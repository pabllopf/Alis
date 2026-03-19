using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The collision callbacks sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class CollisionCallbacksSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "callbacks";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Collision callbacks";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Subscribes to collision and separation callbacks on fixtures and bodies.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body left = world.CreateBody(new Vector2F(-2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body right = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture leftFixture = left.CreateCircle(0.8f, 1.0f);
            Fixture rightFixture = right.CreateCircle(0.8f, 1.0f);

            left.LinearVelocity = new Vector2F(4.0f, 0.0f);
            right.LinearVelocity = new Vector2F(-4.0f, 0.0f);

            int fixtureCollisionCount = 0;
            int fixtureSeparationCount = 0;
            int bodyCollisionCount = 0;

            leftFixture.OnCollision = (sender, other, contact) =>
            {
                fixtureCollisionCount++;
                return true;
            };
            leftFixture.OnSeparation = (sender, other, contact) => { fixtureSeparationCount++; };
            left.OnCollision += (sender, other, contact) =>
            {
                bodyCollisionCount++;
                return true;
            };

            runtime.StepWorld(world, 180);
            Console.WriteLine("Fixture collisions: {0}", fixtureCollisionCount);
            Console.WriteLine("Fixture separations: {0}", fixtureSeparationCount);
            Console.WriteLine("Body collisions: {0}", bodyCollisionCount);
            runtime.PrintBodyState("Left", left);
            runtime.PrintBodyState("Right", right);
        }
    }
}