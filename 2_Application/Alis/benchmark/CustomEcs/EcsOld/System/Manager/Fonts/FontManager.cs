// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontManager.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math.Definition;

namespace Alis.Core.EcsOld.System.Manager.Fonts
{
    /// <summary>
    ///     The font manager class
    /// </summary>
    public class FontManager
    {
        /// <summary>
        ///     Renders the text using the specified mono
        /// </summary>
        /// <param name="mono">The mono</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="white">The white</param>
        /// <param name="p5">The </param>
        public void RenderText(string mono, string p1, float p2, int p3, Color white, int p5)
        {
        }

        /// <summary>
        ///     Loads the font using the specified mono
        /// </summary>
        /// <param name="mono">The mono</param>
        /// <param name="i">The </param>
        /// <param name="find">The find</param>
        public void LoadFont(string mono, int i, string find)
        {
        }

        /// <summary>
        ///     Renders the text using the specified mono
        /// </summary>
        /// <param name="mono">The mono</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="white">The white</param>
        /// <param name="p5">The </param>
        public void RenderText(string mono, string p1, float p2, float p3, Color white, int p5)
        {
        }
    }
    /*
    /// <summary>
    ///     The font
    /// </summary>
    private readonly Dictionary<string, Font> _fonts = new Dictionary<string, Font>();

    /// <summary>
    ///     The renderer
    /// </summary>
    private readonly Context context;

    /// <summary>
    ///     The renderer flips
    /// </summary>
    private readonly RendererFlips _rendererFlips;

    /// <summary>
    ///     Initializes a new instance of the <see cref="FontManager" /> class
    /// </summary>
    /// <param name="context">The renderer</param>
    /// <param name="rendererFlips">The renderer flips</param>
    public FontManager(Context context, RendererFlips rendererFlips)
    {
        this.context = context;
        _rendererFlips = rendererFlips;
    }

    /// <summary>
    ///     Loads the font using the specified font name
    /// </summary>
    /// <param name="fontName">The font name</param>
    /// <param name="fontSize">The font size</param>
    /// <param name="fontColor">The font color</param>
    /// <param name="backgroundColor">The background color</param>
    /// <param name="fontPath">The font path</param>
    public void LoadFont(string fontName, int fontSize, Color fontColor, Color backgroundColor, string fontPath)
    {
        IntPtr surface = Sdl.LoadBmp(fontPath);
        if (surface == IntPtr.Zero)
        {
            Logger.Exception($"Failed to load BMP file: {Sdl.GetError()}");
            return;
        }

        // Set the color key (transparent pixel) in a surface
        // Here, we assume the background color is black (0, 0, 0)
        Surface surfaceObject = Marshal.PtrToStructure<Surface>(surface);

        Sdl.SetColorKey(surface, 1, Sdl.MapRgb(surfaceObject.Format, 0, 0, 0));

        IntPtr texture = Sdl.CreateTextureFromSurface(context.GraphicManager.Renderer, surface);
        if (texture == IntPtr.Zero)
        {
            Logger.Exception($"Failed to create texture from surface: {Sdl.GetError()}");
            return;
        }


        Dictionary<char, RectangleI> characterRects = new Dictionary<char, RectangleI>();
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string special = "0123456789";

        int charWidth = 10; // Width of each character in the bitmap
        int charHeight = 16; // Height of each character in the bitmap
        int charsPerRow = 28; // Number of characters per row in the bitmap
        int xSpacing = 1; // Horizontal spacing between characters
        int ySpacing = 0; // Vertical spacing between rows

        // Iterate over lowercase characters
        for (int i = 0; i < lowercase.Length; i++)
        {
            char c = lowercase[i];
            int x = i % charsPerRow * (charWidth + xSpacing);
            int y = i / charsPerRow * (charHeight + ySpacing);
            characterRects[c] = new RectangleI
                {X = x, Y = y, W = charWidth, H = charHeight};
        }

        // Iterate over uppercase characters
        for (int i = 0; i < uppercase.Length; i++)
        {
            char c = uppercase[i];
            int x = i % charsPerRow * (charWidth + xSpacing);
            int y = (i / charsPerRow + 1) * (charHeight + ySpacing); // Move to the next row
            characterRects[c] = new RectangleI
                {X = x, Y = y, W = charWidth, H = charHeight};
        }

        // Iterate over special characters
        for (int i = 0; i < special.Length; i++)
        {
            char c = special[i];
            int x = i % charsPerRow * (charWidth + xSpacing);
            int y = (i / charsPerRow + 2) * (charHeight + ySpacing); // Move to the next row
            characterRects[c] = new RectangleI
                {X = x, Y = y, W = charWidth, H = charHeight};
        }

        _fonts[fontName] = new Font(fontName, fontSize, fontColor, backgroundColor, texture, surface, characterRects);
    }

    /// <summary>
    ///     Loads the font using the specified font name
    /// </summary>
    /// <param name="fontName">The font name</param>
    /// <param name="fontSize">The font size</param>
    /// <param name="fontPath">The font path</param>
    public void LoadFont(string fontName, int fontSize, string fontPath)
    {
        IntPtr surface = Sdl.LoadBmp(fontPath);
        if (surface == IntPtr.Zero)
        {
            Logger.Exception($"Failed to load BMP file: {Sdl.GetError()}");
            return;
        }

        // Set the color key (transparent pixel) in a surface
        // Here, we assume the background color is black (0, 0, 0)
        Surface surfaceObject = Marshal.PtrToStructure<Surface>(surface);

        Sdl.SetColorKey(surface, 1, Sdl.MapRgb(surfaceObject.Format, 0, 0, 0));

        IntPtr texture = Sdl.CreateTextureFromSurface(context.GraphicManager.Renderer, surface);
        if (texture == IntPtr.Zero)
        {
            Logger.Exception($"Failed to create texture from surface: {Sdl.GetError()}");
            return;
        }


        Dictionary<char, RectangleI> characterRects = new Dictionary<char, RectangleI>();
        string lowercase = "abcdefghijklmnopqrstuvwxyz ";
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        string special = "0123456789.:,;(*!?}^)$#{%^&-+@"; // Special characters

        int charWidth = 10; // Width of each character in the bitmap
        int charHeight = 16; // Height of each character in the bitmap
        int charsPerRow = 28; // Number of characters per row in the bitmap
        int xSpacing = 1; // Horizontal spacing between characters
        int ySpacing = 0; // Vertical spacing between rows

        // Iterate over lowercase characters
        for (int i = 0; i < lowercase.Length; i++)
        {
            char c = lowercase[i];
            int x = i % charsPerRow * (charWidth + xSpacing);
            int y = i / charsPerRow * (charHeight + ySpacing);
            characterRects[c] = new RectangleI
                {X = x, Y = y, W = charWidth, H = charHeight};
        }

        // Iterate over uppercase characters
        for (int i = 0; i < uppercase.Length; i++)
        {
            char c = uppercase[i];
            int x = i % charsPerRow * (charWidth + xSpacing);
            int y = (i / charsPerRow + 1) * (charHeight + ySpacing); // Move to the next row
            characterRects[c] = new RectangleI
                {X = x, Y = y, W = charWidth, H = charHeight};
        }

        // Iterate over special characters
        for (int i = 0; i < special.Length; i++)
        {
            char c = special[i];
            int x = i % charsPerRow * (charWidth + xSpacing);
            int y = (i / charsPerRow + 2) * (charHeight + ySpacing); // Move to the next row
            characterRects[c] = new RectangleI
                {X = x, Y = y, W = charWidth, H = charHeight};
        }

        _fonts[fontName] = new Font(fontName, fontSize, texture, surface, characterRects);
    }

    /// <summary>
    ///     Renders the text using the specified font name
    /// </summary>
    /// <param name="fontName">The font name</param>
    /// <param name="text">The text</param>
    /// <param name="x">The </param>
    /// <param name="y">The </param>
    public void RenderText(string fontName, string text, int x, int y)
    {
        if (!_fonts.TryGetValue(fontName, out Font font))
        {
            Logger.Exception($"Font '{fontName}' not found.");
            return;
        }

        int posX = x;

        // Lock the surface to access pixel data
        Sdl.LockSurface(font.Surface);

        // Get the pixel data from the surface
        Surface surfaceObject = Marshal.PtrToStructure<Surface>(font.Surface);
        IntPtr pixels = surfaceObject.Pixels;
        int pitch = surfaceObject.pitch;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Iterate through the pixels and change the color
                for (int py = 0; py < srcRect.H; py++)
                {
                    for (int px = 0; px < srcRect.W; px++)
                    {
                        int index = (srcRect.Y + py) * pitch + (srcRect.X + px) * 4; // 4 bytes per pixel (RGBA)
                        byte alpha = Marshal.ReadByte(pixels, index + 3);
                        if (alpha > 0) // Only modify non-transparent pixels
                        {
                            byte originalR = Marshal.ReadByte(pixels, index + 2);
                            byte originalG = Marshal.ReadByte(pixels, index + 1);
                            byte originalB = Marshal.ReadByte(pixels, index);

                            byte newR = (byte) ((font.Color.R * alpha + originalR * (255 - alpha)) / 255);
                            byte newG = (byte) ((font.Color.G * alpha + originalG * (255 - alpha)) / 255);
                            byte newB = (byte) ((font.Color.B * alpha + originalB * (255 - alpha)) / 255);

                            Marshal.WriteByte(pixels, index, newB); // Blue
                            Marshal.WriteByte(pixels, index + 1, newG); // Green
                            Marshal.WriteByte(pixels, index + 2, newR); // Red
                        }
                    }
                }

                // Draw text character
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W, H = srcRect.H};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += srcRect.W; // Move the X position for the next character
            }
        }

        // Unlock the surface
        Sdl.UnlockSurface(font.Surface);

        // Update the entire texture with the modified pixel data
        Sdl.UpdateTexture(font.Texture, IntPtr.Zero, pixels, pitch);

        posX = x;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Draw text character
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W, H = srcRect.H};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += srcRect.W; // Move the X position for the next character
            }
        }
    }

    /// <summary>
    ///     Renders the text using the specified font name
    /// </summary>
    /// <param name="fontName">The font name</param>
    /// <param name="text">The text</param>
    /// <param name="x">The </param>
    /// <param name="y">The </param>
    /// <param name="colorFont">The color font</param>
    public void RenderText(string fontName, string text, int x, int y, Color colorFont)
    {
        if (!_fonts.TryGetValue(fontName, out Font font))
        {
            Logger.Exception($"Font '{fontName}' not found.");
            return;
        }

        int posX = x;

        // Lock the surface to access pixel data
        Sdl.LockSurface(font.Surface);

        // Get the pixel data from the surface
        Surface surfaceObject = Marshal.PtrToStructure<Surface>(font.Surface);
        IntPtr pixels = surfaceObject.Pixels;
        int pitch = surfaceObject.pitch;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Iterate through the pixels and change the color
                for (int py = 0; py < srcRect.H; py++)
                {
                    for (int px = 0; px < srcRect.W; px++)
                    {
                        int index = (srcRect.Y + py) * pitch + (srcRect.X + px) * 4; // 4 bytes per pixel (RGBA)
                        byte alpha = Marshal.ReadByte(pixels, index + 3);
                        if (alpha > 0) // Only modify non-transparent pixels
                        {
                            Marshal.WriteByte(pixels, index, colorFont.B); // Blue
                            Marshal.WriteByte(pixels, index + 1, colorFont.G); // Green
                            Marshal.WriteByte(pixels, index + 2, colorFont.R); // Red
                        }
                    }
                }

                // Draw text character
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W, H = srcRect.H};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += srcRect.W; // Move the X position for the next character
            }
        }

        // Unlock the surface
        Sdl.UnlockSurface(font.Surface);

        // Update the entire texture with the modified pixel data
        Sdl.UpdateTexture(font.Texture, IntPtr.Zero, pixels, pitch);

        posX = x;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Draw text character
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W, H = srcRect.H};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += srcRect.W; // Move the X position for the next character
            }
        }
    }


    /// <summary>
    ///     Renders the text using the specified font name
    /// </summary>
    /// <param name="fontName">The font name</param>
    /// <param name="text">The text</param>
    /// <param name="x">The </param>
    /// <param name="y">The </param>
    /// <param name="colorFont">The color font</param>
    /// <param name="backgroundColor">The background color</param>
    public void RenderText(string fontName, string text, int x, int y, Color colorFont, Color backgroundColor)
    {
        if (!_fonts.TryGetValue(fontName, out Font font))
        {
            Logger.Exception($"Font '{fontName}' not found.");
            return;
        }

        int posX = x;

        // Lock the surface to access pixel data
        Sdl.LockSurface(font.Surface);

        // Get the pixel data from the surface
        Surface surfaceObject = Marshal.PtrToStructure<Surface>(font.Surface);
        IntPtr pixels = surfaceObject.Pixels;
        int pitch = surfaceObject.pitch;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Iterate through the pixels and change the color
                for (int py = 0; py < srcRect.H; py++)
                {
                    for (int px = 0; px < srcRect.W; px++)
                    {
                        int index = (srcRect.Y + py) * pitch + (srcRect.X + px) * 4; // 4 bytes per pixel (RGBA)
                        byte alpha = Marshal.ReadByte(pixels, index + 3);
                        if (alpha > 0) // Only modify non-transparent pixels
                        {
                            Marshal.WriteByte(pixels, index, colorFont.B); // Blue
                            Marshal.WriteByte(pixels, index + 1, colorFont.G); // Green
                            Marshal.WriteByte(pixels, index + 2, colorFont.R); // Red
                        }
                    }
                }

                // Draw text character
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W, H = srcRect.H};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += srcRect.W; // Move the X position for the next character
            }
        }

        // Unlock the surface
        Sdl.UnlockSurface(font.Surface);

        // Update the entire texture with the modified pixel data
        Sdl.UpdateTexture(font.Texture, IntPtr.Zero, pixels, pitch);

        posX = x;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Draw background rectangle
                RectangleI backgroundRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W, H = srcRect.H};
                Sdl.SetRenderDrawColor(context.GraphicManager.Renderer, backgroundColor.R, backgroundColor.G, backgroundColor.B, backgroundColor.A);
                Sdl.RenderFillRect(context.GraphicManager.Renderer, ref backgroundRect);

                // Draw text character
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W, H = srcRect.H};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += srcRect.W; // Move the X position for the next character
            }
        }
    }

    /// <summary>
    ///     Renders the text using the specified font name
    /// </summary>
    /// <param name="fontName">The font name</param>
    /// <param name="text">The text</param>
    /// <param name="x">The </param>
    /// <param name="y">The </param>
    /// <param name="colorFont">The color font</param>
    /// <param name="backgroundColor">The background color</param>
    /// <param name="fontSize">The font size</param>
    public void RenderText(string fontName, string text, int x, int y, Color colorFont, Color backgroundColor, int fontSize)
    {
        if (!_fonts.TryGetValue(fontName, out Font font))
        {
            Logger.Exception($"Font '{fontName}' not found.");
            return;
        }

        int posX = x;

        // Lock the surface to access pixel data
        Sdl.LockSurface(font.Surface);

        // Get the pixel data from the surface
        Surface surfaceObject = Marshal.PtrToStructure<Surface>(font.Surface);
        IntPtr pixels = surfaceObject.Pixels;
        int pitch = surfaceObject.pitch;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Iterate through the pixels and change the color
                for (int py = 0; py < srcRect.H; py++)
                {
                    for (int px = 0; px < srcRect.W; px++)
                    {
                        int index = (srcRect.Y + py) * pitch + (srcRect.X + px) * 4; // 4 bytes per pixel (RGBA)
                        byte alpha = Marshal.ReadByte(pixels, index + 3);
                        if (alpha > 0) // Only modify non-transparent pixels
                        {
                            Marshal.WriteByte(pixels, index, colorFont.B); // Blue
                            Marshal.WriteByte(pixels, index + 1, colorFont.G); // Green
                            Marshal.WriteByte(pixels, index + 2, colorFont.R); // Red
                        }
                    }
                }

                // Draw text character with scaling
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W * fontSize / font.Size, H = srcRect.H * fontSize / font.Size};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += dstRect.W; // Move the X position for the next character
            }
        }

        // Unlock the surface
        Sdl.UnlockSurface(font.Surface);

        // Update the entire texture with the modified pixel data
        Sdl.UpdateTexture(font.Texture, IntPtr.Zero, pixels, pitch);

        posX = x;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Draw background rectangle with scaling
                RectangleI backgroundRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W * fontSize / font.Size, H = srcRect.H * fontSize / font.Size};
                Sdl.SetRenderDrawColor(context.GraphicManager.Renderer, backgroundColor.R, backgroundColor.G, backgroundColor.B, backgroundColor.A);
                Sdl.RenderFillRect(context.GraphicManager.Renderer, ref backgroundRect);

                // Draw text character with scaling
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = y, W = srcRect.W * fontSize / font.Size, H = srcRect.H * fontSize / font.Size};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += dstRect.W; // Move the X position for the next character
            }
        }
    }

    /// <summary>
    ///     Renders the text using the specified font name
    /// </summary>
    /// <param name="fontName">The font name</param>
    /// <param name="text">The text</param>
    /// <param name="x">The x position</param>
    /// <param name="y">The y position</param>
    /// <param name="colorFont">The color font</param>
    /// <param name="fontSize">The font size</param>
    public void RenderText(string fontName, string text, float x, float y, Color colorFont, int fontSize)
    {
        if (!_fonts.TryGetValue(fontName, out Font font))
        {
            Logger.Exception($"Font '{fontName}' not found.");
            return;
        }

        List<Camera> cameras = context.GraphicManager.Cameras;
        if (cameras.Count == 0)
        {
            Logger.Exception("No cameras found.");
            return;
        }

        Camera camera = cameras[0]; // Assuming the first camera is the main camera
        Vector2F cameraPosition = camera.Position;
        Vector2F cameraResolution = camera.Resolution;
        float pixelsPerMeter = 32.0f; // Assuming a constant value for pixels per meter

        // Get the window size
        Vector2F windowSize = Sdl.GetWindowSize(context.GraphicManager.Window);

        // Adjust the text position based on the camera position and window size
        int adjustedX = (int)((x - cameraPosition.X) * pixelsPerMeter + cameraResolution.X / 2);
        int adjustedY = (int)((y - cameraPosition.Y) * pixelsPerMeter + cameraResolution.Y / 2);

        // Scale the position based on the window size
        adjustedX = (int)(adjustedX * (windowSize.X / cameraResolution.X));
        adjustedY = (int)(adjustedY * (windowSize.Y / cameraResolution.Y));

        int posX = adjustedX;

        // Lock the surface to access pixel data
        Sdl.LockSurface(font.Surface);

        // Get the pixel data from the surface
        Surface surfaceObject = Marshal.PtrToStructure<Surface>(font.Surface);
        IntPtr pixels = surfaceObject.Pixels;
        int pitch = surfaceObject.pitch;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Iterate through the pixels and change the color
                for (int py = 0; py < srcRect.H; py++)
                {
                    for (int px = 0; px < srcRect.W; px++)
                    {
                        int index = (srcRect.Y + py) * pitch + (srcRect.X + px) * 4; // 4 bytes per pixel (RGBA)
                        byte alpha = Marshal.ReadByte(pixels, index + 3);
                        if (alpha > 0) // Only modify non-transparent pixels
                        {
                            Marshal.WriteByte(pixels, index, colorFont.B); // Blue
                            Marshal.WriteByte(pixels, index + 1, colorFont.G); // Green
                            Marshal.WriteByte(pixels, index + 2, colorFont.R); // Red
                        }
                    }
                }

                // Draw text character with scaling
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = adjustedY, W = srcRect.W * fontSize / font.Size, H = srcRect.H * fontSize / font.Size};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += dstRect.W; // Move the X position for the next character
            }
        }

        // Unlock the surface
        Sdl.UnlockSurface(font.Surface);

        // Update the entire texture with the modified pixel data
        Sdl.UpdateTexture(font.Texture, IntPtr.Zero, pixels, pitch);

        posX = adjustedX;

        foreach (char c in text)
        {
            if (font.CharacterRects.TryGetValue(c, out RectangleI srcRect))
            {
                // Draw text character with scaling
                RectangleI dstRect = new RectangleI
                    {X = posX, Y = adjustedY, W = srcRect.W * fontSize / font.Size, H = srcRect.H * fontSize / font.Size};
                Sdl.RenderCopyEx(context.GraphicManager.Renderer, font.Texture, ref srcRect, ref dstRect, 0, IntPtr.Zero, _rendererFlips);

                posX += dstRect.W; // Move the X position for the next character
            }
        }
    }
}*/
}