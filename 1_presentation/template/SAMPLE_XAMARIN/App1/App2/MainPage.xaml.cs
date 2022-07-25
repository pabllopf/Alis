using System;
using alis;
using OpenTK.Graphics.ES30;
using Xamarin.Forms;

namespace App2
{
    /// <summary>
    /// The main page class
    /// </summary>
    /// <seealso cref="ContentPage"/>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class
        /// </summary>
        public MainPage() =>
            Content = new OpenGLView
            {
                HasRenderLoop = true,
                OnDisplay = View_OnDisplay,
            };

        /// <summary>
        /// Views the on display using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        private void View_OnDisplay(Rectangle obj) => OpenGLManager.Render();
    }
}