// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DummyTest.cs
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

using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Additional guard-clause tests for dialog lookups
    /// </summary>
    public class DialogManagerLookupTest
    {
        /// <summary>
        ///     Tests that GetDialog returns null for null ids
        /// </summary>
        [Fact]
        public void GetDialog_WithNullId_ShouldReturnNull()
        {
            DialogManager manager = new DialogManager();

            Dialog result = manager.GetDialog(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetDialog returns null for whitespace ids
        /// </summary>
        [Fact]
        public void GetDialog_WithWhitespaceId_ShouldReturnNull()
        {
            DialogManager manager = new DialogManager();

            Dialog result = manager.GetDialog("   ");

            Assert.Null(result);
        }
    }
}