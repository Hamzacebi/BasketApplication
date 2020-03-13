using System;

namespace Models.EntitiesOfBasketApplication.Entities
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public partial class MemberBaskets : BaseOfEntities
    {
        public bool Status { get; set; }
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }
        public short Quantity { get; set; }
        public byte ClosingReasonId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public virtual Members Member { get; set; }
        public virtual Products Product { get; set; }
        public virtual BasketClosingReasons ClosingReason { get; set; }
    }
}
