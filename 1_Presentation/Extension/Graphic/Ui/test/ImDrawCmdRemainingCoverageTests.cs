using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImDrawCmdRemainingCoverageTests
    {
        [Fact]
        public void GetTexId_ShouldCallNativeMethod()
        {
            ImDrawCmd cmd = new ImDrawCmd();
            _ = cmd.GetTexId();
        }
    }
}
