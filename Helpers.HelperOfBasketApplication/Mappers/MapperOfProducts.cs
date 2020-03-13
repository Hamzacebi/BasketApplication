#region Added Project References and General Usings
using System.Collections.Generic;
using Models.EntitiesOfBasketApplication.Entities;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject;
#endregion Added Project References and General Usings

namespace Helpers.HelperOfBasketApplication.Mappers
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public sealed class MapperOfProducts : IMapper<Products, DTOOfProducts>
    {
        #region Explicitly Functions

        DTOOfProducts IMapper<Products, DTOOfProducts>.MapToDTO(Products entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfProducts
                {
                    Id = entityObject.Id,
                    Name = entityObject.Name,
                    Price = entityObject.Price,
                    Status = entityObject.Status
                };
            }
            return null;
        }

        IEnumerable<DTOOfProducts> IMapper<Products, DTOOfProducts>.MapToDTOList(IEnumerable<Products> entityList)
        {
            List<DTOOfProducts> listOfResultToReturn = new List<DTOOfProducts>();
            foreach (Products currentProduct in entityList)
            {
                listOfResultToReturn.Add(item: new DTOOfProducts
                {
                    Id = currentProduct.Id,
                    Name = currentProduct.Name,
                    Price = currentProduct.Price,
                    Status = currentProduct.Status
                });
            }
            return listOfResultToReturn;
        }

        Products IMapper<Products, DTOOfProducts>.MapToEntity(DTOOfProducts dtoObject)
        {
            if (dtoObject != null)
            {
                return new Products
                {
                    Id = dtoObject.Id,
                    Name = dtoObject.Name,
                    Price = dtoObject.Price,
                    Status = dtoObject.Status
                };
            }
            return null;
        }

        #endregion Explicitly Functions
    }
}
