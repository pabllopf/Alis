// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ToiOutputTest.cs
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

using Alis.Core.Physic.Collision.TOI;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.TOI
{
    /// <summary>
    ///     The toi output test class
    /// </summary>
    public class ToiOutputTest
    {
        /// <summary>
        ///     Tests that test toi output state property
        /// </summary>
        [Fact]
        public void TestToiOutputStateProperty()
        {
            // Arrange
            ToiOutput toiOutput = new ToiOutput
            {
                // Act
                State = ToiOutputState.Failed
            };
            
            // Assert
            Assert.Equal(ToiOutputState.Failed, toiOutput.State);
        }
        
        /// <summary>
        ///     Tests that test toi output property property
        /// </summary>
        [Fact]
        public void TestToiOutputPropertyProperty()
        {
            // Arrange
            ToiOutput toiOutput = new ToiOutput
            {
                // Act
                Property = 0.5f
            };
            
            // Assert
            Assert.Equal(0.5f, toiOutput.Property);
        }
    }
}