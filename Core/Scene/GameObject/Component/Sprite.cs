//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Camera.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core
{
    /// <summary>Define a component</summary>
    public class Sprite : Component
    {
        /// <summary>The depth</summary>
        [NotNull]
        private int depth;

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        public Sprite()
        {
            this.depth = 0;
        }

        /// <summary>Initializes a new instance of the <see cref="Camera" /> class.</summary>
        public Sprite([NotNull] int depth)
        {
            this.depth = depth;
        }

        /// <summary>Gets or sets the depth.</summary>
        /// <value>The depth.</value>
        [NotNull]
        public int Depth { get => depth; set => depth = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
        }

        internal SFML.Graphics.Drawable GetDraw()
        {
            return default;
        }
    }
}