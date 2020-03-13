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

    public sealed class MapperOfProductStocks : IMapper<ProductStocks, DTOOfProductStocks>
    {
        #region Explicitly Functions

        DTOOfProductStocks IMapper<ProductStocks, DTOOfProductStocks>.MapToDTO(ProductStocks entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfProductStocks
                {
                    Id = entityObject.Id,
                    Quantity = entityObject.Quantity,
                    ProductId = entityObject.ProductId
                };
            }
            return null;
        }

        IEnumerable<DTOOfProductStocks> IMapper<ProductStocks, DTOOfProductStocks>.MapToDTOList(IEnumerable<ProductStocks> entityList)
        {
            List<DTOOfProductStocks> listOfResultToReturn = new List<DTOOfProductStocks>();
            foreach (ProductStocks currentProductStock in entityList)
            {
                listOfResultToReturn.Add(item: new DTOOfProductStocks
                {
                    Id = currentProductStock.Id,
                    Quantity = currentProductStock.Quantity,
                    ProductId = currentProductStock.ProductId
                });
            }
            return listOfResultToReturn;
        }

        ProductStocks IMapper<ProductStocks, DTOOfProductStocks>.MapToEntity(DTOOfProductStocks dtoObject)
        {
            if (dtoObject != null)
            {
                return new ProductStocks
                {
                    Id = dtoObject.Id,
                    Quantity = dtoObject.Quantity,
                    ProductId = dtoObject.ProductId
                };
            }
            return null;
        }

        #endregion Explicitly Functions
    }
}
