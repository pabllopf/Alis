

using Xunit;

namespace Alis.Extension.Security.Test
{
    /// <summary>
    ///     The secure string tests class
    /// </summary>
    public class SecureStringTests
    {
        /// <summary>
        ///     Tests that test set value get value
        /// </summary>
        [Fact]
        public void TestSetValueGetValue()
        {
            SecureString secureString = new SecureString("test");

            string value = secureString.GetValue();

            Assert.Equal("test", value);
        }

        /// <summary>
        ///     Tests that test encryption decryption
        /// </summary>
        [Fact]
        public void TestEncryptionDecryption()
        {
            SecureString secureString = new SecureString("test");

            secureString.SetValue("newTest");
            string value = secureString.GetValue();

            Assert.Equal("newTest", value);
        }

        /// <summary>
        ///     Tests that test different instances
        /// </summary>
        [Fact]
        public void TestDifferentInstances()
        {
            SecureString secureString1 = new SecureString("test");
            SecureString secureString2 = new SecureString("test");

            string value1 = secureString1.GetValue();
            string value2 = secureString2.GetValue();

            Assert.Equal(value1, value2);
        }
    }
}