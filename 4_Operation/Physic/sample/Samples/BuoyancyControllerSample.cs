using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The buoyancy controller sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class BuoyancyControllerSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "buoyancy";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Buoyancy controller";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Creates a water volume that applies buoyancy and drag to submerged bodies.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(new Vector2F(0.0f, -9.81f));
            runtime.AddGround(world, -10.0f);

            Aabb water = new Aabb(new Vector2F(-20.0f, -2.0f), new Vector2F(20.0f, 2.0f));
            BuoyancyController controller = new BuoyancyController(water, 2.5f, 2.0f, 1.0f, world.GetGravity);
            world.Add(controller);

            Body floatingBox = world.CreateRectangle(1.6f, 1.6f, 0.5f, new Vector2F(0.0f, 4.0f), 0.0f, BodyType.Dynamic);

            runtime.StepWorld(world, 360, step =>
            {
                if ((step % 120) == 0)
                {
                    runtime.PrintBodyState("Floating box at step " + step, floatingBox);
                }
            });
        }
    }
}