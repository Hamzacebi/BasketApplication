#region Added Project References and Global Usings
using System;
using Commons.CommonOfBasketApplication.Constants;
using Models.OtherNeccesaryModelsOfBasketApplication;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMembers;
#endregion Added Project References and Global Usings

namespace Managers.ManagerOfBasketApplication.Concretes
{
    #region Internal Project Usings
    using Abstracts;
    using Abstracts.Base;
    #endregion Internal Project Usings

    public class ManagerOfMembers : ManagerOfBasic, IManagerOfMembers
    {
        #region Explicitly Functions

        ResultModelOfSelectMember IManagerOfMembers.FetchMemberById(Guid idOfMember)
        {
            ResultModel resultToReturn = default(ResultModel);
            WebAPIModelOfSelectMember resultToReturnOfMemberInformation = default(WebAPIModelOfSelectMember);

            if (idOfMember == Guid.Empty)
            {
                resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.MemberIdCannotBeEmpty);
            }
            else
            {
                try
                {
                    DTOOfMembers getMemberById = this.MapperOfMember
                                                             .MapToDTO(entityObject: this.UnitOfWorkForBasketApplication
                                                                                         .RepositoryOfMembers
                                                                                         .FetchAnyRecord(id: idOfMember));
                    if (getMemberById == null)
                    {
                        resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful: ConstantsOfResults.NoMembersFound);
                    }
                    else
                    {
                        resultToReturnOfMemberInformation = new WebAPIModelOfSelectMember
                        {
                            MemberId = getMemberById.Id,
                            MemberFirstName = getMemberById.Name,
                            MemberLastName = getMemberById.Surname
                        };
                        resultToReturn = ResultModel.SuccessfulResult(messageOfResultSuccessful: ConstantsOfResults.MemberSearchIsSuccessfull);
                    }
                }
                catch (Exception exception)
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(messageOfResultUnsuccessful:
                                                                 $"{ConstantsOfErrors.TransactionErrorMessageOfFetchMember} HATA : {exception.Message}");
                } 
            }
            return new ResultModelOfSelectMember
            {
                SuccessInformation = resultToReturn,
                MemberInformation = resultToReturnOfMemberInformation
            };
        }

        #endregion Explicitly Functions
    }
}
