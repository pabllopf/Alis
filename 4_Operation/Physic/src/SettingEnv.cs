// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingEnv.cs
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
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic
{
    /// <summary>
    ///     The settings class
    /// </summary>
    public static class SettingEnv
    {
        /// <summary>
        ///     The max float
        /// </summary>
        public const float MaxFloat = 3.402823466e+38f;

        /// <summary>
        ///     The epsilon
        /// </summary>
        public const float Epsilon = 1.192092896e-07f;

        // Common

        /// <summary>
        ///     Enabling diagnistics causes the engine to gather timing information.
        ///     You can see how much time it took to solve the contacts, solve CCD
        ///     and update the controllers.
        ///     NOTE: If you are using a debug view that shows performance counters,
        ///     you might want to enable this.
        /// </summary>
        public const bool EnableDiagnostics = true;

        /// <summary>
        ///     Maximum number of sub-steps per contact in continuous physics simulation.
        /// </summary>
        public const int MaxSubSteps = 8;

        /// <summary>
        ///     The maximum number of contact points between two convex shapes.
        ///     DO NOT CHANGE THIS VALUE!
        /// </summary>
        public const int MaxManifoldPoints = 2;

        /// <summary>
        ///     This is used to fatten AABBs in the dynamic tree. This allows proxies
        ///     to move by a small amount without triggering a tree adjustment.
        ///     This is in meters.
        /// </summary>
        public const float AabbExtension = 0.1f;

        /// <summary>
        ///     This is used to fatten AABBs in the dynamic tree. This is used to predict
        ///     the future position based on the current displacement.
        ///     This is a dimensionless multiplier.
        /// </summary>
        public const float AabbMultiplier = 2.0f;

        /// <summary>
        ///     A small length used as a collision and constraint tolerance. Usually it is
        ///     chosen to be numerically significant, but visually insignificant.
        /// </summary>
        public const float LinearSlop = 0.005f;

        /// <summary>
        ///     A small angle used as a collision and constraint tolerance. Usually it is
        ///     chosen to be numerically significant, but visually insignificant.
        /// </summary>
        public const float AngularSlop = 2.0f / 180.0f * Constant.Pi;

        /// <summary>
        ///     The radius of the polygon/edge shape skin. This should not be modified. Making
        ///     this smaller means polygons will have an insufficient buffer for continuous collision.
        ///     Making it larger may create artifacts for vertex collision.
        /// </summary>
        public const float PolygonRadius = 2.0f * LinearSlop;

        // Dynamics

        /// <summary>
        ///     Maximum number of contacts to be handled to solve a TOI impact.
        /// </summary>
        public const int MaxToiContacts = 32;

        /// <summary>
        ///     A velocity threshold for elastic collisions. Any collision with a relative linear
        ///     velocity below this threshold will be treated as inelastic.
        /// </summary>
        public const float VelocityThreshold = 1.0f;

        /// <summary>
        ///     The maximum linear position correction used when solving constraints. This helps to
        ///     prevent overshoot.
        /// </summary>
        public const float MaxLinearCorrection = 0.2f;

        /// <summary>
        ///     The maximum angular position correction used when solving constraints. This helps to
        ///     prevent overshoot.
        /// </summary>
        public const float MaxAngularCorrection = 8.0f / 180.0f * Constant.Pi;

        /// <summary>
        ///     This scale factor controls how fast overlap is resolved. Ideally this would be 1 so
        ///     that overlap is removed in one time step. However using values close to 1 often lead
        ///     to overshoot.
        /// </summary>
        public const float Baumgarte = 0.2f;

        // Sleep
        /// <summary>
        ///     The time that a body must be still before it will go to sleep.
        /// </summary>
        public const float TimeToSleep = 0.5f;

        /// <summary>
        ///     A body cannot sleep if its linear velocity is above this tolerance.
        /// </summary>
        public const float LinearSleepTolerance = 0.01f;

        /// <summary>
        ///     A body cannot sleep if its angular velocity is above this tolerance.
        /// </summary>
        public const float AngularSleepTolerance = 2.0f / 180.0f * Constant.Pi;

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
        public const float MaxRotation = 0.5f * Constant.Pi;

        /// <summary>
        ///     The max rotation
        /// </summary>
        public const float MaxRotationSquared = MaxRotation * MaxRotation;

        /// <summary>
        ///     Defines the maximum number of iterations made by the GJK algorithm.
        /// </summary>
        public const int MaxGjkIterations = 20;

        /// <summary>
        ///     By default, forces are cleared automatically after each call to Step.
        ///     The default behavior is modified with this setting.
        ///     The purpose of this setting is to support sub-stepping. Sub-stepping is often used to maintain
        ///     a fixed sized time step under a variable frame-rate.
        ///     When you perform sub-stepping you should disable auto clearing of forces and instead call
        ///     ClearForces after all sub-steps are complete in one pass of your game loop.
        /// </summary>
        public const bool AutoClearForces = true;

        /// <summary>
        ///     The number of velocity iterations used in the solver.
        /// </summary>
        public static int VelocityIterations = 8;

        /// <summary>
        ///     The number of position iterations used in the solver.
        /// </summary>
        public static int PositionIterations = 3;

        /// <summary>
        ///     Enable/Disable Continuous Collision Detection (CCD)
        /// </summary>
        public static bool ContinuousPhysics = true;

        /// <summary>
        ///     If true, it will run a GiftWrap convex hull on all polygon inputs.
        ///     This makes for a more stable engine when given random input,
        ///     but if speed of the creation of polygons are more important,
        ///     you might want to set this to false.
        /// </summary>
        public static bool UseConvexHullPolygons = true;

        /// <summary>
        ///     The number of velocity iterations in the TOI solver
        /// </summary>
        public static int ToiVelocityIterations = VelocityIterations;

        /// <summary>
        ///     The number of position iterations in the TOI solver
        /// </summary>
        public static int ToiPositionIterations = 20;

        /// <summary>
        ///     Enable/Disable sleeping
        /// </summary>
        public static bool AllowSleep = true;

        /// <summary>
        ///     The maximum number of vertices on a convex polygon.
        /// </summary>
        public static int MaxPolygonVertices = 8;

        /// <summary>
        ///     Friction mixing law. Feel free to customize this.
        /// </summary>
        /// <param name="friction1">The friction1.</param>
        /// <param name="friction2">The friction2.</param>
        /// <returns></returns>
        public static float MixFriction(float friction1, float friction2) => (float) Math.Sqrt(friction1 * friction2);

        /// <summary>
        ///     Restitution mixing law. Feel free to customize this.
        /// </summary>
        /// <param name="restitution1">The restitution1.</param>
        /// <param name="restitution2">The restitution2.</param>
        /// <returns></returns>
        public static float MixRestitution(float restitution1, float restitution2) => restitution1 > restitution2 ? restitution1 : restitution2;
    }
}