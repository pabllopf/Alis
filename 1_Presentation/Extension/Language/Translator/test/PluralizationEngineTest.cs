

using System;
using Alis.Extension.Language.Translator.Pluralization;
using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    /// <summary>
    ///     Tests for the PluralizationEngine class
    /// </summary>
    public class PluralizationEngineTest
    {
        /// <summary>
        ///     Tests that English pluralization returns singular form for 1
        /// </summary>
        [Fact]
        public void GetPluralForm_EnglishWithOne_ShouldReturnSingular()
        {
            PluralizationEngine engine = new PluralizationEngine();

            int form = engine.GetPluralForm("en", 1);

            Assert.Equal(0, form);
        }

        /// <summary>
        ///     Tests that English pluralization returns plural form for other quantities
        /// </summary>
        [Theory, InlineData(0), InlineData(2), InlineData(5), InlineData(100)]
        public void GetPluralForm_EnglishWithMultiple_ShouldReturnPlural(int quantity)
        {
            PluralizationEngine engine = new PluralizationEngine();

            int form = engine.GetPluralForm("en", quantity);

            Assert.Equal(1, form);
        }

        /// <summary>
        ///     Tests that Spanish pluralization works correctly
        /// </summary>
        [Theory, InlineData(1, 0), InlineData(2, 1), InlineData(0, 1)]
        public void GetPluralForm_Spanish_ShouldWorkCorrectly(int quantity, int expected)
        {
            PluralizationEngine engine = new PluralizationEngine();

            int form = engine.GetPluralForm("es", quantity);

            Assert.Equal(expected, form);
        }

        /// <summary>
        ///     Tests that Russian pluralization returns correct forms
        /// </summary>
        [Theory, InlineData(1, 0), InlineData(21, 0), InlineData(2, 1), InlineData(5, 2), InlineData(0, 2)]
        public void GetPluralForm_Russian_ShouldReturnCorrectForm(int quantity, int expected)
        {
            PluralizationEngine engine = new PluralizationEngine();

            int form = engine.GetPluralForm("ru", quantity);

            Assert.Equal(expected, form);
        }

        /// <summary>
        ///     Tests Russian teen-number edge cases that map to the many form
        /// </summary>
        [Theory, InlineData(11), InlineData(12), InlineData(19), InlineData(111)]
        public void GetPluralForm_RussianTeenValues_ShouldReturnMany(int quantity)
        {
            PluralizationEngine engine = new PluralizationEngine();

            int form = engine.GetPluralForm("ru", quantity);

            Assert.Equal(2, form);
        }

        /// <summary>
        ///     Tests Polish pluralization branches including singular, few and many forms
        /// </summary>
        [Theory, InlineData(1, 0), InlineData(2, 1), InlineData(4, 1), InlineData(5, 2), InlineData(12, 1), InlineData(0, 2)]
        public void GetPluralForm_Polish_ShouldReturnExpectedForm(int quantity, int expected)
        {
            PluralizationEngine engine = new PluralizationEngine();

            int form = engine.GetPluralForm("pl", quantity);

            Assert.Equal(expected, form);
        }

        /// <summary>
        ///     Tests that Japanese has no pluralization
        /// </summary>
        [Theory, InlineData(0), InlineData(1), InlineData(100)]
        public void GetPluralForm_Japanese_ShouldAlwaysReturnZero(int quantity)
        {
            PluralizationEngine engine = new PluralizationEngine();

            int form = engine.GetPluralForm("ja", quantity);

            Assert.Equal(0, form);
        }

        /// <summary>
        ///     Tests that RegisterPluralizationRule adds custom rule
        /// </summary>
        [Fact]
        public void RegisterPluralizationRule_WithCustomRule_ShouldUseCustomRule()
        {
            PluralizationEngine engine = new PluralizationEngine();
            Func<int, int> customRule = q => q % 2 == 0 ? 0 : 1;

            engine.RegisterPluralizationRule("custom", customRule);
            int form = engine.GetPluralForm("custom", 4);

            Assert.Equal(0, form);
        }

        /// <summary>
        ///     Tests that RegisterPluralizationRule with null rule throws exception
        /// </summary>
        [Fact]
        public void RegisterPluralizationRule_WithNullRule_ShouldThrowException()
        {
            PluralizationEngine engine = new PluralizationEngine();

            Assert.Throws<ArgumentNullException>(() => engine.RegisterPluralizationRule("test", null));
        }

        /// <summary>
        ///     Tests that GetPluralFormCount returns correct counts
        /// </summary>
        [Theory, InlineData("en", 2), InlineData("es", 2), InlineData("ru", 3), InlineData("ja", 1)]
        public void GetPluralFormCount_ShouldReturnCorrectCount(string languageCode, int expectedCount)
        {
            PluralizationEngine engine = new PluralizationEngine();

            int count = engine.GetPluralFormCount(languageCode);

            Assert.Equal(expectedCount, count);
        }

        /// <summary>
        ///     Tests that GetPluralForm with null language code throws exception
        /// </summary>
        [Fact]
        public void GetPluralForm_WithNullLanguageCode_ShouldThrowException()
        {
            PluralizationEngine engine = new PluralizationEngine();

            Assert.Throws<ArgumentException>(() => engine.GetPluralForm(null, 1));
        }
    }
}