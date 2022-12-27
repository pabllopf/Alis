using Microsoft.Maui.Controls;

namespace Alis.Template.Game.Desktop.MacOs
{
	/// <summary>
	/// The app class
	/// </summary>
	/// <seealso cref="Application"/>
	public partial class App : Application
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="App"/> class
		/// </summary>
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
	}
}
