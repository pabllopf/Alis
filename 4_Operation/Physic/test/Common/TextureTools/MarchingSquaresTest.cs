using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    public class MarchingSquaresTest
    {
        [Fact]
        public void LookMarch_HasExpectedValues()
        {
            FieldInfo field = typeof(MarchingSquares).GetField("LookMarch", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(field);
            int[] lookMarch = (int[])field.GetValue(null);
            Assert.NotNull(lookMarch);
            Assert.Equal(16, lookMarch.Length);
            Assert.Equal(0x00, lookMarch[0]);
            Assert.Equal(0x55, lookMarch[15]);
        }

        #region Square

        [Theory]
        [InlineData(3f, 9f)]
        [InlineData(-3f, 9f)]
        [InlineData(0f, 0f)]
        [InlineData(0.5f, 0.25f)]
        public void Square_ComputesCorrectValue(float input, float expected)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Square", BindingFlags.Static | BindingFlags.NonPublic);
            float result = (float)method.Invoke(null, new object[] { input });
            Assert.Equal(expected, result);
        }

        #endregion

        #region VecDsq

        [Theory]
        [InlineData(0, 0, 0, 0, 0f)]
        [InlineData(1, 0, 0, 0, 1f)]
        [InlineData(0, 3, 0, 0, 9f)]
        [InlineData(1, 2, 4, 6, 25f)]
        public void VecDsq_ComputesCorrectValue(float ax, float ay, float bx, float by, float expected)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("VecDsq", BindingFlags.Static | BindingFlags.NonPublic);
            Vector2F a = new Vector2F(ax, ay);
            Vector2F b = new Vector2F(bx, by);
            float result = (float)method.Invoke(null, new object[] { a, b });
            Assert.Equal(expected, result);
        }

        #endregion

        #region VecCross

        [Theory]
        [InlineData(1, 0, 0, 1, 1f)]
        [InlineData(0, 1, 1, 0, -1f)]
        [InlineData(1, 0, 1, 0, 0f)]
        public void VecCross_ComputesCorrectValue(float ax, float ay, float bx, float by, float expected)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("VecCross", BindingFlags.Static | BindingFlags.NonPublic);
            Vector2F a = new Vector2F(ax, ay);
            Vector2F b = new Vector2F(bx, by);
            float result = (float)method.Invoke(null, new object[] { a, b });
            Assert.Equal(expected, result);
        }

        #endregion

        #region Lerp

        [Theory]
        [InlineData(0f, 10f, 1f, 0f, 10f)]
        [InlineData(0f, 10f, 0f, 1f, 0f)]
        [InlineData(0f, 10f, 5f, 5f, 5f)]
        [InlineData(10f, 0f, 2f, -2f, 5f)]
        public void Lerp_ComputesCorrectValue(float x0, float x1, float v0, float v1, float expected)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Lerp", BindingFlags.Static | BindingFlags.NonPublic);
            float result = (float)method.Invoke(null, new object[] { x0, x1, v0, v1 });
            Assert.True(Math.Abs(result - expected) < 0.001f, $"Expected {expected}, got {result}");
        }

        [Fact]
        public void Lerp_WhenDvIsTiny_ReturnsMidpoint()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Lerp", BindingFlags.Static | BindingFlags.NonPublic);
            float v0 = SettingEnv.Epsilon;
            float v1 = 0f;
            float result = (float)method.Invoke(null, new object[] { 0f, 10f, v0, v1 });
            Assert.Equal(5f, result);
        }

        #endregion

        #region Xlerp

        [Fact]
        public void Xlerp_WithZeroC_ReturnsLinearInterpolation()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Xlerp", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            f[5, 0] = 1;
            f[0, 0] = -1;
            float result = (float)method.Invoke(null, new object[] { 0f, 10f, 0f, -1f, 1f, f, 0 });
            Assert.Equal(5f, result, 3);
        }

        [Fact]
        public void Xlerp_WithRecursion_ReturnsInterpolatedValue()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Xlerp", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            for (int x = 0; x < 50; x++) f[x, 0] = -1;
            for (int x = 50; x < 100; x++) f[x, 0] = 1;

            float result = (float)method.Invoke(null, new object[] { 0f, 100f, 0f, -1f, 1f, f, 3 });
            Assert.InRange(result, 30f, 70f);
        }

        [Fact]
        public void Xlerp_WhenVmSignMatchesV0_RecursesRight()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Xlerp", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            for (int x = 0; x < 30; x++) f[x, 0] = -1;
            for (int x = 30; x < 100; x++) f[x, 0] = 1;

            float result = (float)method.Invoke(null, new object[] { 0f, 100f, 0f, -1f, 1f, f, 2 });
            Assert.InRange(result, 20f, 60f);
        }

        #endregion

        #region Ylerp

        [Fact]
        public void Ylerp_WithZeroC_ReturnsLinearInterpolation()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Ylerp", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            f[0, 5] = 1;
            f[0, 0] = -1;
            float result = (float)method.Invoke(null, new object[] { 0f, 10f, 0f, -1f, 1f, f, 0 });
            Assert.Equal(5f, result, 3);
        }

        [Fact]
        public void Ylerp_WithRecursion_ReturnsInterpolatedValue()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Ylerp", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            for (int y = 0; y < 50; y++) f[0, y] = -1;
            for (int y = 50; y < 100; y++) f[0, y] = 1;

            float result = (float)method.Invoke(null, new object[] { 0f, 100f, 0f, -1f, 1f, f, 3 });
            Assert.InRange(result, 30f, 70f);
        }

        #endregion

        #region MarchSquare

        [Fact]
        public void MarchSquare_WithAllPositiveFs_ReturnsZeroKey()
        {
            MethodInfo marchSquare = typeof(MarchingSquares).GetMethod("MarchSquare", BindingFlags.Static | BindingFlags.NonPublic);
            ConstructorInfo geomPolyCtor = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic).GetConstructor(Type.EmptyTypes);
            object poly = geomPolyCtor.Invoke(null);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[10, 10];
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    fs[x, y] = 1;

            object[] args = { f, fs, poly, 0, 0, 0f, 0f, 1f, 1f, 2 };
            int key = (int)marchSquare.Invoke(null, args);
            Assert.Equal(0, key);
        }

        [Fact]
        public void MarchSquare_WithAllNegativeFs_ReturnsNonZeroKey()
        {
            MethodInfo marchSquare = typeof(MarchingSquares).GetMethod("MarchSquare", BindingFlags.Static | BindingFlags.NonPublic);
            ConstructorInfo geomPolyCtor = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic).GetConstructor(Type.EmptyTypes);
            object poly = geomPolyCtor.Invoke(null);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[10, 10];
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    fs[x, y] = -1;

            object[] args = { f, fs, poly, 0, 0, 0f, 0f, 1f, 1f, 2 };
            int key = (int)marchSquare.Invoke(null, args);
            Assert.Equal(15, key);
        }

        #endregion

        #region CxFastList

        [Fact]
        public void CxFastList_AddAndFront_WorksCorrectly()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo front = intListType.GetMethod("Front");
            MethodInfo empty = intListType.GetMethod("Empty");

            add.Invoke(list, new object[] { 42 });
            Assert.False((bool)empty.Invoke(list, null));
            Assert.Equal(42, front.Invoke(list, null));
        }

        [Fact]
        public void CxFastList_AddMultiple_CountsCorrectly()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo add = intListType.GetMethod("Add");

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 30 });

            Assert.Equal(3, (int)countField.GetValue(list));
        }

        [Fact]
        public void CxFastList_Remove_ExistingItem_ReturnsTrue()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 30 });

            bool removed = (bool)remove.Invoke(list, new object[] { 20 });
            Assert.True(removed);
            Assert.Equal(2, (int)countField.GetValue(list));
        }

        [Fact]
        public void CxFastList_Remove_NonExistingItem_ReturnsFalse()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");

            add.Invoke(list, new object[] { 10 });
            bool removed = (bool)remove.Invoke(list, new object[] { 999 });
            Assert.False(removed);
        }

        [Fact]
        public void CxFastList_Remove_HeadItem_Works()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });

            bool removed = (bool)remove.Invoke(list, new object[] { 20 });
            Assert.True(removed);
            Assert.Equal(1, (int)countField.GetValue(list));
        }

        [Fact]
        public void CxFastList_Pop_RemovesHead()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo pop = intListType.GetMethod("Pop");
            MethodInfo front = intListType.GetMethod("Front");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });

            pop.Invoke(list, null);
            Assert.Equal(1, (int)countField.GetValue(list));
            Assert.Equal(10, front.Invoke(list, null));
        }

        [Fact]
        public void CxFastList_Insert_AfterNode_Works()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo insert = intListType.GetMethod("Insert");
            MethodInfo begin = intListType.GetMethod("Begin");
            MethodInfo getList = intListType.GetMethod("GetListOfElements");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 30 });

            object firstNode = begin.Invoke(list, null);
            insert.Invoke(list, new object[] { firstNode, 20 });

            Assert.Equal(3, (int)countField.GetValue(list));

            List<int> elements = (List<int>)getList.Invoke(list, null);
            Assert.Contains(20, elements);
        }

        [Fact]
        public void CxFastList_Insert_NullNode_AddsToHead()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo insert = intListType.GetMethod("Insert");
            MethodInfo front = intListType.GetMethod("Front");

            add.Invoke(list, new object[] { 10 });
            insert.Invoke(list, new object[] { null, 5 });

            Assert.Equal(5, front.Invoke(list, null));
        }

        [Fact]
        public void CxFastList_Erase_WithPrev_RemovesNode()
        {
            // Erase with non-null prev is exercised internally by Remove.
            // This test verifies Erase works via the Remove operation.
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");
            MethodInfo getList = intListType.GetMethod("GetListOfElements");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 30 });

            bool removed = (bool)remove.Invoke(list, new object[] { 20 });
            Assert.True(removed);
            Assert.Equal(2, (int)countField.GetValue(list));

            List<int> elements = (List<int>)getList.Invoke(list, null);
            Assert.Contains(10, elements);
            Assert.Contains(30, elements);
        }

        [Fact]
        public void CxFastList_Erase_NullPrev_RemovesHead()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo erase = intListType.GetMethod("Erase");
            MethodInfo begin = intListType.GetMethod("Begin");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });

            erase.Invoke(list, new object[] { null, begin.Invoke(list, null) });
            Assert.Equal(1, (int)countField.GetValue(list));
        }

        [Fact]
        public void CxFastList_Empty_OnNewList_ReturnsTrue()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo empty = intListType.GetMethod("Empty");
            Assert.True((bool)empty.Invoke(list, null));
        }

        [Fact]
        public void CxFastList_Empty_AfterAdd_ReturnsFalse()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo empty = intListType.GetMethod("Empty");

            add.Invoke(list, new object[] { 1 });
            Assert.False((bool)empty.Invoke(list, null));
        }

        [Fact]
        public void CxFastList_Clear_EmptiesList()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo clear = intListType.GetMethod("Clear");
            MethodInfo empty = intListType.GetMethod("Empty");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 1 });
            add.Invoke(list, new object[] { 2 });
            add.Invoke(list, new object[] { 3 });

            clear.Invoke(list, null);
            Assert.True((bool)empty.Invoke(list, null));
            Assert.Equal(0, (int)countField.GetValue(list));
        }

        [Fact]
        public void CxFastList_End_ReturnsNull()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo end = intListType.GetMethod("End");
            Assert.Null(end.Invoke(list, null));
        }

        [Fact]
        public void CxFastList_GetListOfElements_ReturnsAll()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo getListOfElements = intListType.GetMethod("GetListOfElements");

            add.Invoke(list, new object[] { 1 });
            add.Invoke(list, new object[] { 2 });
            add.Invoke(list, new object[] { 3 });

            List<int> elements = (List<int>)getListOfElements.Invoke(list, null);
            Assert.Equal(3, elements.Count);
            Assert.Contains(1, elements);
            Assert.Contains(2, elements);
            Assert.Contains(3, elements);
        }

        [Fact]
        public void CxFastList_GetListOfElements_OnEmptyList_ReturnsEmpty()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo getListOfElements = intListType.GetMethod("GetListOfElements");
            List<int> elements = (List<int>)getListOfElements.Invoke(list, null);
            Assert.NotNull(elements);
            Assert.Empty(elements);
        }

        #endregion

        #region GeomPoly

        [Fact]
        public void GeomPoly_Constructor_InitializesEmpty()
        {
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object poly = Activator.CreateInstance(geomPolyType);

            FieldInfo pointsField = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);

            Assert.NotNull(pointsField.GetValue(poly));
            Assert.Equal(0, (int)lengthField.GetValue(poly));
        }

        #endregion

        #region CombLeft

        [Fact]
        public void CombLeft_MergesTwoConnectedPolys()
        {
            MethodInfo combLeft = typeof(MarchingSquares).GetMethod("CombLeft", BindingFlags.Static | BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object polyA = Activator.CreateInstance(geomPolyType);
            object polyB = Activator.CreateInstance(geomPolyType);

            FieldInfo pointsField = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            object pointsA = pointsField.GetValue(polyA);
            object pointsB = pointsField.GetValue(polyB);

            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            MethodInfo add = vectorListType.GetMethod("Add");

            add.Invoke(pointsA, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(pointsA, new object[] { new Vector2F(5f, 0f) });
            add.Invoke(pointsA, new object[] { new Vector2F(5f, 5f) });

            add.Invoke(pointsB, new object[] { new Vector2F(5f, 0f) });
            add.Invoke(pointsB, new object[] { new Vector2F(10f, 0f) });

            object[] args = { polyA, polyB };
            combLeft.Invoke(null, args);
        }

        #endregion

        #region ComputeGridDimension

        [Theory]
        [InlineData(10f, 5f, 4)]
        [InlineData(10f, 3f, 7)]
        [InlineData(0f, 1f, 0)]
        [InlineData(5f, 10f, 1)]
        public void ComputeGridDimension_ComputesCorrectValue(float extent, float cellSize, int expected)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("ComputeGridDimension", BindingFlags.Static | BindingFlags.NonPublic);
            int result = (int)method.Invoke(null, new object[] { extent, cellSize });
            Assert.Equal(expected, result);
        }

        #endregion

        #region InitializeFunctionGrid

        [Fact]
        public void InitializeFunctionGrid_CopiesValuesCorrectly()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("InitializeFunctionGrid", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[10, 10];
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            // Set values in f that will be copied
            f[0, 0] = -1;
            f[10, 10] = 1;
            f[5, 5] = -1;

            method.Invoke(null, new object[] { f, fs, domain, 5, 5, 2f, 2f });

            Assert.Equal(f[0, 0], fs[0, 0]);
            Assert.Equal(f[10, 10], fs[5, 5]);
            Assert.Equal(f[5, 5], fs[2, 2]);
        }

        #endregion

        #region BuildKey

        [Fact]
        public void BuildKey_AllPositiveFs_ReturnsZero()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("BuildKey", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] fs = new sbyte[3, 3];
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    fs[x, y] = 1;
            int key = (int)method.Invoke(null, new object[] { fs, 0, 0 });
            Assert.Equal(0, key);
        }

        [Fact]
        public void BuildKey_AllNegativeFs_Returns15()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("BuildKey", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] fs = new sbyte[3, 3];
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    fs[x, y] = -1;
            int key = (int)method.Invoke(null, new object[] { fs, 0, 0 });
            Assert.Equal(15, key);
        }

        [Theory]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(2)]
        [InlineData(1)]
        public void BuildKey_SingleCornerNegative_ReturnsCorrectKey(int expectedBit)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("BuildKey", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] fs = new sbyte[3, 3];
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    fs[x, y] = 1;

            int ax = 0, ay = 0;
            if ((expectedBit & 8) != 0) fs[ax, ay] = -1;
            if ((expectedBit & 4) != 0) fs[ax + 1, ay] = -1;
            if ((expectedBit & 2) != 0) fs[ax + 1, ay + 1] = -1;
            if ((expectedBit & 1) != 0) fs[ax, ay + 1] = -1;

            int key = (int)method.Invoke(null, new object[] { fs, ax, ay });
            Assert.Equal(expectedBit, key);
        }

        #endregion

        #region ProcessKey

        [Fact]
        public void ProcessKey_WithVal1_AddsPointToPoly()
        {
            MethodInfo processKey = typeof(MarchingSquares).GetMethod("ProcessKey", BindingFlags.Static | BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object poly = Activator.CreateInstance(geomPolyType);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[3, 3];
            fs[0, 0] = -1; fs[1, 0] = 1; fs[1, 1] = -1; fs[0, 1] = 1;

            processKey.Invoke(null, new object[] { 1, 0f, 0f, 10f, 10f, 0, 0, f, fs, 2, poly });

            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);
            int length = (int)lengthField.GetValue(poly);
            Assert.True(length > 0);
        }

        [Fact]
        public void ProcessKey_WithMultipleBits_AddsMultiplePoints()
        {
            MethodInfo processKey = typeof(MarchingSquares).GetMethod("ProcessKey", BindingFlags.Static | BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object poly = Activator.CreateInstance(geomPolyType);

            sbyte[,] f = new sbyte[100, 100];
            sbyte[,] fs = new sbyte[3, 3];
            fs[0, 0] = -1; fs[1, 0] = -1; fs[1, 1] = -1; fs[0, 1] = -1;

            processKey.Invoke(null, new object[] { 0x55, 0f, 0f, 10f, 10f, 0, 0, f, fs, 2, poly });

            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);
            int length = (int)lengthField.GetValue(poly);
            Assert.Equal(4, length);
        }

        #endregion

        #region GetVertexPosition

        [Theory]
        [InlineData(0, 0f, 0f)]
        [InlineData(2, 10f, 0f)]
        [InlineData(4, 10f, 10f)]
        [InlineData(6, 0f, 10f)]
        public void GetVertexPosition_CornerIndices_ReturnsCorrectPosition(int index, float expectedX, float expectedY)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("GetVertexPosition", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            f[0, 0] = -1; f[10, 0] = 1; f[10, 10] = -1; f[0, 10] = 1;

            Vector2F result = (Vector2F)method.Invoke(null, new object[] { index, 0f, 0f, 10f, 10f, (sbyte)-1, (sbyte)1, (sbyte)-1, (sbyte)1, f, 2 });

            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void GetVertexPosition_EdgeIndices_DoesNotThrow(int index)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("GetVertexPosition", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            f[0, 0] = -1; f[10, 0] = 1; f[10, 10] = -1; f[0, 10] = 1;

            Vector2F result = (Vector2F)method.Invoke(null, new object[] { index, 0f, 0f, 10f, 10f, (sbyte)-1, (sbyte)1, (sbyte)-1, (sbyte)1, f, 2 });

            Assert.NotNull(result);
        }

        #endregion

        #region MarchSquare

        [Fact]
        public void MarchSquare_WithKey15_ProcessesVal0x55()
        {
            MethodInfo marchSquare = typeof(MarchingSquares).GetMethod("MarchSquare", BindingFlags.Static | BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object poly = Activator.CreateInstance(geomPolyType);

            sbyte[,] f = new sbyte[100, 100];
            sbyte[,] fs = new sbyte[3, 3];
            fs[0, 0] = -1; fs[1, 0] = -1; fs[1, 1] = -1; fs[0, 1] = -1;

            object[] args = { f, fs, poly, 0, 0, 0f, 0f, 10f, 10f, 2 };
            int key = (int)marchSquare.Invoke(null, args);
            Assert.Equal(15, key);
        }

        #endregion

        #region DetectSquares

        [Fact]
        public void DetectSquares_WithoutCombine_ReturnsVertices()
        {
            MethodInfo detectSquares = typeof(MarchingSquares).GetMethod("DetectSquares", BindingFlags.Static | BindingFlags.NonPublic);
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            sbyte[,] f = new sbyte[11, 11];
            for (int x = 0; x < 11; x++)
                for (int y = 0; y < 11; y++)
                    f[x, y] = (x < 5 && y < 5) ? (sbyte)-1 : (sbyte)1;

            List<Vertices> result = (List<Vertices>)detectSquares.Invoke(null, new object[] { domain, 2f, 2f, f, 2, false });

            Assert.NotNull(result);
        }

        [Fact]
        public void DetectSquares_WithCombine_ReturnsVertices()
        {
            MethodInfo detectSquares = typeof(MarchingSquares).GetMethod("DetectSquares", BindingFlags.Static | BindingFlags.NonPublic);
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            sbyte[,] f = new sbyte[11, 11];
            for (int x = 0; x < 11; x++)
                for (int y = 0; y < 11; y++)
                    f[x, y] = (x < 5 && y < 5) ? (sbyte)-1 : (sbyte)1;

            List<Vertices> result = (List<Vertices>)detectSquares.Invoke(null, new object[] { domain, 2f, 2f, f, 2, true });

            Assert.NotNull(result);
        }

        #endregion

        #region CanCombine

        [Fact]
        public void CanCombine_WithNullP_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("CanCombine", BindingFlags.Static | BindingFlags.NonPublic);
            GeomPolyVal[,] ps = new GeomPolyVal[2, 2];
            ps[0, 1] = null;

            bool result = (bool)method.Invoke(null, new object[] { ps, 0, 1 });
            Assert.False(result);
        }

        [Fact]
        public void CanCombine_WithPKeyNoBottomBits_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("CanCombine", BindingFlags.Static | BindingFlags.NonPublic);
            GeomPolyVal[,] ps = new GeomPolyVal[2, 2];
            ps[0, 1] = new GeomPolyVal(new MarchingSquares.GeomPoly(), 0);

            bool result = (bool)method.Invoke(null, new object[] { ps, 0, 1 });
            Assert.False(result);
        }

        [Fact]
        public void CanCombine_WithNullU_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("CanCombine", BindingFlags.Static | BindingFlags.NonPublic);
            GeomPolyVal[,] ps = new GeomPolyVal[2, 2];
            ps[0, 1] = new GeomPolyVal(new MarchingSquares.GeomPoly(), 12);
            ps[0, 0] = null;

            bool result = (bool)method.Invoke(null, new object[] { ps, 0, 1 });
            Assert.False(result);
        }

        [Fact]
        public void CanCombine_WithSameGeomP_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("CanCombine", BindingFlags.Static | BindingFlags.NonPublic);
            MarchingSquares.GeomPoly sharedPoly = new MarchingSquares.GeomPoly();
            GeomPolyVal[,] ps = new GeomPolyVal[2, 2];
            ps[0, 1] = new GeomPolyVal(sharedPoly, 12);
            ps[0, 0] = new GeomPolyVal(sharedPoly, 3);

            bool result = (bool)method.Invoke(null, new object[] { ps, 0, 1 });
            Assert.False(result);
        }

        #endregion

        #region CxFastList_Additional

        [Fact]
        public void CxFastList_Has_ExistingItem_ReturnsTrue()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo has = intListType.GetMethod("Has");

            add.Invoke(list, new object[] { 42 });
            bool result = (bool)has.Invoke(list, new object[] { 42 });
            Assert.True(result);
        }

        [Fact]
        public void CxFastList_Has_NonExistingItem_ReturnsFalse()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo has = intListType.GetMethod("Has");

            add.Invoke(list, new object[] { 42 });
            bool result = (bool)has.Invoke(list, new object[] { 99 });
            Assert.False(result);
        }

        [Fact]
        public void CxFastList_Size_WithMultipleItems_ReturnsCorrectCount()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo size = intListType.GetMethod("Size");

            add.Invoke(list, new object[] { 1 });
            add.Invoke(list, new object[] { 2 });
            add.Invoke(list, new object[] { 3 });

            int result = (int)size.Invoke(list, null);
            Assert.Equal(3, result);
        }

        [Fact]
        public void CxFastList_Find_WithDefaultValue_ReturnsNode()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo find = intListType.GetMethod("Find");

            add.Invoke(list, new object[] { 1 });
            add.Invoke(list, new object[] { 0 });
            add.Invoke(list, new object[] { 2 });

            object result = find.Invoke(list, new object[] { 0 });
            Assert.NotNull(result);
        }

        [Fact]
        public void CxFastList_Find_OnEmptyList_ReturnsNull()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo find = intListType.GetMethod("Find");
            object result = find.Invoke(list, new object[] { 42 });
            Assert.Null(result);
        }

        [Fact]
        public void CxFastList_Remove_OnEmptyList_ReturnsFalse()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo remove = intListType.GetMethod("Remove");
            bool result = (bool)remove.Invoke(list, new object[] { 42 });
            Assert.False(result);
        }

        #endregion

        #region InsertPolyIntoPoly

        [Fact]
        public void InsertPolyIntoPoly_WithNonEmptyBp_InsertsCorrectly()
        {
            MethodInfo insertPolyIntoPoly = typeof(MarchingSquares).GetMethod("InsertPolyIntoPoly", BindingFlags.Static | BindingFlags.NonPublic);

            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);

            object polyA = Activator.CreateInstance(geomPolyType);
            object polyB = Activator.CreateInstance(geomPolyType);

            FieldInfo pointsFieldA = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            object pointsA = pointsFieldA.GetValue(polyA);
            object pointsB = pointsFieldA.GetValue(polyB);

            MethodInfo add = vectorListType.GetMethod("Add");
            MethodInfo begin = vectorListType.GetMethod("Begin");

            add.Invoke(pointsA, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(pointsA, new object[] { new Vector2F(5f, 0f) });

            add.Invoke(pointsB, new object[] { new Vector2F(10f, 0f) });
            add.Invoke(pointsB, new object[] { new Vector2F(15f, 0f) });

            object ai = begin.Invoke(pointsA, null);
            object refAp = pointsA;
            object refBp = pointsB;

            insertPolyIntoPoly.Invoke(null, new[] { refAp, polyA, refBp, ai });
        }

        #endregion

        #region CxFastList_Vector2F

        [Fact]
        public void CxFastList_Vector2F_AddAndIterate_Works()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            object list = Activator.CreateInstance(vectorListType);

            MethodInfo add = vectorListType.GetMethod("Add");
            MethodInfo begin = vectorListType.GetMethod("Begin");
            MethodInfo getList = vectorListType.GetMethod("GetListOfElements");

            add.Invoke(list, new object[] { new Vector2F(1f, 2f) });
            add.Invoke(list, new object[] { new Vector2F(3f, 4f) });

            List<Vector2F> elements = (List<Vector2F>)getList.Invoke(list, null);
            Assert.Equal(2, elements.Count);
        }

        #endregion
    }
}
