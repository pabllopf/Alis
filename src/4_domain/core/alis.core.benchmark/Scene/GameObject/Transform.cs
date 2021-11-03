//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Transform.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Manage the position of the game object on a scene.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Transform
    {
        /// <summary>The icon</summary>
        private string icon = "\uf0b2";

        /// <summary>The position</summary>
        [NotNull]
        private Vector3 position;

        /// <summary>The rotation</summary>
        [NotNull]
        private Vector3 rotation;

        /// <summary>The size</summary>
        [NotNull]
        private Vector3 scale;

        /// <summary>The x position</summary>
        private float xPos;

        /// <summary>The y position</summary>
        private float yPos;

        /// <summary>The z position</summary>
        private float zPos;

        /// <summary>The go up</summary>
        private bool canGoUp = true;

        /// <summary>The go down</summary>
        private bool canGoDown = true;

        /// <summary>The go left</summary>
        private bool canGoLeft = true;

        /// <summary>The go right</summary>
        private bool canGoRight = true;

        /// <summary>The can go inside</summary>
        private bool canGoInside = true;

        /// <summary>The can go out</summary>
        private bool canGoOut = true;

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="scale">The size.</param>
        [JsonConstructor]
        public Transform([NotNull] Vector3 position, [NotNull] Vector3 rotation, [NotNull] Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;

            xPos = this.position.X;
            yPos = this.position.Y;
            zPos = this.position.Z;

            OnCreate += Transform_OnCreate;
            OnPositionChange += Transform_OnPositionChange;
            OnRotationChange += Transform_OnRotationChange;
            OnSizeChange += Transform_OnSizeChange;
            OnDestroy += Transform_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            position = new Vector3(0f);
            rotation = new Vector3(0f);
            scale = new Vector3(1f);

            xPos = this.position.X;
            yPos = this.position.Y;
            zPos = this.position.Z;

            OnCreate += Transform_OnCreate;
            OnPositionChange += Transform_OnPositionChange;
            OnRotationChange += Transform_OnRotationChange;
            OnSizeChange += Transform_OnSizeChange;
            OnDestroy += Transform_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="position">The position.</param>
        public Transform([NotNull] Vector3 position)
        {
            this.position = position;
            rotation = new Vector3(0f);
            scale = new Vector3(1f);

            xPos = this.position.X;
            yPos = this.position.Y;
            zPos = this.position.Z;

            OnCreate += Transform_OnCreate;
            OnPositionChange += Transform_OnPositionChange;
            OnRotationChange += Transform_OnRotationChange;
            OnSizeChange += Transform_OnSizeChange;
            OnDestroy += Transform_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Finalizes an instance of the <see cref="Transform" /> class.</summary>
        ~Transform() => OnDestroy.Invoke(this, true);

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnPositionChange;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnRotationChange;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnSizeChange;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the position.</summary>
        /// <value>The position.</value>
        [NotNull]
        [JsonProperty]
        public Vector3 Position
        {
            get => position;
            set
            {
                position = value;
                OnPositionChange.Invoke(this, true);
            }
        }

        /// <summary>Gets or sets the rotation.</summary>
        /// <value>The rotation.</value>
        [NotNull]
        [JsonProperty]
        public Vector3 Rotation
        {
            get => rotation; 
            set
            {
                rotation = value;
                OnRotationChange.Invoke(this, true);
            }
        }

        /// <summary>Gets or sets the size.</summary>
        /// <value>The size.</value>
        [NotNull]
        [JsonProperty]
        public Vector3 Scale
        {
            get => scale; 
            set
            {
                scale = value;
                OnSizeChange.Invoke(this, true);
            }
        }

        /// <summary>Gets or sets the x position.</summary>
        /// <value>The x position.</value>
        public float XPos
        {
            get => xPos; 
            set
            {
                if (value != position.X)
                {
                    if (value < position.X && canGoLeft)
                    {
                        position.X = value;
                        xPos = value;
                        OnPositionChange.Invoke(this, true);
                    }

                    if (value > position.X && canGoRight)
                    {
                        position.X = value;
                        xPos = value;
                        OnPositionChange.Invoke(this, true);
                    }
                }
            }
        }

        /// <summary>Gets or sets the y position.</summary>
        /// <value>The y position.</value>
        public float YPos
        {
            get => yPos; set
            {
                if (value != position.Y)
                {
                    if (value < position.Y && canGoUp) 
                    {
                        position.Y = value;
                        yPos = value;
                        OnPositionChange.Invoke(this, true);
                    }

                    if (value > position.Y && canGoDown)
                    {
                        position.Y = value;
                        yPos = value;
                        OnPositionChange.Invoke(this, true);
                    }
                }
            }
        }

        /// <summary>Gets or sets the z position.</summary>
        /// <value>The z position.</value>
        public float ZPos
        {
            get => zPos; 
            set
            {
                if (value != position.Z) 
                {
                    if (value < position.Z && canGoOut)
                    {
                        position.Z = value;
                        zPos = value;
                        OnPositionChange.Invoke(this, true);
                    }
                    
                    if (value > position.Z && canGoInside)
                    {
                        position.Z = value;
                        zPos = value;
                        OnPositionChange.Invoke(this, true);
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether [go up].</summary>
        /// <value>
        /// <c>true</c> if [go up]; otherwise, <c>false</c>.</value>
        public bool CanGoUp { get => canGoUp; set => canGoUp = value; }

        /// <summary>Gets or sets a value indicating whether [go down].</summary>
        /// <value>
        /// <c>true</c> if [go down]; otherwise, <c>false</c>.</value>
        public bool CanGoDown { get => canGoDown; set => canGoDown = value; }

        /// <summary>Gets or sets a value indicating whether [go left].</summary>
        /// <value>
        /// <c>true</c> if [go left]; otherwise, <c>false</c>.</value>
        public bool CanGoLeft { get => canGoLeft; set => canGoLeft = value; }

        /// <summary>Gets or sets a value indicating whether [go right].</summary>
        /// <value>
        /// <c>true</c> if [go right]; otherwise, <c>false</c>.</value>
        public bool CanGoRight { get => canGoRight; set => canGoRight = value; }

        /// <summary>Gets or sets a value indicating whether this instance can go inside.</summary>
        /// <value>
        /// <c>true</c> if this instance can go inside; otherwise, <c>false</c>.</value>
        public bool CanGoInside { get => canGoInside; set => canGoInside = value; }

        /// <summary>Gets or sets a value indicating whether this instance can go out.</summary>
        /// <value>
        /// <c>true</c> if this instance can go out; otherwise, <c>false</c>.</value>
        public bool CanGoOut { get => canGoOut; set => canGoOut = value; }
        /// <summary>
        /// Gets or sets the value of the icon
        /// </summary>
        public string Icon { get => icon; set => icon = value; }

        #region DefineEvents

        /// <summary>Transforms the on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Transform_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Transforms the on position change.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Transform_OnPositionChange([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Transforms the on rotation change.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Transform_OnRotationChange([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Transforms the on size change.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Transform_OnSizeChange([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Transforms the on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Transform_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}