//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Transform.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics;
    using System.Numerics;
    using Newtonsoft.Json;

    /// <summary>Manage the position of the game object on a scene.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Transform : IComponent
    {
        /// <summary>The icon</summary>
        private readonly string icon = "\uf0b2";

        /// <summary>The position</summary>
        private Vector3 position;

        /// <summary>The rotation</summary>
        private Vector3 rotation;

        /// <summary>The size</summary>
        private Vector3 size;

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

        /// <summary>Gets the icon.</summary>
        /// <value>The icon.</value>
        public string Icon => icon;

        /// <summary>Starts the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Start(GameObject gameObject)
        {
        }

        /// <summary>Updates the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Update(GameObject gameObject)
        {
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}