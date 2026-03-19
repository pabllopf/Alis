using System.Collections.Generic;
using Alis.Core.Physic.Sample.Samples;

namespace Alis.Core.Physic.Sample
{
    /// <summary>
    /// The sample catalog class
    /// </summary>
    internal static class SampleCatalog
    {
        /// <summary>
        /// Gets the value of the all
        /// </summary>
        public static IReadOnlyList<IPhysicSample> All { get; } =
            new List<IPhysicSample>
            {
                new BasicWorldStepSample(),
                new BodyFactoryShapesSample(),
                new ForcesAndImpulsesSample(),
                new CollisionCallbacksSample(),
                new CollisionFilteringAndSensorsSample(),
                new JointsDistanceAndRevoluteSample(),
                new ControllersGravityAndLimitSample(),
                new BuoyancyControllerSample(),
                new SpatialQueriesSample(),
                new CloneAndTransformSample()
            };
    }
}

