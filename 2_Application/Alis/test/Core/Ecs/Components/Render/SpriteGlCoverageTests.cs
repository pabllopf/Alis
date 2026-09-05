// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteGlCoverageTests.cs
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

using System;
using System.IO;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// Drives the GL-backed paths of <see cref="Sprite" /> using a fake function pointer table.
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class SpriteGlCoverageTests : IDisposable
    {
        private static readonly FieldInfo GlField = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly FieldInfo SharedInitializedField = typeof(Sprite).GetField("SharedInitialized", BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly FieldInfo LastBoundTextureField = typeof(Sprite).GetField("LastBoundTexture", BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly FieldInfo TextureField = typeof(Sprite).GetField("<Texture>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo SizeField = typeof(Sprite).GetField("<Size>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo FlipField = typeof(Sprite).GetField("<Flip>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);

        private readonly object _savedGl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteGlCoverageTests"/> class
        /// </summary>
        public SpriteGlCoverageTests() => _savedGl = GlField?.GetValue(null);

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => GlField?.SetValue(null, _savedGl);

        private static readonly Gl.ActiveTexture FakeActiveTexture = _ => { };

        private static readonly BindTexture FakeBindTexture = (_, _) => { };

        private static readonly CreateShader FakeCreateShader = _ => 1;

        private static readonly ShaderSourceDel FakeShaderSource = (_, _, _, _) => { };

        private static readonly CompileShader FakeCompileShader = _ => { };

        private static readonly CreateProgram FakeCreateProgram = () => 1;

        private static readonly AttachShader FakeAttachShader = (_, _) => { };

        private static readonly LinkProgram FakeLinkProgram = _ => { };

        private static readonly DeleteShader FakeDeleteShader = _ => { };

        private static readonly GetUniformLocation FakeGetUniformLocation = (_, _) => 0;

        private static readonly Uniform1I FakeUniform1I = (_, _) => { };

        private static readonly GenVertexArrays FakeGenVertexArrays = (_, arrays) => arrays[0] = 1;

        private static readonly GenBuffers FakeGenBuffers = (_, buffers) => buffers[0] = 2;

        private static readonly BindVertexArray FakeBindVertexArray = _ => { };

        private static readonly BindBuffer FakeBindBuffer = (_, _) => { };

        private static readonly BufferData FakeBufferData = (_, _, _, _) => { };

        private static readonly VertexAttribPointerDel FakeVertexAttribPointer = (_, _, _, _, _, _) => { };

        private static readonly EnableVertexAttribArrayDel FakeEnableVertexAttribArray = _ => { };

        private static readonly GenTextures FakeGenTextures = (_, textures) => textures[0] = 3;

        private static readonly TexParameteri FakeTexParameteri = (_, _, _) => { };

        private static readonly TexImage2D FakeTexImage2D = (_, _, _, _, _, _, _, _, _) => { };

        private static readonly GetString FakeMipMap = _ => IntPtr.Zero;

        private static readonly UseProgram FakeUseProgram = _ => { };

        private static readonly Uniform2F FakeUniform2F = (_, _, _) => { };

        private static readonly Uniform1F FakeUniform1F = (_, _) => { };

        private static readonly Enable FakeEnable = _ => { };

        private static readonly BlendFunc FakeBlendFunc = (_, _) => { };

        private static readonly DrawElements FakeDrawElements = (_, _, _, _) => { };

        private static readonly Disable FakeDisable = _ => { };

        private static readonly DeleteTextures FakeDeleteTextures = (_, _) => { };

        private static readonly GetShaderiv OkShaderiv = (_, pname, p) => p[0] = pname == ShaderParameter.CompileStatus ? 1 : 0;

        private static readonly GetProgramiv OkProgramiv = (_, pname, p) => p[0] = pname == ProgramParameter.LinkStatus ? 1 : 0;

        private static readonly GetShaderiv FailCompileShaderiv = (_, pname, p) => p[0] = pname == ShaderParameter.CompileStatus ? 0 : 12;

        private static readonly GetShaderInfoLogDel FakeReadShaderLog = (_, _, length, sb) =>
        {
            length[0] = 4;
            sb.Append("fail");
        };

        private static readonly GetProgramiv FailLinkProgramiv = (_, pname, p) => p[0] = pname == ProgramParameter.LinkStatus ? 0 : 9;

        private static readonly GetProgramInfoLogDel FakeReadProgramLog = (_, _, length, sb) =>
        {
            length[0] = 4;
            sb.Append("link");
        };

        private static Gl.GetProcAddressDelegate SuccessResolver() => name => name switch
        {
            "glActiveTexture" => Marshal.GetFunctionPointerForDelegate(FakeActiveTexture),
            "glBindTexture" => Marshal.GetFunctionPointerForDelegate(FakeBindTexture),
            "glCreateShader" => Marshal.GetFunctionPointerForDelegate(FakeCreateShader),
            "glShaderSource" => Marshal.GetFunctionPointerForDelegate(FakeShaderSource),
            "glCompileShader" => Marshal.GetFunctionPointerForDelegate(FakeCompileShader),
            "glGetShaderiv" => Marshal.GetFunctionPointerForDelegate(OkShaderiv),
            "glCreateProgram" => Marshal.GetFunctionPointerForDelegate(FakeCreateProgram),
            "glAttachShader" => Marshal.GetFunctionPointerForDelegate(FakeAttachShader),
            "glLinkProgram" => Marshal.GetFunctionPointerForDelegate(FakeLinkProgram),
            "glGetProgramiv" => Marshal.GetFunctionPointerForDelegate(OkProgramiv),
            "glDeleteShader" => Marshal.GetFunctionPointerForDelegate(FakeDeleteShader),
            "glGetUniformLocation" => Marshal.GetFunctionPointerForDelegate(FakeGetUniformLocation),
            "glUniform1i" => Marshal.GetFunctionPointerForDelegate(FakeUniform1I),
            "glGenVertexArrays" => Marshal.GetFunctionPointerForDelegate(FakeGenVertexArrays),
            "glGenBuffers" => Marshal.GetFunctionPointerForDelegate(FakeGenBuffers),
            "glBindVertexArray" => Marshal.GetFunctionPointerForDelegate(FakeBindVertexArray),
            "glBindBuffer" => Marshal.GetFunctionPointerForDelegate(FakeBindBuffer),
            "glBufferData" => Marshal.GetFunctionPointerForDelegate(FakeBufferData),
            "glVertexAttribPointer" => Marshal.GetFunctionPointerForDelegate(FakeVertexAttribPointer),
            "glEnableVertexAttribArray" => Marshal.GetFunctionPointerForDelegate(FakeEnableVertexAttribArray),
            "glGenTextures" => Marshal.GetFunctionPointerForDelegate(FakeGenTextures),
            "glTexParameteri" => Marshal.GetFunctionPointerForDelegate(FakeTexParameteri),
            "glTexImage2D" => Marshal.GetFunctionPointerForDelegate(FakeTexImage2D),
            "glGenerateMipmap" => Marshal.GetFunctionPointerForDelegate(FakeMipMap),
            "glUseProgram" => Marshal.GetFunctionPointerForDelegate(FakeUseProgram),
            "glUniform2f" => Marshal.GetFunctionPointerForDelegate(FakeUniform2F),
            "glUniform1f" => Marshal.GetFunctionPointerForDelegate(FakeUniform1F),
            "glEnable" => Marshal.GetFunctionPointerForDelegate(FakeEnable),
            "glBlendFunc" => Marshal.GetFunctionPointerForDelegate(FakeBlendFunc),
            "glDrawElements" => Marshal.GetFunctionPointerForDelegate(FakeDrawElements),
            "glDisable" => Marshal.GetFunctionPointerForDelegate(FakeDisable),
            "glDeleteTextures" => Marshal.GetFunctionPointerForDelegate(FakeDeleteTextures),
            _ => IntPtr.Zero
        };

        private static Gl.GetProcAddressDelegate CompileFailResolver() => name => name switch
        {
            "glGetShaderiv" => Marshal.GetFunctionPointerForDelegate(FailCompileShaderiv),
            "glGetShaderInfoLog" => Marshal.GetFunctionPointerForDelegate(FakeReadShaderLog),
            _ => SuccessResolver()(name)
        };

        private static Gl.GetProcAddressDelegate LinkFailResolver() => name => name switch
        {
            "glGetProgramiv" => Marshal.GetFunctionPointerForDelegate(FailLinkProgramiv),
            "glGetProgramInfoLog" => Marshal.GetFunctionPointerForDelegate(FakeReadProgramLog),
            _ => SuccessResolver()(name)
        };

        private static Gl.GetProcAddressDelegate FragmentFailResolver()
        {
            int counter = 0;
            GetShaderiv iv = (_, pname, p) => p[0] = pname == ShaderParameter.CompileStatus ? (counter++ == 0 ? 1 : 0) : 12;
            return name => name switch
            {
                "glGetShaderiv" => Marshal.GetFunctionPointerForDelegate(iv),
                "glGetShaderInfoLog" => Marshal.GetFunctionPointerForDelegate(FakeReadShaderLog),
                _ => SuccessResolver()(name)
            };
        }

        private static void ResetSpriteStatics()
        {
            SharedInitializedField?.SetValue(null, false);
            LastBoundTextureField?.SetValue(null, 0u);
        }

        private static void InvokeInitializeSharedResources(Context context)
        {
            try
            {
                typeof(Sprite).GetMethod("InitializeSharedResources", BindingFlags.NonPublic | BindingFlags.Static)?.Invoke(null, new object[] { context });
            }
            catch (TargetInvocationException exception) when (exception.InnerException != null)
            {
                ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
            }
        }

        private static Sprite BuildSprite()
        {
            Sprite sprite = new Sprite(new Context(), string.Empty, 0);
            object boxed = sprite;
            SizeField?.SetValue(boxed, new Vector2F(16, 16));
            TextureField?.SetValue(boxed, 0u);
            FlipField?.SetValue(boxed, false);
            return (Sprite)boxed;
        }

        /// <summary>
        /// Initializes the shared resources twice with an OpenGL ES friendly context
        /// </summary>
        [Fact]
        public void InitializeSharedResources_PreviewMode_Twice_Executes()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());
            Context context = new Context();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };

            InvokeInitializeSharedResources(context);
            InvokeInitializeSharedResources(context);

            Assert.Equal(true, SharedInitializedField?.GetValue(null));
        }

        /// <summary>
        /// Initializes the shared resources with the desktop shader variant
        /// </summary>
        [Fact]
        public void InitializeSharedResources_DesktopVariant_Executes()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());

            InvokeInitializeSharedResources(new Context());

            Assert.Equal(true, SharedInitializedField?.GetValue(null));
        }

        /// <summary>
        /// Throws when the vertex shader fails to compile
        /// </summary>
        [Fact]
        public void InitializeSharedResources_VertexCompileFails_Throws()
        {
            ResetSpriteStatics();
            Gl.Initialize(CompileFailResolver());

            Assert.Throws<InvalidOperationException>(() => InvokeInitializeSharedResources(new Context()));
        }

        /// <summary>
        /// Throws when the shader program fails to link
        /// </summary>
        [Fact]
        public void InitializeSharedResources_LinkFails_Throws()
        {
            ResetSpriteStatics();
            Gl.Initialize(LinkFailResolver());

            Assert.Throws<InvalidOperationException>(() => InvokeInitializeSharedResources(new Context()));
        }

        /// <summary>
        /// Throws when the fragment shader fails to compile
        /// </summary>
        [Fact]
        public void InitializeSharedResources_FragmentCompileFails_Throws()
        {
            ResetSpriteStatics();
            Gl.Initialize(FragmentFailResolver());

            Assert.Throws<InvalidOperationException>(() => InvokeInitializeSharedResources(new Context()));
        }

        /// <summary>
        /// Loads an existing bitmap through the fake function pointer table
        /// </summary>
        [Fact]
        public void LoadTexture_ExistingBitmap_FakeGl_Succeeds()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());
            string path = Path.GetTempFileName() + ".bmp";
            try
            {
                byte[] data = new byte[58];
                data[0] = 0x42;
                data[1] = 0x4D;
                BitConverter.GetBytes(58).CopyTo(data, 2);
                data[10] = 54;
                BitConverter.GetBytes(40).CopyTo(data, 14);
                BitConverter.GetBytes(1).CopyTo(data, 18);
                BitConverter.GetBytes(1).CopyTo(data, 22);
                BitConverter.GetBytes((short)1).CopyTo(data, 26);
                BitConverter.GetBytes((short)32).CopyTo(data, 28);
                BitConverter.GetBytes(0).CopyTo(data, 34);
                BitConverter.GetBytes(4).CopyTo(data, 46);
                File.WriteAllBytes(path, data);

                Sprite sprite = BuildSprite();
                object boxed = sprite;
                typeof(Sprite).GetMethod("LoadTexture", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(boxed, new object[] { path });

                Assert.Equal(3u, TextureField?.GetValue(boxed));
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        /// Renders an invisible sprite and returns before issuing draw calls
        /// </summary>
        [Fact]
        public void Render_HiddenSprite_ReturnsEarly()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());
            Component.RegisterComponent<Transform>();
            Scene scene = new Scene();
            GameObject gameObject = scene.CreateFromObjects(new object[] { new Transform(new Vector2F(100, 100), 0f) });
            Sprite sprite = BuildSprite();

            sprite.Render(gameObject, new Vector2F(0, 0), new Vector2F(32, 32), 1f);

            Assert.True(TextureField?.GetValue(Box(sprite)).Equals(0u));
        }

        /// <summary>
        /// Renders a visible sprite with a bound texture and flip enabled
        /// </summary>
        [Fact]
        public void Render_VisibleWithTexture_FakeGl_Executes()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());
            Component.RegisterComponent<Transform>();
            Scene scene = new Scene();
            GameObject gameObject = scene.CreateFromObjects(new object[] { new Transform(new Vector2F(0, 0), 0f) });
            Sprite sprite = BuildSprite();
            object boxed = sprite;
            TextureField?.SetValue(boxed, 7u);
            FlipField?.SetValue(boxed, true);
            sprite = (Sprite)boxed;

            sprite.Render(gameObject, new Vector2F(0, 0), new Vector2F(32, 32), 1f);

            Assert.Equal(7u, TextureField?.GetValue(boxed));
        }

        /// <summary>
        /// Releases the texture through the fake function pointer table
        /// </summary>
        [Fact]
        public void OnExit_WithTexture_FakeGl_Executes()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());
            Sprite sprite = BuildSprite();
            object boxed = sprite;
            TextureField?.SetValue(boxed, 7u);
            sprite = (Sprite)boxed;

            typeof(Sprite).GetMethod("OnExit", BindingFlags.Public | BindingFlags.Instance)?.Invoke(boxed, new object[] { null });

            Assert.Equal(0u, TextureField?.GetValue(boxed));
        }

        /// <summary>
        /// Loads a missing file through the embedded resource fallback
        /// </summary>
        [Fact]
        public void LoadTexture_MissingFile_UsesEmbeddedResource()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());
            Sprite sprite = BuildSprite();
            object boxed = sprite;

            typeof(Sprite).GetMethod("LoadTexture", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(boxed, new object[] { "dino_assets.bmp" });

            Assert.Equal(3u, TextureField?.GetValue(boxed));
        }

        /// <summary>
        /// Renders a sprite whose texture is loaded from the embedded resource inside the render path
        /// </summary>
        [Fact]
        public void Render_NamedResource_InitializesInsideRenderPath()
        {
            ResetSpriteStatics();
            Gl.Initialize(SuccessResolver());
            Component.RegisterComponent<Transform>();
            Scene scene = new Scene();
            GameObject gameObject = scene.CreateFromObjects(new object[] { new Transform(new Vector2F(0, 0), 0f) });
            Sprite sprite = new Sprite(new Context(), "dino_assets.bmp", 0);
            object boxed = sprite;
            SizeField?.SetValue(boxed, new Vector2F(16, 16));
            sprite = (Sprite)boxed;

            typeof(Sprite).GetMethod("Render", BindingFlags.Public | BindingFlags.Instance)?.Invoke(boxed, new object[] { gameObject, new Vector2F(0, 0), new Vector2F(32, 32), 1f });

            Assert.Equal(3u, TextureField?.GetValue(boxed));
        }

        private static object Box(Sprite sprite)
        {
            object boxed = sprite;
            return boxed;
        }
    }
}