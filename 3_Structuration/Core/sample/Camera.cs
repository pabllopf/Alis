using System;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Sample
{
    public class Camera
    {
        public RectangleI Viewport;
        
        public Vector2 Resolution;
        
        public Color BackgroundColor;
        
        public float CameraBorder;
        
        public Vector2 Position;
        
        public IntPtr TextureTarget;
        
        public Camera(IntPtr renderer)
        {
            Position = new Vector2(0, 0);
            Resolution = new Vector2(640, 480);
            Viewport = new RectangleI(0, 0, 640, 480);
            BackgroundColor = Color.Black;
            CameraBorder = 1f;
            TextureTarget = IntPtr.Zero;
            
            int x = (int)Math.Truncate(Position.X);
            int y = (int)Math.Truncate(Position.Y);
            int w = (int)Math.Truncate(Resolution.X);
            int h = (int)Math.Truncate(Resolution.Y);
            
            Viewport = new RectangleI(x, y, w, h);
            TextureTarget = Sdl.CreateTexture(renderer, Sdl.PixelFormatRgba8888, (int)TextureAccess.SdlTextureAccessTarget, Viewport.W, Viewport.H);
        }
        
        public void OnUpdate()
        {
            Viewport = new RectangleI((int)(Position.X - Resolution.X / 2), (int)(Position.Y - Resolution.Y / 2), (int)Resolution.X, (int)Resolution.Y);
        }
    }
}