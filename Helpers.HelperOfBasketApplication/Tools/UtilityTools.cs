#region Global Usings
using System;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Collections.Concurrent;
using Commons.CommonOfBasketApplication.Constants;
#endregion Global Usings

namespace Helpers.HelperOfBasketApplication.Tools
{
    /// <summary>
    /// Proje icerisinde herhangi bir yerde kullanilacak yardimci fonksiyonlari iceren class
    /// </summary>
    public static class UtilityTools
    {
        #region Global Private Properties
        private static ConcurrentDictionary<string, object> createdObjectsOfInstances;
        #endregion Global Private Properties

        #region Constructors

        static UtilityTools()
        {
            createdObjectsOfInstances = new ConcurrentDictionary<string, object>();
        }

        #endregion Constructors

        #region Public Static Functions

        /// <summary>
        /// Kendisine verilen Interface ve Class degerlerine gore Singleton olarak bir Constructor'a herhangi bir deger 
        /// gondermeden instance uretmeye yarayan fonksiyon
        /// </summary>
        /// <typeparam name="T">Instance degeri elde edilmek istenilen Interface</typeparam>
        /// <param name="resultToReturnClass">Interface'den Inherit edilmis olan class</param>
        /// <returns></returns>
        public static T CreateGenericSingletonInstance<T>(Type resultToReturnClass)
        {
            if (resultToReturnClass == null)
            {
                throw new NullReferenceException(message: ConstantsOfErrors.NullReferenceExceptionForResultToReturnClassType);
            }

            Type interfaceOfInherit = typeof(T);

            bool isClassInheritedToInterface = ((TypeInfo)resultToReturnClass).ImplementedInterfaces
                                                                              .Contains(value: interfaceOfInherit);
            if (isClassInheritedToInterface)
            {
                if (createdObjectsOfInstances.ContainsKey(key: interfaceOfInherit.FullName))
                {
                    object outParameterForImplementedClass = null;
                    var isThereAnyFecth = createdObjectsOfInstances.TryGetValue(key: interfaceOfInherit.FullName, value: out outParameterForImplementedClass);
                    if (isThereAnyFecth)
                    {
                        return (T)outParameterForImplementedClass;
                    }
                    throw new InvalidCastException(message: ConstantsOfErrors.InvalidCastExceptionForFetchInheritedClass);
                }
                Lazy<T> createSingletonInstance = new Lazy<T>(valueFactory: () =>
                {
                    return (T)Activator.CreateInstance(type: resultToReturnClass);
                });
                T resultToReturnOfCreatedSingletonInstance = createSingletonInstance.Value;
                if (createSingletonInstance.IsValueCreated)
                {
                    createdObjectsOfInstances.TryAdd(key: interfaceOfInherit.FullName,
                                                     value: resultToReturnOfCreatedSingletonInstance);
                    return resultToReturnOfCreatedSingletonInstance;
                }
                throw new Exception(message: ConstantsOfErrors.ExceptionMessageForCreateInstance);
            }
            throw new NotImplementedException(message: $"{resultToReturnClass.Name} adlı CLASS {interfaceOfInherit.Name} adlı INTERFACE'den miras almadığı için {interfaceOfInherit.Name} adlı INTERFACE için bir nesne üretilemiyor. Lütfen {interfaceOfInherit.Name}'den miras alan bir CLASS tanımlayınız ve 'resultToReturnClass' adlı parametreye bu CLASS değerini verin!");
        }


        /// <summary>
        /// Kendisine verilen Interface ve Class degerlerine gore Singleton olarak bir Constructor'a, kendisine verilen degerleri
        /// gondererek instance uretmeye yarayan fonksiyon
        /// </summary>
        /// <typeparam name="T">Instance degeri elde edilmek istenilen Interface</typeparam>
        /// <param name="resultToReturnClass">Interface'den Inherit edilmis olan class</param>
        /// <param name="constructorParameters">Inherit edilmis olan class'a ait Constructor'a gonderilmek istenilen parametre / parametreler</param>
        /// <returns></returns>
        public static T CreateGenericSingletonInstance<T>(Type resultToReturnClass, object[] constructorParameters)
        {
            if (resultToReturnClass == null)
            {
                throw new NullReferenceException(message: ConstantsOfErrors.NullReferenceExceptionForResultToReturnClassType);
            }

            if (constructorParameters == null)
            {
                throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForConstructorParameters,
                                                innerException: null);
            }

            Type inheritedInterface = typeof(T);

            bool isInheritedInterface = ((TypeInfo)resultToReturnClass).ImplementedInterfaces
                                                                      .Contains(value: inheritedInterface);
            if (isInheritedInterface)
            {
                if (createdObjectsOfInstances.ContainsKey(key: inheritedInterface.FullName))
                {
                    object outParameterForImplementedClass = null;
                    var isThereAnyFecth = createdObjectsOfInstances.TryGetValue(key: inheritedInterface.FullName, value: out outParameterForImplementedClass);
                    if (isThereAnyFecth)
                    {
                        return (T)outParameterForImplementedClass;
                    }
                    throw new InvalidCastException(message: ConstantsOfErrors.InvalidCastExceptionForFetchInheritedClass);
                }
                if (constructorParameters.Any())
                {
                    Lazy<T> createSingletonInstance = new Lazy<T>(valueFactory: () =>
                    {
                        return (T)Activator.CreateInstance(type: resultToReturnClass,
                                                           args: constructorParameters);
                    });
                    T resultToReturnOfCreatedSingletonInstance = createSingletonInstance.Value;
                    if (createSingletonInstance.IsValueCreated)
                    {
                        createdObjectsOfInstances.TryAdd(key: inheritedInterface.FullName,
                                                         value: resultToReturnOfCreatedSingletonInstance);
                        return resultToReturnOfCreatedSingletonInstance;
                    }
                    throw new Exception(message: ConstantsOfErrors.ExceptionMessageForCreateInstance);
                }
                throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForConstructorParameters,
                                                innerException: null);
            }
            throw new NotImplementedException(message: $"{resultToReturnClass.Name} adlı CLASS {inheritedInterface.Name} adlı INTERFACE'den miras almadığı için {inheritedInterface.Name} adlı INTERFACE için bir nesne üretilemiyor. Lütfen {inheritedInterface.Name}'den miras alan bir CLASS tanımlayınız ve 'resultToReturnClass' adlı parametreye bu CLASS değerini verin!");
        }

        /// <summary>
        /// Her bir Request icin olusturulmus olan tum Instance'leri temizlemeye yarayan fonksiyon
        /// </summary>
        public static void ClearAllInstances()
        {
            var cleanedInstances = Interlocked.Exchange(ref createdObjectsOfInstances, null);

            createdObjectsOfInstances = new ConcurrentDictionary<string, object>();

            if ((cleanedInstances != null) && (cleanedInstances.Any()))
            {
                var instanceList = cleanedInstances.Values.ToArray();

                foreach (var theInstance in instanceList)
                {
                    bool inheritedFromIDisposable = ((TypeInfo)theInstance.GetType()).ImplementedInterfaces
                                                                                     .Contains(value: typeof(IDisposable));
                    if (inheritedFromIDisposable)
                    {
                        ((IDisposable)theInstance).Dispose();
                    }
                }
            }
        }

        #endregion Public Static Functions



    }
}
