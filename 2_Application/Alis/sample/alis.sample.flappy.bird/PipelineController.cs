// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PipelineController.cs
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
using System.Security.Cryptography;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The pipeline controller class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class PipelineController : AComponent
    {
        /// <summary>
        ///     The random height
        /// </summary>
        private static int _randomHeight;

        /// <summary>
        ///     The random direction
        /// </summary>
        private static int _randomDirection;

        /// <summary>
        ///     The generated
        /// </summary>
        private static bool _generated;

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
        private float factorVelocity = 0.5f;

        /// <summary>
        ///     The pos origin
        /// </summary>
        private Transform posOrigin;

        /// <summary>
        ///     The velocity
        /// </summary>
        public float Velocity = 3;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            posOrigin = GameObject.Transform;
            boxCollider = GameObject.Get<BoxCollider>();

            Velocity = 3;
            factorVelocity = 1.1f;

            boxCollider.LinearVelocity = new Vector2F(-Velocity, 0);

            using (RandomNumberGenerator randomGenerator = RandomNumberGenerator.Create())
            {
                data = new byte[16];
                randomGenerator.GetBytes(data);
            }

            _randomHeight = RandomNumberGenerator.GetInt32(0, 3);
            _randomDirection = Math.Abs(BitConverter.ToInt32(data, 4) % 2);
            Logger.Info($"{GameObject.Name} NUM={_randomHeight} Direction={_randomDirection}");

            _generated = true;
            IsStop = false;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (IsStop && (Velocity != 0))
            {
                Velocity = 0;
                factorVelocity = 0;
                boxCollider.LinearVelocity = new Vector2F(0, 0);
                return;
            }

            if ((GameObject.Transform.Position.X <= -5) && !IsStop)
            {
                if (!_generated)
                {
                    _generated = true;
                    _randomHeight = RandomNumberGenerator.GetInt32(0, 3);
                    _randomDirection = Math.Abs(BitConverter.ToInt32(data, 4) % 2);
                    Logger.Info($"{GameObject.Name} NUM={_randomHeight} Direction={_randomDirection} velocity={Velocity}");
                }

                switch (_randomDirection)
                {
                    case 0:
                    {
                        Vector2F newPos = new Vector2F(posOrigin.Position.X, posOrigin.Position.Y + _randomHeight);
                        boxCollider.Body.Position = newPos;
                        boxCollider.LinearVelocity = new Vector2F(-Velocity, 0);
                        break;
                    }
                    case 1:
                    {
                        Vector2F newPos = new Vector2F(posOrigin.Position.X, posOrigin.Position.Y - _randomHeight);
                        boxCollider.Body.Position = newPos;
                        boxCollider.LinearVelocity = new Vector2F(-Velocity, 0);
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
            if (_generated && !IsStop)
            {
                Velocity *= factorVelocity;
                _generated = false;
            }
        }
    }
}