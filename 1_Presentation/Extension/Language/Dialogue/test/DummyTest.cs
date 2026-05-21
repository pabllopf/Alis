

using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Additional guard-clause tests for dialog lookups
    /// </summary>
    public class DialogManagerLookupTest
    {
        /// <summary>
        ///     Tests that GetDialog returns null for null ids
        /// </summary>
        [Fact]
        public void GetDialog_WithNullId_ShouldReturnNull()
        {
            DialogManager manager = new DialogManager();

            Dialog result = manager.GetDialog(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetDialog returns null for whitespace ids
        /// </summary>
        [Fact]
        public void GetDialog_WithWhitespaceId_ShouldReturnNull()
        {
            DialogManager manager = new DialogManager();

            Dialog result = manager.GetDialog("   ");

            Assert.Null(result);
        }
    }
}