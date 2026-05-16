// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendOperation.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl blend operation enum
    /// </summary>
    public enum BlendOperation
    {
    /// <summary>
    ///     Additive blend operation: source + destination
    /// </summary>
    SdlBlendOperationAdd = 0x1,

    /// <summary>
    ///     Subtractive blend operation: source - destination
    /// </summary>
    SdlBlendOperationSubtract = 0x2,

    /// <summary>
    ///     Reverse subtractive blend operation: destination - source
    /// </summary>
    SdlBlendOperationRevSubtract = 0x3,

    /// <summary>
    ///     Minimum blend operation: min(source, destination) per component
    /// </summary>
    SdlBlendOperationMinimum = 0x4,

    /// <summary>
    ///     Maximum blend operation: max(source, destination) per component
    /// </summary>
    SdlBlendOperationMaximum = 0x5
    }
}