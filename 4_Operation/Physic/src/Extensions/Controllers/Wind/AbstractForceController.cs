// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AbstractForceController.cs
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
using System.Numerics;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Extensions.Controllers.ControllerBase;
using Alis.Core.Systems.Physics2D.Config.Extensions.Controllers.Wind.Curve;

namespace Alis.Core.Physic.Extensions.Controllers.Wind
{
    /// <summary>
    ///     The abstract force controller class
    /// </summary>
    /// <seealso cref="Controller" />
    public abstract class AbstractForceController : Controller
    {
        /// <summary>Curve to be used for Decay in Curve mode</summary>
        public Systems.Physics2D.Config.Extensions.Controllers.Wind.Curve.Curve DecayCurve;

        /// <summary>The Forcetype of the instance</summary>
        public ForceTypes ForceType;

        /// <summary>Provided for reuse to provide Variation functionality in inheriting classes</summary>
        protected Random Randomize;

        /// <summary>
        ///     Curve used by Curve Mode as an animated multiplier for the force strength. Only positions between 0 and 1 are
        ///     considered as that range is stretched to have ImpulseLength.
        /// </summary>
        public Systems.Physics2D.Config.Extensions.Controllers.Wind.Curve.Curve StrengthCurve;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbstractForceController" /> class
        /// </summary>
        protected AbstractForceController() : base(ControllerType.AbstractForceController)
        {
            Enabled = true;

            Strength = 1.0f;
            Position = new Vector2(0, 0);
            MaximumSpeed = 100.0f;
            TimingMode = TimingModes.Switched;
            ImpulseTime = 0.0f;
            ImpulseLength = 1.0f;
            Triggered = false;
            StrengthCurve = new Systems.Physics2D.Config.Extensions.Controllers.Wind.Curve.Curve();
            Variation = 0.0f;
            Randomize = new Random(1234);
            DecayMode = DecayModes.None;
            DecayCurve = new Systems.Physics2D.Config.Extensions.Controllers.Wind.Curve.Curve();
            DecayStart = 0.0f;
            DecayEnd = 0.0f;

            StrengthCurve.Keys.Add(new CurveKey(0, 5));
            StrengthCurve.Keys.Add(new CurveKey(0.1f, 5));
            StrengthCurve.Keys.Add(new CurveKey(0.2f, -4));
            StrengthCurve.Keys.Add(new CurveKey(1f, 0));
        }

        /// <summary>Overloaded Contstructor with supplying Timing Mode</summary>
        /// <param name="mode"></param>
        protected AbstractForceController(TimingModes mode) : base(ControllerType.AbstractForceController)
        {
            TimingMode = mode;
            switch (mode)
            {
                case TimingModes.Switched:
                    Enabled = true;
                    break;
                case TimingModes.Triggered:
                    Enabled = false;
                    break;
                case TimingModes.Curve:
                    Enabled = false;
                    break;
            }
        }

        /// <summary>Global Strength of the force to be applied</summary>
        public float Strength { get; set; }

        /// <summary>Position of the Force. Can be ignored (left at (0,0) for forces that are not position-dependent</summary>
        public Vector2 Position { get; set; }

        /// <summary>Maximum speed of the bodies. Bodies that are travelling faster are supposed to be ignored</summary>
        public float MaximumSpeed { get; set; }

        /// <summary>Timing Mode of the force instance</summary>
        public TimingModes TimingMode { get; set; }

        /// <summary>Time of the current impulse. Incremented in update till ImpulseLength is reached</summary>
        public float ImpulseTime { get; private set; }

        /// <summary>Length of a triggered impulse. Used in both Triggered and Curve Mode</summary>
        public float ImpulseLength { get; set; }

        /// <summary>Indicating if we are currently during an Impulse (Triggered and Curve Mode)</summary>
        public bool Triggered { get; private set; }

        /// <summary>Variation of the force applied to each body affected !! Must be used in inheriting classes properly !!</summary>
        public float Variation { get; set; }

        /// <summary>See DecayModes</summary>
        public DecayModes DecayMode { get; set; }

        /// <summary>Start of the distance based Decay. To set a non decaying area</summary>
        public float DecayStart { get; set; }

        /// <summary>Maximum distance a force should be applied</summary>
        public float DecayEnd { get; set; }

        /// <summary>Modes for Decay. Actual Decay must be implemented in inheriting classes</summary>
        public enum DecayModes
        {
            /// <summary>
            ///     The none decay modes
            /// </summary>
            None,

