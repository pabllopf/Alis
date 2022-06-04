using System;
using Foundation;
using AppKit;
using ObjCRuntime;
using OpenGL;

namespace OpenGLViewSample
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;
		GLView view;
		
		public AppDelegate ()
		{
		}

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

