// 

using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Dynamics
{
    /// <summary>
    ///     The test time step class
    /// </summary>
    public class TestTimeStep
    {
        /// <summary>
        ///     The step
        /// </summary>
        private TimeStep step;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup() => step = new TimeStep();

        /// <summary>
        ///     Tests that test time step construction
        /// </summary>
        [Test]
        public void TestTimeStepConstruction()
        {
        }

        /// <summary>
        ///     Tests that test time step constructor empty
        /// </summary>
        [Test]
        public void TestTimeStepConstructorEmpty()
        {
            TimeStep step = new TimeStep();
            Assert.AreEqual(0.0, step.DeltaTime);
            Assert.AreEqual(0.0, step.InvertedDeltaTime);
            Assert.AreEqual(0.0, step.DeltaTimeRatio);
            Assert.AreEqual(0.0, step.PositionIterations);
            Assert.AreEqual(0.0, step.VelocityIterations);
            Assert.AreEqual(false, step.WarmStarting);
        }
    }
}