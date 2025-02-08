namespace Alis.Core.Graphic.Stb
{
#if !STBSHARP_INTERNAL
	public
#else
	internal
#endif
	enum ColorComponents
	{
		Default,
		Grey,
		GreyAlpha,
		RedGreenBlue,
		RedGreenBlueAlpha
	}
}