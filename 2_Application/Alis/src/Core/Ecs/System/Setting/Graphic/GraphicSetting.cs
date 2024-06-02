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

using System.Diagnostics.CodeAnalysis;
using Alis.Builder.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Graphic;

namespace Alis.Core.Ecs.System.Setting.Graphic
{
    /// <summary>
    ///     The graphic setting class
    /// </summary>
    /// <seealso cref="IGraphicSetting" />
    /// <seealso cref="IBuilder{GraphicSettingBuilder}" />
    public class GraphicSetting : IGraphicSetting, IBuilder<GraphicSettingBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicSetting"/> class
        /// </summary>
        [ExcludeFromCodeCoverage]
        public GraphicSetting()
        {
            Window = new Window();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicSetting"/> class
        /// </summary>
        /// <param name="window">The window</param>
        [JsonConstructor]
        [ExcludeFromCodeCoverage]
        public GraphicSetting(Window window)
        {
            Window = window;
        }
        
        /// <summary>
        ///     Gets or sets the value of the window
        /// </summary>
        [JsonPropertyName("_Window_")]
        public Window Window { get; set; }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder Builder() => new GraphicSettingBuilder();
    }
}