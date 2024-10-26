using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Snake
{
    /// <summary>
    /// The spawner class
    /// </summary>
    /// <seealso cref="AComponent"/>
    public class Spawner : AComponent
    {
        /// <summary>
        /// The food pool
        /// </summary>
        private List<GameObject> _foodPool;
        /// <summary>
        /// The current food index
        /// </summary>
        private int _currentFoodIndex;
        /// <summary>
        /// The spawn interval
        /// </summary>
        private float _spawnInterval = 1.0f; // Time in seconds between spawns
        /// <summary>
        /// The timer
        /// </summary>
        private float _timer;

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            _foodPool = new List<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject food = new GameObject();
                food.Name = $"Food_{i}";

                Transform transform = food.Transform;
                transform.Position = new Vector2(-15, -15); // Initial off-screen position
                food.Transform = transform;

                food.Add<BoxCollider>(new BoxCollider()
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
        /// Ons the update
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
        /// Spawns the food
        /// </summary>
        private void SpawnFood()
        {
            GameObject food = _foodPool[_currentFoodIndex];
            if (!food.IsEnable)
            {
                Random random = new Random();
                float x = (float)(random.NextDouble() * 15 - 7);
                float y = (float)(random.NextDouble() * 15 - 7);

                BoxCollider collider = food.Get<BoxCollider>();
                collider.Body.Position = new Vector2(x, y);

                food.IsEnable = true;
                _currentFoodIndex = (_currentFoodIndex + 1) % _foodPool.Count;
            }
        }
    }
}