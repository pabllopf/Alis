using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OpenTK.Graphics.ES20;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace App2
{
    /// <summary>
    /// The app class
    /// </summary>
    /// <seealso cref="Application"/>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Ons the sleep
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Ons the resume
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}