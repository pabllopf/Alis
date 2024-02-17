// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilterData.cs
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

using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Extensions.PhysicsLogics
{
    /// <summary>Contains filter data that can determine whether an object should be processed or not.</summary>
    public abstract class FilterData
    {
        /// <summary>Disable the logic on specific categories. Category.None by default.</summary>
        public Category DisabledOnCategories = Category.None;

        /// <summary>Disable the logic on specific groups</summary>
        public int DisabledOnGroup;

        /// <summary>Enable the logic on specific categories Category.All by default.</summary>
        public Category EnabledOnCategories = Category.All;

        /// <summary>Enable the logic on specific groups.</summary>
        public int EnabledOnGroup;

        /// <summary>
        /// Describes whether this instance is active on
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The bool</returns>
        public virtual bool IsActiveOn(Body body)
        {
            if (!IsValidBody(body))
            {
                return false;
            }

            foreach (Fixture fixture in body.FixtureList)
            {
                if (IsFixtureDisabled(fixture))
                {
                    return false;
                }

                if (IsFixtureEnabled(fixture))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Describes whether this instance is valid body
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The bool</returns>
        private bool IsValidBody(Body body)
        {
            return body != null && body.Enabled && !body.IsStatic && body.FixtureList != null;
        }

        /// <summary>
        /// Describes whether this instance is fixture disabled
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <returns>The bool</returns>
        private bool IsFixtureDisabled(Fixture fixture)
        {
            return (fixture.CollisionGroup == DisabledOnGroup && fixture.CollisionGroup != 0 && DisabledOnGroup != 0) ||
                   (fixture.CollisionCategories & DisabledOnCategories) != Category.None;
        }

        /// <summary>
        /// Describes whether this instance is fixture enabled
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <returns>The bool</returns>
        private bool IsFixtureEnabled(Fixture fixture)
        {
            return (EnabledOnGroup != 0 || EnabledOnCategories != Category.All) &&
                   ((fixture.CollisionGroup == EnabledOnGroup && fixture.CollisionGroup != 0 && EnabledOnGroup != 0) ||
                    ((fixture.CollisionCategories & EnabledOnCategories) != Category.None &&
                     EnabledOnCategories != Category.All));
        }

        /// <summary>Adds the category.</summary>
        /// <param name="category">The category.</param>
        public void AddDisabledCategory(Category category)
        {
            DisabledOnCategories |= category;
        }

        /// <summary>Removes the category.</summary>
        /// <param name="category">The category.</param>
        public void RemoveDisabledCategory(Category category)
        {
            DisabledOnCategories &= ~category;
        }

        /// <summary>Determines whether this body ignores the the specified controller.</summary>
        /// <param name="category">The category.</param>
        /// <returns><c>true</c> if the object has the specified category; otherwise, <c>false</c>.</returns>
        public bool IsInDisabledCategory(Category category) => (DisabledOnCategories & category) == category;

        /// <summary>Adds the category.</summary>
        /// <param name="category">The category.</param>
        public void AddEnabledCategory(Category category)
        {
            EnabledOnCategories |= category;
        }

        /// <summary>Removes the category.</summary>
        /// <param name="category">The category.</param>
        public void RemoveEnabledCategory(Category category)
        {
            EnabledOnCategories &= ~category;
        }

        /// <summary>Determines whether this body ignores the the specified controller.</summary>
        /// <param name="category">The category.</param>
        /// <returns><c>true</c> if the object has the specified category; otherwise, <c>false</c>.</returns>
        public bool IsInEnabledInCategory(Category category) => (EnabledOnCategories & category) == category;
    }
}