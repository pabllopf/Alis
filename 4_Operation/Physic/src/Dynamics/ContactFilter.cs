// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactFilter.cs
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

using Alis.Core.Physic.Dynamics.Fixtures;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     Implement this class to provide collision filtering. In other words, you can implement
    ///     this class if you want finer control over contact creation.
    /// </summary>
    public class ContactFilter
    {
        /// <summary>
        ///     Return true if contact calculations should be performed between these two shapes.
        ///     If you implement your own collision filter you may want to build from this implementation.
        ///     @warning for performance reasons this is only called when the AABBs begin to overlap.
        /// </summary>
        public virtual bool ShouldCollide(Fixture fixtureA, Fixture fixtureB)
        {
            FilterData filterA = fixtureA.Filter;
            FilterData filterB = fixtureB.Filter;

            if ((filterA.GroupIndex == filterB.GroupIndex) && (filterA.GroupIndex != 0))
            {
                return filterA.GroupIndex > 0;
            }

            bool collide = ((filterA.MaskBits & filterB.CategoryBits) != 0) &&
                           ((filterA.CategoryBits & filterB.MaskBits) != 0);
            return collide;
        }

        /// <summary>
        ///     Return true if the given shape should be considered for ray intersection.
        /// </summary>
        public bool RayCollide(object userData, Fixture fixture)
        {
            //By default, cast userData as a shape, and then collide if the shapes would collide
            if (userData == null)
            {
                return true;
            }

            return ShouldCollide((Fixture) userData, fixture);
        }
    }
}