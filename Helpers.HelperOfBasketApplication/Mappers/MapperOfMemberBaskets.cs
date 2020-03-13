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

    public sealed class MapperOfMemberBaskets : IMapper<MemberBaskets, DTOOfMemberBaskets>
    {
        #region Explicitly Functions

        DTOOfMemberBaskets IMapper<MemberBaskets, DTOOfMemberBaskets>.MapToDTO(MemberBaskets entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfMemberBaskets
                {
                    Id = entityObject.Id,
                    Status = entityObject.Status,
                    Quantity = entityObject.Quantity,
                    MemberId = entityObject.MemberId,
                    ProductId = entityObject.ProductId,
                    ReleaseDate = entityObject.ReleaseDate,
                    CreationDate = entityObject.CreationDate,
                    ClosingReasonId = entityObject.ClosingReasonId
                };
            }
            return null;
        }

        IEnumerable<DTOOfMemberBaskets> IMapper<MemberBaskets, DTOOfMemberBaskets>.MapToDTOList(IEnumerable<MemberBaskets> entityList)
        {
            List<DTOOfMemberBaskets> listOfResultToReturn = new List<DTOOfMemberBaskets>();
            foreach (MemberBaskets currentMemberBasket in entityList)
            {
                listOfResultToReturn.Add(item: new DTOOfMemberBaskets
                {
                    Id = currentMemberBasket.Id,
                    Status = currentMemberBasket.Status,
                    Quantity = currentMemberBasket.Quantity,
                    MemberId = currentMemberBasket.MemberId,
                    ProductId = currentMemberBasket.ProductId,
                    ReleaseDate = currentMemberBasket.ReleaseDate,
                    CreationDate = currentMemberBasket.CreationDate,
                    ClosingReasonId = currentMemberBasket.ClosingReasonId
                });
            }
            return listOfResultToReturn;
        }

        MemberBaskets IMapper<MemberBaskets, DTOOfMemberBaskets>.MapToEntity(DTOOfMemberBaskets dtoObject)
        {
            if (dtoObject != null)
            {
                return new MemberBaskets
                {
                    Id = dtoObject.Id,
                    Status = dtoObject.Status,
                    MemberId = dtoObject.MemberId,
                    Quantity = dtoObject.Quantity,
                    ProductId = dtoObject.ProductId,
                    ReleaseDate = dtoObject.ReleaseDate,
                    CreationDate = dtoObject.CreationDate,
                    ClosingReasonId = dtoObject.ClosingReasonId
                };
            }
            return null;
        }

        #endregion Explicitly Functions
    }
}
