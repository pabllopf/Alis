using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Alis.Template.Game
{
	[Register(nameof(AppDelegate))]
	public class AppDelegate : MauiUIApplicationDelegate
	{
		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
