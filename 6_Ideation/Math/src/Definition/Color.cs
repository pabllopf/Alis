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
    ///     The color
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Color : ISerializable
    {
        /// <summary>
        ///     The
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        /// Gets the value of the cyan
        /// </summary>
        public static Color Cyan { get; } = new Color(0, 255, 255, 255);

        /// <summary>
        /// Gets the value of the magenta
        /// </summary>
        public static Color Magenta { get; } = new Color(255, 0, 255, 255);
 
        /// <summary>
        /// Gets the value of the yellow
        /// </summary>
        public static Color Yellow { get; } = new Color(255, 255, 0, 255);

        /// <summary>
        /// Gets the value of the blue
        /// </summary>
        public static Color Blue { get; } = new Color(0, 0, 255, 255);


        /// <summary>
        ///     Initializes a new instance of the <see cref="Color" /> class
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Color" /> class
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        public Color(int r, int g, int b, int a)
        {
            R = (byte) r;
            G = (byte) g;
            B = (byte) b;
            A = (byte) a;
        }

        /// <summary>
        ///     Gets the value of the black
        /// </summary>
        public static Color Black => new Color(0, 0, 0, 255);

        /// <summary>
        ///     Gets the value of the white
        /// </summary>
        public static Color White => new Color(255, 255, 255, 255);

        /// <summary>
        ///     Gets the value of the red
        /// </summary>
        public static Color Red => new Color(255, 0, 0, 255);

        /// <summary>
        ///     Gets the value of the transparent
        /// </summary>
        public static Color Transparent => new Color(0, 0, 0, 0);

        /// <summary>
        ///     Gets the value of the green
        /// </summary>
        public static Color Green => new Color(0, 255, 0, 255);

        /// <summary>
        ///     Gets or sets the value of the brown
        /// </summary>
        public static Color Brown { get; } = new Color(165, 42, 42, 255);

        /// <summary>
        ///     Gets or sets the value of the dark green
        /// </summary>
        public static Color DarkGreen { get; } = new Color(0, 100, 0, 255);

        /// <summary>
        ///     Gets the object data using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("r", R);
            info.AddValue("g", G);
            info.AddValue("b", B);
            info.AddValue("a", A);
        }
    }
}