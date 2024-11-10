// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:YNode.cs
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
    internal class YNode : Node
    {
        /// <summary>
        ///     The edge
        /// </summary>
        private readonly Edge _edge;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="YNode" /> class
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <param name="lChild">The child</param>
        /// <param name="rChild">The child</param>
        public YNode(Edge edge, Node lChild, Node rChild)
            : base(lChild, rChild)
            => _edge = edge;
        
        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The sink</returns>
        public override Sink Locate(Edge edge)
        {
            if (_edge.IsAbove(edge.P))
            {
                return RightChild.Locate(edge); // Move down the graph
            }

            if (_edge.IsBelow(edge.P))
            {
                return LeftChild.Locate(edge); // Move up the graph
            }

            // s and segment share the same endpoint, p
            if (edge.Slope < _edge.Slope)
            {
                return RightChild.Locate(edge); // Move down the graph
            }

            // Move up the graph
            return LeftChild.Locate(edge);
        }
    }
}