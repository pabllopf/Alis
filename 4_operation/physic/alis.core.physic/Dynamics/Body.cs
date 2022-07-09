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
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Controllers;
using Alis.Core.Physic.Dynamics.Joints;
using Math = Alis.Core.Physic.Common.Math;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     A rigid body. These are created via World.CreateBody.
    /// </summary>
    public class Body : IDisposable
    {
        /// <summary>
        ///     The body flags enum
        /// </summary>
        [Flags]
        public enum BodyFlags
        {
            /// <summary>
            ///     The frozen body flags
            /// </summary>
            Frozen = 0x0002,

            /// <summary>
            ///     The island body flags
            /// </summary>
            Island = 0x0004,

            /// <summary>
            ///     The sleep body flags
            /// </summary>
            Sleep = 0x0008,

            /// <summary>
            ///     The allow sleep body flags
            /// </summary>
            AllowSleep = 0x0010,

            /// <summary>
            ///     The bullet body flags
            /// </summary>
            Bullet = 0x0020,

            /// <summary>
            ///     The fixed rotation body flags
            /// </summary>
            FixedRotation = 0x0040
        }

        /// <summary>
        ///     The body type enum
        /// </summary>
        public enum BodyType
        {
            /// <summary>
            ///     The static body type
            /// </summary>
            Static,

            /// <summary>
            ///     The dynamic body type
            /// </summary>
            Dynamic,

            /// <summary>
            ///     The max types body type
            /// </summary>
            MaxTypes
        }

        /// <summary>
        ///     The angular damping
        /// </summary>
        internal float AngularDamping;

        /// <summary>
        ///     The angular velocity
        /// </summary>
        internal float AngularVelocity;

        /// <summary>
        ///     The contact list
        /// </summary>
        internal ContactEdge ContactList;

        /// <summary>
        ///     The controller list
        /// </summary>
        internal ControllerEdge ControllerList;

        /// <summary>
        ///     The fixture count
        /// </summary>
        internal int FixtureCount;

        /// <summary>
        ///     The fixture list
        /// </summary>
        internal Fixture FixtureList;

        /// <summary>
        ///     The flags
        /// </summary>
        internal BodyFlags Flags;

        /// <summary>
        ///     The force
        /// </summary>
        internal Vec2 Force;

        /// <summary>
        ///     The
        /// </summary>
        internal float I;

        /// <summary>
        ///     The inv
        /// </summary>
        internal float InvI;

        /// <summary>
        ///     The inv mass
        /// </summary>
        internal float InvMass;

        /// <summary>
        ///     The island index
        /// </summary>
        internal int IslandIndex;

        /// <summary>
        ///     The joint list
        /// </summary>
        internal JointEdge JointList;

        /// <summary>
        ///     The linear damping
        /// </summary>
        internal float LinearDamping;

        /// <summary>
        ///     The linear velocity
        /// </summary>
        internal Vec2 LinearVelocity;

        /// <summary>
        ///     The mass
        /// </summary>
        internal float Mass;

        /// <summary>
        ///     The next
        /// </summary>
        internal Body Next;

        /// <summary>
        ///     The prev
        /// </summary>
        internal Body Prev;

        /// <summary>
        ///     The sleep time
        /// </summary>
        internal float SleepTime;

        /// <summary>
        ///     The sweep
        /// </summary>
        internal Sweep Sweep; // the swept motion for CCD

        /// <summary>
        ///     The torque
        /// </summary>
        internal float Torque;

        /// <summary>
        ///     The type
        /// </summary>
        private BodyType type;

        /// <summary>
        ///     The user data
        /// </summary>
        private object userData;

        /// <summary>
        ///     The world
        /// </summary>
        private World world;

        /// <summary>
        ///     The xf
        /// </summary>
        internal XForm Xf; // the body origin transform

        /// <summary>
        ///     Initializes a new instance of the <see cref="Body" /> class
        /// </summary>
        /// <param name="bd">The bd</param>
        /// <param name="world">The world</param>
        internal Body(BodyDef bd, World world)
        {
            Box2DXDebug.Assert(world._lock == false);

            Flags = 0;

            if (bd.IsBullet)
            {
                Flags |= BodyFlags.Bullet;
            }

            if (bd.FixedRotation)
            {
                Flags |= BodyFlags.FixedRotation;
            }

            if (bd.AllowSleep)
            {
                Flags |= BodyFlags.AllowSleep;
            }

            if (bd.IsSleeping)
            {
                Flags |= BodyFlags.Sleep;
            }

            this.world = world;

            Xf.Position = bd.Position;
            Xf.R.Set(bd.Angle);

            Sweep.LocalCenter = bd.MassData.Center;
            Sweep.T0 = 1.0f;
            Sweep.A0 = Sweep.A = bd.Angle;
            Sweep.C0 = Sweep.C = Math.Mul(Xf, Sweep.LocalCenter);

            //_jointList = null;
            //_contactList = null;
            //_controllerList = null;
            //_prev = null;
            //_next = null;

            LinearVelocity = bd.LinearVelocity;
            AngularVelocity = bd.AngularVelocity;

            LinearDamping = bd.LinearDamping;
            AngularDamping = bd.AngularDamping;

            //_force.Set(0.0f, 0.0f);
            //_torque = 0.0f;

            //_linearVelocity.SetZero();
            //_angularVelocity = 0.0f;

            //_sleepTime = 0.0f;

            //_invMass = 0.0f;
            //_I = 0.0f;
            //_invI = 0.0f;

            Mass = bd.MassData.Mass;

            if (Mass > 0.0f)
            {
                InvMass = 1.0f / Mass;
            }

            I = bd.MassData.I;

            if (I > 0.0f && (Flags & BodyFlags.FixedRotation) == 0)
            {
                InvI = 1.0f / I;
            }

            if (InvMass == 0.0f && InvI == 0.0f)
            {
                type = BodyType.Static;
            }
            else
            {
                type = BodyType.Dynamic;
            }

            userData = bd.UserData;

            //_fixtureList = null;
            //_fixtureCount = 0;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Box2DXDebug.Assert(world._lock == false);
            // shapes and joints are destroyed in World.Destroy
        }

        /// <summary>
        ///     Describes whether this instance synchronize fixtures
        /// </summary>
        /// <returns>The bool</returns>
        internal bool SynchronizeFixtures()
        {
            XForm xf1 = new XForm();
            xf1.R.Set(Sweep.A0);
            xf1.Position = Sweep.C0 - Math.Mul(xf1.R, Sweep.LocalCenter);

            bool inRange = true;
            for (Fixture f = FixtureList; f != null; f = f.Next)
            {
                inRange = f.Synchronize(world._broadPhase, xf1, Xf);
                if (inRange == false)
                {
                    break;
                }
            }

            if (inRange == false)
            {
                Flags |= BodyFlags.Frozen;
                LinearVelocity.SetZero();
                AngularVelocity = 0.0f;

                // Failure
                return false;
            }

            // Success
            return true;
        }

        // This is used to prevent connected bodies from colliding.
        // It may lie, depending on the collideConnected flag.
        /// <summary>
        ///     Describes whether this instance is connected
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        internal bool IsConnected(Body other)
        {
            for (JointEdge jn = JointList; jn != null; jn = jn.Next)
            {
                if (jn.Other == other)
                    return jn.Joint.CollideConnected == false;
            }

            return false;
        }

        /// <summary>
        ///     Creates a fixture and attach it to this body.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="def">The fixture definition.</param>
        public Fixture CreateFixture(FixtureDef def)
        {
            Box2DXDebug.Assert(world._lock == false);
            if (world._lock)
            {
                return null;
            }

            BroadPhase broadPhase = world._broadPhase;

            Fixture fixture = new Fixture();
            fixture.Create(broadPhase, this, Xf, def);

            fixture.Next = FixtureList;
            FixtureList = fixture;
            ++FixtureCount;

            fixture.Body = this;

            return fixture;
        }

        /// <summary>
        ///     Destroy a fixture. This removes the fixture from the broad-phase and
        ///     therefore destroys any contacts associated with this fixture. All fixtures
        ///     attached to a body are implicitly destroyed when the body is destroyed.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="fixture">The fixture to be removed.</param>
        public void DestroyFixture(Fixture fixture)
        {
            Box2DXDebug.Assert(world._lock == false);
            if (world._lock)
            {
                return;
            }

            Box2DXDebug.Assert(fixture.Body == this);

            // Remove the fixture from this body's singly linked list.
            Box2DXDebug.Assert(FixtureCount > 0);
            Fixture node = FixtureList;
            bool found = false;
            while (node != null)
            {
                if (node == fixture)
                {
                    //*node = fixture->m_next;
                    FixtureList = fixture.Next;
                    found = true;
                    break;
                }

                node = node.Next;
            }

            // You tried to remove a shape that is not attached to this body.
            Box2DXDebug.Assert(found);

            BroadPhase broadPhase = world._broadPhase;

            fixture.Destroy(broadPhase);
            fixture.Body = null;
            fixture.Next = null;

            --FixtureCount;
        }

        // TODO_ERIN adjust linear velocity and torque to account for movement of center.
        /// <summary>
        ///     Set the mass properties. Note that this changes the center of mass position.
        ///     If you are not sure how to compute mass properties, use SetMassFromShapes.
        ///     The inertia tensor is assumed to be relative to the center of mass.
        /// </summary>
        /// <param name="massData">The mass properties.</param>
        public void SetMass(MassData massData)
        {
            Box2DXDebug.Assert(world._lock == false);
            if (world._lock)
            {
                return;
            }

            InvMass = 0.0f;
            I = 0.0f;
            InvI = 0.0f;

            Mass = massData.Mass;

            if (Mass > 0.0f)
            {
                InvMass = 1.0f / Mass;
            }

            I = massData.I;

            if (I > 0.0f && (Flags & BodyFlags.FixedRotation) == 0)
            {
                InvI = 1.0f / I;
            }

            // Move center of mass.
            Sweep.LocalCenter = massData.Center;
            Sweep.C0 = Sweep.C = Math.Mul(Xf, Sweep.LocalCenter);

            BodyType oldType = type;
            if (InvMass == 0.0f && InvI == 0.0f)
            {
                type = BodyType.Static;
            }
            else
            {
                type = BodyType.Dynamic;
            }

            // If the body type changed, we need to refilter the broad-phase proxies.
            if (oldType != type)
            {
                for (Fixture f = FixtureList; f != null; f = f.Next)
                {
                    f.RefilterProxy(world._broadPhase, Xf);
                }
            }
        }

        // TODO_ERIN adjust linear velocity and torque to account for movement of center.
        /// <summary>
        ///     Compute the mass properties from the attached shapes. You typically call this
        ///     after adding all the shapes. If you add or remove shapes later, you may want
        ///     to call this again. Note that this changes the center of mass position.
        /// </summary>
        public void SetMassFromShapes()
        {
            Box2DXDebug.Assert(world._lock == false);
            if (world._lock)
            {
                return;
            }

            // Compute mass data from shapes. Each shape has its own density.
            Mass = 0.0f;
            InvMass = 0.0f;
            I = 0.0f;
            InvI = 0.0f;

            Vec2 center = Vec2.Zero;
            for (Fixture f = FixtureList; f != null; f = f.Next)
            {
                MassData massData;
                f.ComputeMass(out massData);
                Mass += massData.Mass;
                center += massData.Mass * massData.Center;
                I += massData.I;
            }

            // Compute center of mass, and shift the origin to the COM.
            if (Mass > 0.0f)
            {
                InvMass = 1.0f / Mass;
                center *= InvMass;
            }

            if (I > 0.0f && (Flags & BodyFlags.FixedRotation) == 0)
            {
                // Center the inertia about the center of mass.
                I -= Mass * Vec2.Dot(center, center);
                Box2DXDebug.Assert(I > 0.0f);
                InvI = 1.0f / I;
            }
            else
            {
                I = 0.0f;
                InvI = 0.0f;
            }

            // Move center of mass.
            Sweep.LocalCenter = center;
            Sweep.C0 = Sweep.C = Math.Mul(Xf, Sweep.LocalCenter);

            BodyType oldType = type;
            if (InvMass == 0.0f && InvI == 0.0f)
            {
                type = BodyType.Static;
            }
            else
            {
                type = BodyType.Dynamic;
            }

            // If the body type changed, we need to refilter the broad-phase proxies.
            if (oldType != type)
            {
                for (Fixture f = FixtureList; f != null; f = f.Next)
                {
                    f.RefilterProxy(world._broadPhase, Xf);
                }
            }
        }

        /// <summary>
        ///     Set the position of the body's origin and rotation (radians).
        ///     This breaks any contacts and wakes the other bodies.
        /// </summary>
        /// <param name="position">
        ///     The new world position of the body's origin (not necessarily
        ///     the center of mass).
        /// </param>
        /// <param name="angle">The new world rotation angle of the body in radians.</param>
        /// <returns>
        ///     Return false if the movement put a shape outside the world. In this case the
        ///     body is automatically frozen.
        /// </returns>
        public bool SetXForm(Vec2 position, float angle)
        {
            Box2DXDebug.Assert(world._lock == false);
            if (world._lock)
            {
                return true;
            }

            if (IsFrozen())
            {
                return false;
            }

            Xf.R.Set(angle);
            Xf.Position = position;

            Sweep.C0 = Sweep.C = Math.Mul(Xf, Sweep.LocalCenter);
            Sweep.A0 = Sweep.A = angle;

            bool freeze = false;
            for (Fixture f = FixtureList; f != null; f = f.Next)
            {
                bool inRange = f.Synchronize(world._broadPhase, Xf, Xf);

                if (inRange == false)
                {
                    freeze = true;
                    break;
                }
            }

            if (freeze)
            {
                Flags |= BodyFlags.Frozen;
                LinearVelocity.SetZero();
                AngularVelocity = 0.0f;

                // Failure
                return false;
            }

            // Success
            world._broadPhase.Commit();
            return true;
        }

        /// <summary>
        ///     Set the position of the body's origin and rotation (radians).
        ///     This breaks any contacts and wakes the other bodies.
        ///     Note this is less efficient than the other overload - you should use that
        ///     if the angle is available.
        /// </summary>
        /// <param name="xf">The transform of position and angle to set the body to.</param>
        /// <returns>
        ///     False if the movement put a shape outside the world. In this case the
        ///     body is automatically frozen.
        /// </returns>
        public bool SetXForm(XForm xf)
        {
            return SetXForm(xf.Position, xf.GetAngle());
        }

        /// <summary>
        ///     Get the body transform for the body's origin.
        /// </summary>
        /// <returns>Return the world transform of the body's origin.</returns>
        public XForm GetXForm()
        {
            return Xf;
        }

        /// <summary>
        ///     Set the world body origin position.
        /// </summary>
        /// <param name="position">The new position of the body.</param>
        public void SetPosition(Vec2 position)
        {
            SetXForm(position, GetAngle());
        }

        /// <summary>
        ///     Set the world body angle.
        /// </summary>
        /// <param name="angle">The new angle of the body.</param>
        public void SetAngle(float angle)
        {
            SetXForm(GetPosition(), angle);
        }

        /// <summary>
        ///     Get the world body origin position.
        /// </summary>
        /// <returns>Return the world position of the body's origin.</returns>
        public Vec2 GetPosition()
        {
            return Xf.Position;
        }

        /// <summary>
        ///     Get the angle in radians.
        /// </summary>
        /// <returns>Return the current world rotation angle in radians.</returns>
        public float GetAngle()
        {
            return Sweep.A;
        }

        /// <summary>
        ///     Get the world position of the center of mass.
        /// </summary>
        /// <returns></returns>
        public Vec2 GetWorldCenter()
        {
            return Sweep.C;
        }

        /// <summary>
        ///     Get the local position of the center of mass.
        /// </summary>
        /// <returns></returns>
        public Vec2 GetLocalCenter()
        {
            return Sweep.LocalCenter;
        }

        /// <summary>
        ///     Set the linear velocity of the center of mass.
        /// </summary>
        /// <param name="v">The new linear velocity of the center of mass.</param>
        public void SetLinearVelocity(Vec2 v)
        {
            LinearVelocity = v;
        }

        /// <summary>
        ///     Get the linear velocity of the center of mass.
        /// </summary>
        /// <returns>Return the linear velocity of the center of mass.</returns>
        public Vec2 GetLinearVelocity()
        {
            return LinearVelocity;
        }

        /// <summary>
        ///     Sets the angular velocity.
        /// </summary>
        /// <param name="w">The w.</param>
        public void SetAngularVelocity(float w)
        {
            AngularVelocity = w;
        }

        /// <summary>
        ///     Get the angular velocity.
        /// </summary>
        /// <returns>Return the angular velocity in radians/second.</returns>
        public float GetAngularVelocity()
        {
            return AngularVelocity;
        }

        /// <summary>
        ///     Apply a force at a world point. If the force is not
        ///     applied at the center of mass, it will generate a torque and
        ///     affect the angular velocity. This wakes up the body.
        /// </summary>
        /// <param name="force">The world force vector, usually in Newtons (N).</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyForce(Vec2 force, Vec2 point)
        {
            if (IsSleeping())
            {
                WakeUp();
            }

            Force += force;
            Torque += Vec2.Cross(point - Sweep.C, force);
        }

        /// <summary>
        ///     Apply a torque. This affects the angular velocity
        ///     without affecting the linear velocity of the center of mass.
        ///     This wakes up the body.
        /// </summary>
        /// <param name="torque">Torque about the z-axis (out of the screen), usually in N-m.</param>
        public void ApplyTorque(float torque)
        {
            if (IsSleeping())
            {
                WakeUp();
            }

            Torque += torque;
        }

        /// <summary>
        ///     Apply an impulse at a point. This immediately modifies the velocity.
        ///     It also modifies the angular velocity if the point of application
        ///     is not at the center of mass. This wakes up the body.
        /// </summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyImpulse(Vec2 impulse, Vec2 point)
        {
            if (IsSleeping())
            {
                WakeUp();
            }

            LinearVelocity += InvMass * impulse;
            AngularVelocity += InvI * Vec2.Cross(point - Sweep.C, impulse);
        }

        /// <summary>
        ///     Get the total mass of the body.
        /// </summary>
        /// <returns>Return the mass, usually in kilograms (kg).</returns>
        public float GetMass()
        {
            return Mass;
        }

        /// <summary>
        ///     Get the central rotational inertia of the body.
        /// </summary>
        /// <returns>Return the rotational inertia, usually in kg-m^2.</returns>
        public float GetInertia()
        {
            return I;
        }

        /// <summary>
        ///     Get the mass data of the body.
        /// </summary>
        /// <returns>A struct containing the mass, inertia and center of the body.</returns>
        public MassData GetMassData()
        {
            MassData massData = new MassData();
            massData.Mass = Mass;
            massData.I = I;
            massData.Center = GetWorldCenter();
            return massData;
        }

        /// <summary>
        ///     Get the world coordinates of a point given the local coordinates.
        /// </summary>
        /// <param name="localPoint">A point on the body measured relative the the body's origin.</param>
        /// <returns>Return the same point expressed in world coordinates.</returns>
        public Vec2 GetWorldPoint(Vec2 localPoint)
        {
            return Math.Mul(Xf, localPoint);
        }

        /// <summary>
        ///     Get the world coordinates of a vector given the local coordinates.
        /// </summary>
        /// <param name="localVector">A vector fixed in the body.</param>
        /// <returns>Return the same vector expressed in world coordinates.</returns>
        public Vec2 GetWorldVector(Vec2 localVector)
        {
            return Math.Mul(Xf.R, localVector);
        }

        /// <summary>
        ///     Gets a local point relative to the body's origin given a world point.
        /// </summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>Return the corresponding local point relative to the body's origin.</returns>
        public Vec2 GetLocalPoint(Vec2 worldPoint)
        {
            return Math.MulT(Xf, worldPoint);
        }

        /// <summary>
        ///     Gets a local vector given a world vector.
        /// </summary>
        /// <param name="worldVector">A vector in world coordinates.</param>
        /// <returns>Return the corresponding local vector.</returns>
        public Vec2 GetLocalVector(Vec2 worldVector)
        {
            return Math.MulT(Xf.R, worldVector);
        }

        /// <summary>
        ///     Get the world linear velocity of a world point attached to this body.
        /// </summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vec2 GetLinearVelocityFromWorldPoint(Vec2 worldPoint)
        {
            return LinearVelocity + Vec2.Cross(AngularVelocity, worldPoint - Sweep.C);
        }

        /// <summary>
        ///     Get the world velocity of a local point.
        /// </summary>
        /// <param name="localPoint">A point in local coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vec2 GetLinearVelocityFromLocalPoint(Vec2 localPoint)
        {
            return GetLinearVelocityFromWorldPoint(GetWorldPoint(localPoint));
        }

        /// <summary>
        ///     Gets the linear damping
        /// </summary>
        /// <returns>The linear damping</returns>
        public float GetLinearDamping()
        {
            return LinearDamping;
        }

        /// <summary>
        ///     Sets the linear damping using the specified linear damping
        /// </summary>
        /// <param name="linearDamping">The linear damping</param>
        public void SetLinearDamping(float linearDamping)
        {
            LinearDamping = linearDamping;
        }

        /// <summary>
        ///     Gets the angular damping
        /// </summary>
        /// <returns>The angular damping</returns>
        public float GetAngularDamping()
        {
            return AngularDamping;
        }

        /// <summary>
        ///     Sets the angular damping using the specified angular damping
        /// </summary>
        /// <param name="angularDamping">The angular damping</param>
        public void SetAngularDamping(float angularDamping)
        {
            AngularDamping = angularDamping;
        }

        /// <summary>
        ///     Is this body treated like a bullet for continuous collision detection?
        /// </summary>
        /// <returns></returns>
        public bool IsBullet()
        {
            return (Flags & BodyFlags.Bullet) == BodyFlags.Bullet;
        }

        /// <summary>
        ///     Should this body be treated like a bullet for continuous collision detection?
        /// </summary>
        /// <param name="flag"></param>
        public void SetBullet(bool flag)
        {
            if (flag)
            {
                Flags |= BodyFlags.Bullet;
            }
            else
            {
                Flags &= ~BodyFlags.Bullet;
            }
        }

        /// <summary>
        ///     Describes whether this instance is fixed rotation
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsFixedRotation()
        {
            return (Flags & BodyFlags.FixedRotation) == BodyFlags.FixedRotation;
        }

        /// <summary>
        ///     Sets the fixed rotation using the specified fixedr
        /// </summary>
        /// <param name="fixedr">The fixedr</param>
        public void SetFixedRotation(bool fixedr)
        {
            if (fixedr)
            {
                AngularVelocity = 0.0f;
                InvI = 0.0f;
                Flags |= BodyFlags.FixedRotation;
            }
            else
            {
                if (I > 0.0f)
                {
                    // Recover _invI from _I.
                    InvI = 1.0f / I;
                    Flags &= BodyFlags.FixedRotation;
                }
                // TODO: Else what?
            }
        }

        /// <summary>
        ///     Is this body static (immovable)?
        /// </summary>
        /// <returns></returns>
        public bool IsStatic()
        {
            return type == BodyType.Static;
        }

        /// <summary>
        ///     Sets the static
        /// </summary>
        public void SetStatic()
        {
            if (type == BodyType.Static)
                return;
            Mass = 0.0f;
            InvMass = 0.0f;
            I = 0.0f;
            InvI = 0.0f;
            type = BodyType.Static;

            for (Fixture f = FixtureList; f != null; f = f.Next)
            {
                f.RefilterProxy(world._broadPhase, Xf);
            }
        }

        /// <summary>
        ///     Is this body dynamic (movable)?
        /// </summary>
        /// <returns></returns>
        public bool IsDynamic()
        {
            return type == BodyType.Dynamic;
        }

        /// <summary>
        ///     Is this body frozen?
        /// </summary>
        /// <returns></returns>
        public bool IsFrozen()
        {
            return (Flags & BodyFlags.Frozen) == BodyFlags.Frozen;
        }

        /// <summary>
        ///     Is this body sleeping (not simulating).
        /// </summary>
        /// <returns></returns>
        public bool IsSleeping()
        {
            return (Flags & BodyFlags.Sleep) == BodyFlags.Sleep;
        }

        /// <summary>
        ///     Describes whether this instance is allow sleeping
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsAllowSleeping()
        {
            return (Flags & BodyFlags.AllowSleep) == BodyFlags.AllowSleep;
        }

        /// <summary>
        ///     You can disable sleeping on this body.
        /// </summary>
        /// <param name="flag"></param>
        public void AllowSleeping(bool flag)
        {
            if (flag)
            {
                Flags |= BodyFlags.AllowSleep;
            }
            else
            {
                Flags &= ~BodyFlags.AllowSleep;
                WakeUp();
            }
        }

        /// <summary>
        ///     Wake up this body so it will begin simulating.
        /// </summary>
        public void WakeUp()
        {
            Flags &= ~BodyFlags.Sleep;
            SleepTime = 0.0f;
        }

        /// <summary>
        ///     Put this body to sleep so it will stop simulating.
        ///     This also sets the velocity to zero.
        /// </summary>
        public void PutToSleep()
        {
            Flags |= BodyFlags.Sleep;
            SleepTime = 0.0f;
            LinearVelocity.SetZero();
            AngularVelocity = 0.0f;
            Force.SetZero();
            Torque = 0.0f;
        }

        /// <summary>
        ///     Get the list of all fixtures attached to this body.
        /// </summary>
        /// <returns></returns>
        public Fixture GetFixtureList()
        {
            return FixtureList;
        }

        /// <summary>
        ///     Get the list of all joints attached to this body.
        /// </summary>
        /// <returns></returns>
        public JointEdge GetJointList()
        {
            return JointList;
        }

        /// <summary>
        ///     Gets the controller list
        /// </summary>
        /// <returns>The controller list</returns>
        public ControllerEdge GetControllerList()
        {
            return ControllerList;
        }

        /// <summary>
        ///     Get the next body in the world's body list.
        /// </summary>
        /// <returns></returns>
        public Body GetNext()
        {
            return Next;
        }

        /// <summary>
        ///     Get the user data pointer that was provided in the body definition.
        /// </summary>
        /// <returns></returns>
        public object GetUserData()
        {
            return userData;
        }

        /// <summary>
        ///     Set the user data. Use this to store your application specific data.
        /// </summary>
        /// <param name="data"></param>
        public void SetUserData(object data)
        {
            userData = data;
        }

        /// <summary>
        ///     Get the parent world of this body.
        /// </summary>
        /// <returns></returns>
        public World GetWorld()
        {
            return world;
        }

        /// <summary>
        ///     Synchronizes the transform
        /// </summary>
        internal void SynchronizeTransform()
        {
            Xf.R.Set(Sweep.A);
            Xf.Position = Sweep.C - Math.Mul(Xf.R, Sweep.LocalCenter);
        }

        /// <summary>
        ///     Advances the t
        /// </summary>
        /// <param name="t">The </param>
        internal void Advance(float t)
        {
            // Advance to the new safe time.
            Sweep.Advance(t);
            Sweep.C = Sweep.C0;
            Sweep.A = Sweep.A0;
            SynchronizeTransform();
        }
    }
}