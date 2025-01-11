// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerController.cs
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
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Snake
{
    /// <summary>
    ///     The player controller class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class PlayerController : AComponent
    {
        /// <summary>
        ///     The move interval
        /// </summary>
        private readonly float _moveInterval = 0.2f;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider _boxCollider;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F _direction = new Vector2F(1, 0);

        /// <summary>
        ///     The move timer
        /// </summary>
        private float _moveTimer;

        /// <summary>
        ///     The snake body
        /// </summary>
        private List<GameObject> _snakeBody;

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
           Logger.Info("PlayerController started");
            _boxCollider = GameObject.Get<BoxCollider>();
            _snakeBody = new List<GameObject> {GameObject};
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            _moveTimer += Context.TimeManager.DeltaTime;
            if (_moveTimer >= _moveInterval)
            {
                Move();
                _moveTimer = 0;
            }
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(KeyCodes key)
        {
            if ((key == KeyCodes.W) && (_direction != new Vector2F(0, -1)))
            {
                _direction = new Vector2F(0, 1);
            }
            else if ((key == KeyCodes.S) && (_direction != new Vector2F(0, 1)))
            {
                _direction = new Vector2F(0, -1);
            }
            else if ((key == KeyCodes.A) && (_direction != new Vector2F(1, 0)))
            {
                _direction = new Vector2F(-1, 0);
            }
            else if ((key == KeyCodes.D) && (_direction != new Vector2F(-1, 0)))
            {
                _direction = new Vector2F(1, 0);
            }
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(KeyCodes key)
        {
            // No action needed on key release for this game
        }

        /// <summary>
        ///     Moves this instance
        /// </summary>
        private void Move()
        {
            Vector2F newPosition = _boxCollider.Body.Position + _direction * 1; // Move by 1 meter (32 pixels)

            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                if ((_snakeBody[i].Get<BoxCollider>().Body != null) && (_snakeBody[i - 1].Get<BoxCollider>().Body != null))
                {
                    BoxCollider segmentCollider = _snakeBody[i].Get<BoxCollider>();
                    segmentCollider.GameObject.IsEnable = true;
                    segmentCollider.Body.Position = _snakeBody[i - 1].Get<BoxCollider>().Body.Position;
                }
            }

            _boxCollider.Body.Position = newPosition;
        }

        /// <summary>
        ///     Grows this instance
        /// </summary>
        public void Grow()
        {
            // Create a new GameObject for the new segment
            GameObject newSegment = new GameObject();

            // Create and configure the BoxCollider for the new segment
            BoxCollider newSegmentCollider = new BoxCollider()
                .Builder()
                .IsActive(true)
                .BodyType(BodyType.Kinematic)
                .IsTrigger(false)
                .AutoTilling(false)
                .Size(1f, 1f)
                .Rotation(0.0f)
                .RelativePosition(0, 0)
                .Mass(1.0f)
                .Restitution(1f)
                .Friction(0f)
                .FixedRotation(true)
                .IgnoreGravity(true)
                .Build();

            // Add the BoxCollider to the new segment
            newSegment.Add(newSegmentCollider);

            // Add the new segment to the scene
            Context.SceneManager.CurrentScene.Add(newSegment);

            // Add the new segment to the snake body list
            _snakeBody.Add(newSegment);

            newSegment.Tag = "SnakeSegment";
            newSegment.IsEnable = false;
        }
    }
}