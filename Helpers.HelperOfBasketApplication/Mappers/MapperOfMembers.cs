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

    public sealed class MapperOfMembers : IMapper<Members, DTOOfMembers>
    {
        #region Explicitly Functions

        DTOOfMembers IMapper<Members, DTOOfMembers>.MapToDTO(Members entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfMembers
                {
                    Id = entityObject.Id,
                    Name = entityObject.Name,
                    Surname = entityObject.Surname
                };
            }
            return null;
        }

        IEnumerable<DTOOfMembers> IMapper<Members, DTOOfMembers>.MapToDTOList(IEnumerable<Members> entityList)
        {
            List<DTOOfMembers> listOfResultToReturn = new List<DTOOfMembers>();
            foreach (Members currentMember in entityList)
            {
                listOfResultToReturn.Add(item: new DTOOfMembers
                {
                    Id = currentMember.Id,
                    Name = currentMember.Name,
                    Surname = currentMember.Surname
                });
            }
            return listOfResultToReturn;
        }

        Members IMapper<Members, DTOOfMembers>.MapToEntity(DTOOfMembers dtoObject)
        {
            if (dtoObject != null)
            {
                return new Members
                {
                    Id = dtoObject.Id,
                    Name = dtoObject.Name,
                    Surname = dtoObject.Surname
                };
            }
            return null;
        }
        #endregion Explicitly Functions
    }
}
