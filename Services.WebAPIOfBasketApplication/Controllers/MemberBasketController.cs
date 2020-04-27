#region Added Project References and General Usings
using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Managers.ManagerOfBasketApplication.Abstracts;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMemberBasket;
#endregion Added Project References and General Usings

namespace Services.WebAPIOfBasketApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    public class MemberBasketController : ControllerBase
    {
        #region Global Private Readonly Properties
        private readonly IManagerOfMemberBaskets ManagerOfMemberBaskets;
        #endregion Global Private Readonly Properties


        #region Constructors
        public MemberBasketController(IManagerOfMemberBaskets managerOfMemberBaskets)
        {
            this.ManagerOfMemberBaskets = managerOfMemberBaskets;
        }
        #endregion Constructors


        #region Public Service Functions

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost(Name = "{idOfBasketOwnerId:guid}"), Route(template: "buy-products-in-cart-by-basket-owner-id")]
        public IActionResult BuyProductsInCart([FromBody]Guid idOfBasketOwnerId)
        {
            var resultFromBuyProductsInCart = this.ManagerOfMemberBaskets
                                                  .BuyProductsInCart(idOfBasketOwnerId: idOfBasketOwnerId);

            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromBuyProductsInCart);
        }


        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost(Name = "{idOfMemberBasket:guid}"), Route(template: "delete-any-product-in-the-basket")]
        public IActionResult DeleteAnyProductInTheBasket([FromBody]Guid idOfMemberBasket)
        {
            var resultFromDeleteAnyProductInTheBasket = this.ManagerOfMemberBaskets
                                                            .DeleteAnyProductInTheBasket(idOfMemberBasket: idOfMemberBasket);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromDeleteAnyProductInTheBasket);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost, Route(template: "add-product-to-cart")]
        public IActionResult AddProductToCart(WebAPIModelOfInsertMemberBasket productToAddedToBasket)
        {
            var resultFromAddProductToCart = this.ManagerOfMemberBaskets
                                                 .AddProductToCart(productToBeAddedToCart: productToAddedToBasket);

            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromAddProductToCart);
        }


        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost(Name = "memberId:guid"), Route(template: "fetch-all-products-owned-by-the-member")]
        public IActionResult FetchAllProductsOwnedByTheMember([FromBody]Guid memberId)
        {
            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: this.ManagerOfMemberBaskets
                                         .FetchAllProductsOwnedByTheMember(memberId));
        }

        #endregion Public Service Functions
    }
}