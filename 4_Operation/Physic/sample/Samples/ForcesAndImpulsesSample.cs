using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The forces and impulses sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class ForcesAndImpulsesSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "forces";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Forces vs impulses";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Compares continuous force application against a one-shot impulse.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body forceBody = world.CreateCircle(0.4f, 1.0f, new Vector2F(-4.0f, 0.0f), BodyType.Dynamic);
            Body impulseBody = world.CreateCircle(0.4f, 1.0f, new Vector2F(-4.0f, -2.0f), BodyType.Dynamic);

            Vector2F force = new Vector2F(40.0f, 0.0f);
            Vector2F impulse = new Vector2F(5.0f, 0.0f);
            impulseBody.ApplyLinearImpulse(impulse);

            for (int i = 0; i < 120; i++)
            {
                forceBody.ApplyForce(force);
                world.Step(SampleRuntime.FixedDeltaTime);
            }

            runtime.PrintBodyState("Force body", forceBody);
            runtime.PrintBodyState("Impulse body", impulseBody);
        }
    }
}