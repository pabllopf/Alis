// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRuntime.cs
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

namespace Alis.Core.Ecs.System.Property
{
    /// <summary>
    ///     The runtime interface
    /// </summary>
    public interface IRuntime
    {
        /// <summary>
        ///     Ons the enable
        /// </summary>
        public void OnEnable();
        
        /// <summary>
        ///     Inits this instance
        /// </summary>
        public void OnInit();
        
        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public void OnAwake();
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void OnStart();
        
        /// <summary>
        ///     Before run the update
        /// </summary>
        public void OnBeforeUpdate();
        
        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void OnUpdate();
        
        /// <summary>
        ///     Afters the update
        /// </summary>
        public void OnAfterUpdate();
        
        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate();
        
        /// <summary>
        ///     Update every frame.
        /// </summary>
        public void OnFixedUpdate();
        
        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate();
        
        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public void OnDispatchEvents();
        
        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate();
        
        /// <summary>
        ///     Draws this instance
        /// </summary>
        public void OnDraw();
        
        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui();
        
        /// <summary>
        ///     Ons the disable
        /// </summary>
        public void OnDisable();
        
        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void OnReset();
        
        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void OnStop();
        
        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void OnExit();
        
        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy();
    }
}