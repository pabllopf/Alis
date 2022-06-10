using System;
using CoreGraphics;
using Foundation;
using AppKit;
using ObjCRuntime;

namespace MMOpenTK
{
	/// <summary>
	/// The main class
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// Main the args
		/// </summary>
		/// <param name="args">The args</param>
		static void Main (string[] args)
		{
			NSApplication.Init ();
			NSApplication.Main (args);
		}
	}
}	

