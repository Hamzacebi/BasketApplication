#region Added Project References and Global Usings
using System.Collections.Generic;
using Models.OtherNeccesaryModelsOfBasketApplication.ModelsOfDataTransferObject.Base;
#endregion Added Project References and Global Usings

namespace Helpers.HelperOfBasketApplication.Mappers.Base
{
    /// <summary>
    /// typeof(TEntity) database tablolari uzerinde yapilacak islemlere direkt ulasmak yerine
    /// her bir typeof(TEntity) tablosu icin olusturulmus olan DTO classi uzerinden ulasilmasini
    /// saglayan tum fonksiyonlari iceren interface
    /// </summary>
    /// <typeparam name="TEntity">typeof(TEntity) -> Database tablolari</typeparam>
    /// <typeparam name="TDTO">typeof(TEntity) icin olusturulmus olan DTO classlari</typeparam>
    public interface IMapper<TEntity, TDTO> where TEntity : class where TDTO : BaseOfDTO
    {
        //ToDo : TEntity icin IEntity, TDTO icin IDTO seklinde interface olusturulabilir. hepsinde ortak olanlar buraya tasinabilir

        /// <summary>
        /// Verilen DTO nesnesini Entity nesnesi olarak veren fonksiyon
        /// </summary>
        /// <param name="dtoObject">Entity nesnesine donusturulecek olan DTO nesnesi</param>
        /// <returns></returns>
        TEntity MapToEntity(TDTO dtoObject);

        /// <summary>
        /// Verilen Entity nesnesini DTO nesnesi olarak veren fonksiyon
        /// </summary>
        /// <param name="entityObject">DTO nesnesine donusturulecek olan Entity nesnesi</param>
        /// <returns></returns>
        TDTO MapToDTO(TEntity entityObject);

        /// <summary>
        /// Verilen Entity nesnesine ait listeyi DTO nesnesine ait liste olarak veren fonksiyon
        /// </summary>
        /// <param name="entityList">DTO nesnesine ait liste olarak elde edilmek istenilen Entity nesnesine ait liste</param>
        /// <returns></returns>
        IEnumerable<TDTO> MapToDTOList(IEnumerable<TEntity> entityList);
        //ToDo : IEnumerable<TDTO> olmazsa List<DTO> seklinde degistir
    }
}
