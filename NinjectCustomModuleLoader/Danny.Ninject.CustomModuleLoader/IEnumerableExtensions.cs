using System;
using System.Collections.Generic;

namespace Danny.Ninject.CustomModuleLoader
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Performs an action on every item in an IEnumerable of said item
        /// </summary>
        /// <typeparam name="TItem">Item type</typeparam>
        /// <param name="items">IEnumerable of type item</param>
        /// <param name="action">Action to perform</param>
        public static void Foreach<TItem>(this IEnumerable<TItem> items, Action<TItem> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}