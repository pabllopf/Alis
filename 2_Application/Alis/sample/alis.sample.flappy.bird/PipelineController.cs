// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: PipelineController.cs
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
using System.Security.Cryptography;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The pipeline controller class
    /// </summary>
    /// <seealso cref="Component" />
    public class PipelineController : Component
    {
        /// <summary>
        ///     The random height
        /// </summary>
        private static int randomHeight;

        /// <summary>
        ///     The random direction
        /// </summary>
        private static int randomDirection;

        /// <summary>
        ///     The generated
        /// </summary>
        private static bool generated;

        /// <summary>
        ///     The velocity
        /// </summary>
        public static float velocity = 10;

        /// <summary>
        ///     The is stop
        /// </summary>
        public static bool IsStop;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     The data
        /// </summary>
        private byte[] data;

        /// <summary>
        ///     The factor velocity
        /// </summary>
        private float factorVelocity = 1.1f;

        /// <summary>
        ///     The pos origin
        /// </summary>
        private Transform posOrigin;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            posOrigin = GameObject.Transform;
            boxCollider = GameObject.Get<BoxCollider>();
            boxCollider.LinearVelocity = new Vector2(-velocity, 0);

            velocity = 10;
            factorVelocity = 1.1f;

            using (RandomNumberGenerator randomGenerator = RandomNumberGenerator.Create())
            {
                data = new byte[16];
                randomGenerator.GetBytes(data);
            }

            randomHeight = Math.Abs(BitConverter.ToInt32(data, 0) % 100);
            randomDirection = Math.Abs(BitConverter.ToInt32(data, 4) % 2);
            Console.WriteLine($"{GameObject.Name} NUM={randomHeight} Direction={randomDirection}");

            generated = true;
            IsStop = false;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (IsStop && (velocity != 0))
            {
                velocity = 0;
                factorVelocity = 0;
                boxCollider.LinearVelocity = new Vector2(0, 0);
                return;
            }

            if ((GameObject.Transform.Position.X <= -27) && !IsStop)
            {
                if (!generated)
                {
                    generated = true;
                    randomHeight = Math.Abs(BitConverter.ToInt32(data, 0) % 100);
                    randomDirection = Math.Abs(BitConverter.ToInt32(data, 4) % 2);
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
        ///     Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            if (generated && !IsStop)
            {
                velocity *= factorVelocity;
                generated = false;
            }
        }
    }
}