#region Added Project References and General Usings
using System;
using Microsoft.EntityFrameworkCore;
using Helpers.HelperOfBasketApplication.Tools;
using Commons.CommonOfBasketApplication.Constants;
using Models.EntitiesOfBasketApplication.DatabaseContext;
#endregion Added Project References and General Usings

namespace DataAccesses.DataAccessOfBasketApplication.Concretes.UnitOfWorks
{
    #region Internal Project Usings
    using Abstracts.UnitOfWorks;
    using Abstracts.RepositoriesOfEntities;
    using Concretes.RepositoriesOfEntities;
    #endregion Internal Project Usings

    public sealed class UnitOfWorkForBasketApplication : IUnitOfWorkForBasketApplication
    {
        #region Global Private Properties

        private bool disposedValue;
        private DbContext DbContext;

        #endregion Global Private Properties


        #region Constructors
        public UnitOfWorkForBasketApplication(DbContext dbContextObject)
        {
            this.DbContext = dbContextObject ?? throw new ArgumentNullException(innerException: null,
                                                                                message: ConstantsOfErrors.ArgumentNullExceptionMessageForDbContext);
            this.disposedValue = default(bool);
        }
        #endregion Constructors

        #region Explicitly Functions


        #region Save Changes

        int IUnitOfWorkForBasketApplication.SaveChanges()
        {
            if (this.DbContext == null)
            {
                throw new ArgumentNullException(innerException: null,
                                                message: ConstantsOfErrors.ArgumentNullExceptionMessageForSaveChanges);
            }
            else
            {
                return this.DbContext.SaveChanges();
            }
        }

        #endregion Save Changes


        #region Repository Of Properties

        IRepositoryOfMembers IUnitOfWorkForBasketApplication.RepositoryOfMembers =>
                                       UtilityTools.CreateGenericSingletonInstance<IRepositoryOfMembers>(resultToReturnClass: typeof(RepositoryOfMembers),
                                                                                                        constructorParameters: new object[] {
                                                                                                                                              this.DbContext,
                                                                                                                                              typeof(ECommerceDbContext)
                                                                                                                                             }
                                                                                                       );

        IRepositoryOfProducts IUnitOfWorkForBasketApplication.RepositoryOfProducts =>
                                        UtilityTools.CreateGenericSingletonInstance<IRepositoryOfProducts>(resultToReturnClass: typeof(RepositoryOfProducts),
                                                                                                          constructorParameters: new object[] {
                                                                                                                                                this.DbContext,
                                                                                                                                                typeof(ECommerceDbContext)
                                                                                                                                               }
                                                                                                         );

        IRepositoryOfProductStocks IUnitOfWorkForBasketApplication.RepositoryOfProductStocks =>
                                             UtilityTools.CreateGenericSingletonInstance<IRepositoryOfProductStocks>(resultToReturnClass: typeof(RepositoryOfProductStocks),
                                                                                                                    constructorParameters: new object[] {
                                                                                                                                                this.DbContext,
                                                                                                                                                typeof(ECommerceDbContext)
                                                                                                                                                        }
                                                                                                                   );

        IRepositoryOfMemberBaskets IUnitOfWorkForBasketApplication.RepositoryOfMemberBaskets =>
                                             UtilityTools.CreateGenericSingletonInstance<IRepositoryOfMemberBaskets>(resultToReturnClass: typeof(RepositoryOfMemberBaskets),
                                                                                                                    constructorParameters: new object[] {
                                                                                                                                                this.DbContext,
                                                                                                                                                typeof(ECommerceDbContext)
                                                                                                                                                        }
                                                                                                                   );
        #endregion Repository Of Properties

        #endregion Explicitly Functions


        #region IDisposable Support

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UtilityTools.ClearAllInstances();
                    this.DbContext = null;
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}
