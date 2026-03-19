using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The collision filtering and sensors sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class CollisionFilteringAndSensorsSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "filter";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Collision filtering and sensors";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Shows category masks and non-solid sensor fixtures.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            RunSensorScenario(runtime);
            runtime.PrintSeparator();
            RunCategoryFilteringScenario(runtime);
        }

        /// <summary>
        /// Runs the sensor scenario using the specified runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        private static void RunSensorScenario(SampleRuntime runtime)
        {
            Console.WriteLine("Sensor scenario");
            WorldPhysic world = runtime.CreateWorld(new Vector2F(0.0f, -9.81f));
            runtime.AddGround(world, -10.0f);

            Body sensorBody = world.CreateBody(new Vector2F(0.0f, 3.0f), 0.0f, BodyType.Static);
            Fixture sensor = sensorBody.CreateRectangle(6.0f, 0.8f, 0.0f, Vector2F.Zero);
            sensor.GetIsSensor = true;

            Body fallingBall = world.CreateBody(new Vector2F(0.0f, 8.0f), 0.0f, BodyType.Dynamic);
            fallingBall.CreateCircle(0.6f, 1.0f);

            int touches = 0;
            sensor.OnCollision = (sender, other, contact) =>
            {
                touches++;
                return true;
            };

            runtime.StepWorld(world, 180);
            Console.WriteLine("Sensor touch callbacks: {0}", touches);
            runtime.PrintBodyState("Falling ball", fallingBall);
        }

        /// <summary>
        /// Runs the category filtering scenario using the specified runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        private static void RunCategoryFilteringScenario(SampleRuntime runtime)
        {
            Console.WriteLine("Category filtering scenario");
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body left = world.CreateBody(new Vector2F(-6.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body right = world.CreateBody(new Vector2F(6.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture leftFixture = left.CreateCircle(0.8f, 1.0f);
            Fixture rightFixture = right.CreateCircle(0.8f, 1.0f);

            leftFixture.GetCollisionCategories = Category.Cat2;
            leftFixture.GetCollidesWith = Category.Cat3;
            rightFixture.GetCollisionCategories = Category.Cat4;
            rightFixture.GetCollidesWith = Category.Cat1;

            int collisions = 0;
            leftFixture.OnCollision = (sender, other, contact) =>
            {
                collisions++;
                return true;
            };

            left.LinearVelocity = new Vector2F(6.0f, 0.0f);
            right.LinearVelocity = new Vector2F(-6.0f, 0.0f);

            runtime.StepWorld(world, 180);
            Console.WriteLine("Filtered collisions between pair: {0}", collisions);
            runtime.PrintBodyState("Left filtered body", left);
            runtime.PrintBodyState("Right filtered body", right);
        }
    }
}