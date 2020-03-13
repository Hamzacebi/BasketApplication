namespace Commons.CommonOfBasketApplication.Constants
{
    /// <summary>
    /// typeof(Members), typeof(Products), typeof(ProductStocks), typeof(MemberBaskets) tablolari icin
    /// System ve Custom Exception hata mesajlarinin bulundugu class
    /// </summary>
    public sealed class ConstantsOfErrors
    {
        #region Constructos
        private ConstantsOfErrors() { }
        #endregion Constructos


        #region Base Messages
        private const string SystemException = "sistemsel bir hata olustu! Lutfen tekrar deneyin!";
        #endregion Base Messages


        #region Database Error Messages

        public const string ArgumentNullExceptionMessageForDbContext = "DbContext objesi bos gecilemez!";
        public const string ArgumentNullExceptionMessageForSaveChanges = "Yapilan C - R - U - D islemlerini Database uzerinde calistirmak icin DbContext nesnesi gereklidir. Lutfen bir DbContext nesnesi vererek tekrar deneyin!";
        public const string ArgumentNullExceptionMessageForDbContextTransaction = "Commit veya Rollback islemi yapilabilmesi icin Begin Transaction baslatilmasi gerekmektedir. Lutfen bir Begin Transaction islemi baslatin!";

        public const string ArgumentNullExceptionMessageForXXXDbContext = "Lutfen ulasmak istediginiz tabloya ait repository nesnesi icin tablonun bulundugu DatabaseContext nesnesini verin! Orn: ECommerceDbContext";

        #endregion Database Error Messages


        #region General Exception Messages

        public const string ExceptionMessageForCreateInstance = "typeof(T) tipindeki CLASS'a ait instance uretilmesi esnasinda hata olustu. Lutfen tekrar deneyin!";

        public const string InvalidCastExceptionForFetchInheritedClass = "typeof(T) tipindeki Interface'i inherit etmis olan CLASS'a ait instance getirilirken bir hata olustu. Lutfen tekrar deneyin!";

        public const string NullReferenceExceptionForResultToReturnClassType = "Singleton uretim yapilabilmesi icin typeof(T) tipindeki Interface'den inherit edilmis olan Class'in belirtilmesi gerekmektedir. Lutfen typeof(T)'den inherit edilmis olan bir Class tanimlayin ve tekrar deneyin!";

        public const string ArgumentNullExceptionMessageForConstructorParameters = "'resultToReturnClass' adli parametre icin tanimlanmis olan typeof(T) tipindeki CLASS icin DEFAULT Constructor olmalidir veya Constructor icin istenilen initialize parametrelerini gondermek zorundasiniz! Lutfen ilgili CLASS icin DEFAULT Constructor tanimlayin veya Constructor'un ihtiyac duydugu parametreleri gondererek tekrar deneyin!";

        public const string ArgumentNullExceptionMessageForRepositoryOfEntityInWhatDbContext = "Calistirilmak istenilen RepositoryOfXXX adli Repository class'inin hangi DbContext nesnesinde olduguna dair bir DbContext tanimlanmalidir. Lutfen RepositoryOfXXX icin bir DbContext nesnesi tanimlayarak tekrar deneyin!";
        #endregion General Exception Messages


        #region Exception Messages Of typeof(Members)

        public const string TransactionErrorMessageOfFetchMember = "KULLANICI'ya ait bilgiler listelenirken " + SystemException;

        #endregion Exception Messages Of typeof(Members)


        #region Exception Messages Of typeof(Products)
        public const string TransactionErrorMessageOfFetchProduct = "URUN'e ait bilgiler listelenirken " + SystemException;
        public const string TransactionErrorMessageOfUpdateProductStatus = "URUN'e ait STATUS degeri GUNCELLENIRKEN " + SystemException;
        #endregion Exception Messages Of typeof(Products)


        #region Exception Messages Of typeof(ProductStocks)

        public const string TransactionErrorMessageOfFetchProductStock = "URUN'e ait STOK bilgiler ilistelenirken " + SystemException;

        public const string TransactionErrorMessageOfInsertProductStock = "Ilgili URUN'e Stock bilgisi eklenirken " + SystemException;

        public const string TransactionErrorMessageOfProductIdAlreadyExists = "Ilgili URUN icin daha onceden STOK bilgisi girilmis. Lutfen bu URUN icin STOK bilgisini guncelleyerek artirmayi deneyin veya baska bir URUN icin STOK bilgisi girmeyi deneyin!";

        public const string TransactionErrorMessageOfUpdateExistsProductStock = "Ilgili URUN'e ait STOK bilgisi guncellenirken " + SystemException;
        #endregion Exception Messages Of typeof(ProductStocks)


        #region Exception Messages Of typeof(MemberBaskets)


        public const string TransactionErrorMessageOfAddProductToCart = "Ilgili URUN, belirtilen KULLANICI'ya ait SEPET'e eklenirken " + SystemException;

        public const string TransactionErrorMessageOfBuyProductsInBasket = "Ilgili KULLANICI'ya ait SEPET'te ki URUN'lerin satin alinmasi islemleri esnasinda " + SystemException;

        public const string TransactionErrorMessageOfDeleteProductToCart = "Ilgili KULLANICI'ya ait SEPET'te ki URUN'un SILINMESI islemi esnasinda " + SystemException;

        public const string TransactionErrorMessageOfUpdateProductInTheBasket = "Ilgili KULLANICI'ya ait SEPET GUNCELLENIRKEN " + SystemException;

        public const string TransactionErrorMessageOfFetchProductsOwnedByTheMember = "Ilgili KULLANICI'ya ait SEPET listelenirken " + SystemException;

        #endregion Exception Messages Of typeof(MemberBaskets)

    }
}
