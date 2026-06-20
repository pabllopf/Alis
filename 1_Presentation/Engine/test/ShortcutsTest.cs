// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShortcutsTest.cs
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

using Alis.App.Engine.Shortcut;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests the <see cref="Shortcuts" /> class.
    /// </summary>
    public class ShortcutsTest
    {
        /// <summary>
        ///     Tests that NewScene has a non-null value.
        /// </summary>
        [Fact]
        public void NewScene_HasValue()
        {
            Assert.NotNull(Shortcuts.NewScene);
            Assert.NotEmpty(Shortcuts.NewScene);
        }

        /// <summary>
        ///     Tests that OpenScene has a non-null value.
        /// </summary>
        [Fact]
        public void OpenScene_HasValue()
        {
            Assert.NotNull(Shortcuts.OpenScene);
            Assert.NotEmpty(Shortcuts.OpenScene);
        }

        /// <summary>
        ///     Tests that Save has a non-null value.
        /// </summary>
        [Fact]
        public void Save_HasValue()
        {
            Assert.NotNull(Shortcuts.Save);
            Assert.NotEmpty(Shortcuts.Save);
        }

        /// <summary>
        ///     Tests that SaveAs has a non-null value.
        /// </summary>
        [Fact]
        public void SaveAs_HasValue()
        {
            Assert.NotNull(Shortcuts.SaveAs);
            Assert.NotEmpty(Shortcuts.SaveAs);
        }

        /// <summary>
        ///     Tests that Undo has a non-null value.
        /// </summary>
        [Fact]
        public void Undo_HasValue()
        {
            Assert.NotNull(Shortcuts.Undo);
            Assert.NotEmpty(Shortcuts.Undo);
        }

        /// <summary>
        ///     Tests that Redo has a non-null value.
        /// </summary>
        [Fact]
        public void Redo_HasValue()
        {
            Assert.NotNull(Shortcuts.Redo);
            Assert.NotEmpty(Shortcuts.Redo);
        }

        /// <summary>
        ///     Tests that Play has a non-null value.
        /// </summary>
        [Fact]
        public void Play_HasValue()
        {
            Assert.NotNull(Shortcuts.Play);
            Assert.NotEmpty(Shortcuts.Play);
        }

        /// <summary>
        ///     Tests that Pause has a non-null value.
        /// </summary>
        [Fact]
        public void Pause_HasValue()
        {
            Assert.NotNull(Shortcuts.Pause);
            Assert.NotEmpty(Shortcuts.Pause);
        }

        /// <summary>
        ///     Tests that Cut has a non-null value.
        /// </summary>
        [Fact]
        public void Cut_HasValue()
        {
            Assert.NotNull(Shortcuts.Cut);
            Assert.NotEmpty(Shortcuts.Cut);
        }

        /// <summary>
        ///     Tests that Copy has a non-null value.
        /// </summary>
        [Fact]
        public void Copy_HasValue()
        {
            Assert.NotNull(Shortcuts.Copy);
            Assert.NotEmpty(Shortcuts.Copy);
        }

        /// <summary>
        ///     Tests that Paste has a non-null value.
        /// </summary>
        [Fact]
        public void Paste_HasValue()
        {
            Assert.NotNull(Shortcuts.Paste);
            Assert.NotEmpty(Shortcuts.Paste);
        }

        /// <summary>
        ///     Tests that Duplicate has a non-null value.
        /// </summary>
        [Fact]
        public void Duplicate_HasValue()
        {
            Assert.NotNull(Shortcuts.Duplicate);
            Assert.NotEmpty(Shortcuts.Duplicate);
        }

        /// <summary>
        ///     Tests that Delete has a non-null value.
        /// </summary>
        [Fact]
        public void Delete_HasValue()
        {
            Assert.NotNull(Shortcuts.Delete);
            Assert.NotEmpty(Shortcuts.Delete);
        }

        /// <summary>
        ///     Tests that Search has a non-null value.
        /// </summary>
        [Fact]
        public void Search_HasValue()
        {
            Assert.NotNull(Shortcuts.Search);
            Assert.NotEmpty(Shortcuts.Search);
        }

        /// <summary>
        ///     Tests that AboutAlis has a non-null value.
        /// </summary>
        [Fact]
        public void AboutAlis_HasValue()
        {
            Assert.NotNull(Shortcuts.AboutAlis);
            Assert.NotEmpty(Shortcuts.AboutAlis);
        }

        /// <summary>
        ///     Tests that Preferences has a non-null value.
        /// </summary>
        [Fact]
        public void Preferences_HasValue()
        {
            Assert.NotNull(Shortcuts.Preferences);
            Assert.NotEmpty(Shortcuts.Preferences);
        }

        /// <summary>
        ///     Tests that QuitAlis has a non-null value.
        /// </summary>
        [Fact]
        public void QuitAlis_HasValue()
        {
            Assert.NotNull(Shortcuts.QuitAlis);
            Assert.NotEmpty(Shortcuts.QuitAlis);
        }

        /// <summary>
        ///     Tests that all shortcuts are populated when accessed.
        /// </summary>
        [Fact]
        public void AllShortcuts_AllProperties_AreNotEmpty()
        {
            Assert.Matches(".+", Shortcuts.NewScene);
            Assert.Matches(".+", Shortcuts.OpenScene);
            Assert.Matches(".+", Shortcuts.Save);
            Assert.Matches(".+", Shortcuts.SaveAs);
            Assert.Matches(".+", Shortcuts.Undo);
            Assert.Matches(".+", Shortcuts.Redo);
            Assert.Matches(".+", Shortcuts.Play);
            Assert.Matches(".+", Shortcuts.Pause);
            Assert.Matches(".+", Shortcuts.Cut);
            Assert.Matches(".+", Shortcuts.Copy);
            Assert.Matches(".+", Shortcuts.Paste);
            Assert.Matches(".+", Shortcuts.Duplicate);
            Assert.Matches(".+", Shortcuts.Delete);
            Assert.Matches(".+", Shortcuts.Search);
            Assert.Matches(".+", Shortcuts.AboutAlis);
            Assert.Matches(".+", Shortcuts.Preferences);
            Assert.Matches(".+", Shortcuts.QuitAlis);
        }
    }
}
