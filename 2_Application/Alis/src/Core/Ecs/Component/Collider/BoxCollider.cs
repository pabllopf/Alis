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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Ecs.Component.Collider
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="ACollider" />
    public class BoxCollider : ACollider, IHasBuilder<BoxColliderBuilder>
    {
        /// <summary>
        ///     The rectangle
        /// </summary>
        [JsonIgnore]
        private RectangleI rectangle;

        /// <summary>
        ///     Gets or sets the value of the is trigger
        /// </summary>
        [JsonPropertyName("_IsTrigger_")]
        public bool IsTrigger { get; set; }

        /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>
        [JsonPropertyName("_Width_")]
        public float Width { get; set; }

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>
        [JsonPropertyName("_Height_")]
        public float Height { get; set; }

        /// <summary>
        ///     Gets or sets the value of the rotation
        /// </summary>
        [JsonPropertyName("_Rotation_")]
        public float Rotation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the relative position
        /// </summary>
        [JsonPropertyName("_RelativePosition_")]
        public Vector2F RelativePosition { get; set; }

        /// <summary>
        ///     Gets or sets the value of the body
        /// </summary>
        [JsonIgnore]
        public Physic.Dynamics.Body Body { get; set; }

        /// <summary>
        ///     Gets or sets the value of the auto tilling
        /// </summary>
        [JsonPropertyName("_AutoTilling_")]
        public bool AutoTilling { get; set; }

        /// <summary>
        ///     Gets or sets the value of the body type
        /// </summary>
        [JsonPropertyName("_BodyType_")]
        public BodyType BodyType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        [JsonPropertyName("_Restitution_")]
        public float Restitution { get; set; }

        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        [JsonPropertyName("_Friction_")]
        public float Friction { get; set; }

        /// <summary>
        ///     Gets or sets the value of the fixed rotation
        /// </summary>
        [JsonPropertyName("_FixedRotation_")]
        public bool FixedRotation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the mass
        /// </summary>
        [JsonPropertyName("_Mass_")]
        public float Mass { get; set; }

        /// <summary>
        ///     Gets or sets the value of the gravity scale
        /// </summary>
        [JsonPropertyName("_IgnoreGravity_")]
        public bool IgnoreGravity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the linear velocity
        /// </summary>
        [JsonPropertyName("_LinearVelocity_")]
        public Vector2F LinearVelocity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the angular velocity
        /// </summary>
        [JsonPropertyName("_AngularVelocity_")]
        public float AngularVelocity { get; set; }

        public BoxCollider()
        {
            Width = 10;
            Height = 10;
            Rotation = 0;
            RelativePosition = new Vector2F(0, 0);
            AutoTilling = false;
            BodyType = BodyType.Static;
            Restitution = 0.5f;
            Friction = 0.5f;
            FixedRotation = false;
            Mass = 1.0f;
            IgnoreGravity = false;
            LinearVelocity = new Vector2F(0, 0);
            AngularVelocity = 0;
        }
        
        [JsonConstructor]
        public BoxCollider(
            bool isTrigger,
            float width,
            float height,
            float rotation,
            Vector2F relativePosition,
            bool autoTilling,
            BodyType bodyType,
            float restitution,
            float friction,
            bool fixedRotation,
            float mass,
            bool ignoreGravity,
            Vector2F linearVelocity,
            float angularVelocity)
        {
            IsTrigger = isTrigger;
            Width = width;
            Height = height;
            Rotation = rotation;
            RelativePosition = relativePosition;
            AutoTilling = autoTilling;
            BodyType = bodyType;
            Restitution = restitution;
            Friction = friction;
            FixedRotation = fixedRotation;
            Mass = mass;
            IgnoreGravity = ignoreGravity;
            LinearVelocity = linearVelocity;
            AngularVelocity = angularVelocity;
        }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Builder() => new BoxColliderBuilder();

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
                Width * GameObject.Transform.Scale.X,
                Height * GameObject.Transform.Scale.Y,
                1.0f,
                new Vector2F(GameObject.Transform.Position.X + RelativePosition.X, GameObject.Transform.Position.Y + RelativePosition.Y),
                Rotation,
                BodyType);

            Body.SetRestitution(Restitution);
            Body.SetFriction(Friction);
            Body.FixedRotation = FixedRotation;
            Body.Mass = Mass;
            Body.SleepingAllowed = false;
            Body.IsBullet = true;
            Body.IgnoreGravity = IgnoreGravity;
            Body.LinearVelocity = LinearVelocity;
            Body.Awake = true;
            Body.SetIsSensor(IsTrigger);
            Body.Tag = GameObject;
            Context.GraphicManager.Attach(this);

            Body.OnCollision += OnCollision;
            Body.OnSeparation += OnSeparation;
        }

        /// <summary>
        ///     Describes whether this instance on collision
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="contact">The contact</param>
        /// <returns>The bool</returns>
        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            GameObject fixtureGameObject = (GameObject) fixtureA.Body.Tag;
            GameObject fixtureBGameObject = (GameObject) fixtureB.Body.Tag;

            if (fixtureGameObject.Equals(GameObject) && fixtureBGameObject.Contains<BoxCollider>())
            {
                fixtureBGameObject.Components.ForEach(i => i.OnCollisionEnter(GameObject));
            }
            else if (fixtureBGameObject.Equals(GameObject) && fixtureGameObject.Contains<BoxCollider>())
            {
                fixtureGameObject.Components.ForEach(i => i.OnCollisionEnter(GameObject));
            }

            return true;
        }

        /// <summary>
        ///     Ons the separation using the specified fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="contact">The contact</param>
        private void OnSeparation(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            GameObject fixtureGameObject = (GameObject) fixtureA.Body.Tag;
            GameObject fixtureBGameObject = (GameObject) fixtureB.Body.Tag;

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
            GameObject.Transform = new Transform(Body.Position, Body.Rotation, GameObject.Transform.Scale);

            // If the collider contains a camera, update the camera position
            if (GameObject.Contains<Camera>())
            {
                Camera camera = GameObject.Get<Camera>();
                camera.Position.X = GameObject.Transform.Position.X;
                camera.Position.Y = GameObject.Transform.Position.Y;
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
            Context.GraphicManager.UnAttach(this);
            Context.PhysicManager.World.Remove(Body);
        }

        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        /// <param name="debugColor">The debug color</param>
        public void Render(IntPtr renderer, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter, Color debugColor)
        {
            Vector2F colliderPosition = GameObject.Transform.Position;
            Vector2F colliderScale = GameObject.Transform.Scale;
            float colliderRotation = GameObject.Transform.Rotation;

            float posX = colliderPosition.X * pixelsPerMeter;
            float posY = colliderPosition.Y * pixelsPerMeter;
            float width = Width * pixelsPerMeter * colliderScale.X;
            float height = Height * pixelsPerMeter * colliderScale.Y;

            int x = (int) (posX - cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2);
            int y = (int) (posY - cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2);

            rectangle.X = (int) (x - width / 2);
            rectangle.Y = (int) (y - height / 2);
            rectangle.W = (int) width;
            rectangle.H = (int) height;

            Sdl.SetRenderDrawColor(renderer, debugColor.R, debugColor.G, debugColor.B, debugColor.A);
            Sdl.RenderDrawRect(renderer, ref rectangle);

            // Render with rotation
            Sdl.RenderCopyEx(renderer, IntPtr.Zero, IntPtr.Zero, ref rectangle, colliderRotation, IntPtr.Zero, RendererFlips.None);
        }

        /// <summary>
        ///     Describes whether this instance is visible
        /// </summary>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        /// <returns>The bool</returns>
        public bool IsVisible(Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            Vector2F colliderPosition = GameObject.Transform.Position;
            Vector2F colliderSize = new Vector2F(Width, Height);
            float colliderRotation = GameObject.Transform.Rotation;

            float colliderPosX = colliderPosition.X * pixelsPerMeter;
            float colliderPosY = colliderPosition.Y * pixelsPerMeter;

            float cameraLeft = cameraPosition.X * pixelsPerMeter - cameraResolution.X / 2;
            float cameraRight = cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2;
            float cameraTop = cameraPosition.Y * pixelsPerMeter - cameraResolution.Y / 2;
            float cameraBottom = cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2;

            // Calculate the bounding box of the rotated collider
            float halfWidth = colliderSize.X / 2;
            float halfHeight = colliderSize.Y / 2;
            float cos = (float) Math.Cos(colliderRotation);
            float sin = (float) Math.Sin(colliderRotation);

            float[] cornersX = new float[4];
            float[] cornersY = new float[4];

            cornersX[0] = colliderPosX + (-halfWidth * cos - -halfHeight * sin);
            cornersY[0] = colliderPosY + (-halfWidth * sin + -halfHeight * cos);
            cornersX[1] = colliderPosX + (halfWidth * cos - -halfHeight * sin);
            cornersY[1] = colliderPosY + (halfWidth * sin + -halfHeight * cos);
            cornersX[2] = colliderPosX + (halfWidth * cos - halfHeight * sin);
            cornersY[2] = colliderPosY + (halfWidth * sin + halfHeight * cos);
            cornersX[3] = colliderPosX + (-halfWidth * cos - halfHeight * sin);
            cornersY[3] = colliderPosY + (-halfWidth * sin + halfHeight * cos);

            float colliderLeft = Min(cornersX);
            float colliderRight = Max(cornersX);
            float colliderTop = Min(cornersY);
            float colliderBottom = Max(cornersY);

            return (colliderRight > cameraLeft) && (colliderLeft < cameraRight) && (colliderBottom > cameraTop) && (colliderTop < cameraBottom);
        }

        /// <summary>
        ///     Mins the corners x
        /// </summary>
        /// <param name="cornersX">The corners</param>
        /// <returns>The min</returns>
        private float Min(float[] cornersX)
        {
            float min = cornersX[0];

            for (int i = 1; i < cornersX.Length; i++)
            {
                if (cornersX[i] < min)
                {
                    min = cornersX[i];
                }
            }

            return min;
        }

        /// <summary>
        ///     Maxes the corners x
        /// </summary>
        /// <param name="cornersX">The corners</param>
        /// <returns>The max</returns>
        private float Max(float[] cornersX)
        {
            float max = cornersX[0];

            for (int i = 1; i < cornersX.Length; i++)
            {
                if (cornersX[i] > max)
                {
                    max = cornersX[i];
                }
            }

            return max;
        }
    }
}