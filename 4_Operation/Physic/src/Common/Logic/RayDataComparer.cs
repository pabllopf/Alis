

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     This is a comprarer used for
    ///     detecting angle difference between rays
    /// </summary>
    internal class RayDataComparer : IComparer<float>
    {
        /// <summary>
        ///     Compares the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        int IComparer<float>.Compare(float a, float b)
        {
            float diff = a - b;
            if (diff > 0)
            {
                return 1;
            }

            if (diff < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}