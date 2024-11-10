// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Frame.cs
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

using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The frame class
    /// </summary>
    public class Frame :
        IHasBuilder<FrameBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Frame" /> class
        /// </summary>
        public Frame()
        {
            NameFile = string.Empty;
            FilePath = string.Empty;
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Frame" /> class
        /// </summary>
        /// <param name="nameFile">The name file</param>
        [JsonConstructor]
        public Frame(string nameFile)
        {
            NameFile = nameFile;
            FilePath = AssetManager.Find(nameFile);
        }
        
        /// <summary>
        ///     Gets or sets the value of the name file
        /// </summary>
        [JsonPropertyName("_NameFile_")]
        public string NameFile { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the file path
        /// </summary>
        [JsonIgnore]
        public string FilePath { get; set; }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The frame builder</returns>
        public FrameBuilder Builder() => new FrameBuilder();
    }
}