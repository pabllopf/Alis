// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicSettingTest.cs
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

using Alis.Builder.Core.EcsOld.System.Setting.Graphic;
using Alis.Core.EcsOld.System.Configuration.Graphic;
using Xunit;

namespace Alis.Test.Core.EcsOld.System.Configuration.Graphic
{
    /// <summary>
    ///     The graphic setting test class
    /// </summary>
    public class GraphicSettingTest
    {
        /// <summary>
        ///     Tests that test graphic setting builder
        /// </summary>
        [Fact]
        public void Test_GraphicSetting_Builder()
        {
            // Arrange
            GraphicSetting graphicSetting = new GraphicSetting();

            // Act
            GraphicSettingBuilder result = graphicSetting.Builder();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GraphicSettingBuilder>(result);
        }
    }
}