// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MyClass.cs
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
using System.Reflection;

namespace Alis.Core.Aspect.Memory.Sample
{
    /// <summary>
    /// The my class
    /// </summary>
    public class MyClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyClass"/> class
        /// </summary>
        public MyClass()
        {

        }
        
        /// <summary>
        /// Mys the method
        /// </summary>
        [PrePostMethod]
        public virtual void MyMethod()
        {
            Console.WriteLine("Método ejecutado 1");
        }
        
        /// <summary>
        /// Mys the method 2
        /// </summary>
        [PrePostMethod]
        public virtual void MyMethod2()
        {
            Console.WriteLine("Método ejecutado 2");
        }
    }


}