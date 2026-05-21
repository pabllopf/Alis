

using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;
using Styles = Alis.Extension.Graphic.Sfml.Windows.Styles;

namespace Alis.Extension.Graphic.Sfml.Sample
{
    /// <summary>
    ///     The simple window class
    /// </summary>
    internal class SimpleWindow
    {
        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            VideoMode mode = new VideoMode(800, 600);
            ContextSettings settings = new ContextSettings(0, 0, 0, 2, 1, ContextSettings.Attribute.None, false);
            RenderWindow window = new RenderWindow(mode, "SFML works!", Styles.Default, settings);
            window.KeyPressed += Window_KeyPressed;

            CircleShape circle = new CircleShape(100f)
            {
                FillColor = Color.Blue
            };

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Draw(circle);

                window.Display();
            }
        }

        /// <summary>
        ///     Function called when a key is pressed
        /// </summary>
        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            Window window = (Window) sender;
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
    }
}