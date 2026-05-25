// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XNode.cs
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

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The node class
    /// </summary>
    /// <seealso cref="Node" />
    internal class XNode : Node
    {
        /// <summary>
        ///     The point
        /// </summary>
        private readonly Point _point;

        /// <summary>
        ///     Initializes a new instance of the <see cref="XNode" /> class
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="lChild">The child</param>
        /// <param name="rChild">The child</param>
        public XNode(Point point, Node lChild, Node rChild)
            : base(lChild, rChild)
            => _point = point;

        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="s">The edge</param>
        /// <returns>The sink</returns>
        public override Sink Locate(Edge s)
        {
            if (s.P.X >= _point.X)
            {
                return RightChild.Locate(s); // Move to the right in the graph
            }

            return LeftChild.Locate(s); // Move to the left in the graph
        }
    }
}