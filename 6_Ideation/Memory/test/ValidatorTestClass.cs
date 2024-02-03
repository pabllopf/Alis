// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ValidatorTestClass.cs
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
using Alis.Core.Aspect.Memory.Attributes;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    /// The validator test class
    /// </summary>
    public class ValidatorTestClass
    {
        /// <summary>
        /// The test field
        /// </summary>
        [IsNotEmpty]
        public string TestField;
        
        /// <summary>
        /// Gets or sets the value of the test property
        /// </summary>
        [IsNotEmpty]
        public string TestProperty { get; set; }
        
        /// <summary>
        /// Tests the method using the specified test param
        /// </summary>
        /// <param name="testParam">The test param</param>
        public void TestMethod([IsNotEmpty] string testParam)
        {
            Console.WriteLine("Test method");
        }
        
        /// <summary>
        /// Tests the method 2
        /// </summary>
        public void TestMethod2()
        {
            Console.WriteLine("Test method 2");
        }
        
        /// <summary>
        /// Tests the method 3 using the specified test param
        /// </summary>
        /// <param name="testParam">The test param</param>
        /// <param name="testParam2">The test param</param>
        public void TestMethod3([IsNotEmpty] string testParam, [IsNotNull] string testParam2)
        {
            Console.WriteLine("Test method 3");
        }
    }
}