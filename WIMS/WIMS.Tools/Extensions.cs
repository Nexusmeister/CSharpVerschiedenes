using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WIMS.Tools
{
    /// <summary>
    /// Extensions für Listen
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Wandelt ein Objekt, das IEnumerable implementiert in eine ObservableCollection um
        /// </summary>
        /// <typeparam name="T">Gewünschter Typ der Liste</typeparam>
        /// <param name="collection">Collection, das IEnumerable implementiert</param>
        /// <returns>Neue ObservableCollection</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
