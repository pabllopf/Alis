﻿/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    internal class XNode : Node
    {
        private Point _point;

        public XNode(Point point, Node lChild, Node rChild)
            : base(lChild, rChild)
        {
            _point = point;
        }

        public override Sink Locate(Edge edge)
        {
            if (edge.P.X >= _point.X)
                return RightChild.Locate(edge); // Move to the right in the graph

            return LeftChild.Locate(edge); // Move to the left in the graph
        }
    }
}