using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The browser player edge case tests class
    /// </summary>
    public class BrowserPlayerEdgeCaseTests
    {
        /// <summary>
        /// Tests that set volume should return completed task
        /// </summary>
        [Fact]
        public void SetVolume_ShouldReturnCompletedTask()
        {
            BrowserPlayer player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            Task result = player.SetVolume(50);

            Assert.Equal(Task.CompletedTask, result);
        }

        /// <summary>
        /// Tests that set volume with zero should return completed task
        /// </summary>
        [Fact]
        public void SetVolume_WithZero_ShouldReturnCompletedTask()
        {
            BrowserPlayer player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            Task result = player.SetVolume(0);

            Assert.Equal(Task.CompletedTask, result);
        }

        /// <summary>
        /// Tests that set volume with max value should return completed task
        /// </summary>
        [Fact]
        public void SetVolume_WithMaxValue_ShouldReturnCompletedTask()
        {
            BrowserPlayer player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            Task result = player.SetVolume(255);

            Assert.Equal(Task.CompletedTask, result);
        }

        /// <summary>
        /// Tests that get format with zero bits and zero channels should return false
        /// </summary>
        [Fact]
        public void GetFormat_WithZeroBitsAndZeroChannels_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(0, 0, out int format);

            Assert.False(result);
            Assert.Equal(0, format);
        }

        /// <summary>
        /// Tests that get format with negative bits should return false
        /// </summary>
        [Fact]
        public void GetFormat_WithNegativeBits_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(-1, 1, out int format);

            Assert.False(result);
            Assert.Equal(0, format);
        }

        /// <summary>
        /// Tests that find fmt chunk with null array should throw null reference exception
        /// </summary>
        [Fact]
        public void FindFmtChunk_WithNullArray_ShouldThrowNullReferenceException()
        {
            int fmtPos = 12;

            Assert.Throws<NullReferenceException>(() => BrowserPlayer.FindFmtChunk(null, ref fmtPos));
        }

        /// <summary>
        /// Tests that find data chunk with null array should throw null reference exception
        /// </summary>
        [Fact]
        public void FindDataChunk_WithNullArray_ShouldThrowNullReferenceException()
        {
            int pos = 12;

            Assert.Throws<NullReferenceException>(() => BrowserPlayer.FindDataChunk(null, ref pos, out int _, out int _));
        }
    }
}
