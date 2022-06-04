using System;
using System.Linq;
using Foundation;
using AppKit;

namespace OpenGLViewSample
{
	/// <summary>
	/// The main window controller class
	/// </summary>
	/// <seealso cref="AppKit.NSWindowController"/>
	public partial class MainWindowController : AppKit.NSWindowController
	{
		// Called when created from unmanaged code
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowController"/> class
		/// </summary>
		/// <param name="handle">The handle</param>
		public MainWindowController (IntPtr handle) : base (handle)
		{
		}

		// Called when created directly from a XIB file
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowController"/> class
		/// </summary>
		/// <param name="coder">The coder</param>
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
		}

		// Call to load from the XIB/NIB file
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowController"/> class
		/// </summary>
		public MainWindowController () : base ("MainWindow")
		{
		}


		//strongly typed window accessor
		/// <summary>
		/// Gets the value of the window
		/// </summary>
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
	}
}

