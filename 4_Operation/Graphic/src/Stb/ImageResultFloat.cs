using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{

	/// <summary>
	/// The image result float class
	/// </summary>
	public
	class ImageResultFloat
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
		public float[] Data { get; set; }

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
		internal static unsafe ImageResultFloat FromResult(float* result, int width, int height, ColorComponents comp,
			ColorComponents req_comp)
		{
			if (result == null)
				throw new InvalidOperationException(StbImage.stbi__g_failure_reason);

			ImageResultFloat image = new ImageResultFloat
			{
				Width = width,
				Height = height,
				SourceComp = comp,
				Comp = req_comp == ColorComponents.Default ? comp : req_comp
			};

			// Convert to array
			image.Data = new float[width * height * (int)image.Comp];
			Marshal.Copy(new IntPtr(result), image.Data, 0, image.Data.Length);

			return image;
		}

		/// <summary>
		/// Creates the stream using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		/// <param name="requiredComponents">The required components</param>
		/// <returns>The image result float</returns>
		public static unsafe ImageResultFloat FromStream(Stream stream,
			ColorComponents requiredComponents = ColorComponents.Default)
		{
			float* result = null;

			try
			{
				int x, y, comp;

				StbImage.stbi__context context = new StbImage.stbi__context(stream);

				result = StbImage.stbi__loadf_main(context, &x, &y, &comp, (int)requiredComponents);

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
		/// <returns>The image result float</returns>
		public static ImageResultFloat FromMemory(byte[] data,
			ColorComponents requiredComponents = ColorComponents.Default)
		{
			using (MemoryStream stream = new MemoryStream(data))
			{
				return FromStream(stream, requiredComponents);
			}
		}
	}
}