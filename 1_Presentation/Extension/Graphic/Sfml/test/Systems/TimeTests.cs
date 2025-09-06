using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    public class TimeTests
    {
        [Fact]
        public void Zero_IsZero()
        {
            Assert.Equal(0, Time.Zero.AsMicroseconds());
        }

        [Fact]
        public void FromSeconds_CreatesCorrectTime()
        {
            Time t = Time.FromSeconds(2.5f);
            Assert.True(Math.Abs(t.AsSeconds() - 2.5f) < 0.001);
        }

        [Fact]
        public void FromMilliseconds_CreatesCorrectTime()
        {
            Time t = Time.FromMilliseconds(1500);
            Assert.Equal(1500, t.AsMilliseconds());
        }

        [Fact]
        public void FromMicroseconds_CreatesCorrectTime()
        {
            Time t = Time.FromMicroseconds(1234567);
            Assert.Equal(1234567, t.AsMicroseconds());
        }

        [Fact]
        public void Equality_Operators_Work()
        {
            Time t1 = Time.FromMilliseconds(1000);
            Time t2 = Time.FromSeconds(1);
            Assert.True(t1 == t2);
            Assert.False(t1 != t2);
        }

        [Fact]
        public void Comparison_Operators_Work()
        {
            Time t1 = Time.FromMilliseconds(500);
            Time t2 = Time.FromMilliseconds(1000);
            Assert.True(t1 < t2);
            Assert.True(t2 > t1);
            Assert.True(t1 <= t2);
            Assert.True(t2 >= t1);
        }

        [Fact]
        public void Arithmetic_Operators_Work()
        {
            Time t1 = Time.FromMilliseconds(1000);
            Time t2 = Time.FromMilliseconds(500);
            Assert.Equal(1500, (t1 + t2).AsMilliseconds());
            Assert.Equal(500, (t1 - t2).AsMilliseconds());
            Assert.Equal(2000, (t2 * 4).AsMilliseconds());
            Assert.Equal(250, (t1 / 4).AsMilliseconds());
        }

        [Fact]
        public void Modulo_Operator_Works()
        {
            Time t1 = Time.FromMilliseconds(1050);
            Time t2 = Time.FromMilliseconds(1000);
            Assert.Equal(50, (t1 % t2).AsMilliseconds());
        }

        [Fact]
        public void GetHashCode_IsConsistent()
        {
            Time t1 = Time.FromMilliseconds(1234);
            Time t2 = Time.FromMilliseconds(1234);
            Assert.Equal(t1.GetHashCode(), t2.GetHashCode());
        }
    }
}

