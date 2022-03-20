// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Body.cs
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
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Collision;
using Alis.Core.Physics2D.Collision.Shapes;
using Alis.Core.Physics2D.Common;
using Alis.Core.Physics2D.Dynamics.Contacts;
using Alis.Core.Physics2D.Dynamics.Fixtures;
using Alis.Core.Physics2D.Dynamics.Joints;
using Math = Alis.Core.Physics2D.Common.Math;

namespace Alis.Core.Physics2D.Dynamics.Bodies
{
    /// <summary>
    ///     A rigid body. These are created via World.CreateBody.
    /// </summary>
    [DebuggerDisplay("{UserData}")]
    public class Body
    {
        /// <summary>
        /// The world
        /// </summary>
        private readonly World.World m_world;
        /// <summary>
        /// The angulardamping
        /// </summary>
        internal float m_angularDamping;
        /// <summary>
        /// The angularvelocity
        /// </summary>
        internal float m_angularVelocity;
        /// <summary>
        /// The contactlist
        /// </summary>
        internal ContactEdge m_contactList;
        /// <summary>
        /// The fixturecount
        /// </summary>
        internal int m_fixtureCount;

        /// <summary>
        /// The fixturelist
        /// </summary>
        internal Fixture m_fixtureList;
        /// <summary>
        /// The flags
        /// </summary>
        private BodyFlags m_flags;

        /// <summary>
        /// The force
        /// </summary>
        internal Vector2 m_force;
        /// <summary>
        /// The gravityscale
        /// </summary>
        internal float m_gravityScale;
        /// <summary>
        /// The 
        /// </summary>
        private float m_I;
        /// <summary>
        /// The invi
        /// </summary>
        internal float m_invI;
        /// <summary>
        /// The invmass
        /// </summary>
        internal float m_invMass;

        /// <summary>
        /// The islandindex
        /// </summary>
        internal int m_islandIndex;

        /// <summary>
        /// The jointlist
        /// </summary>
        internal JointEdge m_jointList;

        /// <summary>
        /// The lineardamping
        /// </summary>
        internal float m_linearDamping;

        /// <summary>
        /// The linearvelocity
        /// </summary>
        internal Vector2 m_linearVelocity;

        /// <summary>
        /// The mass
        /// </summary>
        internal float m_mass;
        /// <summary>
        /// The next
        /// </summary>
        internal Body m_next;
        /// <summary>
        /// The prev
        /// </summary>
        internal Body m_prev;

        /// <summary>
        /// The sleeptime
        /// </summary>
        internal float m_sleepTime;

        /// <summary>
        /// The sweep
        /// </summary>
        internal Sweep m_sweep; // the swept motion for CCD
        /// <summary>
        /// The torque
        /// </summary>
        internal float m_torque;

        /// <summary>
        /// The type
        /// </summary>
        internal BodyType m_type;

        /// <summary>
        /// The xf
        /// </summary>
        internal Transform m_xf; // the body origin transform

        // No public default constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Body"/> class
        /// </summary>
        private Body()
        {
        }

        // private

