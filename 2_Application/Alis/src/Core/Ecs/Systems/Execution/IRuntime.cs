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

namespace Alis.Core.Ecs.Systems.Execution
{
    /// <summary>
    ///     The runtime interface
    /// </summary>
    public interface IRuntime
    {
        /// <summary>
        ///     Ons the enable
        /// </summary>
        void OnEnable();

        /// <summary>
        ///     Inits this instance
        /// </summary>
        void OnInit();

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        void OnAwake();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        void OnStart();

        /// <summary>
        ///     Ons the physic update
        /// </summary>
        void OnPhysicUpdate();

        /// <summary>
        ///     Before run the update
        /// </summary>
        void OnBeforeUpdate();

        /// <summary>
        ///     Updates this instance
        /// </summary>
        void OnUpdate();

        /// <summary>
        ///     Afters the update
        /// </summary>
        void OnAfterUpdate();

        /// <summary>
        ///     Ons the process pending changes
        /// </summary>
        void OnProcessPendingChanges();

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        void OnBeforeFixedUpdate();

        /// <summary>
        ///     Update every frame.
        /// </summary>
        void OnFixedUpdate();

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        void OnAfterFixedUpdate();

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        void OnDispatchEvents();

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        void OnCalculate();

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        void OnBeforeDraw();

        /// <summary>
        ///     Draws this instance
        /// </summary>
        void OnDraw();

        /// <summary>
        ///     Ons the after draw
        /// </summary>
        void OnAfterDraw();

        /// <summary>
        ///     Ons the gui
        /// </summary>
        void OnGui();

        /// <summary>
        ///     Ons the render present
        /// </summary>
        void OnRenderPresent();

        /// <summary>
        ///     Ons the disable
        /// </summary>
        void OnDisable();

        /// <summary>
        ///     Resets this instance
        /// </summary>
        void OnReset();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        void OnStop();

        /// <summary>
        ///     Exits this instance
        /// </summary>
        void OnExit();

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        void OnDestroy();

        /// <summary>
        ///     Ons the save
        /// </summary>
        void OnSave();

        /// <summary>
        ///     Ons the load
        /// </summary>
        void OnLoad();

        /// <summary>
        ///     Ons the save using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        void OnSave(string path);

        /// <summary>
        ///     Ons the load using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        void OnLoad(string path);
    }
}