using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMemberBasket
{
    public sealed class WebAPIModelOfSelectMemberBasket : BaseWebAPIModelOfMemberBasket
    {
        public Guid MemberBasketId { get; set; }
        public DateTime MemberBasketCreationDate { get; set; }
    }
}
