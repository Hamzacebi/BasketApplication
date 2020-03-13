using System;
using System.Collections.Generic;

namespace Models.EntitiesOfBasketApplication.Entities
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public partial class Members : BaseOfEntities
    {
        public Members()
        {
            MemberBaskets = new HashSet<MemberBaskets>();
        }
         
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<MemberBaskets> MemberBaskets { get; set; }
    }
}
