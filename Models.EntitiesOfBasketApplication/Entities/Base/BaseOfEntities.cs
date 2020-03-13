using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EntitiesOfBasketApplication.Entities.Base
{
    public abstract class BaseOfEntities
    {
        #region Constructors
        protected BaseOfEntities() { }
        #endregion Constructors

        public Guid Id { get; set; }
    }
}
