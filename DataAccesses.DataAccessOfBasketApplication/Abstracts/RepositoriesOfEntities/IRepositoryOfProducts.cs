#region Added Project References and General Usings
using System;
using Models.EntitiesOfBasketApplication.Entities;
using SinanHamzaceBi.GenericRepository.Abstracts.RepositoryOfBasics;
#endregion Added Project References and General Usings

namespace DataAccesses.DataAccessOfBasketApplication.Abstracts.RepositoriesOfEntities
{
    /// <summary>
    /// typeof(Products) tablosu icin C - R - U - D islemleri ve Custom islemler yapabilmeye imkân saglayan Interface.
    /// <para>Products tablosunda kayitli olan Product'lar icin eger Stock bilgisi yok ise Product satisa acik degildir 
    /// uyarisi vermek amaciyla Status koyulmus ve Products tablosunun islem yetenekleri arasina Updatable katilmistir.</para>
    /// </summary>
    public interface IRepositoryOfProducts : IRepositoryOfSelectable<Products>, IRepositoryOfUpdatable<Products>, IDisposable
    {
    }

}
