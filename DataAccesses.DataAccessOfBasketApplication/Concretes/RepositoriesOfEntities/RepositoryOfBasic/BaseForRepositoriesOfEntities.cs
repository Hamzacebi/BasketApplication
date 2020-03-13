#region Added Project References and General Usings
using System;
using Microsoft.EntityFrameworkCore;
using Commons.CommonOfBasketApplication.Constants;
using Models.EntitiesOfBasketApplication.Entities.Base;
using SinanHamzaceBi.GenericRepository.Concretes.RepositoryOfBasics;
#endregion Added Project References and General Usings

namespace DataAccesses.DataAccessOfBasketApplication.Concretes.RepositoriesOfEntities.RepositoryOfBasic
{
    public abstract class BaseForRepositoriesOfEntities<T> : RepositoryBase<T>, IDisposable where T : BaseOfEntities
    {
        #region Global Private Properties
        private bool disposedValue;
        protected new DbContext DbContext { get; private set; }
        #endregion Global Private Properties

        #region Constructors
        protected BaseForRepositoriesOfEntities(DbContext dbContext, Type repositoryOfEntityInWhatDbContext) : base(dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(innerException: null,
                                                                          message: ConstantsOfErrors.ArgumentNullExceptionMessageForDbContext);
            if (repositoryOfEntityInWhatDbContext == null)
            {
                throw new ArgumentNullException(innerException: null,
                                                message: ConstantsOfErrors.ArgumentNullExceptionMessageForRepositoryOfEntityInWhatDbContext);
            }
            else
            {
                if (repositoryOfEntityInWhatDbContext != dbContext.GetType())
                {
                    throw new ArgumentNullException(innerException: null,
                                                    message: ConstantsOfErrors.ArgumentNullExceptionMessageForXXXDbContext);
                }
            }
            this.disposedValue = false;
        }
        #endregion Constructors


        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.DbContext.Dispose();
                    this.DbContext = null;
                }
                disposedValue = true;
            }
        }


        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
