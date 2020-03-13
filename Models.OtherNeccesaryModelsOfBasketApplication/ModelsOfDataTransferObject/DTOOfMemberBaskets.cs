using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public sealed class DTOOfMemberBaskets : BaseOfDTO
    {
        public bool Status { get; set; }
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }
        public short Quantity { get; set; }
        public byte ClosingReasonId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
