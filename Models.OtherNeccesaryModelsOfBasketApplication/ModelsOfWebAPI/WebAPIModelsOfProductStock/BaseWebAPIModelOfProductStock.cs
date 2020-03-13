using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProductStock
{
    public class BaseWebAPIModelOfProductStock
    {
        public Guid ProductId { get; set; }
        public int ProductStockQuantity { get; set; }
    }
}
