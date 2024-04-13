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

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Ecs.System.Manager.Physic
{
    /// <summary>
    ///     The physic manager base class
    /// </summary>
    /// <seealso cref="Manager" />
    public class PhysicManager : Manager, IPhysicManager
    {
        /// <summary>
        ///     The vector
        /// </summary>
        private readonly World world = new World(new Vector2(0, 9.8f));
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            Logger.Trace();
            world.Step(Game.TimeManager.Configuration.FixedTimeStep);
        }
        
        /// <summary>
        ///     Attaches the body
        /// </summary>
        /// <param name="body">The body</param>
        public void Attach(Body body)
        {
            world.AddBody(body);
        }
        
        /// <summary>
        ///     Uns the attach using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void UnAttach(Body body)
        {
            world.RemoveBody(body);
        }
    }
}