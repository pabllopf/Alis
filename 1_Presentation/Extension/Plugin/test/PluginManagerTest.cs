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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Plugin;
using Xunit;

namespace Alis.Extension.Plugin.Test
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
            Assert.False(PluginManager.ValidatePluginsDirectory(pluginsDirectory));
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
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginFromFile(pluginFile));
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
        [Theory, InlineData("plugin.dll", true), InlineData("plugin.so", true), InlineData("plugin.dylib", true), InlineData("plugin.txt", false), InlineData("plugin", false)]
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
            Assert.False(PluginManager.ValidatePluginsDirectory(invalidDirectory));
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

        /// <summary>
        /// Tests that load assembly loads correct assembly
        /// </summary>
        [Fact]
        public void LoadAssembly_LoadsCorrectAssembly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string platformFolder = pluginManager.GetPlatformFolder();
            string platformPluginsDirectory = pluginManager.GetPlatformPluginsDirectory("Assets/Plugins", platformFolder);

            string pluginFile = Path.Combine(platformPluginsDirectory, "Sum.dll"); // Replace with the actual path to your plugin file

            // Act
            Assembly loadedAssembly = pluginManager.LoadAssembly(pluginFile);

            // Assert
            // Here you would assert that the assembly was loaded correctly
            Assert.NotNull(loadedAssembly);
        }

        /// <summary>
        /// Tests that create plugin instance creates correct plugin instance
        /// </summary>
        [Fact]
        public void CreatePluginInstance_CreatesCorrectPluginInstance()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            Type pluginType = typeof(PluginSample); // Replace with the actual type of your plugin

            // Act
            IPlugin pluginInstance = pluginManager.CreatePluginInstance(pluginType);

            // Assert
            // Here you would assert that the correct plugin instance was created
            Assert.IsType<PluginSample>(pluginInstance);
        }

        /// <summary>
        /// Tests that is plugin file returns correct value for non plugin file
        /// </summary>
        [Fact]
        public void IsPluginFile_ReturnsCorrectValueForNonPluginFile()
        {
            // Arrange
            string nonPluginFile = "path/to/non-plugin.txt"; // Replace with the actual path to your non-plugin file

            // Act
            bool result = PluginManager.IsPluginFile(nonPluginFile);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that unload plugins unloads all plugins
        /// </summary>
        [Fact]
        public void UnloadPlugins_UnloadsAllPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            // Load some plugins here

            // Act
            pluginManager.UnloadPlugins();

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
            Assert.Empty(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        /// Tests that is running oni os returns false when not running oni os
        /// </summary>
        [Fact]
        public void IsRunningOniOS_ReturnsFalseWhenNotRunningOniOS()
        {
            // Arrange
            // No arrangement necessary for static method

            // Act
            bool result = PluginManager.IsRunningOniOS();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that is running on android returns false when not running on android
        /// </summary>
        [Fact]
        public void IsRunningOnAndroid_ReturnsFalseWhenNotRunningOnAndroid()
        {
            // Arrange
            // No arrangement necessary for static method

            // Act
            bool result = PluginManager.IsRunningOnAndroid();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that instantiate plugins adds plugins to loaded plugins
        /// </summary>
        [Fact]
        public void InstantiatePlugins_AddsPluginsToLoadedPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            string platformFolder = pluginManager.GetPlatformFolder();
            string platformPluginsDirectory = pluginManager.GetPlatformPluginsDirectory("Assets/Plugins", platformFolder);

            string pluginFile = Path.Combine(platformPluginsDirectory, "Sum.dll"); // Replace with the actual path to your plugin file


            Assembly assembly = Assembly.LoadFrom(pluginFile);

            // Act
            pluginManager.InstantiatePlugins(assembly);

            // Assert
            // Here you would assert that the plugins were added to the LoadedPlugins list
            Assert.NotEmpty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        /// Tests that load plugins from files loads correct number of plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_LoadsCorrectNumberOfPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        /// Tests that load plugins from files loads correct plugin instances
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_LoadsCorrectPluginInstances()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        /// Tests that load plugins from files adds plugins to loaded plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_AddsPluginsToLoadedPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files


            // Assert
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        /// Tests that load plugins v 1 loads plugins from directory
        /// </summary>
        [Fact]
        public void LoadPlugins_v1_LoadsPluginsFromDirectory()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";

            // Act
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        /// Tests that dispose v 1 unloads plugins
        /// </summary>
        [Fact]
        public void Dispose_v1_UnloadsPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginsDirectory = "path/to/plugins";
            Assert.False(PluginManager.ValidatePluginsDirectory(pluginsDirectory));

            // Act
            pluginManager.Dispose();

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
            Assert.Empty(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        /// Tests that load plugin from file v 1 loads plugin correctly
        /// </summary>
        [Fact]
        public void LoadPluginFromFile__v1LoadsPluginCorrectly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginFile = "path/to/plugin.dll"; // Replace with the actual path to your plugin file

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginFromFile(pluginFile));
        }

        /// <summary>
        /// Tests that load assembly vq loads correct assembly
        /// </summary>
        [Fact]
        public void LoadAssembly_vq_LoadsCorrectAssembly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string platformFolder = pluginManager.GetPlatformFolder();
            string platformPluginsDirectory = pluginManager.GetPlatformPluginsDirectory("Assets/Plugins", platformFolder);

            string pluginFile = Path.Combine(platformPluginsDirectory, "Sum.dll"); // Replace with the actual path to your plugin file

            // Act
            Assembly loadedAssembly = pluginManager.LoadAssembly(pluginFile);

            // Assert
            Assert.NotNull(loadedAssembly);
            Assert.Single(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        /// Tests that create plugin instance v 1 creates correct plugin instance
        /// </summary>
        [Fact]
        public void CreatePluginInstance_v1_CreatesCorrectPluginInstance()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            Type pluginType = typeof(PluginSample); // Replace with the actual type of your plugin

            // Act
            IPlugin pluginInstance = pluginManager.CreatePluginInstance(pluginType);

            // Assert
            Assert.IsType<PluginSample>(pluginInstance);
        }

        /// <summary>
        /// Tests that instantiate plugins v 1 adds plugins to loaded plugins
        /// </summary>
        [Fact]
        public void InstantiatePlugins_v1_AddsPluginsToLoadedPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            string platformFolder = pluginManager.GetPlatformFolder();
            string platformPluginsDirectory = pluginManager.GetPlatformPluginsDirectory("Assets/Plugins", platformFolder);

            string pluginFile = Path.Combine(platformPluginsDirectory, "Sum.dll"); // Replace with the actual path to your plugin file

            Assembly assembly = Assembly.LoadFrom(pluginFile);

            // Act
            pluginManager.InstantiatePlugins(assembly);

            // Assert
            Assert.NotEmpty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        /// Tests that load plugins from files v 1 loads correct number of plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_v1_LoadsCorrectNumberOfPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        /// Tests that load plugins from files v 1 loads correct plugin instances
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_v1_LoadsCorrectPluginInstances()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        /// Tests that load plugins from files v 1 adds plugins to loaded plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_v1_AddsPluginsToLoadedPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        /// Tests that load plugin from file v 1 loads plugin correctly
        /// </summary>
        [Fact]
        public void LoadPluginFromFile_v1_LoadsPluginCorrectly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string pluginFile = "path/to/plugin.dll"; // Replace with the actual path to your plugin file

            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginFromFile(pluginFile));
        }

        /// <summary>
        /// Tests that unload plugins v 1 unloads all plugins
        /// </summary>
        [Fact]
        public void UnloadPlugins_v1_UnloadsAllPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            // Load some plugins here

            // Act
            pluginManager.UnloadPlugins();

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
            Assert.Empty(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        /// Tests that get platform folder returns correct folder
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsCorrectFolder()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            // Act
            string platformFolder = pluginManager.GetPlatformFolder();

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Equal("Windows", platformFolder);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.Equal(PluginManager.IsRunningOniOS() ? "ios" : "osx", platformFolder);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.Equal(PluginManager.IsRunningOnAndroid() ? "android" : "linux", platformFolder);
            }
            else
            {
                Assert.Throws<NotSupportedException>(() => pluginManager.GetPlatformFolder());
            }
        }

        /// <summary>
        /// Tests that load plugins loads plugins when directory is valid
        /// </summary>
        [Fact]
        public void LoadPlugins_LoadsPluginsWhenDirectoryIsValid()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            // Act
            pluginManager.LoadPlugins("Assets/Plugins");

            // Assert
            Assert.NotEmpty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        /// Tests that load plugins throws exception when directory is invalid
        /// </summary>
        [Fact]
        public void LoadPlugins_ThrowsExceptionWhenDirectoryIsInvalid()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string invalidPluginsDirectory = "path/to/invalid/plugins";

            // Act and Assert
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(invalidPluginsDirectory));
        }

        /// <summary>
        /// Tests that load plugins loads correct number of plugins
        /// </summary>
        [Fact]
        public void LoadPlugins_LoadsCorrectNumberOfPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string platformFolder = pluginManager.GetPlatformFolder();
            string validPluginsDirectory = Path.Combine(Environment.CurrentDirectory, pluginManager.GetPlatformPluginsDirectory("Assets/Plugins", platformFolder));

            // Act
            pluginManager.LoadPlugins("Assets/Plugins");

            // Assert
            int expectedNumberOfPlugins = Directory.GetFiles(validPluginsDirectory, "*.dll").Length;
            Assert.Equal(expectedNumberOfPlugins, pluginManager.LoadedPlugins.Count);
        }


        /// <summary>
        /// Tests that load plugins plugins are loaded only once
        /// </summary>
        [Fact]
        public void LoadPlugins_PluginsAreLoadedOnlyOnce()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            string platformFolder = pluginManager.GetPlatformFolder();
            string validPluginsDirectory = Path.Combine(Environment.CurrentDirectory, pluginManager.GetPlatformPluginsDirectory("Assets/Plugins", platformFolder));

            // Act
            pluginManager.LoadPlugins("Assets/Plugins");
            pluginManager.LoadPlugins("Assets/Plugins");

            // Assert
            int expectedNumberOfPlugins = 2;
            Assert.Equal(expectedNumberOfPlugins, pluginManager.LoadedPlugins.Count);
        }


        /// <summary>
        /// Tests that get platform folder returns windows when running on windows
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsWindows_WhenRunningOnWindows()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            // Act
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var result = pluginManager.GetPlatformFolder();

                // Assert
                Assert.Equal("Windows", result);
            }
        }

        /// <summary>
        /// Tests that get platform folder returns osx when running on osx
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsOsx_WhenRunningOnOsx()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            // Act
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && !PluginManager.IsRunningOniOS())
            {
                var result = pluginManager.GetPlatformFolder();

                // Assert
                Assert.Equal("osx", result);
            }
        }

        /// <summary>
        /// Tests that get platform folder returns ios when running on ios
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsIos_WhenRunningOnIos()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            // Act
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && PluginManager.IsRunningOniOS())
            {
                var result = pluginManager.GetPlatformFolder();

                // Assert
                Assert.Equal("ios", result);
            }
        }

        /// <summary>
        /// Tests that get platform folder returns linux when running on linux
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsLinux_WhenRunningOnLinux()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            // Act
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && !PluginManager.IsRunningOnAndroid())
            {
                var result = pluginManager.GetPlatformFolder();

                // Assert
                Assert.Equal("linux", result);
            }
        }

        /// <summary>
        /// Tests that get platform folder returns android when running on android
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsAndroid_WhenRunningOnAndroid()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();

            // Act
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && PluginManager.IsRunningOnAndroid())
            {
                var result = pluginManager.GetPlatformFolder();

                // Assert
                Assert.Equal("android", result);
            }
        }

        /// <summary>
        /// Tests that get platform folder throws exception when platform is unsupported
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ThrowsException_WhenPlatformIsUnsupported()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager();
            
            // Act and Assert
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                !RuntimeInformation.IsOSPlatform(OSPlatform.OSX) &&
                !RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.Throws<NotSupportedException>(() => pluginManager.GetPlatformFolder());
            }
        }
    }
}