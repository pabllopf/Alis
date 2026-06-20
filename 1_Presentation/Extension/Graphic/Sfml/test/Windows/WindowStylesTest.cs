// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowStylesTest.cs
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

using SfmlWindows = Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Tests the <see cref="Alis.Extension.Graphic.Sfml.Windows.Styles" /> enum.
    /// </summary>
    public class WindowStylesTest
    {
        [Fact]
        public void None_HasValue0() => Assert.Equal(0, (int) SfmlWindows.Styles.None);

        [Fact]
        public void Titlebar_HasValue1() => Assert.Equal(1, (int) SfmlWindows.Styles.Titlebar);

        [Fact]
        public void Resize_HasValue2() => Assert.Equal(2, (int) SfmlWindows.Styles.Resize);

        [Fact]
        public void Close_HasValue4() => Assert.Equal(4, (int) SfmlWindows.Styles.Close);

        [Fact]
        public void Fullscreen_HasValue8() => Assert.Equal(8, (int) SfmlWindows.Styles.Fullscreen);

        [Fact]
        public void Default_HasTitlebarResizeClose() => Assert.Equal(7, (int) SfmlWindows.Styles.Default);

        [Fact]
        public void TitlebarResize_Combined() => Assert.Equal(3, (int) (SfmlWindows.Styles.Titlebar | SfmlWindows.Styles.Resize));
    }
}
