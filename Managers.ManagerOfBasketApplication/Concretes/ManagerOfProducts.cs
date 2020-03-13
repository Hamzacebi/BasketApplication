#region Added Project References and Global Usings
using Commons.CommonOfBasketApplication.Constants;
using Models.OtherNeccesaryModelsOfBasketApplication;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfProducts;
#endregion Added Project References and Global Usings

namespace Managers.ManagerOfBasketApplication.Concretes
{
    using System;
    #region Internal Project Usings
    using Abstracts;
    using Abstracts.Base;
    #endregion Internal Project Usings

    public class ManagerOfProducts : ManagerOfBasic, IManagerOfProducts
    {
        #region Explicitly Functions

        ResultModelOfSelectProduct IManagerOfProducts.FetchProductById(Guid idOfProduct)
        {
            ResultModel resultModel = default(ResultModel);
            WebAPIModelOfSelectProduct resultToReturnOfProductInformation = default(WebAPIModelOfSelectProduct);

            if (idOfProduct == Guid.Empty)
            {
                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductIdCannotBeEmpty);
            }
            else
            {
                try
                {
                    DTOOfProducts getProductByIdAndStatus = this.MapperOfProduct
                                                                .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                                            .RepositoryOfProducts
                                                                                            .FetchAnyRecord(whereConditions: x => x.Status == true &&
                                                                                                                                  x.Id == idOfProduct));
                    if (getProductByIdAndStatus == null)
                    {
                        resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.NoProductsFound);
                    }
                    else
                    {
                        resultToReturnOfProductInformation = new WebAPIModelOfSelectProduct
                        {
                            ProductId = getProductByIdAndStatus.Id,
                            ProductName = getProductByIdAndStatus.Name,
                            ProductPrice = getProductByIdAndStatus.Price
                        };
                        resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.ProductSearchIsSuccessful);
                    }
                }
                catch (Exception exception)
                {
                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                 $"{ConstantsOfErrors.TransactionErrorMessageOfFetchProduct} HATA : {exception.Message}");
                }
            }
            return new ResultModelOfSelectProduct
            {
                InformationOfSuccess = resultModel,
                InformationOfProduct = resultToReturnOfProductInformation
            };
        }

        ResultModel IManagerOfProducts.UpdateProductStatus(Guid idOfProductToBeUpdate, bool newStatusValue)
        {
            int numberOfRowsAffected = default(int);
            ResultModel resultModel = default(ResultModel);

            if (idOfProductToBeUpdate == Guid.Empty)
            {
                return ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductIdCannotBeEmpty);
            }
            try
            {
                DTOOfProducts getProductById = this.MapperOfProduct
                                                   .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                               .RepositoryOfProducts
                                                                               .FetchAnyRecord(id: idOfProductToBeUpdate));
                if (getProductById == null)
                {
                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.NoProductsFound);
                }
                else
                {
                    getProductById.Status = newStatusValue;

                    DTOOfProducts updatedProduct = this.MapperOfProduct
                                                           .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                                       .RepositoryOfProducts
                                                                                       .UpdateRecord(recordToUpdate: this.MapperOfProduct
                                                                                                                         .MapToEntity(dtoObject: getProductById)));
                    numberOfRowsAffected = this.UnitOfWorkForBasketApplication.SaveChanges();
                    if (numberOfRowsAffected > 0)
                    {
                        resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.ProductUpdateSuccessful);
                    }
                    else
                    {
                        resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductUpdateUnsuccessful);
                    }
                }
            }
            catch (Exception exception)
            {
                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                             $"{ConstantsOfErrors.TransactionErrorMessageOfUpdateProductStatus} HATA : {exception.Message}");
            }
            finally
            {
                this.UnitOfWorkForBasketApplication.Dispose();
            }
            return resultModel;
        }

        #endregion Explicitly Functions
    }
}
