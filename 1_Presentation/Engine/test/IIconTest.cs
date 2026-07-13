// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IIconTest.cs
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

using Alis.App.Engine.Icons;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    /// The icon test class
    /// </summary>
    public class IIconTest
    {
        /// <summary>
        /// Tests that interface should be public
        /// </summary>
        [Fact]
        public void Interface_ShouldBePublic()
        {
            Assert.True(typeof(IIcon).IsInterface);
            Assert.True(typeof(IIcon).IsPublic);
        }

        /// <summary>
        /// Tests that interface should be implemented by folder icon
        /// </summary>
        [Fact]
        public void Interface_ShouldBeImplementedByFolderIcon()
        {
            Assert.IsAssignableFrom<IIcon>(new FolderIcon());
        }

        /// <summary>
        /// Tests that interface should be implemented by segoe icon
        /// </summary>
        [Fact]
        public void Interface_ShouldBeImplementedBySegoeIcon()
        {
            Assert.IsAssignableFrom<IIcon>(new global::Alis.App.Engine.Fonts.SegoeIcon());
        }
    }
}
