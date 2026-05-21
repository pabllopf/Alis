

using System;
using Alis.Core.Aspect.Logging;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     The dialog test class
    /// </summary>
    public class DialogTest
    {
        /// <summary>
        ///     Tests that dialog constructor should initialize properties
        /// </summary>
        [Fact]
        public void Dialog_Constructor_ShouldInitializeProperties()
        {
            string id = "testId";
            string text = "Test Text";
            Dialog dialog = new Dialog(id, text);

            Assert.Equal(id, dialog.Id);
            Assert.Equal(text, dialog.Text);
            Assert.Empty(dialog.Options);
            Assert.Empty(dialog.Branches);
        }

        /// <summary>
        ///     Tests that add option should add option to list
        /// </summary>
        [Fact]
        public void AddOption_ShouldAddOptionToList()
        {
            Dialog dialog = new Dialog("testId", "Test Text");
            DialogOption option = new DialogOption("Option Text", () => Logger.Info("Test Action"));
            dialog.AddOption(option);

            Assert.Single(dialog.Options);
            Assert.Contains(option, dialog.Options);
        }

        /// <summary>
        ///     Tests that dialog option constructor should initialize properties
        /// </summary>
        [Fact]
        public void DialogOption_Constructor_ShouldInitializeProperties()
        {
            string text = "Option Text";
            Action action = () => Logger.Info("Test Action");
            DialogOption option = new DialogOption(text, action);

            Assert.Equal(text, option.Text);
            Assert.Equal(action, option.Action);
        }

        /// <summary>
        ///     Tests that parent dialog id can be assigned and read
        /// </summary>
        [Fact]
        public void ParentDialogId_SetterGetter_ShouldPersistValue()
        {
            Dialog dialog = new Dialog("child", "Child dialog")
            {
                ParentDialogId = "root"
            };

            Assert.Equal("root", dialog.ParentDialogId);
        }

        /// <summary>
        ///     Tests that adding a null option does not change the options collection
        /// </summary>
        [Fact]
        public void AddOption_WithNull_ShouldNotModifyOptions()
        {
            Dialog dialog = new Dialog("testId", "Test Text");

            dialog.AddOption(null);

            Assert.Empty(dialog.Options);
        }
    }
}