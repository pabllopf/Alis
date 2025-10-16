// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FloorAnimation.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Manager.Time;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The floor animation class
    /// </summary>
    
    public class FloorAnimation : IOnStart, IOnUpdate, IHasContext<Context>
    {
        /// <summary>
        ///     The velocity
        /// </summary>
        private const float Velocity = 2.0f;

        /// <summary>
        ///     The old
        /// </summary>
        private float xOld;

        /// <summary>
        /// Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            xOld = self.Get<Transform>().Position.X;    
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

            // get the velocity of game object:
            float displace = Velocity * Context.TimeManager.DeltaTime;

            // if the x position is less than -50.0f, then reset the x position to 0.0f
            Vector2F newPosition = x < -1.0f ? new Vector2F(xOld, y) : new Vector2F(x - displace, y);
            
            t.Position = newPosition;
        }

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }
    }
}