using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Attributes
{
    [ExcludeFromCodeCoverage]
    public class RequiresSfmlFactAttribute : FactAttribute
    {
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
