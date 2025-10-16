// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BirdIdle.cs
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
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The bird idle class
    /// </summary>
    
    public class BirdIdle : IOnStart, IOnUpdate, IHasContext<Context>
    {
        /// <summary>
        ///     The range movement
        /// </summary>
        private const float RangeMovement = 0.3f;

        /// <summary>
        ///     The velocity
        /// </summary>
        private const float Velocity = 1f;

        /// <summary>
        ///     The default position
        /// </summary>
        private Vector2F defaultPosition;

        /// <summary>
        ///     The go down
        /// </summary>
        private bool goDown;

        /// <summary>
        ///     The go up
        /// </summary>
        private bool goUp = true;
        
        /// <summary>
        /// Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            defaultPosition = self.Get<Transform>().Position;
        }

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            ref Transform t = ref self.Get<Transform>();
            
            // get the x position of game object:
            float x = t.Position.X;

            // get the y position of game object:
            float y = t.Position.Y;

            Vector2F scale = t.Scale;


            float rotation = t.Rotation;

            // create a new position:
            Vector2F newPosition;

            if (goUp && !goDown)
            {
                float displace = Velocity * Context.TimeManager.DeltaTime;
                newPosition = new Vector2F(x, y - displace);
                Transform transform = new Transform
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };

                self.Get<Transform>() = transform;
            }
            else if (goDown && !goUp)
            {
                float displace = Velocity * Context.TimeManager.DeltaTime;
                newPosition = new Vector2F(x, y + displace);
                Transform transform = new Transform
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };

                self.Get<Transform>() = transform;
            }

            if (y < defaultPosition.Y - RangeMovement)
            {
                goUp = false;
                goDown = true;
            }

            if (y > defaultPosition.Y + RangeMovement)
            {
                goUp = true;
                goDown = false;
            }
        }

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }
    }
}