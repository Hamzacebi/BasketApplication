using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public sealed class DTOOfMembers : BaseOfDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
