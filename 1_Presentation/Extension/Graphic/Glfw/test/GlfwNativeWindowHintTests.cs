// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeWindowHintTests.cs
// 
//  Author:GitHub Copilot
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

using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for GlfwNative WindowHint methods
    /// </summary>
    public class GlfwNativeWindowHintTests
    {
        [RequiresDisplay]
        public void WindowHint_WithResizable_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Resizable, true);
        }

        [RequiresDisplay]
        public void WindowHint_WithVisible_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Visible, false);
        }

        [RequiresDisplay]
        public void WindowHint_WithDecorated_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Decorated, true);
        }

        [RequiresDisplay]
        public void WindowHint_WithFocused_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Focused, true);
        }

        [RequiresDisplay]
        public void WindowHint_WithAutoIconify_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.AutoIconify, true);
        }

        [RequiresDisplay]
        public void WindowHint_WithFloating_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Floating, false);
        }

        [RequiresDisplay]
        public void WindowHint_WithMaximized_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Maximized, false);
        }

        [RequiresDisplay]
        public void WindowHint_WithRedBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.RedBits, 8);
        }

        [RequiresDisplay]
        public void WindowHint_WithGreenBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.GreenBits, 8);
        }

        [RequiresDisplay]
        public void WindowHint_WithBlueBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.BlueBits, 8);
        }

        [RequiresDisplay]
        public void WindowHint_WithAlphaBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.AlphaBits, 8);
        }

        [RequiresDisplay]
        public void WindowHint_WithDepthBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.DepthBits, 24);
        }

        [RequiresDisplay]
        public void WindowHint_WithStencilBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.StencilBits, 8);
        }

        [RequiresDisplay]
        public void WindowHint_WithSamples_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Samples, 4);
        }

        [RequiresDisplay]
        public void WindowHint_WithRefreshRate_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.RefreshRate, 60);
        }

        [RequiresDisplay]
        public void WindowHint_WithClientApi_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.ClientApi, (int)ClientApi.OpenGl);
        }

        [RequiresDisplay]
        public void WindowHint_WithContextVersionMajor_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.ContextVersionMajor, 3);
        }

        [RequiresDisplay]
        public void WindowHint_WithContextVersionMinor_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.ContextVersionMinor, 3);
        }

        [RequiresDisplay]
        public void WindowHint_WithOpenGLProfile_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.OpenglProfile, (int)GlfwProfile.Core);
        }

        [RequiresDisplay]
        public void WindowHint_WithOpenGLForwardCompat_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.OpenglForwardCompatible, true);
        }

        [RequiresDisplay]
        public void WindowHint_WithSrgbCapable_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.SrgbCapable, true);
        }

        [RequiresDisplay]
        public void WindowHint_WithDoubleBuffer_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Doublebuffer, true);
        }

        [RequiresDisplay]
        public void WindowHintString_WithX11ClassName_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHintString(Hint.X11ClassName, System.Text.Encoding.UTF8.GetBytes("TestClass"));
        }

        [RequiresDisplay]
        public void DefaultWindowHints_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.DefaultWindowHints();
        }
    }
}

