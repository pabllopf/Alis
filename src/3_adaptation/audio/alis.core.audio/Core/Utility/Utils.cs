// 

using System.Runtime.CompilerServices;

namespace Alis.Core.Systems.Audio.Core.Utility
{
    public static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}