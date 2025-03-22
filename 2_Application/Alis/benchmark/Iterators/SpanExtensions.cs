// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:d.cs
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
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Benchmark.Iterators
{
    public static class SpanExtensions
    {
        public static void FastFor<T>(this Span<T> span, Action<T> action) where T : struct
        {
            int vectorSize = Vector<T>.Count;
            int length = span.Length;
            ref T start = ref MemoryMarshal.GetReference(span);

            for (int i = 0; i <= length - vectorSize; i += vectorSize)
            {
                Vector<T> vector = new Vector<T>(Unsafe.Add(ref start, i));
                for (int j = 0; j < vectorSize; j++)
                {
                    action(vector[j]);
                }
            }

            for (int i = length - (length % vectorSize); i < length; i++)
            {
                action(Unsafe.Add(ref start, i));
            }
        }
    }
}