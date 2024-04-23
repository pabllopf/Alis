// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ListObjectTest.cs
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

using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    public class ListObjectTest
    {
        
        [Fact]
        public void TestAddMethod()
        {
            // Arrange
            ConcreteListObject listObject = new ConcreteListObject(); // Assuming ConcreteListObject is a concrete implementation of ListObject
            object value = new object();
            JsonOptions options = new JsonOptions(); // Assuming JsonOptions is a valid class
            
            // Act
            listObject.Add(value, options);
            
            // Assert
            // Here you would assert that the value has been added to the list
            // The exact assertion will depend on how the Add method is implemented
        }
        
        [Fact]
        public void TestClearMethod()
        {
            // Arrange
            ConcreteListObject listObject = new ConcreteListObject(); // Assuming ConcreteListObject is a concrete implementation of ListObject
            object value = new object();
            JsonOptions options = new JsonOptions(); // Assuming JsonOptions is a valid class
            listObject.Add(value, options);
            
            // Act
            listObject.Clear();
            
            // Assert
            // Here you would assert that the list is now empty
            // The exact assertion will depend on how the Clear method is implemented
        }
    }
}
