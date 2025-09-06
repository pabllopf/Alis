// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Velocity.cs
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

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    /// <summary>
    ///     The velocity
    /// </summary>
    internal struct Velocity(int dx, int dy) : IComponent<Position>
    {
        /// <summary>
        ///     The dx
        /// </summary>
        public int DX = dx;

        /// <summary>
        ///     The dy
        /// </summary>
        public int DY = dy;

        /// <summary>
        ///     Updates the pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void Update(ref Position pos)
        {
            pos.X += DX;
            pos.Y += DY;
        }
    }
}