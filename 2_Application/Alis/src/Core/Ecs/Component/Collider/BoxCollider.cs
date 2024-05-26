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
using System.Diagnostics.CodeAnalysis;
using Alis.Builder.Core.Ecs.Component.Collider;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Figure;
using Sprite = Alis.Core.Ecs.Component.Render.Sprite;

namespace Alis.Core.Ecs.Component.Collider
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="ACollider" />
    public class BoxCollider : ACollider, IBuilder<BoxColliderBuilder>
    {
        /// <summary>
        ///     The rectangle shape
        /// </summary>
        public RectangleF RectangleF;
        
        /// <summary>
        ///     Gets or sets the value of the is trigger
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
        [ExcludeFromCodeCoverage]
        public Physic.Dynamics.Body Body { get; private set; }
        
        /// <summary>
        ///     Gets or sets the value of the auto tilling
        /// </summary>
        public bool AutoTilling { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the body type
        /// </summary>
        public BodyType BodyType { get; set; } = BodyType.Static;
        
        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        public float Restitution { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        public float Friction { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the fixed rotation
        /// </summary>
        public bool FixedRotation { get; set; }
        
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
        public Vector2 LinearVelocity { get; set; } = Vector2.Zero;
        
        /// <summary>
        ///     Gets or sets the value of the angular velocity
        /// </summary>
        public float AngularVelocity { get; set; }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Builder() => new BoxColliderBuilder();
        
        /// <summary>
        ///     Inits this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnInit()
        {
            if (AutoTilling)
            {
                if (GameObject.Contains<Sprite>())
                {
                    Width = GameObject.Get<Sprite>().Image.Size.X * GameObject.Transform.Scale.X;
                    Height = GameObject.Get<Sprite>().Image.Size.Y * GameObject.Transform.Scale.Y;
                }
            }
            else
            {
                Width *= GameObject.Transform.Scale.X;
                Height *= GameObject.Transform.Scale.Y;
            }
        }
        
        /// <summary>
        ///     Awakes this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnAwake()
        {
            RectangleF = new RectangleF
            {
                x = GameObject.Transform.Position.X + RelativePosition.X - Width / 2,
                y = GameObject.Transform.Position.Y + RelativePosition.Y - Height / 2,
                w = Width,
                h = Height
            };
            
            
            Body = new Rectangle(
                Width,
                Height,
                new Vector2(
                    GameObject.Transform.Position.X + RelativePosition.X,
                    GameObject.Transform.Position.Y + RelativePosition.Y
                ),
                LinearVelocity,
                BodyType,
                Rotation,
                AngularVelocity,
                0,
                0,
                false,
                true,
                FixedRotation,
                true,
                true,
                GravityScale
            );
            
            Body.Restitution = Restitution;
            Body.Friction = Friction;
            Body.FixedRotation = FixedRotation;
            Body.Mass = Mass;
            Body.SleepingAllowed = false;
            Body.IsBullet = true;
            Body.GravityScale = GravityScale;
            Body.LinearVelocity = LinearVelocity;
            Body.Awake = true;
            Body.IsSensor = IsTrigger;
            Body.GameObject = GameObject;
            
            Body.OnCollision += OnCollision;
            Body.OnSeparation += OnSeparation;
            
            Context.GraphicManager.Attach(this);
            Context.PhysicManager.Attach(Body);
        }
        
        /// <summary>
        ///     Ons the separation using the specified fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture a</param>
        /// <param name="fixtureB">The fixture b</param>
        /// <param name="contact">The contact</param>
        [ExcludeFromCodeCoverage]
        private void OnSeparation(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            GameObject fixtureGameObject = (GameObject) fixtureA.Body.GameObject;
            GameObject fixtureBGameObject = (GameObject) fixtureB.Body.GameObject;
            
            if (fixtureGameObject.Equals(GameObject) && fixtureBGameObject.Contains<BoxCollider>())
            {
                fixtureBGameObject.Components.ForEach(i => i.OnCollisionExit(GameObject));
            }
            else if (fixtureBGameObject.Equals(GameObject) && fixtureGameObject.Contains<BoxCollider>())
            {
                fixtureGameObject.Components.ForEach(i => i.OnCollisionExit(GameObject));
            }
        }
        
        /// <summary>
        ///     Ons the collision using the specified fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture a</param>
        /// <param name="fixtureB">The fixture b</param>
        /// <param name="contact">The contact</param>
        [ExcludeFromCodeCoverage]
        private void OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            GameObject fixtureGameObject = (GameObject) fixtureA.Body.GameObject;
            GameObject fixtureBGameObject = (GameObject) fixtureB.Body.GameObject;
            
            if (fixtureGameObject.Equals(GameObject) && fixtureBGameObject.Contains<BoxCollider>())
            {
                fixtureBGameObject.Components.ForEach(i => i.OnCollisionEnter(GameObject));
            }
            else if (fixtureBGameObject.Equals(GameObject) && fixtureGameObject.Contains<BoxCollider>())
            {
                fixtureGameObject.Components.ForEach(i => i.OnCollisionEnter(GameObject));
            }
        }
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void OnStart()
        {
            Logger.Trace();
        }
        
        /// <summary>
        ///     Before the update
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnBeforeUpdate()
        {
            float xOdl = GameObject.Transform.Position.X;
            float yOld = GameObject.Transform.Position.Y;
            
            float xNew = Body.Position.X;
            float yNew = Body.Position.Y;
            
            if (Math.Abs(xOdl - xNew) >= 1.1f)
            {
                Transform transform = new Transform
                {
                    Position = new Vector2(Body.Position.X, GameObject.Transform.Position.Y),
                    Rotation = new Rotation(Body.Rotation),
                    Scale = GameObject.Transform.Scale
                };
                
                GameObject.Transform = transform;
            }
            
            if (Math.Abs(yOld - yNew) >= 1.1f)
            {
                Transform transform = new Transform
                {
                    Position = new Vector2(GameObject.Transform.Position.X, Body.Position.Y),
                    Rotation = new Rotation(Body.Rotation),
                    Scale = GameObject.Transform.Scale
                };
                
                GameObject.Transform = transform;
            }
        }
        
        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void OnUpdate()
        {
            Logger.Trace();
        }
        
        /// <summary>
        ///     Draws this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnDraw()
        {
            RectangleF.x = GameObject.Transform.Position.X + RelativePosition.X - Width / 2;
            RectangleF.y = GameObject.Transform.Position.Y + RelativePosition.Y - Height / 2;
        }
        
        /// <summary>
        ///     Ons the exit
        /// </summary>
        [ExcludeFromCodeCoverage]
        public override void OnExit()
        {
            Context.GraphicManager.UnAttach(this);
            Context.PhysicManager.UnAttach(Body);
        }
    }
}