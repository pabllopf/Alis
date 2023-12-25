// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Animation.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Collections.Generic;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The animation class
    /// </summary>
    public class Animation :
        IBuilder<AnimatorBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Animation" /> class
        /// </summary>
        public Animation() => Frames = new List<Frame>();


        /// <summary>
        ///     Initializes a new instance of the <see cref="Animation" /> class
        /// </summary>
        /// <param name="textures">The textures</param>
        public Animation(List<Frame> textures) => Frames = textures;

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; } = "Default Animation";


        /// <summary>
        ///     Gets or sets the value of the index
        /// </summary>
        private int Index { get; set; }


        /// <summary>
        ///     Gets or sets the value of the order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///     Gets or sets the value of the speed
        /// </summary>
        public float Speed { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the value of the textures
        /// </summary>
        private List<Frame> Frames { get; }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The animator builder</returns>
        public AnimatorBuilder Builder() => new AnimatorBuilder();

        /// <summary>
        ///     Describes whether this instance has next
        /// </summary>
        /// <returns>The bool</returns>
        public bool HasNext() => Frames.Count > 0;

        /// <summary>
        ///     Nexts the texture
        /// </summary>
        /// <exception cref="InvalidCastException"></exception>
        /// <returns>The texture</returns>
        public Frame NextTexture()
        {
            Frame result = Frames[Index];

            if (Index < Frames.Count)
            {
                Index += 1;
            }

            if (Index == Frames.Count)
            {
                Index = 0;
            }

            return result;
        }

        /// <summary>
        ///     Adds the frame using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        public void AddFrame(Frame frame)
        {
            Frames.Add(frame);
        }
    }
}