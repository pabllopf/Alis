// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonEventArgsTest.cs
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

using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The json event args test class
    /// </summary>
    public class JsonEventArgsTest
    {
        /// <summary>
        ///     Tests that json event args constructor with four parameters sets properties correctly
        /// </summary>
        [Fact]
        public void JsonEventArgs_ConstructorWithFourParameters_SetsPropertiesCorrectly()
        {
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            JsonEventArgs eventArgs = new JsonEventArgs(writer, value, objectGraph, options);

            Assert.Equal(writer, eventArgs.Writer);
            Assert.Equal(value, eventArgs.Value);
            Assert.Equal(objectGraph, eventArgs.ObjectGraph);
            Assert.Equal(options, eventArgs.Options);
        }

        /// <summary>
        ///     Tests that json event args constructor with six parameters sets properties correctly
        /// </summary>
        [Fact]
        public void JsonEventArgs_ConstructorWithSixParameters_SetsPropertiesCorrectly()
        {
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            string name = "TestName";
            object component = new object();

            JsonEventArgs eventArgs = new JsonEventArgs(writer, value, objectGraph, options, name, component);

            Assert.Equal(writer, eventArgs.Writer);
            Assert.Equal(value, eventArgs.Value);
            Assert.Equal(objectGraph, eventArgs.ObjectGraph);
            Assert.Equal(options, eventArgs.Options);
            Assert.Equal(name, eventArgs.Name);
            Assert.Equal(component, eventArgs.Component);
        }

        /// <summary>
        ///     Tests that json event args properties can be set
        /// </summary>
        [Fact]
        public void JsonEventArgs_PropertiesCanBeSet()
        {
            JsonEventArgs eventArgs = new JsonEventArgs(null, null, null, null)
            {
                EventType = JsonEventType.Unspecified,
                Handled = true,
                First = true,
                Value = new object(),
                Name = "TestName"
            };

            Assert.Equal(JsonEventType.Unspecified, eventArgs.EventType);
            Assert.True(eventArgs.Handled);
            Assert.True(eventArgs.First);
            Assert.NotNull(eventArgs.Value);
            Assert.Equal("TestName", eventArgs.Name);
        }
    }
}