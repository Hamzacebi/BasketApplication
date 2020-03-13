#region Added Project References and General Usings
using Xunit;
using System;
using Managers.ManagerOfBasketApplication.Abstracts;
using Managers.ManagerOfBasketApplication.Concretes;
#endregion Added Project References and General Usings

namespace Tests.XUnitTestForBasketApplication
{
    public class XUnitTestOfProducts
    {
        #region Private Readonly Properties
        private readonly IManagerOfProducts ManagerOfProducts;
        #endregion Private Readonly Properties

        #region Constructor

        public XUnitTestOfProducts()
        {
            this.ManagerOfProducts = new ManagerOfProducts();
        }

        #endregion Constructor


        #region Test Functions

        [Fact]
        public void FetchProductById()
        {
            var resultFromFetchProductById = this.ManagerOfProducts
                                                 .FetchProductById(idOfProduct: Guid.Parse(input: "846c7698-c472-4337-ba27-00295bca12be"));
        }

        [Fact]
        public void FecthProductByEmptyId()
        {
            var resultFromFetchProductByEmptyId = this.ManagerOfProducts
                                                      .FetchProductById(idOfProduct: Guid.Empty);
        }

        [Fact]
        public void FetchProductByInvalidProductId()
        {
            var resultFromFetchProductByInvalidProductId = this.ManagerOfProducts
                                                               .FetchProductById(idOfProduct: Guid.Parse(input: "5da3e369-0e7e-4b0b-b76f-4a525df3c25c"));
        }


        [Fact]
        public void UpdateProductStatus()
        {
            var resultFromUpdateProductStatus = this.ManagerOfProducts
                                                    .UpdateProductStatus(newStatusValue: false,
                                                                         idOfProductToBeUpdate: Guid.Parse(input: "846c7698-c472-4337-ba27-00295bca12be"));
        }

        #endregion Test Functions
    }
}
