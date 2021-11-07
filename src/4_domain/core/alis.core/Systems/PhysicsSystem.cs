// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PhysicsSystem.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Text.Json.Serialization;

namespace Alis.Core.Systems
{
    /// <summary>
    /// The physics system class
    /// </summary>
    /// <seealso cref="System"/>
    public class PhysicsSystem : System
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicsSystem" /> class
        /// </summary>
        [JsonConstructor]
        public PhysicsSystem()
        {
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
        /// Destroy object.
        /// </summary>
        ~PhysicsSystem() => Console.WriteLine(@$"Destroy PhysicsSystem {GetHashCode().ToString()}");
    }
}