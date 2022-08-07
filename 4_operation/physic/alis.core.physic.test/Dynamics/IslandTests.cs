using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The island tests class
    /// </summary>
    public class IslandTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock contact listener
        /// </summary>
        private Mock<IContactListener> mockContactListener;

        /// <summary>
        /// Initializes a new instance of the <see cref="IslandTests"/> class
        /// </summary>
        public IslandTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockContactListener = mockRepository.Create<IContactListener>();
        }

        /// <summary>
        /// Creates the island
        /// </summary>
        /// <returns>The island</returns>
        private Island CreateIsland()
        {
            return new Island(
                TODO,
                TODO,
                TODO,
                mockContactListener.Object);
        }

        /// <summary>
        /// Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var island = CreateIsland();

            // Act
            island.Dispose();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that clear state under test expected behavior
        /// </summary>
        [Fact]
        public void Clear_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var island = CreateIsland();

            // Act
            island.Clear();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that solve state under test expected behavior
        /// </summary>
        [Fact]
        public void Solve_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var island = CreateIsland();
            TimeStep step = default(Aspect.Time.TimeStep);
            Vector2 gravity = default(global::Alis.Aspect.Math.Vector2);
            bool allowSleep = false;

            // Act
            island.Solve(
                step,
                gravity,
                allowSleep);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that solve toi state under test expected behavior
        /// </summary>
        [Fact]
        public void SolveToi_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var island = CreateIsland();
            TimeStep subStep = default(Aspect.Time.TimeStep);

            // Act
            island.SolveToi(
                ref subStep);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add state under test expected behavior
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var island = CreateIsland();
            Body body = null;

            // Act
            island.Add(
                body);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add state under test expected behavior 1
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var island = CreateIsland();
            Contact contact = null;

            // Act
            island.Add(
                contact);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add state under test expected behavior 2
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var island = CreateIsland();
            Joint joint = null;

            // Act
            island.Add(
                joint);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that report state under test expected behavior
        /// </summary>
        [Fact]
        public void Report_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var island = CreateIsland();
            ContactConstraint[] constraints = null;

            // Act
            island.Report(
                constraints);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
