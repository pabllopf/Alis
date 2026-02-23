// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonNativeAotIntegrationTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The json native aot integration test class
    /// </summary>
    public class JsonNativeAotIntegrationTest
    {
        /// <summary>
        /// The user profile class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{UserProfile}"/>
        private class UserProfile : IJsonSerializable, IJsonDesSerializable<UserProfile>
        {
            /// <summary>
            /// Gets or sets the value of the username
            /// </summary>
            public string Username { get; set; }
            /// <summary>
            /// Gets or sets the value of the email
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// Gets or sets the value of the age
            /// </summary>
            public int Age { get; set; }
            /// <summary>
            /// Gets or sets the value of the is active
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Username", Username);
                yield return ("Email", Email);
                yield return ("Age", Age.ToString());
                yield return ("IsActive", IsActive.ToString());
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The user profile</returns>
            public UserProfile CreateFromProperties(Dictionary<string, string> properties)
            {
                return new UserProfile
                {
                    Username = properties.TryGetValue("Username", out var username) ? username : null,
                    Email = properties.TryGetValue("Email", out var email) ? email : null,
                    Age = properties.TryGetValue("Age", out var age) && int.TryParse(age, out var ageValue) ? ageValue : 0,
                    IsActive = properties.TryGetValue("IsActive", out var isActive) && bool.TryParse(isActive, out var isActiveValue) ? isActiveValue : false
                };
            }
        }

        /// <summary>
        /// Tests that serialize deserialize round trip preserves data
        /// </summary>
        [Fact]
        public void Serialize_Deserialize_RoundTrip_PreservesData()
        {
            var original = new UserProfile
            {
                Username = "johnsmith",
                Email = "john@example.com",
                Age = 30,
                IsActive = true
            };

            string json = JsonNativeAot.Serialize(original);
            var deserialized = JsonNativeAot.Deserialize<UserProfile>(json);

            Assert.Equal(original.Username, deserialized.Username);
            Assert.Equal(original.Email, deserialized.Email);
            Assert.Equal(original.Age, deserialized.Age);
            Assert.Equal(original.IsActive, deserialized.IsActive);
        }

        /// <summary>
        /// Tests that parse json to dictionary with simple json returns dictionary
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithSimpleJson_ReturnsDictionary()
        {
            string json = "{\"key1\":\"value1\",\"key2\":\"value2\"}";
            var properties = JsonNativeAot.ParseJsonToDictionary(json);

            Assert.Equal(2, properties.Count);
            Assert.Equal("value1", properties["key1"]);
            Assert.Equal("value2", properties["key2"]);
        }

        /// <summary>
        /// Tests that serialize create valid json format
        /// </summary>
        [Fact]
        public void Serialize_CreateValidJsonFormat()
        {
            var obj = new UserProfile
            {
                Username = "testuser",
                Email = "test@test.com",
                Age = 25,
                IsActive = false
            };

            string json = JsonNativeAot.Serialize(obj);

            Assert.StartsWith("{", json);
            Assert.EndsWith("}", json);
            Assert.Contains("\"Username\"", json);
            Assert.Contains("\"testuser\"", json);
        }

        /// <summary>
        /// Tests that deserialize with complete json creates complete object
        /// </summary>
        [Fact]
        public void Deserialize_WithCompleteJson_CreatesCompleteObject()
        {
            string json = "{\"Username\":\"alice\",\"Email\":\"alice@test.com\",\"Age\":\"28\",\"IsActive\":\"true\"}";
            var user = JsonNativeAot.Deserialize<UserProfile>(json);

            Assert.Equal("alice", user.Username);
            Assert.Equal("alice@test.com", user.Email);
            Assert.Equal(28, user.Age);
            Assert.True(user.IsActive);
        }

        /// <summary>
        /// Tests that deserialize with partial json fills available properties
        /// </summary>
        [Fact]
        public void Deserialize_WithPartialJson_FillsAvailableProperties()
        {
            string json = "{\"Username\":\"bob\"}";
            var user = JsonNativeAot.Deserialize<UserProfile>(json);

            Assert.Equal("bob", user.Username);
            Assert.Null(user.Email);
            Assert.Equal(0, user.Age);
            Assert.False(user.IsActive);
        }

        /// <summary>
        /// Tests that serialize with whitespace in values escapes correctly
        /// </summary>
        [Fact]
        public void Serialize_WithWhitespaceInValues_EscapesCorrectly()
        {
            var obj = new UserProfile
            {
                Username = "user with spaces",
                Email = "user@example.com",
                Age = 35,
                IsActive = true
            };

            string json = JsonNativeAot.Serialize(obj);
            var deserialized = JsonNativeAot.Deserialize<UserProfile>(json);

            Assert.Equal("user with spaces", deserialized.Username);
        }

        /// <summary>
        /// Tests that serialize multiple objects produced different json
        /// </summary>
        [Fact]
        public void Serialize_MultipleObjects_ProducedDifferentJson()
        {
            var obj1 = new UserProfile { Username = "user1", Email = "user1@test.com", Age = 25, IsActive = true };
            var obj2 = new UserProfile { Username = "user2", Email = "user2@test.com", Age = 30, IsActive = false };

            string json1 = JsonNativeAot.Serialize(obj1);
            string json2 = JsonNativeAot.Serialize(obj2);

            Assert.NotEqual(json1, json2);
        }
    }
}

