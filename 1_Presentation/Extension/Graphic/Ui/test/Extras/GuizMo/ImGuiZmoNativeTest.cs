// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiZmoNativeTest.cs
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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    ///     Provides contract tests for <see cref="ImGuiZmoNative" /> P/Invoke declarations.
    /// </summary>
    public class ImGuiZmoNativeTest
    {
        /// <summary>
        ///     Verifies the native wrapper type is static.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStaticClass()
        {
            Type type = typeof(ImGuiZmoNative);

            Assert.True(type.IsClass);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        ///     Verifies native library constant points to cimgui.
        /// </summary>
        [Fact]
        public void NativeLibraryConstant_ShouldBeCimgui()
        {
            FieldInfo field = typeof(ImGuiZmoNative).GetField("NativeLibrary", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(field);
            Assert.True(field.IsLiteral);
            Assert.Equal("cimgui", field.GetRawConstantValue() as string);
        }

        /// <summary>
        ///     Verifies all managed native bindings preserve expected entry points.
        /// </summary>
        [Fact]
        public void NativeMethods_ShouldKeepExpectedEntryPoints()
        {
            Dictionary<string, string> expectedEntryPoints = new Dictionary<string, string>
            {
                ["InternalAllowAxisFlip"] = "ImGuizmo_AllowAxisFlip",
                ["InternalBeginFrame"] = "ImGuizmo_BeginFrame",
                ["InternalDecomposeMatrixToComponents"] = "ImGuizmo_DecomposeMatrixToComponents",
                ["InternalDrawCubes"] = "ImGuizmo_DrawCubes",
                ["InternalDrawGrid"] = "ImGuizmo_DrawGrid",
                ["InternalEnable"] = "ImGuizmo_Enable",
                ["InternalIsOverNil"] = "ImGuizmo_IsOver_Nil",
                ["InternalIsOverOPERATION"] = "ImGuizmo_IsOverOPERATION",
                ["InternalIsUsing"] = "ImGuizmo_IsUsing",
                ["InternalManipulate"] = "ImGuizmo_Manipulate",
                ["InternalRecomposeMatrixFromComponents"] = "ImGuizmo_RecomposeMatrixFromComponents",
                ["InternalSetDrawlist"] = "ImGuizmo_SetDrawlist",
                ["InternalSetGizmoSizeClipSpace"] = "ImGuizmo_SetGizmoSizeClipSpace",
                ["InternalSetID"] = "ImGuizmo_SetID",
                ["InternalSetImGuiContext"] = "ImGuizmo_SetImGuiContext",
                ["InternalSetOrthographic"] = "ImGuizmo_SetOrthographic",
                ["InternalSetRect"] = "ImGuizmo_SetRect",
                ["ImGuizmo_ViewManipulate"] = "ImGuizmo_ViewManipulate_Float"
            };

            foreach (KeyValuePair<string, string> pair in expectedEntryPoints)
            {
                MethodInfo method = typeof(ImGuiZmoNative).GetMethod(pair.Key, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                Assert.NotNull(method);

                DllImportAttribute attribute = method.GetCustomAttribute<DllImportAttribute>();
                Assert.NotNull(attribute);
                Assert.Equal("cimgui", attribute.Value);
                Assert.Equal(pair.Value, attribute.EntryPoint);
                Assert.Equal(CallingConvention.Cdecl, attribute.CallingConvention);
            }
        }

        /// <summary>
        ///     Verifies that externally exposed native methods are the intended two APIs.
        /// </summary>
        [Fact]
        public void PublicNativeMethods_ShouldBeLimitedToPublicInteropSurface()
        {
            MethodInfo[] publicMethods = typeof(ImGuiZmoNative).GetMethods(BindingFlags.Public | BindingFlags.Static);

            Assert.Equal(2, publicMethods.Length);
            Assert.Contains(publicMethods, method => method.Name == "InternalSetRect");
            Assert.Contains(publicMethods, method => method.Name == "ImGuizmo_ViewManipulate");
        }
    }
}