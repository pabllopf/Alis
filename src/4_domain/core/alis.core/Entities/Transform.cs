using System.Numerics;
using System.Text.Json.Serialization;

namespace Alis.Core.Entities
{
    /// <summary>Control the object space in the game.</summary>
    public class Transform
    {
        /// <summary>The position</summary>
        private Vector3 position;

        /// <summary>The rotation</summary>
        private Vector3 rotation;

        /// <summary>The size</summary>
        private Vector3 scale;

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            scale = new Vector3(1.0f, 1.0f, 1.0f);
            position = new Vector3(0.0f, 0.0f, 0.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="size">The size.</param>
        public Transform(Vector3 size)
        {
            scale = size;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        [JsonConstructor]
        public Transform(Vector3 size, Vector3 position, Vector3 rotation)
        {
            scale = size;
            this.position = position;
            this.rotation = rotation;
        }

        /// <summary>Gets or sets the size.</summary>
        /// <value>The size.</value>
        [JsonPropertyName("_Size")]
        public Vector3 Scale
        {
            get => scale;
            set => scale = value;
        }

        /// <summary>Gets or sets the position.</summary>
        /// <value>The position.</value>
        [JsonPropertyName("_Position")]
        public Vector3 Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>Gets or sets the rotation.</summary>
        /// <value>The rotation.</value>
        [JsonPropertyName("_Rotation")]
        public Vector3 Rotation
        {
            get => rotation;
            set => rotation = value;
        }
    }
}