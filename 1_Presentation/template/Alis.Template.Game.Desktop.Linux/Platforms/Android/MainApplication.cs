using System;
using Android.App;
using Android.Runtime;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Alis.Template.Mobile
{
	/// <summary>
	/// The main application class
	/// </summary>
	/// <seealso cref="MauiApplication"/>
	[Application]
	public class MainApplication : MauiApplication
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MainApplication"/> class
		/// </summary>
		/// <param name="handle">The handle</param>
		/// <param name="ownership">The ownership</param>
		public MainApplication(IntPtr handle, JniHandleOwnership ownership)
			: base(handle, ownership)
		{
		}

		/// <summary>
		/// Creates the maui app
		/// </summary>
		/// <returns>The maui app</returns>
		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
