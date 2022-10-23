// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FixtureDef.cs
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

using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Definitions
{
    /// <summary>
    ///     The fixture def class
    /// </summary>
    /// <seealso cref="IDef" />
    public class FixtureDef : IDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FixtureDef" /> class
        /// </summary>
        public FixtureDef()
        {
            SetDefaults();
        }

        //Velcro: removed density from fixtures. It is only present on shapes

        /// <summary>Contact filtering data.</summary>
        public Filter Filter { get; set; }

        /// <summary>The friction coefficient, usually in the range [0,1].</summary>
        public float Friction { get; set; }

        /// <summary>A sensor shape collects contact information but never generates a collision response.</summary>
        public bool IsSensor { get; set; }

        /// <summary>The restitution (elasticity) usually in the range [0,1].</summary>
        public float Restitution { get; set; }

        /// <summary>
        ///     Restitution velocity threshold, usually in m/s. Collisions above this speed have restitution applied (will bounce).
        /// </summary>
        public float RestitutionThreshold { get; set; }

        /// <summary>The shape, this must be set. The shape will be cloned, so you can create the shape on the stack.</summary>
        public Shape Shape { get; set; }

        /// <summary>Use this to store application specific fixture data.</summary>
        public object? UserData { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public void SetDefaults()
        {
            Shape = null;
            Friction = 0.2f;
            Restitution = 0.0f;
            RestitutionThreshold = 1.0f;
            IsSensor = false;
            Filter = new Filter();
        }
    }
}