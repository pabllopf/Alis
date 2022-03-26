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

using Alis.Core.Physics2D.Shapes;

namespace Alis.Core.Physics2D.Fixtures
{
    /// <summary>
    ///     A fixture definition is used to create a fixture. This class defines an
    ///     abstract fixture definition. You can reuse fixture definitions safely.
    /// </summary>
    public class FixtureDef
    {
        /// <summary>
        ///     The density, usually in kg/m^2.
        /// </summary>
        public float density;

        /// <summary>
        ///     Contact filtering data.
        /// </summary>
        public Filter filter = new Filter();

        /// <summary>
        ///     The friction coefficient, usually in the range [0,1].
        /// </summary>
        public float friction = 0.2f;

        /// <summary>
        ///     A sensor shape collects contact information but never generates a collision response.
        /// </summary>
        public bool isSensor;

        /// <summary>
        ///     The restitution (elasticity) usually in the range [0,1].
        /// </summary>
        public float restitution;

        /// <summary>
        ///     The shape
        /// </summary>
        public Shape shape;

        /// <summary>
        ///     Use this to store application specific fixture data.
        /// </summary>
        public object userData;
    }
}