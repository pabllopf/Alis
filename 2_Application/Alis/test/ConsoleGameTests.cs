using Alis.Builder;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The console game tests class
    /// </summary>
    public class ConsoleGameTests
    {
        
        /// <summary>
        /// Tests that builder should return a console game builder
        /// </summary>
        [Fact]
        public void Builder_Should_Return_A_ConsoleGameBuilder() => Assert.Equal(typeof(ConsoleGameBuilder), ConsoleGame.Builder().GetType());
        
      
        /// <summary>
        /// Tests that builder dont should return a null
        /// </summary>
        [Fact]
        public void Builder_Dont_Should_Return_A_Null() => Assert.NotNull(ConsoleGame.Builder());
    }
}
