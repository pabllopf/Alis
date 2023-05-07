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

namespace Alis.Core.Manager.Physic
{
    /// <summary>
    ///     The physic manager class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class PhysicManager : PhysicManagerBase
    {
        /// <summary>
        ///     Gets or sets the value of the world
        /// </summary>
        public World World { get; set; }

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            World = new World(VideoGame.Setting.Physic.Gravity);
            Logger.Trace();
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            World.Step((float) GameBase.TimeManager.TimeStep, 6, 2);
        }


        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
        }

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset()
        {
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop()
        {
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit()
        {
        }

        /// <summary>
        ///     Attaches the body using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void AttachBody(Body body)
        {
            World.AddBody(body);
        }
    }
}