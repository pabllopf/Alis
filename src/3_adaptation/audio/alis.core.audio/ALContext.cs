// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ALContext.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Audio
{
    public struct ALContext : IEquatable<ALContext>
    {
        public static readonly ALContext Null = new ALContext(IntPtr.Zero);

        public IntPtr Handle;

        public ALContext(IntPtr handle) => Handle = handle;

        public override bool Equals(object obj) => obj is ALContext handle && Equals(handle);

        public bool Equals([AllowNull] ALContext other) => Handle.Equals(other.Handle);

        public override int GetHashCode() => HashCode.Combine(Handle);

        public static bool operator ==(ALContext left, ALContext right) => left.Equals(right);

        public static bool operator !=(ALContext left, ALContext right) => !(left == right);

        public static implicit operator IntPtr(ALContext context) => context.Handle;
    }
}