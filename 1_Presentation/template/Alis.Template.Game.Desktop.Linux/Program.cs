using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Alis.Template.Game.Desktop.Linux
{
	/// <summary>
	/// The maui program class
	/// </summary>
	public static class MauiProgram
	{
		/// <summary>
		/// Creates the maui app
		/// </summary>
		/// <returns>The maui app</returns>
		public static MauiApp CreateMauiApp() =>
			MauiApp
				.CreateBuilder()
				.UseSkiaSharp(true)
				.UseMauiApp<App>()
				.Build();
	}
}
