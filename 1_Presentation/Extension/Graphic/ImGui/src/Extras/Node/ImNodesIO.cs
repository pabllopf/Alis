// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesIO.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Node
{
    /// <summary>
    ///     The im nodes io
    /// </summary>
    public struct ImNodesIo
    {
        /// <summary>
        ///     The emulate three button mouse
        /// </summary>
        public EmulateThreeButtonMouse ThreeButtonMouse { get; set; }

        /// <summary>
        ///     The link detach with modifier click
        /// </summary>
        public LinkDetachWithModifierClick DetachWithModifierClick { get; set; }

        /// <summary>
        ///     The multiple select modifier
        /// </summary>
        public MultipleSelectModifier SelectModifier { get; set; }

        /// <summary>
        ///     The alt mouse button
        /// </summary>
        public int AltMouseButton { get; set; }

        /// <summary>
        ///     The auto panning speed
        /// </summary>
        public float AutoPanningSpeed { get; set; }
    }
}