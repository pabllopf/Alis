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
    /// <summary>
    /// The im guiz mo remaining coverage tests class
    /// </summary>
    public class ImGuizMoRemainingCoverageTests
    {
        /// <summary>
        /// Publics the api should expose decompose matrix to components
        /// </summary>
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeDecomposeMatrixToComponents()
        {
            AssertMethod("DecomposeMatrixToComponents", typeof(void), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType());
        }

        /// <summary>
        /// Publics the api should expose draw cubes
        /// </summary>
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeDrawCubes()
        {
            AssertMethod("DrawCubes", typeof(void), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int));
        }

        /// <summary>
        /// Publics the api should expose draw grid
        /// </summary>
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeDrawGrid()
        {
            AssertMethod("DrawGrid", typeof(void), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float));
        }

        /// <summary>
        /// Publics the api should expose enable
        /// </summary>
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeEnable()
        {
            AssertMethod("Enable", typeof(void), typeof(bool));
        }

        /// <summary>
        /// Publics the api should expose manipulate
        /// </summary>
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeManipulate()
        {
            MethodInfo method = typeof(ImGuizMo).GetMethod("Manipulate", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(float[]), typeof(float[]), typeof(Operations), typeof(Mode), typeof(float[]) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(byte), method.ReturnType);
            Assert.True(method.IsPublic);
            Assert.True(method.IsStatic);
        }

        /// <summary>
        /// Publics the api should expose recompose matrix from components
        /// </summary>
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeRecomposeMatrixFromComponents()
        {
            AssertMethod("RecomposeMatrixFromComponents", typeof(void), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType(), typeof(float[]).MakeByRefType());
        }

        /// <summary>
        /// Publics the api should expose view manipulate
        /// </summary>
        [RequireCImguiSystemFact]
        public void PublicApi_ShouldExposeViewManipulate()
        {
            AssertMethod("ViewManipulate", typeof(void), typeof(float[]).MakeByRefType(), typeof(float), typeof(Vector2F), typeof(Vector2F), typeof(uint));
        }

        /// <summary>
        /// Statics the fields camera projection should have expected values
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_CameraProjection_ShouldHaveExpectedValues()
        {
            float[] values = GetPrivateArray("cameraProjection");

            Assert.Equal(2.0f / 800.0f, values[0], 5);
            Assert.Equal(0.0f, values[1], 5);
            Assert.Equal(0.0f, values[2], 5);
            Assert.Equal(0.0f, values[3], 5);
            Assert.Equal(0.0f, values[4], 5);
            Assert.Equal(2.0f / 600.0f, values[5], 5);
            Assert.Equal(0.0f, values[6], 5);
            Assert.Equal(0.0f, values[7], 5);
            Assert.Equal(0.0f, values[8], 5);
            Assert.Equal(0.0f, values[9], 5);
            Assert.Equal(-1.0f, values[10], 5);
            Assert.Equal(0.0f, values[11], 5);
            Assert.Equal(-1.0f, values[12], 5);
            Assert.Equal(-1.0f, values[13], 5);
            Assert.Equal(0.0f, values[14], 5);
            Assert.Equal(1.0f, values[15], 5);
        }

        /// <summary>
        /// Statics the fields matrix should have expected values
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_Matrix_ShouldHaveExpectedValues()
        {
            float[] values = GetPrivateArray("matrix");

            Assert.Equal(1.0f, values[0], 5);
            Assert.Equal(1.0f, values[5], 5);
            Assert.Equal(1.0f, values[10], 5);
            Assert.Equal(2.0f, values[14], 5);
            Assert.Equal(1.0f, values[15], 5);
        }

        /// <summary>
        /// Statics the fields matrix rotation should be zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_MatrixRotation_ShouldBeZero()
        {
            float[] values = GetPrivateArray("matrixRotation");
            Assert.Equal(0.0f, values[0], 5);
            Assert.Equal(0.0f, values[1], 5);
            Assert.Equal(0.0f, values[2], 5);
        }

        /// <summary>
        /// Statics the fields matrix scale should be zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_MatrixScale_ShouldBeZero()
        {
            float[] values = GetPrivateArray("matrixScale");
            Assert.Equal(0.0f, values[0], 5);
            Assert.Equal(0.0f, values[1], 5);
            Assert.Equal(0.0f, values[2], 5);
        }

        /// <summary>
        /// Statics the fields matrix translation should be zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_MatrixTranslation_ShouldBeZero()
        {
            float[] values = GetPrivateArray("matrixTranslation");
            Assert.Equal(0.0f, values[0], 5);
            Assert.Equal(0.0f, values[1], 5);
            Assert.Equal(0.0f, values[2], 5);
        }

        /// <summary>
        /// Statics the fields vector 3 rotation should be zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_Vector3Rotation_ShouldBeZero()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("rotation", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            Vector3F value = (Vector3F)field.GetValue(null);
            Assert.Equal(0.0f, value.X, 5);
            Assert.Equal(0.0f, value.Y, 5);
            Assert.Equal(0.0f, value.Z, 5);
        }

        /// <summary>
        /// Statics the fields vector 3 scale should be zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_Vector3Scale_ShouldBeZero()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("scale", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            Vector3F value = (Vector3F)field.GetValue(null);
            Assert.Equal(0.0f, value.X, 5);
            Assert.Equal(0.0f, value.Y, 5);
            Assert.Equal(0.0f, value.Z, 5);
        }

        /// <summary>
        /// Statics the fields vector 3 translation should be zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_Vector3Translation_ShouldBeZero()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("translation", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            Vector3F value = (Vector3F)field.GetValue(null);
            Assert.Equal(0.0f, value.X, 5);
            Assert.Equal(0.0f, value.Y, 5);
            Assert.Equal(0.0f, value.Z, 5);
        }

        /// <summary>
        /// Statics the fields is open should be false
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_IsOpen_ShouldBeFalse()
        {
            FieldInfo field = typeof(ImGuizMo).GetField("isOpen", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            bool value = (bool)field.GetValue(null);
            Assert.False(value);
        }

        /// <summary>
        /// Statics the fields camera projection length should be 16
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_CameraProjection_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("cameraProjection").Length);
        }

        /// <summary>
        /// Statics the fields camera view length should be 16
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_CameraView_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("cameraView").Length);
        }

        /// <summary>
        /// Statics the fields identity matrix length should be 16
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_IdentityMatrix_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("identityMatrix").Length);
        }

        /// <summary>
        /// Statics the fields matrix length should be 16
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_Matrix_Length_ShouldBe16()
        {
            Assert.Equal(16, GetPrivateArray("matrix").Length);
        }

        /// <summary>
        /// Statics the fields matrix rotation length should be 3
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_MatrixRotation_Length_ShouldBe3()
        {
            Assert.Equal(3, GetPrivateArray("matrixRotation").Length);
        }

        /// <summary>
        /// Statics the fields matrix scale length should be 3
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_MatrixScale_Length_ShouldBe3()
        {
            Assert.Equal(3, GetPrivateArray("matrixScale").Length);
        }

        /// <summary>
        /// Statics the fields matrix translation length should be 3
        /// </summary>
        [RequireCImguiSystemFact]
        public void StaticFields_MatrixTranslation_Length_ShouldBe3()
        {
            Assert.Equal(3, GetPrivateArray("matrixTranslation").Length);
        }

        /// <summary>
        /// Canonicals the matrices camera view should have ones on diagonal
        /// </summary>
        [RequireCImguiSystemFact]
        public void CanonicalMatrices_CameraView_ShouldHaveOnesOnDiagonal()
        {
            float[] values = GetPrivateArray("cameraView");
            Assert.Equal(1.0f, values[0], 5);
            Assert.Equal(1.0f, values[5], 5);
            Assert.Equal(1.0f, values[10], 5);
            Assert.Equal(1.0f, values[15], 5);
        }

        /// <summary>
        /// Canonicals the matrices identity matrix should have ones on diagonal
        /// </summary>
        [RequireCImguiSystemFact]
        public void CanonicalMatrices_IdentityMatrix_ShouldHaveOnesOnDiagonal()
        {
            float[] values = GetPrivateArray("identityMatrix");
            Assert.Equal(1.0f, values[0], 5);
            Assert.Equal(1.0f, values[5], 5);
            Assert.Equal(1.0f, values[10], 5);
            Assert.Equal(1.0f, values[15], 5);
        }

        /// <summary>
        /// Gets the private array using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The value</returns>
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
        /// Asserts the method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="returnType">The return type</param>
        /// <param name="parameterTypes">The parameter types</param>
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
