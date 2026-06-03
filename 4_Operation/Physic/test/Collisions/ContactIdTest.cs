// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactIdTest.cs
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


using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The contact id test class
    /// </summary>
    public class ContactIdTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            ContactId contactId = new ContactId();

            Assert.Equal(default(ContactFeature), contactId.Features);
            Assert.Equal(0u, contactId.Key);
        }
        

        /// <summary>
        ///     Tests that key should set and get correctly
        /// </summary>
        [Fact]
        public void Key_ShouldSetAndGetCorrectly()
        {
            uint expectedKey = 0x12345678u;

            ContactId contactId = new ContactId
            {
                Key = expectedKey
            };

            Assert.Equal(expectedKey, contactId.Key);
        }
        

        /// <summary>
        ///     Tests that setting key should update features through union
        /// </summary>
        [Fact]
        public void SettingKey_ShouldUpdateFeaturesThroughUnion()
        {
            uint testKey = 0xDEADBEEFu;

            ContactId contactId = new ContactId { Key = testKey };

            Assert.Equal(testKey, contactId.Key);
            Assert.NotEqual(default(ContactFeature), contactId.Features);
        }

        /// <summary>
        ///     Tests that default contact id should have zero key
        /// </summary>
        [Fact]
        public void DefaultContactId_ShouldHaveZeroKey()
        {
            ContactId contactId = new ContactId();

            Assert.Equal(0u, contactId.Key);
        }
        
        
        /// <summary>
        ///     Tests that contact id should be different with different keys
        /// </summary>
        [Fact]
        public void ContactId_ShouldBeDifferentWithDifferentKeys()
        {
            ContactId id1 = new ContactId { Key = 0x11111111u };
            ContactId id2 = new ContactId { Key = 0x22222222u };

            Assert.NotEqual(id1, id2);
        }
    }
}
