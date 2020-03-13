#region Added Project References and General Usings
using System;
using Models.OtherNeccesaryModelsOfBasketApplication;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProductStock;
#endregion Added Project References and General Usings

namespace Managers.ManagerOfBasketApplication.Abstracts
{
    public interface IManagerOfProductStocks
    {
        /// <summary>
        /// Urun'e ait Stok bilgisini listelemeye yarayan fonksiyon
        /// </summary>
        /// <param name="productId">Listelenmek istenilen Stok bilgisine sahip URUN Id (ProductID)</param>
        /// <returns></returns>
        ResultModelOfSingleForSelectProductStock FetchProductStockInformationByProductId(Guid productId);

        /// <summary>
        /// Sistemde kayitli olan bir Product icin Stock bilgisi eklemeye yarayan fonksiyon
        /// </summary>
        /// <param name="insertToProductStock">Eklenmek istenilen Stock bilgisi</param>
        /// <returns></returns>
        ResultModel InsertOrUpdateExistingProductStock(WebAPIModelOfInsertOrUpdateExistsProductStock insertOrUpdateToProductStock);
    }
}
