// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogTest.cs
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
using Alis.Core.Aspect.Logging;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     The dialog test class
    /// </summary>
    public class DialogTest
    {
        /// <summary>
        ///     Tests that dialog constructor should initialize properties
        /// </summary>
        [Fact]
        public void Dialog_Constructor_ShouldInitializeProperties()
        {
            string id = "testId";
            string text = "Test Text";
            Dialog dialog = new Dialog(id, text);

            Assert.Equal(id, dialog.Id);
            Assert.Equal(text, dialog.Text);
            Assert.Empty(dialog.Options);
        }

        /// <summary>
        ///     Tests that add option should add option to list
        /// </summary>
        [Fact]
        public void AddOption_ShouldAddOptionToList()
        {
            Dialog dialog = new Dialog("testId", "Test Text");
            DialogOption option = new DialogOption("Option Text", () => Logger.Info("Test Action"));
            dialog.AddOption(option);

            Assert.Single(dialog.Options);
            Assert.Contains(option, dialog.Options);
        }

        /// <summary>
        ///     Tests that dialog option constructor should initialize properties
        /// </summary>
        [Fact]
        public void DialogOption_Constructor_ShouldInitializeProperties()
        {
            string text = "Option Text";
            Action action = () => Logger.Info("Test Action");
            DialogOption option = new DialogOption(text, action);

            Assert.Equal(text, option.Text);
            Assert.Equal(action, option.Action);
        }
    }
}