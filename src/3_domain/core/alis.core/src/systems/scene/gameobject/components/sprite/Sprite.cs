using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class Sprite : Component
    {
        public Image image;

        public static Sprite Create() => new Sprite();

        public static Sprite Default => new Sprite();
    }
}