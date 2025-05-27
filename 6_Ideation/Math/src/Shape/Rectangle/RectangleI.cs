// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleI.cs
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

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Shape.Rectangle;

/// <summary>
///     The sdl rect
/// </summary>
[StructLayout(LayoutKind.Sequential), Serializable]
public struct RectangleI : IShape, ISerializable
{
    /// <summary>
    ///     The
    /// </summary>
    public int X { get; set; }

    /// <summary>
    ///     The
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    ///     The
    /// </summary>
    public int W { get; set; }

    /// <summary>
    ///     The
    /// </summary>
    public int H { get; set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RectangleI" /> class
    /// </summary>
    /// <param name="x">The </param>
    /// <param name="y">The </param>
    /// <param name="w">The </param>
    /// <param name="h">The </param>
    public RectangleI(int x, int y, int w, int h)
    {
        X = x;
        Y = y;
        H = h;
        W = w;
    }

    /// <summary>
    ///     Gets the object data using the specified info
    /// </summary>
    /// <param name="info">The info</param>
    /// <param name="context">The context</param>
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("x", X);
        info.AddValue("y", Y);
        info.AddValue("w", W);
        info.AddValue("h", H);
    }
}