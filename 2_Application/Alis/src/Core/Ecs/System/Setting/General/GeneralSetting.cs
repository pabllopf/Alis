// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSetting.cs
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
using Alis.Builder.Core.Ecs.System.Setting.General;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.System.Setting.General
{
    /// <summary>
    ///     The general setting class
    /// </summary>
    /// <seealso cref="IGeneralSetting" />
    /// <seealso cref="IBuilder{TOut}" />
    public class GeneralSetting :
        IGeneralSetting,
        IBuilder<GeneralSettingBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSetting"/> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public GeneralSetting()
        {
            Debug = false;
            Name = "Default Name";
            Description = "Default Description";
            Version = "0.0.0";
            Author = "Pablo Perdomo Falcón";
            License = "GPL-3.0 license";
            Icon = AssetManager.Find("app.bmp");
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSetting"/> class
        /// </summary>
        /// <param name="debug">The debug</param>
        /// <param name="name">The name</param>
        /// <param name="description">The description</param>
        /// <param name="version">The version</param>
        /// <param name="author">The author</param>
        /// <param name="license">The license</param>
        /// <param name="icon">The icon</param>
        [JsonConstructor]
        [ExcludeFromCodeCoverage]
        public GeneralSetting(
            bool debug,
            string name,
            string description,
            string version,
            string author,
            string license,
            string icon)
        {
            Debug = debug;
            Name = name;
            Description = description;
            Version = version;
            Author = author;
            License = license;
            Icon = icon;
        }
        
        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        [JsonPropertyName("_Debug_")]
        public bool Debug { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name_")]
        public string Name { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        [JsonPropertyName("_Description_")]
        public string Description { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the version
        /// </summary>
        [JsonPropertyName("_Version_")]
        public string Version { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the author
        /// </summary>
        [JsonPropertyName("_Author_")]
        public string Author { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the license
        /// </summary>
        [JsonPropertyName("_License_")]
        public string License { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the icon
        /// </summary>
        [JsonPropertyName("_Icon_")]
        public string Icon { get; set; }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The graphic setting builder</returns>
        public GeneralSettingBuilder Builder() => new GeneralSettingBuilder();
    }
}