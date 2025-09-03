using Xunit;
using Alis.Extension.Graphic.Sfml.Audios;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound status tests class
    /// </summary>
    public class SoundStatusTests
    {
        /// <summary>
        /// Tests that enum values are unique
        /// </summary>
        [Fact]
        public void Enum_Values_AreUnique()
        {
            int[] values = (int[])System.Enum.GetValues(typeof(SoundStatus));
            Assert.Equal(values.Length, new System.Collections.Generic.HashSet<int>(values).Count);
        }
    }
}

