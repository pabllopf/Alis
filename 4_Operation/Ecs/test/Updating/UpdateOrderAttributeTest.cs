// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateOrderAttributeTest.cs
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
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The update order attribute test class
    /// </summary>
    public class UpdateOrderAttributeTest
    {
        [Fact]
        public void Constructor_WithZero_CreatesInstance()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(0);

            Assert.NotNull(attribute);
            Assert.IsAssignableFrom<Attribute>(attribute);
        }

        [Fact]
        public void Constructor_WithPositiveValue_CreatesInstance()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(100);

            Assert.NotNull(attribute);
        }

        [Fact]
        public void Constructor_WithNegativeValue_CreatesInstance()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(-100);

            Assert.NotNull(attribute);
        }

        [Fact]
        public void Constructor_WithMaxValue_CreatesInstance()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(int.MaxValue);

            Assert.NotNull(attribute);
        }

        [Fact]
        public void Constructor_WithMinValue_CreatesInstance()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(int.MinValue);

            Assert.NotNull(attribute);
        }

        [Fact]
        public void InheritsFromAttribute()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(42);

            Assert.IsAssignableFrom<Attribute>(attribute);
        }

        [Fact]
        public void Implements_IComponentUpdateOrderAttribute()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(42);

            Assert.IsAssignableFrom<IComponentUpdateOrderAttribute>(attribute);
        }

        [Fact]
        public void AttributeUsage_TargetsMethodsOnly()
        {
            AttributeUsageAttribute usage = typeof(UpdateOrderAttribute).GetCustomAttributes(
                typeof(AttributeUsageAttribute), false)[0] as AttributeUsageAttribute;

            Assert.NotNull(usage);
            Assert.Equal(AttributeTargets.Method, usage.ValidOn);
            Assert.False(usage.AllowMultiple);
            Assert.True(usage.Inherited);
        }

        [Fact]
        public void MultipleInstances_AreIndependent()
        {
            UpdateOrderAttribute attr1 = new UpdateOrderAttribute(1);
            UpdateOrderAttribute attr2 = new UpdateOrderAttribute(2);
            UpdateOrderAttribute attr3 = new UpdateOrderAttribute(1);

            Assert.NotNull(attr1);
            Assert.NotNull(attr2);
            Assert.NotNull(attr3);
            Assert.NotSame(attr1, attr2);
            Assert.NotSame(attr1, attr3);
        }
    }
}
