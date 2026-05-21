// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonNativeIgnoreAttribute.cs
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

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Specifies that a property should be ignored during JSON serialization and deserialization.
    ///     When applied to a property, the JSON serializer and deserializer will skip that property entirely,
    ///     excluding it from the generated JSON output and ignoring it when reading JSON input.
    /// </summary>
    /// <remarks>
    ///     This attribute is only valid on properties. It is used in conjunction with the
    ///     <see cref="IJsonSerializable" /> and <see cref="IJsonDesSerializable{T}" /> interfaces
    ///     to control which properties participate in JSON conversion. Properties marked with this
    ///     attribute will not be included in serialized output and will not be populated during deserialization.
    /// </remarks>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsonNativeIgnoreAttribute : Attribute
    {
    }
}
