// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalSdlGameControllerButtonBindTest.cs
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
    /// The internal sdl game controller button bind test class
    /// </summary>
    public class InternalSdlGameControllerButtonBindTest
    {
        /// <summary>
        /// Tests that internal sdl game controller button bind default initialization fields have default values
        /// </summary>
        [Fact]
        public void InternalSdlGameControllerButtonBind_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalSdlGameControllerButtonBind bind = new InternalSdlGameControllerButtonBind();

            Assert.Equal(0, bind.bindType);
            Assert.Equal(0, bind.unionVal0);
            Assert.Equal(0, bind.unionVal1);
        }

        /// <summary>
        /// Tests that internal sdl game controller button bind is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalSdlGameControllerButtonBind_IsValueType_CopyIsIndependent()
        {
            InternalSdlGameControllerButtonBind original = new InternalSdlGameControllerButtonBind();
            InternalSdlGameControllerButtonBind copy = original;

            Assert.Equal(original.bindType, copy.bindType);
            Assert.Equal(original.unionVal0, copy.unionVal0);
            Assert.Equal(original.unionVal1, copy.unionVal1);
        }
    }
}
