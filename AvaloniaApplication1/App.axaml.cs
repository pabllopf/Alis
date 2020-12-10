using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace AvaloniaApplication1
{
    public class App : Application
    {
        /*public static System.IntPtr handleControl;


        public SFML.Graphics.RenderWindow renderwindow;

        public Window wind;
        */

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                /*renderwindow = new SFML.Graphics.RenderWindow(desktop.MainWindow.PlatformImpl.Handle.Handle);

                wind = desktop.MainWindow;

               handleControl = desktop.MainWindow.PlatformImpl.Handle.Handle;
                
                while (desktop.MainWindow.IsActive) // loop while the window is open
                {
                    renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
                    renderwindow.Clear(SFML.Graphics.Color.Yellow); // clear our SFML RenderWindow
                    renderwindow.Display(); // display what SFML has drawn to the screen
                }*/
            }

            base.OnFrameworkInitializationCompleted();

            /*while (wind.IsActive) // loop while the window is open
            {
                renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
                renderwindow.Clear(SFML.Graphics.Color.Yellow); // clear our SFML RenderWindow
                renderwindow.Display(); // display what SFML has drawn to the screen
            }*/
        }
    }
}
