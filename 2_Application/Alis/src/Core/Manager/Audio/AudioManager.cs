// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioManager.cs
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

namespace Alis.Core.Manager.Audio
{
    /// <summary>
    ///     The audio manager class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class AudioManager : ManagerBase
    {
        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Inits this instance
        /// </summary>
        public override void Init()
        {
            Console.WriteLine("Init:new:audiomanager");
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit()
        {
            //throw new NotImplementedException();
            Console.WriteLine("exit:audio:source:");
        }

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            //throw new NotImplementedException();
        }
    }
}