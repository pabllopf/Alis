// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PluginManager.cs
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
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Logging;
using Alis.Core.EcsOld.System.Manager;
using Alis.Core.EcsOld.System.Scope;

namespace Alis.Extension.Plugin
{
    /// <summary>
    ///     The plugin manager class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class PluginManager : AManager, IDisposable, IPluginManager
    {
        /// <summary>
        ///     The platform detector
        /// </summary>
        private readonly IPlatformDetector _platformDetector;

        /// <summary>
        ///     The loaded assemblies
        /// </summary>
        internal readonly List<Assembly> LoadedAssemblies;

        /// <summary>
        ///     The loaded plugins
        /// </summary>
        internal List<IPlugin> LoadedPlugins;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PluginManager" /> class
        /// </summary>
        public PluginManager(Context context) : base(context)
        {
            LoadedPlugins = new List<IPlugin>();
            LoadedAssemblies = new List<Assembly>();
            _platformDetector = new PlatformDetector();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PluginManager" /> class
        /// </summary>
        /// <param name="platformDetector">The platform detector</param>
        /// <param name="context"></param>
        public PluginManager(IPlatformDetector platformDetector, Context context) : base(context)
        {
            LoadedPlugins = new List<IPlugin>();
            LoadedAssemblies = new List<Assembly>();
            _platformDetector = platformDetector;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            UnloadPlugins();
        }

        /// <summary>
        ///     Loads the plugins using the specified plugins directory
        /// </summary>
        /// <param name="pluginsDirectory">The plugins directory</param>
        public void LoadPlugins(string pluginsDirectory)
        {
            string platformFolder = GetPlatformFolder();
            string platformPluginsDirectory = GetPlatformPluginsDirectory(pluginsDirectory, platformFolder);

            if (ValidatePluginsDirectory(platformPluginsDirectory))
            {
                IEnumerable<string> pluginFiles = GetPluginFiles(platformPluginsDirectory);
                LoadPluginsFromFiles(pluginFiles);
            }
            else
            {
                throw new DirectoryNotFoundException("Plugins directory not found.");
            }
        }

        /// <summary>
        ///     Gets the platform plugins directory
        /// </summary>
        /// <param name="pluginsDirectory">The plugins directory</param>
        /// <param name="platformFolder">The platform folder</param>
        /// <returns>The platform plugins directory</returns>
        internal string GetPlatformPluginsDirectory(string pluginsDirectory, string platformFolder)
        {
            Logger.Info("os: " + platformFolder);
            string platformPluginsDirectory = Path.Combine(pluginsDirectory, platformFolder);
            Logger.Info("directory: " + platformPluginsDirectory);
            return platformPluginsDirectory;
        }

        /// <summary>
        ///     Loads the plugins from the specified files
        /// </summary>
        /// <param name="pluginFiles">The plugin files</param>
        internal void LoadPluginsFromFiles(IEnumerable<string> pluginFiles)
        {
            foreach (string pluginFile in pluginFiles)
            {
                LoadPluginFromFile(pluginFile);
            }
        }

        /// <summary>
        ///     Gets the platform folder
        /// </summary>
        /// <exception cref="NotSupportedException">Unsupported platform. Plugins will not be loaded.</exception>
        /// <returns>The string</returns>
        internal string GetPlatformFolder()
        {
            if (_platformDetector.IsLinux())
            {
                return "linux";
            }

            if (_platformDetector.IsWindows())
            {
                return "windows";
            }

            if (_platformDetector.IsOsx())
            {
                return "osx";
            }

            if (_platformDetector.IsiOs())
            {
                return "ios";
            }

            if (_platformDetector.IsAndroid())
            {
                return "android";
            }

            throw new NotSupportedException("Unsupported platform. Plugins will not be loaded.");
        }

        /// <summary>
        ///     Describes whether this instance is running on android
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsRunningOnAndroid() => _platformDetector.IsAndroid();

        /// <summary>
        ///     Describes whether this instance is running oni os
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsRunningOniOS() => _platformDetector.IsiOs();

        /// <summary>
        ///     Validates the plugins directory using the specified directory
        /// </summary>
        /// <param name="directory">The directory</param>
        /// <returns>True if the directory exists, false otherwise</returns>
        internal static bool ValidatePluginsDirectory(string directory) => Directory.Exists(directory);

        /// <summary>
        ///     Gets the plugin files using the specified directory
        /// </summary>
        /// <param name="directory">The directory</param>
        /// <returns>The string array</returns>
        internal IEnumerable<string> GetPluginFiles(string directory) => Directory.GetFiles(directory)
            .Where(IsPluginFile)
            .ToArray();

        /// <summary>
        ///     Loads the plugin from file using the specified plugin file
        /// </summary>
        /// <param name="pluginFile">The plugin file</param>
        internal void LoadPluginFromFile(string pluginFile)
        {
            InstantiatePlugins(LoadAssembly(pluginFile));
        }

        /// <summary>
        ///     Loads the assembly from the specified file
        /// </summary>
        /// <param name="pluginFile">The plugin file</param>
        /// <returns>The loaded assembly</returns>
        internal Assembly LoadAssembly(string pluginFile)
        {
            Assembly assembly = Assembly.LoadFrom(pluginFile);
            Logger.Info($"Loaded assembly: {assembly.FullName}");
            LoadedAssemblies.Add(assembly);
            return assembly;
        }

        /// <summary>
        ///     Instantiates the plugins from the specified assembly
        /// </summary>
        /// <param name="assembly">The assembly</param>
        internal void InstantiatePlugins(Assembly assembly)
        {
            Type[] pluginTypes = GetPluginTypes(assembly);

            foreach (Type type in pluginTypes)
            {
                IPlugin plugin = CreatePluginInstance(type);
                LoadedPlugins.Add(plugin);
            }
        }

        /// <summary>
        ///     Gets the plugin types from the specified assembly
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <returns>An array of plugin types</returns>
        internal Type[] GetPluginTypes(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => typeof(IPlugin).IsAssignableFrom(type))
                .ToArray();
        }

        /// <summary>
        ///     Creates a plugin instance from the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>A plugin instance</returns>
        internal IPlugin CreatePluginInstance(Type type) => (IPlugin) Activator.CreateInstance(type);


        /// <summary>
        ///     Describes whether this instance is plugin file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>The bool</returns>
        internal static bool IsPluginFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return extension == ".dll" || extension == ".so" || extension == ".dylib";
        }

        /// <summary>
        ///     Unloads the plugins
        /// </summary>
        internal void UnloadPlugins()
        {
            foreach (IPlugin plugin in LoadedPlugins)
            {
                plugin.Dispose();
            }

            LoadedPlugins.Clear();
            LoadedAssemblies.Clear();
        }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            foreach (IPlugin plugin in LoadedPlugins)
            {
                plugin.Initialize();
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            foreach (IPlugin plugin in LoadedPlugins)
            {
                plugin.Update();
            }
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            foreach (IPlugin plugin in LoadedPlugins)
            {
                plugin.Render();
            }
        }

        /// <summary>
        ///     Shutdowns this instance
        /// </summary>
        public void Shutdown()
        {
            foreach (IPlugin plugin in LoadedPlugins)
            {
                plugin.Shutdown();
            }
        }
    }
}