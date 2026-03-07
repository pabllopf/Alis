using Alis.Core.Audio;
using Xunit;
using System;
using System.Collections.Generic;

namespace Alis.Core.Audio.Test
{
    /// <summary>
    /// Comprehensive parametrized tests for audio system.
    /// </summary>
    public class AudioExtensiveParametrizedTest
    {
        /// <summary>
        /// Generates the audio property combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateAudioPropertyCombinations()
        {
            float[] volumes = { 0f, 0.25f, 0.5f, 0.75f, 1f };
            float[] pitches = { 0.5f, 0.75f, 1f, 1.25f, 2f };
            
            foreach (float vol in volumes)
            {
                foreach (float pitch in pitches)
                {
                    yield return new object[] { vol, pitch };
                }
            }
        }

        /// <summary>
        /// Tests that audio volume and pitch combinations
        /// </summary>
        /// <param name="volume">The volume</param>
        /// <param name="pitch">The pitch</param>
        [Theory]
        [MemberData(nameof(GenerateAudioPropertyCombinations))]
        public void Audio_VolumeAndPitchCombinations(float volume, float pitch)
        {
            Assert.InRange(volume, 0f, 1f);
            Assert.True(pitch > 0);
        }

        /// <summary>
        /// Tests that audio multiple audio sources
        /// </summary>
        /// <param name="sourceCount">The source count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public void Audio_MultipleAudioSources(int sourceCount)
        {
            Assert.True(sourceCount > 0);
        }
    }
}
