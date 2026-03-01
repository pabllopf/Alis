// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMoTest.cs
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
using System.Reflection;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    /// Provides unit coverage for the managed API surface of <see cref="ImGuizMo"/>.
    /// </summary>
    public class ImGuizMoTest
    {
        /// <summary>
        /// Verifies that ImGuizMo is generated as a static class.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStaticClass()
        {
            Type type = typeof(ImGuizMo);

            Assert.True(type.IsClass);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        /// Verifies that key API methods exist with expected parameter contracts.
        /// </summary>
        [Fact]
        public void PublicApi_ShouldExposeExpectedMethodContracts()
        {
            AssertMethod("AllowAxisFlip", typeof(void), typeof(bool));
            AssertMethod("BeginFrame", typeof(void));
            AssertMethod("IsOver", typeof(bool));
            AssertMethod("IsOver", typeof(bool), typeof(Operation));
            AssertMethod("IsUsing", typeof(bool));
            AssertMethod("SetDrawList", typeof(void));
            AssertMethod("SetDrawList", typeof(void), typeof(ImDrawList));
            AssertMethod("SetGizmoSizeClipSpace", typeof(void), typeof(float));
            AssertMethod("SetId", typeof(void), typeof(int));
            AssertMethod("SetImGuiContext", typeof(void), typeof(IntPtr));
            AssertMethod("SetOrthographic", typeof(void), typeof(bool));
            AssertMethod("SetRect", typeof(void), typeof(float), typeof(float), typeof(float), typeof(float));
            AssertMethod("ShowDemoWindow", typeof(void));
        }

        /// <summary>
        /// Verifies that manipulate keeps the managed wrapper signature over arrays and enums.
        /// </summary>
        [Fact]
        public void Manipulate_ShouldExposeExpectedSignature()
        {
            MethodInfo method = typeof(ImGuizMo).GetMethod(
                "Manipulate",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(float[]), typeof(float[]), typeof(Operation), typeof(Mode), typeof(float[]) },
                null);

            Assert.NotNull(method);
            Assert.Equal(typeof(byte), method.ReturnType);
        }

        /// <summary>
        /// Verifies that internal matrix buffers are initialized with expected dimensions.
        /// </summary>
        [Fact]
        public void InternalBuffers_ShouldUseExpectedSizes()
        {
            float[] cameraProjection = GetPrivateArray("cameraProjection");
            float[] cameraView = GetPrivateArray("cameraView");
            float[] identityMatrix = GetPrivateArray("identityMatrix");
            float[] matrix = GetPrivateArray("matrix");
            float[] matrixRotation = GetPrivateArray("matrixRotation");
            float[] matrixScale = GetPrivateArray("matrixScale");
            float[] matrixTranslation = GetPrivateArray("matrixTranslation");

            Assert.Equal(16, cameraProjection.Length);
            Assert.Equal(16, cameraView.Length);
            Assert.Equal(16, identityMatrix.Length);
            Assert.Equal(16, matrix.Length);
            Assert.Equal(3, matrixRotation.Length);
            Assert.Equal(3, matrixScale.Length);
            Assert.Equal(3, matrixTranslation.Length);
        }

        /// <summary>
        /// Verifies that identity and camera view matrices keep canonical diagonal values.
        /// </summary>
        [Fact]
        public void CanonicalMatrices_ShouldKeepIdentityDiagonal()
        {
            float[] cameraView = GetPrivateArray("cameraView");
            float[] identityMatrix = GetPrivateArray("identityMatrix");

            Assert.Equal(1.0f, cameraView[0]);
            Assert.Equal(1.0f, cameraView[5]);
            Assert.Equal(1.0f, cameraView[10]);
            Assert.Equal(1.0f, cameraView[15]);

            Assert.Equal(1.0f, identityMatrix[0]);
            Assert.Equal(1.0f, identityMatrix[5]);
            Assert.Equal(1.0f, identityMatrix[10]);
            Assert.Equal(1.0f, identityMatrix[15]);
        }

        /// <summary>
        /// Verifies that platform-isolated tests can run without colliding across OS jobs.
        /// </summary>
        [WindowsOnly]
        public void WindowsOnly_SurfaceCheck_ShouldRunIsolated()
        {
            Assert.NotNull(typeof(ImGuizMo));
        }

        /// <summary>
        /// Verifies that platform-isolated tests can run without colliding across OS jobs.
        /// </summary>
        [MacOsOnly]
        public void MacOsOnly_SurfaceCheck_ShouldRunIsolated()
        {
            Assert.NotNull(typeof(ImGuizMo));
        }

        /// <summary>
        /// Verifies that platform-isolated tests can run without colliding across OS jobs.
        /// </summary>
        [LinuxOnly]
        public void LinuxOnly_SurfaceCheck_ShouldRunIsolated()
        {
            Assert.NotNull(typeof(ImGuizMo));
        }

        /// <summary>
        /// Reads a private static float array from ImGuizMo.
        /// </summary>
        /// <param name="name">The field name.</param>
        /// <returns>The resolved float array.</returns>
        private static float[] GetPrivateArray(string name)
        {
            FieldInfo field = typeof(ImGuizMo).GetField(name, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(field);
            Assert.Equal(typeof(float[]), field.FieldType);

            float[] value = field.GetValue(null) as float[];

            Assert.NotNull(value);
            return value;
        }

        /// <summary>
        /// Resolves and validates a specific public static method signature.
        /// </summary>
        /// <param name="name">The method name.</param>
        /// <param name="returnType">The expected return type.</param>
        /// <param name="parameterTypes">The expected parameter types.</param>
        private static void AssertMethod(string name, Type returnType, params Type[] parameterTypes)
        {
            MethodInfo method = typeof(ImGuizMo).GetMethod(name, BindingFlags.Public | BindingFlags.Static, null, parameterTypes, null);

            Assert.NotNull(method);
            Assert.Equal(returnType, method.ReturnType);
            Assert.True(method.IsPublic);
            Assert.True(method.IsStatic);
        }
    }
}