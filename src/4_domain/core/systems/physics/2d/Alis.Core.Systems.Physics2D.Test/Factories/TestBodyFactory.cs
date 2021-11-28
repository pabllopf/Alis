// 

using System.Numerics;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Factories;
using Alis.Core.Systems.Physics2D.Shared;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Factories
{
    public class TestBodyFactory
    {
        public World world;
        
        [SetUp]
        public void Setup() => world = new World(Vector2.Zero);
        
        [Test]
        public void TestCreateBody()
        {
            Body body = BodyFactory.CreateRectangle(world, 1, 1, 1);
            Assert.IsNotNull(body);
        }

        [Test]
        public void TestCreateCircle()
        {
            Body body = BodyFactory.CreateCircle(world, 1, 1);

            Assert.IsNotNull(body);
        }
        
        [Test]
        public void TestCreateEdge()
        {
            Body body = BodyFactory.CreateEdge(world, new Vector2(1, 1), new Vector2(2, 2));
            Assert.IsNotNull(body);
        }

        [Test]
        public void CreateBody()
        {
            Body body = BodyFactory.CreateBody(world, new Vector2(0,0),0f , BodyType.Dynamic);

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