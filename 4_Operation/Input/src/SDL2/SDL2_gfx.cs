using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Input.SDL2
{
	/// <summary>
	/// The sdl gfx class
	/// </summary>
	public static class SDL_gfx
	{
		
		/* Used by DllImport to load the native library. */
		/// <summary>
		/// The native lib name
		/// </summary>
		private const string nativeLibName = "SDL2_gfx";

		
		
		/// <summary>
		/// The pi
		/// </summary>
		public const double M_PI = 3.1415926535897932384626433832795;
		
				
		/// <summary>
		/// The sdl2 gfxprimitives major
		/// </summary>
		public const uint SDL2_GFXPRIMITIVES_MAJOR = 1;
		/// <summary>
		/// The sdl2 gfxprimitives minor
		/// </summary>
		public const uint SDL2_GFXPRIMITIVES_MINOR = 0;
		/// <summary>
		/// The sdl2 gfxprimitives micro
		/// </summary>
		public const uint SDL2_GFXPRIMITIVES_MICRO = 1;

		/// <summary>
		/// Pixels the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int pixelColor(IntPtr renderer, short x, short y, uint color);

		/// <summary>
		/// Pixels the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int pixelRGBA(IntPtr renderer, short x, short y, byte r, byte g, byte b, byte a);

		/// <summary>
		/// Hlines the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int hlineColor(IntPtr renderer, short x1, short x2, short y, uint color);
		
		/// <summary>
		/// Hlines the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int hlineRGBA(IntPtr renderer, short x1, short x2, short y, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Vlines the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y1">The </param>
		/// <param name="y2">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int vlineColor(IntPtr renderer, short x, short y1, short y2, uint color);
		
		/// <summary>
		/// Vlines the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y1">The </param>
		/// <param name="y2">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int vlineRGBA(IntPtr renderer, short x, short y1, short y2, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Rectangles the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int rectangleColor(IntPtr renderer, short x1, short y1, short x2, short y2, uint color);
		
		/// <summary>
		/// Rectangles the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int rectangleRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, byte r, byte g, byte b, byte a);

		/// <summary>
		/// Roundeds the rectangle color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int roundedRectangleColor(IntPtr renderer, short x1, short y1, short x2, short y2, short rad, uint color);
		
		/// <summary>
		/// Roundeds the rectangle rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int roundedRectangleRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, short rad, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Boxes the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int boxColor(IntPtr renderer, short x1, short y1, short x2, short y2, uint color);
		
		/// <summary>
		/// Boxes the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int boxRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Roundeds the box color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int roundedBoxColor(IntPtr renderer, short x1, short y1, short x2, short y2, short rad, uint color);
		
		/// <summary>
		/// Roundeds the box rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int roundedBoxRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, short rad, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Lines the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lineColor(IntPtr renderer, short x1, short y1, short x2, short y2, uint color);
		
		/// <summary>
		/// Lines the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int lineRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Aalines the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aalineColor(IntPtr renderer, short x1, short y1, short x2, short y2, uint color);
		
		/// <summary>
		/// Aalines the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aalineRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Thicks the line color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="width">The width</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int thickLineColor(IntPtr renderer, short x1, short y1, short x2, short y2, byte width, uint color);
		
		/// <summary>
		/// Thicks the line rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="width">The width</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int thickLineRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, byte width, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Circles the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int circleColor(IntPtr renderer, short x, short y, short rad, uint color);
		
		/// <summary>
		/// Circles the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int circleRGBA(IntPtr renderer, short x, short y, short rad, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Arcs the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="start">The start</param>
		/// <param name="end">The end</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int arcColor(IntPtr renderer, short x, short y, short rad, short start, short end, uint color);
		
		/// <summary>
		/// Arcs the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="start">The start</param>
		/// <param name="end">The end</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int arcRGBA(IntPtr renderer, short x, short y, short rad, short start, short end, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Aacircles the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aacircleColor(IntPtr renderer, short x, short y, short rad, uint color);
		
		/// <summary>
		/// Aacircles the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aacircleRGBA(IntPtr renderer, short x, short y, short rad, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Filleds the circle color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledCircleColor(IntPtr renderer, short x, short y, short rad, uint color);
		
		/// <summary>
		/// Filleds the circle rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledCircleRGBA(IntPtr renderer, short x, short y, short rad, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Ellipses the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rx">The rx</param>
		/// <param name="ry">The ry</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ellipseColor(IntPtr renderer, short x, short y, short rx, short ry, uint color);
		
		/// <summary>
		/// Ellipses the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rx">The rx</param>
		/// <param name="ry">The ry</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int ellipseRGBA(IntPtr renderer, short x, short y, short rx, short ry, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Aaellipses the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rx">The rx</param>
		/// <param name="ry">The ry</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aaellipseColor(IntPtr renderer, short x, short y, short rx, short ry, uint color);
		
		/// <summary>
		/// Aaellipses the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rx">The rx</param>
		/// <param name="ry">The ry</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aaellipseRGBA(IntPtr renderer, short x, short y, short rx, short ry, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Filleds the ellipse color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rx">The rx</param>
		/// <param name="ry">The ry</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledEllipseColor(IntPtr renderer, short x, short y, short rx, short ry, uint color);
		
		/// <summary>
		/// Filleds the ellipse rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rx">The rx</param>
		/// <param name="ry">The ry</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledEllipseRGBA(IntPtr renderer, short x, short y, short rx, short ry, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Pies the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="start">The start</param>
		/// <param name="end">The end</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int pieColor(IntPtr renderer, short x, short y, short rad, short start, short end, uint color);
		
		/// <summary>
		/// Pies the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="start">The start</param>
		/// <param name="end">The end</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int pieRGBA(IntPtr renderer, short x, short y, short rad, short start, short end, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Filleds the pie color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="start">The start</param>
		/// <param name="end">The end</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledPieColor(IntPtr renderer, short x, short y, short rad, short start, short end, uint color);
		
		/// <summary>
		/// Filleds the pie rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="rad">The rad</param>
		/// <param name="start">The start</param>
		/// <param name="end">The end</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledPieRGBA(IntPtr renderer, short x, short y, short rad, short start, short end, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Trigons the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="x3">The </param>
		/// <param name="y3">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int trigonColor(IntPtr renderer, short x1, short y1, short x2, short y2, short x3, short y3, uint color);
		
		/// <summary>
		/// Trigons the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="x3">The </param>
		/// <param name="y3">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int trigonRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, short x3, short y3, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Aatrigons the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="x3">The </param>
		/// <param name="y3">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aatrigonColor(IntPtr renderer, short x1, short y1, short x2, short y2, short x3, short y3, uint color);
		
		/// <summary>
		/// Aatrigons the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="x3">The </param>
		/// <param name="y3">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aatrigonRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, short x3, short y3, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Filleds the trigon color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="x3">The </param>
		/// <param name="y3">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledTrigonColor(IntPtr renderer, short x1, short y1, short x2, short y2, short x3, short y3, uint color);
		
		/// <summary>
		/// Filleds the trigon rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <param name="x3">The </param>
		/// <param name="y3">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledTrigonRGBA(IntPtr renderer, short x1, short y1, short x2, short y2, short x3, short y3, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Polygons the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int polygonColor(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, uint color);
		
		/// <summary>
		/// Polygons the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int polygonRGBA(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Aapolygons the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aapolygonColor(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, uint color);
		
		/// <summary>
		/// Aapolygons the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int aapolygonRGBA(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Filleds the polygon color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledPolygonColor(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, uint color);
		
		/// <summary>
		/// Filleds the polygon rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int filledPolygonRGBA(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Textureds the polygon using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="texture">The texture</param>
		/// <param name="texture_dx">The texture dx</param>
		/// <param name="texture_dy">The texture dy</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int texturedPolygon(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, IntPtr texture, int texture_dx, int texture_dy);
		
		/// <summary>
		/// Beziers the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="s">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int bezierColor(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, int s, uint color);
		
		/// <summary>
		/// Beziers the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vx">The vx</param>
		/// <param name="vy">The vy</param>
		/// <param name="n">The </param>
		/// <param name="s">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int bezierRGBA(IntPtr renderer, [In] short[] vx, [In] short[] vy, int n, int s, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Gfxes the primitives set font using the specified fontdata
		/// </summary>
		/// <param name="fontdata">The fontdata</param>
		/// <param name="cw">The cw</param>
		/// <param name="ch">The ch</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gfxPrimitivesSetFont([In] byte[] fontdata, uint cw, uint ch);
		
		/// <summary>
		/// Gfxes the primitives set font rotation using the specified rotation
		/// </summary>
		/// <param name="rotation">The rotation</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void gfxPrimitivesSetFontRotation(uint rotation);
		
		/// <summary>
		/// Characters the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="c">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int characterColor(IntPtr renderer, short x, short y, char c, uint color);
		
		/// <summary>
		/// Characters the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="c">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int characterRGBA(IntPtr renderer, short x, short y, char c, byte r, byte g, byte b, byte a);
		
		/// <summary>
		/// Strings the color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="s">The </param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stringColor(IntPtr renderer, short x, short y, string s, uint color);
		
		/// <summary>
		/// Strings the rgba using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="s">The </param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stringRGBA(IntPtr renderer, short x, short y, string s, byte r, byte g, byte b, byte a);

		

		
		/// <summary>
		/// The smoothing off
		/// </summary>
		public const int SMOOTHING_OFF = 0;
		/// <summary>
		/// The smoothing on
		/// </summary>
		public const int SMOOTHING_ON = 1;
		
		/// <summary>
		/// Rotozooms the surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="angle">The angle</param>
		/// <param name="zoom">The zoom</param>
		/// <param name="smooth">The smooth</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr rotozoomSurface(IntPtr src, double angle, double zoom, int smooth);
		
		/// <summary>
		/// Rotozooms the surface xy using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="angle">The angle</param>
		/// <param name="zoomx">The zoomx</param>
		/// <param name="zoomy">The zoomy</param>
		/// <param name="smooth">The smooth</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr rotozoomSurfaceXY(IntPtr src, double angle, double zoomx, double zoomy, int smooth);
		
		/// <summary>
		/// Rotozooms the surface size using the specified width
		/// </summary>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="angle">The angle</param>
		/// <param name="zoom">The zoom</param>
		/// <param name="dstwidth">The dstwidth</param>
		/// <param name="dstheight">The dstheight</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void rotozoomSurfaceSize(int width, int height, double angle, double zoom, out int dstwidth, out int dstheight);
		
		/// <summary>
		/// Rotozooms the surface size xy using the specified width
		/// </summary>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="angle">The angle</param>
		/// <param name="zoomx">The zoomx</param>
		/// <param name="zoomy">The zoomy</param>
		/// <param name="dstwidth">The dstwidth</param>
		/// <param name="dstheight">The dstheight</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void rotozoomSurfaceSizeXY(int width, int height, double angle, double zoomx, double zoomy, out int dstwidth, out int dstheight);
		
		/// <summary>
		/// Zooms the surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="zoomx">The zoomx</param>
		/// <param name="zoomy">The zoomy</param>
		/// <param name="smooth">The smooth</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr zoomSurface(IntPtr src, double zoomx, double zoomy, int smooth);
		
		/// <summary>
		/// Zooms the surface size using the specified width
		/// </summary>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="zoomx">The zoomx</param>
		/// <param name="zoomy">The zoomy</param>
		/// <param name="dstwidth">The dstwidth</param>
		/// <param name="dstheight">The dstheight</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void zoomSurfaceSize(int width, int height, double zoomx, double zoomy, out int dstwidth, out int dstheight);
		
		/// <summary>
		/// Shrinks the surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="factorx">The factorx</param>
		/// <param name="factory">The factory</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr shrinkSurface(IntPtr src, int factorx, int factory);
		
		/// <summary>
		/// Rotates the surface 90 degrees using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="numClockwiseTurns">The num clockwise turns</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr rotateSurface90Degrees(IntPtr src, int numClockwiseTurns);

		

		
		/// <summary>
		/// The fps upper limit
		/// </summary>
		public const int FPS_UPPER_LIMIT = 200;
		/// <summary>
		/// The fps lower limit
		/// </summary>
		public const int FPS_LOWER_LIMIT = 1;
		/// <summary>
		/// The fps default
		/// </summary>
		public const int FPS_DEFAULT = 30;
		
		/// <summary>
		/// The fp smanager
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct FPSmanager
		{
			/// <summary>
			/// The framecount
			/// </summary>
			public uint framecount;
			/// <summary>
			/// The rateticks
			/// </summary>
			public float rateticks;
			/// <summary>
			/// The baseticks
			/// </summary>
			public uint baseticks;
			/// <summary>
			/// The lastticks
			/// </summary>
			public uint lastticks;
			/// <summary>
			/// The rate
			/// </summary>
			public uint rate;
		}
		
		/// <summary>
		/// Sdls the init framerate using the specified manager
		/// </summary>
		/// <param name="manager">The manager</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_initFramerate(ref FPSmanager manager);
		
		/// <summary>
		/// Sdls the set framerate using the specified manager
		/// </summary>
		/// <param name="manager">The manager</param>
		/// <param name="rate">The rate</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_setFramerate(ref FPSmanager manager, uint rate);
		
		/// <summary>
		/// Sdls the get framerate using the specified manager
		/// </summary>
		/// <param name="manager">The manager</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_getFramerate(ref FPSmanager manager);
		
		/// <summary>
		/// Sdls the get framecount using the specified manager
		/// </summary>
		/// <param name="manager">The manager</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_getFramecount(ref FPSmanager manager);
		
		/// <summary>
		/// Sdls the framerate delay using the specified manager
		/// </summary>
		/// <param name="manager">The manager</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_framerateDelay(ref FPSmanager manager);

		

		
		/// <summary>
		/// Sdls the image filter mm xdetect
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterMMXdetect();
		
		/// <summary>
		/// Sdls the image filter mm xoff
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_imageFilterMMXoff();
		
		/// <summary>
		/// Sdls the image filter mm xon
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_imageFilterMMXon();

		/// <summary>
		/// Sdls the image filter add using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterAdd([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter mean using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterMean([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter sub using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterSub([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter abs diff using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterAbsDiff([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter mult using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterMult([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter mult nor using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterMultNor([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter mult divby 2 using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterMultDivby2([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter mult divby 4 using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterMultDivby4([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter bit and using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterBitAnd([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter bit or using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterBitOr([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter div using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="src2">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterDiv([In] byte[] src1, [In] byte[] src2, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter bit negation using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterBitNegation([In] byte[] src1, [Out] byte[] dest, uint length);
		
		/// <summary>
		/// Sdls the image filter add byte using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="c">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterAddByte([In] byte[] src1, [Out] byte[] dest, uint length, byte c);
		
		/// <summary>
		/// Sdls the image filter add uint using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="c">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterAddUint([In] byte[] src1, [Out] byte[] dest, uint length, uint c);
		
		/// <summary>
		/// Sdls the image filter add byte to half using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="c">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterAddByteToHalf([In] byte[] src1, [Out] byte[] dest, uint length, byte c);
		
		/// <summary>
		/// Sdls the image filter sub byte using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="c">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterSubByte([In] byte[] src1, [Out] byte[] dest, uint length, byte c);
		
		/// <summary>
		/// Sdls the image filter sub uint using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="c">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterSubUint([In] byte[] src1, [Out] byte[] dest, uint length, uint c);
		
		/// <summary>
		/// Sdls the image filter shift right using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="n">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterShiftRight([In] byte[] src1, [Out] byte[] dest, uint length, byte n);
		
		/// <summary>
		/// Sdls the image filter shift right uint using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="n">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterShiftRightUint([In] byte[] src1, [Out] byte[] dest, uint length, byte n);
		
		/// <summary>
		/// Sdls the image filter mult by byte using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="c">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterMultByByte([In] byte[] src1, [Out] byte[] dest, uint length, byte c);
		
		/// <summary>
		/// Sdls the image filter shift right and mult by byte using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="n">The </param>
		/// <param name="c">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterShiftRightAndMultByByte([In] byte[] src1, [Out] byte[] dest, uint length, byte n, byte c);
		
		/// <summary>
		/// Sdls the image filter shift left byte using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="n">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterShiftLeftByte([In] byte[] src1, [Out] byte[] dest, uint length, byte n);
		
		/// <summary>
		/// Sdls the image filter shift left uint using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="n">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterShiftLeftUint([In] byte[] src1, [Out] byte[] dest, uint length, byte n);
		
		/// <summary>
		/// Sdls the image filter shift left using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="n">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterShiftLeft([In] byte[] src1, [Out] byte[] dest, uint length, byte n);
		
		/// <summary>
		/// Sdls the image filter binarize using threshold using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="t">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterBinarizeUsingThreshold([In] byte[] src1, [Out] byte[] dest, uint length, byte t);
		
		/// <summary>
		/// Sdls the image filter clip to range using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="tmin">The tmin</param>
		/// <param name="tmax">The tmax</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterClipToRange([In] byte[] src1, [Out] byte[] dest, uint length, byte tmin, byte tmax);
		
		/// <summary>
		/// Sdls the image filter normalize linear using the specified src 1
		/// </summary>
		/// <param name="src1">The src</param>
		/// <param name="dest">The dest</param>
		/// <param name="length">The length</param>
		/// <param name="cmin">The cmin</param>
		/// <param name="cmax">The cmax</param>
		/// <param name="nmin">The nmin</param>
		/// <param name="nmax">The nmax</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_imageFilterNormalizeLinear([In] byte[] src1, [Out] byte[] dest, uint length, int cmin, int cmax, int nmin, int nmax);

		
	}
}
