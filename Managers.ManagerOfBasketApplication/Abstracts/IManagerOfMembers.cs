#region Added Project References and General Usings
using System;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfWebAPI.WebAPIModelsOfMembers;
#endregion Added Project References and General Usings

namespace Managers.ManagerOfBasketApplication.Abstracts
{
    public interface IManagerOfMembers
    {
        /// <summary>
        /// Verilen Id degerine gore bir kullaniciya ait bilgileri listelemeye yarayan fonksiyon
        /// </summary>
        /// <param name="idOfMember">Elde edilmek istenilen Member'e ait ID bilgisi</param>
        /// <returns></returns>
        ResultModelOfSelectMember FetchMemberById(Guid idOfMember);
    }
}
