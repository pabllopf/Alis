

using Xunit;

namespace Alis.Extension.Security.Test
{
    /// <summary>
    ///     The secure int tests class
    /// </summary>
    public class SecureIntTests
    {
        /// <summary>
        ///     Tests that test secure int constructor
        /// </summary>
        [Fact]
        public void Test_SecureInt_Constructor()
        {
            SecureInt secureInt = new SecureInt(10);
            Assert.Equal(10, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test secure int implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureInt_ImplicitConversion()
        {
            SecureInt secureInt = 10;
            Assert.Equal(10, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test secure int equality operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_EqualityOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 10;
            Assert.True(secureInt1 == secureInt2);

            secureInt2 = 20;
            Assert.False(secureInt1 == secureInt2);
        }

        /// <summary>
        ///     Tests that test secure int inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_InequalityOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 20;
            Assert.True(secureInt1 != secureInt2);

            secureInt2 = 10;
            Assert.False(secureInt1 != secureInt2);
        }

        /// <summary>
        ///     Tests that test secure int addition operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_AdditionOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 20;
            Assert.Equal(30, (int) (secureInt1 + secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_SubtractionOperator()
        {
            SecureInt secureInt1 = 20;
            SecureInt secureInt2 = 10;
            Assert.Equal(10, (int) (secureInt1 - secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_MultiplicationOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 20;
            Assert.Equal(200, (int) (secureInt1 * secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int division operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_DivisionOperator()
        {
            SecureInt secureInt1 = 20;
            SecureInt secureInt2 = 10;
            Assert.Equal(2, (int) (secureInt1 / secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int equals method
        /// </summary>
        [Fact]
        public void Test_SecureInt_EqualsMethod()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 10;
            Assert.True(secureInt1.Equals(secureInt2));

            secureInt2 = 20;
            Assert.False(secureInt1.Equals(secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureInt_GetHashCodeMethod()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 10;
            Assert.Equal(secureInt1.GetHashCode(), secureInt2.GetHashCode());

            secureInt2 = 20;
            Assert.NotEqual(secureInt1.GetHashCode(), secureInt2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure int to string method
        /// </summary>
        [Fact]
        public void Test_SecureInt_ToStringMethod()
        {
            SecureInt secureInt = 10;
            Assert.Equal("10", secureInt.ToString());
        }

        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            SecureInt secureInt = new SecureInt(10);

            int value = secureInt;

            Assert.Equal(10, value);
        }

        /// <summary>
        ///     Tests that test equality
        /// </summary>
        [Fact]
        public void TestEquality()
        {
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(10);

            Assert.True(secureInt1 == secureInt2);
        }

        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(20);

            Assert.True(secureInt1 != secureInt2);
        }

        /// <summary>
        ///     Tests that test increment
        /// </summary>
        [Fact]
        public void TestIncrement()
        {
            SecureInt secureInt = new SecureInt(10);

            secureInt++;

            Assert.Equal(11, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test decrement
        /// </summary>
        [Fact]
        public void TestDecrement()
        {
            SecureInt secureInt = new SecureInt(10);

            secureInt--;

            Assert.Equal(9, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(20);

            SecureInt result = secureInt1 + secureInt2;

            Assert.Equal(30, (int) result);
        }

        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            SecureInt secureInt1 = new SecureInt(20);
            SecureInt secureInt2 = new SecureInt(10);

            SecureInt result = secureInt1 - secureInt2;

            Assert.Equal(10, (int) result);
        }

        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(20);

            SecureInt result = secureInt1 * secureInt2;

            Assert.Equal(200, (int) result);
        }

        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            SecureInt secureInt1 = new SecureInt(20);
            SecureInt secureInt2 = new SecureInt(10);

            SecureInt result = secureInt1 / secureInt2;

            Assert.Equal(2, (int) result);
        }
    }
}