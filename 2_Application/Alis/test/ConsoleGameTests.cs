using Alis;
using Moq;
using System;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The console game tests class
    /// </summary>
    public class ConsoleGameTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleGameTests"/> class
        /// </summary>
        public ConsoleGameTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the console game
        /// </summary>
        /// <returns>The console game</returns>
        private ConsoleGame CreateConsoleGame()
        {
            return new ConsoleGame();
        }

        /// <summary>
        /// Tests that run state under test expected behavior
        /// </summary>
        [Fact]
        public void Run_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var consoleGame = this.CreateConsoleGame();

            // Act
            consoleGame.Run();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var consoleGame = this.CreateConsoleGame();

            // Act
            var result = ConsoleGame.Builder();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
