#region Added Project References and Global Usings
using Microsoft.EntityFrameworkCore;
using Helpers.HelperOfBasketApplication.Tools;
using Helpers.HelperOfBasketApplication.Mappers;
using Models.EntitiesOfBasketApplication.Entities;
using Helpers.HelperOfBasketApplication.Mappers.Base;
using Models.EntitiesOfBasketApplication.DatabaseContext;
using DataAccesses.DataAccessOfBasketApplication.Abstracts.UnitOfWorks;
using DataAccesses.DataAccessOfBasketApplication.Concretes.UnitOfWorks;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject;
#endregion Added Project References and Global Usings

namespace Managers.ManagerOfBasketApplication.Abstracts.Base
{
    public abstract class ManagerOfBasic
    {
        //ToDo : tum try - catch fonksiyonlarinda finally icin this.UnitOfWorkForBasketApplicaton.Dispose(); fonksiyonunu cagir.
        //ToDo : Eger ID hatasi alirsak AddSingleton icin bir DbContext, ECommerceDbContext diyerek uretim yaptir.
        #region Global Private Properties
        //private DbContext DbContext;
        #endregion Global Private Properties

        #region Constructors
        protected ManagerOfBasic()
        {
        }

        //protected ManagerOfBasic(DbContext dbContextObject)
        //{
        //    this.DbContext = dbContextObject;
        //}
        #endregion Constructors


        #region UnitOfWork Property
        protected IUnitOfWorkForBasketApplication UnitOfWorkForBasketApplication
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IUnitOfWorkForBasketApplication>(resultToReturnClass: typeof(UnitOfWorkForBasketApplication),
                                                                                                    constructorParameters: new object[] { new ECommerceDbContext() });
            }
        }
        #endregion UnitOfWork Property


        #region Mapper Properties

        protected IMapper<Members, DTOOfMembers> MapperOfMember
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IMapper<Members, DTOOfMembers>>(resultToReturnClass: typeof(MapperOfMembers));
            }
        }

        protected IMapper<Products, DTOOfProducts> MapperOfProduct
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IMapper<Products, DTOOfProducts>>(resultToReturnClass: typeof(MapperOfProducts));
            }
        }

        protected IMapper<ProductStocks, DTOOfProductStocks> MapperOfProductStock
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IMapper<ProductStocks, DTOOfProductStocks>>(resultToReturnClass: typeof(MapperOfProductStocks));
            }
        }

        protected IMapper<MemberBaskets, DTOOfMemberBaskets> MapperOfMemberBaskets
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IMapper<MemberBaskets, DTOOfMemberBaskets>>(resultToReturnClass: typeof(MapperOfMemberBaskets));
            }
        }

        #endregion Mapper Properties
    }
}
