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
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;
using Alis.Core.Components;
using Alis.Core.Managers;
using Alis.Core.Systems.Physics2D;

namespace Alis.Core.Systems
{
    /// <summary>
    ///     The physics system class
    /// </summary>
    /// <seealso cref="System" />
    public class PhysicsSystem : System
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicsSystem" /> class
        /// </summary>
        [JsonConstructor]
        public PhysicsSystem()
        {
            Vector2 gravity = new Vector2(0.000000000000000e+00f, 1.000000000000000e+01f);
            World = new World(gravity);
        }

        /// <summary>
        ///     Gets or sets the value of the colliders
        /// </summary>
        private static List<Collider> Colliders { get; } = new List<Collider>();

        /// <summary>
        ///     The world
        /// </summary>
        public static World World { get; private set; }

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
        ///     Attaches the collider
        /// </summary>
        /// <param name="collider">The collider</param>
        public static void Attach(Collider collider) => Colliders.Add(collider);


        /// <summary>
        ///     Uns the attach using the specified collider
        /// </summary>
        /// <param name="collider">The collider</param>
        public static void UnAttach(Collider collider) => Colliders.Remove(collider);

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            if (Game.Setting.Debug.ShowPhysicBorders)
            {
                if (Colliders.Count > 0)
                {
                    //Colliders = Colliders.OrderBy(o => o.Level).ToList();
                    for (int i = 0; i < Colliders.Count; i++)
                    {
                        RenderManager.GetWindows().Draw(Colliders[i].GetDrawable());
                    }
                }
            }

            World.Step((float) Game.Setting.Time.TimeStep, 8, 8);
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
        ///     Destroy object.
        /// </summary>
        ~PhysicsSystem() => Console.WriteLine(@$"Destroy PhysicsSystem {GetHashCode().ToString()}");
    }
}