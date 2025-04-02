// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuntimeHelpers.cs
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

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    public static class RuntimeHelpers
    {
        public static bool IsReferenceOrContainsReferences<T>() => Cache<T>.Value;

        private static bool IsReferenceOrContainsReferences(Type type)
        {
            if (!type.IsValueType)
            {
                return true;
            }

            if (type.IsPrimitive || type.IsPointer || type.IsPointer)
            {
                return false;
            }

            return type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(f => IsReferenceOrContainsReferences(f.FieldType));
        }

        private static class Cache<T>
        {
            public static readonly bool Value = IsReferenceOrContainsReferences(typeof(T));
        }
    }
}

#endif