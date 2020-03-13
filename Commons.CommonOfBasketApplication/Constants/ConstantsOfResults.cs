namespace Commons.CommonOfBasketApplication.Constants
{
    /// <summary>
    /// typeof(Members), typeof(Products), typeof(ProductStocks), typeof(MemberBaskets) tablolari icin
    /// Basarili ve Basarisiz islemler icin mesajlarin bulundugu class
    /// </summary>
    public sealed class ConstantsOfResults
    {
        #region Constructos
        private ConstantsOfResults() { }
        #endregion Constructos


        #region Base Messages

        private const string PleaseTryAgain = "Lütfen tekrar deneyin!";
        private const string ChangeIdMessage = "Lutfen ID degerini degistirerek tekrar deneyin!";
        private const string IdCannotBeEmpty = "ID bilgisi bos gecilemez! Lutfen bir ID bilgisi vererek tekrar deneyin!";

        #endregion Base Messages


        #region Result Messages Of typeof(Members)

        public const string NoMembersFound = "Verilen ID bilgisine sahip bir KULLANICI bulunamadi. " + ChangeIdMessage;

        public const string MemberIdCannotBeEmpty = "Kullaniciya ait " + IdCannotBeEmpty;

        public const string MemberSearchIsSuccessfull = "Verilen ID bilgisine ait KULLANICI bilgileri getirilmistir!";

        #endregion Result Messages Of typeof(Members)


        #region Result Messages Of typeof(Products)

        public const string NoProductsFound = "Verilen ID bilgisine sahip bir URUN bulunamadi. " + ChangeIdMessage;

        public const string ProductIdCannotBeEmpty = "Urune ait " + IdCannotBeEmpty;

        public const string ProductUpdateSuccessful = "Verilen ID bilgisine sahip URUN'e ait Status degeri basarili bir sekilde GUNCELLENMISTIR!";

        public const string ProductSearchIsSuccessful = "Verilen ID bilgisine ait URUN bilgileri getirilmistir!";

        public const string ProductUpdateUnsuccessful = "Verilen ID bilgisine sahip URUN'e ait Status degeri guncellenemedi! " + PleaseTryAgain;

        #endregion Result Messages Of typeof(Products)


        #region Result Messages Of typeof(ProductStocks)

        public const string ProductStockInsertSuccessful = "Ilgili URUN'e ait STOK bilgisi basarili bir sekilde eklenmistir!";

        public const string ProductStockUpdateSuccessful = "Ilgili URUN'e ait STOK bilgisi basarili bir sekilde guncellenmistir!";

        public const string ProductStockSearchIsSuccessful = "Ilgili URUN'e ait STOK bilgileri getirilmistir!";

        public const string ProductStockInsertUnsuccessful = "Ilgili URUN'e ait STOK bilgisi eklenemedi. " + PleaseTryAgain;

        public const string ProductStockUpdateUnsuccessful = "Ilgili URUN'e ait STOK bilgisi guncellenemedi. " + PleaseTryAgain;

        public const string ProductStockInformationNotFound = "Ilgili URUN'e ait STOK bilgisi bulunamadi!. Lutfen URUN icin STOK bilgisi girin!";

        public const string ProductStockInformationCannotBeEmpty = "STOK bilgisi eklenmek istenilen URUN'e ait ID ve STOK sayisi bos gecilemez! Lutfen ilgili URUN'e ait ID ve STOK sayisini vererek tekrar deneyin!";

        public const string QuantityValueCannotBeNegativeOrEqualToZero = "URUN'e ait STOK bilgisi 0 (sifir) veya daha kucuk olamaz. Lutfen STOK degeri icin 0'dan (sifir) buyuk bir deger vererek tekrar deneyin!";

        #endregion Result Messages Of typeof(ProductStocks)


        #region Result Messages Of typeof(MemberBaskets)


        public const string NoBasketFound = "Verilen ID degerine gore bir SEPET bulunamadi! " + ChangeIdMessage;

        public const string BasketIdCannotBeEmpty = "SEPET " + IdCannotBeEmpty;

        public const string YouHaveNoItemsInYourCart = "Sepetinizde hicbir URUN bulunmamaktadir. Lutfen SEPET'inize bir URUN ekleyin!";

        public const string WarningOfInsufficientStock = "Satin almak istediginiz URUN'e ait adet sayisi kadar mevcut STOK bulunmamaktadir. Lutfen almak istediginiz URUN'e ait adet sayisini azaltin!";

        public const string AddProductToCartSuccessful = "Ilgili URUN, belirtilen sayida ve belirtilen KULLANICI'ya ait SEPET'e basarili bir sekilde eklendi!";

        public const string AddProductToCartUnsuccessful = "Ilgili URUN, belirtilen KULLANICI'ya ait SEPET'e eklenemedi. " + PleaseTryAgain;

        public const string BuyProductsInBasketIsSuccessful = "Ilgili KULLANICI'ya ait SEPET'te ki URUN'lerin siparisleri basarili bir sekilde verilmistir!";

        public const string BuyProductsInBasketIsUnsuccessful = "Ilgili KULLANICI'ya ait SEPET'te ki URUN'lerin siparisleri verilemedi. " + PleaseTryAgain;

        public const string GeneralWarningForAddProductToCart = "Belirtilen URUN, belirtilen KULLANICI icin SEPET'e eklenme islemi esnasinda bir sorun olustu." + PleaseTryAgain;

        public const string UpdateProductInTheBasketIsSuccessful = "Ilgili KULLANICI'ya ait SEPET basarili bir sekilde GUNCELLENMISTIR!";

        public const string DeleteProductInTheBasketIsSuccessful = "Ilgili KULLANICI'ya ait SEPET'te ki istenilen URUN basarili bir sekilde silindi!";

        public const string UpdateProductInTheBasketIsUnsuccessful = "Ilgili KULLANICI'ya ait SEPET GUNCELLENEMEDI" + PleaseTryAgain;

        public const string DeleteProductInTheBasketIsUnsuccessful = "Ilgili KULLANICI'ya ait SEPET'te ki istenilen URUN silinemedi! " + PleaseTryAgain;

        public const string FetchAllProductsInMemberBasketIsSuccessful = "Sepetinizde ki tum URUN'ler listelenmistir!";

        public const string TheProductToBeDeletedWasNotFoundInTheBasket = "Silinmek istenilen URUN, SEPET'te bulunamadi. " + PleaseTryAgain;

        public const string ProductInformationToBeAddedToTheCartCannotBeEmpty = "SEPET'e eklenecek KULLANICI - URUN ve URUN Adedi bilgileri bos gecilemez! Lutfen KULLANICI - URUN ve URUN ADEDI bilgilerini girerek tekrar deneyin!";

        public const string TheInformationOfTheProductToBeUpdatedInTheBasketCannotBeEmpty = "Sepette ki GUNCELLENMEK istenilen URUN'e ait bilgiler bos olamaz! Lutfen ilgili URUN icin gerekli bilgileri girerek tekrar deneyin!";

        #endregion Result Messages Of typeof(MemberBaskets)
    }
}
