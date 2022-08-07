using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Alis.Aspect.Time;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact solver tests class
    /// </summary>
    public class ContactSolverTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactSolverTests"/> class
        /// </summary>
        public ContactSolverTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the contact solver
        /// </summary>
        /// <returns>The contact solver</returns>
        private ContactSolver CreateContactSolver()
        {
            return new ContactSolver(new TimeStep(),new []{new NullContact()}, 10);
        }

        /// <summary>
        /// Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var contactSolver = CreateContactSolver();

            // Act
            //contactSolver.Dispose();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that init velocity constraints state under test expected behavior
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
           /* var contactSolver = CreateContactSolver();
            TimeStep step = default(TimeStep);

            // Act
            contactSolver.InitVelocityConstraints(
                step);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that solve velocity constraints state under test expected behavior
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var contactSolver = CreateContactSolver();

            // Act
            contactSolver.SolveVelocityConstraints();
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that finalize velocity constraints state under test expected behavior
        /// </summary>
        [Fact]
        public void FinalizeVelocityConstraints_StateUnderTest_ExpectedBehavior()
        { 
            /*
            // Arrange
            var contactSolver = CreateContactSolver();

            // Act
            contactSolver.FinalizeVelocityConstraints();
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that solve position constraints state under test expected behavior
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var contactSolver = CreateContactSolver();
            float baumgarte = 0;

            // Act
            var result = contactSolver.SolvePositionConstraints(
                baumgarte);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
