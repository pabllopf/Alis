// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Color.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Definition
{
    /// <summary>
    ///     Represents an RGBA color with 8-bit byte components, including predefined named colors. Implements <see cref="ISerializable" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Color : ISerializable
    {
        /// <summary>
        ///     Gets or sets the red component (0-255).
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        ///     Gets or sets the green component (0-255).
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        ///     Gets or sets the blue component (0-255).
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        ///     Gets or sets the alpha (opacity) component (0-255, where 255 is fully opaque).
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        ///     Gets the predefined cyan color (R=0, G=255, B=255, A=255).
        /// </summary>
        public static Color Cyan { get; } = new Color(0, 255, 255, 255);

        /// <summary>
        ///     Gets the predefined magenta color (R=255, G=0, B=255, A=255).
        /// </summary>
        public static Color Magenta { get; } = new Color(255, 0, 255, 255);

        /// <summary>
        ///     Gets the predefined yellow color (R=255, G=255, B=0, A=255).
        /// </summary>
        public static Color Yellow { get; } = new Color(255, 255, 0, 255);

        /// <summary>
        ///     Gets the predefined blue color (R=0, G=0, B=255, A=255).
        /// </summary>
        public static Color Blue { get; } = new Color(0, 0, 255, 255);

        /// <summary>
        ///     Initializes a new instance of the <see cref="Color" /> struct with explicit byte component values.
        /// </summary>
        /// <param name="r">The red component value (0-255).</param>
        /// <param name="g">The green component value (0-255).</param>
        /// <param name="b">The blue component value (0-255).</param>
        /// <param name="a">The alpha component value (0-255, 255 = fully opaque).</param>
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Color" /> struct using integer component values that are cast to bytes.
        /// </summary>
        /// <param name="r">The red component value (will be cast to byte).</param>
        /// <param name="g">The green component value (will be cast to byte).</param>
        /// <param name="b">The blue component value (will be cast to byte).</param>
        /// <param name="a">The alpha component value (will be cast to byte).</param>
        public Color(int r, int g, int b, int a)
        {
            R = (byte) r;
            G = (byte) g;
            B = (byte) b;
            A = (byte) a;
        }

        /// <summary>
        ///     Gets the predefined black color (R=0, G=0, B=0, A=255).
        /// </summary>
        public static Color Black => new Color(0, 0, 0, 255);

        /// <summary>
        ///     Gets the predefined white color (R=255, G=255, B=255, A=255).
        /// </summary>
        public static Color White => new Color(255, 255, 255, 255);

        /// <summary>
        ///     Gets the predefined red color (R=255, G=0, B=0, A=255).
        /// </summary>
        public static Color Red => new Color(255, 0, 0, 255);

        /// <summary>
        ///     Gets the predefined transparent color (R=0, G=0, B=0, A=0).
        /// </summary>
        public static Color Transparent => new Color(0, 0, 0, 0);

        /// <summary>
        ///     Gets the predefined green color (R=0, G=255, B=0, A=255).
        /// </summary>
        public static Color Green => new Color(0, 255, 0, 255);

        /// <summary>
        ///     Gets the predefined brown color (R=165, G=42, B=42, A=255).
        /// </summary>
        public static Color Brown { get; } = new Color(165, 42, 42, 255);

        /// <summary>
        ///     Gets the predefined dark green color (R=0, G=100, B=0, A=255).
        /// </summary>
        public static Color DarkGreen { get; } = new Color(0, 100, 0, 255);

        /// <summary>
        ///     Populates a <see cref="SerializationInfo" /> with the data needed to serialize the color.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("r", R);
            info.AddValue("g", G);
            info.AddValue("b", B);
            info.AddValue("a", A);
        }
    }
}
