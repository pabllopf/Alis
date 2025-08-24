using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    #region 2D Vectors
    
    /// <summary>
    /// <see cref="Vec2"/> is a struct represent a glsl vec2 value
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2
    {
        
        /// <summary>
        /// Implicit cast from <see cref="Vector2f"/> to <see cref="Vec2"/>
        /// </summary>
        public static implicit operator Vec2(Vector2f vec) => new Vec2(vec);

        
        /// <summary>
        /// Construct the <see cref="Vec2"/> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vec2(float x, float y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the <see cref="Vec2"/> from a standard SFML <see cref="Vector2f"/>
        /// </summary>
        /// <param name="vec">A standard SFML 2D vector</param>
        ////////////////////////////////////////////////////////////
        public Vec2(Vector2f vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;
    }

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion

    #region 3D Vectors
    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion

    #region 4D Vectors
    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion

    #region Matrices
    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion
}
