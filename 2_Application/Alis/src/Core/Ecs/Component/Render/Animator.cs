// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Animator.cs
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
using System.Diagnostics;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The animator class
    /// </summary>
    public class Animator : Component, IBuilder<AnimatorBuilder>
    {
        /// <summary>
        ///     The current animation
        /// </summary>
        private Animation currentAnimation;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class
        /// </summary>
        public Animator()
        {
            Animations = new List<Animation>();
            Timer = new Stopwatch();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class
        /// </summary>
        /// <param name="animations">The animations</param>
        public Animator(List<Animation> animations)
        {
            Animations = animations;
            if (animations.Count > 0)
            {
                currentAnimation = animations[0];
            }

            Timer = new Stopwatch();
        }

        /// <summary>
        ///     Gets or sets the value of the timer
        /// </summary>
        private Stopwatch Timer { get; }

        /// <summary>
        ///     Gets or sets the value of the sprite
        /// </summary>
        private Sprite Sprite { get; set; }

        /// <summary>
        ///     Gets or sets the value of the animations
        /// </summary>
        public List<Animation> Animations { get; }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The animator builder</returns>
        public AnimatorBuilder Builder() => new AnimatorBuilder();

        /// <summary>
        ///     Adds the animation using the specified animation
        /// </summary>
        /// <param name="animation">The animation</param>
        public void AddAnimation(Animation animation) => Animations.Add(animation);

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void OnInit()
        {
            if (Animations.Count > 0)
            {
                currentAnimation = Animations[0];
            }
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void OnAwake()
        {
            Timer.Start();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void OnStart()
        {
            Sprite = GameObject.Get<Sprite>();
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void OnUpdate()
        {
            if (Sprite == null || currentAnimation == null || Animations.Count == 0)
            {
                return;
            }

            if (Timer.ElapsedMilliseconds >= currentAnimation.Speed * 1000)
            {
                if (currentAnimation.HasNext())
                {
                    Sprite.Image = new Image(currentAnimation.NextTexture().FilePath);
                }

                Timer.Restart();
            }
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void OnExit()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Changes the animation to using the specified name animation
        /// </summary>
        /// <param name="nameAnimation">The name animation</param>
        public void ChangeAnimationTo(string nameAnimation)
        {
            if (currentAnimation.Name.Equals(nameAnimation))
            {
                return;
            }

            Animation tempAnimation = Animations.Find(i => i.Name.Equals(nameAnimation));
            if (tempAnimation != null)
            {
                currentAnimation = tempAnimation;
            }
        }
    }
}