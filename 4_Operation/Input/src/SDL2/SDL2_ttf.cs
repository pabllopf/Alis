using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Input.SDL2
{
	/// <summary>
	/// The sdl ttf class
	/// </summary>
	public static class SDL_ttf
	{
		
		/* Used by DllImport to load the native library. */
		/// <summary>
		/// The native lib name
		/// </summary>
		private const string nativeLibName = "SDL2_ttf";

		

		
		/* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
		/// <summary>
		/// The sdl ttf major version
		/// </summary>
		public const int SDL_TTF_MAJOR_VERSION =	2;
		/// <summary>
		/// The sdl ttf minor version
		/// </summary>
		public const int SDL_TTF_MINOR_VERSION =	0;
		/// <summary>
		/// The sdl ttf patchlevel
		/// </summary>
		public const int SDL_TTF_PATCHLEVEL =		16;

		/// <summary>
		/// The unicode bom native
		/// </summary>
		public const int UNICODE_BOM_NATIVE =	0xFEFF;
		/// <summary>
		/// The unicode bom swapped
		/// </summary>
		public const int UNICODE_BOM_SWAPPED =	0xFFFE;

		/// <summary>
		/// The ttf style normal
		/// </summary>
		public const int TTF_STYLE_NORMAL =		0x00;
		/// <summary>
		/// The ttf style bold
		/// </summary>
		public const int TTF_STYLE_BOLD =		0x01;
		/// <summary>
		/// The ttf style italic
		/// </summary>
		public const int TTF_STYLE_ITALIC =		0x02;
		/// <summary>
		/// The ttf style underline
		/// </summary>
		public const int TTF_STYLE_UNDERLINE =		0x04;
		/// <summary>
		/// The ttf style strikethrough
		/// </summary>
		public const int TTF_STYLE_STRIKETHROUGH =	0x08;

		/// <summary>
		/// The ttf hinting normal
		/// </summary>
		public const int TTF_HINTING_NORMAL =		0;
		/// <summary>
		/// The ttf hinting light
		/// </summary>
		public const int TTF_HINTING_LIGHT =		1;
		/// <summary>
		/// The ttf hinting mono
		/// </summary>
		public const int TTF_HINTING_MONO =		2;
		/// <summary>
		/// The ttf hinting none
		/// </summary>
		public const int TTF_HINTING_NONE =		3;
		/// <summary>
		/// The ttf hinting light subpixel
		/// </summary>
		public const int TTF_HINTING_LIGHT_SUBPIXEL =	4; /* >= 2.0.16 */

		/// <summary>
		/// Sdls the ttf version using the specified x
		/// </summary>
		/// <param name="X">The </param>
		public static void SDL_TTF_VERSION(out SDL.SDL_version X)
		{
			X.major = SDL_TTF_MAJOR_VERSION;
			X.minor = SDL_TTF_MINOR_VERSION;
			X.patch = SDL_TTF_PATCHLEVEL;
		}

		/// <summary>
		/// Internals the ttf linked version
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_TTF_LinkedVersion();
		/// <summary>
		/// Ttfs the linked version
		/// </summary>
		/// <returns>The result</returns>
		public static SDL.SDL_version TTF_LinkedVersion()
		{
			SDL.SDL_version result;
			IntPtr result_ptr = INTERNAL_TTF_LinkedVersion();
			result = (SDL.SDL_version) Marshal.PtrToStructure(
				result_ptr,
				typeof(SDL.SDL_version)
			);
			return result;
		}

		/// <summary>
		/// Ttfs the byte swapped unicode using the specified swapped
		/// </summary>
		/// <param name="swapped">The swapped</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_ByteSwappedUNICODE(int swapped);

		/// <summary>
		/// Ttfs the init
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_Init();

		/* IntPtr refers to a TTF_Font* */
		/// <summary>
		/// Internals the ttf open font using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="ptsize">The ptsize</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_TTF_OpenFont(
			byte* file,
			int ptsize
		);
		/// <summary>
		/// Ttfs the open font using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="ptsize">The ptsize</param>
		/// <returns>The handle</returns>
		public static unsafe IntPtr TTF_OpenFont(string file, int ptsize)
		{
			byte* utf8File = SDL.Utf8EncodeHeap(file);
			IntPtr handle = INTERNAL_TTF_OpenFont(
				utf8File,
				ptsize
			);
			Marshal.FreeHGlobal((IntPtr) utf8File);
			return handle;
		}

		/* src refers to an SDL_RWops*, IntPtr to a TTF_Font* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		/// <summary>
		/// Ttfs the open font rw using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="freesrc">The freesrc</param>
		/// <param name="ptsize">The ptsize</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_OpenFontRW(
			IntPtr src,
			int freesrc,
			int ptsize
		);

		/* IntPtr refers to a TTF_Font* */
		/// <summary>
		/// Internals the ttf open font index using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="ptsize">The ptsize</param>
		/// <param name="index">The index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_TTF_OpenFontIndex(
			byte* file,
			int ptsize,
			long index
		);
		/// <summary>
		/// Ttfs the open font index using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="ptsize">The ptsize</param>
		/// <param name="index">The index</param>
		/// <returns>The handle</returns>
		public static unsafe IntPtr TTF_OpenFontIndex(
			string file,
			int ptsize,
			long index
		) {
			byte* utf8File = SDL.Utf8EncodeHeap(file);
			IntPtr handle = INTERNAL_TTF_OpenFontIndex(
				utf8File,
				ptsize,
				index
			);
			Marshal.FreeHGlobal((IntPtr) utf8File);
			return handle;
		}

		/* src refers to an SDL_RWops*, IntPtr to a TTF_Font* */
		/* THIS IS A PUBLIC RWops FUNCTION! */
		/// <summary>
		/// Ttfs the open font index rw using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="freesrc">The freesrc</param>
		/// <param name="ptsize">The ptsize</param>
		/// <param name="index">The index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_OpenFontIndexRW(
			IntPtr src,
			int freesrc,
			int ptsize,
			long index
		);

		/* font refers to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the set font size using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ptsize">The ptsize</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SetFontSize(
			IntPtr font,
			int ptsize
		);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the get font style using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontStyle(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the set font style using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="style">The style</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontStyle(IntPtr font, int style);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the get font outline using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontOutline(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the set font outline using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="outline">The outline</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontOutline(IntPtr font, int outline);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the get font hinting using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontHinting(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the set font hinting using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="hinting">The hinting</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontHinting(IntPtr font, int hinting);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the font height using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontHeight(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the font ascent using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontAscent(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the font descent using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontDescent(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the font line skip using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontLineSkip(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the get font kerning using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontKerning(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the set font kerning using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="allowed">The allowed</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontKerning(IntPtr font, int allowed);

		/* font refers to a TTF_Font*.
		 * IntPtr is actually a C long! This ignores Win64!
		 */
		/// <summary>
		/// Ttfs the font faces using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_FontFaces(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the font face is fixed width using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Internals the ttf font face family name using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(
			IntPtr font
		);
		/// <summary>
		/// Ttfs the font face family name using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The string</returns>
		public static string TTF_FontFaceFamilyName(IntPtr font)
		{
			return SDL.UTF8_ToManaged(
				INTERNAL_TTF_FontFaceFamilyName(font)
			);
		}

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Internals the ttf font face style name using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_TTF_FontFaceStyleName(
			IntPtr font
		);
		/// <summary>
		/// Ttfs the font face style name using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <returns>The string</returns>
		public static string TTF_FontFaceStyleName(IntPtr font)
		{
			return SDL.UTF8_ToManaged(
				INTERNAL_TTF_FontFaceStyleName(font)
			);
		}

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the glyph is provided using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);

		/* font refers to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the glyph is provided 32 using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GlyphIsProvided32(IntPtr font, uint ch);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the glyph metrics using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="minx">The minx</param>
		/// <param name="maxx">The maxx</param>
		/// <param name="miny">The miny</param>
		/// <param name="maxy">The maxy</param>
		/// <param name="advance">The advance</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GlyphMetrics(
			IntPtr font,
			ushort ch,
			out int minx,
			out int maxx,
			out int miny,
			out int maxy,
			out int advance
		);

		/* font refers to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the glyph metrics 32 using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="minx">The minx</param>
		/// <param name="maxx">The maxx</param>
		/// <param name="miny">The miny</param>
		/// <param name="maxy">The maxy</param>
		/// <param name="advance">The advance</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GlyphMetrics32(
			IntPtr font,
			uint ch,
			out int minx,
			out int maxx,
			out int miny,
			out int maxy,
			out int advance
		);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the size text using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SizeText(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			out int w,
			out int h
		);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Internals the ttf size utf 8 using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_SizeUTF8", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int INTERNAL_TTF_SizeUTF8(
			IntPtr font,
			byte* text,
			out int w,
			out int h
		);
		/// <summary>
		/// Ttfs the size utf 8 using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The result</returns>
		public static unsafe int TTF_SizeUTF8(
			IntPtr font,
			string text,
			out int w,
			out int h
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			int result = INTERNAL_TTF_SizeUTF8(
				font,
				utf8Text,
				out w,
				out h
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the size unicode using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SizeUNICODE(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			out int w,
			out int h
		);

		/* font refers to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the measure text using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="measure_width">The measure width</param>
		/// <param name="extent">The extent</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_MeasureText(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			int measure_width,
			out int extent,
			out int count
		);

		/* font refers to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Internals the ttf measure utf 8 using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="measure_width">The measure width</param>
		/// <param name="extent">The extent</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_MeasureUTF8", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe int INTERNAL_TTF_MeasureUTF8(
			IntPtr font,
			byte* text,
			int measure_width,
			out int extent,
			out int count
		);
		/// <summary>
		/// Ttfs the measure utf 8 using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="measure_width">The measure width</param>
		/// <param name="extent">The extent</param>
		/// <param name="count">The count</param>
		/// <returns>The result</returns>
		public static unsafe int TTF_MeasureUTF8(
			IntPtr font,
			string text,
			int measure_width,
			out int extent,
			out int count
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			int result = INTERNAL_TTF_MeasureUTF8(
				font,
				utf8Text,
				measure_width,
				out extent,
				out count
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* font refers to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the measure unicode using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="measure_width">The measure width</param>
		/// <param name="extent">The extent</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_MeasureUNICODE(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			int measure_width,
			out int extent,
			out int count
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render text solid using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Solid(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Internals the ttf render utf 8 solid using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_TTF_RenderUTF8_Solid(
			IntPtr font,
			byte* text,
			SDL.SDL_Color fg
		);
		/// <summary>
		/// Ttfs the render utf 8 solid using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The result</returns>
		public static unsafe IntPtr TTF_RenderUTF8_Solid(
			IntPtr font,
			string text,
			SDL.SDL_Color fg
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			IntPtr result = INTERNAL_TTF_RenderUTF8_Solid(
				font,
				utf8Text,
				fg
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render unicode solid using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Solid(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			SDL.SDL_Color fg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the render text solid wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Solid_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			uint wrapLength
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Internals the ttf render utf 8 solid wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Solid_Wrapped", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe IntPtr INTERNAL_TTF_RenderUTF8_Solid_Wrapped(
			IntPtr font,
			byte* text,
			SDL.SDL_Color fg,
			uint wrapLength
		);
		/// <summary>
		/// Ttfs the render utf 8 solid wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The result</returns>
		public static unsafe IntPtr TTF_RenderUTF8_Solid_Wrapped(
			IntPtr font,
			string text,
			SDL.SDL_Color fg,
			uint wrapLength
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			IntPtr result = INTERNAL_TTF_RenderUTF8_Solid_Wrapped(
				font,
				utf8Text,
				fg,
				wrapLength
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the render unicode solid wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Solid_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			SDL.SDL_Color fg,
			uint wrapLength
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render glyph solid using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph_Solid(
			IntPtr font,
			ushort ch,
			SDL.SDL_Color fg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the render glyph 32 solid using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph32_Solid(
			IntPtr font,
			uint ch,
			SDL.SDL_Color fg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render text shaded using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Shaded(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Internals the ttf render utf 8 shaded using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_TTF_RenderUTF8_Shaded(
			IntPtr font,
			byte* text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);
		/// <summary>
		/// Ttfs the render utf 8 shaded using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <returns>The result</returns>
		public static unsafe IntPtr TTF_RenderUTF8_Shaded(
			IntPtr font,
			string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			IntPtr result = INTERNAL_TTF_RenderUTF8_Shaded(
				font,
				utf8Text,
				fg,
				bg
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render unicode shaded using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Shaded(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render text shaded wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Shaded_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg,
			uint wrapLength
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Internals the ttf render utf 8 shaded wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded_Wrapped", CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe IntPtr INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(
			IntPtr font,
			byte* text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg,
			uint wrapLength
		);
		/// <summary>
		/// Ttfs the render utf 8 shaded wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The result</returns>
		public static unsafe IntPtr TTF_RenderUTF8_Shaded_Wrapped(
			IntPtr font,
			string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg,
			uint wrapLength
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			IntPtr result = INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(
				font,
				utf8Text,
				fg,
				bg,
				wrapLength
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render unicode shaded wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <param name="wrapLength">The wrap length</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Shaded_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg,
			uint wrapLength
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render glyph shaded using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph_Shaded(
			IntPtr font,
			ushort ch,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the render glyph 32 shaded using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="fg">The fg</param>
		/// <param name="bg">The bg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph32_Shaded(
			IntPtr font,
			uint ch,
			SDL.SDL_Color fg,
			SDL.SDL_Color bg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render text blended using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Blended(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Internals the ttf render utf 8 blended using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_TTF_RenderUTF8_Blended(
			IntPtr font,
			byte* text,
			SDL.SDL_Color fg
		);
		/// <summary>
		/// Ttfs the render utf 8 blended using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The result</returns>
		public static unsafe IntPtr TTF_RenderUTF8_Blended(
			IntPtr font,
			string text,
			SDL.SDL_Color fg
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			IntPtr result = INTERNAL_TTF_RenderUTF8_Blended(
				font,
				utf8Text,
				fg
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render unicode blended using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Blended(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			SDL.SDL_Color fg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render text blended wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapped">The wrapped</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Blended_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPStr)]
				string text,
			SDL.SDL_Color fg,
			uint wrapped
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Internals the ttf render utf 8 blended wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapped">The wrapped</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
			IntPtr font,
			byte* text,
			SDL.SDL_Color fg,
			uint wrapped
		);
		/// <summary>
		/// Ttfs the render utf 8 blended wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapped">The wrapped</param>
		/// <returns>The result</returns>
		public static unsafe IntPtr TTF_RenderUTF8_Blended_Wrapped(
			IntPtr font,
			string text,
			SDL.SDL_Color fg,
			uint wrapped
		) {
			byte* utf8Text = SDL.Utf8EncodeHeap(text);
			IntPtr result = INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
				font,
				utf8Text,
				fg,
				wrapped
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render unicode blended wrapped using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="text">The text</param>
		/// <param name="fg">The fg</param>
		/// <param name="wrapped">The wrapped</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(
			IntPtr font,
			[In()] [MarshalAs(UnmanagedType.LPWStr)]
				string text,
			SDL.SDL_Color fg,
			uint wrapped
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
		/// <summary>
		/// Ttfs the render glyph blended using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph_Blended(
			IntPtr font,
			ushort ch,
			SDL.SDL_Color fg
		);

		/* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the render glyph 32 blended using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="ch">The ch</param>
		/// <param name="fg">The fg</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph32_Blended(
			IntPtr font,
			uint ch,
			SDL.SDL_Color fg
		);

		/* Only available in 2.0.16 or higher. */
		/// <summary>
		/// Ttfs the set direction using the specified direction
		/// </summary>
		/// <param name="direction">The direction</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SetDirection(int direction);

		/* Only available in 2.0.16 or higher. */
		/// <summary>
		/// Ttfs the set script using the specified script
		/// </summary>
		/// <param name="script">The script</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SetScript(int script);

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Ttfs the close font using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_CloseFont(IntPtr font);

		/// <summary>
		/// Ttfs the quit
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_Quit();

		/// <summary>
		/// Ttfs the was init
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_WasInit();

		/* font refers to a TTF_Font* */
		/// <summary>
		/// Sdls the get font kerning size using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="prev_index">The prev index</param>
		/// <param name="index">The index</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetFontKerningSize(
			IntPtr font,
			int prev_index,
			int index
		);

		/* font refers to a TTF_Font*
		 * Only available in 2.0.15 or higher.
		 */
		/// <summary>
		/// Ttfs the get font kerning size glyphs using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="previous_ch">The previous ch</param>
		/// <param name="ch">The ch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontKerningSizeGlyphs(
			IntPtr font,
			ushort previous_ch,
			ushort ch
		);

		/* font refers to a TTF_Font*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Ttfs the get font kerning size glyphs 32 using the specified font
		/// </summary>
		/// <param name="font">The font</param>
		/// <param name="previous_ch">The previous ch</param>
		/// <param name="ch">The ch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontKerningSizeGlyphs32(
			IntPtr font,
			ushort previous_ch,
			ushort ch
		);

		/// <summary>
		/// Ttfs the get error
		/// </summary>
		/// <returns>The string</returns>
		public static string TTF_GetError()
		{
			return SDL.SDL_GetError();
		}

		/// <summary>
		/// Ttfs the set error using the specified fmt and arglist
		/// </summary>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static void TTF_SetError(string fmtAndArglist)
		{
			SDL.SDL_SetError(fmtAndArglist);
		}
		
		
	}
}
