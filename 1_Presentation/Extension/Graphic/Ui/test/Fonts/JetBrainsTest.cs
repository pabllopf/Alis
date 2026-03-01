using System;
using Alis.Extension.Graphic.Ui.Fonts;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Fonts
{
    /// <summary>
    /// Provides unit coverage for <see cref="JetBrains"/> font constants.
    /// </summary>
    public class JetBrainsTest
    {
        /// <summary>
        /// Verifies that the type is generated as a static class.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStaticClass()
        {
            Type type = typeof(JetBrains);

            Assert.True(type.IsClass);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        /// Verifies that all file names are valid TrueType font files.
        /// </summary>
        [Fact]
        public void FontNames_ShouldBeValidTtfFiles()
        {
            Assert.False(string.IsNullOrWhiteSpace(JetBrains.NameRegular));
            Assert.False(string.IsNullOrWhiteSpace(JetBrains.NameSolid));
            Assert.False(string.IsNullOrWhiteSpace(JetBrains.NameLight));

            Assert.EndsWith(".ttf", JetBrains.NameRegular, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", JetBrains.NameSolid, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", JetBrains.NameLight, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Verifies that regular and light names currently map to the same file.
        /// </summary>
        [Fact]
        public void RegularAndLight_ShouldMatchCurrentDefinition()
        {
            Assert.Equal(JetBrains.NameRegular, JetBrains.NameLight);
        }
    }
}

