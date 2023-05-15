// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditRow.cs
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

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The stb textedit row
    /// </summary>
    public struct StbTexteditRow
    {
        /// <summary>
        /// The 
        /// </summary>
        public float x0;
        /// <summary>
        /// The 
        /// </summary>
        public float x1;
        /// <summary>
        /// The baseline delta
        /// </summary>
        public float baseline_y_delta;
        /// <summary>
        /// The ymin
        /// </summary>
        public float ymin;
        /// <summary>
        /// The ymax
        /// </summary>
        public float ymax;
        /// <summary>
        /// The num chars
        /// </summary>
        public int num_chars;
    }
}