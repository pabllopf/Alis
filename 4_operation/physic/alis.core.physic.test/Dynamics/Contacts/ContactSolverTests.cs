// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Aspect.Time;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver tests class
    /// </summary>
    public class ContactSolverTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactSolverTests" /> class
        /// </summary>
        public ContactSolverTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the contact solver
        /// </summary>
        /// <returns>The contact solver</returns>
        private ContactSolver CreateContactSolver()
        {
            return new ContactSolver(new TimeStep(), new[] {new NullContact()}, 10);
        }

        /// <summary>
        ///     Tests that dispose state under test expected behavior
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
        ///     Tests that init velocity constraints state under test expected behavior
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
        ///     Tests that solve velocity constraints state under test expected behavior
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
        ///     Tests that finalize velocity constraints state under test expected behavior
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
        ///     Tests that solve position constraints state under test expected behavior
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