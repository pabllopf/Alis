using System;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The pair
    /// </summary>
    internal struct Pair : IComparable<Pair>
    {
        /// <summary>
        /// The proxy id
        /// </summary>
        public int ProxyIdA;
        /// <summary>
        /// The proxy id
        /// </summary>
        public int ProxyIdB;

        #region IComparable<Pair> Members

        /// <summary>
        /// Compares the to using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The int</returns>
        public int CompareTo(Pair other)
        {
            if (ProxyIdB < other.ProxyIdB)
            {
                return -1;
            }

            if (ProxyIdB == other.ProxyIdB)
            {
                if (ProxyIdA < other.ProxyIdA)
                {
                    return -1;
                }

                if (ProxyIdA == other.ProxyIdA)
                {
                    return 0;
                }
            }

            return 1;
        }

        #endregion
    }
}