// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DefaultTest.cs
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
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Time;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for configuration settings and scene map behavior
    /// </summary>
    public class ConfigurationAndScenesTest
    {
        /// <summary>
        ///     Tests that GeneralSetting initializes with expected default values
        /// </summary>
        [Fact]
        public void GeneralSetting_DefaultConstructor_ShouldUseExpectedDefaults()
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
        ///     Tests that GeneralSetting serializes all expected properties
        /// </summary>
        [Fact]
        public void GeneralSetting_GetSerializableProperties_ShouldIncludeAllValues()
        {
            GeneralSetting setting = new GeneralSetting(
                true,
                "Game",
                "Description",
                "1.2.3",
                "Author",
                "MIT",
                "icon.png");

            Dictionary<string, string> properties = ((IJsonSerializable) setting)
                .GetSerializableProperties()
                .ToDictionary(p => p.PropertyName, p => p.Value);

            Assert.Equal("True", properties[nameof(GeneralSetting.Debug)]);
            Assert.Equal("Game", properties[nameof(GeneralSetting.Name)]);
            Assert.Equal("Description", properties[nameof(GeneralSetting.Description)]);
            Assert.Equal("1.2.3", properties[nameof(GeneralSetting.Version)]);
            Assert.Equal("Author", properties[nameof(GeneralSetting.Author)]);
            Assert.Equal("MIT", properties[nameof(GeneralSetting.License)]);
            Assert.Equal("icon.png", properties[nameof(GeneralSetting.Icon)]);
        }

        /// <summary>
        ///     Tests that GeneralSetting can be created from a property dictionary
        /// </summary>
        [Fact]
        public void GeneralSetting_CreateFromProperties_ShouldMapProvidedValues()
        {
            Dictionary<string, string> source = new Dictionary<string, string>
            {
                {nameof(GeneralSetting.Debug), "true"},
                {nameof(GeneralSetting.Name), "Demo"},
                {nameof(GeneralSetting.Description), "Demo Desc"},
                {nameof(GeneralSetting.Version), "2.0.0"},
                {nameof(GeneralSetting.Author), "Alice"},
                {nameof(GeneralSetting.License), "Apache-2.0"},
                {nameof(GeneralSetting.Icon), "demo.ico"}
            };

            GeneralSetting setting = ((IJsonDesSerializable<GeneralSetting>) new GeneralSetting())
                .CreateFromProperties(source);

            Assert.True(setting.Debug);
            Assert.Equal("Demo", setting.Name);
            Assert.Equal("Demo Desc", setting.Description);
            Assert.Equal("2.0.0", setting.Version);
            Assert.Equal("Alice", setting.Author);
            Assert.Equal("Apache-2.0", setting.License);
            Assert.Equal("demo.ico", setting.Icon);
        }

        /// <summary>
        ///     Tests that missing icon in deserialization uses the current fallback value
        /// </summary>
        [Fact]
        public void GeneralSetting_CreateFromProperties_WithoutIcon_ShouldUseCurrentFallback()
        {
            Dictionary<string, string> source = new Dictionary<string, string>();

            GeneralSetting setting = ((IJsonDesSerializable<GeneralSetting>) new GeneralSetting())
                .CreateFromProperties(source);

            Assert.Equal("app.jpeg", setting.Icon);
        }

        /// <summary>
        ///     Tests that TimeSetting default constructor sets expected values
        /// </summary>
        [Fact]
        public void TimeSetting_DefaultConstructor_ShouldSetExpectedValues()
        {
            TimeSetting setting = new TimeSetting();

            Assert.Equal(0.016f, setting.FixedTimeStep);
            Assert.Equal(0.25f, setting.MaximumAllowedTimeStep);
            Assert.Equal(1.0f, setting.TimeScale);
        }

        /// <summary>
        ///     Tests that TimeSetting stores custom constructor values
        /// </summary>
        [Fact]
        public void TimeSetting_CustomConstructor_ShouldStoreProvidedValues()
        {
            TimeSetting setting = new TimeSetting(0.02f, 0.5f, 2.0f);

            Assert.Equal(0.02f, setting.FixedTimeStep);
            Assert.Equal(0.5f, setting.MaximumAllowedTimeStep);
            Assert.Equal(2.0f, setting.TimeScale);
        }

        /// <summary>
        ///     Tests that NetworkSetting default constructor sets expected values
        /// </summary>
        [Fact]
        public void NetworkSetting_DefaultConstructor_ShouldSetExpectedValues()
        {
            NetworkSetting setting = new NetworkSetting();

            Assert.Equal(8080, setting.Port);
            Assert.Equal("127.0.0.1", setting.Ip);
            Assert.Equal("localhost", setting.Host);
            Assert.Equal("http", setting.Protocol);
        }

        /// <summary>
        ///     Tests that NetworkSetting stores custom constructor values
        /// </summary>
        [Fact]
        public void NetworkSetting_CustomConstructor_ShouldStoreProvidedValues()
        {
            NetworkSetting setting = new NetworkSetting(9000, "10.0.0.7", "demo.local", "https");

            Assert.Equal(9000, setting.Port);
            Assert.Equal("10.0.0.7", setting.Ip);
            Assert.Equal("demo.local", setting.Host);
            Assert.Equal("https", setting.Protocol);
        }

        /// <summary>
        ///     Tests that ScenesMap supports add, remove and clear operations
        /// </summary>
        [Fact]
        public void ScenesMap_AddRemoveClear_ShouldMutateSceneCollection()
        {
            ScenesMap map = new ScenesMap();

            map.AddScene(1);
            map.AddScene(2);
            map.RemoveScene(1);

            Assert.Single(map.Scenes);
            Assert.Equal(2, map.Scenes[0]);

            map.Clear();

            Assert.Empty(map.Scenes);
        }

        /// <summary>
        ///     Tests that Load returns a new empty map and Save is a no-op
        /// </summary>
        [Fact]
        public void ScenesMap_LoadAndSave_CurrentImplementation_ShouldBeSafe()
        {
            ScenesMap map = new ScenesMap();
            map.AddScene(99);

            ScenesMap loaded = ScenesMap.Load();

            Assert.NotNull(loaded);
            Assert.NotSame(map, loaded);
            Assert.Empty(loaded.Scenes);

            map.Save();
        }
    }
}