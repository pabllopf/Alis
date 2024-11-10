﻿/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    internal class YNode : Node
    {
        private Edge _edge;

        public YNode(Edge edge, Node lChild, Node rChild)
            : base(lChild, rChild)
        {
            _edge = edge;
        }

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