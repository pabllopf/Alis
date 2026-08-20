// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayerOpenAlFrameworkTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The browser player open al framework tests class
    /// </summary>
    public class BrowserPlayerOpenAlFrameworkTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BrowserPlayerOpenAlFrameworkTests"/> class
        /// </summary>
        static BrowserPlayerOpenAlFrameworkTests()
        {
            NativeLibrary.SetDllImportResolver(typeof(BrowserPlayer).Assembly, ResolveOpenAlLibrary);
        }

        /// <summary>
        ///     Resolves the open al library to the platform OpenAL framework when available.
        /// </summary>
        /// <param name="libraryName">The library name</param>
        /// <param name="assembly">The assembly</param>
        /// <param name="searchPath">The search path</param>
        /// <returns>The native handle</returns>
        private static IntPtr ResolveOpenAlLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName != "openal32")
            {
                return IntPtr.Zero;
            }

            if (NativeLibrary.TryLoad("/System/Library/Frameworks/OpenAL.framework/OpenAL", out IntPtr frameworkHandle))
            {
                return frameworkHandle;
            }

            if (NativeLibrary.TryLoad("libopenal.1.dylib", out IntPtr brewHandle))
            {
                return brewHandle;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        ///     Tests that the constructor initializes the player successfully when OpenAL is available.
        /// </summary>
        [BrowserOnly]
        public void Constructor_WithOpenAlAvailable_InitializesPlayer()
        {
            BrowserPlayer player = new BrowserPlayer();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
            Assert.NotEqual(0u, player._buffer);
            Assert.NotEqual(0u, player._source);
        }

        /// <summary>
        ///     Tests that pause sets the paused flag and clears the playing flag.
        /// </summary>
         [BrowserOnly]
        public void Pause_WithInitializedPlayer_SetsPausedTrue()
        {
            BrowserPlayer player = new BrowserPlayer();

            Task task = player.Pause();

            Assert.True(task.IsCompleted);
            Assert.True(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that resume sets the playing flag and clears the paused flag.
        /// </summary>
         [BrowserOnly]
        public void Resume_WithInitializedPlayer_SetsPlayingTrue()
        {
            BrowserPlayer player = new BrowserPlayer();

            Task task = player.Resume();

            Assert.True(task.IsCompleted);
            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that stop clears both the playing and paused flags.
        /// </summary>
         [BrowserOnly]
        public void Stop_WithInitializedPlayer_SetsBothFalse()
        {
            BrowserPlayer player = new BrowserPlayer();

            Task task = player.Stop();

            Assert.True(task.IsCompleted);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that set volume returns a completed task.
        /// </summary>
         [BrowserOnly]
        public void SetVolume_WithInitializedPlayer_ReturnsCompletedTask()
        {
            BrowserPlayer player = new BrowserPlayer();

            Task task = player.SetVolume(75);

            Assert.Same(Task.CompletedTask, task);
        }

        /// <summary>
        ///     Tests that play with a valid wav asset buffers and plays the audio.
        /// </summary>
         [BrowserOnly]
        public async Task Play_WithValidWavAsset_PlaysAudio()
        {
            BrowserPlayer player = new BrowserPlayer();
            bool finished = false;
            player.PlaybackFinished += (sender, e) => finished = true;

            await player.Play("sample_1.wav");

            Assert.True(player.Playing);
            Assert.False(player.Paused);
            Assert.True(finished);
        }

        /// <summary>
        ///     Tests that play with an invalid wav asset throws an invalid operation exception.
        /// </summary>
         [BrowserOnly]
        public async Task Play_WithInvalidWavAsset_ThrowsInvalidOperationException()
        {
            byte[] garbage = Encoding.ASCII.GetBytes("this is not a wav file at all");
            BrowserPlayer player = new BrowserPlayer();

            try
            {
                AssetRegistry.RegisterAssembly("Alis.Core.Audio.Test", () => new MemoryStream(CreateZipWithEntry("bad.wav", garbage), false));

                await Assert.ThrowsAsync<InvalidOperationException>(() => player.Play("bad.wav"));
            }
            finally
            {
                AssetRegistry.RegisterAssembly("Alis.Core.Audio.Test", Alis.Core.Aspect.Memory.Generator.ResourceAnchor.LoadAsset);
            }
        }

        /// <summary>
        ///     Tests that play loop delegates to play and plays the audio.
        /// </summary>
         [BrowserOnly]
        public async Task PlayLoop_WithValidWavAsset_PlaysAudio()
        {
            BrowserPlayer player = new BrowserPlayer();

            await player.PlayLoop("sample_2.wav", true);

            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Creates a zip archive containing a single entry.
        /// </summary>
        /// <param name="entryName">The entry name</param>
        /// <param name="content">The content</param>
        /// <returns>The zip bytes</returns>
        private static byte[] CreateZipWithEntry(string entryName, byte[] content)
        {
            using MemoryStream zipMs = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(zipMs, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                using (Stream entryStream = entry.Open())
                {
                    entryStream.Write(content, 0, content.Length);
                }
            }

            return zipMs.ToArray();
        }
    }
}