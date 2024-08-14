// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicSettingBuilder.cs
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
using Alis.Builder.Core.Graphic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Graphic;

namespace Alis.Builder.Core.Ecs.System.Setting.Graphic
{
    /// <summary>
    ///     The graphic setting builder class
    /// </summary>
    public class GraphicSettingBuilder :
        IBuild<GraphicSetting>,
        IWindow<GraphicSettingBuilder, Func<WindowBuilder, Window>>
    {
        /// <summary>
        ///     The graphic setting
        /// </summary>
        private readonly GraphicSetting graphicSetting = new GraphicSetting();
        
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The graphic setting</returns>
        public GraphicSetting Build() => graphicSetting;
        
        /// <summary>
        ///     Windows the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder Window(Func<WindowBuilder, Window> value)
        {
            graphicSetting.Window = value(new WindowBuilder());
            return this;
        }
    }
}