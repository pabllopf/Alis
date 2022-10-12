// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerMovement.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Component;
using Alis.Core.Component.Render;

namespace Alis.Sample.Rogue
{
    /// <summary>
    ///     Move control of player
    /// </summary>
    public class PlayerMovement : ComponentBase
    {
        /// <summary>
        /// The walking
        /// </summary>
        private bool walk;
        
        /// <summary>
        /// The animator
        /// </summary>
        private Animator animator;

        /// <summary>
        /// Awakes this instance
        /// </summary>
        public override void Awake()
        {
            animator = GameObject.GetComponent<Animator>();
            walk = false;
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            Console.WriteLine($"Tag:object:{Tag}");
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            if (!walk)
            {
                animator.ChangeAnimationTo("Idle");
            }
        }

        /// <summary>
        /// sample
        /// </summary>
        /// <param name="key"></param>
        public override void OnReleaseKey(string key)
        {
            switch (key)
            {
                case "W":
                case "D":
                case "S":
                case "A":
                    walk = false;
                    break;
            }
        }
        

        /// <summary>
        /// sample
        /// </summary>
        /// <param name="key"></param>
        public override void OnPressDownKey(string key)
        {
            switch (key)
            {
                case "W":
                    //Console.WriteLine($"Pressed key='{key}'");
                    walk = true;
                    animator.ChangeAnimationTo("WalkUp");
                    Transform.Position += new Vector2(0, -1);
                    break;
                case "S":
                    walk = true;
                    Transform.Position += new Vector2(0, 1);
                    animator.ChangeAnimationTo("WalkDown");
                    //Console.WriteLine($"Pressed key='{key}'");
                    break;
                case "D":
                    walk = true;
                    animator.ChangeAnimationTo("WalkRight");
                    Transform.Position += new Vector2(1, 0);
                    //Console.WriteLine($"Pressed key='{key}'");
                    break;
                case "A":
                    animator.ChangeAnimationTo("WalkLeft");
                    walk = true;
                    Transform.Position += new Vector2(-1, 0);
                    //Console.WriteLine($"Pressed key='{key}'");
                    break;
            }
        }
    }
}