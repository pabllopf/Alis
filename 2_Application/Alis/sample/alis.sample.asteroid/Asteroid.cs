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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Asteroid
{
    /// <summary>
    /// The asteroid class
    /// </summary>
    
    public class Asteroid : IInitable, IUpdateable
    {
        /*
        /// <summary>
        /// The rb
        /// </summary>
        private BoxCollider rb;
        /// <summary>
        /// The speed
        /// </summary>
        public float speed;

        /// <summary>
        /// The sub asteroids
        /// </summary>
        public GameObject[] subAsteroids;
        /// <summary>
        /// The number of asteroids
        /// </summary>
        public int numberOfAsteroids;
        /// <summary>
        /// The health
        /// </summary>
        private int health = 3;

        /// <summary>
        /// The random
        /// </summary>
        private static readonly Random random = new Random();
        
        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart () 
        {
            rb = this.GameObject.Get<BoxCollider>();
        }
        
        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate () 
        {
           if (health <= 0)
           {
               this.Context.SceneManager.CurrentScene.GetByTag("SoundPlayer").Get<AudioSource>().Play();
               SpawnSubAsteroids();
               
               GameObject.Context.SceneManager.CurrentScene.GetByTag("Points").Get<CounterManager>().Increment();
               this.GameObject.Context.SceneManager.DestroyGameObject(this.GameObject);
           }
        }
        
        /// <summary>
        /// Spawns the sub asteroids
        /// </summary>
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

                    subAsteroid.Add(new AudioSource()
                        .Builder()
                        .PlayOnAwake(false)
                        .SetAudioClip(audioClip => audioClip
                            .FilePath("bangLarge.wav")
                            .Volume(100.0f)
                            .Build())
                        .Build());
                   
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
                            .SetTexture($"asteroid_{randomAsteroid}.jpeg")
                            .Depth(1)
                            .Build());
                    }
                    else
                    {
                        // generete a random number between 0 and 3
                        int randomAsteroid = random.Next(0, 3);
                        
                        subAsteroid.Add(new Sprite().Builder()
                            .SetTexture($"asteroid_{randomAsteroid}.jpeg")
                            .Depth(1)
                            .Build());
                    }

                    subAsteroid.Add(new Asteroid());
                   
                   Context.SceneManager.CurrentScene.Add(subAsteroid);
               }
           }

        /// <summary>
        /// Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                Console.WriteLine("Player Dead");
            }

            if (gameObject.Tag == "Asteroid" || gameObject.Tag == "Wall")
            {
                float xRandom = random.Next(-2, 2);
                float yRandom = random.Next(-2, 2);

                while (xRandom == 0 && yRandom == 0)
                {
                    yRandom = random.Next(-2, 2);
                    xRandom = random.Next(-2, 2);
                }
                
                

                Vector2F newVelocity = new Vector2F(xRandom, yRandom);
                newVelocity = Vector2F.Normalize(newVelocity) * 3.0f; 

                rb.Body.LinearVelocity = newVelocity;
            }
        }

        /// <summary>
        /// Ons the collision exit using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionExit(GameObject gameObject)
        {
            
        }

        /// <summary>
        /// Decreases the health
        /// </summary>
        public void DecreaseHealth()
        {
            health -= 1;
            Console.WriteLine("Asteroid health: " + health);
        }*/

        public void Init(IGameObject self)
        {
                
        }

        public void Update(IGameObject self)
        {
          
        }
    }
}