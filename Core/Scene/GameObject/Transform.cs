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
            set
            {
                position = value;
                OnPositionChange.Invoke(this, true);
            }
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