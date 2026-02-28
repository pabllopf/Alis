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
        /// <summary>
        /// Windows the hint with resizable does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithResizable_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Resizable, true);
        }

        /// <summary>
        /// Windows the hint with visible does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithVisible_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Visible, false);
        }

        /// <summary>
        /// Windows the hint with decorated does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithDecorated_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Decorated, true);
        }

        /// <summary>
        /// Windows the hint with focused does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithFocused_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Focused, true);
        }

        /// <summary>
        /// Windows the hint with auto iconify does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithAutoIconify_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.AutoIconify, true);
        }

        /// <summary>
        /// Windows the hint with floating does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithFloating_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Floating, false);
        }

        /// <summary>
        /// Windows the hint with maximized does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithMaximized_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Maximized, false);
        }

        /// <summary>
        /// Windows the hint with red bits does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithRedBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.RedBits, 8);
        }

        /// <summary>
        /// Windows the hint with green bits does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithGreenBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.GreenBits, 8);
        }

        /// <summary>
        /// Windows the hint with blue bits does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithBlueBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.BlueBits, 8);
        }

        /// <summary>
        /// Windows the hint with alpha bits does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithAlphaBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.AlphaBits, 8);
        }

        /// <summary>
        /// Windows the hint with depth bits does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithDepthBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.DepthBits, 24);
        }

        /// <summary>
        /// Windows the hint with stencil bits does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithStencilBits_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.StencilBits, 8);
        }

        /// <summary>
        /// Windows the hint with samples does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithSamples_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Samples, 4);
        }

        /// <summary>
        /// Windows the hint with refresh rate does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithRefreshRate_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.RefreshRate, 60);
        }

        /// <summary>
        /// Windows the hint with client api does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithClientApi_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.ClientApi, (int)ClientApi.OpenGl);
        }

        /// <summary>
        /// Windows the hint with context version major does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithContextVersionMajor_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.ContextVersionMajor, 3);
        }

        /// <summary>
        /// Windows the hint with context version minor does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithContextVersionMinor_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.ContextVersionMinor, 3);
        }

        /// <summary>
        /// Windows the hint with open gl profile does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithOpenGLProfile_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.OpenglProfile, (int)GlfwProfile.Core);
        }

        /// <summary>
        /// Windows the hint with open gl forward compat does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithOpenGLForwardCompat_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.OpenglForwardCompatible, true);
        }

        /// <summary>
        /// Windows the hint with srgb capable does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithSrgbCapable_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.SrgbCapable, true);
        }

        /// <summary>
        /// Windows the hint with double buffer does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHint_WithDoubleBuffer_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Doublebuffer, true);
        }

        /// <summary>
        /// Windows the hint string with x 11 class name does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHintString_WithX11ClassName_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHintString(Hint.X11ClassName, System.Text.Encoding.UTF8.GetBytes("TestClass"));
        }

        /// <summary>
        /// Defaults the window hints does not throw
        /// </summary>
        [RequiresDisplay]
        public void DefaultWindowHints_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.DefaultWindowHints();
        }
    }
}

