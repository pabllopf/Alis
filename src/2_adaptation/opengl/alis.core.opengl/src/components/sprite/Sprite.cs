using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core.OpenGL
{
    public class Sprite : Component
    {
        public Image image;

        public static Sprite Create() => new Sprite();

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public static Sprite Default => new Sprite();
    }
}