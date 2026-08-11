// --------------------------------------------------------------------------
// File:ProbeToiTests.cs
using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    public class ProbeToiTests
    {
        [Fact]
        public void Probe_Toi_Diag()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(2.0f, 10.0f, 1.0f, new Vector2F(0, 0));
            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(-10, 0), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(500, 0);
            for (int i = 0; i < 20; i++)
            {
                world.Step(1.0f / 60.0f);
            }
            Assert.True(true);
        }
    }
}
