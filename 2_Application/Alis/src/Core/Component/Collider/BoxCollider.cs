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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Figure.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Manager.Graphic;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Figure;
using Sprite = Alis.Core.Component.Render.Sprite;

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
        public Physic.Dynamics.Body Body { get; private set; }

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
        public Vector2 LinearVelocity { get; set; } = Vector2.Zero;

        /// <summary>
        ///     Gets or sets the value of the angular velocity
        /// </summary>
        public float AngularVelocity { get; set; } = 0.0f;

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Builder() => new BoxColliderBuilder();

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            if (AutoTilling)
            {
                if (GameObject.Contains<Sprite>())
                {
                    //Width = GameObject.GetComponent<Sprite>()..Texture.Size.X * GameObject.Transform.Scale.X;
                    //Height = GameObject.GetComponent<Sprite>().SpriteSfml.Texture.Size.Y * GameObject.Transform.Scale.Y;
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
        public override void Awake()
        {
            RectangleF = new RectangleF
            {
                x =  (GameObject.Transform.Position.X + RelativePosition.X - Width / 2),
                y = (GameObject.Transform.Position.Y + RelativePosition.Y - Height / 2),
                w =  Width,
                h =  Height
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

            GraphicManager.AttachCollider(this);
            VideoGame.PhysicManager.AttachBody(Body);
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Before the update
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
            Logger.Trace();
        }

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public override void Draw()
        {
            RectangleF.x =  (GameObject.Transform.Position.X + RelativePosition.X - Width / 2);
            RectangleF.y =  (GameObject.Transform.Position.Y + RelativePosition.Y - Height / 2);
        }
    }
}