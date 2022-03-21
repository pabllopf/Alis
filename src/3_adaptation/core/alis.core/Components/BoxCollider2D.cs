// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BoxCollider2D.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using Alis.Core.Physics2D.Collision.Shapes;
using Alis.Core.Physics2D.Dynamics.Bodies;
using Alis.Core.Physics2D.Dynamics.Fixtures;
using Alis.Core.Systems;
using SFML.Graphics;
using SFML.System;

namespace Alis.Core.Components
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="Collider" />
    public class BoxCollider2D : Collider
    {
        /// <summary>
        /// The rectangle shape
        /// </summary>
        private RectangleShape rectangleShape;
        /// <summary>
        /// Gets or sets the value of the width
        /// </summary>
        public float Width { get; set; } = 10.0f;

        /// <summary>
        /// Gets or sets the value of the height
        /// </summary>
        public float Height { get; set; } = 10.0f;

        /// <summary>
        /// Gets or sets the value of the density
        /// </summary>
        public float Density { get; set; } = 1.0f;

        /// <summary>
        /// Gets or sets the value of the rotation
        /// </summary>
        public float Rotation { get; set; } = 1.0f;

        /// <summary>
        /// Gets or sets the value of the relative position
        /// </summary>
        public Vector2 RelativePosition { get; set; } = new Vector2(0, 0);

        /// <summary>
        /// Gets or sets the value of the body
        /// </summary>
        public Body Body { get; private set; }

        /// <summary>
        /// Gets or sets the value of the auto tilling
        /// </summary>
        public bool AutoTilling { get; set; } = false;

        /// <summary>
        /// Gets or sets the value of the body type
        /// </summary>
        public BodyType BodyType { get; set; } = BodyType.Static;


        /// <summary>
        /// Gets or sets the value of the restitution
        /// </summary>
        public float Restitution { get; set; } = 0.0f;
        /// <summary>
        /// Gets or sets the value of the friction
        /// </summary>
        public float Friction { get; set; } = 0.0f;
        /// <summary>
        /// Gets or sets the value of the fixed rotation
        /// </summary>
        public bool FixedRotation { get; set; } = false;
        /// <summary>
        /// Gets or sets the value of the mass
        /// </summary>
        public float Mass { get; set; } = 10.0f;

        /// <summary>
        /// Gets or sets the value of the gravity scale
        /// </summary>
        public float GravityScale { get; set; } = 1.0f;

        /// <summary>
        /// Gets or sets the value of the linear velocity
        /// </summary>
        public Vector2 LinearVelocity { get; set; } = Vector2.Zero;

        /// <summary>
        /// Awakes this instance
        /// </summary>
        public override void Awake()
        {
            if (AutoTilling)
            {
                if (GameObject.Contains<Sprite>())
                {
                    Width = GameObject.Get<Sprite>().Size.X * GameObject.Transform.Scale.X;
                    Height = GameObject.Get<Sprite>().Size.Y * GameObject.Transform.Scale.Y;
                    Console.WriteLine($" {Width} {Height}");
                }
            }

            rectangleShape = new RectangleShape(new Vector2f(Width, Height));
            ;
            rectangleShape.Position = new Vector2f(
                GameObject.Transform.Position.X + RelativePosition.X,
                GameObject.Transform.Position.Y + RelativePosition.Y);
            rectangleShape.FillColor = Color.Transparent;
            rectangleShape.OutlineColor = Color.Green;
            rectangleShape.OutlineThickness = 1f;
            PhysicsSystem.Attach(this);


            Body = CreateBody();

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
        /// Creates the body
        /// </summary>
        /// <returns>The body</returns>
        private Body CreateBody()
        {
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
            return body;
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        /// Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
            rectangleShape.Position = new Vector2f(Body.Position.X, Body.Position.Y);
            rectangleShape.Rotation = Body.GetAngle();
            GameObject.Transform.Position = new Vector3(Body.Position.X, Body.Position.Y, 0);
            GameObject.Transform.Rotation = new Vector3(0, Body.GetAngle(), 0);
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
        }

        /// <summary>
        /// Gets the drawable
        /// </summary>
        /// <returns>The drawable</returns>
        public override Drawable GetDrawable() => rectangleShape;


        /*
        /// <summary>
        /// The size
        /// </summary>
        private Vector2 size;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BoxCollider2D" /> class
        /// </summary>
        public BoxCollider2D()
        {
            AutoTiling = true;
            Size = new Vector2(1.0f, 1.0f);
            RelativePosition = new Vector2(0.0f, 0.0f);
            Level = 100;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxCollider2D"/> class
        /// </summary>
        /// <param name="autoTiling">The auto tiling</param>
        public BoxCollider2D(bool autoTiling)
        {
            AutoTiling = true;
            Size = new Vector2(1.0f, 1.0f);
            RelativePosition = new Vector2(0.0f, 0.0f);
            Level = 100;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BoxCollider2D" /> class
        /// </summary>
        /// <param name="autoTiling">The auto tiling</param>
        /// <param name="size">The size</param>
        /// <param name="relativePosition">The relative position</param>
        [JsonConstructor]
        public BoxCollider2D(bool autoTiling, Vector2 size, Vector2 relativePosition)
        {
            AutoTiling = autoTiling;
            Size = size;
            RelativePosition = relativePosition;
            Level = 100;
        }
        
        public static BoxCollider2DBuilder Builder() => new BoxCollider2DBuilder();

        /// <summary>
        ///     Gets or sets the value of the rectangle
        /// </summary>
        public Body Body { get; set; }

        /// <summary>
        ///     Gets or sets the value of the body type
        /// </summary>
        public BodyType BodyType { get; set; } = BodyType.Static;

        /// <summary>
        ///     Gets or sets the value of the rectangle shape
        /// </summary>
        private RectangleShape? RectangleShape { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the auto tiling
        /// </summary>
        [JsonPropertyName("_AutoTiling")]
        public bool AutoTiling { get; set; }

        /// <summary>
        ///     Gets or sets the value of the relative position
        /// </summary>
        [JsonPropertyName("_RelativePosition")]
        public Vector2 RelativePosition { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [JsonPropertyName("_Size")]
        public Vector2 Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        ///     Creates the instance
        /// </summary>
        /// <returns>The box collider</returns>
        public static BoxCollider2D CreateInstance() => new BoxCollider2D();

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            if (AutoTiling)
            {
                Logger.Log($"{nameof(BoxCollider2D)}: Auto tiling enabled");
                if (GameObject.Contains(nameof(Sprite)))
                {
                    Size = GameObject.Get<Sprite>(nameof(Sprite)).Size;
                    Logger.Log($"{nameof(Entities.GameObject)}='{GameObject.Name}' size is set to {Size}");
                }
            }

           
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            RectangleShape = new RectangleShape(new Vector2f(Size.X, Size.Y));
            RectangleShape.FillColor = Color.Transparent;
            RectangleShape.OutlineColor = Color.Green;
            RectangleShape.OutlineThickness = 1f;
            PhysicsManager.Attach(this);

            Body = BodyFactory.CreateRectangle(world: PhysicsManager.World, 
                width: Size.X, 
                height: Size.Y, 
                density: 1f,
                position: new Vector2(GameObject.Transform.Position.X, GameObject.Transform.Position.Y), 
                rotation: GameObject.Transform.Rotation.Y);
            Body.BodyType = BodyType;
            Body.FixedRotation = true;
            Body.Friction = 0;
            Body.Inertia = 0;
            
            if (IsTrigger)
            {
                
                Body.IsSensor = !IsTrigger;
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            GameObject.Transform.Position = new Vector3(Body.Position.X, Body.Position.Y, 0);
            Body.Rotation = GameObject.Transform.Rotation.Y;
            
            if (RectangleShape is not null)
            {
                RectangleShape.Rotation = Body.Rotation;
                RectangleShape.Position = new Vector2f(Body.Position.X, Body.Position.Y);
                RectangleShape.Size = new Vector2f(Size.X, Size.Y);
            }
        }

        public override void Stop()
        {
            
        }

        public override void Exit()
        {
            
        }


        /// <summary>
        ///     Gets the drawable
        /// </summary>
        /// <returns>The drawable</returns>
        public override Drawable GetDrawable() => RectangleShape ?? throw new NullReferenceException();*/
    }
}