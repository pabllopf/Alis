using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{

	/// <summary>
	/// The image result class
	/// </summary>
	public
	class ImageResult
	{
		/// <summary>
		/// Gets or sets the value of the width
		/// </summary>
		public int Width { get; set; }
		/// <summary>
		/// Gets or sets the value of the height
		/// </summary>
		public int Height { get; set; }
		/// <summary>
		/// Gets or sets the value of the source comp
		/// </summary>
		public ColorComponents SourceComp { get; set; }
		/// <summary>
		/// Gets or sets the value of the comp
		/// </summary>
		public ColorComponents Comp { get; set; }
		/// <summary>
		/// Gets or sets the value of the data
		/// </summary>
		public byte[] Data { get; set; }

		/// <summary>
		/// Creates the result using the specified result
		/// </summary>
		/// <param name="result">The result</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="comp">The comp</param>
		/// <param name="req_comp">The req comp</param>
		/// <exception cref="InvalidOperationException"></exception>
		/// <returns>The image</returns>
		internal static unsafe ImageResult FromResult(byte* result, int width, int height, ColorComponents comp,
			ColorComponents req_comp)
		{
			if (result == null)
				throw new InvalidOperationException(StbImage.stbi__g_failure_reason);

			ImageResult image = new ImageResult
			{
				Width = width,
				Height = height,
				SourceComp = comp,
				Comp = req_comp == ColorComponents.Default ? comp : req_comp
			};

			// Convert to array
			image.Data = new byte[width * height * (int)image.Comp];
			Marshal.Copy(new IntPtr(result), image.Data, 0, image.Data.Length);

			return image;
		}

		/// <summary>
		/// Creates the stream using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		/// <param name="requiredComponents">The required components</param>
		/// <returns>The image result</returns>
		public static unsafe ImageResult FromStream(Stream stream,
			ColorComponents requiredComponents = ColorComponents.Default)
		{
			byte* result = null;

			try
			{
				int x, y, comp;

				StbImage.stbi__context context = new StbImage.stbi__context(stream);

				result = StbImage.stbi__load_and_postprocess_8bit(context, &x, &y, &comp, (int)requiredComponents);

				return FromResult(result, x, y, (ColorComponents)comp, requiredComponents);
			}
			finally
			{
				if (result != null)
					CRuntime.free(result);
			}
		}

		/// <summary>
		/// Creates the memory using the specified data
		/// </summary>
		/// <param name="data">The data</param>
		/// <param name="requiredComponents">The required components</param>
		/// <returns>The image result</returns>
		public static ImageResult FromMemory(byte[] data, ColorComponents requiredComponents = ColorComponents.Default)
		{
			using (MemoryStream stream = new MemoryStream(data))
			{
				return FromStream(stream, requiredComponents);
			}
		}
	}
}