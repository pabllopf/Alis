namespace Alis.Core.Graphic.Stb
{
#if !STBSHARP_INTERNAL
	/// <summary>
	/// The color components enum
	/// </summary>
	public
#else
	internal
#endif
	enum ColorComponents
	{
		/// <summary>
		/// The default color components
		/// </summary>
		Default,
		/// <summary>
		/// The grey color components
		/// </summary>
		Grey,
		/// <summary>
		/// The grey alpha color components
		/// </summary>
		GreyAlpha,
		/// <summary>
		/// The red green blue color components
		/// </summary>
		RedGreenBlue,
		/// <summary>
		/// The red green blue alpha color components
		/// </summary>
		RedGreenBlueAlpha
	}
}