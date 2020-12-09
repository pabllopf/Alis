namespace EditorSimple
{
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;
    using Avalonia.Threading;
    using System;

    public partial class MainWindow : Avalonia.Controls.Window
    {
        private RenderWindow _renderWindow;
        private readonly CircleShape _circle;
        private readonly DispatcherTimer _timer;

        public MainWindow()
        {
            //InitializeComponent();

            this._circle = new CircleShape(20) { FillColor = Color.Magenta };
            this.CreateRenderWindow();

            var refreshRate = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            this._timer = new DispatcherTimer { Interval = refreshRate };
            this._timer.Tick += Timer_Tick;
            this._timer.Start();
        }

        private void CreateRenderWindow()
        {
            if (this._renderWindow != null)
            {
                this._renderWindow.SetActive(false);
                this._renderWindow.Dispose();
            }

            var context = new ContextSettings { DepthBits = 24 };
            _renderWindow = new RenderWindow(,);
            this._renderWindow = new RenderWindow(this.DrawSurface.Handle, context);
            this._renderWindow.MouseButtonPressed += RenderWindow_MouseButtonPressed;
            this._renderWindow.SetActive(true);
        }

        private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var rand = new Random();
            var color = new Color((byte)rand.Next(), (byte)rand.Next(), (byte)rand.Next());
            this._circle.FillColor = color;
        }


        private void DrawSurface_SizeChanged(object sender, EventArgs e)
        {
            this.CreateRenderWindow();
        }

        private void RenderWindow_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            this._circle.Position = new Vector2f(e.X, e.Y);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this._renderWindow.DispatchEvents();

            this._renderWindow.Clear(Color.Black);
            this._renderWindow.Draw(this._circle);
            this._renderWindow.Display();
        }


    }
}
