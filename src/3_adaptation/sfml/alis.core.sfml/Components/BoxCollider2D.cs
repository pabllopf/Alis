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
using System.Text.Json.Serialization;
using Alis.Core.Sfml.Managers;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Factories;
using SFML.Graphics;
using SFML.System;

namespace Alis.Core.Sfml.Components
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="Collider" />
    public class BoxCollider2D : Collider
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BoxCollider2D" /> class
        /// </summary>
        public BoxCollider2D()
        {
            AutoTiling = true;
            Size = new Vector2(1.0f, 1.0f);
            RelativePosition = new Vector2(0.0f, 0.0f);
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
        }

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
        ///     Gets the value of the instance
        /// </summary>
        public static BoxCollider2D Instance { get; } = new BoxCollider2D();

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
        public Vector2 Size { get; set; }

        /// <summary>
        ///     Creates the instance
        /// </summary>
        /// <returns>The box collider</returns>
        public static BoxCollider2D CreateInstance() => Instance;

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            if (AutoTiling)
            {
                if (GameObject.Contains<Sprite>())
                {
                    Size = ((Sprite) GameObject.Get<Sprite>()).Size;
                }
            }
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            RectangleShape = new RectangleShape(new Vector2f(Size.X, Size.Y))
            {
                FillColor = Color.Transparent,
                OutlineColor = Color.Green,
                OutlineThickness = 1f
            };
            PhysicsManager.Attach(this);

            Body = BodyFactory.CreateRectangle(PhysicsManager.World, Size.X, Size.Y, 1f,
                new Vector2(GameObject.Transform.Position.X, GameObject.Transform.Position.Y));
            Body.BodyType = BodyType;
            Body.FixedRotation = true;
            Body.Friction = 0;
            Body.Inertia = 0;
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            if (RectangleShape is not null)
            {
                RectangleShape.Rotation = Body.Rotation;
                RectangleShape.Position = new Vector2f(Body.Position.X, Body.Position.Y);
                RectangleShape.Size = new Vector2f(Size.X, Size.Y);
            }

            GameObject.Transform.Position = new Vector3(Body.Position.X, Body.Position.Y, 0);
        }


        /// <summary>
        ///     Gets the drawable
        /// </summary>
        /// <returns>The drawable</returns>
        public override Drawable GetDrawable() => RectangleShape ?? throw new NullReferenceException();
    }
}