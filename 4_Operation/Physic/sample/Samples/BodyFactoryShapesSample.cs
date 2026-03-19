using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The body factory shapes sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class BodyFactoryShapesSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "shapes";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Factory helpers for shapes";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Builds circles, rectangles, polygons and capsule-like bodies via helper APIs.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(new Vector2F(0.0f, -9.81f));
            runtime.AddGround(world, -12.0f, 120.0f, 1.0f);

            Body rectangle = world.CreateRectangle(2.0f, 1.0f, 1.0f, new Vector2F(-6.0f, 9.0f), 0.15f, BodyType.Dynamic);
            Body circle = world.CreateCircle(0.8f, 1.0f, new Vector2F(-2.0f, 10.0f), BodyType.Dynamic);

            Vertices triangle = new Vertices();
            triangle.Add(new Vector2F(-0.8f, -0.6f));
            triangle.Add(new Vector2F(0.8f, -0.6f));
            triangle.Add(new Vector2F(0.0f, 0.9f));
            Body polygon = world.CreatePolygon(triangle, 1.0f, new Vector2F(2.5f, 10.0f), 0.0f, BodyType.Dynamic);

            Body capsule = world.CreateCapsule(2.4f, 0.5f, 1.0f, new Vector2F(6.0f, 11.0f), 0.0f, BodyType.Dynamic);

            runtime.StepWorld(world, 240);
            runtime.PrintBodyState("Rectangle", rectangle);
            runtime.PrintBodyState("Circle", circle);
            runtime.PrintBodyState("Polygon", polygon);
            runtime.PrintBodyState("Capsule", capsule);
        }
    }
}