        /// <summary>
        /// Initializes a new instance of the <see cref="Body"/> class
        /// </summary>
        /// <param name="bd">The bd</param>
        /// <param name="world">The world</param>
        private Body(in BodyDef bd, World.World world)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Body"/> class
        /// </summary>
        /// <param name="bd">The bd</param>
        /// <param name="world">The world</param>
        internal Body(BodyDef bd, World.World world)
        {
            //Debug.Assert(bd.position.IsValid());
            //Debug.Assert(bd.linearVelocity.IsValid());

            m_flags = 0;

            if (bd.bullet)
            {
                SetFlag(BodyFlags.Bullet);
            }

            if (bd.fixedRotation)
            {
                SetFlag(BodyFlags.FixedRotation);
            }

            if (bd.allowSleep)
            {
                SetFlag(BodyFlags.AutoSleep);
            }

            if (bd.awake && bd.type != BodyType.Static)
            {
                SetFlag(BodyFlags.Awake);
            }

            if (bd.enabled)
            {
                SetFlag(BodyFlags.Enabled);
            }

            m_world = world;

            m_xf.p = bd.position;
            m_xf.q = Matrex.CreateRotation(bd.angle); // Actually about twice as fast to use our own function

            m_sweep.localCenter = Vector2.Zero;
            m_sweep.c0 = m_xf.p;
            m_sweep.c = m_xf.p;
            m_sweep.a0 = bd.angle;
            m_sweep.a = bd.angle;
            m_sweep.alpha0 = 0.0f;

            m_jointList = null;
            m_contactList = null;
            m_prev = null;
            m_next = null;

            m_linearVelocity = bd.linearVelocity;
            m_angularVelocity = bd.angularVelocity;

            m_linearDamping = bd.linearDamping;
            m_angularDamping = bd.angularDamping;
            m_gravityScale = bd.gravityScale;

            m_force = Vector2.Zero;
            m_torque = 0.0f;

            m_sleepTime = 0.0f;

            m_type = bd.type;

            m_mass = 0.0f;
            m_invMass = 0.0f;

            m_I = 0.0f;
            m_invI = 0.0f;

            UserData = bd.userData;

            m_fixtureList = null;
            m_fixtureCount = 0;
        }


        /// <summary>
        /// Gets the value of the transform
        /// </summary>
        public Transform Transform
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_xf;
        }

