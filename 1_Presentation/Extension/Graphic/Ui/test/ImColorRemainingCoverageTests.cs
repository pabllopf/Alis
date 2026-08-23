// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImColorRemainingCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im color remaining coverage tests class
    /// </summary>
    public class ImColorRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that value property round trips
        /// </summary>
         [RequireCImguiSystemFact]
        public void Value_Property_RoundTrips()
        {
            ImColor color = new ImColor();

            color.Value = new Vector4F(0.5f, 0.25f, 0.75f, 1.0f);

            Assert.Equal(0.5f, color.Value.X);
            Assert.Equal(0.25f, color.Value.Y);
            Assert.Equal(0.75f, color.Value.Z);
            Assert.Equal(1.0f, color.Value.W);
        }

        /// <summary>
        ///     Tests that default value is zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultValue_IsZero()
        {
            ImColor color = new ImColor();

            Assert.Equal(0f, color.Value.X);
            Assert.Equal(0f, color.Value.Y);
            Assert.Equal(0f, color.Value.Z);
            Assert.Equal(0f, color.Value.W);
        }
    }
}
