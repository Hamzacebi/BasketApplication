#region Added Project References and General Usings
using Xunit;
using System;
using Managers.ManagerOfBasketApplication.Abstracts;
using Managers.ManagerOfBasketApplication.Concretes;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProductStock;
#endregion Added Project References and General Usings

namespace Tests.XUnitTestForBasketApplication
{
    public class XUnitTestOfProductStocks
    {
        #region Global Private Readonly Properties
        private readonly IManagerOfProductStocks ManagerOfProductStock;
        #endregion Global Private Readonly Properties


        #region Constructors
        public XUnitTestOfProductStocks()
        {
            this.ManagerOfProductStock = new ManagerOfProductStocks();
        }
        #endregion Constructors


        #region Test Functions

        [Fact]
        public void FetchProductStockInformationByProductIdId()
        {
            var resultFromFetchProductStockInformationByProductId = this.FetchProductStockInformationByProductId(productId: Guid.Parse(input: "846c7698-c472-4337-ba27-00295bca12be"));
        }

        [Fact]
        public void FetchProductStockInformationByEmptyProductId()
        {
            var resultFromFetchProductStockInformationByProductId = this.FetchProductStockInformationByProductId(productId: Guid.Empty);
        }

        [Fact]
        public void FetchProductStockInformation()
        {
            var resultFromInsertOrUpdateExistingProductStockInformation = this.ManagerOfProductStock
                                                                              .InsertOrUpdateExistingProductStock(insertOrUpdateToProductStock:
                                                                                                                  new WebAPIModelOfInsertOrUpdateExistsProductStock
                                                                                                                  {
                                                                                                                      ProductStockQuantity = 15,
                                                                                                                      ProductId = Guid.Parse(input: "846c7698-c472-4337-ba27-00295bca12be")
                                                                                                                  });
        }

        [Fact]
        public void FetchProductStockInformationByInvalidProductId()
        {
            var resultFromFetchProductStockInformationByProductId = this.FetchProductStockInformationByProductId(productId: Guid.Parse(input: "5da3e369-0e7e-4b0b-b76f-4a525df3c25c"));
        }

        [Fact]
        public void InsertOrUpdateExistingProductStockInformationByInvalidProductId()
        {
            var resultFromInsertOrUpdateExistingProductStockInformationByInvalidProductId = this.ManagerOfProductStock
                                                                                                .InsertOrUpdateExistingProductStock(insertOrUpdateToProductStock:
                                                                                                                                    new WebAPIModelOfInsertOrUpdateExistsProductStock
                                                                                                                                    {
                                                                                                                                        ProductStockQuantity = 15,
                                                                                                                                        ProductId = Guid.Parse(input: "5da3e369-0e7e-4b0b-b76f-4a525df3c25c")
                                                                                                                                    });
        }

        [Fact]
        public void InsertOrUpdateExistingProductStockByEmptyProductStockInformation()
        {
            var resultFromInsertOrUpdateExistingProductStockInformation = this.ManagerOfProductStock
                                                                              .InsertOrUpdateExistingProductStock(insertOrUpdateToProductStock: null);
        }

        #endregion Test Functions

        #region Private Functions

        ResultModelOfSingleForSelectProductStock FetchProductStockInformationByProductId(Guid productId)
        {
            return this.ManagerOfProductStock
                       .FetchProductStockInformationByProductId(productId: productId);
        }

        #endregion Private Functions
    }
}
