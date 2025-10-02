
using System;
using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Asteroid
{
    public class Player : IOnStart, IOnUpdate, IOnReleaseKey, IOnPressKey, IOnHoldKey, IHasContext<Context>
    {
        
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider boxCollider;
        
        private AudioSource audioSource;
        
        private IGameObject gameObject;
        
        /// <summary>
        /// The vector
        /// </summary>
        Vector2F direction = new Vector2F(0, 0);

        /// <summary>
        /// The acceleration
        /// </summary>
        public float acceleration = 2.0f;
        
        /// <summary>
        /// Ons the start
        /// </summary>
        public void OnStart(IGameObject self)
        {
            boxCollider = self.Get<BoxCollider>();
            audioSource = self.Get<AudioSource>();
            gameObject = self;
        }
        
        
        /// <summary>
        /// Ons the update
        /// </summary>
        public void OnUpdate(IGameObject self)
        {
            float targetRotationDegrees = CalculateRotationInDegrees(direction.X, direction.Y);
            boxCollider.Body.Rotation = targetRotationDegrees;
        
            // Limit the maximum velocity
            float maxVelocity = 3.0f; // Set your desired maximum velocity
            Vector2F currentVelocity = boxCollider.Body.LinearVelocity;
            if (currentVelocity.Length() > maxVelocity)
            {
                currentVelocity = Vector2F.Normalize(currentVelocity) * maxVelocity;
                boxCollider.Body.LinearVelocity = currentVelocity;
            }
        }

        /// <summary>
        /// Calculates the rotation in degrees using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The angle</returns>
        private float CalculateRotationInDegrees(float x, float y)
        {
            float angle = 0.0f;

            if (x == 0)
            {
                if (y > 0)
                {
                    angle = 0.0f;
                }
                else if (y < 0)
                {
                    angle = 180.0f;
                }
            }
            else if (y == 0)
            {
                if (x > 0)
                {
                    angle = 270.0f;
                }
                else if (x < 0)
                {
                    angle = 90.0f;
                }
            }
            else
            {
                if (x > 0 && y > 0)
                {
                    angle = 315;
                    //Console.WriteLine("angle: " + angle);
                }

                if (x < 0 && y > 0)
                {
                    angle = 45;
                    //Console.WriteLine("angle: " + angle);
                }

                if (x < 0 && y < 0)
                {
                    angle = 135;
                    //Console.WriteLine("angle: " + angle);
                }

                if (x > 0 && y < 0)
                {
                    angle = 225;
                    //Console.WriteLine("angle: " + angle);
                }
            }

            return angle;
        }

        /// <summary>
        /// Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public void OnPressKey(KeyEventInfo info)
        {
            ConsoleKey key = info.Key;
            if (key == ConsoleKey.Spacebar && (direction.X != 0 || direction.Y != 0))
            {
                audioSource.Play();
                //this.Context.SceneManager.CurrentScene.GetByTag("Points").Get<CounterManager>().Decrement();
                
                
                
                //bullet.Name = $"Bullet_{Context.TimeManager.FrameCount}";
        
                Transform transform = gameObject.Get<Transform>();
                Transform t = new Transform();
                t.Position = new Vector2F(transform.Position.X, transform.Position.Y);
                t.Scale = new Vector2F(1, 1);
                
                Sprite s = new SpriteBuilder(Context)
                    .SetTexture("asteroid_0.bmp")
                    .Depth(1)
                    .Build();
                
                
                int bulletSpeed = 5;
                Vector2F velo = new Vector2F(direction.X * bulletSpeed, direction.Y * bulletSpeed);

                BoxCollider box = new BoxColliderBuilder(Context)
                    .IsActive(true)
                    .BodyType(BodyType.Dynamic)
                    .IsTrigger(true)
                    .AutoTilling(false)
                    .Size(0.25F, 0.25F)
                    .Rotation(0.0f)
                    .RelativePosition(0, 0)
                    .LinearVelocity(velo.X, velo.Y)
                    .Mass(1.0f)
                    .Restitution(1f)
                    .Friction(0f)
                    .FixedRotation(true)
                    .IgnoreGravity(true)
                    .Build();
                
                var bullet = Context.SceneManager.CurrentWorld.Create<Transform, Sprite, BoxCollider, Bullet>(t, s, box, new Bullet());
                
                
                box.Context = this.Context;
                s.Context = this.Context;
                
                box.OnStart(bullet);
                s.OnStart(bullet);
                
                
            }
        }

        public void OnReleaseKey(KeyEventInfo info)
        {
            
        }

        public void OnHoldKey(KeyEventInfo info)
        {
            ConsoleKey key = info.Key;
            if (key == ConsoleKey.D)
            {
                direction.X = 1;
            }

            if (key == ConsoleKey.A)
            {
                direction.X = -1;
            }

            if (key == ConsoleKey.W)
            {
                direction.Y = 1;
            }

            if (key == ConsoleKey.S)
            {
                direction.Y = -1;
            }

            if (key == ConsoleKey.A || key == ConsoleKey.D || key == ConsoleKey.W || key == ConsoleKey.S)
            {
                this.boxCollider.Body.ApplyForce(direction * acceleration);
            }
        }

        public Context Context { get; set; }
    }
}