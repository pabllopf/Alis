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

using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The property info accessor test class
    /// </summary>
    public class PropertyInfoAccessorTest
    {
        /// <summary>
        ///     Tests that test property info accessor get
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
        ///     Tests that test property info accessor set
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
        
        /// <summary>
        ///     Tests that dispose enumerator is disposable value is not disposes enumerator
        /// </summary>
        [Fact]
        public void Dispose_EnumeratorIsDisposable_ValueIsNot_DisposesEnumerator()
        {
            // Arrange
            DisposableTracker disposableEnumerator = new DisposableTracker();
            NonDisposableTracker nonDisposableValue = new NonDisposableTracker();
            
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"key1", disposableEnumerator},
                {"key2", nonDisposableValue}
            };
            
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            
            // Act
            enumerator.Dispose();
            
            // Assert
            Assert.False(disposableEnumerator.IsDisposed);
        }
        
        /// <summary>
        ///     Tests that dispose value is disposable enumerator is not disposes value
        /// </summary>
        [Fact]
        public void Dispose_ValueIsDisposable_EnumeratorIsNot_DisposesValue()
        {
            // Arrange
            NonDisposableTracker nonDisposableEnumerator = new NonDisposableTracker();
            DisposableTracker disposableValue = new DisposableTracker();
            
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"key1", nonDisposableEnumerator},
                {"key2", disposableValue}
            };
            
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            
            // Act
            enumerator.Dispose();
            
            // Assert
            Assert.False(disposableValue.IsDisposed);
        }
        
        /// <summary>
        ///     Tests that dispose both are disposable disposes both
        /// </summary>
        [Fact]
        public void Dispose_BothAreDisposable_DisposesBoth()
        {
            // Arrange
            DisposableTracker disposableEnumerator = new DisposableTracker();
            DisposableTracker disposableValue = new DisposableTracker();
            
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"key1", disposableEnumerator},
                {"key2", disposableValue}
            };
            
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            
            // Act
            enumerator.Dispose();
            
            // Assert
            Assert.False(disposableEnumerator.IsDisposed);
            Assert.False(disposableValue.IsDisposed);
        }
        
        /// <summary>
        ///     Tests that dispose neither are disposable does not throw
        /// </summary>
        [Fact]
        public void Dispose_NeitherAreDisposable_DoesNotThrow()
        {
            // Arrange
            NonDisposableTracker nonDisposableEnumerator = new NonDisposableTracker();
            NonDisposableTracker nonDisposableValue = new NonDisposableTracker();
            
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"key1", nonDisposableEnumerator},
                {"key2", nonDisposableValue}
            };
            
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            
            // Act
            Exception exception = Record.Exception(() => enumerator.Dispose());
            
            // Assert
            Assert.Null(exception);
        }
    }
}