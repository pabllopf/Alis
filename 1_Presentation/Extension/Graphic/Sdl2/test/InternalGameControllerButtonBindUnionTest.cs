// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalGameControllerButtonBindUnionTest.cs
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
    /// The internal game controller button bind union test class
    /// </summary>
    public class InternalGameControllerButtonBindUnionTest
    {
        /// <summary>
        /// Tests that internal game controller button bind union default initialization fields have default values
        /// </summary>
        [Fact]
        public void InternalGameControllerButtonBindUnion_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalGameControllerButtonBindUnion u = new InternalGameControllerButtonBindUnion();

            Assert.Equal(0, u.button);
            Assert.Equal(0, u.axis);
            Assert.Equal(0, u.hat.Hat);
            Assert.Equal(0, u.hat.HatMask);
        }

        /// <summary>
        /// Tests that internal game controller button bind union is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalGameControllerButtonBindUnion_IsValueType_CopyIsIndependent()
        {
            InternalGameControllerButtonBindUnion original = new InternalGameControllerButtonBindUnion();
            InternalGameControllerButtonBindUnion copy = original;

            Assert.Equal(original.button, copy.button);
            Assert.Equal(original.axis, copy.axis);
        }
    }
}
