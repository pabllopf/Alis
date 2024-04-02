// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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

namespace Alis.Core.Aspect.Security.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            // SecureDouble usage
            SecureDouble secureDouble = 10.0;
            Console.WriteLine($"SecureDouble: {secureDouble}");

            // SecureFloat usage
            SecureFloat secureFloat = 10.0f;
            Console.WriteLine($"SecureFloat: {secureFloat}");

            // SecureInt usage
            SecureInt secureInt = 10;
            Console.WriteLine($"SecureInt: {secureInt}");

            // SecureLong usage
            SecureLong secureLong = 10L;
            Console.WriteLine($"SecureLong: {secureLong}");

            // SecureDecimal usage
            SecureDecimal secureDecimal = 10.0m;
            Console.WriteLine($"SecureDecimal: {secureDecimal}");
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}