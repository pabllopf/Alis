// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ${File.FileName}
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    /// The pipeline controller class
    /// </summary>
    /// <seealso cref="Component"/>
    public class PipelineController : Component
    {
        /// <summary>
        /// The random height
        /// </summary>
        private static int randomHeight;
        
        /// <summary>
        /// The random direction
        /// </summary>
        private static int randomDirection;
        
        /// <summary>
        /// The generated
        /// </summary>
        private static bool generated;
        
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        /// The pos origin
        /// </summary>
        private Transform posOrigin;

        /// <summary>
        /// The velocity
        /// </summary>
        private static float velocity = 10;

        /// <summary>
        /// The factor velocity
        /// </summary>
        private float factorVelocity = 1.1f;

        /// <summary>
        /// Ons the init
        /// </summary>
        public override void OnInit()
        {
            posOrigin = GameObject.Transform;
            boxCollider = GameObject.Get<BoxCollider>();
            boxCollider.LinearVelocity = new Vector2(-velocity, 0);

            generated = true;
            randomHeight = new Random().Next(0, 100);
            randomDirection = new Random().Next(0, 2);
            Console.WriteLine($"{GameObject.Name} NUM={randomHeight} Direction={randomDirection}");
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (GameObject.Transform.Position.X <= -27)
            {
                if (!generated)
                {
                    generated = true;
                    randomHeight = new Random().Next(10, 75);
                    randomDirection = new Random().Next(0, 2);
                    Console.WriteLine($"{GameObject.Name} NUM={randomHeight} Direction={randomDirection} velocity={velocity}");
                }

                switch (randomDirection)
                {
                    case 0:
                    {
                        Vector2 newPos = new Vector2(posOrigin.Position.X, posOrigin.Position.Y + randomHeight);
                        boxCollider.Body.Position = newPos;
                        boxCollider.LinearVelocity = new Vector2(-velocity, 0);
                        break;
                    }
                    case 1:
                    {
                        Vector2 newPos = new Vector2(posOrigin.Position.X, posOrigin.Position.Y - randomHeight);
                        boxCollider.Body.Position = newPos;
                        boxCollider.LinearVelocity = new Vector2(-velocity, 0);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            if (generated)
            {
                velocity *= factorVelocity;
                generated = false;
            }
        }
    }
}