// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureDef.cs
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

using Alis.Core.Physic.Collisions.Shape;

namespace Alis.Core.Physic.Dynamics.Fixtures
{
    /// <summary>
    ///     A fixture definition is used to create a fixture. This class defines an
    ///     abstract fixture definition. You can reuse fixture definitions safely.
    /// </summary>
    public class FixtureDef
    {
        /// <summary>
        ///     A sensor shape collects contact information but never generates a collision response.
        /// </summary>
        public readonly bool IsSensor;

        /// <summary>
        ///     The restitution (elasticity) usually in the range [0,1].
        /// </summary>
        public readonly float Restitution;

        /// <summary>
        ///     Use this to store application specific fixture data.
        /// </summary>
        public readonly object UserData;

        /// <summary>
        ///     The density, usually in kg/m^2.
        /// </summary>
        public float Density;

        /// <summary>
        ///     Contact filtering data.
        /// </summary>
        public FilterData Filter;

        /// <summary>
        ///     The friction coefficient, usually in the range [0,1].
        /// </summary>
        public float Friction;

        /// <summary>
        ///     Holds the shape type for down-casting.
        /// </summary>
        public ShapeType Type;

        /// <summary>
        ///     The constructor sets the default fixture definition values.
        /// </summary>
        public FixtureDef()
        {
            Type = ShapeType.UnknownShape;
            UserData = null;
            Friction = 0.2f;
            Restitution = 0.0f;
            Density = 0.0f;
            Filter.CategoryBits = 0x0001;
            Filter.MaskBits = 0xFFFF;
            Filter.GroupIndex = 0;
            IsSensor = false;
        }
    }
}