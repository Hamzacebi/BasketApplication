#region General Usings
using System;
#endregion General Usings

namespace Helpers.HelperOfBasketApplication.Extensions
{
    /// <summary>
    /// Geriye typeof(T) tipinde bir deger dondurmesi istenilen islemler icin kullanilacak olan Try - Catch - Finally fonksiyonlarini iceren Extension
    /// </summary>
    public static class ExtensionsOfFunction
    {
        /// <summary>
        /// Calismasi sonucunda geriye T tipinde deger dondurecek olan fonksiyonlarda Try-Catch-Finally islemi yapmak icin kullanilir
        /// </summary>
        /// <typeparam name="T">Geriye dondurulecek olan veri tipi</typeparam>
        /// <param name="function">Calistirilmasi istenilen function</param>
        /// <param name="catchAndDo">Function calisirken olusabilecek olan Exception icin yapilmak istenilen islemler</param>
        /// <param name="finallyDo">Try - Catch icin Finally aninda yapilmasi istenilen islemler</param>
        /// <returns></returns>
        public static T TryCatch<T>(this Func<T> function, Func<Exception, bool> catchAndDo = null, Action finallyDo = null)
        {
            try
            {
                if (function != null)
                {
                    return function();
                }
            }
            catch (Exception exception)
            {
                bool reThrow = catchAndDo?.Invoke(exception) ?? true;
                if (reThrow)
                {
                    throw exception;
                }
            }
            finally
            {
                if (finallyDo != null)
                {
                    finallyDo.Invoke();
                }
            }
            return default(T);
        }
    }
}
