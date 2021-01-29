//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Transform.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System.Numerics;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>Manage the position of the game object on a scene.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class Transform : IComponent
    {
        /// <summary>The position</summary>
        [JsonProperty]
        private Vector3 position;

        /// <summary>The rotation</summary>
        [JsonProperty]
        private Vector3 rotation;

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            position = new Vector3();
            rotation = new Vector3();
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        public Transform(Vector3 position, Vector3 rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }

        /// <summary>Gets or sets the position.</summary>
        /// <value>The position.</value>
        public Vector3 Position { get => position; set => position = value; }

        /// <summary>Gets or sets the rotation.</summary>
        /// <value>The rotation.</value>
        public Vector3 Rotation { get => rotation; set => rotation = value; }

        /// <summary>Starts this instance.</summary>
        public void Start()
        { 
        }

        /// <summary>Updates this instance.</summary>
        public void Update()
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