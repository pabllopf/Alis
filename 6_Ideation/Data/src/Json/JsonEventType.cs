// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonEventType.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Defines a type of JSON event.
    /// </summary>
    public enum JsonEventType
    {
        /// <summary>
        ///     An unspecified type of event.
        /// </summary>
        Unspecified,

        /// <summary>
        ///     The write value event type.
        /// </summary>
        WriteValue,

        /// <summary>
        ///     The before write object event type.
        /// </summary>
        BeforeWriteObject,

        /// <summary>
        ///     The after write object event type.
        /// </summary>
        AfterWriteObject,

        /// <summary>
        ///     The write named value object event type.
        /// </summary>
        WriteNamedValueObject,

        /// <summary>
        ///     The create instance event type.
        /// </summary>
        CreateInstance,

        /// <summary>
        ///     The map entry event type.
        /// </summary>
        MapEntry,

        /// <summary>
        ///     The apply entry event type.
        /// </summary>
        ApplyEntry,

        /// <summary>
        ///     The get list object event type.
        /// </summary>
        GetListObject
    }
}