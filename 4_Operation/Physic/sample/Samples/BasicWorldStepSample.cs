using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The basic world step sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class BasicWorldStepSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "world";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "World, bodies and stepping";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Creates a floor and a falling body, then advances the simulation.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(new Vector2F(0.0f, -9.81f));
            runtime.AddGround(world, -10.0f);

            Body ball = world.CreateCircle(0.6f, 1.0f, new Vector2F(0.0f, 8.0f), BodyType.Dynamic);

            runtime.PrintBodyState("Initial", ball);
            runtime.StepWorld(world, 180);
            runtime.PrintBodyState("After 3s", ball);
        }
    }
}

