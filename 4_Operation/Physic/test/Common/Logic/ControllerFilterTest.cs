// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerFilterTest.cs
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

using System;
using Alis.Core.Physic.Common.Logic;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The controller filter test class
    /// </summary>
    public class ControllerFilterTest
    {
        /// <summary>
        /// Tests that controller filter type should be accessible
        /// </summary>
        [Fact]
        public void ControllerFilter_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(ControllerFilter));
        }

        /// <summary>
        /// Tests that constructor sets controller categories
        /// </summary>
        [Fact]
        public void Constructor_SetsControllerCategories()
        {
            ControllerFilter filter = new ControllerFilter(ControllerCategories.Cat01);

            Assert.Equal(ControllerCategories.Cat01, filter.ControllerCategories);
        }

        /// <summary>
        /// Tests that IgnoreController clears the specified category
        /// </summary>
        [Fact]
        public void IgnoreController_ClearsCategory()
        {
            ControllerFilter filter = new ControllerFilter(ControllerCategories.Cat01 | ControllerCategories.Cat02);

            filter.IgnoreController(ControllerCategories.Cat01);

            Assert.Equal(ControllerCategories.Cat02, filter.ControllerCategories);
        }

        /// <summary>
        /// Tests that RestoreController sets the specified category
        /// </summary>
        [Fact]
        public void RestoreController_SetsCategory()
        {
            ControllerFilter filter = new ControllerFilter(ControllerCategories.None);

            filter.RestoreController(ControllerCategories.Cat01);

            Assert.Equal(ControllerCategories.Cat01, filter.ControllerCategories);
        }

        /// <summary>
        /// Tests that IsControllerIgnored returns true when category is ignored
        /// </summary>
        [Fact]
        public void IsControllerIgnored_ReturnsTrueWhenIgnored()
        {
            ControllerFilter filter = new ControllerFilter(ControllerCategories.Cat02);
            filter.IgnoreController(ControllerCategories.Cat02);

            bool ignored = filter.IsControllerIgnored(ControllerCategories.Cat02);

            Assert.True(ignored);
        }

        /// <summary>
        /// Tests that IsControllerIgnored returns false when category is not ignored
        /// </summary>
        [Fact]
        public void IsControllerIgnored_ReturnsFalseWhenNotIgnored()
        {
            ControllerFilter filter = new ControllerFilter(ControllerCategories.Cat01 | ControllerCategories.Cat02);
            filter.IgnoreController(ControllerCategories.Cat01);

            bool ignored = filter.IsControllerIgnored(ControllerCategories.Cat02);

            Assert.False(ignored);
        }
    }
}

