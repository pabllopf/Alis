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

using System;
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
        /// <exception cref="NotImplementedException"></exception>
        public void OnEnable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnInit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnAwake()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnStart()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnBeforeUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnAfterUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnBeforeFixedUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnFixedUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnAfterFixedUpdate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDispatchEvents()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnCalculate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDraw()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnGui()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDisable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnReset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnStop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnExit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDestroy()
        {
            throw new NotImplementedException();
        }
    }
}