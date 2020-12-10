using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Threading;

namespace AvaloniaApplication1
{
    public class MainWindow : Window
    {
        public event Action<TimeSpan> Tick;
        Thread _renderTick;

        public static System.IntPtr handleControl;


        public SFML.Graphics.RenderWindow renderwindow;

        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);

            Window1 window1 = new Window1();


            _renderTick = new Thread(() =>
            {
               
                renderwindow = new SFML.Graphics.RenderWindow(window1.PlatformImpl.Handle.Handle);

                renderwindow.Size = new SFML.System.Vector2u(100, 100);

                while (true)
                {
                    renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
                    renderwindow.Clear(SFML.Graphics.Color.Yellow); // clear our SFML RenderWindow
                    renderwindow.Display(); // display what SFML has drawn to the screen
                    Tick?.Invoke(TimeSpan.FromMilliseconds(Environment.TickCount));
                }
            });
            _renderTick.IsBackground = true;
            _renderTick.Start();
        }

        private void DwmFlush()
        {

            
            Console.WriteLine("Every frame");
        }

        protected override void HandlePaint(Rect rect)
        {
            //base.HandlePaint(rect);

            Console.WriteLine("HandlePaint()");
        }

        public override void Render(DrawingContext context)
        {
            //base.Render(context);
            Console.WriteLine("Render");
        }

        protected override void UpdateDataValidation(AvaloniaProperty property, BindingNotification status)
        {
            //base.UpdateDataValidation(property, status);

            Console.WriteLine("UpdateDataValidation()");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        /*Window window;
        Window Parent;

        public SFML.Graphics.RenderWindow renderwindow;

        public System.IntPtr handleControl;

        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            handleControl = PlatformImpl.Handle.Handle;
            renderwindow = new SFML.Graphics.RenderWindow(handleControl);

            this.LayoutUpdated += VlcPreviewWindow_LayoutUpdated;
            this.AttachedToVisualTree += VlcPreviewWindow_AttachedToVisualTree;
            window = new Window();
            window.Background = Avalonia.Media.Brushes.Black;
            window.WindowStartupLocation = WindowStartupLocation.Manual;
            window.WindowState = WindowState.Normal;
            window.HasSystemDecorations = false;
            window.ShowInTaskbar = false;

        }

        private void VlcPreviewWindow_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            Parent = (Window)e.Root;
            Parent.PositionChanged += Parent_PositionChanged;
        }

        private void Parent_PositionChanged(object sender, PixelPointEventArgs e)
        {
            window.Position = this.PointToScreen(this.Bounds.Position);
        }

        private void VlcPreviewWindow_LayoutUpdated(object sender, System.EventArgs e)
        {
            window.Position = this.PointToScreen(this.Bounds.Position);
            window.Width = this.Bounds.Width;
            window.Height = this.Bounds.Height;
            window.Topmost = true;



            //NativeMethods.SetWindowPos(HWND, NativeMethods.HWND_TOPMOST, window.Position.X, window.Position.Y, (int)window.Width, (int)window.Height, 0);
        }*/
    }
}
