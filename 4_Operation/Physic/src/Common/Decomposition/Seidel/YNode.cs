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

/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    internal class YNode : Node
    {
        private readonly Edge _edge;

        public YNode(Edge edge, Node lChild, Node rChild)
            : base(lChild, rChild)
            => _edge = edge;

        public override Sink Locate(Edge edge)
        {
            if (_edge.IsAbove(edge.P))
                return RightChild.Locate(edge); // Move down the graph

            if (_edge.IsBelow(edge.P))
                return LeftChild.Locate(edge); // Move up the graph

            // s and segment share the same endpoint, p
            if (edge.Slope < _edge.Slope)
                return RightChild.Locate(edge); // Move down the graph

            // Move up the graph
            return LeftChild.Locate(edge);
        }
    }
}