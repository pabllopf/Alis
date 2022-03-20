// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Global.cs
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

using Alis.Core.Physics2D.Collision;

namespace Alis.Core.Physics2D.Common
{
    /// <summary>
    /// The global class
    /// </summary>
    public class Global
    {
        /// <summary>
        /// Swaps the a
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        /// <summary>
        /// Gets the point states using the specified state 1
        /// </summary>
        /// <param name="state1">The state</param>
        /// <param name="state2">The state</param>
        /// <param name="manifold1">The manifold</param>
        /// <param name="manifold2">The manifold</param>
        public static void GetPointStates(
            out PointState[] state1,
            out PointState[] state2,
            in Manifold manifold1,
            in Manifold manifold2)
        {
            state1 = new PointState[Settings.MaxManifoldPoints];
            state2 = new PointState[Settings.MaxManifoldPoints];
            for (int i = 0; i < Settings.MaxManifoldPoints; ++i)
            {
                state1[i] = PointState.Null;
                state2[i] = PointState.Null;
            }

            // Detect persists and removes.
            for (int i = 0; i < manifold1.pointCount; ++i)
            {
                ContactID id = manifold1.points[i].id;

                state1[i] = PointState.Remove;

                for (int j = 0; j < manifold2.pointCount; ++j)
                {
                    if (manifold2.points[j].id.key == id.key)
                    {
                        state1[i] = PointState.Persist;
                        break;
                    }
                }
            }

            // Detect persists and adds.
            for (int i = 0; i < manifold2.pointCount; ++i)
            {
                ContactID id = manifold2.points[i].id;

                state2[i] = PointState.Add;

                for (int j = 0; j < manifold1.pointCount; ++j)
                {
                    if (manifold1.points[j].id.key == id.key)
                    {
                        state2[i] = PointState.Persist;
                        break;
                    }
                }
            }
        }
    }
}