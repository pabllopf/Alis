

using Xunit;

namespace Alis.Extension.Security.Test
{
    /// <summary>
    ///     The secure long tests class
    /// </summary>
    public class SecureLongTests
    {
        /// <summary>
        ///     Tests that test secure long constructor
        /// </summary>
        [Fact]
        public void Test_SecureLong_Constructor()
        {
            SecureLong secureLong = new SecureLong(10L);
            Assert.Equal(10L, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test secure long implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureLong_ImplicitConversion()
        {
            SecureLong secureLong = 10L;
            Assert.Equal(10L, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test secure long equality operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_EqualityOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 10L;
            Assert.True(secureLong1 == secureLong2);

            secureLong2 = 20L;
            Assert.False(secureLong1 == secureLong2);
        }

        /// <summary>
        ///     Tests that test secure long inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_InequalityOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 20L;
            Assert.True(secureLong1 != secureLong2);

            secureLong2 = 10L;
            Assert.False(secureLong1 != secureLong2);
        }

        /// <summary>
        ///     Tests that test secure long addition operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_AdditionOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 20L;
            Assert.Equal(30L, (long) (secureLong1 + secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_SubtractionOperator()
        {
            SecureLong secureLong1 = 20L;
            SecureLong secureLong2 = 10L;
            Assert.Equal(10L, (long) (secureLong1 - secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_MultiplicationOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 20L;
            Assert.Equal(200L, (long) (secureLong1 * secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long division operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_DivisionOperator()
        {
            SecureLong secureLong1 = 20L;
            SecureLong secureLong2 = 10L;
            Assert.Equal(2L, (long) (secureLong1 / secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long equals method
        /// </summary>
        [Fact]
        public void Test_SecureLong_EqualsMethod()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 10L;
            Assert.True(secureLong1.Equals(secureLong2));

            secureLong2 = 20L;
            Assert.False(secureLong1.Equals(secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureLong_GetHashCodeMethod()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 10L;
            Assert.Equal(secureLong1.GetHashCode(), secureLong2.GetHashCode());

            secureLong2 = 20L;
            Assert.NotEqual(secureLong1.GetHashCode(), secureLong2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure long to string method
        /// </summary>
        [Fact]
        public void Test_SecureLong_ToStringMethod()
        {
            SecureLong secureLong = 10L;
            Assert.Equal("10", secureLong.ToString());
        }

        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            SecureLong secureLong = new SecureLong(10);

            long value = secureLong;

            Assert.Equal(10, value);
        }

        /// <summary>
        ///     Tests that test equality
        /// </summary>
        [Fact]
        public void TestEquality()
        {
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(10);

            Assert.True(secureLong1 == secureLong2);
        }

        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(20);

            Assert.True(secureLong1 != secureLong2);
        }

        /// <summary>
        ///     Tests that test increment
        /// </summary>
        [Fact]
        public void TestIncrement()
        {
            SecureLong secureLong = new SecureLong(10);

            secureLong++;

            Assert.Equal(11, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test decrement
        /// </summary>
        [Fact]
        public void TestDecrement()
        {
            SecureLong secureLong = new SecureLong(10);

            secureLong--;

            Assert.Equal(9, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(20);

            SecureLong result = secureLong1 + secureLong2;

            Assert.Equal(30, (long) result);
        }

        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            SecureLong secureLong1 = new SecureLong(20);
            SecureLong secureLong2 = new SecureLong(10);

            SecureLong result = secureLong1 - secureLong2;

            Assert.Equal(10, (long) result);
        }

        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(20);

            SecureLong result = secureLong1 * secureLong2;

            Assert.Equal(200, (long) result);
        }

        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            SecureLong secureLong1 = new SecureLong(20);
            SecureLong secureLong2 = new SecureLong(10);

            SecureLong result = secureLong1 / secureLong2;

            Assert.Equal(2, (long) result);
        }
    }
}