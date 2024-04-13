// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ManagerSample.cs
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
using Alis.Core.Ecs.System.Manager;

namespace Alis.Core.Test.Ecs.System.Manager
{
    /// <summary>
    ///     The manager test class
    /// </summary>
    /// <seealso cref="IManager" />
    internal class ManagerSample : IManager
    {
        /// <summary>
        ///     Gets or sets the value of the is enable
        /// </summary>
        public bool IsEnable { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>
        public string Tag { get; set; }
        
        /// <summary>
        ///     Ons the enable
        /// </summary>
        public void OnEnable()
        {
            Logger.Info("ManagerSample enabled");
        }
        
        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            Logger.Info("ManagerSample initialized");
        }
        
        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake()
        {
            Logger.Info("ManagerSample awaked");
        }
        
        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart()
        {
            Logger.Info("ManagerSample started");
        }
        
        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate()
        {
            Logger.Info("ManagerSample before update");
        }
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate()
        {
            Logger.Info("ManagerSample updated");
        }
        
        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate()
        {
            Logger.Info("ManagerSample after update");
        }
        
        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate()
        {
            Logger.Info("ManagerSample before fixed update");
        }
        
        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate()
        {
            Logger.Info("ManagerSample fixed update");
        }
        
        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate()
        {
            Logger.Info("ManagerSample after fixed update");
        }
        
        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents()
        {
            Logger.Info("ManagerSample dispatch events");
        }
        
        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate()
        {
            Logger.Info("ManagerSample calculated");
        }
        
        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw()
        {
            Logger.Info("ManagerSample draw");
        }
        
        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui()
        {
            Logger.Info("ManagerSample gui");
        }
        
        /// <summary>
        ///     Ons the disable
        /// </summary>
        public void OnDisable()
        {
            Logger.Info("ManagerSample disabled");
        }
        
        /// <summary>
        ///     Ons the reset
        /// </summary>
        public void OnReset()
        {
            Logger.Info("ManagerSample reset");
        }
        
        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop()
        {
            Logger.Info("ManagerSample stopped");
        }
        
        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit()
        {
            Logger.Info("ManagerSample exited");
        }
        
        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy()
        {
            Logger.Info("ManagerSample destroyed");
        }
    }
}