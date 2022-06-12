using AppKit;
using Foundation;

namespace MMOpenTK
{
	/// <summary>
	/// The app delegate class
	/// </summary>
	/// <seealso cref="NSApplicationDelegate"/>
	public partial class AppDelegate : NSApplicationDelegate
	{
		/// <summary>
		/// The main window controller
		/// </summary>
		MainWindowController mainWindowController;
		/// <summary>
		/// The view
		/// </summary>
		GLView view;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="AppDelegate"/> class
		/// </summary>
		public AppDelegate ()
		{
		}

		/// <summary>
		/// Dids the finish launching using the specified notification
		/// </summary>
		/// <param name="notification">The notification</param>
		public override void DidFinishLaunching (NSNotification notification)
		{
			mainWindowController = new MainWindowController ();
			view = new GLView (mainWindowController.Window.Frame, new NSOpenGLPixelFormat (new object [] {
										NSOpenGLPixelFormatAttribute.Accelerated,
										NSOpenGLPixelFormatAttribute.MinimumPolicy				
			}));
			
			mainWindowController.Window.ContentView = view;
 			mainWindowController.Window.MakeKeyAndOrderFront (this);
		}
	}
}

