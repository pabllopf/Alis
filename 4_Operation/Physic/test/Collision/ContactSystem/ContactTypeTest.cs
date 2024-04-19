// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactTypeTest.cs
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
    /// The contact type test class
    /// </summary>
    public class ContactTypeTest
    {
        /// <summary>
        /// Tests that test contact type not supported
        /// </summary>
        [Fact]
        public void TestContactType_NotSupported()
        {
            // Assert
            Assert.Equal(0, (int) ContactType.NotSupported);
        }
        
        /// <summary>
        /// Tests that test contact type polygon
        /// </summary>
        [Fact]
        public void TestContactType_Polygon()
        {
            // Assert
            Assert.Equal(1, (int) ContactType.Polygon);
        }
        
        /// <summary>
        /// Tests that test contact type polygon and circle
        /// </summary>
        [Fact]
        public void TestContactType_PolygonAndCircle()
        {
            // Assert
            Assert.Equal(2, (int) ContactType.PolygonAndCircle);
        }
        
        /// <summary>
        /// Tests that test contact type circle
        /// </summary>
        [Fact]
        public void TestContactType_Circle()
        {
            // Assert
            Assert.Equal(3, (int) ContactType.Circle);
        }
        
        /// <summary>
        /// Tests that test contact type edge and polygon
        /// </summary>
        [Fact]
        public void TestContactType_EdgeAndPolygon()
        {
            // Assert
            Assert.Equal(4, (int) ContactType.EdgeAndPolygon);
        }
        
        /// <summary>
        /// Tests that test contact type edge and circle
        /// </summary>
        [Fact]
        public void TestContactType_EdgeAndCircle()
        {
            // Assert
            Assert.Equal(5, (int) ContactType.EdgeAndCircle);
        }
        
        /// <summary>
        /// Tests that test contact type chain and polygon
        /// </summary>
        [Fact]
        public void TestContactType_ChainAndPolygon()
        {
            // Assert
            Assert.Equal(6, (int) ContactType.ChainAndPolygon);
        }
        
        /// <summary>
        /// Tests that test contact type chain and circle
        /// </summary>
        [Fact]
        public void TestContactType_ChainAndCircle()
        {
            // Assert
            Assert.Equal(7, (int) ContactType.ChainAndCircle);
        }
    }
}