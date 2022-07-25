using System;
using alis;
using OpenTK.Graphics.ES30;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage() =>
            Content = new OpenGLView
            {
                HasRenderLoop = true,
                OnDisplay = View_OnDisplay,
            };

        private void View_OnDisplay(Rectangle obj) => OpenGLManager.Render();
    }
}