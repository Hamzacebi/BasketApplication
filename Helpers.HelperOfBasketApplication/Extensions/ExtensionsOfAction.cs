#region General Usings
using System;
#endregion General Usings

namespace Helpers.HelperOfBasketApplication.Extensions
{
    /// <summary>
    /// Geriye herhangi bir deger dondurmeyen islemler icin kullanilacak olan Try - Catch - Finally fonksiyonlarini iceren Extension
    /// </summary>
    public static class ExtensionsOfAction
    {
        /// <summary>
        /// Calismasi sonucunda geriye herhangi bir deger dondurmeyecek olan fonksiyonlarda Try - Catch - Finally islemleri yapmak icin kullanilir.
        /// </summary>
        /// <param name="action">Calistirilmasi istenilen action</param>
        /// <param name="catchAndDo">Function calisirken olusabilecek olan Exception icin yapilmak istenilen islemler</param>
        /// <param name="finallyDo">Try - Catch icin Finally aninda yapilmasi istenilen islemler</param>
        public static void TryCatch(this Action action, Func<Exception, bool> catchAndDo = null, Action finallyDo = null)
        {
            try
            {
                if (action != null)
                {
                    action.Invoke();
                }
            }
            catch (Exception exception)
            {
                bool reThrow = catchAndDo?.Invoke(arg: exception) ?? true;
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
        }
    }
}
