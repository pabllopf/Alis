// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SinkTest.cs
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

using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The sink test class
    /// </summary>
    public class SinkTest
    {
        /// <summary>
        ///     Tests that isink should create new sink when trapezoid has no sink
        /// </summary>
        [Fact]
        public void Isink_ShouldCreateNewSink_WhenTrapezoidHasNoSink()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            
            Sink sink = Sink.Isink(trapezoid);
            
            Assert.NotNull(sink);
            Assert.Equal(trapezoid, sink.Trapezoid);
        }

        /// <summary>
        ///     Tests that isink should return existing sink when trapezoid has sink
        /// </summary>
        [Fact]
        public void Isink_ShouldReturnExistingSink_WhenTrapezoidHasSink()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Sink firstSink = Sink.Isink(trapezoid);
            
            Sink secondSink = Sink.Isink(trapezoid);
            
            Assert.Same(firstSink, secondSink);
        }

        /// <summary>
        ///     Tests that trapezoid property should be readonly
        /// </summary>
        [Fact]
        public void TrapezoidProperty_ShouldBeReadonly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Sink sink = Sink.Isink(trapezoid);
            
            Assert.Equal(trapezoid, sink.Trapezoid);
        }

        /// <summary>
        ///     Tests that locate should return self
        /// </summary>
        [Fact]
        public void Locate_ShouldReturnSelf()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Sink sink = Sink.Isink(trapezoid);
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 10);
            Edge edge = new Edge(p1, p2);
            
            Sink result = sink.Locate(edge);
            
            Assert.Equal(sink, result);
        }

        /// <summary>
        ///     Tests that sink should inherit from node
        /// </summary>
        [Fact]
        public void Sink_ShouldInheritFromNode()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Sink sink = Sink.Isink(trapezoid);
            
            Assert.IsAssignableFrom<Node>(sink);
        }

        /// <summary>
        ///     Tests that isink should link trapezoid to sink
        /// </summary>
        [Fact]
        public void Isink_ShouldLinkTrapezoidToSink()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            
            Sink sink = Sink.Isink(trapezoid);
            
            Assert.Equal(sink, trapezoid.Sink);
        }

        /// <summary>
        ///     Tests that multiple calls to isink should return same instance
        /// </summary>
        [Fact]
        public void MultipleCalls_ToIsink_ShouldReturnSameInstance()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            
            Sink sink1 = Sink.Isink(trapezoid);
            Sink sink2 = Sink.Isink(trapezoid);
            Sink sink3 = Sink.Isink(trapezoid);
            
            Assert.Same(sink1, sink2);
            Assert.Same(sink2, sink3);
        }

        /// <summary>
        ///     Tests that sink should handle edge parameter in locate
        /// </summary>
        [Fact]
        public void Sink_ShouldHandleEdgeParameterInLocate()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Sink sink = Sink.Isink(trapezoid);
            Point p1 = new Point(100, 200);
            Point p2 = new Point(300, 400);
            Edge edge = new Edge(p1, p2);
            
            Sink result = sink.Locate(edge);
            
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Creates the test trapezoid
        /// </summary>
        /// <returns>The trapezoid</returns>
        private Trapezoid CreateTestTrapezoid()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Edge top = new Edge(new Point(0, 10), new Point(10, 10));
            Edge bottom = new Edge(new Point(0, -10), new Point(10, -10));
            return new Trapezoid(leftPoint, rightPoint, top, bottom);
        }
    }
}

