// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OperationTest.cs
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

using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    ///     Provides unit coverage for <see cref="Operations" /> flag composition.
    /// </summary>
    public class OperationTest
    {
        /// <summary>
        ///     Verifies that translate is the composition of X, Y and Z translate flags.
        /// </summary>
        [Fact]
        public void Translate_ShouldCombineTranslateAxes()
        {
            Operations expected = Operations.TranslateX | Operations.TranslateY | Operations.TranslateZ;

            Assert.Equal(expected, Operations.Translate);
        }

        /// <summary>
        ///     Verifies that rotate is the composition of all rotate flags.
        /// </summary>
        [Fact]
        public void Rotate_ShouldCombineRotateAxes()
        {
            Operations expected = Operations.RotateX | Operations.RotateY | Operations.RotateZ | Operations.RotateScreen;

            Assert.Equal(expected, Operations.Rotate);
        }

        /// <summary>
        ///     Verifies that scale is the composition of all scale flags.
        /// </summary>
        [Fact]
        public void Scale_ShouldCombineScaleAxes()
        {
            Operations expected = Operations.ScaleX | Operations.ScaleY | Operations.ScaleZ;

            Assert.Equal(expected, Operations.Scale);
        }
    }
}