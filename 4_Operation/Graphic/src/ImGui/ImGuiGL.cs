using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base;
using Alis.Core.Graphic.Properties;
using static SDL2.SDL;
using static OpenGL.GL;


namespace ImGuiGeneral
{
	/// <summary>
	/// The im gui gl class
	/// </summary>
	public static class ImGuiGL
	{
        static ImGuiGL()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dylib", NativeGraphic.osx_arm64_cimgui);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dylib", NativeGraphic.osx_x64_cimgui);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dll", NativeGraphic.win_arm64_cimgui);
                        break;
                    case Architecture.X86:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dll", NativeGraphic.win_x86_cimgui);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.dll", NativeGraphic.win_x64_cimgui);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.so", NativeGraphic.debian_arm64_cimgui);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("cimgui.so", NativeGraphic.debian_arm64_cimgui);
                        break;
                }
            }
        }
        
		/// <summary>
		/// Creates the window and gl context using the specified title
		/// </summary>
		/// <param name="title">The title</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="fullscreen">The fullscreen</param>
		/// <param name="highDpi">The high dpi</param>
		/// <returns>The int ptr int ptr</returns>
		public static (IntPtr, IntPtr) CreateWindowAndGLContext(string title, int width, int height, bool fullscreen = false, bool highDpi = false)
		{
			// initialize SDL and set a few defaults for the OpenGL context
			SDL_Init(SDL_INIT_VIDEO);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_FLAGS, (int)SDL_GLcontext.SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_CORE);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_MAJOR_VERSION, 3);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_MINOR_VERSION, 2);

			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_CONTEXT_PROFILE_MASK, SDL_GLprofile.SDL_GL_CONTEXT_PROFILE_CORE);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DOUBLEBUFFER, 1);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_DEPTH_SIZE, 24);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_ALPHA_SIZE, 8);
			SDL_GL_SetAttribute(SDL_GLattr.SDL_GL_STENCIL_SIZE, 8);

			// create the window which should be able to have a valid OpenGL context and is resizable
			var flags = SDL_WindowFlags.SDL_WINDOW_OPENGL | SDL_WindowFlags.SDL_WINDOW_RESIZABLE;
			if (fullscreen) flags |= SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
			if (highDpi) flags |= SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI;

			var window = SDL_CreateWindow(title, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, width, height, flags);
			var glContext = CreateGLContext(window);
			return (window, glContext);
		}

		/// <summary>
		/// Creates the gl context using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <exception cref="Exception">CouldNotCreateContext</exception>
		/// <returns>The gl context</returns>
		static IntPtr CreateGLContext(IntPtr window)
		{
			var glContext = SDL_GL_CreateContext(window);
			if (glContext == IntPtr.Zero)
				throw new Exception("CouldNotCreateContext");

			SDL_GL_MakeCurrent(window, glContext);
			SDL_GL_SetSwapInterval(1);

			// initialize the screen to black as soon as possible
			glClearColor(0f, 0f, 0f, 1f);
			glClear(ClearBufferMask.ColorBufferBit);
			SDL_GL_SwapWindow(window);

			Console.WriteLine($"GL Version: {glGetString(StringName.Version)}");
			return glContext;
		}

		/// <summary>
		/// Loads the texture using the specified pixel data
		/// </summary>
		/// <param name="pixelData">The pixel data</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="format">The format</param>
		/// <param name="internalFormat">The internal format</param>
		/// <returns>The texture id</returns>
		public static uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
		{
			var textureId = GenTexture();
			glPixelStorei(PixelStoreParameter.UnpackAlignment, 1);
			glBindTexture(TextureTarget.Texture2D, textureId);
			glTexImage2D(TextureTarget.Texture2D, 0, internalFormat, width, height, 0, format,PixelType.UnsignedByte, pixelData);
			glTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
			glTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
			glBindTexture(TextureTarget.Texture2D, 0);
			return textureId;
		}
	}
}