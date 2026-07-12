using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im draw cmd remaining coverage tests class
    /// </summary>
    public class ImDrawCmdRemainingCoverageTests
    {
        /// <summary>
        /// Tests that get tex id should call native method
        /// </summary>
        [Fact]
        public void GetTexId_ShouldCallNativeMethod()
        {
            ImDrawCmd cmd = new ImDrawCmd();
            _ = cmd.GetTexId();
        }
    }
}
