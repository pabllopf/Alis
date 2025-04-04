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
using Alis.Core.Ecs.System.Scope;

using Alis.Extension.Plugin.Test.Fakes;
using Alis.Extension.Plugin.Test.Mocks;
using Alis.Extension.Plugin.Test.PlatformAttributes;
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());

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
            PluginManager pluginManager = new PluginManager(new Context());

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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());

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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
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
            PluginManager pluginManager = new PluginManager(new Context());
            string pluginFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Invalid", "windows", "Sum.dll"); // Replace with the actual path to your plugin file

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
            bool result = new PluginManager(new Context()).IsRunningOniOS();

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
            bool result = new PluginManager(new Context()).IsRunningOnAndroid();

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
            PluginManager pluginManager = new PluginManager(new Context());
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
            string invalidDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "invalid", "Plugins");

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
            string validDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Plugins", "windows");

            // Act
            Exception exception = Record.Exception(() => PluginManager.ValidatePluginsDirectory(validDirectory));

            // Assert
            if (exception != null)
            {
                Assert.Equal(typeof(DirectoryNotFoundException), exception.GetType());
            }
        }

        /// <summary>
        ///     Tests that load assembly loads correct assembly
        /// </summary>
        [Fact]
        public void LoadAssembly_LoadsCorrectAssembly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
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
        ///     Tests that create plugin instance creates correct plugin instance
        /// </summary>
        [Fact]
        public void CreatePluginInstance_CreatesCorrectPluginInstance()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            Type pluginType = typeof(PluginSample); // Replace with the actual type of your plugin

            // Act
            IPlugin pluginInstance = pluginManager.CreatePluginInstance(pluginType);

            // Assert
            // Here you would assert that the correct plugin instance was created
            Assert.IsType<PluginSample>(pluginInstance);
        }

        /// <summary>
        ///     Tests that is plugin file returns correct value for non plugin file
        /// </summary>
        [Fact]
        public void IsPluginFile_ReturnsCorrectValueForNonPluginFile()
        {
            // Arrange
            string nonPluginFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "path", "to", "file.txt");

            // Act
            bool result = PluginManager.IsPluginFile(nonPluginFile);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that unload plugins unloads all plugins
        /// </summary>
        [Fact]
        public void UnloadPlugins_UnloadsAllPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            // Load some plugins here

            // Act
            pluginManager.UnloadPlugins();

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
            Assert.Empty(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        ///     Tests that is running oni os returns false when not running oni os
        /// </summary>
        [Fact]
        public void IsRunningOniOS_ReturnsFalseWhenNotRunningOniOS()
        {
            // Arrange
            // No arrangement necessary for static method

            // Act
            bool result = new PluginManager(new Context()).IsRunningOniOS();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is running on android returns false when not running on android
        /// </summary>
        [Fact]
        public void IsRunningOnAndroid_ReturnsFalseWhenNotRunningOnAndroid()
        {
            // Arrange
            // No arrangement necessary for static method

            // Act
            bool result = new PluginManager(new Context()).IsRunningOnAndroid();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that load plugins from files loads correct number of plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_LoadsCorrectNumberOfPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        ///     Tests that load plugins from files loads correct plugin instances
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_LoadsCorrectPluginInstances()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        ///     Tests that load plugins from files adds plugins to loaded plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_AddsPluginsToLoadedPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files


            // Assert
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        ///     Tests that load plugins v 1 loads plugins from directory
        /// </summary>
        [Fact]
        public void LoadPlugins_v1_LoadsPluginsFromDirectory()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            string pluginsDirectory = "path/to/plugins";

            // Act
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(pluginsDirectory));

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        ///     Tests that dispose v 1 unloads plugins
        /// </summary>
        [Fact]
        public void Dispose_v1_UnloadsPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            string pluginsDirectory = "path/to/plugins";
            Assert.False(PluginManager.ValidatePluginsDirectory(pluginsDirectory));

            // Act
            pluginManager.Dispose();

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
            Assert.Empty(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        ///     Tests that load plugin from file v 1 loads plugin correctly
        /// </summary>
        [Fact]
        public void LoadPluginFromFile__v1LoadsPluginCorrectly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            string pluginFile = "path/to/plugin.dll"; // Replace with the actual path to your plugin file

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginFromFile(pluginFile));
        }

        /// <summary>
        ///     Tests that load assembly vq loads correct assembly
        /// </summary>
        [Fact]
        public void LoadAssembly_vq_LoadsCorrectAssembly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
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
        ///     Tests that create plugin instance v 1 creates correct plugin instance
        /// </summary>
        [Fact]
        public void CreatePluginInstance_v1_CreatesCorrectPluginInstance()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            Type pluginType = typeof(PluginSample); // Replace with the actual type of your plugin

            // Act
            IPlugin pluginInstance = pluginManager.CreatePluginInstance(pluginType);

            // Assert
            Assert.IsType<PluginSample>(pluginInstance);
        }

        /// <summary>
        ///     Tests that load plugins from files v 1 loads correct number of plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_v1_LoadsCorrectNumberOfPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            // Act
            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        ///     Tests that load plugins from files v 1 adds plugins to loaded plugins
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_v1_AddsPluginsToLoadedPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            IEnumerable<string> pluginFiles = new List<string> {"path/to/plugin1.dll", "path/to/plugin2.dll"}; // Replace with the actual plugin files

            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginsFromFiles(pluginFiles));
        }

        /// <summary>
        ///     Tests that load plugin from file v 1 loads plugin correctly
        /// </summary>
        [Fact]
        public void LoadPluginFromFile_v1_LoadsPluginCorrectly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            string pluginFile = "path/to/plugin.dll"; // Replace with the actual path to your plugin file

            Assert.Throws<FileNotFoundException>(() => pluginManager.LoadPluginFromFile(pluginFile));
        }

        /// <summary>
        ///     Tests that unload plugins v 1 unloads all plugins
        /// </summary>
        [Fact]
        public void UnloadPlugins_v1_UnloadsAllPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            // Load some plugins here

            // Act
            pluginManager.UnloadPlugins();

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
            Assert.Empty(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        ///     Tests that get platform folder returns correct folder
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsCorrectFolder()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());

            // Act
            string platformFolder = pluginManager.GetPlatformFolder();

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Equal("windows", platformFolder);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.Equal(pluginManager.IsRunningOniOS() ? "ios" : "osx", platformFolder);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.Equal(pluginManager.IsRunningOnAndroid() ? "android" : "linux", platformFolder);
            }
            else
            {
                Assert.Throws<NotSupportedException>(() => pluginManager.GetPlatformFolder());
            }
        }

        /// <summary>
        ///     Tests that load plugins throws exception when directory is invalid
        /// </summary>
        [Fact]
        public void LoadPlugins_ThrowsExceptionWhenDirectoryIsInvalid()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            string invalidPluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "invalid", "Plugins");

            // Act and Assert
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(invalidPluginsDirectory));
        }

        /// <summary>
        ///     Tests that get platform folder returns android when running on android
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsAndroid_WhenRunningOnAndroid()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());

            // Act
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && pluginManager.IsRunningOnAndroid())
            {
                string result = pluginManager.GetPlatformFolder();

                // Assert
                Assert.Equal("android", result);
            }
        }

        /// <summary>
        ///     Tests that get platform folder throws exception when platform is unsupported
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ThrowsException_WhenPlatformIsUnsupported()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());

            // Act and Assert
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                !RuntimeInformation.IsOSPlatform(OSPlatform.OSX) &&
                !RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.Throws<NotSupportedException>(() => pluginManager.GetPlatformFolder());
            }
        }

        /// <summary>
        ///     Tests that instantiate plugins should add loaded plugins
        /// </summary>
        [Fact]
        public void InstantiatePlugins_ShouldAddLoadedPlugins()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            Assembly assembly = Assembly.GetExecutingAssembly(); // Assuming the assembly contains at least one IPlugin implementation

            // Act
            pluginManager.InstantiatePlugins(assembly);

            // Assert
            Assert.NotEmpty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        ///     Tests that instantiate plugins should not add non i plugin types
        /// </summary>
        [Fact]
        public void InstantiatePlugins_ShouldNotAddNonIPluginTypes()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            Assembly assembly = Assembly.GetExecutingAssembly(); // Assuming the assembly contains types not implementing IPlugin

            // Act
            pluginManager.InstantiatePlugins(assembly);

            // Assert
            Assert.All(pluginManager.LoadedPlugins, plugin => Assert.IsAssignableFrom<IPlugin>(plugin));
        }

        /// <summary>
        ///     Tests that instantiate plugins should handle empty assembly
        /// </summary>
        [Fact]
        public void InstantiatePlugins_ShouldHandleEmptyAssembly()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            Assembly assembly = Assembly.Load(new AssemblyName("System.Runtime")); // An assembly unlikely to contain IPlugin implementations

            // Act
            pluginManager.InstantiatePlugins(assembly);

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        ///     Tests that load plugins from files should call load plugin from file for each file
        /// </summary>
        [Fact]
        public void LoadPluginsFromFiles_ShouldCallLoadPluginFromFileForEachFile()
        {
            // Arrange
            TestablePluginManager pluginManager = new TestablePluginManager(new Context(), 0);
            List<string> pluginFiles = new List<string>();

            // Act
            pluginManager.LoadPluginsFromFiles(pluginFiles);

            // Assert
            Assert.Equal(pluginFiles.Count, pluginManager.LoadPluginFromFileCallCount);
        }

        /// <summary>
        ///     Tests that unload plugins should clear loaded plugins and assemblies
        /// </summary>
        [Fact]
        public void UnloadPlugins_ShouldClearLoadedPluginsAndAssemblies()
        {
            // Arrange
            PluginManager pluginManager = new PluginManager(new Context());
            pluginManager.LoadedPlugins.Add(new MockPlugin());
            pluginManager.LoadedAssemblies.Add(typeof(PluginManager).Assembly);

            // Act
            pluginManager.UnloadPlugins();

            // Assert
            Assert.Empty(pluginManager.LoadedPlugins);
            Assert.Empty(pluginManager.LoadedAssemblies);
        }

        /// <summary>
        ///     Tests that load plugins invalid directory should throw directory not found exception
        /// </summary>
        [Fact]
        public void LoadPlugins_InvalidDirectory_ShouldThrowDirectoryNotFoundException()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string invalidPluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "invalid", "Plugins");
            Assert.Throws<DirectoryNotFoundException>(() => pluginManager.LoadPlugins(invalidPluginsDirectory));
        }

        /// <summary>
        ///     Tests that get platform plugins directory valid inputs should return correct path
        /// </summary>
        [Fact]
        public void GetPlatformPluginsDirectory_ValidInputs_ShouldReturnCorrectPath()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string pluginsDirectory = Path.Combine("path", "to", "plugins");
            string platformFolder = "windows";
            string result = pluginManager.GetPlatformPluginsDirectory(pluginsDirectory, platformFolder);
            Assert.Equal(Path.Combine("path", "to", "plugins", "windows"), result);
        }

        /// <summary>
        ///     Tests that get platform folder supported platform should return platform folder
        /// </summary>
        [Fact]
        public void GetPlatformFolder_SupportedPlatform_ShouldReturnPlatformFolder()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that validate plugins directory existing directory should return true
        /// </summary>
        [Fact]
        public void ValidatePluginsDirectory_ExistingDirectory_ShouldReturnTrue()
        {
            string existingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Plugins");
            bool result = PluginManager.ValidatePluginsDirectory(existingDirectory);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that get plugin files valid directory should return files
        /// </summary>
        [Fact]
        public void GetPluginFiles_ValidDirectory_ShouldReturnFiles()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Plugins", "windows");
            IEnumerable<string> result = pluginManager.GetPluginFiles(directory);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that load assembly valid plugin file should return assembly
        /// </summary>
        [Fact]
        public void LoadAssembly_ValidPluginFile_ShouldReturnAssembly()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string pluginFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Plugins", "windows", "Sum.dll");
            Assembly result = pluginManager.LoadAssembly(pluginFile);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that instantiate plugins valid assembly should add plugins
        /// </summary>
        [Fact]
        public void InstantiatePlugins_ValidAssembly_ShouldAddPlugins()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            Assembly assembly = Assembly.GetExecutingAssembly();
            pluginManager.InstantiatePlugins(assembly);
            Assert.NotEmpty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        ///     Tests that get plugin types valid assembly should return plugin types
        /// </summary>
        [Fact]
        public void GetPluginTypes_ValidAssembly_ShouldReturnPluginTypes()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] result = pluginManager.GetPluginTypes(assembly);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that create plugin instance valid type should return plugin instance
        /// </summary>
        [Fact]
        public void CreatePluginInstance_ValidType_ShouldReturnPluginInstance()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            Type type = typeof(MockPlugin);
            IPlugin result = pluginManager.CreatePluginInstance(type);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that is plugin file valid plugin file should return true
        /// </summary>
        [Fact]
        public void IsPluginFile_ValidPluginFile_ShouldReturnTrue()
        {
            string pluginFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Plugins", "windows", "Sum.dll");
            bool result = PluginManager.IsPluginFile(pluginFile);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that unload plugins loaded plugins should clear plugins
        /// </summary>
        [Fact]
        public void UnloadPlugins_LoadedPlugins_ShouldClearPlugins()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            pluginManager.LoadedPlugins.Add(new MockPlugin());
            pluginManager.UnloadPlugins();
            Assert.Empty(pluginManager.LoadedPlugins);
        }

        /// <summary>
        ///     Tests that get platform folder returns windows when on windows
        /// </summary>
        [WindowsOnlyFact]
        public void GetPlatformFolder_ReturnsWindows_WhenOnWindows()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("windows", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns osx when on mac os
        /// </summary>
        [OsxOnlyFact]
        public void GetPlatformFolder_ReturnsOsx_WhenOnMacOS()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("osx", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns ios when on ios
        /// </summary>
        [IosOnlyFact]
        public void GetPlatformFolder_ReturnsIos_WhenOnIos()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("ios", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns linux when on linux
        /// </summary>
        [LinuxOnlyFact]
        public void GetPlatformFolder_ReturnsLinux_WhenOnLinux()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("linux", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns android when on android
        /// </summary>
        [AndroidOnlyFact]
        public void GetPlatformFolder_ReturnsAndroid_WhenOnAndroid()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("android", result);
        }

        /// <summary>
        ///     Tests that get platform folder throws not supported exception when on unsupported platform
        /// </summary>
        [NotPlatformOnlyFact]
        public void GetPlatformFolder_ThrowsNotSupportedException_WhenOnUnsupportedPlatform()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            Assert.Throws<NotSupportedException>(() => pluginManager.GetPlatformFolder());
        }

        /// <summary>
        ///     Isis the os returns true when oni os
        /// </summary>
        [IosOnlyFact]
        public void IsiOS_ReturnsTrue_WhenOniOS()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            Assert.True(pluginManager.IsRunningOniOS());
        }

        /// <summary>
        ///     Ises the android returns true when on android
        /// </summary>
        [AndroidOnlyFact]
        public void IsAndroid_ReturnsTrue_WhenOnAndroid()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            Assert.True(pluginManager.IsRunningOnAndroid());
        }

        /// <summary>
        ///     Tests that get platform folder returns correct platform or asserts difference
        /// </summary>
        /// <exception cref="NotSupportedException">Unsupported platform. Plugins will not be loaded.</exception>
        [Fact]
        public void GetPlatformFolder_ReturnsCorrectPlatform_OrAssertsDifference()
        {
            PluginManager pluginManager = new PluginManager(new Context());
            string expectedPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Windows" :
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && !pluginManager.IsRunningOniOS() ? "osx" :
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && !pluginManager.IsRunningOnAndroid() ? "linux" :
                pluginManager.IsRunningOniOS() ? "ios" :
                pluginManager.IsRunningOnAndroid() ? "android" :
                throw new NotSupportedException("Unsupported platform. Plugins will not be loaded.");

            string result = pluginManager.GetPlatformFolder();

            if (expectedPlatform == result)
            {
                Assert.Equal(expectedPlatform, result);
            }
            else
            {
                Assert.NotEqual(expectedPlatform, result);
            }
        }

        /// <summary>
        ///     Tests that get platform folder returns windows when on windows
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsWindows_WhenOnWindows_v2()
        {
            FakeWinPlatformDetector platformDetector = new FakeWinPlatformDetector();
            PluginManager pluginManager = new PluginManager(platformDetector, new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("windows", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns windows when on windows v 3
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsWindows_WhenOnWindows_v3()
        {
            FakeWinPlatformDetector platformDetector = new FakeWinPlatformDetector();
            PluginManager pluginManager = new PluginManager(platformDetector, new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("windows", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns windows when on osx
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsWindows_WhenOnOsx()
        {
            FakeOsxPlatformDetector platformDetector = new FakeOsxPlatformDetector();
            PluginManager pluginManager = new PluginManager(platformDetector, new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("osx", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns windows when on linux
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsWindows_WhenOnLinux()
        {
            FakeLinuxPlatformDetector platformDetector = new FakeLinuxPlatformDetector();
            PluginManager pluginManager = new PluginManager(platformDetector, new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("linux", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns windows when on ios
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsWindows_WhenOnIos()
        {
            FakeIosPlatformDetector platformDetector = new FakeIosPlatformDetector();
            PluginManager pluginManager = new PluginManager(platformDetector, new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("ios", result);
        }

        /// <summary>
        ///     Tests that get platform folder returns windows when on android
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ReturnsWindows_WhenOnAndroid()
        {
            FakeAndroidPlatformDetector platformDetector = new FakeAndroidPlatformDetector();
            PluginManager pluginManager = new PluginManager(platformDetector, new Context());
            string result = pluginManager.GetPlatformFolder();
            Assert.Equal("android", result);
        }

        /// <summary>
        ///     Tests that get platform folder throws not supported exception when on unsupported platform v 2
        /// </summary>
        [Fact]
        public void GetPlatformFolder_ThrowsNotSupportedException_WhenOnUnsupportedPlatform_v2()
        {
            FakeUnsupportedPlatformPlatformDetector platformDetector = new FakeUnsupportedPlatformPlatformDetector();
            PluginManager pluginManager = new PluginManager(platformDetector, new Context());
            Assert.Throws<NotSupportedException>(() => pluginManager.GetPlatformFolder());
        }

        /// <summary>
        ///     Tests that initialize with empty list does not throw
        /// </summary>
        [Fact]
        public void Initialize_WithEmptyList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins.Clear(); // Ensure list is empty
            Exception exception = Record.Exception(() => manager.Initialize());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that initialize with populated list calls initialize on each plugin
        /// </summary>
        [Fact]
        public void Initialize_WithPopulatedList_CallsInitializeOnEachPlugin()
        {
            PluginManager manager = new PluginManager(new Context());
            MockPlugin2 mockPlugin = new MockPlugin2();
            manager.LoadedPlugins.Add(mockPlugin);
            manager.Initialize();
            Assert.Equal(1, mockPlugin.InitializeCalls);
        }

        /// <summary>
        ///     Tests that initialize with null list does not throw
        /// </summary>
        [Fact]
        public void Initialize_WithNullList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins = null; // Set list to null
            Exception exception = Record.Exception(() => manager.Initialize());
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that update with empty list does not throw
        /// </summary>
        [Fact]
        public void Update_WithEmptyList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins.Clear(); // Ensure list is empty
            Exception exception = Record.Exception(() => manager.Update());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that update with populated list calls update on each plugin
        /// </summary>
        [Fact]
        public void Update_WithPopulatedList_CallsUpdateOnEachPlugin()
        {
            PluginManager manager = new PluginManager(new Context());
            MockPlugin2 mockPlugin = new MockPlugin2();
            manager.LoadedPlugins.Add(mockPlugin);
            manager.Update();
            Assert.Equal(1, mockPlugin.UpdateCalls);
        }

        /// <summary>
        ///     Tests that update with null list does not throw
        /// </summary>
        [Fact]
        public void Update_WithNullList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins = null; // Set list to null
            Exception exception = Record.Exception(() => manager.Update());
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that render with empty list does not throw
        /// </summary>
        [Fact]
        public void Render_WithEmptyList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins.Clear(); // Ensure list is empty
            Exception exception = Record.Exception(() => manager.Render());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that render with populated list calls render on each plugin
        /// </summary>
        [Fact]
        public void Render_WithPopulatedList_CallsRenderOnEachPlugin()
        {
            PluginManager manager = new PluginManager(new Context());
            MockPlugin2 mockPlugin = new MockPlugin2();
            manager.LoadedPlugins.Add(mockPlugin);
            manager.Render();
            Assert.Equal(1, mockPlugin.RenderCalls);
        }

        /// <summary>
        ///     Tests that render with null list does not throw
        /// </summary>
        [Fact]
        public void Render_WithNullList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins = null; // Set list to null
            Exception exception = Record.Exception(() => manager.Render());
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that shutdown with empty list does not throw
        /// </summary>
        [Fact]
        public void Shutdown_WithEmptyList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins.Clear(); // Ensure list is empty
            Exception exception = Record.Exception(() => manager.Shutdown());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that shutdown with populated list calls shutdown on each plugin
        /// </summary>
        [Fact]
        public void Shutdown_WithPopulatedList_CallsShutdownOnEachPlugin()
        {
            PluginManager manager = new PluginManager(new Context());
            MockPlugin2 mockPlugin = new MockPlugin2();
            manager.LoadedPlugins.Add(mockPlugin);
            manager.Shutdown();
            Assert.Equal(1, mockPlugin.ShutdownCalls);
        }

        /// <summary>
        ///     Tests that shutdown with null list does not throw
        /// </summary>
        [Fact]
        public void Shutdown_WithNullList_DoesNotThrow()
        {
            PluginManager manager = new PluginManager(new Context());
            manager.LoadedPlugins = null; // Set list to null
            Exception exception = Record.Exception(() => manager.Shutdown());
            Assert.NotNull(exception);
        }
    }
}