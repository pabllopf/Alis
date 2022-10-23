// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxCollider.cs
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
using Alis.Builder.Core.Component.Collider;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.SFML;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Manager.Graphic;
using Alis.Core.Manager.Physic;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Factories;

namespace Alis.Core.Component.Collider
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="ColliderBase" />
    public class BoxCollider : ColliderBase, IBuilder<BoxColliderBuilder>
    {
         /// <summary>
        ///     The rectangle shape
        /// </summary>
        private RectangleShape rectangleShape;
         
         
         /// <summary>
         /// Initializes a new instance of the <see cref="BoxCollider"/> class
         /// </summary>
         public BoxCollider()
         {
         }

         /// <summary>
         /// The is dynamic
         /// </summary>
         public bool IsDynamic { get; set; }
         
         /// <summary>
         /// Gets or sets the value of the is trigger
         /// </summary>
         public bool IsTrigger { get; set; }
         
         /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>
        public float Width { get; set; } = 10.0f;

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>
        public float Height { get; set; } = 10.0f;

        /// <summary>
        ///     Gets or sets the value of the density
        /// </summary>
        public float Density { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the value of the rotation
        /// </summary>
        public float Rotation { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the value of the relative position
        /// </summary>
        public Vector2 RelativePosition { get; set; } = new Vector2(0, 0);

        /// <summary>
        ///     Gets or sets the value of the body
        /// </summary>
        public Systems.Physics2D.Dynamics.Body Body { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the auto tilling
        /// </summary>
        public bool AutoTilling { get; set; } = false;

        /// <summary>
        ///     Gets or sets the value of the body type
        /// </summary>
        public BodyType BodyType { get; set; } = BodyType.Static;
        
        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        public float Restitution { get; set; } = 0.0f;

        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        public float Friction { get; set; } = 0.0f;

        /// <summary>
        ///     Gets or sets the value of the fixed rotation
        /// </summary>
        public bool FixedRotation { get; set; } = false;

        /// <summary>
        ///     Gets or sets the value of the mass
        /// </summary>
        public float Mass { get; set; } = 10.0f;

        /// <summary>
        ///     Gets or sets the value of the gravity scale
        /// </summary>
        public float GravityScale { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the value of the linear velocity
        /// </summary>
        public System.Numerics.Vector2 LinearVelocity { get; set; } = System.Numerics.Vector2.Zero;
        
        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The box collider builder</returns>
        public new BoxColliderBuilder Builder() => new BoxColliderBuilder();
        
        /// <summary>
        /// Inits this instance
        /// </summary>
        public override void Init()
        {
            
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            if (AutoTilling)
            {
                if (GameObject.Contains<Alis.Core.Component.Render.Sprite>())
                {
                    Width = GameObject.GetComponent<Alis.Core.Component.Render.Sprite>().sprite.Texture.Size.X * GameObject.Transform.Scale.X;
                    Height = GameObject.GetComponent<Alis.Core.Component.Render.Sprite>().sprite.Texture.Size.Y * GameObject.Transform.Scale.Y;
                }
            }
            
            
            rectangleShape = new RectangleShape(new Vector2F(Width, Height));
            //Console.WriteLine($"Name={GameObject.Name} rectangleShape.Size={rectangleShape.Size}");
            Vector2F pos = new Vector2F(
                (GameObject.Transform.Position.X + RelativePosition.X) - ((Width) / 2),
                (GameObject.Transform.Position.Y + RelativePosition.Y) - ((Height) / 2)
                );

            //Vector2f pos = new Vector2f(GameObject.Transform.Position.X, GameObject.Transform.Position.Y);
            
            
            rectangleShape.Position = pos;
            rectangleShape.FillColor = Color.Transparent;
            rectangleShape.OutlineColor = Color.Green;
            rectangleShape.OutlineThickness = 1f;
            
            //Console.WriteLine($"Name={GameObject.Name} rectangleShape.Position={rectangleShape.Position}");
            
            GraphicManager.Colliders.Add(rectangleShape);


            Body = CreateBody();

            //Transform transform;
            //Body.GetTransform(out transform);
            
            
            
            Console.WriteLine($"Name={GameObject.Name} rectangleShape.Position={rectangleShape.Position}");
            Console.WriteLine($"Name={GameObject.Name} rectangleShape.Size={rectangleShape.Size}");
            Console.WriteLine($"Name={GameObject.Name} rectangleShape.Rotation={rectangleShape.Rotation}");

            
            Console.WriteLine($"Name={GameObject.Name} Body.Position={Body.Position}");
            Console.WriteLine($"Name={GameObject.Name} Body.Size=x{Width}y{Height}");
            Console.WriteLine($"Name={GameObject.Name} Body.Rotation={Body.Rotation}");

            /*
            Body = BodyFactory.CreateRectangle(
                world: PhysicsSystem.World, 
                width: Width, 
                height: Height, 
                density: Density, 
                position: new Vector2(
                    GameObject.Transform.Position.X + RelativePosition.X, 
                    GameObject.Transform.Position.Y + RelativePosition.Y),   
                rotation: Rotation, 
                bodyType: BodyType, 
                userData: this.GameObject);
            
            Body.Restitution = Restitution;
            Body.Friction = Friction;
            Body.FixedRotation = FixedRotation;
            Body.Mass = Mass;
            Body.SleepingAllowed = false;
            Body.IsBullet = true;*/
        }

        /// <summary>
        ///     Creates the body
        /// </summary>
        /// <returns>The body</returns>
        private Systems.Physics2D.Dynamics.Body CreateBody()
        {
            if (IsDynamic)
            {
                BodyType = BodyType.Dynamic;
            }
            
            Systems.Physics2D.Dynamics.Body body = BodyFactory.CreateRectangle(
                world: PhysicManager.World, 
                width: Width , 
                height: Height, 
                density: Density, 
                position: new System.Numerics.Vector2(
                    (GameObject.Transform.Position.X ) + RelativePosition.X,
                    (GameObject.Transform.Position.Y ) + RelativePosition.Y
                    ), 
                rotation: Rotation, 
                bodyType: BodyType, 
                userData: this.GameObject);
            
            body.Restitution = Restitution;
            body.Friction = Friction;
            body.FixedRotation = FixedRotation;
            body.Mass = Mass;
            body.SleepingAllowed = false;
            body.IsBullet = true;
            body.GravityScale = GravityScale;
            body.LinearVelocity = LinearVelocity;
            body.Awake = true;
            body.IsSensor = IsTrigger;

            return body;
            
            
            
            /*
            BodyDef bodyDef = new BodyDef
            {
                enabled = IsActive,
                type = BodyType,
                position = new Vector2(
                    GameObject.Transform.Position.X + RelativePosition.X,
                    GameObject.Transform.Position.Y + RelativePosition.Y),
                angle = Rotation,
                linearVelocity = LinearVelocity,
                angularVelocity = 0.0f,
                linearDamping = 0.0f,
                angularDamping = 0.0f,
                allowSleep = false,
                awake = true,
                fixedRotation = FixedRotation,
                bullet = true,
                gravityScale = GravityScale,
                userData = GameObject
            };

            FixtureDef fixtureDef = new FixtureDef
            {
                friction = Friction,
                restitution = Restitution,
                density = Density,
                isSensor = IsTrigger,
                filter =
                {
                    categoryBits = 1,
                    maskBits = 65535,
                    groupIndex = 0
                },
                userData = GameObject,
                //shape = new PolygonShape(Width / 2, Height / 2)
                shape = new PolygonShape(Width, Height)
            };

            Body body = PhysicsSystem.World.CreateBody(bodyDef);
            body.CreateFixture(fixtureDef);
            return body;*/
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
           
        }

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
            GameObject.Transform.Position = new Vector2(Body.Position.X, Body.Position.Y);
            GameObject.Transform.Rotation = Body.Rotation;
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            
        }

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
        }

        /// <summary>
        /// Draws this instance
        /// </summary>
        public override void Draw()
        {
            Vector2F pos = new Vector2F(
                (GameObject.Transform.Position.X + RelativePosition.X) - ((Width) / 2),
                (GameObject.Transform.Position.Y + RelativePosition.Y) - ((Height) / 2)
            );
            rectangleShape.Position = pos;
            rectangleShape.Rotation = GameObject.Transform.Rotation;
        }
    }
}