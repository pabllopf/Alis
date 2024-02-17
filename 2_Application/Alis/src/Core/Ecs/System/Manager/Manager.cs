// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Manager.cs
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

namespace Alis.Core.Ecs.System.Manager
{
    /// <summary>
    ///     The manager class
    /// </summary>
    /// <seealso cref="IManager" />
    public abstract class Manager : IManager
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
        public abstract void OnEnable();

        /// <summary>
        ///     Ons the init
        /// </summary>
        public abstract void OnInit();

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public abstract void OnAwake();

        /// <summary>
        ///     Ons the start
        /// </summary>
        public abstract void OnStart();

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public abstract void OnBeforeUpdate();

        /// <summary>
        ///     Ons the update
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public abstract void OnAfterUpdate();

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public abstract void OnBeforeFixedUpdate();

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public abstract void OnFixedUpdate();

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public abstract void OnAfterFixedUpdate();

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public abstract void OnDispatchEvents();

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public abstract void OnCalculate();

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public abstract void OnDraw();

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public abstract void OnGui();

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public abstract void OnDisable();

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public abstract void OnReset();

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public abstract void OnStop();

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public abstract void OnExit();

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public abstract void OnDestroy();
    }
}