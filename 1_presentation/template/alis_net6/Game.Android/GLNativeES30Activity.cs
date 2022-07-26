using Android.App;
using Android.Content.PM;
using Android.Opengl;
using Android.OS;
using Android.Views;

namespace HelloAndroid
{
	// the ConfigurationChanges flags set here keep the EGL context
	// from being destroyed whenever the device is rotated or the
	// keyboard is shown (highly recommended for all GL apps)
	/// <summary>
	/// The gl native es 30 activity class
	/// </summary>
	/// <seealso cref="Activity"/>
	[Activity (ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden, MainLauncher = true)]
	public class GLNativeES30Activity : Activity
	{
		/// <summary>
		/// The gl view
		/// </summary>
		private GLSurfaceView mGLView;

		/// <summary>
		/// Ons the create using the specified bundle
		/// </summary>
		/// <param name="bundle">The bundle</param>
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			Game.exampleshareclass.print();
			
			//set up notitle 
			RequestWindowFeature(WindowFeatures.NoTitle);  
			//set up full screen
			Window.SetFlags(flags: WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

			// Create a GLSurfaceView instance and set it
			// as the ContentView for this Activity
			mGLView = new MyGLSurfaceView (this);
			SetContentView (mGLView);
		}

		/// <summary>
		/// Ons the pause
		/// </summary>
		protected override void OnPause ()
		{
			base.OnPause ();

			// The following call pauses the rendering thread.
			// If your OpenGL application is memory intensive,
			// you should consider de-allocating objects that
			// consume significant memory here.
			mGLView.OnPause ();
		}

		/// <summary>
		/// Ons the resume
		/// </summary>
		protected override void OnResume ()
		{
			base.OnResume ();

			// The following call resumes a paused rendering thread.
			// If you de-allocated graphic objects for onPause()
			// this is a good place to re-allocate them.
			mGLView.OnResume ();
		}
	}
}


