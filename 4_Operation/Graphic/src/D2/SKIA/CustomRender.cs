using SkiaSharp;

namespace Alis.Core.Graphic.D2.SKIA
{
	/// <summary>
	/// The custom render class
	/// </summary>
	public static class CustomRender
	{
        /// <summary>
        ///     The blue
        /// </summary>
        private static float red, green, blue;
        
        /// <summary>
        /// The fill color
        /// </summary>
        private static SKColorF _fillColor;
        
        /// <summary>
        /// Updates the e surface
        /// </summary>
        /// <param name="surfaceCanvas">The surface canvas</param>
        public static void Update(SKCanvas surfaceCanvas)
        {
            red += 0.01f;
            if (red >= 1.0f)
            {
                red -= 1.0f;
            }

            green += 0.02f;
            if (green >= 1.0f)
            {
                green -= 1.0f;
            }

            blue += 0.03f;
            if (blue >= 1.0f)
            {
                blue -= 1.0f;
            }
            
            // change the background color
            _fillColor = new SKColorF(red, green, blue);
            
            // clear the view with the specified background color
            surfaceCanvas.DrawColor(_fillColor);
        }
    }
}
