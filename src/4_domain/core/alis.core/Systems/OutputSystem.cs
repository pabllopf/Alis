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

#region

using System;
using System.Text.Json.Serialization;

#endregion

namespace Alis.Core.Systems
{
    /// <summary>
    ///     The output system class
    /// </summary>
    /// <seealso cref="System" />
    public class OutputSystem : System
    {
        #region Constructor()

        /// <summary>
        ///     Initializes a new instance of the <see cref="OutputSystem" /> class
        /// </summary>
        [JsonConstructor]
        public OutputSystem()
        {
        }

        #endregion

        #region Awake()

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
        }

        #endregion

        #region Start()

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        #endregion

        #region BeforeUpdate()

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
        }

        #endregion

        #region Update()

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }

        #endregion

        #region AfterUpdate()

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
        }

        #endregion

        #region FixedUpdate()

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
        }

        #endregion

        #region DispatchEvents()

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
        }

        #endregion

        #region Reset()

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset()
        {
        }

        #endregion

        #region Stop()

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop()
        {
        }

        #endregion

        #region Exit()

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit()
        {
        }

        #endregion

        #region Destructor()

        ~OutputSystem()
        {
            Console.WriteLine(@"Destroy");
        }

        #endregion
    }
}