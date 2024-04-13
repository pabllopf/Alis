// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureStringTests.cs
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

using Xunit;

namespace Alis.Core.Aspect.Security.Test
{
    /// <summary>
    ///     The secure string tests class
    /// </summary>
    public class SecureStringTests
    {
        /// <summary>
        ///     Tests that test set value get value
        /// </summary>
        [Fact]
        public void TestSetValueGetValue()
        {
            // Arrange
            SecureString secureString = new SecureString("test");
            
            // Act
            string value = secureString.GetValue();
            
            // Assert
            Assert.Equal("test", value);
        }
        
        /// <summary>
        ///     Tests that test encryption decryption
        /// </summary>
        [Fact]
        public void TestEncryptionDecryption()
        {
            // Arrange
            SecureString secureString = new SecureString("test");
            
            // Act
            secureString.SetValue("newTest");
            string value = secureString.GetValue();
            
            // Assert
            Assert.Equal("newTest", value);
        }
        
        /// <summary>
        ///     Tests that test different instances
        /// </summary>
        [Fact]
        public void TestDifferentInstances()
        {
            // Arrange
            SecureString secureString1 = new SecureString("test");
            SecureString secureString2 = new SecureString("test");
            
            // Act
            string value1 = secureString1.GetValue();
            string value2 = secureString2.GetValue();
            
            // Assert
            Assert.Equal(value1, value2);
        }
    }
}