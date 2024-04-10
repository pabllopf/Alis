// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sink.cs
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

namespace Alis.Extension.Math.PathGenerator.Triangulation.Seidel
{
    /// <summary>
    ///     The sink class
    /// </summary>
    /// <seealso cref="Node" />
    internal class Sink : Node
    {
        /// <summary>
        ///     The trapezoid
        /// </summary>
        public readonly Trapezoid Trapezoid;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sink" /> class
        /// </summary>
        /// <param name="trapezoid">The trapezoid</param>
        private Sink(Trapezoid trapezoid)
            : base(null, null)
        {
            Trapezoid = trapezoid;
            trapezoid.Sink = this;
        }

        /// <summary>
        ///     Is inks the trapezoid
        /// </summary>
        /// <param name="trapezoid">The trapezoid</param>
        /// <returns>The sink</returns>
        public static Sink IsInk(Trapezoid trapezoid) => trapezoid.Sink ?? new Sink(trapezoid);

        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The sink</returns>
        public override Sink Locate(Edge edge) => this;
    }
}