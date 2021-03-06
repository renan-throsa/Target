using Target.Entities.Entities;

namespace Target.Entities.DTO
{
    public class ProductDTO : BaseDTO<Product>
    {
        public float PurchasePrice { get; set; }

        public float SalePrice { get; set; }
        public string Description { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }
        
        public int MinimumQuantity { get; set; }
                
    }
}
