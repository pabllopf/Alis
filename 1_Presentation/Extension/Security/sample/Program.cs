

namespace Alis.Extension.Security.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            SecureDouble secureDouble = 10.0;
            secureDouble += 20.0;

            SecureFloat secureFloat = 10.0f;
            secureFloat += 20.0f;

            SecureInt secureInt = 10;
            secureInt += 20;

            SecureLong secureLong = 10L;
            secureLong += 20L;

            SecureDecimal secureDecimal = 10.0m;
            secureDecimal += 20.0m;

            SecureString secureString = new SecureString("Hello");

            SecureChar secureChar = new SecureChar('W');
            secureChar = 'W';
        }
    }
}