        /// <summary>
        /// Gets the value of the position
        /// </summary>
        public Vector2 Position
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_xf.p;
        }

        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public object UserData
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            private set;
        }

        // public
        /// <summary>
        ///     Creates a fixture and attaches it to this body. Use this function if you need
        ///     to set some fixture parameters, like friction. Otherwise you can create the
        ///     fixture directly from a shape.
        ///     If the density is non-zero, this function automatically updates the mass of the body.
        ///     Contacts are not created until the next time step.
        /// </summary>
        /// <param name="def">the fixture definition.</param>
        /// <warning>This function is locked during callbacks.</warning>
        public Fixture CreateFixture(in FixtureDef def)
        {
            //Debug.Assert(_world.IsLocked() == false);
            if (m_world.IsLocked())
            {
                throw new
                    Box2DException(
                        "Cannot create fixtures in the middle of Step. Has this been spawned from an event such as a ContactListener callback?");
            }

            Fixture fixture = new Fixture();
            fixture.Create(this, def);

            if (HasFlag(BodyFlags.Enabled))
            {
                BroadPhase broadPhase = m_world.m_contactManager.m_broadPhase;
                fixture.CreateProxies(broadPhase, m_xf);
            }

            fixture.m_next = m_fixtureList;
            m_fixtureList = fixture;
            ++m_fixtureCount;

            fixture.m_body = this;

            // Adjust mass properties if needed.
            if (fixture.m_density > 0.0f)
            {
                ResetMassData();
            }

            // Let the world know we have a new fixture. This will cause new contacts
            // to be created at the beginning of the next time step.
            m_world.m_newContacts = true;

            return fixture;
        }

        /// <summary>
        ///     Creates a fixture from a shape and attach it to this body.
        ///     This is a convenience function. Use b2FixtureDef if you need to set parameters
        ///     like friction, restitution, user data, or filtering.
        ///     If the density is non-zero, this function automatically updates the mass of the body.
        /// </summary>
        /// <param name="shape">the shape to be cloned.</param>
        /// <param name="density">the shape density (set to zero for static bodies).</param>
        /// <warning>This function is locked during callbacks.</warning>
        public Fixture CreateFixture(in Shape shape, float density = 0f)
        {
            FixtureDef def = new FixtureDef();
            def.shape = shape;
            def.density = density;

            return CreateFixture(def);
        }

        /// <summary>
        /// Destroys the fixture using the specified fixture
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <exception cref="                    Box2DException">Cannot destroy fixtures in the middle of Step. Has this been spawned from an event such as a ContactListener callback?</exception>
        /// <exception cref="ArgumentException">Fixture does not belong to this Body. </exception>
        public void DestroyFixture(Fixture fixture)
        {
            if (fixture == null)
            {
                return;
            }

            //Debug.Assert(_world.IsLocked() == false);
            if (m_world.IsLocked())
            {
                throw new
                    Box2DException(
                        "Cannot destroy fixtures in the middle of Step. Has this been spawned from an event such as a ContactListener callback?");
            }

            //Debug.Assert(fixture.m_body == this);

            // Remove the fixture from this body's singly linked list.
            //Debug.Assert(_fixtureCount > 0);
            Fixture node = m_fixtureList;
            Fixture prevNode = null;
            bool found = false;
            while (node != null)
            {
                if (node == fixture)
                {
                    if (prevNode == null)
                    {
                        m_fixtureList = fixture.m_next;
                    }
                    else
                    {
                        prevNode.m_next = fixture.m_next;
                    }

                    found = true;
                    break;
                }

                prevNode = node;
                node = node.m_next;
            }

            // You tried to remove a shape that is not attached to this body.
            if (!found)
            {
                throw new ArgumentException("Fixture does not belong to this Body.", nameof(fixture));
            }

            float density = fixture.m_density;

            // Destroy any contacts associated with the fixture.
            ContactEdge edge = m_contactList;
            while (edge != null)
            {
                Contact c = edge.contact;
                edge = edge.next;

                Fixture fixtureA = c.GetFixtureA();
                Fixture fixtureB = c.GetFixtureB();

                if (fixture == fixtureA || fixture == fixtureB)
                    // This destroys the contact and removes it from
                    // this body's contact list.
                {
                    m_world.m_contactManager.Destroy(c);
                }
            }

            if (HasFlag(BodyFlags.Enabled))
            {
                BroadPhase broadPhase = m_world.m_contactManager.m_broadPhase;
                fixture.DestroyProxies(broadPhase);
            }

            fixture.m_body = null;
            fixture.m_next = null;

            --m_fixtureCount;

            if (density > 0.0f)
            {
                // Reset the mass data.
                ResetMassData();
            }
        }

        /// <summary>
        /// Sets the transform using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="angle">The angle</param>
        public void SetTransform(in Vector2 position, float angle)
        {
            //Debug.Assert(_world.IsLocked() == false);
            if (m_world.IsLocked())
            {
                return;
            }

            m_xf.q = Matrex.CreateRotation(angle); //  Actually about twice as fast to use our own function
            m_xf.p = position;

            m_sweep.c = Math.Mul(m_xf, m_sweep.localCenter);
            m_sweep.a = angle;

            m_sweep.c0 = m_sweep.c;
            m_sweep.a0 = angle;

            BroadPhase broadPhase = m_world.m_contactManager.m_broadPhase;
            for (Fixture f = m_fixtureList; f != null; f = f.m_next)
            {
                f.Synchronize(broadPhase, m_xf, m_xf);
            }

            m_world.m_newContacts = true;
        }

        /// <summary>
        /// Gets the transform
        /// </summary>
        /// <returns>The transform</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Transform GetTransform() => m_xf;

        /// <summary>
        /// Gets the position
        /// </summary>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetPosition() => m_xf.p;

        /// <summary>
        /// Gets the angle
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetAngle() => m_sweep.a;

        /// <summary>
        /// Gets the world center
        /// </summary>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetWorldCenter() => m_sweep.c;

        /// <summary>
        /// Gets the local center
        /// </summary>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetLocalCenter() => m_sweep.localCenter;

        /// <summary>
        /// Sets the linear velocity using the specified v
        /// </summary>
        /// <param name="v">The </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLinearVelocity(in Vector2 v)
        {
            if (m_type == BodyType.Static)
            {
                return;
            }

            if (Vector2.Dot(v, v) > 0f)
            {
                SetAwake(true);
            }

            m_linearVelocity = v;
        }

        /// <summary>
        /// Gets the linear velocity
        /// </summary>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetLinearVelocity() => m_linearVelocity;

        /// <summary>
        /// Sets the angular velocity using the specified omega
        /// </summary>
        /// <param name="omega">The omega</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAngularVelocity(float omega)
        {
            if (m_type == BodyType.Static)
            {
                return;
            }

            if (omega * omega > 0f)
            {
                SetAwake(true);
            }

            m_angularVelocity = omega;
        }

        /// <summary>
        /// Gets the angular velocity
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetAngularVelocity() => m_angularVelocity;

        /// <summary>
        /// Applies the force using the specified force
        /// </summary>
        /// <param name="force">The force</param>
        /// <param name="point">The point</param>
        /// <param name="wake">The wake</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyForce(in Vector2 force, in Vector2 point, bool wake = true)
        {
            if (m_type != BodyType.Dynamic)
            {
                return;
            }

            if (wake && !HasFlag(BodyFlags.Awake))
            {
                SetAwake(true);
            }

            if (HasFlag(BodyFlags.Awake))
            {
                m_force += force;
                m_torque += Vectex.Cross(point - m_sweep.c, force);
            }
        }

        /// <summary>
        /// Applies the force to center using the specified force
        /// </summary>
        /// <param name="force">The force</param>
        /// <param name="wake">The wake</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyForceToCenter(in Vector2 force, bool wake = true)
        {
            if (m_type != BodyType.Dynamic)
            {
                return;
            }

            if (wake && !HasFlag(BodyFlags.Awake))
            {
                SetAwake(true);
            }

            if (HasFlag(BodyFlags.Awake))
            {
                m_force += force;
            }
        }

        /// <summary>
        /// Applies the torque using the specified torque
        /// </summary>
        /// <param name="torque">The torque</param>
        /// <param name="wake">The wake</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyTorque(float torque, bool wake = true)
        {
            if (m_type != BodyType.Dynamic)
            {
                return;
            }

            if (wake && !HasFlag(BodyFlags.Awake))
            {
                SetAwake(true);
            }

            if (HasFlag(BodyFlags.Awake))
            {
                m_torque += torque;
            }
        }

        /// <summary>
        /// Applies the linear impulse using the specified impulse
        /// </summary>
        /// <param name="impulse">The impulse</param>
        /// <param name="point">The point</param>
        /// <param name="wake">The wake</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyLinearImpulse(in Vector2 impulse, in Vector2 point, bool wake = true)
        {
            if (m_type != BodyType.Dynamic)
            {
                return;
            }

            if (wake && !HasFlag(BodyFlags.Awake))
            {
                SetAwake(true);
            }

            if (HasFlag(BodyFlags.Awake))
            {
                m_linearVelocity += m_invMass * impulse;
                m_torque += m_invI * Vectex.Cross(point - m_sweep.c, impulse);
            }
        }

        /// <summary>
        /// Applies the linear impulse to center using the specified impulse
        /// </summary>
        /// <param name="impulse">The impulse</param>
        /// <param name="wake">The wake</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyLinearImpulseToCenter(in Vector2 impulse, bool wake = true)
        {
            if (m_type != BodyType.Dynamic)
            {
                return;
            }

            if (wake && !HasFlag(BodyFlags.Awake))
            {
                SetAwake(true);
            }

            if (HasFlag(BodyFlags.Awake))
            {
                m_linearVelocity += m_invMass * impulse;
            }
        }

        /// <summary>
        /// Applies the angular impulse using the specified impulse
        /// </summary>
        /// <param name="impulse">The impulse</param>
        /// <param name="wake">The wake</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ApplyAngularImpulse(float impulse, bool wake = true)
        {
            if (m_type != BodyType.Dynamic)
            {
                return;
            }

            if (wake && !HasFlag(BodyFlags.Awake))
            {
                SetAwake(true);
            }

            if (HasFlag(BodyFlags.Awake))
            {
                m_angularVelocity += m_invI * impulse;
            }
        }

        /// <summary>
        /// Gets the mass
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetMass() => m_mass;

        /// <summary>
        /// Gets the inertia
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetInertia() => m_I + m_mass * Vector2.Dot(m_sweep.localCenter, m_sweep.localCenter);

        /// <summary>
        /// Gets the mass data using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        public void GetMassData(out MassData data)
        {
            data.mass = m_mass;
            data.I = m_I + m_mass * Vector2.Dot(m_sweep.localCenter, m_sweep.localCenter);
            data.center = m_sweep.localCenter;
        }

        /// <summary>
        /// Sets the mass data using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        public void SetMassData(in MassData massData)
        {
            //Debug.Assert(_world.IsLocked() == false);
            if (m_world.IsLocked())
            {
                return;
            }

            if (m_type != BodyType.Dynamic)
            {
                return;
            }

            m_invMass = 0.0f;
            m_I = 0.0f;
            m_invI = 0.0f;

            m_mass = massData.mass;
            if (m_mass <= 0.0f)
            {
                m_mass = 1.0f;
            }

            m_invMass = 1.0f / m_mass;

            if (massData.I > 0.0f && !HasFlag(BodyFlags.FixedRotation))
            {
                m_I = massData.I - m_mass * Vector2.Dot(massData.center, massData.center);
                //Debug.Assert(_I > 0.0f);
                m_invI = 1.0f / m_I;
            }

            // Move center of mass.
            Vector2 oldCenter = m_sweep.c;
            m_sweep.localCenter = massData.center;
            m_sweep.c0 = m_sweep.c = Math.Mul(m_xf, m_sweep.localCenter);

            // Update center of mass velocity.
            m_linearVelocity += Vectex.Cross(m_angularVelocity, m_sweep.c - oldCenter);
        }

        /// <summary>
        /// Resets the mass data
        /// </summary>
        public void ResetMassData()
        {
            // Compute mass data from shapes. Each shape has its own density.
            m_mass = 0.0f;
            m_invMass = 0.0f;
            m_I = 0.0f;
            m_invI = 0.0f;
            m_sweep.localCenter = Vector2.Zero;

            // Static and kinematic bodies have zero mass.
            if (m_type == BodyType.Static || m_type == BodyType.Kinematic)
            {
                m_sweep.c0 = m_xf.p;
                m_sweep.c = m_xf.p;
                m_sweep.a0 = m_sweep.a;
                return;
            }

            //Debug.Assert(_type == BodyType.Dynamic);

            // Accumulate mass over all fixtures.
            Vector2 localCenter = Vector2.Zero;
            for (Fixture f = m_fixtureList; f != null; f = f.m_next)
            {
                if (f.m_density == 0.0f)
                {
                    continue;
                }

                f.GetMassData(out MassData massData);
                m_mass += massData.mass;
                localCenter += massData.mass * massData.center;
                m_I += massData.I;
            }

            // Compute center of mass.
            if (m_mass > 0.0f)
            {
                m_invMass = 1.0f / m_mass;
                localCenter *= m_invMass;
            }

            if (m_I > 0.0f && !HasFlag(BodyFlags.FixedRotation))
            {
                // Center the inertia about the center of mass.
                m_I -= m_mass * Vector2.Dot(localCenter, localCenter);
                //Debug.Assert(_I > 0.0f);
                m_invI = 1.0f / m_I;
            }
            else
            {
                m_I = 0.0f;
                m_invI = 0.0f;
            }

            // Move center of mass.
            Vector2 oldCenter = m_sweep.c;
            m_sweep.localCenter = localCenter;
            m_sweep.c0 = m_sweep.c = Math.Mul(m_xf, m_sweep.localCenter);

            // Update center of mass velocity.
            m_linearVelocity += Vectex.Cross(m_angularVelocity, m_sweep.c - oldCenter);
        }

        /// <summary>
        /// Gets the world point using the specified local point
        /// </summary>
        /// <param name="localPoint">The local point</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetWorldPoint(in Vector2 localPoint) => Math.Mul(m_xf, localPoint);

        /// <summary>
        /// Gets the world vector using the specified local vector
        /// </summary>
        /// <param name="localVector">The local vector</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetWorldVector(in Vector2 localVector) =>
            Vector2.Transform(localVector, m_xf.q); //  Math.Mul(_xf.q, localVector);

        /// <summary>
        /// Gets the local point using the specified world point
        /// </summary>
        /// <param name="worldPoint">The world point</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetLocalPoint(in Vector2 worldPoint) => Math.MulT(m_xf, worldPoint);

        /// <summary>
        /// Gets the local vector using the specified world vector
        /// </summary>
        /// <param name="worldVector">The world vector</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetLocalVector(in Vector2 worldVector) => Math.MulT(m_xf.q, worldVector);

        /// <summary>
        /// Gets the linear velocity from world point using the specified world point
        /// </summary>
        /// <param name="worldPoint">The world point</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetLinearVelocityFromWorldPoint(in Vector2 worldPoint) =>
            m_linearVelocity + Vectex.Cross(m_angularVelocity, worldPoint - m_sweep.c);

        /// <summary>
        /// Gets the linear velocity from local point using the specified local point
        /// </summary>
        /// <param name="localPoint">The local point</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetLinearVelocityFromLocalPoint(in Vector2 localPoint) =>
            GetLinearVelocityFromWorldPoint(GetWorldPoint(localPoint));

        /// <summary>
        /// Gets the linear damping
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetLinearDamping() => m_linearDamping;

        /// <summary>
        /// Sets the linear dampling using the specified linear damping
        /// </summary>
        /// <param name="linearDamping">The linear damping</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLinearDampling(float linearDamping)
        {
            m_linearDamping = linearDamping;
        }

        /// <summary>
        /// Gets the angular damping
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetAngularDamping() => m_angularDamping;

        /// <summary>
        /// Sets the angular damping using the specified angular damping
        /// </summary>
        /// <param name="angularDamping">The angular damping</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAngularDamping(float angularDamping)
        {
            m_angularDamping = angularDamping;
        }

        /// <summary>
        /// Gets the gravity scale
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetGravityScale() => m_gravityScale;

        /// <summary>
        /// Sets the gravity scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetGravityScale(float scale)
        {
            m_gravityScale = scale;
        }

        /// <summary>
        /// Sets the type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        public void SetType(BodyType type)
        {
            //Debug.Assert(_world.IsLocked() == false);
            if (m_world.IsLocked())
            {
                return;
            }

            if (m_type == type)
            {
                return;
            }

            m_type = type;

            ResetMassData();

            if (m_type == BodyType.Static)
            {
                m_linearVelocity = Vector2.Zero;
                m_angularVelocity = 0.0f;
                m_sweep.a0 = m_sweep.a;
                m_sweep.c0 = m_sweep.c;
                m_flags &= ~BodyFlags.Awake;
                SynchronizeFixtures();
            }

            SetAwake(true);

            m_force = Vector2.Zero;
            m_torque = 0.0f;

            // Delete the attached contacts.
            ContactEdge ce = m_contactList;
            while (ce != null)
            {
                ContactEdge ce0 = ce;
                ce = ce.next;
                m_world.m_contactManager.Destroy(ce0.contact);
            }

            m_contactList = null;

            // Touch the proxies so that new contacts will be created (when appropriate)
            BroadPhase broadPhase = m_world.m_contactManager.m_broadPhase;
            for (Fixture f = m_fixtureList; f != null; f = f.m_next)
            {
                int proxyCount = f.m_proxyCount;
                for (int i = 0; i < proxyCount; ++i)
                {
                    broadPhase.TouchProxy(f.m_proxies[i].proxyId);
                }
            }
        }

        /// <summary>
        /// Types this instance
        /// </summary>
        /// <returns>The body type</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BodyType Type() => m_type;

        /// <summary>
        /// Sets the flag using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SetFlag(BodyFlags flag)
        {
            m_flags |= flag;
        }

        /// <summary>
        /// Unsets the flag using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void UnsetFlag(BodyFlags flag)
        {
            m_flags &= ~flag;
        }

        /// <summary>
        /// Sets the bullet using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetBullet(bool flag)
        {
            if (flag)
            {
                SetFlag(BodyFlags.Bullet);
            }
            else
            {
                UnsetFlag(BodyFlags.Bullet);
            }
        }

        /// <summary>
        /// Describes whether this instance is bullet
        /// </summary>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsBullet() => HasFlag(BodyFlags.Bullet);

        /// <summary>
        /// Sets the sleeping allowed using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetSleepingAllowed(bool flag)
        {
            if (flag)
            {
                SetFlag(BodyFlags.AutoSleep);
            }
            else
            {
                UnsetFlag(BodyFlags.AutoSleep);
                SetAwake(true);
            }
        }

        /// <summary>
        /// Describes whether this instance is sleeping allowed
        /// </summary>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSleepingAllowed() => HasFlag(BodyFlags.AutoSleep);

        /// <summary>
        /// Sets the awake using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAwake(bool flag)
        {
            if (m_type == BodyType.Static)
            {
                return;
            }

            if (flag)
            {
                SetFlag(BodyFlags.Awake);
                m_sleepTime = 0f;
            }
            else
            {
                UnsetFlag(BodyFlags.Awake);
                m_sleepTime = 0f;
                m_linearVelocity = Vector2.Zero;
                m_angularVelocity = 0f;
                m_force = Vector2.Zero;
                m_torque = 0f;
            }
        }

        /// <summary>
        /// Describes whether this instance is awake
        /// </summary>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsAwake() => HasFlag(BodyFlags.Awake);

        /// <summary>
        /// Sets the enabled using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        public void SetEnabled(bool flag)
        {
            //Debug.Assert(_world.IsLocked() == false);

            if (flag == IsEnabled())
            {
                return;
            }

            if (flag)
            {
                SetFlag(BodyFlags.Enabled);

                // Create all proxies.
                BroadPhase broadPhase = m_world.m_contactManager.m_broadPhase;
                for (Fixture f = m_fixtureList; f != null; f = f.m_next)
                {
                    f.CreateProxies(broadPhase, m_xf);
                }

                // Contacts are created at the beginning of the next
                m_world.m_newContacts = true;
            }
            else
            {
                UnsetFlag(BodyFlags.Enabled);

                // Destroy all proxies.
                BroadPhase broadPhase = m_world.m_contactManager.m_broadPhase;
                for (Fixture f = m_fixtureList; f != null; f = f.m_next)
                {
                    f.DestroyProxies(broadPhase);
                }

                // Destroy the attached contacts.
                ContactEdge ce = m_contactList;
                while (ce != null)
                {
                    ContactEdge ce0 = ce;
                    ce = ce.next;
                    m_world.m_contactManager.Destroy(ce0.contact);
                }

                m_contactList = null;
            }
        }

        /// <summary>
        /// Describes whether this instance is enabled
        /// </summary>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled() => HasFlag(BodyFlags.Enabled);

        /// <summary>
        /// Sets the fixed rotation using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        public void SetFixedRotation(bool flag)
        {
            if (flag == HasFlag(BodyFlags.FixedRotation))
            {
                return;
            }

            if (flag)
            {
                SetFlag(BodyFlags.FixedRotation);
            }
            else
            {
                UnsetFlag(BodyFlags.FixedRotation);
            }

            m_angularVelocity = 0.0f;

            ResetMassData();
        }

        /// <summary>
        /// Describes whether this instance is fixed rotation
        /// </summary>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsFixedRotation() => HasFlag(BodyFlags.FixedRotation);

        /// <summary>
        /// Gets the fixture list
        /// </summary>
        /// <returns>The fixture</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fixture GetFixtureList() => m_fixtureList;

        /// <summary>
        /// Gets the joint list
        /// </summary>
        /// <returns>The joint edge</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public JointEdge GetJointList() => m_jointList;

        /// <summary>
        /// Gets the contact list
        /// </summary>
        /// <returns>The contact edge</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContactEdge GetContactList() => m_contactList;

        /// <summary>
        /// Gets the next
        /// </summary>
        /// <returns>The body</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Body GetNext() => m_next;

        /// <summary>
        /// Gets the user data
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetUserData<T>() => (T) UserData;

        /// <summary>
        /// Sets the user data using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetUserData(object data)
        {
            UserData = data;
        }

        /// <summary>
        /// Gets the world
        /// </summary>
        /// <returns>The world world</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public World.World GetWorld() => m_world;

        /// <summary>
        /// Dumps this instance
        /// </summary>
        public void Dump()
        {
            // Todo: Dump in some form. We could just serialize.
        }


        /// <summary>
        /// Synchronizes the fixtures
        /// </summary>
        internal void SynchronizeFixtures()
        {
            BroadPhase broadPhase = m_world.m_contactManager.m_broadPhase;

            if (IsAwake())
            {
                Transform xf1 = new Transform();
                xf1.q = Matrex.CreateRotation(m_sweep.a0); // Actually about twice as fast to use our own function
                xf1.p = m_sweep.c0 -
                        Vector2.Transform(m_sweep.localCenter, xf1.q); //Math.Mul(xf1.q, _sweep.localCenter);

                for (Fixture f = m_fixtureList; f != null; f = f.m_next)
                {
                    f.Synchronize(broadPhase, xf1, m_xf);
                }
            }
            else
            {
                for (Fixture f = m_fixtureList; f != null; f = f.m_next)
                {
                    f.Synchronize(broadPhase, m_xf, m_xf);
                }
            }
        }

        /// <summary>
        /// Synchronizes the transform
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SynchronizeTransform()
        {
            m_xf.q = Matrex.CreateRotation(m_sweep.a); // Actually about twice as fast to use our own function
            m_xf.p = m_sweep.c - Vector2.Transform(m_sweep.localCenter, m_xf.q); // Math.Mul(_xf.q, _sweep.localCenter);
        }

        /// <summary>
        /// Describes whether this instance should collide
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        internal bool ShouldCollide(in Body other)
        {
            // At least one body should be dynamic.
            if (m_type != BodyType.Dynamic && other.m_type != BodyType.Dynamic)
            {
                return false;
            }

            // Does a joint prevent collision?
            for (JointEdge jn = m_jointList; jn != null; jn = jn.next)
            {
                if (jn.other == other && jn.joint.m_collideConnected == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Advances the alpha
        /// </summary>
        /// <param name="alpha">The alpha</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Advance(float alpha)
        {
            // Advance to the new safe time. This doesn't sync the broad-phase.
            m_sweep.Advance(alpha);
            m_sweep.c = m_sweep.c0;
            m_sweep.a = m_sweep.a0;
            m_xf.q = Matrex.CreateRotation(m_sweep.a); // Actually about twice as fast to use our own function
            m_xf.p = m_sweep.c - Vector2.Transform(m_sweep.localCenter, m_xf.q); //Math.Mul(_xf.q, _sweep.localCenter);
        }

        /// <summary>
        /// Describes whether this instance has flag
        /// </summary>
        /// <param name="flag">The flag</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasFlag(BodyFlags flag) => (m_flags & flag) == flag;


        // This is used to prevent connected bodies from colliding.
        // It may lie, depending on the collideConnected flag.
        /// <summary>
        /// Describes whether this instance is connected
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool IsConnected(Body other)
        {
            for (JointEdge jn = m_jointList; jn != null; jn = jn.next)
            {
                if (jn.other == other)
                {
                    return jn.joint.m_collideConnected == false;
                }
            }

            return false;
        }
    }
}