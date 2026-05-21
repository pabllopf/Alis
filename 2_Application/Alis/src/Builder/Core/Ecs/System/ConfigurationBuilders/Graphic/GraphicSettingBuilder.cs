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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Configuration.Graphic;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Graphic
{
    /// <summary>
    ///     The graphic setting builder class
    /// </summary>
    public class GraphicSettingBuilder :
        IBuild<GraphicSetting>
    {
        /// <summary>
        ///     The graphic setting
        /// </summary>
        private GraphicSetting graphicSetting = new GraphicSetting();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The graphic setting</returns>
        public GraphicSetting Build() => graphicSetting;

        /// <summary>
        ///     Targets the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder Target(string value)
        {
            graphicSetting.Target = value;
            return this;
        }

        /// <summary>
        ///     Frames the rate using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder FrameRate(double value)
        {
            graphicSetting.TargetFrames = value;
            return this;
        }

        /// <summary>
        ///     Resolutions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder Resolution(int x, int y)
        {
            graphicSetting.WindowSize = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Backgrounds the color using the specified color
        /// </summary>
        /// <param name="color">The color</param>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder BackgroundColor(Color color)
        {
            graphicSetting.BackgroundColor = color;
            return this;
        }

        /// <summary>
        ///     Ises the resizable using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The graphic setting builder</returns>
        public GraphicSettingBuilder IsResizable(bool value)
        {
            graphicSetting.IsResizable = value;
            return this;
        }
    }
}