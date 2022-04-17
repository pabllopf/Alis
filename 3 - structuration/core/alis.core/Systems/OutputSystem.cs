// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   OutputSystem.cs
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
    ///     The output system class
    /// </summary>
    /// <seealso cref="System" />
    public class OutputSystem : System
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OutputSystem" /> class
        /// </summary>
        [JsonConstructor]
        public OutputSystem()
        {
        }

        /// <summary>
        /// Inits this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Init()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Befores the awake
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void BeforeAwake()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
        }

        /// <summary>
        /// Afters the awake
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void AfterAwake()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Befores the start
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void BeforeStart()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        /// Afters the start
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void AfterStart()
        {
            throw new NotImplementedException();
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
        /// Draws this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Draw()
        {
            throw new NotImplementedException();
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

        ~OutputSystem()
        {
            Console.WriteLine(@"Destroy");
        }
    }
}