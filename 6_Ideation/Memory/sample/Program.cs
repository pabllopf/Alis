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

using Alis.Core.Aspect.Memory.Attributes;

namespace Alis.Core.Aspect.Memory.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Gets or sets the value of the non zero value
        /// </summary>
        [IsNotZero] private static int _nonZeroValue;

        /// <summary>
        ///     Gets or sets the value of the non zero value
        /// </summary>
        private static int _nonZeroValuev2;

        /// <summary>
        ///     Gets or sets the value of the sample
        /// </summary>
        [IsNotZero]
        private static int Sample { get; set; }

        /// <summary>
        ///     Samples the method using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public static void SampleMethod([IsNotZero, IsNotNull] int value)
        {
            Validator.Validate(value, nameof(value));
        }

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            Sample = 0;
            Validator.Validate(Sample, nameof(Sample));

            SampleMethod(0);

            _nonZeroValuev2 = 0;
            Validator.Validate(_nonZeroValuev2, nameof(_nonZeroValuev2));

            _nonZeroValue = 0;
            Validator.Validate(_nonZeroValue, nameof(_nonZeroValue));

            _nonZeroValue = 5;
            Validator.Validate(_nonZeroValue, nameof(_nonZeroValue));
        }
    }
}