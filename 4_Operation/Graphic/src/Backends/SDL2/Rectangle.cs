using System;
using System.Numerics;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The rectangle
    /// </summary>
    public struct Rectangle : IEquatable<Rectangle>
    {
        /// <summary>
        /// The 
        /// </summary>
        public int X;

        /// <summary>
        /// The 
        /// </summary>
        public int Y;

        /// <summary>
        /// The width
        /// </summary>
        public int Width;

        /// <summary>
        /// The height
        /// </summary>
        public int Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class
        /// </summary>
        /// <param name="topLeft">The top left</param>
        /// <param name="size">The size</param>
        public Rectangle(Point topLeft, Point size)
        {
            X = topLeft.X;
            Y = topLeft.Y;
            Width = size.X;
            Height = size.Y;
        }

        /// <summary>
        /// Gets the value of the left
        /// </summary>
        public int Left => X;
        /// <summary>
        /// Gets the value of the right
        /// </summary>
        public int Right => X + Width;
        /// <summary>
        /// Gets the value of the top
        /// </summary>
        public int Top => Y;
        /// <summary>
        /// Gets the value of the bottom
        /// </summary>
        public int Bottom => Y + Height;

        /// <summary>
        /// Gets the value of the position
        /// </summary>
        public Vector2 Position => new Vector2(X, Y);
        /// <summary>
        /// Gets the value of the size
        /// </summary>
        public Vector2 Size => new Vector2(Width, Height);

        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool Contains(Point p) => Contains(p.X, p.Y);
        /// <summary>
        /// Describes whether this instance contains
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The bool</returns>
        public bool Contains(int x, int y)
        {
            return (X <= x && (X + Width) > x)
                && (Y <= y && (Y + Height) > y);
        }

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(Rectangle other) => X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width) && Height.Equals(other.Height);

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => obj is Rectangle r && Equals(r);

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            return HashHelpersdl2.Combine(X.GetHashCode(), HashHelpersdl2.Combine(Y.GetHashCode(), HashHelpersdl2.Combine(Width.GetHashCode(), Height.GetHashCode())));
        }

        public static bool operator ==(Rectangle left, Rectangle right) => left.Equals(right);
        public static bool operator !=(Rectangle left, Rectangle right) => !left.Equals(right);
    }
}
