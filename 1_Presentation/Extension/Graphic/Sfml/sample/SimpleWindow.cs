using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;

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
            RenderWindow window = new RenderWindow(mode, "SFML works!");
            window.KeyPressed += Window_KeyPressed;

            CircleShape circle = new CircleShape(100f)
            {
                FillColor = Color.Blue
            };

            // Start the game loop
            while (window.IsOpen)
            {
                // Process events
                window.DispatchEvents();
                window.Draw(circle);

                // Finally, display the rendered frame on screen
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