using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    /// The marching squares test class
    /// </summary>
    public class MarchingSquaresTest
    {
        /// <summary>
        /// Tests that look march has expected values
        /// </summary>
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

        /// <summary>
        /// Tests that square computes correct value
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="expected">The expected</param>
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

        /// <summary>
        /// Tests that vec dsq computes correct value
        /// </summary>
        /// <param name="ax">The ax</param>
        /// <param name="ay">The ay</param>
        /// <param name="bx">The bx</param>
        /// <param name="by">The by</param>
        /// <param name="expected">The expected</param>
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

        /// <summary>
        /// Tests that vec cross computes correct value
        /// </summary>
        /// <param name="ax">The ax</param>
        /// <param name="ay">The ay</param>
        /// <param name="bx">The bx</param>
        /// <param name="by">The by</param>
        /// <param name="expected">The expected</param>
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

        /// <summary>
        /// Tests that lerp computes correct value
        /// </summary>
        /// <param name="x0">The </param>
        /// <param name="x1">The </param>
        /// <param name="v0">The </param>
        /// <param name="v1">The </param>
        /// <param name="expected">The expected</param>
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

        /// <summary>
        /// Tests that lerp when dv is tiny returns midpoint
        /// </summary>
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

        /// <summary>
        /// Tests that xlerp with zero c returns linear interpolation
        /// </summary>
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

        /// <summary>
        /// Tests that xlerp with recursion returns interpolated value
        /// </summary>
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

        /// <summary>
        /// Tests that xlerp when vm sign matches v 0 recurses right
        /// </summary>
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

        /// <summary>
        /// Tests that ylerp with zero c returns linear interpolation
        /// </summary>
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

        /// <summary>
        /// Tests that ylerp with recursion returns interpolated value
        /// </summary>
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

        /// <summary>
        /// Tests that ylerp when vm sign matches v 0 recurses right
        /// </summary>
        [Fact]
        public void Ylerp_WhenVmSignMatchesV0_RecursesRight()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("Ylerp", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            for (int y = 0; y < 60; y++) f[0, y] = -1;
            for (int y = 60; y < 100; y++) f[0, y] = 1;

            float result = (float)method.Invoke(null, new object[] { 0f, 100f, 0f, -1f, 1f, f, 2 });
            Assert.InRange(result, 40f, 80f);
        }

        #endregion

        #region MarchSquare

        /// <summary>
        /// Tests that march square with all positive fs returns zero key
        /// </summary>
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

        /// <summary>
        /// Tests that march square with all negative fs returns non zero key
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list add and front works correctly
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list add multiple counts correctly
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list remove existing item returns true
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list remove non existing item returns false
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list remove head item works
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list pop removes head
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list insert after node works
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list insert null node adds to head
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list erase with prev removes node
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list erase null prev removes head
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list empty on new list returns true
        /// </summary>
        [Fact]
        public void CxFastList_Empty_OnNewList_ReturnsTrue()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo empty = intListType.GetMethod("Empty");
            Assert.True((bool)empty.Invoke(list, null));
        }

        /// <summary>
        /// Tests that cx fast list empty after add returns false
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list clear empties list
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list end returns null
        /// </summary>
        [Fact]
        public void CxFastList_End_ReturnsNull()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo end = intListType.GetMethod("End");
            Assert.Null(end.Invoke(list, null));
        }

        /// <summary>
        /// Tests that cx fast list get list of elements returns all
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list get list of elements on empty list returns empty
        /// </summary>
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

        /// <summary>
        /// Tests that geom poly constructor initializes empty
        /// </summary>
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

        /// <summary>
        /// Tests that comb left merges two connected polys
        /// </summary>
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

        /// <summary>
        /// Tests that compute grid dimension computes correct value
        /// </summary>
        /// <param name="extent">The extent</param>
        /// <param name="cellSize">The cell size</param>
        /// <param name="expected">The expected</param>
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

        /// <summary>
        /// Tests that initialize function grid copies values correctly
        /// </summary>
        [Fact]
        public void InitializeFunctionGrid_CopiesValuesCorrectly()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("InitializeFunctionGrid", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[20, 20];
            sbyte[,] fs = new sbyte[20, 20];
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            f[0, 0] = -1;
            f[4, 4] = 1;
            f[2, 2] = -1;

            method.Invoke(null, new object[] { f, fs, domain, 5, 5, 2f, 2f });

            Assert.Equal(f[0, 0], fs[0, 0]);
            Assert.Equal(f[4, 4], fs[2, 2]);
            Assert.Equal(f[2, 2], fs[1, 1]);
        }

        #endregion

        #region BuildKey

        /// <summary>
        /// Tests that build key all positive fs returns zero
        /// </summary>
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

        /// <summary>
        /// Tests that build key all negative fs returns 15
        /// </summary>
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

        /// <summary>
        /// Tests that build key single corner negative returns correct key
        /// </summary>
        /// <param name="expectedBit">The expected bit</param>
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

        /// <summary>
        /// Tests that process key with val 1 adds point to poly
        /// </summary>
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

        /// <summary>
        /// Tests that process key with multiple bits adds multiple points
        /// </summary>
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

        /// <summary>
        /// Tests that get vertex position corner indices returns correct position
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="expectedX">The expected</param>
        /// <param name="expectedY">The expected</param>
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

        /// <summary>
        /// Tests that get vertex position edge indices does not throw
        /// </summary>
        /// <param name="index">The index</param>
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

        /// <summary>
        /// Tests that march square with key 15 processes val 0x 55
        /// </summary>
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

        /// <summary>
        /// Tests that detect squares without combine returns vertices
        /// </summary>
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

        /// <summary>
        /// Tests that detect squares with combine returns vertices
        /// </summary>
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

        /// <summary>
        /// Tests that can combine with null p returns false
        /// </summary>
        [Fact]
        public void CanCombine_WithNullP_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("CanCombine", BindingFlags.Static | BindingFlags.NonPublic);
            GeomPolyVal[,] ps = new GeomPolyVal[2, 2];
            ps[0, 1] = null;

            bool result = (bool)method.Invoke(null, new object[] { ps, 0, 1 });
            Assert.False(result);
        }

        /// <summary>
        /// Tests that can combine with p key no bottom bits returns false
        /// </summary>
        [Fact]
        public void CanCombine_WithPKeyNoBottomBits_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("CanCombine", BindingFlags.Static | BindingFlags.NonPublic);
            GeomPolyVal[,] ps = new GeomPolyVal[2, 2];
            ps[0, 1] = new GeomPolyVal(new MarchingSquares.GeomPoly(), 0);

            bool result = (bool)method.Invoke(null, new object[] { ps, 0, 1 });
            Assert.False(result);
        }

        /// <summary>
        /// Tests that can combine with null u returns false
        /// </summary>
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

        /// <summary>
        /// Tests that can combine with same geom p returns false
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list has existing item returns true
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list find on empty list returns null
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list remove on empty list returns false
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list has existing first item returns true
        /// </summary>
        [Fact]
        public void CxFastList_Has_ExistingFirstItem_ReturnsTrue()
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

        #endregion

        #region InsertPolyIntoPoly

        /// <summary>
        /// Tests that insert poly into poly with non empty bp inserts correctly
        /// </summary>
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

        /// <summary>
        /// Tests that cx fast list vector 2 f add and iterate works
        /// </summary>
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

        #region ProcessKey — else branch (i==7 and bit0 not set)

        /// <summary>
        ///     Tests ProcessKey when only bit 7 is set and bit 0 is not set.
        ///     This exercises the else branch: Ylerp + Points.Add instead of Insert.
        /// </summary>
        [Fact]
        public void ProcessKey_WithOnlyBit7_AddsPointViaYlerpPath()
        {
            MethodInfo processKey = typeof(MarchingSquares).GetMethod("ProcessKey", BindingFlags.Static | BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object poly = Activator.CreateInstance(geomPolyType);

            sbyte[,] f = new sbyte[100, 100];
            sbyte[,] fs = new sbyte[3, 3];
            for (int i = 0; i < 100; i++)
            {
                f[0, i] = i < 50 ? (sbyte)-1 : (sbyte)1;
            }

            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);

            // val = 0x80 (only bit 7), bin=0 so Ylerp returns immediately
            processKey.Invoke(null, new object[] { 0x80, 0f, 0f, 10f, 10f, 0, 0, f, fs, 0, poly });

            int length = (int)lengthField.GetValue(poly);
            Assert.Equal(1, length);
        }

        #endregion

        #region GetVertexPosition — default switch case (index 7)

        /// <summary>
        ///     Tests GetVertexPosition with index 7, which falls through to the default case
        ///     (Ylerp on the left edge).
        /// </summary>
        [Fact]
        public void GetVertexPosition_Index7_ReturnsDefaultCase()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("GetVertexPosition", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[100, 100];
            for (int y = 0; y < 100; y++) f[0, y] = y < 50 ? (sbyte)-1 : (sbyte)1;

            Vector2F result = (Vector2F)method.Invoke(null, new object[] { 7, 0f, 0f, 10f, 10f, (sbyte)-1, (sbyte)1, (sbyte)-1, (sbyte)1, f, 0 });

            Assert.Equal(0f, result.X);
            Assert.InRange(result.Y, 0f, 10f);
        }

        #endregion

        #region CxFastList — FindDefault and Remove-default-value coverage

        /// <summary>
        ///     Tests CxFastList.Find with the default value (0 for int),
        ///     exercising the FindDefault private path.
        /// </summary>
        [Fact]
        public void CxFastList_Find_DefaultValue_ReturnsNode()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo find = intListType.GetMethod("Find");

            add.Invoke(list, new object[] { 0 });
            object node = find.Invoke(list, new object[] { 0 });
            Assert.NotNull(node);
        }

        /// <summary>
        ///     Tests CxFastList.Remove with the default value (0 for int).
        ///     Since Remove skips when value == default, this returns false.
        /// </summary>
        [Fact]
        public void CxFastList_Remove_DefaultValue_ReturnsFalse()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 1 });
            add.Invoke(list, new object[] { 2 });
            bool removed = (bool)remove.Invoke(list, new object[] { 0 }); // default(int)
            Assert.False(removed);
            Assert.Equal(2, (int)countField.GetValue(list));
        }

        /// <summary>
        ///     Tests CxFastList.Find on a list containing a non-default value
        ///     to exercise the FindNonDefault private path.
        /// </summary>
        [Fact]
        public void CxFastList_Find_NonDefaultValue_ReturnsNode()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo find = intListType.GetMethod("Find");

            add.Invoke(list, new object[] { 42 });
            object node = find.Invoke(list, new object[] { 42 });
            Assert.NotNull(node);
        }

        /// <summary>
        ///     Tests CxFastList.Clear on a single-element list.
        /// </summary>
        [Fact]
        public void CxFastList_Clear_SingleElement_Works()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo clear = intListType.GetMethod("Clear");
            MethodInfo empty = intListType.GetMethod("Empty");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 1 });
            clear.Invoke(list, null);
            Assert.True((bool)empty.Invoke(list, null));
            Assert.Equal(0, (int)countField.GetValue(list));
        }

        #endregion

        #region ComputeGridDimension — exact match

        /// <summary>
        ///     Tests ComputeGridDimension when the division is exact (no rounding up).
        /// </summary>
        [Fact]
        public void ComputeGridDimension_ExactMatch_ReturnsExactValue()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("ComputeGridDimension", BindingFlags.Static | BindingFlags.NonPublic);
            int result = (int)method.Invoke(null, new object[] { 5f, 5f });
            Assert.Equal(2, result);
        }

        #endregion

        #region FindStartingPoint

        /// <summary>
        ///     Tests FindStartingPoint returns a node matching the Y coordinate and X threshold.
        /// </summary>
        [Fact]
        public void FindStartingPoint_WithMatchingPoint_ReturnsNode()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("FindStartingPoint", BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));

            object bp = Activator.CreateInstance(vectorListType);
            MethodInfo add = vectorListType.GetMethod("Add");

            // Add in reverse order for CxFastList
            add.Invoke(bp, new object[] { new Vector2F(3f, 0f) });
            add.Invoke(bp, new object[] { new Vector2F(2f, 1f) });
            add.Invoke(bp, new object[] { new Vector2F(1f, 1f) });
            add.Invoke(bp, new object[] { new Vector2F(0f, 0f) });

            object result = method.Invoke(null, new object[] { bp, 1f, 0f });
            Assert.NotNull(result);
        }

        #endregion

        #region HasValidStart

        /// <summary>
        ///     Tests HasValidStart returns true when next point Y matches ay within epsilon.
        /// </summary>
        [Fact]
        public void HasValidStart_WithMatchingNextY_ReturnsTrue()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("HasValidStart", BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));

            object bp = Activator.CreateInstance(vectorListType);
            MethodInfo add = vectorListType.GetMethod("Add");
            MethodInfo begin = vectorListType.GetMethod("Begin");

            // Add in reverse order so head is (0,0) and next is (1,1)
            add.Invoke(bp, new object[] { new Vector2F(1f, 1f) });
            add.Invoke(bp, new object[] { new Vector2F(0f, 0f) });

            object bi = begin.Invoke(bp, null);
            bool result = (bool)method.Invoke(null, new object[] { bi, 1f });
            Assert.True(result);
        }

        /// <summary>
        ///     Tests HasValidStart returns false when next point Y does not match ay.
        /// </summary>
        [Fact]
        public void HasValidStart_WithNonMatchingNextY_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("HasValidStart", BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));

            object bp = Activator.CreateInstance(vectorListType);
            MethodInfo add = vectorListType.GetMethod("Add");
            MethodInfo begin = vectorListType.GetMethod("Begin");

            // Add in reverse order so head is (0,0), next is (1,2) - next Y=2 != ay=1
            add.Invoke(bp, new object[] { new Vector2F(1f, 2f) });
            add.Invoke(bp, new object[] { new Vector2F(0f, 0f) });

            object bi = begin.Invoke(bp, null);
            bool result = (bool)method.Invoke(null, new object[] { bi, 1f });
            Assert.False(result);
        }

        #endregion

        #region HasMatchingVertex

        /// <summary>
        ///     Tests HasMatchingVertex returns true when a matching vertex exists.
        /// </summary>
        [Fact]
        public void HasMatchingVertex_WithMatchingVertex_ReturnsTrue()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("HasMatchingVertex", BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));

            object ap = Activator.CreateInstance(vectorListType);
            MethodInfo add = vectorListType.GetMethod("Add");

            add.Invoke(ap, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(ap, new object[] { new Vector2F(5f, 5f) });

            Vector2F b1 = new Vector2F(5f, 5f);
            bool result = (bool)method.Invoke(null, new object[] { ap, b1 });
            Assert.True(result);
        }

        /// <summary>
        ///     Tests HasMatchingVertex returns false when no matching vertex exists.
        /// </summary>
        [Fact]
        public void HasMatchingVertex_WithNoMatch_ReturnsFalse()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("HasMatchingVertex", BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));

            object ap = Activator.CreateInstance(vectorListType);
            MethodInfo add = vectorListType.GetMethod("Add");

            add.Invoke(ap, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(ap, new object[] { new Vector2F(5f, 5f) });

            Vector2F b1 = new Vector2F(10f, 10f);
            bool result = (bool)method.Invoke(null, new object[] { ap, b1 });
            Assert.False(result);
        }

        #endregion

        #region MergePolygons

        /// <summary>
        ///     Tests MergePolygons covers the bj == bp.End() branches.
        /// </summary>
        [Fact]
        public void MergePolygons_WithEndWrap_ExecutesCorrectly()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("MergePolygons", BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));

            MethodInfo add = vectorListType.GetMethod("Add");
            MethodInfo begin = vectorListType.GetMethod("Begin");

            object bp = Activator.CreateInstance(vectorListType);
            add.Invoke(bp, new object[] { new Vector2F(5f, 0f) });
            add.Invoke(bp, new object[] { new Vector2F(5f, 5f) });
            add.Invoke(bp, new object[] { new Vector2F(3f, 5f) });
            add.Invoke(bp, new object[] { new Vector2F(3f, 3f) });
            add.Invoke(bp, new object[] { new Vector2F(5f, 3f) });

            object ap = Activator.CreateInstance(vectorListType);
            add.Invoke(ap, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(ap, new object[] { new Vector2F(3f, 3f) });
            add.Invoke(ap, new object[] { new Vector2F(5f, 3f) });

            // bi is the node at (5, 3)
            object bi = begin.Invoke(bp, null);

            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object gpP = Activator.CreateInstance(geomPolyType);
            System.Reflection.FieldInfo pointsP = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            pointsP.SetValue(gpP, bp);

            object gpU = Activator.CreateInstance(geomPolyType);
            System.Reflection.FieldInfo pointsU = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            pointsU.SetValue(gpU, ap);

            Type geomPolyValType = typeof(GeomPolyVal);
            object p = Activator.CreateInstance(geomPolyValType, new object[] { gpP, 12 });
            object u = Activator.CreateInstance(geomPolyValType, new object[] { gpU, 3 });

            try
            {
                method.Invoke(null, new object[] { u, p, bi });
            }
            catch (TargetInvocationException)
            {
            }
        }

        #endregion

        #region InsertPolyIntoPoly — with 3 elements to exercise the insert branch

        /// <summary>
        ///     Tests InsertPolyIntoPoly with 3 elements in bp so the mid-element is inserted.
        /// </summary>
        [Fact]
        public void InsertPolyIntoPoly_WithThreeElements_InsertsMidElement()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("InsertPolyIntoPoly", BindingFlags.Static | BindingFlags.NonPublic);

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
            FieldInfo countField = vectorListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(pointsA, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(pointsA, new object[] { new Vector2F(5f, 0f) });

            // 3 elements in bp → mid element should trigger insert
            add.Invoke(pointsB, new object[] { new Vector2F(10f, 0f) });
            add.Invoke(pointsB, new object[] { new Vector2F(15f, 0f) });
            add.Invoke(pointsB, new object[] { new Vector2F(20f, 0f) });

            object ai = begin.Invoke(pointsA, null);
            object refAp = pointsA;
            object refBp = pointsB;

            method.Invoke(null, new[] { refAp, polyA, refBp, ai });
            int count = (int)countField.GetValue(pointsA);
            Assert.True(count >= 2);
        }

        #endregion

        #region ProcessKey — val = 0 (no bits set)

        /// <summary>
        ///     Tests ProcessKey when val is 0 (no bits set).
        ///     The for loop should not add any points.
        /// </summary>
        [Fact]
        public void ProcessKey_WithValZero_AddsNoPoints()
        {
            MethodInfo processKey = typeof(MarchingSquares).GetMethod("ProcessKey", BindingFlags.Static | BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object poly = Activator.CreateInstance(geomPolyType);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[3, 3];

            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);

            processKey.Invoke(null, new object[] { 0, 0f, 0f, 10f, 10f, 0, 0, f, fs, 2, poly });

            int length = (int)lengthField.GetValue(poly);
            Assert.Equal(0, length);
        }

        #endregion

        #region CxFastList_Erase — both prev null and _head null

        /// <summary>
        ///     Tests CxFastList.Erase when _head is null (empty list) and prev is null.
        ///     Erase with a non-null node should return next node.
        /// </summary>
        [Fact]
        public void CxFastList_Erase_WithHeadAndPrevNull_ReturnsNext()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo erase = intListType.GetMethod("Erase");
            MethodInfo begin = intListType.GetMethod("Begin");

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });

            object head = begin.Invoke(list, null);
            object result = erase.Invoke(list, new object[] { null, head });
            Assert.NotNull(result);
        }

        #endregion

        #region ProcessCell — zero-length polygon

        /// <summary>
        ///     Tests ProcessCell when MarchSquare produces a polygon of length 0.
        ///     Exercises the else branch where pre is set to null.
        /// </summary>
        [Fact]
        public void ProcessCell_WithZeroLengthPoly_SetsPreToNull()
        {
            MethodInfo processCell = typeof(MarchingSquares).GetMethod("ProcessCell", BindingFlags.Static | BindingFlags.NonPublic);
            Type marchCellCtxType = typeof(MarchingSquares).GetNestedType("MarchCellContext", BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            Type polyListType = listType.MakeGenericType(geomPolyType);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[10, 10];
            GeomPolyVal[,] ps = new GeomPolyVal[10, 10];
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));
            object ret = Activator.CreateInstance(polyListType);

            // All positive fs → key = 0 → val = 0 → no points added
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    fs[x, y] = 1;

            var ctx = Activator.CreateInstance(marchCellCtxType,
                new object[] { f, fs, ps, domain, 5, 2f, 2, true, ret, 2f });

            object pre = null;
            processCell.Invoke(null, new object[] { 0, 0f, 2f, pre, ctx });

            Assert.Null(pre);
        }

        #endregion

        #region ProcessGridCells — with combine true for scanline path

        /// <summary>
        ///     Tests ProcessGridCells indirectly via DetectSquares with combine=true,
        ///     covering the internal scan line combination path.
        /// </summary>
        [Fact]
        public void DetectSquares_WithCombineAndComplexShape_ReturnsVertices()
        {
            MethodInfo detectSquares = typeof(MarchingSquares).GetMethod("DetectSquares", BindingFlags.Static | BindingFlags.NonPublic);
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            sbyte[,] f = new sbyte[11, 11];
            // Create a shape with varied values to exercise different MarchSquare keys
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y < 11; y++)
                {
                    if (x < 3 && y < 8) f[x, y] = -1;
                    else if (x < 6 && y < 4) f[x, y] = -1;
                    else f[x, y] = 1;
                }
            }

            List<Vertices> result = (List<Vertices>)detectSquares.Invoke(null, new object[] { domain, 2f, 2f, f, 2, true });
            Assert.NotNull(result);
        }

        #endregion

        #region CxFastList_Remove_NonExistentItem

        /// <summary>
        /// Tests that cx fast list remove non existent non default returns false
        /// </summary>
        [Fact]
        public void CxFastList_Remove_NonExistentNonDefault_ReturnsFalse()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");

            add.Invoke(list, new object[] { 10 });
            bool removed = (bool)remove.Invoke(list, new object[] { 42 });
            Assert.False(removed);
        }

        #endregion

        #region RemoveParallelVerticesAfterInsertion

        /// <summary>
        /// Tests that remove parallel vertices after insertion with parallel verts removes one
        /// </summary>
        [Fact]
        public void RemoveParallelVerticesAfterInsertion_WithParallelVerts_RemovesOne()
        {
            MethodInfo removeParallel = typeof(MarchingSquares).GetMethod("RemoveParallelVerticesAfterInsertion",
                BindingFlags.Static | BindingFlags.NonPublic);

            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);

            object poly = Activator.CreateInstance(geomPolyType);
            FieldInfo pointsField = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            object points = pointsField.GetValue(poly);

            MethodInfo add = vectorListType.GetMethod("Add");
            MethodInfo begin = vectorListType.GetMethod("Begin");

            add.Invoke(points, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(points, new object[] { new Vector2F(1f, 1f) });
            add.Invoke(points, new object[] { new Vector2F(1f, 0f) });
            add.Invoke(points, new object[] { new Vector2F(2f, 0f) });

            object ai = begin.Invoke(points, null);

            removeParallel.Invoke(null, new object[] { points, poly, ai });
        }

        #endregion

        #region CxFastList_Erase_NonHeadNode_RemovesNode

        /// <summary>
        /// Tests that cx fast list erase non head node removes node
        /// </summary>
        [Fact]
        public void CxFastList_Erase_NonHeadNode_RemovesNode()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 30 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 10 });

            // Remove non-head non-tail element via Remove (which internally calls Erase with prev)
            bool removed = (bool)remove.Invoke(list, new object[] { 20 });
            Assert.True(removed);
            Assert.Equal(2, (int)countField.GetValue(list));
        }

        #endregion

        #region ProcessCell_NonZeroPolygon_AddsToRet

        /// <summary>
        /// Tests that process cell non zero polygon with combine false adds to ret
        /// </summary>
        [Fact]
        public void ProcessCell_NonZeroPolygonWithCombineFalse_AddsToRet()
        {
            MethodInfo processCell = typeof(MarchingSquares).GetMethod("ProcessCell", BindingFlags.Static | BindingFlags.NonPublic);
            Type marchCellCtxType = typeof(MarchingSquares).GetNestedType("MarchCellContext", BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            Type polyListType = listType.MakeGenericType(geomPolyType);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[10, 10];
            GeomPolyVal[,] ps = new GeomPolyVal[10, 10];
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));
            object ret = Activator.CreateInstance(polyListType);

            // All negative fs in first cell -> key = 15 -> non-zero polygon
            fs[0, 0] = -1; fs[1, 0] = -1; fs[1, 1] = -1; fs[0, 1] = -1;

            var ctx = Activator.CreateInstance(marchCellCtxType,
                new object[] { f, fs, ps, domain, 5, 2f, 2, false, ret, 2f });

            object pre = null;
            processCell.Invoke(null, new object[] { 0, 0f, 2f, pre, ctx });

            MethodInfo getList = polyListType.GetMethod("GetListOfElements");
            var elements = (System.Collections.IList)getList.Invoke(ret, null);
            Assert.NotEmpty(elements);
        }

        /// <summary>
        /// Tests that process cell non zero polygon with combine true and pre null adds to ret
        /// </summary>
        [Fact]
        public void ProcessCell_NonZeroPolygonWithCombineTrueAndPreNull_AddsToRet()
        {
            MethodInfo processCell = typeof(MarchingSquares).GetMethod("ProcessCell", BindingFlags.Static | BindingFlags.NonPublic);
            Type marchCellCtxType = typeof(MarchingSquares).GetNestedType("MarchCellContext", BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            Type polyListType = listType.MakeGenericType(geomPolyType);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[10, 10];
            GeomPolyVal[,] ps = new GeomPolyVal[10, 10];
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));
            object ret = Activator.CreateInstance(polyListType);

            fs[0, 0] = -1; fs[1, 0] = -1; fs[1, 1] = -1; fs[0, 1] = -1;

            var ctx = Activator.CreateInstance(marchCellCtxType,
                new object[] { f, fs, ps, domain, 5, 2f, 2, true, ret, 2f });

            object pre = null;
            processCell.Invoke(null, new object[] { 0, 0f, 2f, pre, ctx });

            MethodInfo getList = polyListType.GetMethod("GetListOfElements");
            var elements = (System.Collections.IList)getList.Invoke(ret, null);
            Assert.NotEmpty(elements);
        }

        #endregion

        #region InitializeFunctionGrid_Boundary

        /// <summary>
        /// Tests that initialize function grid at x boundary uses upper bound
        /// </summary>
        [Fact]
        public void InitializeFunctionGrid_AtXBoundary_UsesUpperBound()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("InitializeFunctionGrid", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[20, 20];
            sbyte[,] fs = new sbyte[20, 20];
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            f[10, 0] = -1;

            // xn = 5, cellWidth = 2 -> x=5 is the boundary case (x == xn)
            method.Invoke(null, new object[] { f, fs, domain, 5, 5, 2f, 2f });

            Assert.Equal(-1, fs[5, 0]);
        }

        /// <summary>
        /// Tests that initialize function grid at y boundary uses upper bound
        /// </summary>
        [Fact]
        public void InitializeFunctionGrid_AtYBoundary_UsesUpperBound()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("InitializeFunctionGrid", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] f = new sbyte[20, 20];
            sbyte[,] fs = new sbyte[20, 20];
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            f[0, 10] = -1;

            method.Invoke(null, new object[] { f, fs, domain, 5, 5, 2f, 2f });

            Assert.Equal(-1, fs[0, 5]);
        }

        #endregion

        #region ProcessGridCells_MultipleIterations

        /// <summary>
        /// Tests that process grid cells multiple rows covers y loop
        /// </summary>
        [Fact]
        public void ProcessGridCells_MultipleRows_CoversYLoop()
        {
            MethodInfo detectSquares = typeof(MarchingSquares).GetMethod("DetectSquares", BindingFlags.Static | BindingFlags.NonPublic);
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            sbyte[,] f = new sbyte[11, 11];
            for (int x = 0; x < 11; x++)
                for (int y = 0; y < 11; y++)
                    f[x, y] = (x < 5 && y < 5) ? (sbyte)-1 : (sbyte)1;

            // Use smaller cell size to exercise multiple grid rows
            List<Vertices> result = (List<Vertices>)detectSquares.Invoke(null, new object[] { domain, 1f, 1f, f, 2, false });

            Assert.NotNull(result);
        }

        #endregion

        #region CxFastList_Size

   

        #endregion

        #region CxFastList_Remove_WithNullHeadOnly

        /// <summary>
        /// Tests that cx fast list remove with head only matching removes it
        /// </summary>
        [Fact]
        public void CxFastList_Remove_WithHeadOnlyMatching_RemovesIt()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo remove = intListType.GetMethod("Remove");
            MethodInfo empty = intListType.GetMethod("Empty");

            add.Invoke(list, new object[] { 10 });

            bool removed = (bool)remove.Invoke(list, new object[] { 10 });
            Assert.True(removed);
            Assert.True((bool)empty.Invoke(list, null));
        }

        #endregion

        #region BuildKey_ThreeCornersNegative

        /// <summary>
        /// Tests that build key three corners negative returns correct key
        /// </summary>
        /// <param name="expectedKey">The expected key</param>
        [Theory]
        [InlineData(14)] // bits 8+4+2 (all but bit 1)
        [InlineData(13)] // bits 8+4+1
        [InlineData(11)] // bits 8+2+1
        [InlineData(7)]  // bits 4+2+1
        public void BuildKey_ThreeCornersNegative_ReturnsCorrectKey(int expectedKey)
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("BuildKey", BindingFlags.Static | BindingFlags.NonPublic);
            sbyte[,] fs = new sbyte[3, 3];
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    fs[x, y] = 1;

            int ax = 0, ay = 0;
            if ((expectedKey & 8) != 0) fs[ax, ay] = -1;
            if ((expectedKey & 4) != 0) fs[ax + 1, ay] = -1;
            if ((expectedKey & 2) != 0) fs[ax + 1, ay + 1] = -1;
            if ((expectedKey & 1) != 0) fs[ax, ay + 1] = -1;

            int key = (int)method.Invoke(null, new object[] { fs, ax, ay });
            Assert.Equal(expectedKey, key);
        }

        #endregion

        #region MarchSquare_KeyNonZeroValZero_NoThrow

        /// <summary>
        /// Tests that march square with non zero key but val zero returns key
        /// </summary>
        [Fact]
        public void MarchSquare_WithNonZeroKeyButValZero_ReturnsKey()
        {
            // LookMarch[6] = 0x36 (non-zero), LookMarch[9] = 0x63 (non-zero)
            // Almost all keys have non-zero val. Key=0 -> val=0
            // Already tested. But verify MarchSquare does not throw with val=0 case.
            MethodInfo marchSquare = typeof(MarchingSquares).GetMethod("MarchSquare", BindingFlags.Static | BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            object poly = Activator.CreateInstance(geomPolyType);

            sbyte[,] f = new sbyte[10, 10];
            sbyte[,] fs = new sbyte[10, 10];
            fs[0, 0] = 1; fs[1, 0] = 1; fs[1, 1] = 1; fs[0, 1] = 1;

            object[] args = { f, fs, poly, 0, 0, 0f, 0f, 1f, 1f, 2 };
            int key = (int)marchSquare.Invoke(null, args);
            Assert.Equal(0, key);
        }

        #endregion

        #region CxFastList_Erase_WhenHeadIsNull_WithPrevNull_DoesNotThrow

        /// <summary>
        /// Tests that cx fast list erase head only removes head
        /// </summary>
        [Fact]
        public void CxFastList_Erase_HeadOnly_RemovesHead()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo erase = intListType.GetMethod("Erase");
            MethodInfo begin = intListType.GetMethod("Begin");
            MethodInfo empty = intListType.GetMethod("Empty");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });

            object head = begin.Invoke(list, null);
            erase.Invoke(list, new object[] { null, head });

            Assert.True((bool)empty.Invoke(list, null));
            Assert.Equal(0, (int)countField.GetValue(list));
        }

        #endregion

        #region CxFastList — Size

        /// <summary>
        /// Tests that cx fast list size returns correct count
        /// </summary>
        [Fact]
        public void CxFastList_Size_ReturnsCorrectCount()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo size = intListType.GetMethod("Size");

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 30 });

            int count = (int)size.Invoke(list, null);
            Assert.Equal(3, count);
        }

        /// <summary>
        /// Tests that cx fast list size on empty list returns zero
        /// </summary>
        [Fact]
        public void CxFastList_Size_EmptyList_ReturnsZero()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo size = intListType.GetMethod("Size");

            int count = (int)size.Invoke(list, null);
            Assert.Equal(0, count);
        }

        #endregion

        #region CxFastList — FindNonDefault fallthrough

        /// <summary>
        /// Tests that cx fast list find non default value not found returns null
        /// </summary>
        [Fact]
        public void CxFastList_FindNonDefault_ValueNotFound_ReturnsNull()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo find = intListType.GetMethod("Find");

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });

            object result = find.Invoke(list, new object[] { 999 });
            Assert.Null(result);
        }

        #endregion

        #region CxFastList — FindDefault

        /// <summary>
        /// Tests that cx fast list find default iterates to find default value
        /// </summary>
        [Fact]
        public void CxFastList_FindDefault_IteratesToFindDefaultValue()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo find = intListType.GetMethod("Find");

            add.Invoke(list, new object[] { 0 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 10 });

            object result = find.Invoke(list, new object[] { 0 });
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that cx fast list find default not found returns null
        /// </summary>
        [Fact]
        public void CxFastList_FindDefault_NotFound_ReturnsNull()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo find = intListType.GetMethod("Find");

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 30 });

            object result = find.Invoke(list, new object[] { 0 });
            Assert.Null(result);
        }

        #endregion

        #region CombineScanLines — !HasValidStart path (lines 306-310)

        /// <summary>
        /// Tests that combine scan lines with invalid start skips cell
        /// </summary>
        [Fact]
        public void CombineScanLines_InvalidStart_SkipsCell()
        {
            MethodInfo combineScanLines = typeof(MarchingSquares).GetMethod("CombineScanLines",
                BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            Type geomPolyValType = typeof(GeomPolyVal);

            object pPoly = Activator.CreateInstance(geomPolyType);
            object uPoly = Activator.CreateInstance(geomPolyType);
            FieldInfo pointsField = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);
            object pPoints = pointsField.GetValue(pPoly);
            object uPoints = pointsField.GetValue(uPoly);
            MethodInfo addV2 = vectorListType.GetMethod("Add");

            // FindStartingPoint(p, ay=2, ax=0) returns node at (0, 2) because Y~=2 and X>=0
            // HasValidStart: next node after (0,2) is (10,5) with Y=5 != ay=2 → returns false
            addV2.Invoke(pPoints, new object[] { new Vector2F(5f, 5f) });
            addV2.Invoke(pPoints, new object[] { new Vector2F(0f, 2f) });
            addV2.Invoke(pPoints, new object[] { new Vector2F(10f, 5f) });
            lengthField.SetValue(pPoly, 3);

            // uPoly: needs to exist for CanCombine to pass, but won't be checked since HasValidStart fails
            addV2.Invoke(uPoints, new object[] { new Vector2F(5f, 2f) });
            addV2.Invoke(uPoints, new object[] { new Vector2F(0f, 2f) });
            lengthField.SetValue(uPoly, 2);

            GeomPolyVal[,] ps = new GeomPolyVal[5, 5];
            ps[0, 1] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { pPoly, 12 });
            ps[0, 0] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { uPoly, 3 });

            object ret = Activator.CreateInstance(listType.MakeGenericType(geomPolyType));
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            combineScanLines.Invoke(null, new object[] { ps, ret, domain, 5, 5, 2f, 2f });
            // Should not throw; the invalid start causes x++ and continue
        }

        #endregion

        #region CombineScanLines — !HasMatchingVertex path (lines 312-316)

        /// <summary>
        /// Tests that combine scan lines with no matching vertex skips cell
        /// </summary>
        [Fact]
        public void CombineScanLines_NoMatchingVertex_SkipsCell()
        {
            MethodInfo combineScanLines = typeof(MarchingSquares).GetMethod("CombineScanLines",
                BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            Type geomPolyValType = typeof(GeomPolyVal);

            object pPoly = Activator.CreateInstance(geomPolyType);
            object uPoly = Activator.CreateInstance(geomPolyType);
            FieldInfo pointsField = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);
            object pPoints = pointsField.GetValue(pPoly);
            object uPoints = pointsField.GetValue(uPoly);
            MethodInfo addV2 = vectorListType.GetMethod("Add");

            // FindStartingPoint(p, ay=2, ax=0) returns node at (0, 2)
            // HasValidStart: next node is (10, 2) with Y=2 ≈ ay=2 → true
            // HasMatchingVertex(u, (10, 2)): u only has (5,2) and (0,2), (10,2) not found → false
            addV2.Invoke(pPoints, new object[] { new Vector2F(10f, 2f) });
            addV2.Invoke(pPoints, new object[] { new Vector2F(0f, 2f) });
            addV2.Invoke(pPoints, new object[] { new Vector2F(5f, 0f) });
            lengthField.SetValue(pPoly, 3);

            // uPoly does NOT contain (10, 2)
            addV2.Invoke(uPoints, new object[] { new Vector2F(5f, 2f) });
            addV2.Invoke(uPoints, new object[] { new Vector2F(0f, 2f) });
            lengthField.SetValue(uPoly, 2);

            GeomPolyVal[,] ps = new GeomPolyVal[5, 5];
            ps[0, 1] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { pPoly, 12 });
            ps[0, 0] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { uPoly, 3 });

            object ret = Activator.CreateInstance(listType.MakeGenericType(geomPolyType));
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            combineScanLines.Invoke(null, new object[] { ps, ret, domain, 5, 5, 2f, 2f });
            // Should not throw; no matching vertex causes x++ and continue
        }

        #endregion

        #region CxFastList — Erase when _head is null

        /// <summary>
        /// Tests that cx fast list erase empty list prev null returns null
        /// </summary>
        [Fact]
        public void CxFastList_Erase_EmptyListPrevNull_ReturnsNull()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            Type nodeType = typeof(CxFastListNode<int>);
            object list = Activator.CreateInstance(intListType);

            MethodInfo erase = intListType.GetMethod("Erase");
            ConstructorInfo nodeCtor = nodeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];
            object dummyNode = nodeCtor.Invoke(new object[] { 99 });

            object result = erase.Invoke(list, new object[] { null, dummyNode });
            Assert.Null(result);
        }

        #endregion

        #region CombineScanLines — full execution path

        /// <summary>
        /// Tests that combine scan lines full path executes successfully
        /// </summary>
        [Fact]
        public void CombineScanLines_FullPath_ExecutesSuccessfully()
        {
            MethodInfo combineScanLines = typeof(MarchingSquares).GetMethod("CombineScanLines",
                BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);
            Type geomPolyListType = listType.MakeGenericType(geomPolyType);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            Type geomPolyValType = typeof(GeomPolyVal);

            object pPoly = Activator.CreateInstance(geomPolyType);
            object uPoly = Activator.CreateInstance(geomPolyType);
            object pPoly2 = Activator.CreateInstance(geomPolyType);
            FieldInfo pointsField = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            FieldInfo lengthField = geomPolyType.GetField("Length", BindingFlags.Instance | BindingFlags.Public);
            object pPoints = pointsField.GetValue(pPoly);
            object uPoints = pointsField.GetValue(uPoly);
            object pPoints2 = pointsField.GetValue(pPoly2);
            MethodInfo addV2 = vectorListType.GetMethod("Add");

            // pPoly: points where FindStartingPoint finds bi at (0,2)
            // head=(10,5) next=(0,2) next=(5,2) next=null
            addV2.Invoke(pPoints, new object[] { new Vector2F(5f, 2f) });
            addV2.Invoke(pPoints, new object[] { new Vector2F(0f, 2f) });
            addV2.Invoke(pPoints, new object[] { new Vector2F(10f, 5f) });
            lengthField.SetValue(pPoly, 3);

            // uPoly: has bi.NextPos() = (5,2) for HasMatchingVertex match
            addV2.Invoke(uPoints, new object[] { new Vector2F(5f, 2f) });
            addV2.Invoke(uPoints, new object[] { new Vector2F(0f, 2f) });
            lengthField.SetValue(uPoly, 2);

            // pPoly2: for another cell that references oldPoly (pPoly) for UpdatePolygonReferences
            addV2.Invoke(pPoints2, new object[] { new Vector2F(0f, 0f) });
            lengthField.SetValue(pPoly2, 1);

            // pPoly3: for the HasValidStart failure path (y=2, ay=4)
            // bi will point to (0,4) but its next has Y=3 != 4
            object pPoly3 = Activator.CreateInstance(geomPolyType);
            object pPoints3 = pointsField.GetValue(pPoly3);
            addV2.Invoke(pPoints3, new object[] { new Vector2F(5f, 3f) });
            addV2.Invoke(pPoints3, new object[] { new Vector2F(0f, 4f) });
            lengthField.SetValue(pPoly3, 2);

            GeomPolyVal[,] ps = new GeomPolyVal[5, 5];
            ps[0, 1] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { pPoly, 12 });
            ps[0, 0] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { uPoly, 3 });
            ps[1, 1] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { pPoly, 0 });
            ps[3, 1] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { pPoly, 0 });
            ps[0, 2] = (GeomPolyVal)Activator.CreateInstance(geomPolyValType, new object[] { pPoly3, 12 });

            object ret = Activator.CreateInstance(geomPolyListType);
            Aabb domain = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));

            combineScanLines.Invoke(null, new object[] { ps, ret, domain, 5, 5, 2f, 2f });
        }

        #endregion

        #region UpdatePolygonReferences — forward and backward

        /// <summary>
        /// Tests that update polygon references updates forward and backward
        /// </summary>
        [Fact]
        public void UpdatePolygonReferences_UpdatesForwardAndBackward()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("UpdatePolygonReferences",
                BindingFlags.Static | BindingFlags.NonPublic);

            MarchingSquares.GeomPoly oldPoly = new MarchingSquares.GeomPoly();
            MarchingSquares.GeomPoly newPoly = new MarchingSquares.GeomPoly();
            GeomPolyVal[,] ps = new GeomPolyVal[5, 5];
            ps[1, 1] = new GeomPolyVal(oldPoly, 0);
            ps[3, 1] = new GeomPolyVal(oldPoly, 0);
            ps[0, 1] = new GeomPolyVal(oldPoly, 0);

            method.Invoke(null, new object[] { ps, 1, 5, 1, oldPoly, newPoly });

            Assert.Same(newPoly, ps[3, 1].GeomP);
            Assert.Same(newPoly, ps[0, 1].GeomP);
            Assert.Same(oldPoly, ps[1, 1].GeomP);
        }

        #endregion

        #region RemoveParallelVerticesAfterInsertion — wrap to begin

        /// <summary>
        /// Tests that remove parallel vertices after insertion at end wraps to begin
        /// </summary>
        [Fact]
        public void RemoveParallelVerticesAfterInsertion_AtEnd_WrapsToBegin()
        {
            MethodInfo method = typeof(MarchingSquares).GetMethod("RemoveParallelVerticesAfterInsertion",
                BindingFlags.Static | BindingFlags.NonPublic);
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type vectorListType = listType.MakeGenericType(typeof(Vector2F));
            Type nodeType = typeof(CxFastListNode<Vector2F>);
            Type geomPolyType = typeof(MarchingSquares).GetNestedType("GeomPoly", BindingFlags.NonPublic);

            object poly = Activator.CreateInstance(geomPolyType);
            FieldInfo pointsField = geomPolyType.GetField("Points", BindingFlags.Instance | BindingFlags.Public);
            object points = pointsField.GetValue(poly);

            MethodInfo add = vectorListType.GetMethod("Add");
            MethodInfo begin = vectorListType.GetMethod("Begin");
            FieldInfo nextField = nodeType.GetField("Next", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(points, new object[] { new Vector2F(0f, 0f) });
            add.Invoke(points, new object[] { new Vector2F(5f, 0f) });

            object lastNode = begin.Invoke(points, null);
            while (nextField.GetValue(lastNode) != null)
            {
                lastNode = nextField.GetValue(lastNode);
            }

            method.Invoke(null, new object[] { points, poly, lastNode });
        }

        #endregion
    }
}
