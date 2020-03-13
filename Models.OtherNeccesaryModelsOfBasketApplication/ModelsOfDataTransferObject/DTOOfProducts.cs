using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public sealed class DTOOfProducts : BaseOfDTO
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
    }
}
