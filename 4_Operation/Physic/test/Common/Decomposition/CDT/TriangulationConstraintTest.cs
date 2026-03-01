// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationConstraintTest.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    ///     The triangulation constraint test class
    /// </summary>
    public class TriangulationConstraintTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with null values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithNullValues()
        {
            TriangulationConstraint constraint = new TriangulationConstraint();
            
            Assert.Null(constraint.P);
            Assert.Null(constraint.Q);
        }

        /// <summary>
        ///     Tests that p property should set and get correctly
        /// </summary>
        [Fact]
        public void PProperty_ShouldSetAndGetCorrectly()
        {
            TriangulationConstraint constraint = new TriangulationConstraint();
            TriangulationPoint point = new TriangulationPoint(5.0, 10.0);
            
            constraint.P = point;
            
            Assert.Equal(point, constraint.P);
        }

        /// <summary>
        ///     Tests that q property should set and get correctly
        /// </summary>
        [Fact]
        public void QProperty_ShouldSetAndGetCorrectly()
        {
            TriangulationConstraint constraint = new TriangulationConstraint();
            TriangulationPoint point = new TriangulationPoint(15.0, 20.0);
            
            constraint.Q = point;
            
            Assert.Equal(point, constraint.Q);
        }

        /// <summary>
        ///     Tests that triangulation constraint should allow both points to be set
        /// </summary>
        [Fact]
        public void TriangulationConstraint_ShouldAllowBothPointsToBeSet()
        {
            TriangulationConstraint constraint = new TriangulationConstraint();
            TriangulationPoint p = new TriangulationPoint(0, 0);
            TriangulationPoint q = new TriangulationPoint(10, 10);
            
            constraint.P = p;
            constraint.Q = q;
            
            Assert.Equal(p, constraint.P);
            Assert.Equal(q, constraint.Q);
        }

        /// <summary>
        ///     Tests that triangulation constraint should allow null assignments
        /// </summary>
        [Fact]
        public void TriangulationConstraint_ShouldAllowNullAssignments()
        {
            TriangulationConstraint constraint = new TriangulationConstraint();
            constraint.P = new TriangulationPoint(5, 5);
            constraint.Q = new TriangulationPoint(10, 10);
            
            constraint.P = null;
            constraint.Q = null;
            
            Assert.Null(constraint.P);
            Assert.Null(constraint.Q);
        }

        /// <summary>
        ///     Tests that triangulation constraint should support point reassignment
        /// </summary>
        [Fact]
        public void TriangulationConstraint_ShouldSupportPointReassignment()
        {
            TriangulationConstraint constraint = new TriangulationConstraint();
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(5, 5);
            
            constraint.P = p1;
            constraint.P = p2;
            
            Assert.Equal(p2, constraint.P);
        }

        /// <summary>
        ///     Tests that triangulation constraint should be reference type
        /// </summary>
        [Fact]
        public void TriangulationConstraint_ShouldBeReferenceType()
        {
            TriangulationConstraint constraint1 = new TriangulationConstraint();
            TriangulationPoint point = new TriangulationPoint(5, 5);
            constraint1.P = point;
            
            TriangulationConstraint constraint2 = constraint1;
            
            Assert.Same(constraint1, constraint2);
        }

        /// <summary>
        ///     Tests that triangulation constraint should support same point for p and q
        /// </summary>
        [Fact]
        public void TriangulationConstraint_ShouldSupportSamePointForPAndQ()
        {
            TriangulationConstraint constraint = new TriangulationConstraint();
            TriangulationPoint point = new TriangulationPoint(5, 5);
            
            constraint.P = point;
            constraint.Q = point;
            
            Assert.Same(constraint.P, constraint.Q);
        }

        /// <summary>
        ///     Tests that multiple constraints can be created independently
        /// </summary>
        [Fact]
        public void MultipleConstraints_CanBeCreatedIndependently()
        {
            TriangulationConstraint constraint1 = new TriangulationConstraint();
            TriangulationConstraint constraint2 = new TriangulationConstraint();
            
            constraint1.P = new TriangulationPoint(0, 0);
            constraint2.P = new TriangulationPoint(10, 10);
            
            Assert.NotEqual(constraint1.P, constraint2.P);
        }
    }
}

