using Alis.Core.Aspect.Math;
using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    /// The hash code test class
    /// </summary>
    public class HashCodeTest
    {
        /// <summary>
        /// Tests that combine with same inputs is deterministic
        /// </summary>
        [Fact]
        public void Combine_WithSameInputs_IsDeterministic()
        {
            int first = HashCode.Combine(1, "abc", 42f);
            int second = HashCode.Combine(1, "abc", 42f);

            Assert.Equal(first, second);
        }

        /// <summary>
        /// Tests that combine with null inputs does not throw
        /// </summary>
        [Fact]
        public void Combine_WithNullInputs_DoesNotThrow()
        {
            int value = HashCode.Combine<string, string, object>(null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that combine overloads from 1 to 8 are callable and stable
        /// </summary>
        [Fact]
        public void Combine_OverloadsFrom1To8_AreCallableAndStable()
        {
            Assert.Equal(HashCode.Combine(1), HashCode.Combine(1));
            Assert.Equal(HashCode.Combine(1, 2), HashCode.Combine(1, 2));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4), HashCode.Combine(1, 2, 3, 4));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5), HashCode.Combine(1, 2, 3, 4, 5));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5, 6), HashCode.Combine(1, 2, 3, 4, 5, 6));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5, 6, 7), HashCode.Combine(1, 2, 3, 4, 5, 6, 7));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5, 6, 7, 8), HashCode.Combine(1, 2, 3, 4, 5, 6, 7, 8));
        }

        /// <summary>
        /// Tests that add and to hash code with same sequence is deterministic
        /// </summary>
        [Fact]
        public void AddAndToHashCode_WithSameSequence_IsDeterministic()
        {
            HashCode first = new HashCode();
            first.Add("a");
            first.Add(10);
            first.Add(20f);

            HashCode second = new HashCode();
            second.Add("a");
            second.Add(10);
            second.Add(20f);

            Assert.Equal(first.ToHashCode(), second.ToHashCode());
        }

        /// <summary>
        /// Tests that rotate left rotates bits as expected
        /// </summary>
        [Fact]
        public void RotateLeft_RotatesBitsAsExpected()
        {
            uint rotated = HashCode.RotateLeft(1u, 1);

            Assert.Equal(2u, rotated);
        }

        /// <summary>
        /// Tests that add changing order changes hash
        /// </summary>
        [Fact]
        public void Add_ChangingOrder_ChangesHash()
        {
            HashCode first = new HashCode();
            first.Add(1);
            first.Add(2);
            first.Add(3);

            HashCode second = new HashCode();
            second.Add(3);
            second.Add(2);
            second.Add(1);

            Assert.NotEqual(first.ToHashCode(), second.ToHashCode());
        }

        /// <summary>
        /// Tests that to hash code without adds is deterministic per process
        /// </summary>
        [Fact]
        public void ToHashCode_WithoutAdds_IsDeterministicPerProcess()
        {
            HashCode first = new HashCode();
            HashCode second = new HashCode();

            Assert.Equal(first.ToHashCode(), second.ToHashCode());
        }

        /// <summary>
        /// Tests that rotate left with edge offsets returns expected value
        /// </summary>
        [Fact]
        public void RotateLeft_WithEdgeOffsets_ReturnsExpectedValue()
        {
            uint value = 0x80000001;

            Assert.Equal(value, HashCode.RotateLeft(value, 0));
            Assert.Equal(0xC0000000u, HashCode.RotateLeft(0x60000000u, 1));
            Assert.Equal(0xC0000000u, HashCode.RotateLeft(0x80000001u, 31));
        }
    }
}
