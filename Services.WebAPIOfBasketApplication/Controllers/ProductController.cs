#region Added Project References and General Usings
using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Managers.ManagerOfBasketApplication.Abstracts;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProducts;
#endregion Added Project References and General Usings

namespace Services.WebAPIOfBasketApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    public class ProductController : ControllerBase
    {
        #region Global Private Readonly Properties
        private readonly IManagerOfProducts ManagerOfProducts;
        #endregion Global Private Readonly Properties


        #region Constructors
        public ProductController(IManagerOfProducts managerOfProducts)
        {
            this.ManagerOfProducts = managerOfProducts;
        }
        #endregion Constructors


        #region Public Service Functions

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [HttpPost(Name = "productId:guid"), Route(template: "fetch-product-by-product-id")]
        public IActionResult FetchProductByProductId([FromBody]Guid productId)
        {
            var resultFromFetchProductById = this.ManagerOfProducts
                                                 .FetchProductById(idOfProduct: productId);
            if (resultFromFetchProductById.InformationOfSuccess.IsResultSuccessful)
            {
                return StatusCode(statusCode: StatusCodes.Status200OK,
                                  value: resultFromFetchProductById);
            }
            return StatusCode(statusCode: StatusCodes.Status204NoContent,
                              value: resultFromFetchProductById.InformationOfSuccess);
        }


        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [HttpPost, Route(template: "update-product-status")]
        public IActionResult UpdateProductStatus(WebAPIModelOfUpdateProduct newlyProductStatusInformation)
        {
            var resultFromUpdateProductStatus = this.ManagerOfProducts
                                                    .UpdateProductStatus(newStatusValue: newlyProductStatusInformation.NewProductStatus,
                                                                         idOfProductToBeUpdate: newlyProductStatusInformation.IdOfProductToBeUpdate);
            if (resultFromUpdateProductStatus.IsResultSuccessful)
            {
                return StatusCode(statusCode: StatusCodes.Status200OK,
                                  value: resultFromUpdateProductStatus);
            }
            return StatusCode(statusCode: StatusCodes.Status204NoContent,
                              value: resultFromUpdateProductStatus);
        }

        #endregion Public Service Functions
    }
}