using System.Runtime.InteropServices;
using SFML.System;

namespace SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Define a point with color and texture coordinates
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vertex from its position
        /// The vertex color is white and texture coordinates are (0, 0).
        /// </summary>
        /// <param name="position">Vertex position</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2f position) :
            this(position, Color.White, new Vector2f(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vertex from its position and color
        /// The texture coordinates are (0, 0).
        /// </summary>
        /// <param name="position">Vertex position</param>
        /// <param name="color">Vertex color</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2f position, Color color) :
            this(position, color, new Vector2f(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vertex from its position and texture coordinates
        /// The vertex color is white.
        /// </summary>
        /// <param name="position">Vertex position</param>
        /// <param name="texCoords">Vertex texture coordinates</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2f position, Vector2f texCoords) :
            this(position, Color.White, texCoords)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vertex from its position, color and texture coordinates
        /// </summary>
        /// <param name="position">Vertex position</param>
        /// <param name="color">Vertex color</param>
        /// <param name="texCoords">Vertex texture coordinates</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2f position, Color color, Vector2f texCoords)
        {
            Position = position;
            Color = color;
            TexCoords = texCoords;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return "[Vertex]" +
                   " Position(" + Position + ")" +
                   " Color(" + Color + ")" +
                   " TexCoords(" + TexCoords + ")";
        }

        /// <summary>2D position of the vertex</summary>
        public Vector2f Position;

        /// <summary>Color of the vertex</summary>
        public Color Color;

        /// <summary>Coordinates of the texture's pixel to map to the vertex</summary>
        public Vector2f TexCoords;
    }
}
