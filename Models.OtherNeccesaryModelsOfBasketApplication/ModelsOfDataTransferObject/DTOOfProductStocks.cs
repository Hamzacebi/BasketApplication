using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public sealed class DTOOfProductStocks : BaseOfDTO
    {
        public new int Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
