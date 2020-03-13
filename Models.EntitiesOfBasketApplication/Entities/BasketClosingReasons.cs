using System.Collections.Generic;

namespace Models.EntitiesOfBasketApplication.Entities
{
    public partial class BasketClosingReasons
    {
        public BasketClosingReasons()
        {
            MemberBaskets = new HashSet<MemberBaskets>();
        }

        public byte Id { get; set; }
        public string Reason { get; set; }

        public virtual ICollection<MemberBaskets> MemberBaskets { get; set; }
    }
}
