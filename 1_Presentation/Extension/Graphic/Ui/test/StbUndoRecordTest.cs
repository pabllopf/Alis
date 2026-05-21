

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The stb undo record test class
    /// </summary>
    public class StbUndoRecordTest
    {
        /// <summary>
        ///     Tests that where should be initialized correctly
        /// </summary>
        [Fact]
        public void Where_ShouldBeInitializedCorrectly()
        {
            StbUndoRecord undoRecord = new StbUndoRecord {Where = 10};

            int where = undoRecord.Where;

            Assert.Equal(10, where);
        }

        /// <summary>
        ///     Tests that insert length should be initialized correctly
        /// </summary>
        [Fact]
        public void InsertLength_ShouldBeInitializedCorrectly()
        {
            StbUndoRecord undoRecord = new StbUndoRecord {InsertLength = 20};

            int insertLength = undoRecord.InsertLength;

            Assert.Equal(20, insertLength);
        }

        /// <summary>
        ///     Tests that delete length should be initialized correctly
        /// </summary>
        [Fact]
        public void DeleteLength_ShouldBeInitializedCorrectly()
        {
            StbUndoRecord undoRecord = new StbUndoRecord {DeleteLength = 30};

            int deleteLength = undoRecord.DeleteLength;

            Assert.Equal(30, deleteLength);
        }

        /// <summary>
        ///     Tests that char storage should be initialized correctly
        /// </summary>
        [Fact]
        public void CharStorage_ShouldBeInitializedCorrectly()
        {
            StbUndoRecord undoRecord = new StbUndoRecord {CharStorage = 40};

            int charStorage = undoRecord.CharStorage;

            Assert.Equal(40, charStorage);
        }
    }
}