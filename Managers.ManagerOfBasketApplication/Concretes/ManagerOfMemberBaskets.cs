#region Added Project References and Global Usings
using System;
using System.Linq;
using System.Collections.Generic;
using Commons.CommonOfBasketApplication.Enums;
using Commons.CommonOfBasketApplication.Constants;
using Models.OtherNeccesaryModelsOfBasketApplication;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMemberBasket;
#endregion Added Project References and Global Usings

namespace Managers.ManagerOfBasketApplication.Concretes
{
    #region Internal Project Usings
    using Abstracts;
    using Abstracts.Base;
    #endregion Internal Project Usings

    public class ManagerOfMemberBaskets : ManagerOfBasic, IManagerOfMemberBaskets
    {
        #region Global Private Readonly Properties
        private readonly IManagerOfMembers ManagerOfMembers;
        private readonly IManagerOfProducts ManagerOfProducts;
        private readonly IManagerOfProductStocks ManagerOfProductStocks;
        #endregion Global Private Readonly Properties

        #region Constructors

        /// <summary>
        /// Test projesinden cagirilmak istenildiginde kullanilan Constructor
        /// </summary>
        public ManagerOfMemberBaskets()
        {
            this.ManagerOfMembers = new ManagerOfMembers();
            this.ManagerOfProducts = new ManagerOfProducts();
            this.ManagerOfProductStocks = new ManagerOfProductStocks();
        }

        /// <summary>
        /// API veya icerisinde IoC bulunduran projelerden cagirilmasi gereken Constructor
        /// </summary>
        /// <param name="managerOfMembers">typeof(Members) tablosuna ait islemlerin yapildigi Manager</param>
        /// <param name="managerOfProducts">typeof(Products) tablosuna ait islemlerin yapildigi Manager</param>
        /// <param name="managerOfProductStocks">typeof(ProductStocks) tablosuna ait islemlerin yapildigi Manager</param>
        public ManagerOfMemberBaskets(IManagerOfMembers managerOfMembers,
                                      IManagerOfProducts managerOfProducts,
                                      IManagerOfProductStocks managerOfProductStocks)
        {
            this.ManagerOfMembers = managerOfMembers;
            this.ManagerOfProducts = managerOfProducts;
            this.ManagerOfProductStocks = managerOfProductStocks;
        }

        #endregion Constructors


        #region Explicitly Functions

