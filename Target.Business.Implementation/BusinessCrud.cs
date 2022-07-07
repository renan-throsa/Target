using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Target.Business.Contract;
using Target.Entities.DTO;
using Target.Entities.Entities;
using Target.Repositories.Contract;

namespace Target.Business.Implementation
{
    public abstract class BusinessCrud<TEntity, TObject> : IBaseBusiness<TEntity, TObject> where TEntity : IEntity where TObject : BaseDTO<TEntity>
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IValidator<TObject> _validator;
        protected readonly IMapper _mapper;

        public BusinessCrud(IRepository<TEntity> repository, AbstractValidator<TObject> validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Response> AddAsync(TObject tObject)
        {
            var result = _validator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Insert.ToString()));
            if (result.IsValid)
            {
                var entity = _mapper.Map<TEntity>(tObject);
                await _repository.UpdateAsync(entity);
                return Response(result.IsValid, _mapper.Map<TObject>(entity));
            }
            else
            {
                return Response(result.IsValid, result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }

        public async Task<IEnumerable<TObject>> AllAsync()
        {
            var entities = await _repository.AllAsync();
            return entities.Select(x => _mapper.Map<TObject>(x));
        }

        public async Task<int> DeleteAsync(int id)
        {            
            return await _repository.DeleteAsync(id);
        }

        public async Task<TObject> FindSync(int Id)
        {
            return _mapper.Map<TObject>(await _repository.FindSync(Id));
        }

        public async Task<Response> UpdateAsync(TObject tObject)
        {
            var result = _validator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Update.ToString()));
            if (result.IsValid)
            {
                var entity = _mapper.Map<TEntity>(tObject);
                await _repository.UpdateAsync(entity); ;
                return Response(result.IsValid, _mapper.Map<TObject>(entity));
            }
            else
            {
                return Response(result.IsValid, result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }

        private Response Response(bool valide, object result = null)
        {
            return
            new Response
            {
                success = valide,
                payload = result
            };
        }
    }
}
