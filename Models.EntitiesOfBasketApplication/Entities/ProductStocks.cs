using System;

namespace Models.EntitiesOfBasketApplication.Entities
{
    #region Internal Project Usings
    using Base;
    #endregion Internal Project Usings

    public partial class ProductStocks : BaseOfEntities
    {
        public new int Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
