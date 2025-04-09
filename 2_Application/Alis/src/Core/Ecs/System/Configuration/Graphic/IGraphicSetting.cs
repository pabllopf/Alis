// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGraphicSetting.cs
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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.System.Configuration.Graphic
{
    /// <summary>
    ///     The graphic setting interface
    /// </summary>
    public interface IGraphicSetting
    {
        /// <summary>
        ///     Gets or sets the value of the target frames
        /// </summary>
        double TargetFrames { get; set; }

        /// <summary>
        ///     Gets or sets the value of the target
        /// </summary>
        string Target { get; set; }

        /// <summary>
        ///     Gets or sets the value of the preview mode
        /// </summary>
        bool PreviewMode { get; set; }

        /// <summary>
        ///     Gets or sets the value of the grid color
        /// </summary>
        Color GridColor { get; set; }

        /// <summary>
        ///     Gets or sets the value of the has grid
        /// </summary>
        bool HasGrid { get; set; }

        /// <summary>
        ///     Gets or sets the value of the background color
        /// </summary>
        Color BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the value of the window size
        /// </summary>
        Vector2F WindowSize { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is resizable
        /// </summary>
        bool IsResizable { get; set; }
    }
}