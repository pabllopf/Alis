using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Alis.Core.Plugin
{
    /// <summary>
    /// The plugin manager class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class PluginManager : IDisposable
    {
        /// <summary>
        /// The loaded plugins
        /// </summary>
        private readonly List<IPlugin> loadedPlugins;
        /// <summary>
        /// The loaded assemblies
        /// </summary>
        private readonly List<Assembly> loadedAssemblies;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginManager"/> class
        /// </summary>
        public PluginManager()
        {
            loadedPlugins = new List<IPlugin>();
            loadedAssemblies = new List<Assembly>();
        }

        /// <summary>
        /// Loads the plugins using the specified plugins directory
        /// </summary>
        /// <param name="pluginsDirectory">The plugins directory</param>
        public void LoadPlugins(string pluginsDirectory)
        {
            string platformFolder;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                platformFolder = "Windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                platformFolder = IsRunningOniOS() ? "ios" : "osx";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                platformFolder = IsRunningOnAndroid() ? "android" : "linux";
            }
            else
            {
               throw new NotSupportedException("Unsupported platform. Plugins will not be loaded.");
            }
            
            Console.WriteLine("os: " + platformFolder);

            string platformPluginsDirectory = Path.Combine(pluginsDirectory, platformFolder);
            
            Console.WriteLine("directory: " + platformPluginsDirectory);

            if (!Directory.Exists(platformPluginsDirectory))
            {
                throw new DirectoryNotFoundException($"Plugins directory for platform '{platformFolder}' does not exist.");
            }

            string[] pluginFiles = Directory.GetFiles(platformPluginsDirectory)
                .Where(file => IsPluginFile(file))
                .ToArray();
            
            foreach (string pluginFile in pluginFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(pluginFile);
                    loadedAssemblies.Add(assembly);

                    Type[] types = assembly.GetTypes();

                    foreach (Type type in types)
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type))
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            loadedPlugins.Add(plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading plugin from file '{pluginFile}': {ex.Message}");
                }
            }
        }
        
        /// <summary>
        /// Describes whether this instance is plugin file
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>The bool</returns>
        private bool IsPluginFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return extension == ".dll" || extension == ".so" || extension == ".dylib";
        }

        /// <summary>
        /// Unloads the plugins
        /// </summary>
        public void UnloadPlugins()
        {
            foreach (IPlugin plugin in loadedPlugins)
            {
                plugin.Dispose();
            }

            loadedPlugins.Clear();
            loadedAssemblies.Clear();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            UnloadPlugins();
        }
        
        
        /// <summary>
        /// Describes whether this instance is running oni os
        /// </summary>
        /// <returns>The bool</returns>
        private bool IsRunningOniOS()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && (RuntimeInformation.OSDescription.Contains("iPhone") || RuntimeInformation.OSDescription.Contains("iPad"));
        }
        
        
        /// <summary>
        /// Describes whether this instance is running on android
        /// </summary>
        /// <returns>The bool</returns>
        private bool IsRunningOnAndroid()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && RuntimeInformation.OSDescription.Contains("Android");
        }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {
            loadedPlugins.ForEach(plugin => plugin.Initialize());
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
            loadedPlugins.ForEach(plugin => plugin.Update());
        }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            loadedPlugins.ForEach(plugin => plugin.Render());
        }

        /// <summary>
        /// Shutdowns this instance
        /// </summary>
        public void Shutdown()
        {
            loadedPlugins.ForEach(plugin => plugin.Shutdown());
        }
        

    }
}
