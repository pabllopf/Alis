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
            secureDouble += 20.0;
            
            // SecureFloat usage
            SecureFloat secureFloat = 10.0f;
            secureFloat += 20.0f;

            // SecureInt usage
            SecureInt secureInt = 10;
            secureInt += 20;

            // SecureLong usage
            SecureLong secureLong = 10L;
            secureLong += 20L;
            
            // SecureDecimal usage
            SecureDecimal secureDecimal = 10.0m;
            secureDecimal += 20.0m;
            
            // SecureString usage
            SecureString secureString = new SecureString("Hello");
            
            // SecureChar usage
            SecureChar secureChar = 'H';
            secureChar = 'W';
        }
    }
}