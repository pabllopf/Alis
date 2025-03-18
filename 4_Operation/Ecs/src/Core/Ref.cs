// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ref.cs
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
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core
{
  /// <summary>
/// A wrapper ref struct over a reference to a <typeparamref name="T"/>
/// </summary>
/// <typeparam name="T">The type this <see cref="Ref{T}"/> wraps over</typeparam>
public ref struct Ref<T>
{
#if NET7_0_OR_GREATER
    internal Ref(T[] compArr, int index) => _comp = ref compArr.UnsafeArrayIndex(index);
    internal Ref(Span<T> compSpan, int index) => _comp = ref compSpan.UnsafeSpanIndex(index);
    internal Ref(ComponentStorage<T> compSpan, int index) => _comp = ref compSpan[index];

    private ref T _comp;

    /// <summary>
    /// The wrapped reference to <typeparamref name="T"/>
    /// </summary>
    public readonly ref T Value => ref _comp;
    /// <summary>
    /// Extracts the wrapped <typeparamref name="T"/> from this <see cref="Ref{T}"/>
    /// </summary>
    public static implicit operator T(Ref<T> @ref) => @ref.Value;
    /// <summary>
    /// Calls the wrapped <typeparamref name="T"/>'s ToString() function, or returns null.
    /// </summary>
    /// <returns>A string representation of the wrapped <typeparamref name="T"/>'s</returns>
    public override readonly string? ToString() => Value?.ToString();
#elif (NETSTANDARD || NETCOREAPP || NETFRAMEWORK) && !NET7_0_OR_GREATER
    internal Ref(T[] compArr, int index)
    {
        _data = compArr;
        _offset = index;
    }
    internal Ref(Span<T> compSpan, int index)
    {
        _data = compSpan;
        _offset = index;
    }

    internal Ref(ComponentStorage<T> compSpan, int index)
    {
        _data = compSpan.AsSpan();
        _offset = index;
    }

    private Span<T> _data;
    private int _offset;

    /// <summary>
    /// The wrapped reference to <typeparamref name="T"/>
    /// </summary>
    public readonly ref T Value => ref _data.UnsafeSpanIndex(_offset);
    /// <summary>
    /// Extracts the wrapped <typeparamref name="T"/> from this <see cref="Ref{T}"/>
    /// </summary>
    public static implicit operator T(Ref<T> @ref) => @ref.Value;
    /// <summary>
    /// Calls the wrapped <typeparamref name="T"/>'s ToString() function, or returns null.
    /// </summary>
    /// <returns>A string representation of the wrapped <typeparamref name="T"/>'s</returns>
    public override readonly string? ToString() => Value?.ToString();
#else
    internal Ref(T[] compArr, int index) => _comp = MemoryMarshal.CreateSpan(ref compArr.UnsafeArrayIndex(index), 1);
    internal Ref(Span<T> compSpan, int index) => _comp = MemoryMarshal.CreateSpan(ref compSpan.UnsafeSpanIndex(index), 1);
    internal Ref(ComponentStorage<T> compSpan, int index) => _comp = MemoryMarshal.CreateSpan(ref compSpan[index], 1);

    private Span<T> _comp;

    /// <summary>
    /// The wrapped reference to <typeparamref name="T"/>
    /// </summary>
    public readonly ref T Value => ref MemoryMarshal.GetReference(_comp);
    /// <summary>
    /// Extracts the wrapped <typeparamref name="T"/> from this <see cref="Ref{T}"/>
    /// /// </summary>
    public static implicit operator T(Ref<T> @ref) => @ref.Value;
    /// <summary>
    /// Calls the wrapped <typeparamref name="T"/>'s ToString() function, or returns null.
    /// </summary>
    /// <returns>A string representation of the wrapped <typeparamref name="T"/>'s</returns>
    public override readonly string? ToString() => Value?.ToString();
#endif
}
}