//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Transform.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using Newtonsoft.Json;

    /// <summary>Manage the position of the game object on a scene.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Transform
    {
        /// <summary>The position</summary>
        private Vector3 position;

        /// <summary>The rotation</summary>
        private Vector3 rotation;

        /// <summary>The size</summary>
        private Vector3 size;

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

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="size">size object</param>
        [JsonConstructor]
        public Transform(Vector3 position, Vector3 rotation, Vector3 size)
        {
            this.position = position;
            this.rotation = rotation;
            this.size = size;
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            this.position = new Vector3(0f);
            this.rotation = new Vector3(0f);
            this.size = new Vector3(1f);
        }

        /// <summary>Finalizes an instance of the <see cref="Transform" /> class.</summary>
        /// <exception cref="System.NotImplementedException"></exception>
        ~Transform()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Gets or sets the position.</summary>
        /// <value>The position.</value>
        [JsonProperty]
        public Vector3 Position { get => position; set => position = value; }

        /// <summary>Gets or sets the rotation.</summary>
        /// <value>The rotation.</value>
        [JsonProperty]
        public Vector3 Rotation { get => rotation; set => rotation = value; }

        /// <summary>Gets or sets the size.</summary>
        /// <value>The size.</value>
        [JsonProperty]
        public Vector3 Size { get => size; set => size = value; }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}