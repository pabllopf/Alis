using Foundation;

namespace Alis.Template.Game.Ios
{
	/// <summary>
	/// The game view controller class
	/// </summary>
	[Register ("GameViewController")]
	partial class GameViewController
	{
		/// <summary>
		/// Gets or sets the value of the metal performance shaders disabled label
		/// </summary>
		[Outlet]
		UIKit.UILabel MetalPerformanceShadersDisabledLabel { get; set; }
		
		/// <summary>
		/// Releases the designer outlets
		/// </summary>
		void ReleaseDesignerOutlets ()
		{
			if (MetalPerformanceShadersDisabledLabel != null) {
				MetalPerformanceShadersDisabledLabel.Dispose ();
				MetalPerformanceShadersDisabledLabel = null;
			}
		}
	}
}
