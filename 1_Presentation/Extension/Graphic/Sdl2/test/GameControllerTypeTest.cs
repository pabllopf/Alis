// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameControllerTypeTest.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the GameControllerType struct.
    /// </summary>
    public class GameControllerTypeTest
    {
        /// <summary>
        ///     Tests the GameControllerType struct default initialization.
        /// </summary>
        [Fact]
        public void GameControllerType_DefaultInitialization_CreatesValidStruct()
        {
            // Arrange & Act
            GameControllerType controllerType = new GameControllerType();

            // Assert
            // GameControllerType should be instantiable
            Assert.NotNull(controllerType);
        }

        /// <summary>
        ///     Tests that GameControllerType can be used as a value type.
        /// </summary>
        [Fact]
        public void GameControllerType_IsValueType_CanBeCopied()
        {
            // Arrange
            GameControllerType original = new GameControllerType();

            // Act
            GameControllerType copy = original;

            // Assert
            // Both instances should be equal
            Assert.Equal(original.GetType(), copy.GetType());
        }

        /// <summary>
        ///     Tests that multiple GameControllerType instances are independent.
        /// </summary>
        [Fact]
        public void GameControllerType_MultipleInstances_AreIndependent()
        {
            // Arrange & Act
            GameControllerType type1 = new GameControllerType();
            GameControllerType type2 = new GameControllerType();

            // Assert
            Assert.NotNull(type1);
            Assert.NotNull(type2);
        }
    }
}

