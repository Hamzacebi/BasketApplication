using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMemberBasket
{
    public sealed class WebAPIModelOfInsertMemberBasket : BaseWebAPIModelOfMemberBasket
    {
        public Guid BasketOwnerMemberId { get; set; }
    }
}
