using System;
using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui.Fonts;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Fonts
{
    /// <summary>
    /// Provides unit coverage for <see cref="FontAwesome5"/> constants.
    /// </summary>
    public class FontAwesome5Test
    {
        /// <summary>
        /// Verifies that the type is generated as a static class.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStaticClass()
        {
            Type type = typeof(FontAwesome5);

            Assert.True(type.IsClass);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        /// Verifies that font file names are set and end with .ttf.
        /// </summary>
        [Fact]
        public void FontNames_ShouldBeTtfFiles()
        {
            Assert.EndsWith(".ttf", FontAwesome5.NameRegular, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", FontAwesome5.NameSolid, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", FontAwesome5.NameLight, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Verifies icon range constants are coherent.
        /// </summary>
        [Fact]
        public void IconRange_ShouldBeCoherent()
        {
            Assert.True(FontAwesome5.IconMin > 0);
            Assert.True(FontAwesome5.IconMax >= FontAwesome5.IconMin);
            Assert.Equal(FontAwesome5.IconMax, FontAwesome5.IconMax16);
        }

        /// <summary>
        /// Verifies that icon string catalog remains broad and non-empty.
        /// </summary>
        [Fact]
        public void IconCatalog_ShouldContainManyNonEmptyConstants()
        {
            FieldInfo[] iconFields = typeof(FontAwesome5)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(field => field.FieldType == typeof(string))
                .Where(field => field.Name != nameof(FontAwesome5.NameRegular))
                .Where(field => field.Name != nameof(FontAwesome5.NameSolid))
                .Where(field => field.Name != nameof(FontAwesome5.NameLight))
                .ToArray();

            Assert.True(iconFields.Length > 300);

            foreach (FieldInfo field in iconFields)
            {
                string value = field.GetValue(null) as string;
                Assert.False(string.IsNullOrWhiteSpace(value));
            }
        }

        /// <summary>
        /// Verifies a representative subset of known icon constants.
        /// </summary>
        [Fact]
        public void RepresentativeIcons_ShouldMatchExpectedGlyphs()
        {
            Assert.Equal("\uf641", FontAwesome5.Ad);
            Assert.Equal("\uf2b9", FontAwesome5.AddressBook);
            Assert.Equal("\uf2bb", FontAwesome5.AddressCard);
            Assert.Equal("\uf042", FontAwesome5.Adjust);
        }
    }
}
