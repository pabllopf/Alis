// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingsBuilderTest.cs
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

using System;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders;
using Alis.Core.Ecs.Systems.Configuration;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The settings builder test class
    /// </summary>
    public class SettingsBuilderTest
    {
        /// <summary>
        /// Tests that constructor no args creates builder
        /// </summary>
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns setting instance
        /// </summary>
        [Fact]
        public void Build_ReturnsSettingInstance()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting result = builder.Build();
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that audio with config returns builder
        /// </summary>
        [Fact]
        public void Audio_WithConfig_ReturnsBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();
            SettingsBuilder result = builder.Audio(a => a.Volume(50).IsMute(false));
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that general with config returns builder
        /// </summary>
        [Fact]
        public void General_WithConfig_ReturnsBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();
            SettingsBuilder result = builder.General(g => g.Name("App").Version("1.0"));
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that graphic with config returns builder
        /// </summary>
        [Fact]
        public void Graphic_WithConfig_ReturnsBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();
            SettingsBuilder result = builder.Graphic(g => g.Target("OpenGL").Resolution(800, 600));
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that input with config returns builder
        /// </summary>
        [Fact]
        public void Input_WithConfig_ReturnsBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();
            SettingsBuilder result = builder.Input(i => i.MouseSensitivity(1.5f));
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that network with config returns builder
        /// </summary>
        [Fact]
        public void Network_WithConfig_ReturnsBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();
            SettingsBuilder result = builder.Network(n => n.Ip("127.0.0.1"));
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that physic with config returns builder
        /// </summary>
        [Fact]
        public void Physic_WithConfig_ReturnsBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();
            SettingsBuilder result = builder.Physic(p => p.Gravity(0, -9.81f));
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all settings creates setting
        /// </summary>
        [Fact]
        public void ChainingAllSettings_CreatesSetting()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting result = builder
                .Audio(a => a.Volume(80).IsMute(false))
                .General(g => g.Name("Game").Version("1.0"))
                .Graphic(g => g.Target("Vulkan").Resolution(1920, 1080))
                .Input(i => i.MouseSensitivity(2.0f))
                .Network(n => n.Ip("localhost"))
                .Physic(p => p.Gravity(0, -9.81f).Debug(true))
                .Build();
            Assert.NotNull(result);
        }
    }
}
