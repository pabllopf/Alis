using System.IO;

namespace Alis.Core.Graphic.Stb
{

	/// <summary>
	/// The image info
	/// </summary>
	public
	struct ImageInfo
	{
		/// <summary>
		/// The width
		/// </summary>
		public int Width;
		/// <summary>
		/// The height
		/// </summary>
		public int Height;
		/// <summary>
		/// The color components
		/// </summary>
		public ColorComponents ColorComponents;
		/// <summary>
		/// The bits per channel
		/// </summary>
		public int BitsPerChannel;


		/// <summary>
		/// Creates the stream using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		/// <returns>The image info</returns>
		public static unsafe ImageInfo? FromStream(Stream stream)
		{
			int width, height, comp;
			StbImage.stbi__context context = new StbImage.stbi__context(stream);

			bool is16Bit = StbImage.stbi__is_16_main(context) == 1;
			StbImage.stbi__rewind(context);

			int infoResult = StbImage.stbi__info_main(context, &width, &height, &comp);
			StbImage.stbi__rewind(context);

			if (infoResult == 0) return null;

			return new ImageInfo
			{
				Width = width,
				Height = height,
				ColorComponents = (ColorComponents)comp,
				BitsPerChannel = is16Bit ? 16 : 8
			};
		}
	}
}