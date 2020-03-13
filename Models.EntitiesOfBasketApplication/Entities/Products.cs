using System;
using System.Collections.Generic;

namespace Models.EntitiesOfBasketApplication.Entities
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public partial class Products : BaseOfEntities
    {
        public Products()
        {
            MemberBaskets = new HashSet<MemberBaskets>();
        }
         
        public string Name { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }

        public virtual ProductStocks ProductStocks { get; set; }
        public virtual ICollection<MemberBaskets> MemberBaskets { get; set; }
    }
}
