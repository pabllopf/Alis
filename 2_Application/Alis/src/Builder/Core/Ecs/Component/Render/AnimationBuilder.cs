// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimationBuilder.cs
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Component.Render;

namespace Alis.Builder.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The animation builder class
    /// </summary>
    /// <seealso cref="IBuild{Animation}" />
    public class AnimationBuilder :
        IBuild<Animation>,
        IName<AnimationBuilder, string>,
        ISpeed<AnimationBuilder, float>,
        IOrder<AnimationBuilder, int>,
        IAddFrame<AnimationBuilder, Func<FrameBuilder, Frame>>
    {
        /// <summary>
        ///     The animation
        /// </summary>
        private readonly Animation animation = new Animation();


        /// <summary>
        ///     Adds the frame using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder AddFrame(Func<FrameBuilder, Frame> value)
        {
            animation.AddFrame(value.Invoke(new FrameBuilder()));
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The animation</returns>
        public Animation Build() => animation;

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder Name(string value)
        {
            animation.Name = value;
            return this;
        }

        /// <summary>
        ///     Orders the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder Order(int value)
        {
            animation.Order = value;
            return this;
        }

        /// <summary>
        ///     Speeds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animation builder</returns>
        public AnimationBuilder Speed(float value)
        {
            animation.Speed = value;
            return this;
        }
    }
}