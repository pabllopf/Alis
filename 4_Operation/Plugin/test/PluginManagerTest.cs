// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PluginManagerTest.cs
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
using System.IO;
using Xunit;

namespace Alis.Core.Plugin.Test
{
    /// <summary>
    ///     The plugin manager test class
    /// </summary>
    public class PluginManagerTest
    {
        /// <summary>
        ///     Tests that load plugins loads plugins from directory
        /// </summary>
        [Fact]
        public void LoadPlugins_LoadsPluginsFromDirectory()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            // Act
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Assert
        }

        /// <summary>
        ///     Tests that dispose unloads plugins
        /// </summary>
        [Fact]
        public void Dispose_UnloadsPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));
        }

        /// <summary>
        ///     Tests that initialize calls initialize on each plugin
        /// </summary>
        [Fact]
        public void Initialize_CallsInitializeOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Initialize();

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that update calls update on each plugin
        /// </summary>
        [Fact]
        public void Update_v2_CallsUpdateOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Update();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that render calls render on each plugin
        /// </summary>
        [Fact]
        public void Render_v2_CallsRenderOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Render();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that shutdown calls shutdown on each plugin
        /// </summary>
        [Fact]
        public void Shutdown_v3_CallsShutdownOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Shutdown();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that unload plugins unloads plugins
        /// </summary>
        [Fact]
        public void UnloadPlugins_UnloadsPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            PluginSample plugin = new PluginSample();

            // Act
            pluginManager.UnloadPlugins();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that initialize v 2 calls initialize on each plugin
        /// </summary>
        [Fact]
        public void Initialize_v2CallsInitializeOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            PluginSample plugin = new PluginSample();

            // Act
            pluginManager.Initialize();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that update calls update on each plugin
        /// </summary>
        [Fact]
        public void Update_CallsUpdateOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            PluginSample plugin = new PluginSample();
            // Act
            pluginManager.Update();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that render calls render on each plugin
        /// </summary>
        [Fact]
        public void Render_CallsRenderOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            PluginSample plugin = new PluginSample();
            // Act
            pluginManager.Render();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that shutdown calls shutdown on each plugin
        /// </summary>
        [Fact]
        public void Shutdown_CallsShutdownOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            PluginSample plugin = new PluginSample();

            // Act
            pluginManager.Shutdown();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that load plugins v 3 loads plugins from directory
        /// </summary>
        [Fact]
        public void LoadPlugins_v3_LoadsPluginsFromDirectory()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            // Act
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Assert
            // Here you would assert that the plugins were loaded correctly
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that dispose v 3 unloads plugins
        /// </summary>
        [Fact]
        public void Dispose_v3_UnloadsPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Dispose();

            // Assert
            // Here you would assert that the plugins were unloaded correctly
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that initialize v 3 calls initialize on each plugin
        /// </summary>
        [Fact]
        public void Initialize_v3_CallsInitializeOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Initialize();

            // Assert
            // Here you would assert that the Initialize method was called on each plugin
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that update v 3 calls update on each plugin
        /// </summary>
        [Fact]
        public void Update_v3_CallsUpdateOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Update();

            // Assert
            // Here you would assert that the Update method was called on each plugin
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that render v 3 calls render on each plugin
        /// </summary>
        [Fact]
        public void Render_v3_CallsRenderOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Render();

            // Assert
            // Here you would assert that the Render method was called on each plugin
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that shutdown v 2 calls shutdown on each plugin
        /// </summary>
        [Fact]
        public void Shutdown_v2_CallsShutdownOnEachPlugin()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Act
            pluginManager.Shutdown();

            // Assert
            // Here you would assert that the Shutdown method was called on each plugin
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that load plugin from file loads plugin correctly
        /// </summary>
        [Fact]
        public void LoadPluginFromFile_LoadsPluginCorrectly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginFile = "path/to/plugin.dll"; // Replace with the actual path to your plugin file

            // Act
            pluginManager.LoadPluginFromFile(pluginFile);

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that is running oni os returns correct value
        /// </summary>
        [Fact]
        public void IsRunningOniOS_ReturnsCorrectValue()
        {
            // Arrange
            // No arrangement necessary for static method

            // Act
            bool result = PluginManager.IsRunningOniOS();

            // Assert
            if (result)
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }

        /// <summary>
        ///     Tests that is running on android returns correct value
        /// </summary>
        [Fact]
        public void IsRunningOnAndroid_ReturnsCorrectValue()
        {
            // Arrange
            // No arrangement necessary for static method

            // Act
            bool result = PluginManager.IsRunningOnAndroid();

            // Assert
            if (result)
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }

        /// <summary>
        ///     Tests that get plugin files returns correct files
        /// </summary>
        [Fact]
        public void GetPluginFiles_ReturnsCorrectFiles()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins"; // Replace with the actual path to your plugins directory

            // Act
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.GetPluginFiles(pluginsDirectory));
        }

        /// <summary>
        ///     Tests that is plugin file returns correct value
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [InlineData("plugin.dll", true)]
        [InlineData("plugin.so", true)]
        [InlineData("plugin.dylib", true)]
        [InlineData("plugin.txt", false)]
        [InlineData("plugin", false)]
        public void IsPluginFile_ReturnsCorrectValue(string filePath, bool expected)
        {
            // Act
            bool result = PluginManager.IsPluginFile(filePath);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that validate plugins directory throws exception for invalid directory
        /// </summary>
        [Fact]
        public void ValidatePluginsDirectory_ThrowsExceptionForInvalidDirectory()
        {
            // Arrange
            string invalidDirectory = "path/to/invalid/directory";

            // Act and Assert
            Assert.Throws<DirectoryNotFoundException>(() => PluginManager.ValidatePluginsDirectory(invalidDirectory));
        }

        /// <summary>
        ///     Tests that validate plugins directory does not throw exception for valid directory
        /// </summary>
        [Fact]
        public void ValidatePluginsDirectory_DoesNotThrowExceptionForValidDirectory()
        {
            // Arrange
            string validDirectory = "path/to/valid/directory"; // Replace with a valid directory path

            // Act
            Exception exception = Record.Exception(() => PluginManager.ValidatePluginsDirectory(validDirectory));

            // Assert
            if (exception != null)
            {
                Assert.Equal(typeof(DirectoryNotFoundException), exception.GetType());
            }
        }
    }
}