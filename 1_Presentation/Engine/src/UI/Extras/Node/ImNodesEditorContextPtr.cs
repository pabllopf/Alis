// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ImNodesEditorContextPtr.cs
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

namespace Alis.App.Engine.UI.Extras.Node
{
    /// <summary>
    ///     The im nodes editor context ptr class
    /// </summary>
    public class ImNodesEditorContextPtr
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImNodesEditorContextPtr" /> class
        /// </summary>
        /// <param name="ret">The ret</param>
        public unsafe ImNodesEditorContextPtr(ImNodesEditorContext* ret) => NativePtr = ret;

        /// <summary>
        ///     Gets or sets the value of the native ptr
        /// </summary>
        public unsafe ImNodesEditorContext* NativePtr { get; private set; }
    }
}