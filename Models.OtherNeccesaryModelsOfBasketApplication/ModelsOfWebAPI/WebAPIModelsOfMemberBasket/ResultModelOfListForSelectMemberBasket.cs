using System.Collections.Generic;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMemberBasket
{
    public sealed class ResultModelOfListForSelectMemberBasket
    {
        public ResultModel InformationOfSuccess { get; set; }
        public List<WebAPIModelOfSelectMemberBasket> ProductsOwnedByTheMember { get; set; }
    }
}
