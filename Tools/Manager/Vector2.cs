//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Vector2.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System.Diagnostics;

    /// <summary>Define a vector.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public struct Vector2
    {
        /// <summary>The x</summary>
        private float x;

        /// <summary>The y</summary>
        private float y;

        /// <summary>Initializes a new instance of the <see cref="Vector2" /> struct.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>Gets or sets the x.</summary>
        /// <value>The x.</value>
        public float X { get => x; set => x = value; }
        
        /// <summary>Gets or sets the y.</summary>
        /// <value>The y.</value>
        public float Y { get => y; set => y = value; }

        /// <summary>Sets the specified x.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Set(float x, float y) 
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>Resets this instance.</summary>
        public void Reset() 
        {
            this.x = 0;
            this.y = 0;
        }

        /// <summary>Determines whether the specified <see cref="System.Object" />, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Return string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
