// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Settings.cs
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

namespace Alis.Aspect.Math
{
    /// <summary>
    ///     The settings class
    /// </summary>
    public class Settings
    {
#if TARGET_FLOAT32_IS_FIXED
		public static readonly float FLT_EPSILON = FIXED_EPSILON;
		public static readonly float FLT_MAX = FIXED_MAX;
		public static float	FORCE_SCALE2(x){ return x<<7;}
		public static float FORCE_INV_SCALE2(x)	{return x>>7;}
#else
        /// <summary>
        ///     The flt epsilon
        /// </summary>
        public static readonly float FltEpsilon = 1.192092896e-07F; //smallest such that 1.0f+FLT_EPSILON != 1.0f

        /// <summary>
        ///     The flt epsilon
        /// </summary>
        public static readonly float
            FltEpsilonSquared = FltEpsilon * FltEpsilon; //smallest such that 1.0f+FLT_EPSILON != 1.0f

        /// <summary>
        ///     The flt max
        /// </summary>
        public static readonly float FltMax = 3.402823466e+38F;

        /// <summary>
        ///     Forces the scale using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The </returns>
        public static float FORCE_SCALE(float x) => x;

        /// <summary>
        ///     Forces the inv scale using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The </returns>
        public static float FORCE_INV_SCALE(float x) => x;
#endif

        /// <summary>
        ///     The pi
        /// </summary>
        public static readonly float Pi = 3.14159265359f;

        // Global tuning constants based on meters-kilograms-seconds (MKS) units.

        // Collision
        /// <summary>
        ///     The max manifold points
        /// </summary>
        public static readonly int MaxManifoldPoints = 2;

        /// <summary>
        ///     The max polygon vertices
        /// </summary>
        public static readonly int MaxPolygonVertices = 8;

        /// <summary>
        ///     The max proxies
        /// </summary>
        public static readonly int MaxProxies = 512; // this must be a power of two

        /// <summary>
        ///     The max proxies
        /// </summary>
        public static readonly int MaxPairs = 8 * MaxProxies; // this must be a power of two

        // Dynamics

        /// <summary>
        ///     A small length used as a collision and constraint tolerance. Usually it is
        ///     chosen to be numerically significant, but visually insignificant.
        /// </summary>
        public static readonly float LinearSlop = 0.005f; // 0.5 cm

        /// <summary>
        ///     A small angle used as a collision and constraint tolerance. Usually it is
        ///     chosen to be numerically significant, but visually insignificant.
        /// </summary>
        public static readonly float AngularSlop = 2.0f / 180.0f * Pi; // 2 degrees

        /// <summary>
        ///     The radius of the polygon/edge shape skin. This should not be modified. Making
        ///     this smaller means polygons will have and insufficient for continuous collision.
        ///     Making it larger may create artifacts for vertex collision.
        /// </summary>
        public static readonly float PolygonRadius = 2.0f * LinearSlop;

        /// <summary>
        ///     Continuous collision detection (CCD) works with core, shrunken shapes. This is amount
        ///     by which shapes are automatically shrunk to work with CCD.
        ///     This must be larger than LinearSlop.
        /// </summary>
        public static readonly float ToiSlop = 8.0f * LinearSlop;

        /// <summary>
        ///     Maximum number of contacts to be handled to solve a TOI island.
        /// </summary>
        public static readonly int MaxToiContactsPerIsland = 32;

        /// <summary>
        ///     Maximum number of joints to be handled to solve a TOI island.
        /// </summary>
        public static readonly int MaxToiJointsPerIsland = 32;

        /// <summary>
        ///     A velocity threshold for elastic collisions. Any collision with a relative linear
        ///     velocity below this threshold will be treated as inelastic.
        /// </summary>
        public static readonly float VelocityThreshold = 1.0f; // 1 m/s

        /// <summary>
        ///     The maximum linear position correction used when solving constraints.
        ///     This helps to prevent overshoot.
        /// </summary>
        public static readonly float MaxLinearCorrection = 0.2f; // 20 cm

        /// <summary>
        ///     The maximum angular position correction used when solving constraints.
        ///     This helps to prevent overshoot.
        /// </summary>
        public static readonly float MaxAngularCorrection = 8.0f / 180.0f * Pi; // 8 degrees

        /// <summary>
        ///     The maximum linear velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
#if TARGET_FLOAT32_IS_FIXED
		public static readonly float MaxLinearVelocity = 100.0f;
#else
        public static readonly float MaxLinearVelocity = 200.0f;

        /// <summary>
        ///     The max linear velocity
        /// </summary>
        public static readonly float MaxLinearVelocitySquared = MaxLinearVelocity * MaxLinearVelocity;
#endif
        /// <summary>
        ///     The maximum angular velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
        public static readonly float MaxAngularVelocity = 250.0f;
#if !TARGET_FLOAT32_IS_FIXED
        /// <summary>
        ///     The max angular velocity
        /// </summary>
        public static readonly float MaxAngularVelocitySquared = MaxAngularVelocity * MaxAngularVelocity;
#endif

        /// <summary>
        ///     The maximum linear velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
        public static readonly float MaxTranslation = 2.0f;

        /// <summary>
        ///     The max translation
        /// </summary>
        public static readonly float MaxTranslationSquared = MaxTranslation * MaxTranslation;

        /// <summary>
        ///     The maximum angular velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
        public static readonly float MaxRotation = 0.5f * Pi;

        /// <summary>
        ///     The max rotation
        /// </summary>
        public static readonly float MaxRotationSquared = MaxRotation * MaxRotation;

        /// <summary>
        ///     This scale factor controls how fast overlap is resolved. Ideally this would be 1 so
        ///     that overlap is removed in one time step. However using values close to 1 often lead to overshoot.
        /// </summary>
        public static readonly float ContactBaumgarte = 0.2f;

        // Sleep

        /// <summary>
        ///     The time that a body must be still before it will go to sleep.
        /// </summary>
        public static readonly float TimeToSleep = 0.5f; // half a second

        /// <summary>
        ///     A body cannot sleep if its linear velocity is above this tolerance.
        /// </summary>
        public static readonly float LinearSleepTolerance = 0.01f; // 1 cm/s

        /// <summary>
        ///     A body cannot sleep if its angular velocity is above this tolerance.
        /// </summary>
        public static readonly float AngularSleepTolerance = 2.0f / 180.0f; // 2 degrees/s

        /// <summary>
        ///     Friction mixing law. Feel free to customize this.
        /// </summary>
        public static float MixFriction(float friction1, float friction2) => (float) System.Math.Sqrt(friction1 * friction2);

        /// <summary>
        ///     Restitution mixing law. Feel free to customize this.
        /// </summary>
        public static float MixRestitution(float restitution1, float restitution2) => restitution1 > restitution2 ? restitution1 : restitution2;
    }
}