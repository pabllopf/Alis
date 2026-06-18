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
using Alis.Core.Ecs.Systems.Configuration.General;
using Xunit;

namespace Alis.Test
{
    public class GeneralSettingBuilderTest
    {
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            Assert.NotNull(builder);
        }

        [Fact]
        public void Build_ReturnsGeneralSettingInstance()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSetting result = builder.Build();
            Assert.NotNull(result);
        }

        [Fact]
        public void Name_SetsName_ReturnsBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSettingBuilder result = builder.Name("TestApp");
            Assert.Same(builder, result);
        }

        [Fact]
        public void Version_SetsVersion_ReturnsBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSettingBuilder result = builder.Version("1.0.0");
            Assert.Same(builder, result);
        }

        [Fact]
        public void Author_SetsAuthor_ReturnsBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSettingBuilder result = builder.Author("Pablo");
            Assert.Same(builder, result);
        }

        [Fact]
        public void Description_SetsDescription_ReturnsBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSettingBuilder result = builder.Description("A test app");
            Assert.Same(builder, result);
        }

        [Fact]
        public void License_SetsLicense_ReturnsBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSettingBuilder result = builder.License("MIT");
            Assert.Same(builder, result);
        }

        [Fact]
        public void Icon_SetsIcon_ReturnsBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSettingBuilder result = builder.Icon("icon.png");
            Assert.Same(builder, result);
        }

        [Fact]
        public void Debug_SetsDebug_ReturnsBuilder()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSettingBuilder result = builder.Debug(true);
            Assert.Same(builder, result);
        }

        [Fact]
        public void ChainingAllProperties_CreatesGeneralSetting()
        {
            GeneralSettingBuilder builder = new GeneralSettingBuilder();
            GeneralSetting result = builder
                .Name("App")
                .Version("1.0")
                .Author("Test")
                .Description("Desc")
                .License("MIT")
                .Icon("icon.png")
                .Debug(true)
                .Build();
            Assert.NotNull(result);
        }
    }
}
