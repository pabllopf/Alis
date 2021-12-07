// 

using System.Numerics;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Tools.ConvexHull;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Tools.ConvexHull
{
    /// <summary>
    ///     Test of class: Andrew's Monotone Chain Convex Hull algorithm. Used to get the convex hull of a point cloud.
    /// </summary>
    public class TestChainHull
    {
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }
        
        /// <summary>
        /// Tests that test get convex hull
        /// </summary>
        [Test]
        public void TestGetConvexHull()
        {
            Vertices? vertices = new Vertices();
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(1, 0);
            Vector2 point3 = new Vector2(0, 1);
            
            vertices.Add(point1);
            vertices.Add(point2);
            vertices.Add(point3);

            Vertices? convexHull = ChainHull.GetConvexHull(vertices);
            
            Assert.AreEqual(convexHull.Count, 3);
            Assert.IsTrue(convexHull[0] == vertices[0]);
            Assert.IsTrue(convexHull[1] == vertices[1]);
            Assert.IsTrue(convexHull[2] == vertices[2]);
        }
    }
}