            /// <summary>
            ///     The step decay modes
            /// </summary>
            Step,

            /// <summary>
            ///     The linear decay modes
            /// </summary>
            Linear,

            /// <summary>
            ///     The inverse square decay modes
            /// </summary>
            InverseSquare,

            /// <summary>
            ///     The curve decay modes
            /// </summary>
            Curve
        }

        /// <summary>
        ///     Forcetypes are used in the decay math to properly get the distance. They are also used to draw a
        ///     representation in DebugView
        /// </summary>
        public enum ForceTypes
        {
            /// <summary>
            ///     The point force types
            /// </summary>
            Point,

            /// <summary>
            ///     The line force types
            /// </summary>
            Line,

            /// <summary>
            ///     The area force types
            /// </summary>
            Area
        }

        /// <summary>
        ///     Timing Modes Switched: Standard on/off mode using the baseclass enabled property Triggered: When the Trigger()
        ///     method is called the force is active for a specified Impulse Length Curve: Still to be defined. The basic idea is
        ///     having a Trigger combined with a curve for the strength
        /// </summary>
        public enum TimingModes
        {
            /// <summary>
            ///     The switched timing modes
            /// </summary>
            Switched,

            /// <summary>
            ///     The triggered timing modes
            /// </summary>
            Triggered,

            /// <summary>
            ///     The curve timing modes
            /// </summary>
            Curve
        }

        /// <summary>
        ///     Calculate the Decay for a given body. Meant to ease force development and stick to the DRY principle and
        ///     provide unified and predictable decay math.
        /// </summary>
        /// <param name="body">The body to calculate decay for</param>
        /// <returns>A multiplier to multiply the force with to add decay support in inheriting classes</returns>
        protected float GetDecayMultiplier(Body body)
        {
            //TODO: Consider ForceType in distance calculation!
            float distance = (body.Position - Position).Length();
            switch (DecayMode)
            {
                case DecayModes.None:
                {
                    return 1.0f;
                }
                case DecayModes.Step:
                {
                    if (distance < DecayEnd)
                    {
                        return 1.0f;
                    }

                    return 0.0f;
                }
                case DecayModes.Linear:
                {
                    if (distance < DecayStart)
                    {
                        return 1.0f;
                    }

                    if (distance > DecayEnd)
                    {
                        return 0.0f;
                    }

                    return DecayEnd - DecayStart / distance - DecayStart;
                }
                case DecayModes.InverseSquare:
                {
                    if (distance < DecayStart)
                    {
                        return 1.0f;
                    }

                    return 1.0f / ((distance - DecayStart) * (distance - DecayStart));
                }
                case DecayModes.Curve:
                {
                    if (distance < DecayStart)
                    {
                        return 1.0f;
                    }

                    return DecayCurve.Evaluate(distance - DecayStart);
                }
                default:
                    return 1.0f;
            }
        }

        /// <summary>Triggers the trigger modes (Trigger and Curve)</summary>
        public void Trigger()
        {
            Triggered = true;
            ImpulseTime = 0;
        }

        /// <summary>Inherited from Controller Depending on the TimingMode perform timing logic and call ApplyForce()</summary>
        /// <param name="dt"></param>
        public override void Update(float dt)
        {
            switch (TimingMode)
            {
                case TimingModes.Switched:
                {
                    if (Enabled)
                    {
                        ApplyForce(dt, Strength);
                    }

                    break;
                }
                case TimingModes.Triggered:
                {
                    if (Enabled && Triggered)
                    {
                        if (ImpulseTime < ImpulseLength)
                        {
                            ApplyForce(dt, Strength);
                            ImpulseTime += dt;
                        }
                        else
                        {
                            Triggered = false;
                        }
                    }

                    break;
                }
                case TimingModes.Curve:
                {
                    if (Enabled && Triggered)
                    {
                        if (ImpulseTime < ImpulseLength)
                        {
                            ApplyForce(dt, Strength * StrengthCurve.Evaluate(ImpulseTime));
                            ImpulseTime += dt;
                        }
                        else
                        {
                            Triggered = false;
                        }
                    }

                    break;
                }
            }
        }

        /// <summary>Apply the force supplying strength which is modified in Update() according to the TimingMode</summary>
        /// <param name="dt"></param>
        /// <param name="strength">The strength</param>
        public abstract void ApplyForce(float dt, float strength);
    }
}