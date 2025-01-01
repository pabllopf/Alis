// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemberDefinitionTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The member definition test class
    /// </summary>
    public class MemberDefinitionTest
    {
        /// <summary>
        ///     Tests that add deserialization member null type throws argument null exception
        /// </summary>
        [Fact]
        public void AddDeserializationMember_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddDeserializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that add deserialization member null member throws argument null exception
        /// </summary>
        [Fact]
        public void AddDeserializationMember_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddDeserializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that add serialization member null type throws argument null exception
        /// </summary>
        [Fact]
        public void AddSerializationMember_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddSerializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that add serialization member null member throws argument null exception
        /// </summary>
        [Fact]
        public void AddSerializationMember_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddSerializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that get serialization members null type throws argument null exception
        /// </summary>
        [Fact]
        public void GetSerializationMembers_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.GetSerializationMembers(null));
        }

        /// <summary>
        ///     Tests that get deserialization members null type throws argument null exception
        /// </summary>
        [Fact]
        public void GetDeserializationMembers_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.GetDeserializationMembers(null));
        }

        /// <summary>
        ///     Tests that using lock null action throws argument null exception
        /// </summary>
        [Fact]
        public void UsingLock_NullAction_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.UsingLock(null, 0));
        }

        /// <summary>
        ///     Tests that name set null throws argument exception
        /// </summary>
        [Fact]
        public void Name_SetNull_ThrowsArgumentException()
        {
            MemberDefinition memberDefinition = new MemberDefinition();
            Assert.Throws<ArgumentException>(() => memberDefinition.Name = null);
        }

        /// <summary>
        ///     Tests that wire name set null throws argument exception
        /// </summary>
        [Fact]
        public void WireName_SetNull_ThrowsArgumentException()
        {
            MemberDefinition memberDefinition = new MemberDefinition();
            Assert.Throws<ArgumentException>(() => memberDefinition.WireName = null);
        }

        /// <summary>
        ///     Tests that escaped wire name set null throws argument exception
        /// </summary>
        [Fact]
        public void EscapedWireName_SetNull_ThrowsArgumentException()
        {
            MemberDefinition memberDefinition = new MemberDefinition();
            Assert.Throws<ArgumentException>(() => memberDefinition.EscapedWireName = null);
        }

        /// <summary>
        ///     Tests that accessor set null throws argument null exception
        /// </summary>
        [Fact]
        public void Accessor_SetNull_ThrowsArgumentNullException()
        {
            MemberDefinition memberDefinition = new MemberDefinition();
            Assert.Throws<ArgumentNullException>(() => memberDefinition.Accessor = null);
        }

        /// <summary>
        ///     Tests that type set null throws argument null exception
        /// </summary>
        [Fact]
        public void Type_SetNull_ThrowsArgumentNullException()
        {
            MemberDefinition memberDefinition = new MemberDefinition();
            Assert.Throws<ArgumentNullException>(() => memberDefinition.Type = null);
        }

        /// <summary>
        ///     Tests that add deserialization member v 2 null type throws argument null exception
        /// </summary>
        [Fact]
        public void AddDeserializationMember_v2_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddDeserializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that add deserialization member v 2 null member throws argument null exception
        /// </summary>
        [Fact]
        public void AddDeserializationMember_v2_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddDeserializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that add serialization member v 2 null type throws argument null exception
        /// </summary>
        [Fact]
        public void AddSerializationMember_v2_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddSerializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that add serialization membe v 2r null member throws argument null exception
        /// </summary>
        [Fact]
        public void AddSerializationMembe_v2r_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddSerializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that get serialization members v 2 null type throws argument null exception
        /// </summary>
        [Fact]
        public void GetSerializationMembers_v2_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.GetSerializationMembers(null));
        }

        /// <summary>
        ///     Tests that get deserialization members v 2 null type throws argument null exception
        /// </summary>
        [Fact]
        public void GetDeserializationMembers_v2_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.GetDeserializationMembers(null));
        }

        /// <summary>
        ///     Tests that using lock null action v 2 throws argument null exception
        /// </summary>
        [Fact]
        public void UsingLock_NullAction_v2_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.UsingLock(null, 0));
        }

        /// <summary>
        ///     Tests that equals default value null value returns false
        /// </summary>
        [Fact]
        public void EqualsDefaultValue_NullValue_ReturnsFalse()
        {
            MemberDefinition memberDefinition = new MemberDefinition();
            bool result = memberDefinition.EqualsDefaultValue(null);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that equals default value default value returns true
        /// </summary>
        [Fact]
        public void EqualsDefaultValue_DefaultValue_ReturnsTrue()
        {
            MemberDefinition memberDefinition = new MemberDefinition
            {
                DefaultValue = "default"
            };
            bool result = memberDefinition.EqualsDefaultValue("default");
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that remove deserialization member null type throws argument null exception
        /// </summary>
        [Fact]
        public void RemoveDeserializationMember_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.RemoveDeserializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that remove deserialization member null member throws argument null exception
        /// </summary>
        [Fact]
        public void RemoveDeserializationMember_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.RemoveDeserializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that remove serialization member null type throws argument null exception
        /// </summary>
        [Fact]
        public void RemoveSerializationMember_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.RemoveSerializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that remove serialization member null member throws argument null exception
        /// </summary>
        [Fact]
        public void RemoveSerializationMember_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.RemoveSerializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that to string returns name
        /// </summary>
        [Fact]
        public void ToString_ReturnsName()
        {
            MemberDefinition memberDefinition = new MemberDefinition
            {
                Name = "TestName"
            };
            string result = memberDefinition.ToString();
            Assert.Equal("TestName", result);
        }

        /// <summary>
        ///     Tests that add deserialization member v 3 null type throws argument null exception
        /// </summary>
        [Fact]
        public void AddDeserializationMember_v3_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddDeserializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that add deserialization member v 3 null member throws argument null exception
        /// </summary>
        [Fact]
        public void AddDeserializationMember_v3_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddDeserializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that add serialization member v 3 null type throws argument null exception
        /// </summary>
        [Fact]
        public void AddSerializationMember_v3_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddSerializationMember(null, new JsonOptions(), new MemberDefinition()));
        }

        /// <summary>
        ///     Tests that add serialization member v 3 null member throws argument null exception
        /// </summary>
        [Fact]
        public void AddSerializationMember_v3_NullMember_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.AddSerializationMember(typeof(string), new JsonOptions(), null));
        }

        /// <summary>
        ///     Tests that get serialization members v 3 null type throws argument null exception
        /// </summary>
        [Fact]
        public void GetSerializationMembers_v3_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.GetSerializationMembers(null));
        }

        /// <summary>
        ///     Tests that get deserialization members v 3 null type throws argument null exception
        /// </summary>
        [Fact]
        public void GetDeserializationMembers_v3_NullType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.GetDeserializationMembers(null));
        }

        /// <summary>
        ///     Tests that using lock v 2 null action throws argument null exception
        /// </summary>
        [Fact]
        public void UsingLock_v2_NullAction_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MemberDefinition.UsingLock(null, 0));
        }
    }
}