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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The pipeline controller class
    /// </summary>
    internal class PipelineController() : IOnStart, IOnUpdate, IOnExit
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
        ///     The pos origin
        /// </summary>
        private Transform posOrigin;

        /// <summary>
        ///     The velocity
        /// </summary>
        public float Velocity = 3;

        /// <summary>
        /// The info
        /// </summary>
        private Info info;


        /// <summary>
        /// Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            posOrigin = self.Get<Transform>();
            info = self.Get<Info>();
            boxCollider = self.Get<BoxCollider>();
            
            Velocity = 3;
            boxCollider.Body.LinearVelocity = new Vector2F(-Velocity, 0);
            
            _randomHeight = (int)(DateTime.Now.Ticks % 4);
            _randomDirection = Math.Abs((int)(DateTime.Now.Ticks % 4) % 2);
            Logger.Info($"{info.Name} NUM={_randomHeight} Direction={_randomDirection}");

            _generated = true;
            IsStop = false;
        }

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            Transform current = self.Get<Transform>();
            
            if (IsStop && (Velocity != 0))
            {
                Velocity = 0;
                boxCollider.Body.LinearVelocity = new Vector2F(0, 0);
                return;
            }

            if ((current.Position.X <= -5) && !IsStop)
            {
                if (!_generated)
                {
                    _generated = true;
                    _randomHeight = (int)(DateTime.Now.Ticks % 2);
                    _randomDirection = Math.Abs((int)(DateTime.Now.Ticks % 4) % 2);
                    Logger.Info($"{info.Name} NUM={_randomHeight} Direction={_randomDirection} velocity={Velocity}");
                }

                switch (_randomDirection)
                {
                    case 0:
                    {
                        Vector2F newPos = new Vector2F(posOrigin.Position.X, posOrigin.Position.Y + _randomHeight);
                        boxCollider.Body.Position = newPos;
                        boxCollider.Body.LinearVelocity = new Vector2F(-Velocity, 0);
                        break;
                    }
                    case 1:
                    {
                        Vector2F newPos = new Vector2F(posOrigin.Position.X, posOrigin.Position.Y - _randomHeight);
                        boxCollider.Body.Position = newPos;
                        boxCollider.Body.LinearVelocity = new Vector2F(-Velocity, 0);
                        break;
                    }
                }
            }
            
            if (_generated && !IsStop)
            {
                _generated = false;
            }
        }

        /// <summary>
        /// Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            Velocity = 0;
            IsStop = true;
            _generated = false;
            Logger.Info($"{info.Name} Exiting...");
        }
    }
}