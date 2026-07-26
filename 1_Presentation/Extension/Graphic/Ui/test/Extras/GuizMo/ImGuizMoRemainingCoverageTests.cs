// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMoRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    public class ImGuizMoRemainingCoverageTests
    {
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeDecomposeMatrixToComponents()
        {
            AssertMethod("DecomposeMatrixToComponents", typeof(void), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType());
        }

        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeDrawCubes()
        {
            AssertMethod("DrawCubes", typeof(void), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int));
        }

        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeDrawGrid()
        {
            AssertMethod("DrawGrid", typeof(void), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float));
        }

        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeEnable()
        {
            AssertMethod("Enable", typeof(void), typeof(bool));
        }

        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeManipulate()
        {
            MethodInfo method = typeof(ImGuizMo).GetMethod("Manipulate", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(float[]), typeof(float[]), typeof(Operations), typeof(Mode), typeof(float[]) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(byte), method.ReturnType);
            Assert.True(method.IsPublic);
            Assert.True(method.IsStatic);
        }

        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeRecomposeMatrixFromComponents()
        {
            AssertMethod("RecomposeMatrixFromComponents", typeof(void), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType());
        }

        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeViewManipulate()
        {
            AssertMethod("ViewManipulate", typeof(void), typeof(float[]).MakeByRefType(), typeof(float), typeof(Vector2F), typeof(Vector2F), typeof(uint));
        }

        [RequireCImguiSystemFact]
        public void StaticFields_CameraProjection_ShouldHaveExpectedValues()
        {
            float[] values = GetPrivateArray("cameraProjection");

            Assert.Equal(2.0f / 800.0f, values[0]);
            Assert.Equal(0.0f, values[1]);
            Assert.Equal(0.0f, values[2]);
            Assert.Equal(0.0f, values[3]);
            Assert.Equal(0.0f, values[4]);
            Assert.Equal(2.0f / 600.0f, values[5]);
            Assert.Equal(0.0f, values[6]);
            Assert.Equal(0.0f, values[7]);
            Assert.Equal(0.0f, values[8]);
            Assert.Equal(0.0f, values[9]);
            Assert.Equal(-1.0f, values[10]);
            Assert.Equal(0.0f, values[11]);
            Assert.Equal(-1.0f, values[12]);
            Assert.Equal(-1.0f, values[13]);
            Assert.Equal(0.0f, values[14]);
            Assert.Equal(1.0f, values[15]);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_Matrix_ShouldHaveExpectedValues()
        {
            float[] values = GetPrivateArray("matrix");

            Assert.Equal(1.0f, values[0]);
            Assert.Equal(1.0f, values[5]);
            Assert.Equal(1.0f, values[10]);
            Assert.Equal(2.0f, values[14]);
            Assert.Equal(1.0f, values[15]);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_MatrixRotation_ShouldBeZero()
        {
            float[] values = GetPrivateArray("matrixRotation");
            Assert.Equal(0.0f, values[0]);
            Assert.Equal(0.0f, values[1]);
            Assert.Equal(0.0f, values[2]);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_MatrixScale_ShouldBeZero()
        {
            float[] values = GetPrivateArray("matrixScale");
            Assert.Equal(0.0f, values[0]);
            Assert.Equal(0.0f, values[1]);
            Assert.Equal(0.0f, values[2]);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_MatrixTranslation_ShouldBeZero()
        {
            float[] values = GetPrivateArray("matrixTranslation");
            Assert.Equal(0.0f, values[0]);
            Assert.Equal(0.0f, values[1]);
            Assert.Equal(0.0f, values[2]);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_Vector3Rotation_ShouldBeZero()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("rotation", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            Vector3F value = (Vector3F)field.GetValue(null);
            Assert.Equal(0.0f, value.X);
            Assert.Equal(0.0f, value.Y);
            Assert.Equal(0.0f, value.Z);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_Vector3Scale_ShouldBeZero()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("scale", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            Vector3F value = (Vector3F)field.GetValue(null);
            Assert.Equal(0.0f, value.X);
            Assert.Equal(0.0f, value.Y);
            Assert.Equal(0.0f, value.Z);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_Vector3Translation_ShouldBeZero()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("translation", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            Vector3F value = (Vector3F)field.GetValue(null);
            Assert.Equal(0.0f, value.X);
            Assert.Equal(0.0f, value.Y);
            Assert.Equal(0.0f, value.Z);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_IsOpen_ShouldBeFalse()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("isOpen", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            bool value = (bool)field.GetValue(null);
            Assert.False(value);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_CameraProjection_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("cameraProjection").Length);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_CameraView_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("cameraView").Length);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_IdentityMatrix_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("identityMatrix").Length);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_Matrix_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("matrix").Length);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_MatrixRotation_Length_ShouldBe3()
        {
            Assert.Equal(3, GetPrivateArray("matrixRotation").Length);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_MatrixScale_Length_ShouldBe3()
        {
            Assert.Equal(3, GetPrivateArray("matrixScale").Length);
        }

        [RequireCImguiSystemFact]
        public void StaticFields_MatrixTranslation_Length_ShouldBe3()
        {
            Assert.Equal(3, GetPrivateArray("matrixTranslation").Length);
        }

        [RequireCImguiSystemFact]
        public void CanonicalMatrices_CameraView_ShouldHaveOnesOnDiagonal()
        {
            float[] values = GetPrivateArray("cameraView");
            Assert.Equal(1.0f, values[0]);
            Assert.Equal(1.0f, values[5]);
            Assert.Equal(1.0f, values[10]);
            Assert.Equal(1.0f, values[15]);
        }

        [RequireCImguiSystemFact]
        public void CanonicalMatrices_IdentityMatrix_ShouldHaveOnesOnDiagonal()
        {
            float[] values = GetPrivateArray("identityMatrix");
            Assert.Equal(1.0f, values[0]);
            Assert.Equal(1.0f, values[5]);
            Assert.Equal(1.0f, values[10]);
            Assert.Equal(1.0f, values[15]);
        }

        private static float[] GetPrivateArray(string name)
        {
            FieldInfo field = typeof(ImGuizMo).GetField(name, BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            Assert.Equal(typeof(float[]), field.FieldType);
            float[] value = field.GetValue(null) as float[];
            Assert.NotNull(value);
            return value;
        }

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
