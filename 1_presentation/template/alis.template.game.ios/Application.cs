using UIKit;

namespace Alis.Template.Game.Ios {
	/// <summary>
	/// The application class
	/// </summary>
	public class Application {
		// This is the main entry point of the application.
		/// <summary>
		/// Main the args
		/// </summary>
		/// <param name="args">The args</param>
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, typeof(AppDelegate));
		}
	}
}

