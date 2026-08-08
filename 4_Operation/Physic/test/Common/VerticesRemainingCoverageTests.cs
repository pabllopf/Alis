using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    /// The vertices remaining coverage tests class
    /// </summary>
    public class VerticesRemainingCoverageTests
    {
        /// <summary>
        /// Tests that attached to body default should be false
        /// </summary>
        [Fact]
        public void AttachedToBody_Default_ShouldBeFalse()
        {
            Vertices vertices = new Vertices();
            Assert.False(vertices.AttachedToBody);
        }

        /// <summary>
        /// Tests that attached to body set true should be true
        /// </summary>
        [Fact]
        public void AttachedToBody_SetTrue_ShouldBeTrue()
        {
            Vertices vertices = new Vertices
                {
                    AttachedToBody = true
                };
            Assert.True(vertices.AttachedToBody);
        }

        /// <summary>
        /// Tests that check polygon too many vertices returns invalid amount of vertices
        /// </summary>
        [Fact]
        public void CheckPolygon_TooManyVertices_ReturnsInvalidAmountOfVertices()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0, 1),
                new Vector2F(0.5f, 1.5f),
                new Vector2F(0.5f, 2f),
                new Vector2F(0, 2f),
                new Vector2F(1, 2f),
                new Vector2F(0.5f, 2.5f)
            };

            PolygonError result = vertices.CheckPolygon();

            Assert.Equal(PolygonError.InvalidAmountOfVertices, result);
        }

        /// <summary>
        /// Tests that get signed area cw polygon returns negative
        /// </summary>
        [Fact]
        public void GetSignedArea_CwPolygon_ReturnsNegative()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(0, 1),
                new Vector2F(1, 0)
            };

            float area = vertices.GetSignedArea();

            Assert.True(area < 0);
        }

        /// <summary>
        /// Tests that point in polygon inside cw square returns one
        /// </summary>
        [Fact]
        public void PointInPolygon_InsideCwSquare_ReturnsOne()
        {
            Vertices cwSquare = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(0, 2),
                new Vector2F(2, 2),
                new Vector2F(2, 0)
            };
            Vector2F inside = new Vector2F(1, 1);

            int result = cwSquare.PointInPolygon(ref inside);

            Assert.Equal(1, result);
        }

        /// <summary>
        /// Tests that translate with empty holes does not throw
        /// </summary>
        [Fact]
        public void Translate_WithEmptyHoles_DoesNotThrow()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(1, 2)
            };
            vertices.Holes = new List<Vertices>();

            vertices.Translate(new Vector2F(10, 10));

            Assert.Equal(new Vector2F(10, 10), vertices[0]);
        }

        /// <summary>
        /// Tests that scale with empty holes does not throw
        /// </summary>
        [Fact]
        public void Scale_WithEmptyHoles_DoesNotThrow()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(1, 1),
                new Vector2F(3, 1),
                new Vector2F(2, 3)
            };
            vertices.Holes = new List<Vertices>();

            vertices.Scale(new Vector2F(2, 2));

            Assert.Equal(new Vector2F(2, 2), vertices[0]);
        }

        /// <summary>
        /// Tests that rotate with empty holes does not throw
        /// </summary>
        [Fact]
        public void Rotate_WithEmptyHoles_DoesNotThrow()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(1, 0)
            };
            vertices.Holes = new List<Vertices>();

            vertices.Rotate((float)System.Math.PI / 2);

            Assert.True(System.Math.Abs(vertices[0].X) < 0.001f);
        }
    }
}
