// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ConvertUnits.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Numerics;

namespace Alis.Core.Systems.Physics2D.Utilities
{
    /// <summary>Convert units between display and simulation units.</summary>
    public static class ConvertUnits
    {
        /// <summary>
        ///     The display units to sim units ratio
        /// </summary>
        private static float _displayUnitsToSimUnitsRatio = 100f;

        /// <summary>
        ///     The display units to sim units ratio
        /// </summary>
        private static float _simUnitsToDisplayUnitsRatio = 1 / _displayUnitsToSimUnitsRatio;

        /// <summary>
        ///     Sets the display unit to sim unit ratio using the specified display units per sim unit
        /// </summary>
        /// <param name="displayUnitsPerSimUnit">The display units per sim unit</param>
        public static void SetDisplayUnitToSimUnitRatio(float displayUnitsPerSimUnit)
        {
            _displayUnitsToSimUnitsRatio = displayUnitsPerSimUnit;
            _simUnitsToDisplayUnitsRatio = 1 / displayUnitsPerSimUnit;
        }

        /// <summary>
        ///     Returns the display units using the specified sim units
        /// </summary>
        /// <param name="simUnits">The sim units</param>
        /// <returns>The float</returns>
        public static float ToDisplayUnits(float simUnits) => simUnits * _displayUnitsToSimUnitsRatio;

        /// <summary>
        ///     Returns the display units using the specified sim units
        /// </summary>
        /// <param name="simUnits">The sim units</param>
        /// <returns>The float</returns>
        public static float ToDisplayUnits(int simUnits) => simUnits * _displayUnitsToSimUnitsRatio;

        /// <summary>
        ///     Returns the display units using the specified sim units
        /// </summary>
        /// <param name="simUnits">The sim units</param>
        /// <returns>The vector</returns>
        public static Vector2 ToDisplayUnits(Vector2 simUnits) => simUnits * _displayUnitsToSimUnitsRatio;

        /// <summary>
        ///     Returns the display units using the specified sim units
        /// </summary>
        /// <param name="simUnits">The sim units</param>
        /// <param name="displayUnits">The display units</param>
        public static void ToDisplayUnits(ref Vector2 simUnits, out Vector2 displayUnits)
        {
            displayUnits = Vector2.Multiply(simUnits, _displayUnitsToSimUnitsRatio);
        }

        /// <summary>
        ///     Returns the display units using the specified sim units
        /// </summary>
        /// <param name="simUnits">The sim units</param>
        /// <returns>The vector</returns>
        public static Vector3 ToDisplayUnits(Vector3 simUnits) => simUnits * _displayUnitsToSimUnitsRatio;

        /// <summary>
        ///     Returns the display units using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The vector</returns>
        public static Vector2 ToDisplayUnits(float x, float y) => new Vector2(x, y) * _displayUnitsToSimUnitsRatio;

        /// <summary>
        ///     Returns the display units using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="displayUnits">The display units</param>
        public static void ToDisplayUnits(float x, float y, out Vector2 displayUnits)
        {
            displayUnits = Vector2.Zero;
            displayUnits.X = x * _displayUnitsToSimUnitsRatio;
            displayUnits.Y = y * _displayUnitsToSimUnitsRatio;
        }

        /// <summary>
        ///     Returns the sim units using the specified display units
        /// </summary>
        /// <param name="displayUnits">The display units</param>
        /// <returns>The float</returns>
        public static float ToSimUnits(float displayUnits) => displayUnits * _simUnitsToDisplayUnitsRatio;

        /// <summary>
        ///     Returns the sim units using the specified display units
        /// </summary>
        /// <param name="displayUnits">The display units</param>
        /// <returns>The float</returns>
        public static float ToSimUnits(double displayUnits) => (float) displayUnits * _simUnitsToDisplayUnitsRatio;

        /// <summary>
        ///     Returns the sim units using the specified display units
        /// </summary>
        /// <param name="displayUnits">The display units</param>
        /// <returns>The float</returns>
        public static float ToSimUnits(int displayUnits) => displayUnits * _simUnitsToDisplayUnitsRatio;

        /// <summary>
        ///     Returns the sim units using the specified display units
        /// </summary>
        /// <param name="displayUnits">The display units</param>
        /// <returns>The vector</returns>
        public static Vector2 ToSimUnits(Vector2 displayUnits) => displayUnits * _simUnitsToDisplayUnitsRatio;

        /// <summary>
        ///     Returns the sim units using the specified display units
        /// </summary>
        /// <param name="displayUnits">The display units</param>
        /// <returns>The vector</returns>
        public static Vector3 ToSimUnits(Vector3 displayUnits) => displayUnits * _simUnitsToDisplayUnitsRatio;

        /// <summary>
        ///     Returns the sim units using the specified display units
        /// </summary>
        /// <param name="displayUnits">The display units</param>
        /// <param name="simUnits">The sim units</param>
        public static void ToSimUnits(ref Vector2 displayUnits, out Vector2 simUnits)
        {
            simUnits = Vector2.Multiply(displayUnits, _simUnitsToDisplayUnitsRatio);
        }

        /// <summary>
        ///     Returns the sim units using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The vector</returns>
        public static Vector2 ToSimUnits(float x, float y) => new Vector2(x, y) * _simUnitsToDisplayUnitsRatio;

        /// <summary>
        ///     Returns the sim units using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The vector</returns>
        public static Vector2 ToSimUnits(double x, double y) =>
            new Vector2((float) x, (float) y) * _simUnitsToDisplayUnitsRatio;

        /// <summary>
        ///     Returns the sim units using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="simUnits">The sim units</param>
        public static void ToSimUnits(float x, float y, out Vector2 simUnits)
        {
            simUnits = Vector2.Zero;
            simUnits.X = x * _simUnitsToDisplayUnitsRatio;
            simUnits.Y = y * _simUnitsToDisplayUnitsRatio;
        }
    }
}