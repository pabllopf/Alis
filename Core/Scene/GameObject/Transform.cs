//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Transform.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using Newtonsoft.Json;

    /// <summary>Manage the position of the game object on a scene.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Transform
    {
        /// <summary>The icon</summary>
        private readonly string icon = "\uf03d";

        /// <summary>The position</summary>
        [JsonProperty]
        [NotNull]
        private Vector3 position;

        /// <summary>The rotation</summary>
        [JsonProperty]
        [NotNull]
        private Vector3 rotation;

        /// <summary>The size</summary>
        [JsonProperty]
        [NotNull]
        private Vector3 size;

        private float xPos;

        private float yPos;

        private float zPos;

        private bool goUp = true;

        private bool goDown = true;

        private bool goLeft = true;

        private bool goRight = true;

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            position = new Vector3(0f);
            rotation = new Vector3(0f);
            size = new Vector3(1f);

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
            size = new Vector3(1f);

            OnCreate += Transform_OnCreate;
            OnPositionChange += Transform_OnPositionChange;
            OnRotationChange += Transform_OnRotationChange;
            OnSizeChange += Transform_OnSizeChange;
            OnDestroy += Transform_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="size">The size.</param>
        [JsonConstructor]
        public Transform([NotNull] Vector3 position, [NotNull] Vector3 rotation, [NotNull] Vector3 size)
        {
            this.position = position;
            this.rotation = rotation;
            this.size = size;

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
        public Vector3 Position
        {
            get => position; 
        }

        /// <summary>Gets or sets the rotation.</summary>
        /// <value>The rotation.</value>
        [NotNull]
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
        public Vector3 Size
        {
            get => size; 
            set
            {
                size = value;
                OnSizeChange.Invoke(this, true);
            }
        }

        /// <summary>Gets the icon.</summary>
        /// <value>The icon.</value>
        public string Icon => icon;

        public float XPos
        {
            get => xPos; 
            set
            {
                if (value != position.X)
                {
                    if (value < position.X && goLeft)
                    {
                        position.X = value;
                        xPos = value;
                        OnPositionChange.Invoke(this, true);
                    }

                    if (value > position.X && goRight)
                    {
                        position.X = value;
                        xPos = value;
                        OnPositionChange.Invoke(this, true);
                    }
                }
            }
        }
        public float YPos
        {
            get => yPos; set
            {
                if (value != position.Y)
                {
                    if (value < position.Y && goUp) 
                    {
                        position.Y = value;
                        yPos = value;
                        OnPositionChange.Invoke(this, true);
                    }

                    if (value > position.Y && goDown)
                    {
                        position.Y = value;
                        yPos = value;
                        OnPositionChange.Invoke(this, true);
                    }
                }
            }
        }
        public float ZPos
        {
            get => zPos; 
            set
            {
                if (value != position.Z) 
                {
                    position.Z = value;
                    zPos = value;
                    OnPositionChange.Invoke(this, true);
                }
            }
        }

        public bool GoUp { get => goUp; set => goUp = value; }
        public bool GoDown { get => goDown; set => goDown = value; }
        public bool GoLeft { get => goLeft; set => goLeft = value; }
        public bool GoRight { get => goRight; set => goRight = value; }

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