using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    internal sealed class ControllersGravityAndLimitSample : IPhysicSample
    {
        public string Key => "controllers";

        public string Title => "Gravity and velocity-limit controllers";

        public string Description => "Uses controllers to add custom gravity and cap linear/angular speeds.";

        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body orbA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-6.0f, 0.0f), BodyType.Dynamic);
            Body orbB = world.CreateCircle(0.5f, 1.0f, new Vector2F(6.0f, 0.0f), BodyType.Dynamic);

            GravityController gravityController = new GravityController(0.20f, 40.0f, 0.5f);
            gravityController.AddPoint(Vector2F.Zero);

            VelocityLimitController limitController = new VelocityLimitController(4.5f, 2.0f);
            limitController.AddBody(orbA);
            limitController.AddBody(orbB);

            world.Add(gravityController);
            world.Add(limitController);

            orbA.ApplyLinearImpulse(new Vector2F(6.0f, 1.5f));
            orbB.ApplyLinearImpulse(new Vector2F(-6.0f, -1.0f));

            runtime.StepWorld(world, 300);
            runtime.PrintBodyState("Orb A", orbA);
            runtime.PrintBodyState("Orb B", orbB);
        }
    }
}