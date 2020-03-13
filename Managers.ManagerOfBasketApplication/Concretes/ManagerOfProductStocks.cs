#region Added Project References and Global Usings
using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Commons.CommonOfBasketApplication.Constants;
using Models.OtherNeccesaryModelsOfBasketApplication;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProductStock;
#endregion Added Project References and Global Usings

namespace Managers.ManagerOfBasketApplication.Concretes
{
    #region Internal Project Usings
    using Abstracts;
    using Abstracts.Base;
    #endregion Internal Project Usings

    public class ManagerOfProductStocks : ManagerOfBasic, IManagerOfProductStocks
    {
        #region Global Private Readonly Properties
        private readonly IManagerOfProducts ManagerOfProducts;
        #endregion Global Private Readonly Properties


        #region Constructors 
        /// <summary>
        /// Test projesinden cagirilmak istenildiginde kullanilacak olan Constructor
        /// </summary>
        public ManagerOfProductStocks()
        {
            this.ManagerOfProducts = new ManagerOfProducts();
        }

        /// <summary>
        /// API veya icerisinde IoC bulunduran projelerden cagirilmasi gereken Constructor
        /// </summary>
        /// <param name="managerOfProducts">typeof(Products) tablosuna ait islemlerin yapildigi Manager</param>
        public ManagerOfProductStocks(IManagerOfProducts managerOfProducts)
        {
            this.ManagerOfProducts = managerOfProducts;
        }
        #endregion Constructors


        #region Explicitly Functions

