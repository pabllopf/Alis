// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesMiniMapLocationTest.cs
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

using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImNodesMiniMapLocation" /> enum values.
    /// </summary>
    public class ImNodesMiniMapLocationTest
    {
        /// <summary>
        ///     Verifies that BottomLeft is zero.
        /// </summary>
        [RequireCImguiSystemFact]
        public void BottomLeft_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImNodesMiniMapLocation.BottomLeft);
        }

        /// <summary>
        ///     Verifies that locations use distinct values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Locations_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImNodesMiniMapLocation.BottomLeft, (int) ImNodesMiniMapLocation.BottomRight);
            Assert.NotEqual((int) ImNodesMiniMapLocation.TopLeft, (int) ImNodesMiniMapLocation.TopRight);
        }
    }
}
