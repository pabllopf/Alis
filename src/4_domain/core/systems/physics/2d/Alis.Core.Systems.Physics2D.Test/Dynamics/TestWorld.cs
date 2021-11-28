// 

using System.Numerics;
using Alis.Core.Systems.Physics2D.Definitions;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Factories;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    public class TestWorld
    {
        public World world;
        
        [SetUp]
        public void Setup() => world = new World(Vector2.Zero);

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void Test_AddBody(int expected, int count)
        {
            for (int i = 0; i < count; i++)
            {
                world.AddBody(new Body(new BodyDef()));
            }
            
            Assert.AreEqual(expected, world.BodyList.Count);
        }
        
    }
}