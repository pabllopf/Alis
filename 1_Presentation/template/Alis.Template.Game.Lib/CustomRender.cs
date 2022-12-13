using System;
using SkiaSharp;

namespace Alis.Template.Game.Lib
{
	public class CustomRender
	{
        /// <summary>
        ///     The blue
        /// </summary>
        private static float red, green, blue;
        
        private static SKColorF _fillColor;
        
        public static void Update(SKSurface eSurface, SKCanvas surfaceCanvas)
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
            surfaceCanvas.Clear(_fillColor);
        }
    }
}
