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
        public static IEnumerator<T> GetEmptyEnumerator<T>()
        {
            return ((IEnumerable<T>)Array.Empty<T>()).GetEnumerator();
        }

        /// <summary>Converts an enumerable to an array using the same logic as List{T}.</summary>
        /// <param name="source">The enumerable to convert.</param>
        /// <param name="length">The number of items stored in the resulting array, 0-indexed.</param>
        /// <returns>
        ///     The resulting array.  The length of the array may be greater than <paramref name="length" />,
        ///     which is the actual number of elements in the array.
        /// </returns>
        public static T[] ToArray<T>(IEnumerable<T> source, out int length)
        {
            // Copied from Array.MaxLength in System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Array.cs
            const int arrayMaxLength = 0X7FFFFFC7;

            if (source is ICollection<T> ic)
            {
                int count = ic.Count;
                if (count != 0)
                {
                    // Allocate an array of the desired size, then copy the elements into it. Note that this has the same
                    // issue regarding concurrency as other existing collections like List<T>. If the collection size
                    // concurrently changes between the array allocation and the CopyTo, we could end up either getting an
                    // exception from overrunning the array (if the size went up) or we could end up not filling as many
                    // items as 'count' suggests (if the size went down).  This is only an issue for concurrent collections
                    // that implement ICollection<T>, which as of .NET 4.6 is just ConcurrentDictionary<TKey, TValue>.
                    T[] arr = new T[count];
                    ic.CopyTo(arr, 0);
                    length = count;
                    return arr;
                }
            }
            else
            {
                using (var en = source.GetEnumerator())
                {
                    if (en.MoveNext())
                    {
                        const int defaultCapacity = 4;
                        T[] arr = new T[defaultCapacity];
                        arr[0] = en.Current;
                        int count = 1;

                        while (en.MoveNext())
                        {
                            if (count == arr.Length)
                            {
                                // This is the same growth logic as in List<T>:
                                // If the array is currently empty, we make it a default size.  Otherwise, we attempt to
                                // double the size of the array.  Doubling will overflow once the size of the array reaches
                                // 2^30, since doubling to 2^31 is 1 larger than Int32.MaxValue.  In that case, we instead
                                // constrain the length to be Array.MaxLength (this overflow check works because of the
                                // cast to uint).
                                int newLength = count << 1;
                                if ((uint)newLength > arrayMaxLength)
                                    newLength = arrayMaxLength <= count ? count + 1 : arrayMaxLength;

                                Array.Resize(ref arr, newLength);
                            }

                            arr[count++] = en.Current;
                        }

                        length = count;
                        return arr;
                    }
                }
            }

            length = 0;
            return Array.Empty<T>();
        }
    }
}