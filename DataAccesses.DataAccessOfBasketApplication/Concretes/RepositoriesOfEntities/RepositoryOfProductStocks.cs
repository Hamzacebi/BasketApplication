﻿#region Added Project References ang General Usings
using System;
using Microsoft.EntityFrameworkCore;
using Models.EntitiesOfBasketApplication.Entities;
#endregion Added Project References ang General Usings

namespace DataAccesses.DataAccessOfBasketApplication.Concretes.RepositoriesOfEntities
{
    #region Internal Project Usings
    using RepositoryOfBasic;
    using Abstracts.RepositoriesOfEntities;
    #endregion Internal Project Usings

    public sealed class RepositoryOfProductStocks : BaseForRepositoriesOfEntities<ProductStocks>, IRepositoryOfProductStocks
    {
        public RepositoryOfProductStocks(DbContext dbContext, Type repositoryOfEntityInWhatDbContext) : base(dbContext, repositoryOfEntityInWhatDbContext)
        {
        }
    }
}
