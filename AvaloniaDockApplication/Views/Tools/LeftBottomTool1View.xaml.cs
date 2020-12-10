using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Threading;

namespace AvaloniaDockApplication.Views.Tools
{
    public class LeftBottomTool1View : UserControl
    {
        private Window window;
        Window Parent;

        public event Action<TimeSpan> Tick;
        Thread _renderTick;

        public static System.IntPtr handleControl;


        public SFML.Graphics.RenderWindow renderwindow;

        public LeftBottomTool1View()
        {
            AvaloniaXamlLoader.Load(this);

            this.LayoutUpdated += VlcPreviewWindow_LayoutUpdated;
            this.AttachedToVisualTree += VlcPreviewWindow_AttachedToVisualTree;

            window = new Window();
            window.Background = Avalonia.Media.Brushes.Black;
            window.WindowStartupLocation = WindowStartupLocation.Manual;
            window.WindowState = WindowState.Normal;
            window.HasSystemDecorations = false;
            window.ShowInTaskbar = false;

            renderwindow = new SFML.Graphics.RenderWindow(window.PlatformImpl.Handle.Handle);

        }

        private void VlcPreviewWindow_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            Parent = (Window)e.Root;
            Parent.PositionChanged += Parent_PositionChanged;

            uint width = (uint)Bounds.Width - 15;
            uint height = (uint)Bounds.Height - 20;

            renderwindow.Size = new SFML.System.Vector2u(width, height);
            renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
            renderwindow.Clear(SFML.Graphics.Color.Yellow); // clear our SFML RenderWindow
            renderwindow.Display(); // display what SFML has drawn to the screen

        }

        private void Parent_PositionChanged(object sender, PixelPointEventArgs e)
        {
            window.Position = this.PointToScreen(this.Bounds.Position);
            window.SizeToContent = Parent.SizeToContent;

            uint width = (uint)Bounds.Width - 15;
            uint height = (uint)Bounds.Height - 20;

            renderwindow.Size = new SFML.System.Vector2u(width, height);
            renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
            renderwindow.Clear(SFML.Graphics.Color.Yellow); // clear our SFML RenderWindow
            renderwindow.Display(); // display what SFML has drawn to the screen

        }

        private void VlcPreviewWindow_LayoutUpdated(object sender, System.EventArgs e)
        {
            window.Position = this.PointToScreen(this.Bounds.Position);
            window.Width = this.Bounds.Width;
            window.Height = this.Bounds.Height;
            window.Topmost = true;

            uint width = (uint)Bounds.Width - 15;
            uint height = (uint)Bounds.Height - 20;

            renderwindow.Size = new SFML.System.Vector2u(width, height);
            renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
            renderwindow.Clear(SFML.Graphics.Color.Yellow); // clear our SFML RenderWindow
            renderwindow.Display(); // display what SFML has drawn to the screen

            //NativeMethods.SetWindowPos(HWND, NativeMethods.HWND_TOPMOST, window.Position.X, window.Position.Y, (int)window.Width, (int)window.Height, 0);
        }
    }
}
