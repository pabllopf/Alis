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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    /// The animator
    /// </summary>
    public struct Animator : IAnimator
    {
        public List<Animation> Animations { get; set; }
        
        public int CurrentAnimationIndex { get; set; }

        public Animator()
        {
            Animations = new List<Animation>();
            CurrentAnimationIndex = 0;
        }

        public Animator(List<Animation> animations)
        {
            Animations = animations;
            CurrentAnimationIndex = 0;
        }
        
        public void Update(IGameObject self)
        {
        }

        public void Init(IGameObject self)
        {
        }

        public void AddAnimation(Animation animation)
        {
            Animations.Add(animation);
        }
    }
}