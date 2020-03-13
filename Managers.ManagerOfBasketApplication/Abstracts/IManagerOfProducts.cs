#region Added Project References and General Usings
using System;
using Models.OtherNeccesaryModelsOfBasketApplication;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProducts;
#endregion Added Project References and General Usings

namespace Managers.ManagerOfBasketApplication.Abstracts
{
    public interface IManagerOfProducts
    {
        /// <summary>
        /// Sistemde kayitli olan urunler icinden ID degeri eslesen ve Status = true olan urunler icin bilgi getirmeye
        /// yarayan fonksiyon.
        /// NOT : Eger Product'a ait Quantity = 0 veya daha az ise otomatik olarak Product icin Status = 0 atamasi yapilmistir.
        /// </summary>
        /// <param name="idOfProduct">Bilgilerine ulasilmak istenilen Product Id si</param>
        /// <returns></returns>
        ResultModelOfSelectProduct FetchProductById(Guid idOfProduct);


        /// <summary>
        /// Bir URUN'un Katalog da olup olmayacagini ayarlamaya yarayan fonksiyon
        /// </summary>
        /// <param name="idOfProductToBeUpdate">Katalog da varligi belirlenmek istenilen URUN'e ait ID bilgisi</param>
        /// <param name="newStatusValue">Katalog da varligi belirtmek icin gerekli parametre (True = Var - False = Yok)</param>
        /// <returns></returns>
        ResultModel UpdateProductStatus(Guid idOfProductToBeUpdate, Boolean newStatusValue);
    }
}
