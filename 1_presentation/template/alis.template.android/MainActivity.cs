using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;
using AndroidX.AppCompat.App;

namespace Alis.Template.Android

{
    // The ConfigurationChanges flags set here keep the EGL context
    // from being destroyed whenever the device is rotated or the
    // keyboard is shown (highly recommended for all GL apps)
    /// <summary>
    /// The main activity class
    /// </summary>
    /// <seealso cref="AppCompatActivity"/>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",
                ConfigurationChanges = ConfigChanges.KeyboardHidden,
                ScreenOrientation = ScreenOrientation.SensorLandscape,
                MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        /// <summary>
        /// The view
        /// </summary>
        GLView1 view;
        /// <summary>
        /// Ons the create using the specified saved instance state
        /// </summary>
        /// <param name="savedInstanceState">The saved instance state</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var manager = GetSystemService(Context.ActivityService) as ActivityManager;
            if (manager.DeviceConfigurationInfo.ReqGlEsVersion >= 0x30000)
            {
                // Create our OpenGL view, and display it
                view = new GLView1(this);
                SetContentView(view);
            }
            else
                SetContentView(Resource.Layout.activity_main);
        }
    }
}

