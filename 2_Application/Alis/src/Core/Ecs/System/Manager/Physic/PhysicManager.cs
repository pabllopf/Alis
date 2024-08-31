// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicManager.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Ecs.System.Manager.Physic
{
    /// <summary>
    ///     The physic manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class PhysicManager : AManager
    {
        public World World = new World(new AABB(){LowerBound = new Vec2(-10000.0f, -10000.0f), UpperBound = new Vec2(10000.0f, 10000.0f)}, new Vec2(0.0f, 0f), true);
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (Context is null)
            {
                return;
            }
            World.Step(1/30.0f, 8, 3);
        }
        
        /// <summary>
        ///     Uns the attach using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void UnAttach(Body body)
        {
            World.DestroyBody(body);
        }
    }
}