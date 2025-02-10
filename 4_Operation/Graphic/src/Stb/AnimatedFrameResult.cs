namespace Alis.Core.Graphic.Stb
{
#if !STBSHARP_INTERNAL
	public
#else
	internal
#endif
	class AnimatedFrameResult : ImageResult
	{
		public int DelayInMs { get; set; }
	}
}