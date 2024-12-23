// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicSetting.cs
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

using Alis.Builder.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic;

namespace Alis.Core.Ecs.System.Configuration.Graphic
{
    /// <summary>
    ///     The graphic setting class
    /// </summary>
    /// <seealso cref="IGraphicSetting" />
    /// <seealso cref="IHasBuilder{TOut}" />
    public class GraphicSetting : IGraphicSetting, IHasBuilder<GraphicSettingBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicSetting" /> class
        /// </summary>
        public GraphicSetting() => Window = new Window();

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicSetting" /> class
        /// </summary>
        /// <param name="window">The window</param>
        [JsonConstructor]
        public GraphicSetting(Window window) => Window = window;

        /// <summary>
        ///     Gets or sets the value of the window
        /// </summary>
        [JsonPropertyName("_Window_")]
        public Window Window { get; set; }

        /// <summary>
        ///     The targetframes
        /// </summary>
        [JsonPropertyName("_TargetFrames_")]
        public double TargetFrames { get; set; } = 60;

        /// <summary>
        ///     Gets or sets the value of the target
        /// </summary>
        [JsonPropertyName("_Target_")]
        public string Target { get; set; } = "OpenGL";

        /// <summary>
        ///     Gets or sets the value of the preview mode
        /// </summary>
        [JsonIgnore]
        public bool PreviewMode { get; set; } = false;

        [JsonPropertyName("_GridColor_")]
        public Color GridColor { get; set; } = new Color(195, 195, 195, 100);
        
        [JsonIgnore]
        public bool HasGrid { get; set; } = false;
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder Builder() => new GraphicSettingBuilder();
    }
}