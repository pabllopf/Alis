// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomListObjectTest.cs
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
using System.Collections;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Sample
{
    /// <summary>
    ///     The custom list object test class
    /// </summary>
    public class CustomListObjectTest
    {
        /// <summary>
        ///     Tests that clear list is empty does not throw exception
        /// </summary>
        [Fact]
        public void Clear_ListIsEmpty_DoesNotThrowException()
        {
            CustomListObject customListObject = new CustomListObject
            {
                List = new ArrayList()
            };
            customListObject.Clear();
            Assert.Empty(customListObject.List as IList ?? throw new InvalidOperationException());
        }
        
        /// <summary>
        ///     Tests that clear list is not empty clears list
        /// </summary>
        [Fact]
        public void Clear_ListIsNotEmpty_ClearsList()
        {
            CustomListObject customListObject = new CustomListObject();
            customListObject.Clear();
            customListObject.List = new ArrayList {1, 2, 3};
            customListObject.Clear();
            Assert.Empty(customListObject.List as IList ?? throw new InvalidOperationException());
        }
    }
}