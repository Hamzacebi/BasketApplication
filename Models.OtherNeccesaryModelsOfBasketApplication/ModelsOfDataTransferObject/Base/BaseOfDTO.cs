using System;

namespace Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject.Base
{
    public abstract class BaseOfDTO
    {
        protected BaseOfDTO()
        {
        }

        public Guid Id { get; set; }
    }
}
