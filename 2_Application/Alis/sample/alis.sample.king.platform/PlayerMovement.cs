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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Graphic;
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Sample.King.Platform
{
    /// <summary>
    /// The player movement class
    /// </summary>
    /// <seealso cref="Component"/>
    public class PlayerMovement : Component
    {
        /// <summary>
        /// The animator
        /// </summary>
        private Animator animator;
        
        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart() => animator = GameObject.Get<Animator>();

        /// <summary>
        /// Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(SdlKeycode key)
        {
            switch (key)
            {
                case SdlKeycode.SdlkD:
                    animator.ChangeAnimationTo("Idle", FlipTo.Right);
                    break;
                case SdlKeycode.SdlkA:
                    animator.ChangeAnimationTo("Idle", FlipTo.Left);
                    break;
            }
        }

        /// <summary>
        /// Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(SdlKeycode key)
        {
            switch (key)
            {
                case SdlKeycode.SdlkD:
                    animator.ChangeAnimationTo("Run", FlipTo.Right);
                    break;
                case SdlKeycode.SdlkA:
                    animator.ChangeAnimationTo("Run" , FlipTo.Left);
                    break;
            }
        }
    }
}