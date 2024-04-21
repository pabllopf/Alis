// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSettingTest.cs
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
    ///     The contact setting test class
    /// </summary>
    public class ContactSettingTest
    {
        /// <summary>
        ///     Tests that test contact setting none
        /// </summary>
        [Fact]
        public void TestContactSetting_None()
        {
            // Assert
            Assert.Equal(0, (int) ContactSetting.None);
        }
        
        /// <summary>
        ///     Tests that test contact setting island flag
        /// </summary>
        [Fact]
        public void TestContactSetting_IslandFlag()
        {
            // Assert
            Assert.Equal(1, (int) ContactSetting.IslandFlag);
        }
        
        /// <summary>
        ///     Tests that test contact setting touching flag
        /// </summary>
        [Fact]
        public void TestContactSetting_TouchingFlag()
        {
            // Assert
            Assert.Equal(2, (int) ContactSetting.TouchingFlag);
        }
        
        /// <summary>
        ///     Tests that test contact setting enabled flag
        /// </summary>
        [Fact]
        public void TestContactSetting_EnabledFlag()
        {
            // Assert
            Assert.Equal(4, (int) ContactSetting.EnabledFlag);
        }
        
        /// <summary>
        ///     Tests that test contact setting filter flag
        /// </summary>
        [Fact]
        public void TestContactSetting_FilterFlag()
        {
            // Assert
            Assert.Equal(8, (int) ContactSetting.FilterFlag);
        }
        
        /// <summary>
        ///     Tests that test contact setting bullet hit flag
        /// </summary>
        [Fact]
        public void TestContactSetting_BulletHitFlag()
        {
            // Assert
            Assert.Equal(16, (int) ContactSetting.BulletHitFlag);
        }
        
        /// <summary>
        ///     Tests that test contact setting toi flag
        /// </summary>
        [Fact]
        public void TestContactSetting_ToiFlag()
        {
            // Assert
            Assert.Equal(32, (int) ContactSetting.ToiFlag);
        }
    }
}