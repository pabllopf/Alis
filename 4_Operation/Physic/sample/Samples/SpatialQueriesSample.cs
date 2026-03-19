using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    internal sealed class SpatialQueriesSample : IPhysicSample
    {
        public string Key => "queries";

        public string Title => "AABB queries, ray-casts and point tests";

        public string Description => "Demonstrates WorldPhysic.QueryAabb, WorldPhysic.RayCast and WorldPhysic.TestPoint.";

        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            world.CreateCircle(0.8f, 0.0f, new Vector2F(-3.0f, 0.0f), BodyType.Static);
            world.CreateRectangle(2.0f, 1.0f, 0.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);
            world.CreateCircle(0.6f, 0.0f, new Vector2F(3.0f, 0.0f), BodyType.Static);

            Aabb queryRegion = new Aabb(new Vector2F(0.0f, 0.0f), 8.0f, 4.0f);
            int aabbHits = 0;
            world.QueryAabb(
                fixture =>
                {
                    aabbHits++;
                    return true;
                },
                ref queryRegion);

            int rayHits = 0;
            world.RayCast(
                (fixture, point, normal, fraction) =>
                {
                    rayHits++;
                    return 1.0f;
                },
                new Vector2F(-10.0f, 0.0f),
                new Vector2F(10.0f, 0.0f));

            Fixture testedFixture = world.TestPoint(new Vector2F(0.0f, 0.0f));

            Console.WriteLine("AABB hits: {0}", aabbHits);
            Console.WriteLine("Ray hits: {0}", rayHits);
            Console.WriteLine("TestPoint found fixture: {0}", testedFixture != null ? "yes" : "no");
        }
    }
}