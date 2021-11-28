// 

using System.Numerics;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Factories;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Factories
{
    /// <summary>
    ///     The test body factory class
    /// </summary>
    public class TestBodyFactory
    {
        /// <summary>
        ///     The world
        /// </summary>
        public World world;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup() => world = new World(Vector2.Zero);

        /// <summary>
        ///     Tests that test create body
        /// </summary>
        [Test]
        public void TestCreateBody()
        {
            Body body = BodyFactory.CreateRectangle(world, 1, 1, 1);
            Assert.IsNotNull(body);
        }

        /// <summary>
        ///     Tests that test create circle
        /// </summary>
        [Test]
        public void TestCreateCircle()
        {
            Body body = BodyFactory.CreateCircle(world, 1, 1);

            Assert.IsNotNull(body);
        }

        /// <summary>
        ///     Tests that test create edge
        /// </summary>
        [Test]
        public void TestCreateEdge()
        {
            Body body = BodyFactory.CreateEdge(world, new Vector2(1, 1), new Vector2(2, 2));
            Assert.IsNotNull(body);
        }

        /// <summary>
        ///     Tests that create body
        /// </summary>
        [Test]
        public void CreateBody()
        {
            Body body = BodyFactory.CreateBody(world, new Vector2(0, 0), 0f, BodyType.Dynamic);

            Assert.AreEqual(BodyType.Dynamic, body.BodyType);
            Assert.AreEqual(0.0f, body.Position.X);
            Assert.AreEqual(0.0f, body.Position.Y);
            Assert.AreEqual(0.0f, body.Rotation);
            Assert.AreEqual(0.0f, body.LinearDamping);
            Assert.AreEqual(0.0f, body.LinearVelocity.X);
            Assert.AreEqual(0.0f, body.LinearVelocity.Y);
            Assert.AreEqual(0.0f, body.AngularVelocity);
            Assert.AreEqual(0.0f, body.AngularDamping);
            Assert.AreEqual(0.0f, body.Inertia);
            Assert.AreEqual(0.0f, body.Mass);
            Assert.AreEqual(0.0f, body.Inertia);
            Assert.AreEqual(false, body.IsStatic);
            Assert.AreEqual(false, body.IsKinematic);
            Assert.AreEqual(1.0f, body.GravityScale);
        }
    }
}