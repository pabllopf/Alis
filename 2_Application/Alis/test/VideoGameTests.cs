using Alis.Builder;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The video game tests class
    /// </summary>
    public class VideoGameTests
    {
        /// <summary>
        /// Tests that builder should return a video game builder
        /// </summary>
        [Fact]
        public void Builder_Should_Return_A_VideoGameBuilder() => Assert.Equal(typeof(VideoGameBuilder), VideoGame.Builder().GetType());
        
        /// <summary>
        /// Tests that builder dont should return a null
        /// </summary>
        [Fact]
        public void Builder_Dont_Should_Return_A_Null() => Assert.NotNull(VideoGame.Builder());
        
        /// <summary>
        /// Tests that get of setting dont should return a null value
        /// </summary>
        [Fact]
        public void Get_Of_Setting_Dont_Should_Return_A_Null_Value() => Assert.NotNull(VideoGame.Setting);
    }
}