        ResultModelOfSingleForSelectProductStock IManagerOfProductStocks.FetchProductStockInformationByProductId(Guid productId)
        {
            ResultModel resultModel = default(ResultModel);
            WebAPIModelOfSelectProductStock resultFromProductStockInformationToReturn = default(WebAPIModelOfSelectProductStock);

            if (productId == Guid.Empty)
            {
                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductIdCannotBeEmpty);
            }
            else
            {
                var resultFromFetchProductByProductId = this.ManagerOfProducts.FetchProductById(idOfProduct: productId);

                if (!resultFromFetchProductByProductId.InformationOfSuccess.IsResultSuccessful
                    && resultFromFetchProductByProductId.InformationOfProduct == null)
                {
                    resultModel = resultFromFetchProductByProductId.InformationOfSuccess;
                }
                else if (resultFromFetchProductByProductId.InformationOfSuccess.IsResultSuccessful
                         && resultFromFetchProductByProductId.InformationOfProduct != null)
                {
                    try
                    {
                        resultFromProductStockInformationToReturn = this.FetchProductStockInformationByProductId(productId: productId);
                        if (resultFromProductStockInformationToReturn == null)
                        {
                            resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductStockInformationNotFound);
                        }
                        else
                        {
                            resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.ProductStockSearchIsSuccessful);
                        }
                    }
                    catch (Exception exception)
                    {
                        resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                     $"{ConstantsOfErrors.TransactionErrorMessageOfFetchProductStock} HATA : {exception.Message}");
                    } 
                }
            }
            return new ResultModelOfSingleForSelectProductStock
            {
                InformationOfSuccess = resultModel,
                InformationOfProductStock = resultFromProductStockInformationToReturn
            };
        }

        ResultModel IManagerOfProductStocks.InsertOrUpdateExistingProductStock(WebAPIModelOfInsertOrUpdateExistsProductStock insertOrUpdateToProductStock)
        {
            ResultModel resultModel = default(ResultModel);
            if (insertOrUpdateToProductStock == null)
            {
                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductStockInformationCannotBeEmpty);
            }
            else
            {
                if (insertOrUpdateToProductStock.ProductStockQuantity <= 0)
                {
                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.QuantityValueCannotBeNegativeOrEqualToZero);
                }
                else
                {
                    var fetchProductInfoByProductId = this.ManagerOfProducts.FetchProductById(idOfProduct: insertOrUpdateToProductStock.ProductId);

                    if (!fetchProductInfoByProductId.InformationOfSuccess.IsResultSuccessful
                        && fetchProductInfoByProductId.InformationOfProduct == null)
                    {
                        resultModel = fetchProductInfoByProductId.InformationOfSuccess;
                    }
                    else if (fetchProductInfoByProductId.InformationOfSuccess.IsResultSuccessful
                             && fetchProductInfoByProductId.InformationOfProduct != null)
                    {
                        try
                        {
                            int numberOfRowsAffected = default(int);

                            var fetchProductStockInfoByProductId = this.FetchProductStockInformationByProductId(productId: fetchProductInfoByProductId.InformationOfProduct.ProductId);

                            // Urune ait ilk defa Stok bilgisi giriliyor.
                            if (fetchProductStockInfoByProductId == null)
                            {
                                DTOOfProductStocks insertedProductStock =
                                    this.MapperOfProductStock
                                        .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                    .RepositoryOfProductStocks
                                                                    .InsertRecord(recordToInsert: this.MapperOfProductStock
                                                                                                      .MapToEntity(dtoObject: new DTOOfProductStocks
                                                                                                      {
                                                                                                          ProductId = fetchProductInfoByProductId
                                                                                                                      .InformationOfProduct
                                                                                                                      .ProductId,
                                                                                                          Quantity = insertOrUpdateToProductStock
                                                                                                                     .ProductStockQuantity
                                                                                                      })));
                                numberOfRowsAffected = this.UnitOfWorkForBasketApplication.SaveChanges();
                                if (numberOfRowsAffected <= 0)
                                {
                                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductStockInsertUnsuccessful);
                                }
                                else
                                {
                                    resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.ProductStockInsertSuccessful);
                                }
                            }
                            // Urune ait Stok bilgisi guncelleniyor
                            else
                            {
                                DTOOfProductStocks updatedProductStock =
                                    this.MapperOfProductStock.MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                                         .RepositoryOfProductStocks
                                                                                         .UpdateRecord(recordToUpdate: this.MapperOfProductStock
                                                                                                                           .MapToEntity(dtoObject: new DTOOfProductStocks
                                                                                                                           {
                                                                                                                               Id = fetchProductStockInfoByProductId
                                                                                                                                    .ProductStockId,
                                                                                                                               ProductId = fetchProductStockInfoByProductId
                                                                                                                                           .ProductId,
                                                                                                                               Quantity = insertOrUpdateToProductStock.ProductStockQuantity
                                                                                                                           })));
                                numberOfRowsAffected = this.UnitOfWorkForBasketApplication.SaveChanges();
                                if (numberOfRowsAffected <= 0)
                                {
                                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductStockUpdateUnsuccessful);
                                }
                                else
                                {
                                    resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.ProductStockUpdateSuccessful);
                                }
                            }
                        }
                        catch (DbUpdateException dbUpdateException)
                        {
                            if (dbUpdateException.InnerException != null)
                            {
                                if (dbUpdateException.InnerException is SqlException sqlException)
                                {
                                    // ProductId degeri Unique oldugu icin sistemde kayitli olan ProductId lerden bir tanesi tekrar girilirse Unique Exception hatasi 
                                    // almak icin bu blok yazildi. 2627 UniqueKey i ifade etmektedir.
                                    if (sqlException.Number == 2627)
                                    {
                                        resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                                     $"{ConstantsOfErrors.TransactionErrorMessageOfProductIdAlreadyExists}");
                                    }
                                }
                            }
                            else
                            {
                                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                             $"{ConstantsOfErrors.TransactionErrorMessageOfUpdateExistsProductStock} HATA : " +
                                                                             $"{dbUpdateException.Message}");
                            }
                        }
                        catch (Exception exception)
                        {
                            resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                         $"{ConstantsOfErrors.TransactionErrorMessageOfInsertProductStock} HATA : {exception.Message}");
                        }
                        finally
                        {
                            this.UnitOfWorkForBasketApplication.Dispose();
                        }
                    }
                }
            }
            return resultModel;
        }

        #endregion Explicitly Functions


        #region Private Functions

        private WebAPIModelOfSelectProductStock FetchProductStockInformationByProductId(Guid productId)
        {
            DTOOfProductStocks getProductStock = this.MapperOfProductStock
                                                     .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                                 .RepositoryOfProductStocks
                                                                                 .FetchAnyRecord(whereConditions: x => x.ProductId == productId));
            if (getProductStock == null)
            {
                return null;
            }

            return new WebAPIModelOfSelectProductStock
            {
                ProductStockId = getProductStock.Id,
                ProductId = getProductStock.ProductId,
                ProductStockQuantity = getProductStock.Quantity
            };
        }

        #endregion Private Functions
    }
}
