// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSettingStructTest.cs
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

using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.Systems.Configuration.General;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The general setting struct test class
    /// </summary>
    public class GeneralSettingStructTest
    {
        /// <summary>
        /// Tests that default values should be correct
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            GeneralSetting setting = new GeneralSetting();
            Assert.False(setting.Debug);
            Assert.Equal("Default Name", setting.Name);
            Assert.Equal("Default Description", setting.Description);
            Assert.Equal("0.0.0", setting.Version);
            Assert.Equal("Pablo Perdomo Falcón", setting.Author);
            Assert.Equal("GPL-3.0 license", setting.License);
            Assert.Equal("app.ico", setting.Icon);
        }

        /// <summary>
        /// Tests that custom constructor should store values
        /// </summary>
        [Fact]
        public void CustomConstructor_ShouldStoreValues()
        {
            GeneralSetting setting = new GeneralSetting(true, "Test", "Desc", "1.0", "Author", "MIT", "icon.png");
            Assert.True(setting.Debug);
            Assert.Equal("Test", setting.Name);
            Assert.Equal("Desc", setting.Description);
            Assert.Equal("1.0", setting.Version);
            Assert.Equal("Author", setting.Author);
            Assert.Equal("MIT", setting.License);
            Assert.Equal("icon.png", setting.Icon);
        }

        /// <summary>
        /// Tests that should implement i general setting
        /// </summary>
        [Fact]
        public void ShouldImplementIGeneralSetting()
        {
            GeneralSetting setting = new GeneralSetting();
            Assert.IsAssignableFrom<IGeneralSetting>(setting);
        }

        /// <summary>
        /// Tests that GetSerializableProperties returns all 7 properties
        /// </summary>
        [Fact]
        public void GetSerializableProperties_ShouldReturnAllProperties()
        {
            GeneralSetting setting = new GeneralSetting(true, "TestName", "TestDesc", "2.0", "TestAuthor", "MIT", "test.ico");
            IJsonSerializable serializable = setting;

            List<(string PropertyName, string Value)> properties = serializable.GetSerializableProperties().ToList();

            Assert.Contains(properties, p => p.PropertyName == "Debug" && p.Value == "True");
            Assert.Contains(properties, p => p.PropertyName == "Name" && p.Value == "TestName");
            Assert.Contains(properties, p => p.PropertyName == "Description" && p.Value == "TestDesc");
            Assert.Contains(properties, p => p.PropertyName == "Version" && p.Value == "2.0");
            Assert.Contains(properties, p => p.PropertyName == "Author" && p.Value == "TestAuthor");
            Assert.Contains(properties, p => p.PropertyName == "License" && p.Value == "MIT");
            Assert.Contains(properties, p => p.PropertyName == "Icon" && p.Value == "test.ico");
            Assert.Equal(7, properties.Count);
        }

        /// <summary>
        /// Tests that GetSerializableProperties returns default values
        /// </summary>
        [Fact]
        public void GetSerializableProperties_WithDefaults_ShouldReturnDefaultValues()
        {
            GeneralSetting setting = new GeneralSetting();
            IJsonSerializable serializable = setting;

            List<(string PropertyName, string Value)> properties = serializable.GetSerializableProperties().ToList();

            Assert.Contains(properties, p => p.PropertyName == "Debug" && p.Value == "False");
            Assert.Contains(properties, p => p.PropertyName == "Name" && p.Value == "Default Name");
            Assert.Contains(properties, p => p.PropertyName == "Description" && p.Value == "Default Description");
            Assert.Contains(properties, p => p.PropertyName == "Version" && p.Value == "0.0.0");
            Assert.Contains(properties, p => p.PropertyName == "Author" && p.Value == "Pablo Perdomo Falcón");
            Assert.Contains(properties, p => p.PropertyName == "License" && p.Value == "GPL-3.0 license");
            Assert.Contains(properties, p => p.PropertyName == "Icon" && p.Value == "app.ico");
            Assert.Equal(7, properties.Count);
        }

        /// <summary>
        /// Tests that CreateFromProperties creates instance with all provided values
        /// </summary>
        [Fact]
        public void CreateFromProperties_WithAllValues_ShouldCreatePopulatedInstance()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                { "Debug", "true" },
                { "Name", "CustomName" },
                { "Description", "CustomDesc" },
                { "Version", "3.0.0" },
                { "Author", "CustomAuthor" },
                { "License", "Apache-2.0" },
                { "Icon", "custom.ico" }
            };

            IJsonDesSerializable<GeneralSetting> deserializable = new GeneralSetting();
            GeneralSetting result = deserializable.CreateFromProperties(properties);

            Assert.True(result.Debug);
            Assert.Equal("CustomName", result.Name);
            Assert.Equal("CustomDesc", result.Description);
            Assert.Equal("3.0.0", result.Version);
            Assert.Equal("CustomAuthor", result.Author);
            Assert.Equal("Apache-2.0", result.License);
            Assert.Equal("custom.ico", result.Icon);
        }

        /// <summary>
        /// Tests that CreateFromProperties uses fallback defaults for missing values
        /// </summary>
        [Fact]
        public void CreateFromProperties_WithMissingValues_ShouldUseDefaults()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            IJsonDesSerializable<GeneralSetting> deserializable = new GeneralSetting();
            GeneralSetting result = deserializable.CreateFromProperties(properties);

            Assert.False(result.Debug);
            Assert.Equal("Default Name", result.Name);
            Assert.Equal("Default Description", result.Description);
            Assert.Equal("0.0.0", result.Version);
            Assert.Equal("Pablo Perdomo Falcón", result.Author);
            Assert.Equal("GPL-3.0 license", result.License);
            Assert.Equal("app.jpeg", result.Icon);
        }

        /// <summary>
        /// Tests that CreateFromProperties treats invalid Debug value as false
        /// </summary>
        [Fact]
        public void CreateFromProperties_WithInvalidDebug_ShouldTreatAsFalse()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                { "Debug", "not-a-bool" }
            };

            IJsonDesSerializable<GeneralSetting> deserializable = new GeneralSetting();
            GeneralSetting result = deserializable.CreateFromProperties(properties);

            Assert.False(result.Debug);
        }

        /// <summary>
        /// Tests that CreateFromProperties with partial values uses fallbacks for missing
        /// </summary>
        [Fact]
        public void CreateFromProperties_WithPartialValues_ShouldUseFallbacks()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                { "Name", "OnlyName" },
                { "Version", "99.9.9" }
            };

            IJsonDesSerializable<GeneralSetting> deserializable = new GeneralSetting();
            GeneralSetting result = deserializable.CreateFromProperties(properties);

            Assert.False(result.Debug);
            Assert.Equal("OnlyName", result.Name);
            Assert.Equal("Default Description", result.Description);
            Assert.Equal("99.9.9", result.Version);
            Assert.Equal("Pablo Perdomo Falcón", result.Author);
            Assert.Equal("GPL-3.0 license", result.License);
            Assert.Equal("app.jpeg", result.Icon);
        }
    }
}
