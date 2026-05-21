

using Alis.Core.Aspect.Math.Definition;

namespace Alis.Core.Graphic.Ui
{
    /// <summary>
    ///     The font manager class
    /// </summary>
    public static class FontManager
    {
        /// <summary>
        ///     Gets the value of the default font
        /// </summary>
        public static Font DefaultFont { get; } = new Font("mono.bmp", 1, 1, "");

        /// <summary>
        ///     Renders the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The x position to render the text</param>
        /// <param name="y">The y position to render the text</param>
        /// <param name="foreColor">The foreground color of the text</param>
        /// <param name="backColor">The background color of the text</param>
        public static void RenderText(string text, int x, int y, Color foreColor, Color backColor)
        {
            DefaultFont.RenderText(text, x, y, foreColor, backColor);
        }

        /// <summary>
        ///     Renders the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The x position to render the text</param>
        /// <param name="y">The y position to render the text</param>
        public static void RenderText(string text, int x, int y)
        {
            DefaultFont.RenderText(text, x, y, Color.White, Color.Transparent);
        }
    }
}