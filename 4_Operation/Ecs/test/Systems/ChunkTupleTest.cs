

using System;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Tests for ChunkTuple deconstruction across arities 1..8.
    /// </summary>
    public class ChunkTupleTest
    {
        /// <summary>
        ///     Tests that chunk tuple 1 deconstruct returns underlying span
        /// </summary>
        [Fact]
        public void ChunkTuple1_Deconstruct_ReturnsUnderlyingSpan()
        {
            int[] a1 = [1, 2, 3];
            ChunkTuple<int> tuple = new ChunkTuple<int> {Span = a1.AsSpan()};

            tuple.Deconstruct(out Span<int> s1);
            s1[0] = 99;

            Assert.Equal(3, s1.Length);
            Assert.Equal(99, tuple.Span[0]);
        }

        /// <summary>
        ///     Tests that chunk tuple 2 deconstruct returns mapped spans
        /// </summary>
        [Fact]
        public void ChunkTuple2_Deconstruct_ReturnsMappedSpans()
        {
            int[] a1 = [1, 2];
            float[] a2 = [3, 4];
            ChunkTuple<int, float> tuple = new ChunkTuple<int, float> {Span1 = a1.AsSpan(), Span2 = a2.AsSpan()};

            tuple.Deconstruct(out Span<int> s1, out Span<float> s2);
            s1[1] = 77;
            s2[0] = 9;

            Assert.Equal(77, tuple.Span1[1]);
            Assert.Equal(9, tuple.Span2[0]);
        }

        /// <summary>
        ///     Tests that chunk tuple 3 deconstruct returns mapped spans
        /// </summary>
        [Fact]
        public void ChunkTuple3_Deconstruct_ReturnsMappedSpans()
        {
            int[] a1 = [1];
            int[] a2 = [2];
            int[] a3 = [3];
            ChunkTuple<int, int, int> tuple = new ChunkTuple<int, int, int>
                {Span1 = a1.AsSpan(), Span2 = a2.AsSpan(), Span3 = a3.AsSpan()};

            tuple.Deconstruct(out Span<int> s1, out Span<int> s2, out Span<int> s3);
            s1[0] = 10;
            s2[0] = 20;
            s3[0] = 30;

            Assert.Equal(10, tuple.Span1[0]);
            Assert.Equal(20, tuple.Span2[0]);
            Assert.Equal(30, tuple.Span3[0]);
        }

        /// <summary>
        ///     Tests that chunk tuple 4 deconstruct returns mapped spans
        /// </summary>
        [Fact]
        public void ChunkTuple4_Deconstruct_ReturnsMappedSpans()
        {
            int[] a1 = [1];
            int[] a2 = [2];
            int[] a3 = [3];
            int[] a4 = [4];
            ChunkTuple<int, int, int, int> tuple = new ChunkTuple<int, int, int, int>
            {
                Span1 = a1.AsSpan(), Span2 = a2.AsSpan(), Span3 = a3.AsSpan(), Span4 = a4.AsSpan()
            };

            tuple.Deconstruct(out Span<int> s1, out Span<int> s2, out Span<int> s3, out Span<int> s4);
            s4[0] = 40;

            Assert.Equal(40, tuple.Span4[0]);
            Assert.Equal(1, s1[0]);
            Assert.Equal(2, s2[0]);
            Assert.Equal(3, s3[0]);
        }

        /// <summary>
        ///     Tests that chunk tuple 5 deconstruct returns mapped spans
        /// </summary>
        [Fact]
        public void ChunkTuple5_Deconstruct_ReturnsMappedSpans()
        {
            int[] a1 = [1];
            int[] a2 = [2];
            int[] a3 = [3];
            int[] a4 = [4];
            int[] a5 = [5];
            ChunkTuple<int, int, int, int, int> tuple = new ChunkTuple<int, int, int, int, int>
            {
                Span1 = a1.AsSpan(), Span2 = a2.AsSpan(), Span3 = a3.AsSpan(), Span4 = a4.AsSpan(), Span5 = a5.AsSpan()
            };

            tuple.Deconstruct(out Span<int> s1, out Span<int> s2, out Span<int> s3, out Span<int> s4, out Span<int> s5);
            s5[0] = 50;

            Assert.Equal(50, tuple.Span5[0]);
            Assert.Equal(1, s1[0]);
            Assert.Equal(2, s2[0]);
            Assert.Equal(3, s3[0]);
            Assert.Equal(4, s4[0]);
        }

        /// <summary>
        ///     Tests that chunk tuple 6 deconstruct returns mapped spans
        /// </summary>
        [Fact]
        public void ChunkTuple6_Deconstruct_ReturnsMappedSpans()
        {
            int[] a1 = [1];
            int[] a2 = [2];
            int[] a3 = [3];
            int[] a4 = [4];
            int[] a5 = [5];
            int[] a6 = [6];
            ChunkTuple<int, int, int, int, int, int> tuple = new ChunkTuple<int, int, int, int, int, int>
            {
                Span1 = a1.AsSpan(), Span2 = a2.AsSpan(), Span3 = a3.AsSpan(), Span4 = a4.AsSpan(), Span5 = a5.AsSpan(),
                Span6 = a6.AsSpan()
            };

            tuple.Deconstruct(out Span<int> s1, out Span<int> s2, out Span<int> s3, out Span<int> s4, out Span<int> s5,
                out Span<int> s6);
            s6[0] = 60;

            Assert.Equal(60, tuple.Span6[0]);
            Assert.Equal(1, s1[0]);
            Assert.Equal(2, s2[0]);
            Assert.Equal(3, s3[0]);
            Assert.Equal(4, s4[0]);
            Assert.Equal(5, s5[0]);
        }

        /// <summary>
        ///     Tests that chunk tuple 7 deconstruct returns mapped spans
        /// </summary>
        [Fact]
        public void ChunkTuple7_Deconstruct_ReturnsMappedSpans()
        {
            int[] a1 = [1];
            int[] a2 = [2];
            int[] a3 = [3];
            int[] a4 = [4];
            int[] a5 = [5];
            int[] a6 = [6];
            int[] a7 = [7];
            ChunkTuple<int, int, int, int, int, int, int> tuple = new ChunkTuple<int, int, int, int, int, int, int>
            {
                Span1 = a1.AsSpan(), Span2 = a2.AsSpan(), Span3 = a3.AsSpan(), Span4 = a4.AsSpan(), Span5 = a5.AsSpan(),
                Span6 = a6.AsSpan(), Span7 = a7.AsSpan()
            };

            tuple.Deconstruct(out Span<int> s1, out Span<int> s2, out Span<int> s3, out Span<int> s4, out Span<int> s5,
                out Span<int> s6, out Span<int> s7);
            s7[0] = 70;

            Assert.Equal(70, tuple.Span7[0]);
            Assert.Equal(1, s1[0]);
            Assert.Equal(2, s2[0]);
            Assert.Equal(3, s3[0]);
            Assert.Equal(4, s4[0]);
            Assert.Equal(5, s5[0]);
            Assert.Equal(6, s6[0]);
        }

        /// <summary>
        ///     Tests that chunk tuple 8 deconstruct returns mapped spans
        /// </summary>
        [Fact]
        public void ChunkTuple8_Deconstruct_ReturnsMappedSpans()
        {
            int[] a1 = [1];
            int[] a2 = [2];
            int[] a3 = [3];
            int[] a4 = [4];
            int[] a5 = [5];
            int[] a6 = [6];
            int[] a7 = [7];
            int[] a8 = [8];
            ChunkTuple<int, int, int, int, int, int, int, int> tuple = new ChunkTuple<int, int, int, int, int, int, int, int>
            {
                Span1 = a1.AsSpan(), Span2 = a2.AsSpan(), Span3 = a3.AsSpan(), Span4 = a4.AsSpan(), Span5 = a5.AsSpan(),
                Span6 = a6.AsSpan(), Span7 = a7.AsSpan(), Span8 = a8.AsSpan()
            };

            tuple.Deconstruct(out Span<int> s1, out Span<int> s2, out Span<int> s3, out Span<int> s4, out Span<int> s5,
                out Span<int> s6, out Span<int> s7, out Span<int> s8);
            s8[0] = 80;

            Assert.Equal(80, tuple.Span8[0]);
            Assert.Equal(1, s1[0]);
            Assert.Equal(2, s2[0]);
            Assert.Equal(3, s3[0]);
            Assert.Equal(4, s4[0]);
            Assert.Equal(5, s5[0]);
            Assert.Equal(6, s6[0]);
            Assert.Equal(7, s7[0]);
        }
    }
}