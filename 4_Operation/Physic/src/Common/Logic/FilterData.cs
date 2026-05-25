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

using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     Contains filter data that can determine whether an object should be processed or not.
    /// </summary>
    public abstract class FilterData
    {
        /// <summary>
        ///     Disable the logic on specific categories.
        ///     Categories.None by default.
        /// </summary>
        public Categories DisabledOnCategories = Categories.None;

        /// <summary>
        ///     Disable the logic on specific groups
        /// </summary>
        public int DisabledOnGroup;

        /// <summary>
        ///     Enable the logic on specific categories
        ///     Categories.All by default.
        /// </summary>
        public Categories EnabledOnCategories = Categories.All;

        /// <summary>
        ///     Enable the logic on specific groups.
        /// </summary>
        public int EnabledOnGroup;

        /// <summary>
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public virtual bool IsActiveOn(Body body)
        {
            if (body == null || !body.Enabled || body.GetBodyType == BodyType.Static)
            {
                return false;
            }

            foreach (Fixture fixture in body.FixtureList)
            {
                if ((fixture.GetCollisionGroup == DisabledOnGroup) && (fixture.GetCollisionGroup != 0) && (DisabledOnGroup != 0))
                {
                    return false;
                }

                if ((fixture.GetCollisionCategories & DisabledOnCategories) != Categories.None)
                {
                    return false;
                }

                if (EnabledOnGroup != 0 || EnabledOnCategories != Categories.All)
                {
                    if ((fixture.GetCollisionGroup == EnabledOnGroup) && (fixture.GetCollisionGroup != 0) && (EnabledOnGroup != 0))
                    {
                        return true;
                    }

                    if (((fixture.GetCollisionCategories & EnabledOnCategories) != Categories.None) &&
                        (EnabledOnCategories != Categories.All))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void AddDisabledCategory(Categories category)
        {
            DisabledOnCategories |= category;
        }

        /// <summary>
        ///     Removes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void RemoveDisabledCategory(Categories category)
        {
            DisabledOnCategories &= ~category;
        }

        /// <summary>
        ///     Determines whether this body ignores the the specified controller.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///     <c>true</c> if the object has the specified category; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInDisabledCategory(Categories category) => (DisabledOnCategories & category) == category;

        /// <summary>
        ///     Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void AddEnabledCategory(Categories category)
        {
            EnabledOnCategories |= category;
        }

        /// <summary>
        ///     Removes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void RemoveEnabledCategory(Categories category)
        {
            EnabledOnCategories &= ~category;
        }

        /// <summary>
        ///     Determines whether this body ignores the the specified controller.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///     <c>true</c> if the object has the specified category; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInEnabledInCategory(Categories category) => (EnabledOnCategories & category) == category;
    }
}