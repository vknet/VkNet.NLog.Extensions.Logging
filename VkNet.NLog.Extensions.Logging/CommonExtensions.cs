#if NET40
using System;
using System.Reflection;

namespace VkNet.NLog.Extensions.Logging
{
    /// <summary>
    /// Методы расширения для совместимости с NET45
    /// </summary>
    public static class CommonExtensions
    {
        /// <summary>
        /// Получить информацию о типе
        /// </summary>
        /// <param name="type"> Тип </param>
        /// <returns> Тип </returns>
        public static Type GetTypeInfo(this Type type)
        {
            return type;
        }

        /// <summary>
        /// Получить задекларированный тип
        /// </summary>
        /// <param name="type">Тип данных</param>
        /// <param name="name">Имя свойства</param>
        /// <returns></returns>
        public static PropertyInfo GetDeclaredProperty(this Type type, string name)
        {
            return type.GetProperty(name, BindingFlags.DeclaredOnly);
        }
    }
}
#endif