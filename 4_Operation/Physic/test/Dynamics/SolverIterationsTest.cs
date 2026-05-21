

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The solver iterations test class
    /// </summary>
    public class SolverIterationsTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            SolverIterations iterations = new SolverIterations();

            Assert.Equal(0, iterations.VelocityIterations);
            Assert.Equal(0, iterations.PositionIterations);
            Assert.Equal(0, iterations.ToiVelocityIterations);
            Assert.Equal(0, iterations.ToiPositionIterations);
        }

        /// <summary>
        ///     Tests that velocity iterations should set and get correctly
        /// </summary>
        [Fact]
        public void VelocityIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = 8
            };

            Assert.Equal(8, iterations.VelocityIterations);
        }

        /// <summary>
        ///     Tests that position iterations should set and get correctly
        /// </summary>
        [Fact]
        public void PositionIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                PositionIterations = 3
            };

            Assert.Equal(3, iterations.PositionIterations);
        }

        /// <summary>
        ///     Tests that toi velocity iterations should set and get correctly
        /// </summary>
        [Fact]
        public void ToiVelocityIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                ToiVelocityIterations = 10
            };

            Assert.Equal(10, iterations.ToiVelocityIterations);
        }

        /// <summary>
        ///     Tests that toi position iterations should set and get correctly
        /// </summary>
        [Fact]
        public void ToiPositionIterations_ShouldSetAndGetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                ToiPositionIterations = 20
            };

            Assert.Equal(20, iterations.ToiPositionIterations);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = 8,
                PositionIterations = 3,
                ToiVelocityIterations = 10,
                ToiPositionIterations = 20
            };

            Assert.Equal(8, iterations.VelocityIterations);
            Assert.Equal(3, iterations.PositionIterations);
            Assert.Equal(10, iterations.ToiVelocityIterations);
            Assert.Equal(20, iterations.ToiPositionIterations);
        }

        /// <summary>
        ///     Tests that iterations with negative values should work
        /// </summary>
        [Fact]
        public void Iterations_WithNegativeValues_ShouldWork()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = -1,
                PositionIterations = -1
            };

            Assert.Equal(-1, iterations.VelocityIterations);
            Assert.Equal(-1, iterations.PositionIterations);
        }

        /// <summary>
        ///     Tests that iterations with zero should work
        /// </summary>
        [Fact]
        public void Iterations_WithZero_ShouldWork()
        {
            SolverIterations iterations = new SolverIterations
            {
                VelocityIterations = 0,
                PositionIterations = 0,
                ToiVelocityIterations = 0,
                ToiPositionIterations = 0
            };

            Assert.Equal(0, iterations.VelocityIterations);
            Assert.Equal(0, iterations.PositionIterations);
            Assert.Equal(0, iterations.ToiVelocityIterations);
            Assert.Equal(0, iterations.ToiPositionIterations);
        }
    }
}