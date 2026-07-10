using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class BrowserPlayerEdgeCaseTests
    {
        [Fact]
        public void SetVolume_ShouldReturnCompletedTask()
        {
            BrowserPlayer player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            Task result = player.SetVolume(50);

            Assert.Equal(Task.CompletedTask, result);
        }

        [Fact]
        public void SetVolume_WithZero_ShouldReturnCompletedTask()
        {
            BrowserPlayer player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            Task result = player.SetVolume(0);

            Assert.Equal(Task.CompletedTask, result);
        }

        [Fact]
        public void SetVolume_WithMaxValue_ShouldReturnCompletedTask()
        {
            BrowserPlayer player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            Task result = player.SetVolume(255);

            Assert.Equal(Task.CompletedTask, result);
        }

        [Fact]
        public void GetFormat_WithZeroBitsAndZeroChannels_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(0, 0, out int format);

            Assert.False(result);
            Assert.Equal(0, format);
        }

        [Fact]
        public void GetFormat_WithNegativeBits_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(-1, 1, out int format);

            Assert.False(result);
            Assert.Equal(0, format);
        }

        [Fact]
        public void FindFmtChunk_WithNullArray_ShouldThrowNullReferenceException()
        {
            int fmtPos = 12;

            Assert.Throws<NullReferenceException>(() => BrowserPlayer.FindFmtChunk(null, ref fmtPos));
        }

        [Fact]
        public void FindDataChunk_WithNullArray_ShouldThrowNullReferenceException()
        {
            int pos = 12;

            Assert.Throws<NullReferenceException>(() => BrowserPlayer.FindDataChunk(null, ref pos, out int _, out int _));
        }
    }
}
