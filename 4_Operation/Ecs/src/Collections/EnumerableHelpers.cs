// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpers.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     Internal helper functions for working with enumerables.
    /// </summary>
    public static class EnumerableHelpers
    {
        /// <summary>Calls Reset on an enumerator instance.</summary>
        /// <remarks>Enables Reset to be called without boxing on a struct enumerator that lacks a public Reset.</remarks>
        internal static void Reset<T>(ref T enumerator) where T : IEnumerator
        {
            enumerator.Reset();
        }

        /// <summary>Gets an enumerator singleton for an empty collection.</summary>
        public static IEnumerator<T> GetEmptyEnumerator<T>() => ((IEnumerable<T>) Array.Empty<T>()).GetEnumerator();

        /// <summary>Converts an enumerable to an array using the same logic as List{T}.</summary>
        /// <param name="source">The enumerable to convert.</param>
        /// <param name="length">The number of items stored in the resulting array, 0-indexed.</param>
        /// <returns>
        ///     The resulting array.  The length of the array may be greater than <paramref name="length" />,
        ///     which is the actual number of elements in the array.
        /// </returns>
        public static T[] ToArray<T>(IEnumerable<T> source, out int length)
        {
            const int arrayMaxLength = 0X7FFFFFC7;

            if (source is ICollection<T> ic)
            {
                return ToArrayFromCollection(ic, out length);
            }

            using (IEnumerator<T> en = source.GetEnumerator())
            {
                if (en.MoveNext())
                {
                    return ToArrayFromEnumerator(en, arrayMaxLength, out length);
                }
            }

            length = 0;
            return Array.Empty<T>();
        }

        /// <summary>
        /// Returns the array from collection using the specified collection
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="length">The length</param>
        /// <returns>The array</returns>
        private static T[] ToArrayFromCollection<T>(ICollection<T> collection, out int length)
        {
            int count = collection.Count;
            if (count != 0)
            {
                T[] arr = new T[count];
                collection.CopyTo(arr, 0);
                length = count;
                return arr;
            }

            length = 0;
            return Array.Empty<T>();
        }

        /// <summary>
        /// Returns the array from enumerator using the specified enumerator
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="enumerator">The enumerator</param>
        /// <param name="arrayMaxLength">The array max length</param>
        /// <param name="length">The length</param>
        /// <returns>The arr</returns>
        private static T[] ToArrayFromEnumerator<T>(IEnumerator<T> enumerator, int arrayMaxLength, out int length)
        {
            const int defaultCapacity = 4;
            T[] arr = new T[defaultCapacity];
            arr[0] = enumerator.Current;
            int count = 1;

            while (enumerator.MoveNext())
            {
                if (count == arr.Length)
                {
                    int newLength = count << 1;
                    if ((uint) newLength > arrayMaxLength)
                    {
                        newLength = arrayMaxLength <= count ? count + 1 : arrayMaxLength;
                    }

                    Array.Resize(ref arr, newLength);
                }

                arr[count++] = enumerator.Current;
            }

            length = count;
            return arr;
        }
    }
}