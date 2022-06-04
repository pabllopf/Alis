using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES30;
using OpenTK.Platform.Android;

using Android.Content;
using Android.Util;

namespace Alis.Template.Android
{
    class GLView1 : AndroidGameView
    {
        Ball ball;
        bool setViewport = true;

        public GLView1(Context context) : base(context)
        {
            // New GL "world" object
            ball = new Ball();

            // Do not set context on render frame as we will be rendering
            // on separate thread and thus Android will not set GL context
            // behind our back
            AutoSetContextOnRenderFrame = false;

            // Render on separate thread. This gains us
            // fluent rendering. Be careful to not use GL calls on UI thread.
            // OnRenderFrame is called from rendering thread, so do all
            // the GL calls there
            RenderOnUIThread = false;

            Resize += delegate
            {
                ball.SetupProjection(Width, Height);
                setViewport = true;
            };
        }

        // This gets called when the drawing surface is ready
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Run the render loop
            Run();
        }

        protected override void OnContextSet(EventArgs e)
        {
            base.OnContextSet(e);
            Console.WriteLine($"OpenGL version: {GL.GetString(StringName.Version)} GLSL version: {GL.GetString(StringName.ShadingLanguageVersion)}");
            ball.LoadShaders();
            ball.InitModel();
            ball.Start();
        }

        // This method is called everytime the context needs
        // to be recreated. Use it to set any egl-specific settings
        // prior to context creation
        //
        // In this particular case, we demonstrate how to set
        // the graphics mode and fallback in case the device doesn't
        // support the defaults
        protected override void CreateFrameBuffer()
        {
            ContextRenderingApi = GLVersion.ES3;

            // The default GraphicsMode that is set consists of (16, 16, 0, 0, 2, false)
            try
            {
                Log.Verbose("GLTemplateES30", "Loading with default settings");

                // If you don't call this, the context won't be created
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex)
            {
                Log.Verbose($"GLTemplateES30", $"{ex}");
            }

            // This is a graphics setting that sets everything to the lowest mode possible so
            // the device returns a reliable graphics setting.
            try
            {
                Log.Verbose("GLTemplateES30", "Loading with custom Android settings (low mode)");
                GraphicsMode = new AndroidGraphicsMode(0, 0, 0, 0, 0, false);

                // If you don't call this, the context won't be created
                base.CreateFrameBuffer();
                return;
            }
            catch (Exception ex)
            {
                Log.Verbose($"GLTemplateES30", $"{ex}");
            }
            throw new Exception("Can't load egl, aborting");
        }

        // This gets called on each frame render
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // You only need to call this if you have delegates
            // registered that you want to have called
            base.OnRenderFrame(e);

            ball.UpdateWorld();

            if (setViewport)
            {
                setViewport = false;
                GL.Viewport(0, 0, Width, Height);
            }

            ball.RenderFrame();

            SwapBuffers();
        }
    }
}

