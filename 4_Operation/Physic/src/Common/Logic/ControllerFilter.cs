// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerFilter.cs
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

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     The controller filter
    /// </summary>
    public struct ControllerFilter
    {
        /// <summary>
        ///     The controller categories
        /// </summary>
        public ControllerCategory ControllerCategories;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ControllerFilter" /> class
        /// </summary>
        /// <param name="controllerCategory">The controller category</param>
        public ControllerFilter(ControllerCategory controllerCategory) => ControllerCategories = controllerCategory;

        /// <summary>
        ///     Ignores the controller. The controller has no effect on this body.
        /// </summary>
        /// <param name="category"></param>
        public void IgnoreController(ControllerCategory category)
        {
            ControllerCategories &= ~category;
        }

        /// <summary>
        ///     Restore the controller. The controller affects this body.
        /// </summary>
        /// <param name="category">The logic type.</param>
        public void RestoreController(ControllerCategory category)
        {
            ControllerCategories |= category;
        }

        /// <summary>
        ///     Determines whether this body ignores the the specified controller.
        /// </summary>
        /// <param name="category">The logic type.</param>
        /// <returns>
        ///     <c>true</c> if the body has the specified flag; otherwise, <c>false</c>.
        /// </returns>
        public bool IsControllerIgnored(ControllerCategory category) => (ControllerCategories & category) != category;
    }
}