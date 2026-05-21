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
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Audio;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.General;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Graphic;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Input;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Network;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Physic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Configuration;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ConfigurationBuilders
{
    /// <summary>
    ///     Contains unit tests for the <see cref="SettingsBuilder" /> class.
    /// </summary>
    public class SettingsBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a Setting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsSettingInstance()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting setting = builder.Build();

            Assert.NotNull(setting);
            Assert.IsType<Setting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null Setting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullSetting()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that settings can be configured via the builder.
        /// </summary>
        [Fact]
        public void SettingsCanBeConfiguredViaBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder creates a valid Setting object.
        /// </summary>
        [Fact]
        public void BuilderCreatesValidSettingObject()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Assert.IsAssignableFrom<IBuild<Setting>>(builder);
            Assert.IsAssignableFrom<IAudio<SettingsBuilder, Action<AudioSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IGeneral<SettingsBuilder, Action<GeneralSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IGraphic<SettingsBuilder, Action<GraphicSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IInput<SettingsBuilder, Action<InputSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<INetwork<SettingsBuilder, Action<NetworkSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IPhysic<SettingsBuilder, Action<PhysicSettingBuilder>>>(builder);
        }

        /// <summary>
        ///     Tests that the builder can be chained.
        /// </summary>
        [Fact]
        public void BuilderCanBeChained()
        {
            SettingsBuilder builder = new SettingsBuilder();

            SettingsBuilder result = builder
                .General(g => g.Name("TestGame"))
                .Audio(a => a.Volume(50))
                .Graphic(g => g.Target("High"))
                .Physic(p => p.Debug(false));

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that the builder default state is valid.
        /// </summary>
        [Fact]
        public void BuilderDefaultState_IsValid()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }
    }
}
