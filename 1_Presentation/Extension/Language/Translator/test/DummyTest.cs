

using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    /// <summary>
    ///     Tests for Lang and translation exceptions
    /// </summary>
    public class LangAndExceptionTest
    {
        /// <summary>
        ///     Tests that NativeName and CultureCode can be assigned and read
        /// </summary>
        [Fact]
        public void Lang_SetNativeAndCulture_ShouldPersistValues()
        {
            Lang lang = new Lang("en", "English")
            {
                NativeName = "English",
                CultureCode = "en-US"
            };

            Assert.Equal("English", lang.NativeName);
            Assert.Equal("en-US", lang.CultureCode);
        }

        /// <summary>
        ///     Tests that TranslationNotFound message contains the requested key
        /// </summary>
        [Fact]
        public void TranslationNotFound_Constructor_ShouldBuildExpectedMessage()
        {
            TranslationNotFound exception = new TranslationNotFound("menu.play");

            Assert.Contains("menu.play", exception.Message);
        }
    }
}