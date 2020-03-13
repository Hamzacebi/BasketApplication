#region Added Project References and General Usings
using System;
using Models.OtherNeccesaryModelsOfBasketApplication;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMemberBasket;
#endregion Added Project References and General Usings

namespace Managers.ManagerOfBasketApplication.Abstracts
{
    public interface IManagerOfMemberBaskets
    {
        /// <summary>
        /// Bir KULLANICI'nin kendisine ait olan SEPET'inde ki tum URUN'leri satin almasini saglayan fonksiyon
        /// </summary>
        /// <param name="idOfBasketOwnerId">SEPET'inde ki URUN'leri satin almak isteyen KULLANICI'ya ait ID bilgisi</param>
        /// <returns></returns>
        ResultModel BuyProductsInCart(Guid idOfBasketOwnerId);


        /// <summary>
        /// SEPET'te mevcut olan bir URUN'u SEPET'ten silmeye yarayan fonksiyon 
        /// </summary>
        /// <param name="idOfMemberBasket">Silinmek istenilen URUN'e ait SEPET ID bilgisi</param>
        /// <returns></returns>
        ResultModel DeleteAnyProductInTheBasket(Guid idOfMemberBasket);


        /// <summary>
        /// Bir KULLANICI icin istedigi bir URUN'u istedigi sayida ekleyebilmeyi saglayan fonksiyon
        /// </summary>
        /// <param name="productToBeAddedToCart">Kullanici - Urun ve Urun Sayisi bilgileri</param>
        /// <returns></returns>
        ResultModel AddProductToCart(WebAPIModelOfInsertMemberBasket productToBeAddedToCart);


        /// <summary>
        /// Bir KULLANICI'nin kendisine ait olan SEPET icerisinde BasketClosingReasonType = Added and
        /// ReleaseDate = NULL and Status = True olan tum URUN'lerini listelemeye yarayan fonksiyon
        /// </summary>
        /// <param name="memberId">SEPET bilgisine ulasilmak istenilen KULLANICI'ya ait ID bilgisi</param>
        /// <returns></returns>
        ResultModelOfListForSelectMemberBasket FetchAllProductsOwnedByTheMember(Guid memberId);
    }
}
