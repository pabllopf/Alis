using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    public class YuPengClipperRemainingCoverageTests
    {
        [Fact]
        public void InsertIntersectionPoint_AlphaBeyondEnd_DoesNotInsert()
        {
            Vertices verts = new Vertices
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f)
            };
            var method = typeof(YuPengClipper).GetMethod("InsertIntersectionPoint",
                BindingFlags.Static | BindingFlags.NonPublic);
            method.Invoke(null, new object[] { verts, new Vector2F(0f, 0f), new Vector2F(10f, 0f), new Vector2F(20f, 0f) });
            Assert.Equal(2, verts.Count);
        }

        [Fact]
        public void InsertIntersectionPoint_AlphaAtZero_DoesNotInsert()
        {
            Vertices verts = new Vertices
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f)
            };
            var method = typeof(YuPengClipper).GetMethod("InsertIntersectionPoint",
                BindingFlags.Static | BindingFlags.NonPublic);
            method.Invoke(null, new object[] { verts, new Vector2F(0f, 0f), new Vector2F(10f, 0f), new Vector2F(0f, 0f) });
            Assert.Equal(2, verts.Count);
        }

        [Fact]
        public void BuildPolygonsFromChain_DisconnectedEdges_ReturnsBrokenResult()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

            object e1 = ctor.Invoke(new object[] { new Vector2F(0f, 0f), new Vector2F(1f, 0f) });
            object e2 = ctor.Invoke(new object[] { new Vector2F(5f, 0f), new Vector2F(6f, 0f) });

            Type listType = typeof(List<>).MakeGenericType(edgeType);
            object list = Activator.CreateInstance(listType);
            listType.GetMethod("Add").Invoke(list, new[] { e1 });
            listType.GetMethod("Add").Invoke(list, new[] { e2 });

            MethodInfo buildMethod = typeof(YuPengClipper).GetMethod("BuildPolygonsFromChain",
                BindingFlags.Static | BindingFlags.NonPublic);

            object[] args = new object[] { list, null };
            object errVal = buildMethod.Invoke(null, args);

            Assert.Equal(PolyClipError.BrokenResult, (PolyClipError)errVal);
        }

        [Fact]
        public void BuildPolygonsFromChain_SingleEdge_ReturnsDegenerated()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

            object e1 = ctor.Invoke(new object[] { new Vector2F(0f, 0f), new Vector2F(1f, 0f) });

            Type listType = typeof(List<>).MakeGenericType(edgeType);
            object list = Activator.CreateInstance(listType);
            listType.GetMethod("Add").Invoke(list, new[] { e1 });

            MethodInfo buildMethod = typeof(YuPengClipper).GetMethod("BuildPolygonsFromChain",
                BindingFlags.Static | BindingFlags.NonPublic);

            object[] args = new object[] { list, null };
            object errVal = buildMethod.Invoke(null, args);

            Assert.Equal(PolyClipError.DegeneratedOutput, (PolyClipError)errVal);
        }

        [Fact]
        public void Edge_EqualsObject_WithNonNullEdge_ReturnsTrue()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

            object edge1 = ctor.Invoke(new object[] { new Vector2F(1f, 2f), new Vector2F(3f, 4f) });
            object edge2 = ctor.Invoke(new object[] { new Vector2F(1f, 2f), new Vector2F(3f, 4f) });

            MethodInfo equalsObj = edgeType.GetMethod("Equals", new[] { typeof(object) });

            Assert.True((bool)equalsObj.Invoke(edge1, new object[] { edge2 }));
        }

        [Fact]
        public void Edge_EqualsObject_WithNonEdgeObject_ReturnsFalse()
        {
            Type edgeType = typeof(YuPengClipper).GetNestedType("Edge", BindingFlags.NonPublic);
            ConstructorInfo ctor = edgeType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];

            object edge = ctor.Invoke(new object[] { new Vector2F(1f, 2f), new Vector2F(3f, 4f) });

            MethodInfo equalsObj = edgeType.GetMethod("Equals", new[] { typeof(object) });

            Assert.False((bool)equalsObj.Invoke(edge, new object[] { 42 }));
        }
    }
}
