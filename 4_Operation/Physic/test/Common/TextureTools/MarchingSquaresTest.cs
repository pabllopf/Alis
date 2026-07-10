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
            float v0 = 1.192092896e-07f;
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
            Assert.InRange(result, 48f, 52f);
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
            Assert.InRange(result, 48f, 52f);
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
            Type nodeType = listType.GetNestedType("CxFastListNode`1", BindingFlags.NonPublic).MakeGenericType(typeof(int));
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
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type nodeType = listType.GetNestedType("CxFastListNode`1", BindingFlags.NonPublic).MakeGenericType(typeof(int));
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo erase = intListType.GetMethod("Erase");
            MethodInfo getList = intListType.GetMethod("GetListOfElements");
            FieldInfo countField = intListType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic);

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });
            add.Invoke(list, new object[] { 30 });

            MethodInfo begin = intListType.GetMethod("Begin");
            object head = begin.Invoke(list, null);
            FieldInfo nextField = nodeType.GetField("Next", BindingFlags.Instance | BindingFlags.Public);
            object second = nextField.GetValue(head);

            erase.Invoke(list, new object[] { head, second });
            Assert.Equal(2, (int)countField.GetValue(list));

            List<int> elements = (List<int>)getList.Invoke(list, null);
            Assert.Equal(2, elements.Count);
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
        public void CxFastList_Size_ReturnsCorrectCount()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo size = intListType.GetMethod("Size");

            Assert.Equal(0, (int)size.Invoke(list, null));

            add.Invoke(list, new object[] { 10 });
            add.Invoke(list, new object[] { 20 });

            Assert.Equal(2, (int)size.Invoke(list, null));
        }

        [Fact]
        public void CxFastList_Has_ReturnsTrueForExisting()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo has = intListType.GetMethod("Has");

            add.Invoke(list, new object[] { 42 });

            Assert.True((bool)has.Invoke(list, new object[] { 42 }));
            Assert.False((bool)has.Invoke(list, new object[] { 99 }));
        }

        [Fact]
        public void CxFastList_Find_ReturnsNodeForExisting()
        {
            Type listType = typeof(MarchingSquares).GetNestedType("CxFastList`1", BindingFlags.NonPublic);
            Type intListType = listType.MakeGenericType(typeof(int));
            object list = Activator.CreateInstance(intListType);

            MethodInfo add = intListType.GetMethod("Add");
            MethodInfo find = intListType.GetMethod("Find");

            add.Invoke(list, new object[] { 42 });
            object node = find.Invoke(list, new object[] { 42 });
            Assert.NotNull(node);

            object notFound = find.Invoke(list, new object[] { 99 });
            Assert.Null(notFound);
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
    }
}
