namespace Alis.Core.Graphic.Stb
{
#if !STBSHARP_INTERNAL
	/// <summary>
	/// The animated frame result class
	/// </summary>
	/// <seealso cref="ImageResult"/>
	public
	class AnimatedFrameResult : ImageResult
	{
		/// <summary>
		/// Gets or sets the value of the delay in ms
		/// </summary>
		public int DelayInMs { get; set; }
	}
}