// license header

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Test.Render;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The touch test class
    /// </summary>
    public class TouchTest
    {
        /// <summary>
        /// Tests that is down method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsDown_Method_Exists()
        {
            Assert.NotNull(typeof(Touch).GetMethod("IsDown"));
        }

        /// <summary>
        /// Tests that get position method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Touch).GetMethod("GetPosition", new[] { typeof(uint) }));
            Assert.NotNull(typeof(Touch).GetMethod("GetPosition", new[] { typeof(uint), typeof(Window) }));
        }

        /// <summary>
        /// Tests that the main thread worker queried the touch position relative to the persistent window
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetPosition_WithWindow_MainThreadWorkerSucceeded()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.TouchHelperPositionExecuted);
        }

        /// <summary>
        /// Tests that get position with a window delegates to the window touch lookup
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetPosition_WithWindow_DelegatesToWindow()
        {
            MockTouchWindow window = new MockTouchWindow();

            Vector2F result = Touch.GetPosition(3, window);

            Assert.True(window.InternalGetTouchPositionCalled);
            Assert.Equal<Vector2F>(new Vector2F(9, 11), result);
        }
    }

    /// <summary>
    /// The mock touch window used to intercept the touch position lookup
    /// </summary>
    public class MockTouchWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockTouchWindow"/> class
        /// </summary>
        public MockTouchWindow() : base(System.IntPtr.Zero, 0)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the touch position lookup was requested
        /// </summary>
        public bool InternalGetTouchPositionCalled { get; private set; }

        /// <summary>
        /// Internals the get touch position using the specified finger
        /// </summary>
        /// <param name="finger">The finger</param>
        /// <returns>The return position</returns>
        public override Vector2F InternalGetTouchPosition(uint finger)
        {
            InternalGetTouchPositionCalled = true;
            return new Vector2F(9, 11);
        }
    }
}
