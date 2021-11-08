// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PhysicsManager.cs
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
using Alis.Core.Sfml.Components;
using Alis.Core.Systems.Physics2D;
using Alis.Core.Systems.Physics2D.Dynamics;

namespace Alis.Core.Sfml.Managers
{
    /// <summary>
    ///     The physics manager class
    /// </summary>
    /// <seealso cref="PhysicsSystem" />
    public class PhysicsManager : PhysicsSystem
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicsSystem" /> class
        /// </summary>
        [JsonConstructor]
        public PhysicsManager()
        {
        }

        /// <summary>
        ///     The world
        /// </summary>
        public static World World { get; set; } = new World(new Vector2(0));

        /// <summary>
        ///     Gets or sets the value of the colliders
        /// </summary>
        private static List<Collider> Colliders { get; } = new List<Collider>();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            if (Game.Setting.Debug.ShowPhysicBorders)
            {
                if (Colliders.Count > 0)
                {
                    for (int i = 0; i < Colliders.Count; i++)
                    {
                        RenderManager.GetWindows().Draw(Colliders[i].GetDrawable());
                    }
                }
            }

            World.Step((float) Game.Setting.Time.TimeStep);
        }

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public override void FixedUpdate()
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
        ///     Destroy object.
        /// </summary>
        ~PhysicsManager() => Console.WriteLine(@$"Destroy PhysicsManager {GetHashCode().ToString()}");
    }
}