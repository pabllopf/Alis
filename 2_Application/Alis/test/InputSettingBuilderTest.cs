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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="InputSettingBuilder" /> class.
    /// </summary>
    public class InputSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns an InputSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsInputSettingInstance()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            InputSetting setting = builder.Build();

            Assert.IsType<InputSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null InputSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullInputSetting()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            InputSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            Assert.IsAssignableFrom<IBuild<InputSetting>>(builder);
        }

        /// <summary>
        ///     Tests that the default sensitivity is 1.0f when Build is called without setting.
        /// </summary>
        [Fact]
        public void DefaultBuildReturnsDefaultSensitivity()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            InputSetting setting = builder.Build();

            Assert.Equal(1.0f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that MouseSensitivity can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void MouseSensitivityCanBeSetViaBuilder()
        {
            InputSettingBuilder builder = new InputSettingBuilder();
            const float expectedSensitivity = 2.5f;

            InputSetting setting = builder.MouseSensitivity(expectedSensitivity).Build();

            Assert.Equal(expectedSensitivity, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that MouseSensitivity can be set to zero via the builder.
        /// </summary>
        [Fact]
        public void MouseSensitivityCanBeSetToZero()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            InputSetting setting = builder.MouseSensitivity(0.0f).Build();

            Assert.Equal(0.0f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that MouseSensitivity can be set to a negative value via the builder.
        /// </summary>
        [Fact]
        public void MouseSensitivityCanBeSetToNegativeValue()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            InputSetting setting = builder.MouseSensitivity(-1.0f).Build();

            Assert.Equal(-1.0f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that MouseSensitivity can be set to a large value via the builder.
        /// </summary>
        [Fact]
        public void MouseSensitivityCanBeSetToLargeValue()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            InputSetting setting = builder.MouseSensitivity(float.MaxValue).Build();

            Assert.Equal(float.MaxValue, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that MouseSensitivity can be set to a small value via the builder.
        /// </summary>
        [Fact]
        public void MouseSensitivityCanBeSetToSmallestValue()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            InputSetting setting = builder.MouseSensitivity(float.Epsilon).Build();

            Assert.Equal(float.Epsilon, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that the builder returns itself from fluent method for chaining.
        /// </summary>
        [Fact]
        public void BuilderReturnsItselfFromFluentMethod()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            InputSettingBuilder result = builder.MouseSensitivity(2.0f);

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that MouseSensitivity can be changed between Build calls independently.
        /// </summary>
        [Fact]
        public void SensitivityCanBeChangedBetweenBuildCalls()
        {
            InputSettingBuilder builder = new InputSettingBuilder();

            builder.MouseSensitivity(5.0f);
            InputSetting first = builder.Build();

            builder.MouseSensitivity(10.0f);
            InputSetting second = builder.Build();

            Assert.Equal(5.0f, first.MouseSensitivity);
            Assert.Equal(10.0f, second.MouseSensitivity);
        }
    }
}
