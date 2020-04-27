#region Added Project References and General Usings
using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Managers.ManagerOfBasketApplication.Abstracts;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProductStock;
#endregion Added Project References and General Usings

namespace Services.WebAPIOfBasketApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    public class ProductStockController : ControllerBase
    {
        #region Global Private Readonly Properties
        private readonly IManagerOfProductStocks ManagerOfProductStocks;
        #endregion Global Private Readonly Properties


        #region Constructors
        public ProductStockController(IManagerOfProductStocks managerOfProductStocks)
        {
            this.ManagerOfProductStocks = managerOfProductStocks;
        }
        #endregion Constructors


        #region Public Service Functions

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost("idOfProduct:guid"), Route(template: "fetch-product-stock-information-by-product-id")]
        public IActionResult FetchProductStockInformationByProductId([FromBody]Guid idOfProduct)
        {
            var resultFromFetchProductStockInfoByProductId = this.ManagerOfProductStocks
                                                                 .FetchProductStockInformationByProductId(productId: idOfProduct);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromFetchProductStockInfoByProductId);
        }

        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [HttpPost, Route(template: "insert-or-update-existing-product-stock")]
        public IActionResult InsertOrUpdateExistingProductStock(WebAPIModelOfInsertOrUpdateExistsProductStock newlyProductStockInformation)
        {
            var resultFromInsertOrUpdateExistingProductStock = this.ManagerOfProductStocks
                                                                   .InsertOrUpdateExistingProductStock(insertOrUpdateToProductStock: newlyProductStockInformation);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                              value: resultFromInsertOrUpdateExistingProductStock);
        }

        #endregion Public Service Functions
    }
}