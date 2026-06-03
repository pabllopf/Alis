// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSettingBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.General;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.General;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="GeneralSettingBuilder" /> class.
    /// </summary>
    public class GeneralSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a GeneralSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsGeneralSettingInstance()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSetting setting = builder.Build();

            Assert.NotNull(setting);
            Assert.IsType<GeneralSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null GeneralSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullGeneralSetting()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            Assert.IsAssignableFrom<IBuild<GeneralSetting>>(builder);
        }

        /// <summary>
        ///     Tests that Name can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void NameCanBeSetViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            const string expectedName = "MyGame";

            GeneralSetting setting = builder.Name(expectedName).Build();

            Assert.Equal(expectedName, setting.Name);
        }

        /// <summary>
        ///     Tests that Description can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void DescriptionCanBeSetViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            const string expectedDescription = "A test game description";

            GeneralSetting setting = builder.Description(expectedDescription).Build();

            Assert.Equal(expectedDescription, setting.Description);
        }

        /// <summary>
        ///     Tests that Version can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void VersionCanBeSetViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            const string expectedVersion = "1.2.3";

            GeneralSetting setting = builder.Version(expectedVersion).Build();

            Assert.Equal(expectedVersion, setting.Version);
        }

        /// <summary>
        ///     Tests that Author can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void AuthorCanBeSetViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            const string expectedAuthor = "Test Author";

            GeneralSetting setting = builder.Author(expectedAuthor).Build();

            Assert.Equal(expectedAuthor, setting.Author);
        }

        /// <summary>
        ///     Tests that License can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void LicenseCanBeSetViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            const string expectedLicense = "MIT";

            GeneralSetting setting = builder.License(expectedLicense).Build();

            Assert.Equal(expectedLicense, setting.License);
        }

        /// <summary>
        ///     Tests that Icon can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void IconCanBeSetViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            const string expectedIcon = "custom.ico";

            GeneralSetting setting = builder.Icon(expectedIcon).Build();

            Assert.Equal(expectedIcon, setting.Icon);
        }

        /// <summary>
        ///     Tests that Debug can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void DebugCanBeSetViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            GeneralSetting setting = builder.Debug(true).Build();

            Assert.True(setting.Debug);
        }

        /// <summary>
        ///     Tests that Debug can be set to false via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void DebugCanBeSetToFalseViaBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            GeneralSetting setting = builder.Debug(false).Build();

            Assert.False(setting.Debug);
        }

        /// <summary>
        ///     Tests that all properties can be set via fluent chaining and are reflected in the built result.
        /// </summary>
        [Fact]
        public void AllPropertiesCanBeSetViaFluentChaining()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            GeneralSetting setting = builder
                .Name("FluentGame")
                .Description("A game built with fluent API")
                .Version("2.0.0")
                .Author("Dev Team")
                .License("Apache 2.0")
                .Icon("icon.png")
                .Debug(true)
                .Build();

            Assert.Equal("FluentGame", setting.Name);
            Assert.Equal("A game built with fluent API", setting.Description);
            Assert.Equal("2.0.0", setting.Version);
            Assert.Equal("Dev Team", setting.Author);
            Assert.Equal("Apache 2.0", setting.License);
            Assert.Equal("icon.png", setting.Icon);
            Assert.True(setting.Debug);
        }

        /// <summary>
        ///     Tests that the builder returns itself from fluent methods for chaining.
        /// </summary>
        [Fact]
        public void BuilderReturnsItselfFromFluentMethods()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            GeneralSettingBuilder result = builder.Name("Test");

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that Name with null value can be set via the builder.
        /// </summary>
        [Fact]
        public void NameCanBeSetToNull()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            GeneralSetting setting = builder.Name(null).Build();

            Assert.Null(setting.Name);
        }

        /// <summary>
        ///     Tests that Name with empty string can be set via the builder.
        /// </summary>
        [Fact]
        public void NameCanBeSetToEmptyString()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();

            GeneralSetting setting = builder.Name(string.Empty).Build();

            Assert.Equal(string.Empty, setting.Name);
        }
    }
}
