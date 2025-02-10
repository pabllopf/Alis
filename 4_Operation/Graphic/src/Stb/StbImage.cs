using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
#if !STBSHARP_INTERNAL
	/// <summary>
	/// The stb image class
	/// </summary>
	public
#else
	internal
#endif
	static unsafe partial class StbImage
	{
		/// <summary>
		/// The stbi failure reason
		/// </summary>
		public static string stbi__g_failure_reason;
		/// <summary>
		/// The stbi parse png file invalid chunk
		/// </summary>
		public static readonly char[] stbi__parse_png_file_invalid_chunk = new char[25];

		/// <summary>
		/// Gets the value of the native allocations
		/// </summary>
		public static int NativeAllocations
		{
			get
			{
				return MemoryStats.Allocations;
			}
		}

		/// <summary>
		/// The stbi context class
		/// </summary>
		public class stbi__context
		{
			/// <summary>
			/// The stream
			/// </summary>
			private readonly Stream _stream;

			/// <summary>
			/// The temp buffer
			/// </summary>
			public byte[] _tempBuffer;
			/// <summary>
			/// The img
			/// </summary>
			public int img_n = 0;
			/// <summary>
			/// The img out
			/// </summary>
			public int img_out_n = 0;
			/// <summary>
			/// The img
			/// </summary>
			public uint img_x = 0;
			/// <summary>
			/// The img
			/// </summary>
			public uint img_y = 0;

			/// <summary>
			/// Initializes a new instance of the <see cref="stbi__context"/> class
			/// </summary>
			/// <param name="stream">The stream</param>
			/// <exception cref="ArgumentNullException">stream</exception>
			public stbi__context(Stream stream)
			{
				if (stream == null)
					throw new ArgumentNullException("stream");

				_stream = stream;
			}

			/// <summary>
			/// Gets the value of the stream
			/// </summary>
			public Stream Stream
			{
				get
				{
					return _stream;
				}
			}
		}

		/// <summary>
		/// Stbis the err using the specified str
		/// </summary>
		/// <param name="str">The str</param>
		/// <returns>The int</returns>
		private static int stbi__err(string str)
		{
			stbi__g_failure_reason = str;
			return 0;
		}

		/// <summary>
		/// Stbis the get 8 using the specified s
		/// </summary>
		/// <param name="s">The </param>
		/// <returns>The byte</returns>
		public static byte stbi__get8(stbi__context s)
		{
			int b = s.Stream.ReadByte();
			if (b == -1) return 0;

			return (byte)b;
		}

		/// <summary>
		/// Stbis the skip using the specified s
		/// </summary>
		/// <param name="s">The </param>
		/// <param name="skip">The skip</param>
		public static void stbi__skip(stbi__context s, int skip)
		{
			s.Stream.Seek(skip, SeekOrigin.Current);
		}

		/// <summary>
		/// Stbis the rewind using the specified s
		/// </summary>
		/// <param name="s">The </param>
		public static void stbi__rewind(stbi__context s)
		{
			s.Stream.Seek(0, SeekOrigin.Begin);
		}

		/// <summary>
		/// Stbis the at eof using the specified s
		/// </summary>
		/// <param name="s">The </param>
		/// <returns>The int</returns>
		public static int stbi__at_eof(stbi__context s)
		{
			return s.Stream.Position == s.Stream.Length ? 1 : 0;
		}

		/// <summary>
		/// Stbis the getn using the specified s
		/// </summary>
		/// <param name="s">The </param>
		/// <param name="buf">The buf</param>
		/// <param name="size">The size</param>
		/// <returns>The result</returns>
		public static int stbi__getn(stbi__context s, byte* buf, int size)
		{
			if (s._tempBuffer == null ||
				s._tempBuffer.Length < size)
				s._tempBuffer = new byte[size * 2];

			int result = s.Stream.Read(s._tempBuffer, 0, size);
			Marshal.Copy(s._tempBuffer, 0, new IntPtr(buf), result);

			return result;
		}
	}
}