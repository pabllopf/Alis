// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DestructionListener.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Physics2D.Fixtures;
using Alis.Core.Physics2D.Joints;

#pragma warning disable 618

namespace Alis.Core.Physics2D.World.Callbacks
{
    /// <summary>
    ///     Joints and shapes are destroyed when their associated
    ///     body is destroyed. Implement this listener so that you
    ///     may nullify references to these joints and shapes.
    /// </summary>
    public abstract class DestructionListener
    {
        /// <summary>
        ///     Called when any joint is about to be destroyed due
        ///     to the destruction of one of its attached bodies.
        /// </summary>
        public abstract void SayGoodbye(Joint joint);

        /// <summary>
        ///     Called when any shape is about to be destroyed due
        ///     to the destruction of its parent body.
        /// </summary>
        public abstract void SayGoodbye(Fixture fixture);
    }
}