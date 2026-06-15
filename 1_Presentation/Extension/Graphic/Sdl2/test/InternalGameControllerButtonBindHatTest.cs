// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalGameControllerButtonBindHatTest.cs
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

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal game controller button bind hat test class
    /// </summary>
    public class InternalGameControllerButtonBindHatTest
    {
        /// <summary>
        /// Tests that internal game controller button bind hat default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalGameControllerButtonBindHat_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalGameControllerButtonBindHat hat = new InternalGameControllerButtonBindHat();

            Assert.Equal(0, hat.Hat);
            Assert.Equal(0, hat.HatMask);
        }

        /// <summary>
        /// Tests that internal game controller button bind hat set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalGameControllerButtonBindHat_SetProperties_StoresValuesCorrectly()
        {
            InternalGameControllerButtonBindHat hat = new InternalGameControllerButtonBindHat
            {
                Hat = 1,
                HatMask = 2
            };

            Assert.Equal(1, hat.Hat);
            Assert.Equal(2, hat.HatMask);
        }

        /// <summary>
        /// Tests that internal game controller button bind hat is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalGameControllerButtonBindHat_IsValueType_CopyIsIndependent()
        {
            InternalGameControllerButtonBindHat original = new InternalGameControllerButtonBindHat { Hat = 5 };
            InternalGameControllerButtonBindHat copy = original;

            copy.Hat = 10;

            Assert.Equal(5, original.Hat);
            Assert.Equal(10, copy.Hat);
        }
    }
}
