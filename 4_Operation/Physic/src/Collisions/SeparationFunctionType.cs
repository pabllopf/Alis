// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SeparationFunctionType.cs
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


namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Specifies which geometric features define the separation function in continuous collision detection.
    /// </summary>
    public enum SeparationFunctionType
    {
        /// <summary>
        ///     Both shapes contribute a single vertex (point-to-point separation).
        /// </summary>
        Points,

        /// <summary>
        ///     Shape A contributes a face and Shape B contributes a vertex (face A to point B).
        /// </summary>
        FaceA,

        /// <summary>
        ///     Shape B contributes a face and Shape A contributes a vertex (face B to point A).
        /// </summary>
        FaceB
    }
}