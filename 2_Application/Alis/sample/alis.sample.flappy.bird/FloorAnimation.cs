// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: FloorAnimation.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Ecs.Component;
using Vector2 = Alis.Core.Aspect.Math.Vector.Vector2;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The floor animation class
    /// </summary>
    /// <seealso cref="Component" />
    public class FloorAnimation : Component
    {
        /// <summary>
        ///     The old
        /// </summary>
        private float xOld;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            xOld = GameObject.Transform.Position.X;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            // get the x position of game object:
            float x = GameObject.Transform.Position.X;

            // get the y position of game object:
            float y = GameObject.Transform.Position.Y;

            // if the x position is less than -50.0f, then reset the x position to 0.0f
            Vector2 newPosition = x < -50.0f ? new Vector2(xOld, y) : new Vector2(x - 0.05f, y);

            Transform transform = new Transform
            {
                Position = newPosition,
                Rotation = GameObject.Transform.Rotation,
                Scale = GameObject.Transform.Scale
            };

            GameObject.Transform = transform;
        }
    }
}