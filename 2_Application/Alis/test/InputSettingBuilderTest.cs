// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputSettingBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Input;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The input setting builder test class
    /// </summary>
    public class InputSettingBuilderTest
    {
        /// <summary>
        /// Tests that constructor no args creates builder
        /// </summary>
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns input setting instance
        /// </summary>
        [Fact]
        public void Build_ReturnsInputSettingInstance()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            InputSetting result = builder.Build();
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that mouse sensitivity sets value returns builder
        /// </summary>
        [Fact]
        public void MouseSensitivity_SetsValue_ReturnsBuilder()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            InputSettingBuilder result = builder.MouseSensitivity(2.5f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all properties creates input setting
        /// </summary>
        [Fact]
        public void ChainingAllProperties_CreatesInputSetting()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            InputSetting result = builder.MouseSensitivity(1.5f).Build();
            Assert.NotNull(result);
        }
    }
}
