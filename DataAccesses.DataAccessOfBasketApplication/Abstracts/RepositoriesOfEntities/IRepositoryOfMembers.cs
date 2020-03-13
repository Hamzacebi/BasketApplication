#region Added Project References and General Usings
using System;
using Models.EntitiesOfBasketApplication.Entities;
using SinanHamzaceBi.GenericRepository.Abstracts.RepositoryOfBasics;
#endregion Added Project References and General Usings

namespace DataAccesses.DataAccessOfBasketApplication.Abstracts.RepositoriesOfEntities
{
    /// <summary>
    /// typeof(Members) tablosu icin C - R - U - D islemleri ve Custom islemler yapabilmeye imkân saglayan Interface.
    /// </summary>
    public interface IRepositoryOfMembers : IRepositoryOfSelectable<Members>, IDisposable
    {
    }

}
