using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Alis.Template.Mobile
{
	/// <summary>
	/// The app delegate class
	/// </summary>
	/// <seealso cref="MauiUIApplicationDelegate"/>
	[Register(nameof(AppDelegate))]
	public class AppDelegate : MauiUIApplicationDelegate
	{
		/// <summary>
		/// Creates the maui app
		/// </summary>
		/// <returns>The maui app</returns>
		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
