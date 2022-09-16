// -------------------------------------------------------------------------- 
//  
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█  
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄ 
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█ 
//
//  -------------------------------------------------------------------------- 
//  File:PhysicSystem.cs 
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

using Alis.Core.Manager;
using Alis.Core.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core.System
{
    /// <summary>
    /// The physic system class
    /// </summary>
    /// <seealso cref="SystemBase"/>
    internal class PhysicSystem : SystemBase
    {
        /// <summary>
        /// The physic manager
        /// </summary>
        public PhysicManager physicManager = new PhysicManager();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicSystem"/> class
        /// </summary>
        public PhysicSystem() 
        {
            managerBase = physicManager;
        }

        /// <summary>
        /// Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Awakes this instance
        /// </summary>
        public override void Awake()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Exits this instance
        /// </summary>
        public override void Exit()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Resets this instance
        /// </summary>
        public override void Reset()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Stops this instance
        /// </summary>
        public override void Stop()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
