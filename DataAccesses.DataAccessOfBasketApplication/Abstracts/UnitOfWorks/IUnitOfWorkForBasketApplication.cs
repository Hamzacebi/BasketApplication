#region Added Project References and General Usings
using System;
#endregion Added Project References and General Usings
namespace DataAccesses.DataAccessOfBasketApplication.Abstracts.UnitOfWorks
{
    #region Internal Project Usings
    using Abstracts.RepositoriesOfEntities;
    #endregion Internal Project Usings

    /// <summary>
    /// Repository Interfacelerine, Database Transaction fonksiyonlarina ve SaveChanges fonksiyon / fonksiyonlarina ulasmayi saglayan Interface
    /// </summary>
    public interface IUnitOfWorkForBasketApplication : IDisposable
    {

        #region Save Changes
        int SaveChanges();
        #endregion Save Changes


        #region Transaction Functions
        //ToDo : TransactionScope ile ilgili olan yazilabilir
        #endregion Transaction Functions


        #region Repository Of Properties 

        /// <summary>
        /// typeof(Members) tablosuna ait C - R - U - D ve Custom islemlerinin yapilabilmesini saglayan Property
        /// </summary>
        IRepositoryOfMembers RepositoryOfMembers { get; }

        /// <summary>
        /// typeof(Products) tablosuna ait C - R - U - D ve Custom islemlerinin yapilabilmesini saglayan Property
        /// </summary>
        IRepositoryOfProducts RepositoryOfProducts { get; }

        /// <summary>
        /// typeof(ProductStocks) tablosuna ait C - R - U - D ve Custom islemlerinin yapilabilmesini saglayan Property
        /// </summary>
        IRepositoryOfProductStocks RepositoryOfProductStocks { get; }

        /// <summary>
        /// typeof(MemberBaskets) tablosuna ait C - R - U - D ve Custom islemlerinin yapilabilmesini saglayan Property
        /// </summary>
        IRepositoryOfMemberBaskets RepositoryOfMemberBaskets { get; }

        #endregion Repository Of Properties
    }
}
