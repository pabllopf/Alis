// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentUpdateItemModel.cs
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

namespace Alis.Core.Ecs.Generator.Models
{
    /// <summary>
    /// </summary>
    /// <param name="Flags"></param>
    /// <param name="FullName"></param>
    /// <param name="Namespace"></param>
    /// <param name="ImplInterface"></param>
    /// <param name="HintName"></param>
    /// <param name="MinimallyQualifiedName"></param>
    /// <param name="NestedTypes"></param>
    /// <param name="GenericArguments"></param>
    /// <param name="Attributes"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct ComponentUpdateItemModel(
        UpdateModelFlags Flags,
        string FullName, // Alis.Generator.Model.ComponentUpdateItemModel
        string Namespace, // Alis.Generator.Model
        string ImplInterface, // IComponent
        string HintName, // Alis.Generator.Model.ComponentUpdateItemModel
        string MinimallyQualifiedName, // ComponentUpdateItemModel
        EquatableArray<TypeDeclarationModel> NestedTypes,
        EquatableArray<string> GenericArguments,
        EquatableArray<string> Attributes)
    {
        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly ComponentUpdateItemModel Default = new(default(UpdateModelFlags), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, new EquatableArray<TypeDeclarationModel>(), new EquatableArray<string>(), new EquatableArray<string>());

        /// <summary>
        ///     Hases the flag using the specified update model flags
        /// </summary>
        /// <param name="updateModelFlags">The update model flags</param>
        /// <returns>The bool</returns>
        public readonly bool HasFlag(UpdateModelFlags updateModelFlags) => Flags.HasFlag(updateModelFlags);

        /// <summary>
        ///     Gets the value of the is default
        /// </summary>
        public readonly bool IsDefault => Flags == UpdateModelFlags.None;

        // ComponentUpdateItemModel
        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public readonly ReadOnlySpan<char> Name => FullName.AsSpan(Namespace is null ? 0 : Namespace.Length + 1);

        /// <summary>
        ///     Gets the value of the is record
        /// </summary>
        public readonly bool IsRecord => HasFlag(UpdateModelFlags.IsRecord);

        /// <summary>
        ///     Gets the value of the is struct
        /// </summary>
        public readonly bool IsStruct => HasFlag(UpdateModelFlags.IsStruct);

        /// <summary>
        ///     Gets the value of the is generic
        /// </summary>
        public readonly bool IsGeneric => HasFlag(UpdateModelFlags.IsGeneric);
    }
}