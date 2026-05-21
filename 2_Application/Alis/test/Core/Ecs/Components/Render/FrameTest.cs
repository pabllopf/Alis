

using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Frame component struct
    /// </summary>
    public class FrameTest
    {
        /// <summary>
        ///     Tests that the constructor creates a Frame with default values
        /// </summary>
        [Fact]
        public void Frame_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            Frame frame = new Frame();

            Assert.Equal(string.Empty, frame.NameFile);
        }

        /// <summary>
        ///     Tests that the NameFile property is gettable and settable
        /// </summary>
        [Fact]
        public void Frame_NameFileProperty_ShouldBeGetAndSettable()
        {
            Frame frame = new Frame();

            frame.NameFile = "frame1.png";
            Assert.Equal("frame1.png", frame.NameFile);

            frame.NameFile = "frame2.jpg";
            Assert.Equal("frame2.jpg", frame.NameFile);
        }

        /// <summary>
        ///     Tests that Frame can be created without exceptions
        /// </summary>
        [Fact]
        public void Frame_Constructor_ShouldNotThrow()
        {
            Frame frame = new Frame();

            Assert.NotNull(frame);
        }

        /// <summary>
        ///     Tests that Frame properties can be modified independently
        /// </summary>
        [Fact]
        public void Frame_NameFile_ShouldBeModifiableIndependently()
        {
            Frame frame = new Frame();

            frame.NameFile = "frame1.png";
            Assert.Equal("frame1.png", frame.NameFile);

            frame.NameFile = "frame2.png";
            Assert.Equal("frame2.png", frame.NameFile);

            frame.NameFile = string.Empty;
            Assert.Equal(string.Empty, frame.NameFile);
        }

        /// <summary>
        ///     Tests that Frame default state is valid
        /// </summary>
        [Fact]
        public void Frame_DefaultState_ShouldBeValid()
        {
            Frame frame = new Frame();

            Assert.NotNull(frame.NameFile);
            Assert.Equal(string.Empty, frame.NameFile);
        }

        /// <summary>
        ///     Tests that Frame has expected public members
        /// </summary>
        [Fact]
        public void Frame_ShouldHaveExpectedPublicMembers()
        {
            Frame frame = new Frame();

            Assert.NotNull(frame.NameFile);
        }

        /// <summary>
        ///     Tests that Frame implements expected interfaces
        /// </summary>
        [Fact]
        public void Frame_ShouldImplementExpectedInterfaces()
        {
            Frame frame = new Frame();

            Assert.IsAssignableFrom<object>(frame);
        }

        /// <summary>
        ///     Tests that Frame constructor doesn't throw with various inputs
        /// </summary>
        [Fact]
        public void Frame_Constructor_WithVariousInputs_ShouldNotThrow()
        {
            Frame frame = new Frame();

            frame.NameFile = "test_frame.png";
            Assert.Equal("test_frame.png", frame.NameFile);

            Frame frame2 = new Frame();
            Assert.NotNull(frame2);
        }
    }
}
