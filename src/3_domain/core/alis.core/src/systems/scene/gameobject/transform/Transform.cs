namespace Alis.Core
{
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using Newtonsoft.Json;

    /// <summary>Control the object space in the game.</summary>
    public class Transform
    {
        /// <summary>The size</summary>
        [NotNull]
        private Vector3 size;

        /// <summary>The position</summary>
        [NotNull]
        private Vector3 position;

        /// <summary>The rotation</summary>
        [NotNull]
        private Vector3 rotation;

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            size =      new Vector3(x: 1.0f, y: 1.0f, z: 1.0f);
            position =  new Vector3(x: 0.0f, y: 0.0f, z: 0.0f);
            rotation =  new Vector3(x: 0.0f, y: 0.0f, z: 0.0f);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="size">The size.</param>
        public Transform([NotNull] Vector3 size)
        {
            this.size = size;
            position =  new Vector3(x: 0.0f, y: 0.0f, z: 0.0f);
            rotation =  new Vector3(x: 0.0f, y: 0.0f, z: 0.0f);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        [JsonConstructor]
        public Transform([NotNull] Vector3 size, [NotNull] Vector3 position, [NotNull] Vector3 rotation)
        {
            this.size = size;
            this.position = position;
            this.rotation = rotation;
        }

        /// <summary>Gets or sets the size.</summary>
        /// <value>The size.</value>
        [JsonProperty("_Size")]
        [NotNull]
        public Vector3 Size { get => size; set => size = value; }

        /// <summary>Gets or sets the position.</summary>
        /// <value>The position.</value>
        [JsonProperty("_Position")]
        [NotNull]
        public Vector3 Position { get => position; set => position = value; }

        /// <summary>Gets or sets the rotation.</summary>
        /// <value>The rotation.</value>
        [JsonProperty("_Rotation")]
        [NotNull]
        public Vector3 Rotation { get => rotation; set => rotation = value; }

     

        public static Transform Default => new Transform();
    }
}