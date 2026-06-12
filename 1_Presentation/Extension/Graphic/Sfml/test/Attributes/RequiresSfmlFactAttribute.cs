using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Attributes
{
    /// <summary>
    /// The requires sfml fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    
    public class RequiresSfmlFactAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiresSfmlFactAttribute"/> class
        /// </summary>
        public RequiresSfmlFactAttribute()
        {
            try
            {
                NativeLibrary.Load("csfml-system");
            }
            catch
            {
                Skip = "SFML native library (csfml-system) not detected. Install SFML to run this test.";
            }
        }
    }
}
