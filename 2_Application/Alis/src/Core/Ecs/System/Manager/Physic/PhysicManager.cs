// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicManagerBase.cs
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
        /// Ons the enable
        /// </summary>
        public override void OnEnable()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the init
        /// </summary>
        public override void OnInit()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the before update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the before fixed update
        /// </summary>
        public override void OnBeforeFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the fixed update
        /// </summary>
        public override void OnFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the after fixed update
        /// </summary>
        public override void OnAfterFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the calculate
        /// </summary>
        public override void OnCalculate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the gui
        /// </summary>
        public override void OnGui()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the disable
        /// </summary>
        public override void OnDisable()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the reset
        /// </summary>
        public override void OnReset()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the stop
        /// </summary>
        public override void OnStop()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Attaches the body
        /// </summary>
        /// <param name="body">The body</param>
        public static void Attach(Body body)
        {
            
        }
    }
}