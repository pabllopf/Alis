using System;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Ecs.Component.Render
{
    public class Camera: AComponent, IBuilder<CameraBuilder>
    {
        public RectangleI Viewport;
        
        public Vector2 Resolution;
        
        public Color BackgroundColor;
        
        public float CameraBorder;
        
        public Vector2 Position;
        
        public IntPtr TextureTarget;
        
        public Camera()
        {
            
        }
        
        public override void OnStart()
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
            TextureTarget = Sdl.CreateTexture(Context.GraphicManager.Renderer, Sdl.PixelFormatRgba8888, (int)TextureAccess.SdlTextureAccessTarget, Viewport.W, Viewport.H);
            
            Context.GraphicManager.Cameras.Add(this);
        }
        
        public override void OnUpdate()
        {
            Viewport = new RectangleI((int)(Position.X - Resolution.X / 2), (int)(Position.Y - Resolution.Y / 2), (int)Resolution.X, (int)Resolution.Y);
        }
        
        public CameraBuilder Builder() => new CameraBuilder();
    }
}