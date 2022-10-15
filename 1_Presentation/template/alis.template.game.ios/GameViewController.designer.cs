// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MetalPerformanceShadersHelloWorld
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
