#region Added Project References and General Usings
using Xunit;
using System;
using Managers.ManagerOfBasketApplication.Abstracts;
using Managers.ManagerOfBasketApplication.Concretes;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMemberBasket;
#endregion Added Project References and General Usings

namespace Tests.XUnitTestForBasketApplication
{
    public class XUnitTestOfMemberBaskets
    {
        #region Private Readonly Properties
        private readonly IManagerOfMemberBaskets ManagerOfMemberBaskets;
        #endregion Private Readonly Properties


        #region Constructors
        public XUnitTestOfMemberBaskets()
        {
            this.ManagerOfMemberBaskets = new ManagerOfMemberBaskets();
        }
        #endregion Constructors


        #region Test Functions

        #region Add Product To Cart 

        [Fact]
        public void AddProductToCartByEmptyValues()
        {
            var wasItAddedOrUpdated = this.ManagerOfMemberBaskets
                                          .AddProductToCart(productToBeAddedToCart: null);
        }

        [Fact]
        public void AddProductToCartCorrectValues()
        {
            var wasItAddedOrUpdated = this.ManagerOfMemberBaskets
                                          .AddProductToCart(productToBeAddedToCart: new WebAPIModelOfInsertMemberBasket
                                          {
                                              ProductQuantity = 12,
                                              ProductId = Guid.Parse(input: "846c7698-c472-4337-ba27-00295bca12be"),
                                              BasketOwnerMemberId = Guid.Parse(input: "682e9a2a-90d3-4061-86f0-7b0c1ef2230e")
                                          });
        }

        [Fact]
        public void AddProductToCartByDefaultValues()
        {
            var wasItAddedOrUpdated = this.ManagerOfMemberBaskets
                                          .AddProductToCart(productToBeAddedToCart: new WebAPIModelOfInsertMemberBasket { });
        }

        [Fact]
        public void AddProductToCartByInvalidValues()
        {
            var wasItAddedOrUpdated = this.ManagerOfMemberBaskets
                                          .AddProductToCart(productToBeAddedToCart: new WebAPIModelOfInsertMemberBasket
                                          {
                                              ProductQuantity = -1,
                                              ProductId = Guid.Parse(input: "a885ceec-e3a9-4bad-92a5-3fd162d6c125"),
                                              BasketOwnerMemberId = Guid.Parse(input: "c133c386-9364-4eee-aa20-c24ac30283d1")
                                          });
        }

        #endregion Add Product To Cart 


        #region Delete Any Product In The Basket

        [Fact]
        public void DeleteAnyProductInTheBasketByEmptyId()
        {
            var wasItDeleted = this.ManagerOfMemberBaskets
                                   .DeleteAnyProductInTheBasket(idOfMemberBasket: Guid.Empty);
        }

        [Fact]
        public void DeleteAnyProductInTheBasketByInvalidId()
        {
            var wasItDeleted = this.ManagerOfMemberBaskets
                                   .DeleteAnyProductInTheBasket(idOfMemberBasket: Guid.Parse(input: "682e9a2a-90d3-4061-86f0-7b0c1ef2230e"));
        }

        [Fact]
        public void DeleteAnyProductInTheBasketByCorrectId()
        {
            var wasItDeleted = this.ManagerOfMemberBaskets
                                   .DeleteAnyProductInTheBasket(idOfMemberBasket: Guid.Parse(input: "8ff2dbb8-92a7-40c2-8c68-a426b52a8fe9"));
        }

        #endregion Delete Any Product In The Basket


        #region Fetch All Products Owned By The Member

        [Fact]
        public void FetchAllProductsOwnedByTheMember()
        {
            var allProducts = this.ManagerOfMemberBaskets
                                  .FetchAllProductsOwnedByTheMember(memberId: Guid.Parse(input: "682e9a2a-90d3-4061-86f0-7b0c1ef2230e"));
        }

        [Fact]
        public void FetchAllProductsOwnedByTheMember_MembersHaveNoProductInTheBasket()
        {
            var allProducts = this.ManagerOfMemberBaskets
                                  .FetchAllProductsOwnedByTheMember(memberId: Guid.Parse(input: "4e2bd134-1a19-40bf-b480-b85c59bde0f0"));
        }

        [Fact]
        public void FetchAllProductsOwnedByTheMemberWithInvalidMemberId_CorrectRequest()
        {
            var allProducts = this.ManagerOfMemberBaskets
                                  .FetchAllProductsOwnedByTheMember(memberId: Guid.Parse(input: "682e9a2a-90d3-4061-86f1-7b0c1ef2230e"));
        }

        #endregion Fetch All Products Owned By The Member


        #region Buy Products In Cart

        [Fact]
        public void BuyProductsInTheCartByEmptyOwnerId()
        {
            var wasItBuyed = this.ManagerOfMemberBaskets
                                 .BuyProductsInCart(idOfBasketOwnerId: Guid.Empty);
        }

        [Fact]
        public void BuyProductsInTheCartByValidOwnerId()
        {
            var wasItBuyed = this.ManagerOfMemberBaskets
                                 .BuyProductsInCart(idOfBasketOwnerId: Guid.Parse(input: "682e9a2a-90d3-4061-86f0-7b0c1ef2230e"));
        }

        [Fact]
        public void BuyProductsInTheCartByInvalidOwnerId()
        {
            var wasItBuyed = this.ManagerOfMemberBaskets
                                 .BuyProductsInCart(idOfBasketOwnerId: Guid.Parse(input: "235e9a2a-90d3-4061-86f0-7b0c1ef2265e"));
        }

        #endregion Buy Products In Cart

        #endregion Test Functions
    }
}
