// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Operation.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Guizmo
{
    /// <summary>
    ///     The operation enum
    /// </summary>
    public enum Operation
    {
        /// <summary>
        ///     The translate operation
        /// </summary>
        TranslateX = 1,
        
        /// <summary>
        ///     The translate operation
        /// </summary>
        TranslateY = 2,
        
        /// <summary>
        ///     The translate operation
        /// </summary>
        TranslateZ = 4,
        
        /// <summary>
        ///     The rotate operation
        /// </summary>
        RotateX = 8,
        
        /// <summary>
        ///     The rotate operation
        /// </summary>
        RotateY = 16,
        
        /// <summary>
        ///     The rotate operation
        /// </summary>
        RotateZ = 32,
        
        /// <summary>
        ///     The rotate screen operation
        /// </summary>
        RotateScreen = 64,
        
        /// <summary>
        ///     The scale operation
        /// </summary>
        ScaleX = 128,
        
        /// <summary>
        ///     The scale operation
        /// </summary>
        ScaleY = 256,
        
        /// <summary>
        ///     The scale operation
        /// </summary>
        ScaleZ = 512,
        
        /// <summary>
        ///     The bounds operation
        /// </summary>
        Bounds = 1024,
        
        /// <summary>
        ///     The translate operation
        /// </summary>
        Translate = 7,
        
        /// <summary>
        ///     The rotate operation
        /// </summary>
        Rotate = 120,
        
        /// <summary>
        ///     The scale operation
        /// </summary>
        Scale = 896
    }
}