using System;
using System.IO;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.Test.Constructs;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    public class FontMockCoverageTest
    {
        public FontMockCoverageTest()
        {
            GlMock.Initialize();
        }

        [Fact]
        public void RenderText_WithGlMock_DoesNotThrow()
        {
            GlMock.Reset();

            string tempFile = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] bmp =
                {
                    0x42, 0x4D, 0x3A, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x36, 0x00, 0x00, 0x00, 0x28, 0x00,
                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
                    0x00, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
                    0xFF, 0x00
                };
                File.WriteAllBytes(tempFile, bmp);

                Font font = new Font("test.bmp", 1, 12);
                font.Path = tempFile;

                Exception ex = Record.Exception(() =>
                    font.RenderText("hello", 0, 0, Color.White, Color.Black));

                Assert.Null(ex);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }
    }
}
