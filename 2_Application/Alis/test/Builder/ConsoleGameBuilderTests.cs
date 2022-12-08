using Alis.Builder;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder
{
    /// <summary>
    /// The console game builder tests class
    /// </summary>
    public class ConsoleGameBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleGameBuilderTests"/> class
        /// </summary>
        public ConsoleGameBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the console game builder
        /// </summary>
        /// <returns>The console game builder</returns>
        private ConsoleGameBuilder CreateConsoleGameBuilder()
        {
            return new ConsoleGameBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var consoleGameBuilder = this.CreateConsoleGameBuilder();

            // Act
            var result = consoleGameBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that run state under test expected behavior
        /// </summary>
        [Fact]
        public void Run_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var consoleGameBuilder = this.CreateConsoleGameBuilder();

            // Act
            consoleGameBuilder.Run();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
