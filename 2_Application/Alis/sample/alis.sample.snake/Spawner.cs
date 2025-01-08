// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Spawner.cs
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
using System.Security.Cryptography;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Snake
{
    /// <summary>
    ///     The spawner class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class Spawner : AComponent
    {
        /// <summary>
        ///     The spawn interval
        /// </summary>
        private readonly float _spawnInterval = 1.0f; // Time in seconds between spawns

        /// <summary>
        ///     The current food index
        /// </summary>
        private int _currentFoodIndex;

        /// <summary>
        ///     The food pool
        /// </summary>
        private List<GameObject> _foodPool;

        /// <summary>
        ///     The timer
        /// </summary>
        private float _timer;

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            _foodPool = new List<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject food = new GameObject();
                food.Name = $"Food_{i}";

                Transform transform = food.Transform;
                transform.Position = new Vector2F(-15, -15); // Initial off-screen position
                food.Transform = transform;

                food.Add(new BoxCollider()
                    .Builder()
                    .IsActive(true)
                    .BodyType(BodyType.Dynamic)
                    .IsTrigger(true)
                    .AutoTilling(false)
                    .Size(0.25F, 0.25F)
                    .Rotation(0.0f)
                    .RelativePosition(0, 0)
                    .Mass(1.0f)
                    .Restitution(1f)
                    .Friction(0f)
                    .FixedRotation(true)
                    .IgnoreGravity(true)
                    .Build());
                food.Add(new Food());
                Context.SceneManager.CurrentScene.Add(food);
                food.IsEnable = false; // Initially disable the food
                _foodPool.Add(food);
            }

            _currentFoodIndex = 0;
            _timer = _spawnInterval;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            _timer += Context.TimeManager.DeltaTime;
            if (_timer >= _spawnInterval)
            {
                SpawnFood();
                _timer = 0;
            }
        }

        /// <summary>
        ///     Spawns the food
        /// </summary>
        private void SpawnFood()
        {
            GameObject food = _foodPool[_currentFoodIndex];
            if (!food.IsEnable)
            {
                RandomNumberGenerator rng = RandomNumberGenerator.Create();
                byte[] buffer = new byte[4];

                // Generate secure random float for x
                rng.GetBytes(buffer);
                float x = BitConverter.ToUInt32(buffer, 0) / (float) uint.MaxValue * 15f - 7f;

                // Generate secure random float for y
                rng.GetBytes(buffer);
                float y = BitConverter.ToUInt32(buffer, 0) / (float) uint.MaxValue * 15f - 7f;

                BoxCollider collider = food.Get<BoxCollider>();
                if (collider != null)
                {
                    collider.Body.Position = new Vector2F(x, y);

                    food.IsEnable = true;
                    _currentFoodIndex = (_currentFoodIndex + 1) % _foodPool.Count;
                }
            }
        }
    }
}