        ResultModel IManagerOfMemberBaskets.BuyProductsInCart(Guid idOfBasketOwnerId)
        {
            ResultModel resultModel = default(ResultModel);

            var isThereAnyMember = this.ManagerOfMembers.FetchMemberById(idOfMember: idOfBasketOwnerId);
            if (!isThereAnyMember.SuccessInformation.IsResultSuccessful && isThereAnyMember.MemberInformation == null)
            {
                return isThereAnyMember.SuccessInformation;
            }

            try
            {
                var allProductsOwnedByTheMember = this.FetchAllProductsOwnedByTheMember(idOfBasketOwner: idOfBasketOwnerId);
                if (!allProductsOwnedByTheMember.Any())
                {
                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.YouHaveNoItemsInYourCart);
                }
                else
                {
                    int numberOfRowsAffected, numberOfProductsToBeUpdated = default(int);

                    foreach (DTOOfMemberBaskets productInfoInTheBasket in allProductsOwnedByTheMember)
                    {
                        /* Satin alinmak istenilen URUN'e ait bilgiler listeleniyor. */
                        var fetchProductInfoByProductId = this.ManagerOfProducts
                                                              .FetchProductById(idOfProduct: productInfoInTheBasket.ProductId);
                        if (!fetchProductInfoByProductId.InformationOfSuccess.IsResultSuccessful &&
                            fetchProductInfoByProductId.InformationOfProduct == null)
                        {
                            return fetchProductInfoByProductId.InformationOfSuccess;
                        }

                        /* Satin alinmak istenilen URUN'e ait STOK bilgisi listeleniyor */
                        var fetchProductStockInfoByProductId =
                            this.ManagerOfProductStocks
                                .FetchProductStockInformationByProductId(productId: fetchProductInfoByProductId.InformationOfProduct.ProductId);
                        if (!fetchProductStockInfoByProductId.InformationOfSuccess.IsResultSuccessful &&
                            fetchProductStockInfoByProductId.InformationOfProductStock == null)
                        {
                            return fetchProductStockInfoByProductId.InformationOfSuccess;
                        }

                        /* Satin alinmak istenilen URUN'e ait URUN adeti ile URUN'e ait STOK adeti karsilastirilmasi yapiliyor.
                         * Alinmak istenilen URUN adeti, STOK adetine esit veya kucuk ise satis yapilir
                         */
                        if (productInfoInTheBasket.Quantity <= fetchProductStockInfoByProductId.InformationOfProductStock.ProductStockQuantity)
                        {
                            #region KULLANICI'ya ait SEPET'teki tum URUN'lerin ClosingReasonType degeri Ordered (Satildi) olarak ayarlanir ve SEPET guncellenir

                            productInfoInTheBasket.Status = false;
                            productInfoInTheBasket.ReleaseDate = DateTime.Now;
                            productInfoInTheBasket.ClosingReasonId = (byte)BasketClosingReasonTypes.Ordered;

                            DTOOfMemberBaskets wasItUpdatedBasket =
                                this.MapperOfMemberBaskets
                                    .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                .RepositoryOfMemberBaskets
                                                                .UpdateRecord(recordToUpdate: this.MapperOfMemberBaskets
                                                                                                  .MapToEntity(dtoObject: productInfoInTheBasket)));

                            #endregion KULLANICI'ya ait SEPET'teki tum URUN'lerin ClosingReasonType degeri Ordered (Satildi) olarak ayarlanir ve SEPET guncellenir

                            #region Satin alinan URUN'ler icin satin alinan URUN adedi kadar STOK azaltimi yapilir

                            fetchProductStockInfoByProductId.InformationOfProductStock.ProductStockQuantity -= productInfoInTheBasket.Quantity;

                            DTOOfProductStocks wasItUpdatedProductStock =
                                this.MapperOfProductStock
                                    .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                .RepositoryOfProductStocks
                                                                .UpdateRecord(recordToUpdate: this.MapperOfProductStock
                                                                                                  .MapToEntity(dtoObject: new DTOOfProductStocks
                                                                                                  {
                                                                                                      Id = fetchProductStockInfoByProductId
                                                                                                           .InformationOfProductStock
                                                                                                           .ProductStockId,
                                                                                                      ProductId = fetchProductStockInfoByProductId
                                                                                                                  .InformationOfProductStock
                                                                                                                  .ProductId,
                                                                                                      Quantity = fetchProductStockInfoByProductId
                                                                                                                 .InformationOfProductStock
                                                                                                                 .ProductStockQuantity

                                                                                                  })));

                            #endregion Satin alinan URUN'ler icin satin alinan URUN adedi kadar STOK azaltimi yapilir

                            #region URUN STOK degeri 0 veya daha az olursa URUN'un satilmamasi icin URUN'un Status degeri false yapilir

                            if (wasItUpdatedProductStock.Quantity <= 0)
                            {
                                numberOfProductsToBeUpdated++;

                                DTOOfProducts wasItUpdatedProduct =
                                    this.MapperOfProduct
                                        .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                    .RepositoryOfProducts
                                                                    .UpdateRecord(recordToUpdate: this.MapperOfProduct
                                                                                                      .MapToEntity(dtoObject: new DTOOfProducts
                                                                                                      {
                                                                                                          Status = false,
                                                                                                          Name = fetchProductInfoByProductId
                                                                                                                 .InformationOfProduct
                                                                                                                 .ProductName,
                                                                                                          Price = fetchProductInfoByProductId
                                                                                                                  .InformationOfProduct
                                                                                                                  .ProductPrice,
                                                                                                          Id = wasItUpdatedProductStock.ProductId
                                                                                                      })));
                            }
                            #endregion URUN STOK degeri 0 veya daha az olursa URUN'un satilmamasi icin URUN'un Status degeri false yapilir
                        }
                        else
                        {
                            return ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                  $"Sepetinizde olan ve SATIN almak istediginiz " +
                                                                  $"{fetchProductInfoByProductId.InformationOfProduct.ProductName} adli URUN icin " +
                                                                  $"yeterli sayida STOK bulunmamaktadir. Lutfen almak istediginiz bu URUN icin adet " +
                                                                  $"sayisi en fazla {fetchProductStockInfoByProductId.InformationOfProductStock.ProductStockQuantity} " +
                                                                  $"tane olacak sekilde siparisinizi yeniden giriniz!");
                        }
                    }
                    numberOfRowsAffected = this.UnitOfWorkForBasketApplication.SaveChanges();
                    if (numberOfRowsAffected == ((allProductsOwnedByTheMember.Count() * 2) + numberOfProductsToBeUpdated))
                    {
                        resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.BuyProductsInBasketIsSuccessful);
                    }
                    else
                    {
                        resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.BuyProductsInBasketIsUnsuccessful);
                    }
                }
            }
            catch (Exception exception)
            {
                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                             $"{ConstantsOfErrors.TransactionErrorMessageOfBuyProductsInBasket} HATA : {exception.Message}");
            }
            finally
            {
                this.UnitOfWorkForBasketApplication.Dispose();
            }
            return resultModel;
        }


        ResultModel IManagerOfMemberBaskets.DeleteAnyProductInTheBasket(Guid idOfMemberBasket)
        {
            ResultModel resultModel = default(ResultModel);
            if (idOfMemberBasket == Guid.Empty)
            {
                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.BasketIdCannotBeEmpty);
            }
            else
            {
                try
                {
                    DTOOfMemberBaskets fetchRecordInTheMemberBasket = this.FetchProductInTheBasketByBasketId(idOfMemberBasket: idOfMemberBasket);
                    if (fetchRecordInTheMemberBasket == null)
                    {
                        resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.TheProductToBeDeletedWasNotFoundInTheBasket);
                    }
                    else
                    {
                        fetchRecordInTheMemberBasket.Status = false;
                        fetchRecordInTheMemberBasket.ReleaseDate = DateTime.Now;
                        fetchRecordInTheMemberBasket.ClosingReasonId = (byte)BasketClosingReasonTypes.Deleted;

                        var wasItDeletedSelectedBasket = this.UpdateSelectedProductInCart(newlyInformationForProductInTheBasket: fetchRecordInTheMemberBasket);
                        if (!wasItDeletedSelectedBasket.IsResultSuccessful)
                        {
                            resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.DeleteProductInTheBasketIsUnsuccessful);
                        }
                        else
                        {
                            resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.DeleteProductInTheBasketIsSuccessful);
                        }
                    }
                }
                catch (Exception exception)
                {
                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                 $"{ConstantsOfErrors.TransactionErrorMessageOfDeleteProductToCart} HATA : {exception.Message}");
                }
                finally
                {
                    this.UnitOfWorkForBasketApplication.Dispose();
                }
            }
            return resultModel;
        }


        ResultModel IManagerOfMemberBaskets.AddProductToCart(WebAPIModelOfInsertMemberBasket productToBeAddedToCart)
        {
            ResultModel resultModel = default(ResultModel);
            if (productToBeAddedToCart == null)
            {
                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.ProductInformationToBeAddedToTheCartCannotBeEmpty);
            }
            else
            {
                var isThereAnyMember = this.ManagerOfMembers.FetchMemberById(idOfMember: productToBeAddedToCart.BasketOwnerMemberId);
                if (!isThereAnyMember.SuccessInformation.IsResultSuccessful && isThereAnyMember.MemberInformation == null)
                {
                    return isThereAnyMember.SuccessInformation;
                }

                var isThereAnyProduct = this.ManagerOfProducts.FetchProductById(idOfProduct: productToBeAddedToCart.ProductId);
                if (!isThereAnyProduct.InformationOfSuccess.IsResultSuccessful && isThereAnyProduct.InformationOfProduct == null)
                {
                    return isThereAnyProduct.InformationOfSuccess;
                }

                var isThereAnyProductStock = this.ManagerOfProductStocks.FetchProductStockInformationByProductId(productId: productToBeAddedToCart.ProductId);
                if (!isThereAnyProductStock.InformationOfSuccess.IsResultSuccessful && isThereAnyProductStock.InformationOfProductStock == null)
                {
                    return isThereAnyProductStock.InformationOfSuccess;
                }

                if (isThereAnyMember.MemberInformation != null &&
                    isThereAnyProduct.InformationOfProduct != null &&
                    isThereAnyProductStock.InformationOfProductStock != null)
                {
                    if (productToBeAddedToCart.ProductQuantity <= 0)
                    {
                        return ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.QuantityValueCannotBeNegativeOrEqualToZero);
                    }
                    if (productToBeAddedToCart.ProductQuantity > isThereAnyProductStock.InformationOfProductStock.ProductStockQuantity)
                    {
                        resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.WarningOfInsufficientStock);
                    }
                    else
                    {
                        /* 
                         * Ilgili kullanici icin Sepete eklenmek istenilen Urun, daha onceden sepetten silinmemis veya
                         * sepete eklenip satin alinmamis halinin varligi kontrol edilir.
                         */
                        DTOOfMemberBaskets isThereThisProductInTheBasket =
                            this.MapperOfMemberBaskets
                                .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                            .RepositoryOfMemberBaskets
                                                            .FetchAnyRecord(whereConditions: x => x.Status == true &&
                                                                                                  x.ReleaseDate == null &&
                                                                                                  x.ProductId == productToBeAddedToCart.ProductId &&
                                                                                                  x.MemberId == productToBeAddedToCart.BasketOwnerMemberId &&
                                                                                                  x.ClosingReasonId == (byte)BasketClosingReasonTypes.Added));
                        /* 
                         * Eger Urun, daha onceden Sepetten silinmemis veya satin alinmamis 
                         * ise ya da hic eklenmemis ise ilk defa URUN, Sepete eklenir
                         */
                        if (isThereThisProductInTheBasket == null)
                        {
                            int numberOfRowsAffected = default(int);
                            try
                            {
                                DTOOfMemberBaskets addedProductToCart =
                                    this.MapperOfMemberBaskets
                                        .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                    .RepositoryOfMemberBaskets
                                                                    .InsertRecord(recordToInsert: this.MapperOfMemberBaskets
                                                                                                      .MapToEntity(dtoObject: new DTOOfMemberBaskets
                                                                                                      {
                                                                                                          Status = true,
                                                                                                          ReleaseDate = null,
                                                                                                          Id = Guid.NewGuid(),
                                                                                                          CreationDate = DateTime.Now,
                                                                                                          ProductId = productToBeAddedToCart.ProductId,
                                                                                                          Quantity = productToBeAddedToCart.ProductQuantity,
                                                                                                          MemberId = productToBeAddedToCart.BasketOwnerMemberId,
                                                                                                          ClosingReasonId = (byte)BasketClosingReasonTypes.Added,
                                                                                                      })));
                                numberOfRowsAffected = this.UnitOfWorkForBasketApplication.SaveChanges();
                                if (numberOfRowsAffected <= 0)
                                {
                                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.AddProductToCartUnsuccessful);
                                }
                                else
                                {
                                    resultModel = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.AddProductToCartSuccessful);
                                }
                            }
                            catch (Exception exception)
                            {
                                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                             $"{ConstantsOfErrors.TransactionErrorMessageOfAddProductToCart} HATA : {exception.Message}");
                            }
                            finally
                            {
                                this.UnitOfWorkForBasketApplication.Dispose();
                            }
                        }
                        /* 
                         *  Urun daha onceden Sepet'e eklenmis ise ve yeterli Stok varsa URUN'e ait adet artirimi yapilir.
                         */
                        else
                        {
                            /* Alinmak istenilen URUN adeti, Stok'ta bulunan adetten buyuk mu diye kontrol edilir */
                            if ((productToBeAddedToCart.ProductQuantity + isThereThisProductInTheBasket.Quantity) >
                                isThereAnyProductStock.InformationOfProductStock.ProductStockQuantity)
                            {
                                resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.WarningOfInsufficientStock);
                            }
                            else
                            {
                                /* Alinmak istenilen URUN adeti, Stok degeriyle ayni ise veya daha kucuk ise 
                                 * Urun'e ait adet sayisi eski sayi ile toplanarak Sepette ki deger guncellenir
                                 */
                                isThereThisProductInTheBasket.Quantity += productToBeAddedToCart.ProductQuantity;

                                resultModel = this.UpdateSelectedProductInCart(newlyInformationForProductInTheBasket: isThereThisProductInTheBasket);
                            }
                        }
                    }
                }
                else
                {
                    resultModel = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.GeneralWarningForAddProductToCart);
                }
            }

            return resultModel;
        }


        ResultModelOfListForSelectMemberBasket IManagerOfMemberBaskets.FetchAllProductsOwnedByTheMember(Guid memberId)
        {
            ResultModel resultToReturn = default(ResultModel);
            List<WebAPIModelOfSelectMemberBasket> allProducts = default(List<WebAPIModelOfSelectMemberBasket>);

            var isThereAnyMember = this.ManagerOfMembers.FetchMemberById(idOfMember: memberId);
            if (!isThereAnyMember.SuccessInformation.IsResultSuccessful && isThereAnyMember.MemberInformation == null)
            {
                resultToReturn = isThereAnyMember.SuccessInformation;
            }
            else
            {
                try
                {
                    IEnumerable<DTOOfMemberBaskets> allProductsOwnedByTheMember = this.FetchAllProductsOwnedByTheMember(idOfBasketOwner: memberId);
                    if (!allProductsOwnedByTheMember.Any())
                    {
                        resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.YouHaveNoItemsInYourCart);
                    }
                    else
                    {
                        allProducts = new List<WebAPIModelOfSelectMemberBasket>();
                        foreach (DTOOfMemberBaskets theProduct in allProductsOwnedByTheMember)
                        {
                            allProducts.Add(item: new WebAPIModelOfSelectMemberBasket
                            {
                                MemberBasketId = theProduct.Id,
                                ProductId = theProduct.ProductId,
                                ProductQuantity = theProduct.Quantity,
                                MemberBasketCreationDate = theProduct.CreationDate
                            });
                        }
                        resultToReturn = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.FetchAllProductsInMemberBasketIsSuccessful);
                    }
                }
                catch (Exception exception)
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                    $"{ConstantsOfErrors.TransactionErrorMessageOfFetchProductsOwnedByTheMember} HATA : {exception.Message}");
                }
                finally
                {
                    //this.UnitOfWorkForBasketApplication.Dispose();
                }
            }
            return new ResultModelOfListForSelectMemberBasket
            {
                InformationOfSuccess = resultToReturn,
                ProductsOwnedByTheMember = allProducts
            };
        }

        #endregion Explicitly Functions


        #region Private Functions

        private DTOOfMemberBaskets FetchProductInTheBasketByBasketId(Guid idOfMemberBasket)
        {
            return this.MapperOfMemberBaskets
                       .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                   .RepositoryOfMemberBaskets
                                                   .FetchAnyRecord(whereConditions: x => x.Status == true &&
                                                                                         x.ReleaseDate == null &&
                                                                                         x.Id == idOfMemberBasket &&
                                                                                         x.ClosingReasonId == (byte)BasketClosingReasonTypes.Added));
        }


        private IEnumerable<DTOOfMemberBaskets> FetchAllProductsOwnedByTheMember(Guid idOfBasketOwner)
        {
            return this.MapperOfMemberBaskets
                                    .MapToDTOList(entityList: this.UnitOfWorkForBasketApplication
                                                                  .RepositoryOfMemberBaskets
                                                                  .FetchAllRecords(whereConditions: x => x.Status == true &&
                                                                                                         x.ReleaseDate == null &&
                                                                                                         x.MemberId == idOfBasketOwner &&
                                                                                                         x.ClosingReasonId == (byte)BasketClosingReasonTypes.Added)
                                                                  .ToList());
        }


        private ResultModel UpdateSelectedProductInCart(DTOOfMemberBaskets newlyInformationForProductInTheBasket)
        {
            ResultModel resultToReturn = default(ResultModel);

            if (newlyInformationForProductInTheBasket == null)
            {
                resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                ConstantsOfResults.TheInformationOfTheProductToBeUpdatedInTheBasketCannotBeEmpty);
            }
            else
            {
                int numberOfRowsAffected = default(int);


                DTOOfMemberBaskets updatedProductInTheBasket =
                    this.MapperOfMemberBaskets
                        .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                    .RepositoryOfMemberBaskets
                                                    .UpdateRecord(recordToUpdate: this.MapperOfMemberBaskets
                                                                                      .MapToEntity(dtoObject: newlyInformationForProductInTheBasket)));
                try
                {
                    numberOfRowsAffected = this.UnitOfWorkForBasketApplication.SaveChanges();
                    if (numberOfRowsAffected <= 0)
                    {
                        resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.UpdateProductInTheBasketIsUnsuccessful);
                    }
                    else
                    {
                        resultToReturn = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.UpdateProductInTheBasketIsSuccessful);
                    }
                }
                catch (Exception exception)
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                    $"{ConstantsOfErrors.TransactionErrorMessageOfUpdateProductInTheBasket} HATA : {exception.Message}");
                }
                finally
                {
                    this.UnitOfWorkForBasketApplication.Dispose();
                }
            }
            return resultToReturn;
        }

        #endregion Private Functions
    }
}
