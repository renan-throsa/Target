using Target.Entities.Entities;

namespace Target.Entities.DTO
{
    public abstract class BaseDTO<TEntity> where TEntity : IEntity
    {
        public int Id { get; set; }        
    }
}
