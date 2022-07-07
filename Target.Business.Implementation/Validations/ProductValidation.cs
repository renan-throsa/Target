using FluentValidation;
using Target.Entities.DTO;
using Target.Entities.Entities;

namespace Target.Business.Implementation.Validations
{
    public class ProductValidation : AbstractValidator<ProductDTO>
    {
        public ProductValidation()
        {
            RuleSet(OperationType.Insert.ToString(), () =>
            {
                RuleFor(m => m.Id).Empty();

                RuleFor(m => m.Description).NotEmpty()
                .WithMessage("A descrição do produto deve ter no mímino 4 caracteres e no máximo 50.");

                RuleFor(m => m.PurchasePrice).InclusiveBetween(0, 1000)
                   .WithMessage("O valor da venda deve estar entre R$ 1,0 e R$ 1000,0.");

                RuleFor(m => m.SalePrice).InclusiveBetween(0, 1000)
                    .WithMessage("O valor da venda deve estar entre R$ 1,0 e R$ 1000,0.");

                RuleFor(m => m.Code).Matches(@"^\d{9,13}$")
                .WithMessage("O código do produto deve ter no mímino 9 caracteres e no máximo 13.");

                RuleFor(m => m.Quantity).InclusiveBetween(0, 100)
                    .WithMessage("A quantidade total deve estar entre 1 e 100.");

                RuleFor(m => m.MinimumQuantity).InclusiveBetween(0, 100)
                    .WithMessage("A quantidade mínima deve estar entre 1 e 100.");

            });

            RuleSet(OperationType.Update.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty();               

                RuleFor(m => m.Description).NotEmpty()
                 .WithMessage("A descrição do produto deve ter no mímino 4 caracteres e no máximo 50.");

                RuleFor(m => m.PurchasePrice).InclusiveBetween(0, 1000)
                   .WithMessage("O valor da venda deve estar entre R$ 1,0 e R$ 1000,0.");

                RuleFor(m => m.SalePrice).InclusiveBetween(0, 1000)
                    .WithMessage("O valor da venda deve estar entre R$ 1,0 e R$ 1000,0.");

                RuleFor(m => m.Code).Matches(@"^\d{9,13}$")
                .WithMessage("O código do produto deve ter no mímino 9 caracteres e no máximo 13.");

                RuleFor(m => m.Quantity).InclusiveBetween(0, 100)
                    .WithMessage("A quantidade total deve estar entre 1 e 100.");

                RuleFor(m => m.MinimumQuantity).InclusiveBetween(0, 100)
                    .WithMessage("A quantidade mínima deve estar entre 1 e 100.");

            });

            RuleSet(OperationType.Delete.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty();
            });

        }
    }
}
