using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProducts
{
    public sealed class WebAPIModelOfUpdateProduct
    {
        public Guid IdOfProductToBeUpdate { get; set; }
        public Boolean NewProductStatus { get; set; }
    }
}
