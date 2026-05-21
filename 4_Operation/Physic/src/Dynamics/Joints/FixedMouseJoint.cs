

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A mouse joint is used to make a point on a body track a
    ///     specified world point. This a soft constraint with a maximum
    ///     force. This allows the constraint to stretch and without
    ///     applying huge forces.
    ///     NOTE: this joint is not documented in the manual because it was
    ///     developed to be used in the testbed. If you want to learn how to
    ///     use the mouse joint, look at the testbed.
    /// </summary>
    /// <remarks>
    ///     p = attached point, m = mouse point
    ///     C = p - m
    ///     Cdot = v
    ///     = v + cross(w, r)
    ///     J = [I r_skew]
    ///     Identity used:
    ///     w k % (rx i + ry j) = w * (-ry i + rx j)
    /// </remarks>
    public class FixedMouseJoint : Joint
    {
        /// <summary>
        ///     The beta
        /// </summary>
        private float _beta;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float _gamma;

        /// <summary>
        ///     The impulse
        /// </summary>
        private Vector2F _impulse;

        /// <summary>
        ///     The index
        /// </summary>
        private int _indexA;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float _invMassA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F _localCenterA;

        /// <summary>
        ///     The mass
        /// </summary>
        private Mat22 _mass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rA;

        /// <summary>
        ///     The world anchor
        /// </summary>
        private Vector2F _worldAnchor;

        /// <summary>
        ///     The maximum force
        /// </summary>
        private float _maxForce;

        /// <summary>
        ///     The frequency
        /// </summary>
        private float _frequency;

        /// <summary>
        ///     The damping ratio
        /// </summary>
        private float _dampingRatio;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F c;

        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;

        /// <summary>
        ///     This requires a world target point,
        ///     tuning parameters, and the time step.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="worldAnchor">The target.</param>
        public FixedMouseJoint(Body body, Vector2F worldAnchor)
            : base(body)
        {
            JointType = JointType.FixedMouse;
            Frequency = 5.0f;
            DampingRatio = 0.7f;
            MaxForce = 1000 * body.Mass;

            _worldAnchor = worldAnchor;
            LocalAnchorA = ControllerTransform.Divide(ref worldAnchor, ref BodyA.Xf);
        }

        /// <summary>
        ///     The local anchor point on BodyA
        /// </summary>
        public Vector2F LocalAnchorA { get; set; }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2F WorldAnchorA
        {
            get => BodyA.GetWorldPoint(LocalAnchorA);
            set => LocalAnchorA = BodyA.GetLocalPoint(value);
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2F WorldAnchorB
        {
            get => _worldAnchor;
            set
            {
                WakeBodies();
                _worldAnchor = value;
            }
        }

        /// <summary>
        ///     The maximum constraint force that can be exerted
        ///     to move the candidate body. Usually you will express
        ///     as some multiple of the weight (multiplier * mass * gravity).
        /// </summary>
        public float MaxForce
        {
            get => _maxForce;
            set => _maxForce = value;
        }

        /// <summary>
        ///     The response speed.
        /// </summary>
        public float Frequency
        {
            get => _frequency;
            set => _frequency = value;
        }

        /// <summary>
        ///     The damping ratio. 0 = no damping, 1 = critical damping.
        /// </summary>
        public float DampingRatio
        {
            get => _dampingRatio;
            set => _dampingRatio = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt) => invDt * _impulse;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * 0.0f;

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            _indexA = BodyA.GetIslandIndex;
            _localCenterA = BodyA.Sweep.LocalCenter;
            _invMassA = BodyA.InvMass;
            invIa = BodyA.InvI;

            Vector2F cA = data.Positions[_indexA].C;
            float aA = data.Positions[_indexA].A;
            Vector2F vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            Complex qA = Complex.FromAngle(aA);

            float mass = BodyA.Mass;

            float omega = Constant.Tau * Frequency;

            float d = 2.0f * mass * DampingRatio * omega;

            float kKk = mass * (omega * omega);

            float h = data.Step.Dt;
            _gamma = h * (d + h * kKk);
            if (Math.Abs(_gamma) > SettingEnv.Epsilon)
            {
                _gamma = 1.0f / _gamma;
            }

            _beta = h * kKk * _gamma;

            _rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            Mat22 k = new Mat22();
            k.Ex.X = _invMassA + invIa * _rA.Y * _rA.Y + _gamma;
            k.Ex.Y = -invIa * _rA.X * _rA.Y;
            k.Ey.X = k.Ex.Y;
            k.Ey.Y = _invMassA + invIa * _rA.X * _rA.X + _gamma;

            _mass = k.Inverse;

            c = cA + _rA - _worldAnchor;
            c *= _beta;

            wA *= 0.98f;

            if (data.Step.WarmStarting)
            {
                _impulse *= data.Step.DtRatio;
                vA += _invMassA * _impulse;
                wA += invIa * MathUtils.Cross(ref _rA, ref _impulse);
            }
            else
            {
                _impulse = Vector2F.Zero;
            }

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            Vector2F vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            Vector2F cdot = vA + MathUtils.Cross(wA, ref _rA);
            Vector2F impulse = MathUtils.Mul(ref _mass, -(cdot + c + _gamma * _impulse));

            Vector2F oldImpulse = _impulse;
            _impulse += impulse;
            float maxImpulse = data.Step.Dt * MaxForce;
            if (_impulse.LengthSquared() > maxImpulse * maxImpulse)
            {
                _impulse *= maxImpulse / _impulse.Length();
            }

            impulse = _impulse - oldImpulse;

            vA += _invMassA * impulse;
            wA += invIa * MathUtils.Cross(ref _rA, ref impulse);

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data) => true;
    }
}