// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestablePluginManager.cs
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

using Alis.Core.EcsOld.System.Scope;

namespace Alis.Extension.Plugin.Test.Mocks
{
    /// <summary>
    ///     The testable plugin manager class
    /// </summary>
    /// <seealso cref="PluginManager" />
    internal class TestablePluginManager : PluginManager
    {
        /// <summary>
        ///     The load plugin from file call count
        /// </summary>
        public int LoadPluginFromFileCallCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TestablePluginManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="loadPluginFromFileCallCount">The load plugin from file call count</param>
        public TestablePluginManager(Context context, int loadPluginFromFileCallCount) : base(context) => LoadPluginFromFileCallCount = loadPluginFromFileCallCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TestablePluginManager" /> class
        /// </summary>
        /// <param name="platformDetector">The platform detector</param>
        /// <param name="context">The context</param>
        /// <param name="loadPluginFromFileCallCount">The load plugin from file call count</param>
        public TestablePluginManager(IPlatformDetector platformDetector, Context context, int loadPluginFromFileCallCount) : base(platformDetector, context) => LoadPluginFromFileCallCount = loadPluginFromFileCallCount;

        /// <summary>
        ///     Loads the plugin from file using the specified plugin file
        /// </summary>
        /// <param name="pluginFile">The plugin file</param>
        internal new void LoadPluginFromFile(string pluginFile)
        {
            base.LoadPluginFromFile(pluginFile);
            LoadPluginFromFileCallCount++;
        }
    }
}