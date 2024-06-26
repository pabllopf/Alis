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

using Alis.Core.Physic.Collision.ContactSystem;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.ContactSystem
{
    /// <summary>
    ///     The contact id test class
    /// </summary>
    public class ContactIdTest
    {
        /// <summary>
        ///     Tests that test contact feature property
        /// </summary>
        [Fact]
        public void TestContactFeatureProperty()
        {
            // Arrange
            ContactId contactId = new ContactId();
            ContactFeature contactFeature = new ContactFeature();
            
            // Act
            contactId.ContactFeature = contactFeature;
            
            // Assert
            Assert.Equal(contactFeature, contactId.ContactFeature);
        }
        
        /// <summary>
        ///     Tests that test key property
        /// </summary>
        [Fact]
        public void TestKeyProperty()
        {
            // Arrange
            ContactId contactId = new ContactId();
            uint key = 1;
            
            // Act
            contactId.Key = key;
            
            // Assert
            Assert.Equal(key, contactId.Key);
        }
    }
}