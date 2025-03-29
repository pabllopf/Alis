// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastArraySafe.cs
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
using System.Runtime.InteropServices;

namespace Alis.Benchmark.CustomCollections.Arrays
{
    /// <summary>
    /// The fast array safe
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastArraySafe<T> : IDisposable
    {
        /// <summary>
        /// The array
        /// </summary>
        private T[] _array = [];

        /// <summary>
        /// Obtiene la longitud del array.
        /// </summary>
        public int Length => _array.Length;

        /// <summary>
        /// Permite acceder al elemento en la posición indicada.
        /// </summary>
        public ref T this[int index] => ref _array[index];

        /// <summary>
        /// Inicializa una nueva instancia de FastArraySafe con la longitud especificada.
        /// </summary>
        /// <param name="length">La longitud del array.</param>
        public FastArraySafe(int length)
        {
            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "La longitud debe ser mayor a 0.");
            }

            _array = new T[length];
        }

        /// <summary>
        /// Devuelve el array como Span&lt;T&gt; para iteraciones rápidas.
        /// </summary>
        
        public Span<T> AsSpan() => _array;

        /// <summary>
        /// Limpia el array asignando el valor por defecto a cada elemento.
        /// </summary>
        
        public void Clear() => Array.Clear(_array, 0, _array.Length);

        /// <summary>
        /// Redimensiona el array a la nueva longitud indicada.
        /// Se copia el contenido existente hasta el menor de ambas longitudes.
        /// </summary>
        /// <param name="newLength">La nueva longitud del array.</param>
        
        public void Resize(int newLength)
        {
            if (newLength == _array.Length)
            {
                return;
            }

            T[] newArray = new T[newLength];
            int count = Math.Min(_array.Length, newLength);
            Array.Copy(_array, newArray, count);
            _array = newArray;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => _array = null;

        /// <summary>
        /// Converts the span len using the specified array size
        /// </summary>
        /// <param name="arraySize">The array size</param>
        /// <returns>A span of t</returns>
        public Span<T> AsSpanLen(int arraySize) => _array.AsSpan(0, arraySize);
    }
}