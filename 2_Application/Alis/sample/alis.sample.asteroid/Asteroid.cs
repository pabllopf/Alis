// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Asteroid.cs
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
using System.Numerics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Audio;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Asteroid
{
    public class Asteroid : AComponent
    {
        private BoxCollider rb;
        public float speed;

        public GameObject[] subAsteroids;
        public int numberOfAsteroids;
        private int health = 3;

        private static readonly Random random = new Random();
        
        public override void OnStart () 
        {
            rb = this.GameObject.Get<BoxCollider>();
        }
        
        public override void OnUpdate () 
        {
           if (health <= 0)
           {
               SpawnSubAsteroids();
               GameObject.Context.SceneManager.CurrentScene.GetByTag("Points").Get<CounterManager>().Increment();
               this.GameObject.Context.SceneManager.DestroyGameObject(this.GameObject);
           }
        }
        
        private void SpawnSubAsteroids()
           {
               for (int i = 0; i < 2; i++)
               {
                   GameObject subAsteroid = new GameObject();
                   subAsteroid.Name = $"SubAsteroid_{i}_{Context.TimeManager.FrameCount}";
                   subAsteroid.Tag = "Asteroid";

                    Transform parentTransform = new Transform();
                    parentTransform.Position = this.GameObject.Transform.Position;
                    parentTransform.Rotation = 0.0f;
                    parentTransform.Scale = new Vector2F(2.0f, 2.0f);
                    
                    subAsteroid.Transform = parentTransform;
                   
                    if (i == 0)
                    {
                        subAsteroid.Add(new BoxCollider().Builder()
                            .IsActive(true)
                            .BodyType(BodyType.Dynamic)
                            .IsTrigger(false)
                            .AutoTilling(true)
                            .Rotation(0.0f)
                            .LinearVelocity(-3f, -1)
                            .Size(0.7F, 0.7F)
                            .Mass(1.0f)
                            .Restitution(0.9f)
                            .Friction(0.5f)
                            .FixedRotation(true)
                            .IgnoreGravity(true)
                            .Build());
                    }
                    else
                    {
                        subAsteroid.Add(new BoxCollider().Builder()
                            .IsActive(true)
                            .BodyType(BodyType.Dynamic)
                            .IsTrigger(false)
                            .AutoTilling(true)
                            .Rotation(0.0f)
                            .LinearVelocity(3f, 1)
                            .Size(0.7F, 0.7F)
                            .Mass(1.0f)
                            .Restitution(0.9f)
                            .Friction(0.5f)
                            .FixedRotation(true)
                            .IgnoreGravity(true)
                            .Build());
                    }

                    if (i == 0)
                    {
                        // generete a random number between 0 and 3
                        int randomAsteroid = random.Next(0, 3);


                        subAsteroid.Add(new Sprite().Builder()
                            .SetTexture($"asteroid_{randomAsteroid}.bmp")
                            .Depth(1)
                            .Build());
                    }
                    else
                    {
                        // generete a random number between 0 and 3
                        int randomAsteroid = random.Next(0, 3);
                        
                        subAsteroid.Add(new Sprite().Builder()
                            .SetTexture($"asteroid_{randomAsteroid}.bmp")
                            .Depth(1)
                            .Build());
                    }

                    subAsteroid.Add(new Asteroid());
                   
                   Context.SceneManager.CurrentScene.Add(subAsteroid);
               }
           }

        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                Console.WriteLine("Player Dead");
            }

            if (gameObject.Tag == "Asteroid" || gameObject.Tag == "Wall")
            {
                float xRandom = random.Next(-1, 2);
                float yRandom = random.Next(-1, 2);

                // Asegurarse de que el vector no sea cero
                if (xRandom == 0 && yRandom == 0)
                {
                    xRandom = 1;
                }

                Vector2F newVelocity = new Vector2F(xRandom, yRandom);
                newVelocity = Vector2F.Normalize(newVelocity) * 3.0f; 

                rb.Body.LinearVelocity = newVelocity;
            }
        }

        public override void OnCollisionExit(GameObject gameObject)
        {
            
        }

        public void DecreaseHealth()
        {
            health -= 1;
            Console.WriteLine("Asteroid health: " + health);
        }
    }
}