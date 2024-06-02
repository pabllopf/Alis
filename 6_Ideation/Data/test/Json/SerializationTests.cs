// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SerializationTests.cs
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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Test.Json.Sample;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The serialization tests class
    /// </summary>
    public class SerializationTests
    {
        /// <summary>
        ///     Tests that test simple types
        /// </summary>
        [Fact]
        public void TestSimpleTypes()
        {
            Assert.Equal("true", JsonSerializer.Serialize(true));
            Assert.Equal("false", JsonSerializer.Serialize(false));
            Assert.Equal("12345678", JsonSerializer.Serialize(12345678));
            Assert.Equal("12345678901234567890", JsonSerializer.Serialize(12345678901234567890));
            Assert.Equal("1234567890123456789.0123456789", JsonSerializer.Serialize(1234567890123456789.01234567890m));
            Assert.Equal("12345678", JsonSerializer.Serialize((uint) 12345678));
            Assert.Equal("128", JsonSerializer.Serialize((byte) 128));
            Assert.Equal("-56", JsonSerializer.Serialize((sbyte) -56));
            Assert.Equal("-56", JsonSerializer.Serialize((short) -56));
            Assert.Equal("12345", JsonSerializer.Serialize((ushort) 12345));
            Assert.Equal("\"héllo world\"", JsonSerializer.Serialize("héllo world"));
            TimeSpan ts = new TimeSpan(12, 34, 56, 7, 8);
            Assert.Equal("1162567008", JsonSerializer.Serialize(ts));
            Assert.Equal("\"13:10:56:07.008\"", JsonSerializer.Serialize(ts, new JsonOptions {SerializationOptions = JsonSerializationOptions.TimeSpanAsText}));
            Guid guid = Guid.NewGuid();
            Assert.Equal("\"" + guid + "\"", JsonSerializer.Serialize(guid));
            Assert.Equal("\"https://github.com/smourier/ZeroDepJson\"", JsonSerializer.Serialize(new Uri("https://github.com/smourier/ZeroDepJson")));
            Assert.Equal("2", JsonSerializer.Serialize(UriKind.Relative));
            Assert.Equal("\"Relative\"", JsonSerializer.Serialize(UriKind.Relative, new JsonOptions {SerializationOptions = JsonSerializationOptions.EnumAsText}));
            Assert.Equal("\"x\"", JsonSerializer.Serialize('x'));
            Assert.Equal("1234.5677", JsonSerializer.Serialize(1234.5678f));
            Assert.Equal("1234.5678", JsonSerializer.Serialize(1234.5678d));
        }
        
        
        /// <summary>
        ///     Tests that test cyclic
        /// </summary>
        [Fact]
        public void TestCyclic()
        {
            Person person = new Person {Name = "foo"};
            Person[] persons = {person, person};
            try
            {
                JsonSerializer.Serialize(persons, new JsonOptions());
            }
            catch (JsonException ex)
            {
                Assert.True(ex.Code == 9);
            }
        }
        
        /// <summary>
        ///     Tests that test cyclic custom
        /// </summary>
        [Fact]
        public void TestCyclicCustom()
        {
            Person person = new Person {Name = "héllo"};
            Person[] persons = {person, person};
            CustomOptions options = new CustomOptions();
            string json = JsonSerializer.Serialize(persons, options);
            Assert.False(json == "[{\"Name\":\"héllo\"},{\"Name\":\"héllo\"}]");
        }
    }
}