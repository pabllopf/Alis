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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Graphic;

namespace Alis.Core.Ecs.System.Setting.Graphic
{
    /// <summary>
    ///     The graphic setting class
    /// </summary>
    /// <seealso cref="IGraphicSetting" />
    /// <seealso cref="IBuilder{GraphicSettingBuilder}" />
    public class GraphicSetting : IGraphicSetting,
        IBuilder<GraphicSettingBuilder>
    {
        /// <summary>
        ///     Gets or sets the value of the window
        /// </summary>
        public IWindow Window { get; set; } = new Window();
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder Builder() => new GraphicSettingBuilder();
    }
}