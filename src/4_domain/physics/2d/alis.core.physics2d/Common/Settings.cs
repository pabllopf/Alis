// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Settings.cs
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

using System;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     The settings class
    /// </summary>
    public class Settings
    {
        /// <summary>
        ///     The max toi iterations
        /// </summary>
        public const int MaxTOIIterations = 20;

        /// <summary>
        ///     The aabb multiplier
        /// </summary>
        public const float AABBMultiplier = 4.0f;

        /// <summary>
        ///     The aabb extension
        /// </summary>
        public const float AABBExtension = 0.1f;

        /// <summary>
        ///     The max toi contacts
        /// </summary>
        public const int MaxTOIContacts = 32;

        /// <summary>
        ///     The max sub steps
        /// </summary>
        public const int MaxSubSteps = 8;

        /// <summary>
        ///     The epsilon
        /// </summary>
        public const float FLT_EPSILON = float.Epsilon; //1.192092896e-07F;//smallest such that 1.0f+FLT_EPSILON != 1.0f

        /// <summary>
        ///     The flt epsilon
        /// </summary>
        public const float
            FLT_EPSILON_SQUARED = FLT_EPSILON * FLT_EPSILON; //smallest such that 1.0f+FLT_EPSILON != 1.0f

        /// <summary>
        ///     The pib
        /// </summary>
        public const float Pib2 = 3.14159265359f; // Original code. Comes out at 3.1415927f

        /// <summary>
        ///     The pi
        /// </summary>
        public const float Pi = MathF.PI; // Also 3.1415927f

        /// <summary>
        ///     The pi
        /// </summary>
        public const float Pi2 = (float) System.Math.PI; // Also displayed as "3.1415927f"

        /// <summary>
        ///     The pi
        /// </summary>
        public const float Tau = 2f * Pi;

        // Global tuning constants based on meters-kilograms-seconds (MKS) units.

        // Collision
        /// <summary>
        ///     The max manifold points
        /// </summary>
        public const int MaxManifoldPoints = 2;

        /// <summary>
        ///     The max polygon vertices
        /// </summary>
        public const int MaxPolygonVertices = 8;

        /// <summary>
        ///     The max proxies
        /// </summary>
        public const int MaxProxies = 512; // this must be a power of two

        /// <summary>
        ///     The max proxies
        /// </summary>
        public const int MaxPairs = 8 * MaxProxies; // this must be a power of two

        // Dynamics

        /// <summary>
        ///     A small length used as a collision and constraint tolerance. Usually it is
        ///     chosen to be numerically significant, but visually insignificant.
        /// </summary>
        public const float LinearSlop = 0.005f; // 0.5 cm

        /// <summary>
        ///     A small angle used as a collision and constraint tolerance. Usually it is
        ///     chosen to be numerically significant, but visually insignificant.
        /// </summary>
        public const float AngularSlop = 2.0f / 180.0f * Pi; // 2 degrees

        /// <summary>
        ///     The radius of the polygon/edge shape skin. This should not be modified. Making
        ///     this smaller means polygons will have and insufficient for continuous collision.
        ///     Making it larger may create artifacts for vertex collision.
        /// </summary>
        public const float PolygonRadius = 2.0f * LinearSlop;

        /// <summary>
        ///     Continuous collision detection (CCD) works with core, shrunken shapes. This is amount
        ///     by which shapes are automatically shrunk to work with CCD.
        ///     This must be larger than LinearSlop.
        /// </summary>
        public const float ToiSlop = 8.0f * LinearSlop;

        /// <summary>
        ///     Maximum number of contacts to be handled to solve a TOI island.
        /// </summary>
        public const int MaxTOIContactsPerIsland = 32;

        /// <summary>
        ///     Maximum number of joints to be handled to solve a TOI island.
        /// </summary>
        public const int MaxTOIJointsPerIsland = 32;

        /// <summary>
        ///     A velocity threshold for elastic collisions. Any collision with a relative linear
        ///     velocity below this threshold will be treated as inelastic.
        /// </summary>
        public const float VelocityThreshold = 1.0f; // 1 m/s

        /// <summary>
        ///     The maximum linear position correction used when solving constraints.
        ///     This helps to prevent overshoot.
        /// </summary>
        public const float MaxLinearCorrection = 0.2f; // 20 cm

        /// <summary>
        ///     The maximum angular position correction used when solving constraints.
        ///     This helps to prevent overshoot.
        /// </summary>
        public const float MaxAngularCorrection = 8.0f / 180.0f * Pi; // 8 degrees

        /// <summary>
        ///     The maximum linear velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
        public const float MaxLinearVelocity = 200.0f;

        /// <summary>
        ///     The max linear velocity
        /// </summary>
        public const float MaxLinearVelocitySquared = MaxLinearVelocity * MaxLinearVelocity;

        /// <summary>
        ///     The maximum angular velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
        public const float MaxAngularVelocity = 250.0f;

        /// <summary>
        ///     The maximum linear velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
        public const float MaxTranslation = 2.0f;

        /// <summary>
        ///     The max translation
        /// </summary>
        public const float MaxTranslationSquared = MaxTranslation * MaxTranslation;

        /// <summary>
        ///     The maximum angular velocity of a body. This limit is very large and is used
        ///     to prevent numerical problems. You shouldn't need to adjust this.
        /// </summary>
        public const float MaxRotation = 0.5f * Pi;

        /// <summary>
        ///     The max rotation
        /// </summary>
        public const float MaxRotationSquared = MaxRotation * MaxRotation;

        /// <summary>
        ///     This scale factor controls how fast overlap is resolved. Ideally this would be 1 so
        ///     that overlap is removed in one time step. However using values close to 1 often lead to overshoot.
        /// </summary>
        public const float ContactBaumgarte = 0.2f;

        // Sleep

        /// <summary>
        ///     The time that a body must be still before it will go to sleep.
        /// </summary>
        public const float TimeToSleep = 0.5f; // half a second

        /// <summary>
        ///     A body cannot sleep if its linear velocity is above this tolerance.
        /// </summary>
        public const float LinearSleepTolerance = 0.01f; // 1 cm/s

        /// <summary>
        ///     A body cannot sleep if its angular velocity is above this tolerance.
        /// </summary>
        public const float AngularSleepTolerance = 2.0f / 180.0f; // 2 degrees/s

        /// <summary>
        ///     The block solve
        /// </summary>
        public const bool BlockSolve = true;

        /// <summary>
        ///     The baumgarte
        /// </summary>
        public const float Baumgarte = 0.2f;

        /// <summary>
        ///     The toi baumgarte
        /// </summary>
        public const float TOIBaumgarte = 0.75f;

        /// <summary>
        ///     Forces the scale using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The float</returns>
        public static float FORCE_SCALE(float x) => x;

        /// <summary>
        ///     Forces the inv scale using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The float</returns>
        public static float FORCE_INV_SCALE(float x) => x;

        /// <summary>
        ///     Friction mixing law. Feel free to customize this.
        /// </summary>
        public static float MixFriction(float friction1, float friction2) =>
            (float) System.Math.Sqrt(friction1 * friction2);

        /// <summary>
        ///     Restitution mixing law. Feel free to customize this.
        /// </summary>
        public static float MixRestitution(float restitution1, float restitution2) =>
            restitution1 > restitution2 ? restitution1 : restitution2;
    }
}