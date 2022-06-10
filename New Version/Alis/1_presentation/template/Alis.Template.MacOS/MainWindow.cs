using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace OpenGLViewSample
{
	/// <summary>
	/// The main window class
	/// </summary>
	/// <seealso cref="AppKit.NSWindow"/>
	public partial class MainWindow : AppKit.NSWindow
	{
		// Called when created from unmanaged code
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindow"/> class
		/// </summary>
		/// <param name="handle">The handle</param>
		public MainWindow (IntPtr handle) : base (handle)
		{
		}

		// Called when created directly from a XIB file
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindow"/> class
		/// </summary>
		/// <param name="coder">The coder</param>
		[Export ("initWithCoder:")]
		public MainWindow (NSCoder coder) : base (coder)
		{
		}
	}
}

