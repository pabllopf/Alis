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
using Alis.Builder.Core.Ecs.Component.Collider;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
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

        private const float PIXELS_PER_METER = 32.0f;

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void OnInit()
        {
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void OnAwake()
        {
            Body = Context.PhysicManager.World.CreateRectangle(
                Width,
                Height,
                1.0f,
                new Vector2(GameObject.Transform.Position.X + RelativePosition.X, GameObject.Transform.Position.Y + RelativePosition.Y),
                Rotation,
                BodyType);

            Body.SetRestitution(Restitution);
            Body.SetFriction(Friction);
            Body.FixedRotation = FixedRotation;
            Body.Mass = Mass;
            Body.SleepingAllowed = false;
            Body.IsBullet = true;
            Body.IgnoreGravity = false;
            Body.LinearVelocity = LinearVelocity;
            Body.Awake = true;
            Body.SetIsSensor(IsTrigger);
            Body.Tag = GameObject;
            Context.GraphicManager.Attach(this);
        }
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Before the update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            //GameObject.Transform = new Transform(Body.Position, Body.Rotation, GameObject.Transform.Scale);
        }
        
        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void OnUpdate()
        {
            GameObject.Transform.Position = new Vector2(Body.Position.X,Body.Position.Y);
            GameObject.Transform.Rotation =Body.Rotation;

            // If the collider contains a camera, update the camera position
            if (GameObject.Contains<Camera>())
            {
                Camera camera = GameObject.Get<Camera>();
                camera.Position.X =GameObject.Transform.Position.X;
                camera.Position.Y =GameObject.Transform.Position.Y;
            }
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public override void OnDraw()
        {
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
        }
    }
}