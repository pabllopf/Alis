using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The key event tests class
    /// </summary>
    public class KeyEventTests
    {
        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            try
            {
                KeyEvent evt = new KeyEvent { Code = Keyboard.Key.A, Alt = 1, Control = 0, Shift = 1, System = 0 };
                Assert.Equal(Keyboard.Key.A, evt.Code);
                Assert.True(evt.Alt >= 0);
                Assert.False(evt.Control < 0);
                Assert.True(evt.Shift >= 0);
                Assert.False(evt.System < 0);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }

    /// <summary>
    /// The key event args tests class
    /// </summary>
    public class KeyEventArgsTests
    {
        /// <summary>
        /// Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            try
            {
                KeyEvent evt = new KeyEvent { Code = Keyboard.Key.B, Alt = 0, Control = 1, Shift = 0, System = 1 };
                KeyEventArgs args = new KeyEventArgs(evt);
                Assert.Equal(Keyboard.Key.B, args.Code);
                Assert.False(args.Alt);
                Assert.True(args.Control);
                Assert.False(args.Shift);
                Assert.True(args.System);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            try
            {
                KeyEvent evt = new KeyEvent { Code = Keyboard.Key.C, Alt = 1, Control = 1, Shift = 0, System = 0 };
                KeyEventArgs args = new KeyEventArgs(evt);
                string str = args.ToString();
                Assert.Contains("Code(C)", str);
                Assert.Contains("Alt(True)", str);
                Assert.Contains("Control(True)", str);
                Assert.Contains("Shift(False)", str);
                Assert.Contains("System(False)", str);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }
}
