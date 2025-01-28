using System;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System.Manager.Time;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Asteroid
{
    /// <summary>
    /// The player movement class
    /// </summary>
    /// <seealso cref="AComponent"/>
    public class Player : AComponent
    {
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider boxCollider;
        
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
        public override void OnStart()
        {
            boxCollider = this.GameObject.Get<BoxCollider>();
        }
        
        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            float targetRotationDegrees = CalculateRotationInDegrees(direction.X, direction.Y);
            boxCollider.Body.Rotation = targetRotationDegrees;
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
        public override void OnPressDownKey(KeyCodes key)
        {
            if (key == KeyCodes.D)
            {
                direction.X = 1;
            }

            if (key == KeyCodes.A)
            {
                direction.X = -1;
            }

            if (key == KeyCodes.W)
            {
                direction.Y = 1;
            }

            if (key == KeyCodes.S)
            {
                direction.Y = -1;
            }

            if (key == KeyCodes.A || key == KeyCodes.D || key == KeyCodes.W || key == KeyCodes.S)
            {
                this.boxCollider.Body.ApplyForce(direction * acceleration);
            }

        }

        /// <summary>
        /// Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(KeyCodes key)
        {
            if (key == KeyCodes.Space)
            {
                GameObject bullet = new GameObject();
                bullet.Name = $"Bullet_{Context.TimeManager.FrameCount}";
        
                Transform transform = bullet.Transform;
                transform.Position = this.GameObject.Transform.Position; // Set the bullet's initial position to the player's position
                transform.Scale = new Vector2F(0.25f, 0.25f);
                bullet.Transform = transform;
        
                bullet.Add(new Sprite().Builder()
                    .SetTexture("asteroid_0.bmp")
                    .Depth(1)
                    .Build());
                
                int bulletSpeed = 5;
                Vector2F velo = new Vector2F(direction.X * bulletSpeed, direction.Y * bulletSpeed);
                
                bullet.Add(new BoxCollider()
                    .Builder()
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
                    .Build());
                
                bullet.Add(new Bullet());
                
                Context.SceneManager.CurrentScene.Add(bullet);
            }
        }

        /// <summary>
        /// Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(KeyCodes key)
        {
        }
    }
}