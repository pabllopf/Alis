

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The edge shape test class
    /// </summary>
    public class EdgeShapeTest
    {
        /// <summary>
        ///     Tests that constructor with vertices should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithVertices_ShouldInitializeCorrectly()
        {
            Vector2F start = new Vector2F(0, 0);
            Vector2F end = new Vector2F(10, 0);

            EdgeShape edge = new EdgeShape(start, end);

            Assert.Equal(ShapeType.Edge, edge.ShapeType);
            Assert.Equal(start, edge.Vertex1);
            Assert.Equal(end, edge.Vertex2);
        }

        /// <summary>
        ///     Tests that child count should return one
        /// </summary>
        [Fact]
        public void ChildCount_ShouldReturnOne()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, new Vector2F(1, 0));

            Assert.Equal(1, edge.ChildCount);
        }

        /// <summary>
        ///     Tests that set should update vertices
        /// </summary>
        [Fact]
        public void Set_ShouldUpdateVertices()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F newStart = new Vector2F(5, 5);
            Vector2F newEnd = new Vector2F(10, 10);

            edge.Set(newStart, newEnd);

            Assert.Equal(newStart, edge.Vertex1);
            Assert.Equal(newEnd, edge.Vertex2);
        }

        /// <summary>
        ///     Tests that vertex1 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex1Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F newVertex = new Vector2F(3, 4);

            edge.Vertex1 = newVertex;

            Assert.Equal(newVertex, edge.Vertex1);
        }

        /// <summary>
        ///     Tests that vertex2 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex2Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F newVertex = new Vector2F(5, 6);

            edge.Vertex2 = newVertex;

            Assert.Equal(newVertex, edge.Vertex2);
        }

        /// <summary>
        ///     Tests that has vertex0 property should set and get correctly
        /// </summary>
        [Fact]
        public void HasVertex0Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);

            edge.HasVertex0 = true;

            Assert.True(edge.HasVertex0);
        }

        /// <summary>
        ///     Tests that has vertex3 property should set and get correctly
        /// </summary>
        [Fact]
        public void HasVertex3Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);

            edge.HasVertex3 = true;

            Assert.True(edge.HasVertex3);
        }

        /// <summary>
        ///     Tests that vertex0 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex0Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F vertex0 = new Vector2F(-1, 0);

            edge.Vertex0 = vertex0;

            Assert.Equal(vertex0, edge.Vertex0);
        }

        /// <summary>
        ///     Tests that vertex3 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex3Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F vertex3 = new Vector2F(2, 1);

            edge.Vertex3 = vertex3;

            Assert.Equal(vertex3, edge.Vertex3);
        }

        /// <summary>
        ///     Tests that test point should always return false
        /// </summary>
        [Fact]
        public void TestPoint_ShouldAlwaysReturnFalse()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, new Vector2F(10, 0));
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F point = new Vector2F(5, 0);

            bool result = edge.TestPoint(ref transform, ref point);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that edge shape should handle vertical edges
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldHandleVerticalEdges()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(5, 0), new Vector2F(5, 10));

            Assert.Equal(5, edge.Vertex1.X);
            Assert.Equal(5, edge.Vertex2.X);
            Assert.NotEqual(edge.Vertex1.Y, edge.Vertex2.Y);
        }

        /// <summary>
        ///     Tests that edge shape should handle horizontal edges
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldHandleHorizontalEdges()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0, 5), new Vector2F(10, 5));

            Assert.Equal(5, edge.Vertex1.Y);
            Assert.Equal(5, edge.Vertex2.Y);
            Assert.NotEqual(edge.Vertex1.X, edge.Vertex2.X);
        }

        /// <summary>
        ///     Tests that edge shape should handle diagonal edges
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldHandleDiagonalEdges()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 10));

            Assert.Equal(0, edge.Vertex1.X);
            Assert.Equal(10, edge.Vertex2.X);
        }

        /// <summary>
        ///     Tests that edge shape should support adjacent vertices
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldSupportAdjacentVertices()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
            edge.HasVertex0 = true;
            edge.HasVertex3 = true;
            edge.Vertex0 = new Vector2F(-10, 0);
            edge.Vertex3 = new Vector2F(20, 0);

            Assert.True(edge.HasVertex0);
            Assert.True(edge.HasVertex3);
            Assert.Equal(new Vector2F(-10, 0), edge.Vertex0);
            Assert.Equal(new Vector2F(20, 0), edge.Vertex3);
        }

        /// <summary>
        ///     Tests that edge shape should inherit from shape
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldInheritFromShape()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);

            Assert.IsAssignableFrom<Shape>(edge);
        }

        /// <summary>
        ///     Tests that set should reset has vertex flags
        /// </summary>
        [Fact]
        public void Set_ShouldResetHasVertexFlags()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            edge.HasVertex0 = true;
            edge.HasVertex3 = true;

            edge.Set(new Vector2F(5, 5), new Vector2F(10, 10));

            Assert.False(edge.HasVertex0);
            Assert.False(edge.HasVertex3);
        }
    }
}