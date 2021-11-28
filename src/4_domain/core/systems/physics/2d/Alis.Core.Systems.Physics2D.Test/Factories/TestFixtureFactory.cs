// 

using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.Shapes;
using Alis.Core.Systems.Physics2D.Definitions;
using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;
using Alis.Core.Systems.Physics2D.Factories;

namespace Alis.Core.Systems.Physics2D.Test.Factories
{
    /// <summary>
    /// The test fixture factory class
    /// </summary>
    public class TestFixtureFactory
    {
        private Fixture fixture;
        
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        ///     Tests that test 1
        /// </summary>
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestCreateFromDef()
        {
            Body? body = BodyFactory.CreateBody(new World(new Vector2(0, 0)));
            CircleShape? shape = new CircleShape(1, 1);
            FixtureDef? fixtureDef = new FixtureDef
            {
                Shape = shape,
                Friction = 0.3f,
                Restitution = 0.5f
            };

            fixture = FixtureFactory.CreateFromDef(body, fixtureDef);
        }
    }
}