// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Animation.cs
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

using System.Collections.Generic;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The animation
    /// </summary>
    public struct Animation : IAnimation
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Animation" /> class
        /// </summary>
        public Animation() : this(string.Empty, 0, 0f)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animation" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="order">The order</param>
        /// <param name="speed">The speed</param>
        public Animation(string name, int order, float speed) : this(name, order, speed, new List<Frame>())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animation" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="order">The order</param>
        /// <param name="speed">The speed</param>
        /// <param name="frames">The frames</param>
        public Animation(string name, int order, float speed, List<Frame> frames)
        {
            Name = name;
            Order = order;
            Speed = speed;
            Frames = frames ?? new List<Frame>();
        }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; } = null;

        /// <summary>
        ///     Gets or sets the value of the order
        /// </summary>
        public int Order { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the value of the speed
        /// </summary>
        public float Speed { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the value of the frames
        /// </summary>
        public List<Frame> Frames { get; set; } = new List<Frame>();

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