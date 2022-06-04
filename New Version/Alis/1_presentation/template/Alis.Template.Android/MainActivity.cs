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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",
                ConfigurationChanges = ConfigChanges.KeyboardHidden,
                ScreenOrientation = ScreenOrientation.SensorLandscape,
                MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        GLView1 view;
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

