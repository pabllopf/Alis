// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneSetting.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Builder.Core.Ecs.System.Setting.Scene;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.System.Setting.Scene
{
    /// <summary>
    ///     The scene setting class
    /// </summary>
    /// <seealso cref="ISceneSetting" />
    public class SceneSetting : 
        ISceneSetting,
        IBuilder<SceneSettingBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneSetting"/> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public SceneSetting()
        {
            MaxNumberOfScenes = 256;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneSetting"/> class
        /// </summary>
        /// <param name="maxNumberOfScenes">The max number of scenes</param>
        [JsonConstructor]
        [ExcludeFromCodeCoverage]
        public SceneSetting(int maxNumberOfScenes)
        {
            MaxNumberOfScenes = maxNumberOfScenes;
        }
        
        /// <summary>
        /// Gets or sets the value of the max number of scenes
        /// </summary>
        [JsonPropertyName("_MaxNumberOfScenes_")]
        public int MaxNumberOfScenes { get; set; }
        
        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The scene setting builder</returns>
        public SceneSettingBuilder Builder() => new SceneSettingBuilder();
    }
}