using Alis.Builder;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The sound game tests class
    /// </summary>
    public class SoundGameTests
    {
        /// <summary>
        /// Tests that builder should return a sound game builder
        /// </summary>
        [Fact]
        public void Builder_Should_Return_A_SoundGameBuilder() => Assert.Equal(typeof(SoundGameBuilder), SoundGame.Builder().GetType());
        
        /// <summary>
        /// Tests that builder dont should return a null
        /// </summary>
        [Fact]
        public void Builder_Dont_Should_Return_A_Null() => Assert.NotNull(SoundGame.Builder());
    }
}
