//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Transform.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    /// <summary>Manage the position of the game object on a scene.</summary>
    public class Transform : IComponent
    {
        /// <summary>The position</summary>
        private Vector3 position;

        /// <summary>The rotation</summary>
        private Vector3 rotation;

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            position = new Vector3();
            rotation = new Vector3();
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
    }
}