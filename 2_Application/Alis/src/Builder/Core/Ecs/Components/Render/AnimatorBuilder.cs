// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimatorBuilder.cs
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
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The animator builder class
    /// </summary>
    public class AnimatorBuilder :
        IBuild<Animator>,
        IAddAnimation<AnimatorBuilder, Func<AnimationBuilder, Animation>>
    {
        /// <summary>
        ///     The animator
        /// </summary>
        private Animator animator = new Animator();
        
        private Context context;

        public AnimatorBuilder(Context context)
        {
            this.context = context;
        }

        /// <summary>
        ///     Adds the animation using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The animator builder</returns>
        public AnimatorBuilder AddAnimation(Func<AnimationBuilder, Animation> value)
        {
            AnimationBuilder animationBuilder = new AnimationBuilder(context);
            Animation animation = value.Invoke(animationBuilder);
            animator.AddAnimation(animation);
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The animator</returns>
        public Animator Build()
        {
            animator.Context = context;
            return animator;
        }
    }
}