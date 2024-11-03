using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;

namespace Alis.Core.Graphic.Fonts
{
    public class Font
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public Color BackgroundColor { get; set; }
        public IntPtr Texture { get; }
        public IntPtr Surface { get; }
        public Dictionary<char, RectangleI> CharacterRects { get; }

        public Font(string name, int size, Color color, Color backgroundColor, IntPtr texture, IntPtr surface, Dictionary<char, RectangleI> characterRects)
        {
            Name = name;
            Size = size;
            Color = color;
            BackgroundColor = backgroundColor;
            Texture = texture;
            Surface = surface;
            CharacterRects = characterRects;
        }

        public Font(string fontName, int fontSize, IntPtr texture, IntPtr surface, Dictionary<char, RectangleI> characterRects)
        {
            Name = fontName;
            Size = fontSize;
            Texture = texture;
            Surface = surface;
            CharacterRects = characterRects;
        }
    }
}