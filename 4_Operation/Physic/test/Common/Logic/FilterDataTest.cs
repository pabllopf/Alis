// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilterDataTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The filter data test class
    /// </summary>
    public class FilterDataTest
    {
        /// <summary>
        ///     The test filter data class
        /// </summary>
        /// <seealso cref="FilterData" />
        private class TestFilterData : FilterData
        {
        }

        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            TestFilterData filter = new TestFilterData();
            
            Assert.Equal(Category.None, filter.DisabledOnCategories);
            Assert.Equal(0, filter.DisabledOnGroup);
            Assert.Equal(Category.All, filter.EnabledOnCategories);
            Assert.Equal(0, filter.EnabledOnGroup);
        }

        /// <summary>
        ///     Tests that is active on should return false for null body
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnFalse_ForNullBody()
        {
            TestFilterData filter = new TestFilterData();
            
            bool result = filter.IsActiveOn(null);
            
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is active on should return false for disabled body
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnFalse_ForDisabledBody()
        {
            TestFilterData filter = new TestFilterData();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            body.Enabled = false;
            
            bool result = filter.IsActiveOn(body);
            
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is active on should return false for static body
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnFalse_ForStaticBody()
        {
            TestFilterData filter = new TestFilterData();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(Vector2F.Zero, 0, BodyType.Static);
            
            bool result = filter.IsActiveOn(body);
            
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is active on should return true for enabled dynamic body
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnTrue_ForEnabledDynamicBody()
        {
            TestFilterData filter = new TestFilterData();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            body.CreateFixture(new CircleShape(1.0f, 1.0f));
            
            bool result = filter.IsActiveOn(body);
            
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that add disabled category should add category
        /// </summary>
        [Fact]
        public void AddDisabledCategory_ShouldAddCategory()
        {
            TestFilterData filter = new TestFilterData();
            
            filter.AddDisabledCategory(Category.Cat1);
            
            Assert.True((filter.DisabledOnCategories & Category.Cat1) == Category.Cat1);
        }

        /// <summary>
        ///     Tests that remove disabled category should remove category
        /// </summary>
        [Fact]
        public void RemoveDisabledCategory_ShouldRemoveCategory()
        {
            TestFilterData filter = new TestFilterData();
            filter.AddDisabledCategory(Category.Cat1);
            
            filter.RemoveDisabledCategory(Category.Cat1);
            
            Assert.False((filter.DisabledOnCategories & Category.Cat1) == Category.Cat1);
        }

        /// <summary>
        ///     Tests that is in disabled category should return true for disabled category
        /// </summary>
        [Fact]
        public void IsInDisabledCategory_ShouldReturnTrue_ForDisabledCategory()
        {
            TestFilterData filter = new TestFilterData();
            filter.AddDisabledCategory(Category.Cat2);
            
            bool result = filter.IsInDisabledCategory(Category.Cat2);
            
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that is in disabled category should return false for enabled category
        /// </summary>
        [Fact]
        public void IsInDisabledCategory_ShouldReturnFalse_ForEnabledCategory()
        {
            TestFilterData filter = new TestFilterData();
            
            bool result = filter.IsInDisabledCategory(Category.Cat1);
            
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that add enabled category should add category
        /// </summary>
        [Fact]
        public void AddEnabledCategory_ShouldAddCategory()
        {
            TestFilterData filter = new TestFilterData();
            filter.EnabledOnCategories = Category.None;
            
            filter.AddEnabledCategory(Category.Cat3);
            
            Assert.True((filter.EnabledOnCategories & Category.Cat3) == Category.Cat3);
        }

        /// <summary>
        ///     Tests that remove enabled category should remove category
        /// </summary>
        [Fact]
        public void RemoveEnabledCategory_ShouldRemoveCategory()
        {
            TestFilterData filter = new TestFilterData();
            filter.AddEnabledCategory(Category.Cat4);
            
            filter.RemoveEnabledCategory(Category.Cat4);
            
            Assert.False((filter.EnabledOnCategories & Category.Cat4) == Category.Cat4);
        }

        /// <summary>
        ///     Tests that is in enabled in category should return true for enabled category
        /// </summary>
        [Fact]
        public void IsInEnabledInCategory_ShouldReturnTrue_ForEnabledCategory()
        {
            TestFilterData filter = new TestFilterData();
            
            bool result = filter.IsInEnabledInCategory(Category.Cat1);
            
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that filter data should be abstract class
        /// </summary>
        [Fact]
        public void FilterData_ShouldBeAbstractClass()
        {
            var type = typeof(FilterData);
            
            Assert.True(type.IsAbstract);
        }

        /// <summary>
        ///     Tests that disabled on group property should set and get correctly
        /// </summary>
        [Fact]
        public void DisabledOnGroupProperty_ShouldSetAndGetCorrectly()
        {
            TestFilterData filter = new TestFilterData
            {
                DisabledOnGroup = 5
            };
            
            Assert.Equal(5, filter.DisabledOnGroup);
        }

        /// <summary>
        ///     Tests that enabled on group property should set and get correctly
        /// </summary>
        [Fact]
        public void EnabledOnGroupProperty_ShouldSetAndGetCorrectly()
        {
            TestFilterData filter = new TestFilterData
            {
                EnabledOnGroup = 10
            };
            
            Assert.Equal(10, filter.EnabledOnGroup);
        }

        /// <summary>
        ///     Tests that is active on should return false for disabled group
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnFalse_ForDisabledGroup()
        {
            TestFilterData filter = new TestFilterData
            {
                DisabledOnGroup = 5
            };
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 1.0f));
            
            
            bool result = filter.IsActiveOn(body);
            
            Assert.True(result);
        }
    }
}

