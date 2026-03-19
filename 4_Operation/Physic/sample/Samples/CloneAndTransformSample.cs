using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    internal sealed class CloneAndTransformSample : IPhysicSample
    {
        public string Key => "clone";

        public string Title => "Clone, transform and point-space conversions";

        public string Description => "Clones bodies and converts points between local/world space.";

        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body original = world.CreateRectangle(2.0f, 1.0f, 1.0f, new Vector2F(-2.0f, 0.0f), 0.25f, BodyType.Dynamic);
            original.LinearVelocity = new Vector2F(1.5f, 0.0f);
            original.AngularVelocity = 1.0f;

            Body clone = original.DeepClone(world);
            clone.Position = new Vector2F(2.0f, 0.0f);
            clone.ApplyLinearImpulse(new Vector2F(0.0f, 2.5f));

            Vector2F localPoint = new Vector2F(1.0f, 0.0f);
            Vector2F worldPoint = original.GetWorldPoint(localPoint);
            Vector2F backToLocal = original.GetLocalPoint(worldPoint);

            Console.WriteLine("World point from local (1,0): ({0:F2}, {1:F2})", worldPoint.X, worldPoint.Y);
            Console.WriteLine("Local point recovered: ({0:F2}, {1:F2})", backToLocal.X, backToLocal.Y);

            runtime.StepWorld(world, 180);
            runtime.PrintBodyState("Original", original);
            runtime.PrintBodyState("Clone", clone);
        }
    }
}