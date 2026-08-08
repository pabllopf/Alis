using Alis.Extension.Graphic.Ui.Test.Attributes;

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
        [RequireCImguiSystemFact]
        public void GetTexId_ShouldCallNativeMethod()
        {
            ImDrawCmd cmd = new ImDrawCmd();
            _ = cmd.GetTexId();
        }
    }
}
