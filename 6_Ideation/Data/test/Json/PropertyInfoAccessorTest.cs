// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PropertyInfoAccessorTest.cs
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

using System.Reflection;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The property info accessor test class
    /// </summary>
    public class PropertyInfoAccessorTest
    {
        /// <summary>
        /// Tests that test property info accessor get
        /// </summary>
        [Fact]
        public void TestPropertyInfoAccessor_Get()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            PropertyInfoAccessor<MyClassSample, string> propertyInfoAccessor = new PropertyInfoAccessor<MyClassSample, string>(propertyInfo);
            MyClassSample component = new MyClassSample(); // Replace with your actual class instance

            // Act
            object result = propertyInfoAccessor.Get(component);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }

        /// <summary>
        /// Tests that test property info accessor set
        /// </summary>
        [Fact]
        public void TestPropertyInfoAccessor_Set()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            PropertyInfoAccessor<MyClassSample, string> propertyInfoAccessor = new PropertyInfoAccessor<MyClassSample, string>(propertyInfo);
            MyClassSample component = new MyClassSample(); // Replace with your actual class instance
            string value = "test"; // Replace with your actual value

            // Act
            propertyInfoAccessor.Set(component, value);

            // Assert
            Assert.Equal(value, component.MyProperty); // Replace with your actual property
        }
    }
}