// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BuoyancyControllerDef.cs
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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     This class is used to build buoyancy controllers
    /// </summary>
    public class BuoyancyControllerDef
    {
        /// Linear drag co-efficient
        public readonly float AngularDrag;

        /// The fluid density
        public readonly float Density;

        /// Gravity vector, if the world's gravity is not used
        public Vec2 Gravity;

        /// Linear drag co-efficient
        public readonly float LinearDrag;

        /// The outer surface normal
        public Vec2 Normal;

        /// The height of the fluid surface along the normal
        public readonly float Offset;

        /// If false, bodies are assumed to be uniformly dense, otherwise use the shapes densities
        public readonly bool UseDensity; //False by default to prevent a gotcha

        /// If true, gravity is taken from the world instead of the gravity parameter.
        public readonly bool UseWorldGravity;

        /// Fluid velocity, for drag calculations
        public Vec2 Velocity;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuoyancyControllerDef" /> class
        /// </summary>
        public BuoyancyControllerDef()
        {
            Normal = new Vec2(0, 1);
            Offset = 0;
            Density = 0;
            Velocity = new Vec2(0, 0);
            LinearDrag = 0;
            AngularDrag = 0;
            UseDensity = false;
            UseWorldGravity = true;
            Gravity = new Vec2(0, 0);
        }
    }
}