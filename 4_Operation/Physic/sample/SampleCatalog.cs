using System.Collections.Generic;
using Alis.Core.Physic.Sample.Samples;

namespace Alis.Core.Physic.Sample
{
    internal static class SampleCatalog
    {
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

