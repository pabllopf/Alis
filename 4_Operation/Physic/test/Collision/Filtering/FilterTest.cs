// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilterTest.cs
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
using Alis.Core.Physic.Config;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Filtering
{
    /// <summary>
    ///     The filter test class
    /// </summary>
    public class FilterTest
    {
        /// <summary>
        ///     Tests that default constructor test
        /// </summary>
        [Fact]
        public void DefaultConstructorTest()
        {
            Filter filter = new Filter();
            Assert.Equal(Settings.DefaultCollisionGroup, filter.Group);
            Assert.Equal(Settings.DefaultFixtureCollisionCategories, filter.Category);
            Assert.Equal(Settings.DefaultFixtureCollidesWith, filter.CategoryMask);
        }
        
        /// <summary>
        ///     Tests that parameterized constructor test
        /// </summary>
        /// <param name="group">The group</param>
        /// <param name="category">The category</param>
        /// <param name="mask">The mask</param>
        [Theory]
        [InlineData(1, Category.Cat1, Category.Cat2)]
        [InlineData(2, Category.Cat2, Category.Cat3)]
        [InlineData(3, Category.Cat3, Category.Cat4)]
        public void ParameterizedConstructorTest(short group, Category category, Category mask)
        {
            Filter filter = new Filter(group, category, mask);
            Assert.Equal(group, filter.Group);
            Assert.Equal(category, filter.Category);
            Assert.Equal(mask, filter.CategoryMask);
        }
    }
}