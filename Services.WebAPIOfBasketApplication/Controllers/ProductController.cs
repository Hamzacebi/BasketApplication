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
        [HttpPost(Name = "productId:guid"), Route(template: "fetch-product-by-product-id")]
        public IActionResult FetchProductByProductId([FromBody]Guid productId)
        {
            var resultFromFetchProductById = this.ManagerOfProducts
                                                 .FetchProductById(idOfProduct: productId);

            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromFetchProductById);
        }


        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost, Route(template: "update-product-status")]
        public IActionResult UpdateProductStatus(WebAPIModelOfUpdateProduct newlyProductStatusInformation)
        {
            var resultFromUpdateProductStatus = this.ManagerOfProducts
                                                    .UpdateProductStatus(newStatusValue: newlyProductStatusInformation.NewProductStatus,
                                                                         idOfProductToBeUpdate: newlyProductStatusInformation.IdOfProductToBeUpdate);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromUpdateProductStatus);
        }

        #endregion Public Service Functions
    }
}