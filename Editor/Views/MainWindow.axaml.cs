using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Drawing;

namespace Editor.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DrawGameArea();
        }

        private void DrawGameArea()
        {
            bool doneDrawingBackground = false;

            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = 20,
                    Height = 20,
                
                };

            }
        }
    }
}
