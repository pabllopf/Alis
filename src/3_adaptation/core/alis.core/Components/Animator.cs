// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Animator.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Entities;

namespace Alis.Core.Components
{
    /// <summary>
    ///     The animator class
    /// </summary>
    public class Animator : Component
    {
        /*
        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class
        /// </summary>
        public Animator()
        {
            Animations = new List<Animation>();
            State = 0;
            Timer = new Stopwatch();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Animator" /> class
        /// </summary>
        /// <param name="animations">The animations</param>
        public Animator(List<Animation> animations)
        {
            Animations = animations;
            State = 0;
            Timer = new Stopwatch();
        }

        /// <summary>
        ///     Gets or sets the value of the timer
        /// </summary>
        private Stopwatch Timer { get; }

        /// <summary>
        ///     Gets or sets the value of the sprite
        /// </summary>
        private Sprite? Sprite { get; set; }

        /// <summary>
        ///     Gets or sets the value of the animations
        /// </summary>
        public List<Animation> Animations { get; set; }

        /// <summary>
        ///     Gets or sets the value of the state
        /// </summary>
        public int State { get; set; }

        /// <summary>
        ///     Gets the value of the instance
        /// </summary>
        public static Animator Instance { get; } = new Animator();

        /// <summary>
        ///     Creates the instance
        /// </summary>
        /// <returns>The animator</returns>
        public static Animator CreateInstance() => Instance;

        /// <summary>
        ///     Adds the animation
        /// </summary>
        /// <param name="animation">The animation</param>
        public void Add(Animation animation)
        {
            Animations.Add(animation);
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            Timer.Start();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            if (GameObject.Contains<Sprite>())
            {
                Sprite = (Sprite) GameObject.Get<Sprite>();
            }
            else
            {
                Sprite = new Sprite();
                GameObject.Add(Sprite);
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            if (Sprite is not null)
            {
                if (Animations.Count > 0)
                {
                    if (Timer.ElapsedMilliseconds >= Animations[State].Speed * 1000)
                    {
                        if (Animations[State].HasNext())
                        {
                            Sprite.Texture = Animations[State].NextTexture();
                        }

                        Timer.Restart();
                    }
                }
            }
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit()
        {
        }*/
        public override void Start()
        {
        }

        public override void Update()
        {
        }
    }
}