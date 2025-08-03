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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Systems.Configuration.Graphic
{
    /// <summary>
    /// The graphic setting class
    /// </summary>
    /// <seealso cref="IGraphicSetting"/>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GraphicSetting(
        double targetFrames,
        string target,
        bool previewMode,
        Color gridColor,
        bool hasGrid,
        Color backgroundColor,
        Vector2F windowSize,
        bool isResizable) : IGraphicSetting
    {
        public GraphicSetting() : this(
            targetFrames: 60.0,
            target: "OpenGL",
            previewMode: false,
            gridColor: Color.White,
            hasGrid: false,
            backgroundColor: Color.Black,
            windowSize: new Vector2F(800, 600),
            isResizable: true)
        {
        }
        
        public double TargetFrames { get; set; } = targetFrames;
        
        public string Target { get; set; } = target;
        
        public bool PreviewMode { get; set; } = previewMode;
        
        public Color GridColor { get; set; } = gridColor;
        
        public bool HasGrid { get; set; } = hasGrid;
        
        public Color BackgroundColor { get; set; } = backgroundColor;
        
        public Vector2F WindowSize { get; set; } = windowSize;
        
        public bool IsResizable { get; set; } = isResizable;
    }
}