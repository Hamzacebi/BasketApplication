using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProducts
{
    public sealed class WebAPIModelOfSelectProduct
    {
        public Guid ProductId { get; set; }
        public String ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
    }
}
