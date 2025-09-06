using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    /// <see cref="Ivec2"/> is a struct represent a glsl ivec2 value
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Ivec2
    {
        
        /// <summary>
        /// Implicit cast from <see cref="Alis.Core.Aspect.Math.Vector.Vector2F"/> to <see cref="Ivec2"/>
        /// </summary>
        public static implicit operator Ivec2(Vector2F vec) => new Ivec2(vec);

        
        /// <summary>
        /// Construct the <see cref="Ivec2"/> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the <see cref="Ivec2"/> from a standard SFML <see cref="Alis.Core.Aspect.Math.Vector.Vector2F"/>
        /// </summary>
        /// <param name="vec">A standard SFML 2D integer vector</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(Vector2F vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;
    }
}