using Android.App;
using Android.Content.PM;
using Microsoft.Maui;

namespace Alis.Template.Mobile
{
	/// <summary>
	/// The main activity class
	/// </summary>
	/// <seealso cref="MauiAppCompatActivity"/>
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : MauiAppCompatActivity
	{
	}
}
