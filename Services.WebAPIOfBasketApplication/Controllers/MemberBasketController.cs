#region Added Project References and General Usings
using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Managers.ManagerOfBasketApplication.Abstracts;
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
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [HttpPost(Name = "{idOfBasketOwnerId:guid}"), Route(template: "buy-products-in-cart-by-basket-owner-id")]
        public IActionResult BuyProductsInCart([FromBody]Guid idOfBasketOwnerId)
        {
            var resultFromBuyProductsInCart = this.ManagerOfMemberBaskets
                                                  .BuyProductsInCart(idOfBasketOwnerId: idOfBasketOwnerId);

            return StatusCode(statusCode: StatusCodes.Status200OK,
                                  value: resultFromBuyProductsInCart);
        }

        #endregion Public Service Functions
    }
}