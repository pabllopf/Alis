// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Body.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Broadphase;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Dynamics.Joints.Misc;
using Alis.Core.Physic.Extensions.Controllers.ControllerBase;
using Alis.Core.Physic.Extensions.PhysicsLogics.PhysicsLogicBase;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The body class
    /// </summary>
    public class Body
    {
        /// <summary>
        ///     The angular velocity
        /// </summary>
        private float angularVelocity;

        /// <summary>
        ///     The inertia
        /// </summary>
        private float inertia;

        /// <summary>
        ///     The linear velocity
        /// </summary>
        private Vector2F linearVelc;

        /// <summary>
        ///     The mass
        /// </summary>
        private float mass;

        /// <summary>
        ///     Fires when two shapes collide and a contact is created between them. Note that the first fixture argument is
        ///     always the fixture that the delegate is subscribed to.
        /// </summary>
        public OnCollisionHandler OnCollision;

        /// <summary>
        ///     Fires when two shapes separate and a contact is removed between them. Note: This can in some cases be called
        ///     multiple times, as a fixture can have multiple contacts. Note The first fixture argument is always the fixture that
        ///     the
        ///     delegate is subscribed to.
        /// </summary>
        public OnSeparationHandler OnSeparation;

        /// <summary>
        ///     The type
        /// </summary>
        internal BodyType Type;

        /// <summary>
        ///     The world
        /// </summary>
        internal World World;

        /// <summary>
        ///     The xf
        /// </summary>
        internal Transform Xf; // the body origin transform

        
        /// <summary>
        /// Initializes a new instance of the <see cref="Body"/> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="linearVelocity">The linear velocity</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="angle">The angle</param>
        /// <param name="angularVelocity">The angular velocity</param>
        /// <param name="linearDamping">The linear damping</param>
        /// <param name="angularDamping">The angular damping</param>
        /// <param name="allowSleep">The allow sleep</param>
        /// <param name="awake">The awake</param>
        /// <param name="fixedRotation">The fixed rotation</param>
        /// <param name="isBullet">The is bullet</param>
        /// <param name="enabled">The enabled</param>
        /// <param name="gravityScale">The gravity scale</param>
        public Body(
            Vector2F position,
            Vector2F linearVelocity,
            BodyType bodyType = BodyType.Static,
            float angle = 0.0f,
            float angularVelocity = 0.0f,
            float linearDamping = 0.0f,
            float angularDamping = 0.0f,
            bool allowSleep = true,
            bool awake = true,
            bool fixedRotation = false,
            bool isBullet = false,
            bool enabled = true,
            float gravityScale = 1.0f
        )
        {
            FixtureList = new List<Fixture>(1);

            if (isBullet)
            {
                Flags |= BodyFlags.BulletFlag;
            }

            if (fixedRotation)
            {
                Flags |= BodyFlags.FixedRotationFlag;
            }

            if (allowSleep)
            {
                Flags |= BodyFlags.AutoSleepFlag;
            }

            if (awake)
            {
                Flags |= BodyFlags.AwakeFlag;
            }

            if (enabled)
            {
                Flags |= BodyFlags.Enabled;
            }

            Xf.Position = position;
            Xf.Rotation.Set(angle);

            Sweep.C0 = Xf.Position;
            Sweep.C = Xf.Position;
            Sweep.A0 = angle;
            Sweep.A = angle;

            LinearVelocity = linearVelocity;
            AngularVelocity = angularVelocity;

            LinearDamping = linearDamping;
            this.AngularDamping = angularDamping;
            GravityScale = gravityScale;

            Type = bodyType;

            mass = 0.0f;
            InvMass = 0.0f;
        }

        /// <summary>
        ///     The flags
        /// </summary>
        internal BodyFlags Flags { get; set; }

        /// <summary>
        ///     The force
        /// </summary>
        public Vector2F Force { get; set; }

        /// <summary>
        ///     The inv
        /// </summary>
        internal float InvI { get; set; }

        /// <summary>
        ///     The inv mass
        /// </summary>
        internal float InvMass { get; set; }

        /// <summary>
        ///     The sweep
        /// </summary>
        internal Sweep Sweep { get; set; } = new Sweep();

        /// <summary>
        ///     The torque
        /// </summary>
        public float Torque { get; set; }

        /// <summary>
        ///     Gets or sets the value of the controller filter
        /// </summary>
        public ControllerFilter ControllerFilter { get; set; }

        /// <summary>
        ///     Gets or sets the value of the physics logic filter
        /// </summary>
        public PhysicsLogicFilter PhysicsLogicFilter { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sleep time
        /// </summary>
        public float SleepTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the island index
        /// </summary>
        public int IslandIndex { get; set; }

        /// <summary>
        ///     Scale the gravity applied to this body. Defaults to 1. A value of 2 means double the gravity is applied to
        ///     this body.
        /// </summary>
        public float GravityScale { get; set; }

        /// <summary>Gets the total number revolutions the body has made.</summary>
        /// <value>The revolutions.</value>
        public float Revolutions => Rotation / MathConstants.Pi;

        /// <summary>Gets or sets the body type. Warning: Calling this mid-update might cause a crash.</summary>
        /// <value>The type of body.</value>
        public BodyType BodyType
        {
            get => Type;
            set
            {
                //Debug.Assert(!World.IsLocked);
                if (World.IsLocked)
                {
                    return;
                }

                if (Type == value)
                {
                    return;
                }

                Type = value;

                ResetMassData();

                if (Type == BodyType.Static)
                {
                    LinearVelocity = Vector2F.Zero;
                    AngularVelocity = 0.0f;
                    Sweep.A0 = Sweep.A;
                    Sweep.C0 = Sweep.C;
                    Flags &= ~BodyFlags.AwakeFlag;
                    SynchronizeFixtures();
                }

                Awake = true;

                Force = Vector2F.Zero;
                Torque = 0.0f;

                // Delete the attached contacts.
                ContactEdge ce = ContactList;
                while (ce != null)
                {
                    ContactEdge ce0 = ce;
                    ce = ce.Next;
                    World.ContactManager.Remove(ce0.Contact);
                }

                ContactList = null;

                // Touch the proxies so that new contacts will be created (when appropriate)
                IBroadPhase broadPhase = World.ContactManager.BroadPhase;
                foreach (Fixture fixture in FixtureList)
                {
                    int proxyCount = fixture.ProxyCount;
                    for (int j = 0; j < proxyCount; j++)
                    {
                        broadPhase.TouchProxy(fixture.Proxies[j].ProxyId);
                    }
                }
            }
        }

        /// <summary>Get or sets the linear velocity of the center of mass.</summary>
        /// <value>The linear velocity.</value>
        public Vector2F LinearVelocity
        {
            get => linearVelc;
            set
            {
                //Debug.Assert(!float.IsNaN(value.X) && !float.IsNaN(value.Y));

                if (Type == BodyType.Static)
                {
                    return;
                }

                if (Vector2F.Dot(value, value) > 0.0f)
                {
                    Awake = true;
                }

                linearVelc = value;
            }
        }

        /// <summary>Gets or sets the angular velocity. Radians/second.</summary>
        /// <value>The angular velocity.</value>
        public float AngularVelocity
        {
            get => angularVelocity;
            set
            {
                //Debug.Assert(!float.IsNaN(value));

                if (Type == BodyType.Static)
                {
                    return;
                }

                if (value * value > 0.0f)
                {
                    Awake = true;
                }

                angularVelocity = value;
            }
        }

        /// <summary>Gets or sets the linear damping.</summary>
        /// <value>The linear damping.</value>
        public float LinearDamping { get; set; }

        /// <summary>Gets or sets the angular damping.</summary>
        /// <value>The angular damping.</value>
        public float AngularDamping { get; set; }

        /// <summary>Gets or sets a value indicating whether this body should be included in the CCD solver.</summary>
        /// <value><c>true</c> if this instance is included in CCD; otherwise, <c>false</c>.</value>
        public bool IsBullet
        {
            get => (Flags & BodyFlags.BulletFlag) == BodyFlags.BulletFlag;
            set
            {
                if (value)
                {
                    Flags |= BodyFlags.BulletFlag;
                }
                else
                {
                    Flags &= ~BodyFlags.BulletFlag;
                }
            }
        }

        /// <summary>You can disable sleeping on this body. If you disable sleeping, the body will be woken.</summary>
        /// <value><c>true</c> if sleeping is allowed; otherwise, <c>false</c>.</value>
        public bool SleepingAllowed
        {
            get => (Flags & BodyFlags.AutoSleepFlag) == BodyFlags.AutoSleepFlag;
            set
            {
                if (value)
                {
                    Flags |= BodyFlags.AutoSleepFlag;
                }
                else
                {
                    Flags &= ~BodyFlags.AutoSleepFlag;
                    Awake = true;
                }
            }
        }

        /// <summary>Set the sleep state of the body. A sleeping body has very low CPU cost.</summary>
        /// <value><c>true</c> if awake; otherwise, <c>false</c>.</value>
        public bool Awake
        {
            get => (Flags & BodyFlags.AwakeFlag) == BodyFlags.AwakeFlag;
            set
            {
                if (Type == BodyType.Static)
                {
                    return;
                }

                if (value)
                {
                    Flags |= BodyFlags.AwakeFlag;
                    SleepTime = 0.0f;
                }
                else
                {
                    Flags &= ~BodyFlags.AwakeFlag;
                    ResetDynamics();
                    SleepTime = 0.0f;
                }
            }
        }

        /// <summary>
        ///     Set the active state of the body. An inactive body is not simulated and cannot be collided with or woken up.
        ///     If you pass a flag of true, all fixtures will be added to the broad-phase. If you pass a flag of false, all
        ///     fixtures
        ///     will be removed from the broad-phase and all contacts will be destroyed. Fixtures and joints are otherwise
        ///     unaffected.
        ///     You may continue to create/destroy fixtures and joints on inactive bodies. Fixtures on an inactive body are
        ///     implicitly
        ///     inactive and will not participate in collisions, ray-casts, or queries. Joints connected to an inactive body are
        ///     implicitly inactive. An inactive body is still owned by a b2World object and remains in the body list.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get => (Flags & BodyFlags.Enabled) == BodyFlags.Enabled;

            set
            {
                //Debug.Assert(!World.IsLocked);

                if (value == Enabled)
                {
                    return;
                }

                if (value)
                {
                    Flags |= BodyFlags.Enabled;

                    // Create all proxies.
                    IBroadPhase broadPhase = World.ContactManager.BroadPhase;
                    for (int i = 0; i < FixtureList.Count; i++)
                    {
                        FixtureList[i].CreateProxies(broadPhase, ref Xf);
                    }

                    // Contacts are created the next time step.
                    World.NewContacts = true;
                }
                else
                {
                    Flags &= ~BodyFlags.Enabled;

                    // Destroy all proxies.
                    IBroadPhase broadPhase = World.ContactManager.BroadPhase;

                    for (int i = 0; i < FixtureList.Count; i++)
                    {
                        FixtureList[i].DestroyProxies(broadPhase);
                    }

                    // Destroy the attached contacts.
                    ContactEdge ce = ContactList;
                    while (ce != null)
                    {
                        ContactEdge ce0 = ce;
                        ce = ce.Next;
                        World.ContactManager.Remove(ce0.Contact);
                    }

                    ContactList = null;
                }
            }
        }

        /// <summary>Set this body to have fixed rotation. This causes the mass to be reset.</summary>
        /// <value><c>true</c> if it has fixed rotation; otherwise, <c>false</c>.</value>
        public bool FixedRotation
        {
            get => (Flags & BodyFlags.FixedRotationFlag) == BodyFlags.FixedRotationFlag;
            set
            {
                if (value == FixedRotation)
                {
                    return;
                }

                if (value)
                {
                    Flags |= BodyFlags.FixedRotationFlag;
                }
                else
                {
                    Flags &= ~BodyFlags.FixedRotationFlag;
                }

                AngularVelocity = 0f;
                ResetMassData();
            }
        }

        /// <summary>Gets all the fixtures attached to this body.</summary>
        /// <value>The fixture list.</value>
        public List<Fixture> FixtureList { get; set; }

        /// <summary>Get the list of all joints attached to this body.</summary>
        /// <value>The joint list.</value>
        public JointEdge JointList { get; set; }

        /// <summary>
        ///     Get the list of all contacts attached to this body. Warning: this list changes during the time step and you
        ///     may miss some collisions if you don't use ContactListener.
        /// </summary>
        /// <value>The contact list.</value>
        public ContactEdge ContactList { get; set; }

        /// <summary>Get the world body origin position.</summary>
        /// <returns>Return the world position of the body's origin.</returns>
        public Vector2F Position
        {
            get => Xf.Position;
            set
            {
                //Debug.Assert(!float.IsNaN(value.X) && !float.IsNaN(value.Y));

                SetTransform(ref value, Sweep.A);
            }
        }

        /// <summary>Get the angle in radians.</summary>
        /// <returns>Return the current world rotation angle in radians.</returns>
        public float Rotation
        {
            get => Sweep.A;
            set
            {
                SetTransform(ref Xf.Position, value);
            }
        }

        //Velcro: We don't add a setter here since it requires a branch, and we only use it internally
        /// <summary>
        ///     Gets the value of the is island
        /// </summary>
        internal bool IsIsland => (Flags & BodyFlags.IslandFlag) == BodyFlags.IslandFlag;

        /// <summary>
        ///     Gets the value of the is static
        /// </summary>
        public bool IsStatic => Type == BodyType.Static;

        /// <summary>
        ///     Gets the value of the is kinematic
        /// </summary>
        public bool IsKinematic => Type == BodyType.Kinematic;

        /// <summary>
        ///     Gets the value of the is dynamic
        /// </summary>
        public bool IsDynamic => Type == BodyType.Dynamic;

        /// <summary>Get the world position of the center of mass.</summary>
        /// <value>The world position.</value>
        public Vector2F WorldCenter => Sweep.C;

        /// <summary>Get the local position of the center of mass.</summary>
        /// <value>The local position.</value>
        public Vector2F LocalCenter
        {
            get => Sweep.LocalCenter;
            set
            {
                if (Type != BodyType.Dynamic)
                {
                    return;
                }

                //Velcro: We support setting the mass independently

                // Move center of mass.
                Vector2F oldCenter = Sweep.C;
                Sweep.LocalCenter = value;
                Sweep.C0 = Sweep.C = MathUtils.Mul(ref Xf, ref Sweep.LocalCenter);

                // Update center of mass velocity.
                Vector2F a = Sweep.C - oldCenter;
                LinearVelocity += new Vector2F(-AngularVelocity * a.Y, AngularVelocity * a.X);
            }
        }

        /// <summary>Gets or sets the mass. Usually in kilograms (kg).</summary>
        /// <value>The mass.</value>
        public float Mass
        {
            get => mass;
            set
            {
                //Debug.Assert(!float.IsNaN(value));

                if (Type != BodyType.Dynamic)
                {
                    return;
                }

                //Velcro: We support setting the mass independently
                mass = value;

                if (mass <= 0.0f)
                {
                    mass = 1.0f;
                }

                InvMass = 1.0f / mass;
            }
        }

        /// <summary>Get or set the rotational inertia of the body about the local origin. usually in kg-m^2.</summary>
        /// <value>The inertia.</value>
        public float Inertia
        {
            get => inertia + mass * Vector2F.Dot(Sweep.LocalCenter, Sweep.LocalCenter);
            set
            {
                //Debug.Assert(!float.IsNaN(value));

                if (Type != BodyType.Dynamic)
                {
                    return;
                }

                //Velcro: We support setting the inertia independently
                if ((value > 0.0f) && !FixedRotation)
                {
                    inertia = value - mass * Vector2F.Dot(Sweep.LocalCenter, Sweep.LocalCenter);
                    //Debug.Assert(inertia > 0.0f);
                    InvI = 1.0f / inertia;
                }
            }
        }

        /// <summary>
        ///     Sets the value of the restitution
        /// </summary>
        public float Restitution
        {
            set
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].Restitution = value;
                }
            }
        }

        /// <summary>
        ///     Sets the value of the friction
        /// </summary>
        public float Friction
        {
            set
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].Friction = value;
                }
            }
        }

        /// <summary>
        ///     Sets the value of the collision categories
        /// </summary>
        public Category CollisionCategories
        {
            set
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].CollisionCategories = value;
                }
            }
        }

        /// <summary>
        ///     Sets the value of the collides with
        /// </summary>
        public Category CollidesWith
        {
            set
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].CollidesWith = value;
                }
            }
        }

        /// <summary>
        ///     Body objects can define which categories of bodies they wish to ignore CCD with. This allows certain bodies to
        ///     be configured to ignore CCD with objects that aren't a penetration problem due to the way content has been
        ///     prepared.
        ///     This is compared against the other Body's fixture CollisionCategories within World.SolveTOI().
        /// </summary>
        public Category IgnoreCcdWith
        {
            set
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].IgnoreCcdWith = value;
                }
            }
        }

        /// <summary>
        ///     Sets the value of the collision group
        /// </summary>
        public short CollisionGroup
        {
            set
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].CollisionGroup = value;
                }
            }
        }

        /// <summary>
        ///     Sets the value of the is sensor
        /// </summary>
        public bool IsSensor
        {
            set
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].IsSensor = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the value of the ignore ccd
        /// </summary>
        public bool IgnoreCcd
        {
            get => (Flags & BodyFlags.IgnoreCcd) == BodyFlags.IgnoreCcd;
            set
            {
                if (value)
                {
                    Flags |= BodyFlags.IgnoreCcd;
                }
                else
                {
                    Flags &= ~BodyFlags.IgnoreCcd;
                }
            }
        }

        /// <summary>
        ///     Gets the mass data using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        public void GetMassData(out MassData data)
        {
            data = new MassData
            {
                Mass = mass,
                Inertia = inertia + mass * MathUtils.Dot(ref Sweep.LocalCenter, ref Sweep.LocalCenter),
                Centroid = Sweep.LocalCenter
            };
        }

        /// <summary>Resets the dynamics of this body. Sets torque, force and linear/angular velocity to 0</summary>
        public void ResetDynamics()
        {
            Torque = 0;
            AngularVelocity = 0;
            Force = Vector2F.Zero;
            LinearVelocity = Vector2F.Zero;
        }

        /// <summary>
        ///     Creates a fixture and attach it to this body. If the density is non-zero, this function automatically updates
        ///     the mass of the body. Contacts are not created until the next time step. Warning: This function is locked during
        ///     callbacks.
        /// </summary>
        public Fixture AddFixture(Fixture fixture)
        {
            //Debug.Assert(!World.IsLocked);
            if (World.IsLocked)
            {
                return null;
            }
            
            if ((Flags & BodyFlags.Enabled) == BodyFlags.Enabled)
            {
                IBroadPhase broadPhase = World.ContactManager.BroadPhase;
                fixture.CreateProxies(broadPhase, ref Xf);
            }

            FixtureList.Add(fixture);

            fixture.Body = this;

            // Adjust mass properties if needed.
            if (fixture.Shape.DensityPrivate > 0.0f)
            {
                ResetMassData();
            }

            World.NewContacts = true;

            //Velcro: Added this code to raise the FixtureAdded event
            World.RaiseNewFixtureEvent(fixture);

            return fixture;
        }

        /// <summary>
        ///     Creates a fixture and attach it to this body. If the density is non-zero, this function automatically updates
        ///     the mass of the body. Contacts are not created until the next time step. Warning: This function is locked during
        ///     callbacks.
        /// </summary>
        public Fixture AddFixture(Shape shape)
        {
            return World.IsLocked ? null : AddFixture(new Fixture(shape, new Filter()));
        }

        /// <summary>
        ///     Destroy a fixture. This removes the fixture from the broad-phase and destroys all contacts associated with
        ///     this fixture. This will automatically adjust the mass of the body if the body is dynamic and the fixture has
        ///     positive
        ///     density. All fixtures attached to a body are implicitly destroyed when the body is destroyed. Warning: This
        ///     function is
        ///     locked during callbacks.
        /// </summary>
        /// <param name="fixture">The fixture to be removed.</param>
        public void RemoveFixture(Fixture fixture)
        {
            //Debug.Assert(!World.IsLocked);
            if (World.IsLocked)
            {
                return;
            }

            if (fixture == null)
            {
                return;
            }

            //Debug.Assert(fixture.Body == this);

            // Remove the fixture from this body's singly linked list.
            //Debug.Assert(FixtureList.Count > 0);

            // You tried to remove a fixture that not present in the fixturelist.
            //Debug.Assert(FixtureList.Contains(fixture));

            // Destroy any contacts associated with the fixture.
            ContactEdge edge = ContactList;
            while (edge != null)
            {
                Contact c = edge.Contact;
                edge = edge.Next;

                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;

                if (fixture == fixtureA || fixture == fixtureB)
                {
                    // This destroys the contact and removes it from
                    // this body's contact list.
                    World.ContactManager.Remove(c);
                }
            }

            if ((Flags & BodyFlags.Enabled) == BodyFlags.Enabled)
            {
                IBroadPhase broadPhase = World.ContactManager.BroadPhase;
                fixture.DestroyProxies(broadPhase);
            }

            FixtureList.Remove(fixture);
            fixture.Destroy();
            fixture.Body = null;

            ResetMassData();
        }

        /// <summary>
        ///     Set the position of the body's origin and rotation. This breaks any contacts and wakes the other bodies.
        ///     Manipulating a body's transform may cause non-physical behavior.
        /// </summary>
        /// <param name="position">The world position of the body's local origin.</param>
        /// <param name="rotation">The world rotation in radians.</param>
        public void SetTransform(Vector2F position, float rotation)
        {
            SetTransform(ref position, rotation);
        }

        /// <summary>
        ///     Set the position of the body's origin and rotation. This breaks any contacts and wakes the other bodies.
        ///     Manipulating a body's transform may cause non-physical behavior.
        /// </summary>
        /// <param name="position">The world position of the body's local origin.</param>
        /// <param name="rotation">The world rotation in radians.</param>
        public void SetTransform(ref Vector2F position, float rotation)
        {
            //Debug.Assert(!World.IsLocked);
            if (World.IsLocked)
            {
                return;
            }

            Xf.Rotation.Set(rotation);
            Xf.Position = position;

            Sweep.C = MathUtils.Mul(ref Xf, Sweep.LocalCenter);
            Sweep.A = rotation;

            Sweep.C0 = Sweep.C;
            Sweep.A0 = rotation;

            IBroadPhase broadPhase = World.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList.Count; i++)
            {
                FixtureList[i].Synchronize(broadPhase, ref Xf, ref Xf);
            }

            // Check for new contacts the next step
            World.NewContacts = true;
        }

        /// <summary>Get the body transform for the body's origin.</summary>
        /// <param name="transform">The transform of the body's origin.</param>
        public void GetTransform(out Transform transform)
        {
            transform = Xf;
        }

        /// <summary>
        ///     Apply a force at a world point. If the force is not applied at the center of mass, it will generate a torque
        ///     and affect the angular velocity. This wakes up the body.
        /// </summary>
        /// <param name="force">The world force vector, usually in Newtons (N).</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyForce(Vector2F force, Vector2F point)
        {
            ApplyForce(ref force, ref point);
        }

        /// <summary>Applies a force at the center of mass.</summary>
        /// <param name="force">The force.</param>
        public void ApplyForce(ref Vector2F force)
        {
            ApplyForce(ref force, ref Xf.Position);
        }

        /// <summary>Applies a force at the center of mass.</summary>
        /// <param name="force">The force.</param>
        public void ApplyForce(Vector2F force)
        {
            ApplyForce(ref force, ref Xf.Position);
        }

        /// <summary>
        ///     Apply a force at a world point. If the force is not applied at the center of mass, it will generate a torque
        ///     and affect the angular velocity. This wakes up the body.
        /// </summary>
        /// <param name="force">The world force vector, usually in Newtons (N).</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyForce(ref Vector2F force, ref Vector2F point)
        {
            //Debug.Assert(!float.IsNaN(force.X));
            //Debug.Assert(!float.IsNaN(force.Y));
            //Debug.Assert(!float.IsNaN(point.X));
            //Debug.Assert(!float.IsNaN(point.Y));

            if (Type != BodyType.Dynamic)
            {
                return;
            }

            //Velcro: We always wake the body. You told it to move.
            if (!Awake)
            {
                Awake = true;
            }

            Force += force;
            Torque += MathUtils.Cross(point - Sweep.C, force);
        }

        /// <summary>Apply a torque. This affects the angular velocity without affecting the linear velocity of the center of mass.</summary>
        /// <param name="torque">The torque about the z-axis (out of the screen), usually in N-m.</param>
        public void ApplyTorque(float torque)
        {
            //Debug.Assert(!float.IsNaN(torque));

            if (Type != BodyType.Dynamic)
            {
                return;
            }

            //Velcro: We always wake the body. You told it to move.
            if (!Awake)
            {
                Awake = true;
            }

            Torque += torque;
        }

        /// <summary>Apply an impulse at a point. This immediately modifies the velocity. This wakes up the body.</summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        public void ApplyLinearImpulse(Vector2F impulse)
        {
            ApplyLinearImpulse(ref impulse);
        }

        /// <summary>
        ///     Apply an impulse at a point. This immediately modifies the velocity. It also modifies the angular velocity if
        ///     the point of application is not at the center of mass. This wakes up the body.
        /// </summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyLinearImpulse(Vector2F impulse, Vector2F point)
        {
            ApplyLinearImpulse(ref impulse, ref point);
        }

        /// <summary>Apply an impulse at a point. This immediately modifies the velocity. This wakes up the body.</summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        public void ApplyLinearImpulse(ref Vector2F impulse)
        {
            if (Type != BodyType.Dynamic)
            {
                return;
            }

            //Velcro: We always wake the body. You told it to move.
            if (!Awake)
            {
                Awake = true;
            }

            LinearVelocity += InvMass * impulse;
        }

        /// <summary>
        ///     Apply an impulse at a point. This immediately modifies the velocity. It also modifies the angular velocity if
        ///     the point of application is not at the center of mass. This wakes up the body.
        /// </summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyLinearImpulse(ref Vector2F impulse, ref Vector2F point)
        {
            if (Type != BodyType.Dynamic)
            {
                return;
            }

            //Velcro: We always wake the body. You told it to move.
            if (!Awake)
            {
                Awake = true;
            }

            LinearVelocity += InvMass * impulse;
            AngularVelocity += InvI * MathUtils.Cross(point - Sweep.C, impulse);
        }

        /// <summary>Apply an angular impulse.</summary>
        /// <param name="impulse">The angular impulse in units of kg*m*m/s.</param>
        public void ApplyAngularImpulse(float impulse)
        {
            if (Type != BodyType.Dynamic)
            {
                return;
            }

            //Velcro: We always wake the body. You told it to move.
            if (!Awake)
            {
                Awake = true;
            }

            AngularVelocity += InvI * impulse;
        }

        /// <summary>
        ///     This resets the mass properties to the sum of the mass properties of the fixtures. This normally does not need
        ///     to be called unless you called SetMassData to override the mass and you later want to reset the mass.
        /// </summary>
        public void ResetMassData()
        {
            // Compute mass data from shapes. Each shape has its own density.
            mass = 0.0f;
            InvMass = 0.0f;
            inertia = 0.0f;
            InvI = 0.0f;
            Sweep.LocalCenter = Vector2F.Zero;

            //Velcro: We have mass on static bodies to support attaching joints to them
            // Kinematic bodies have zero mass.
            if (Type == BodyType.Kinematic)
            {
                Sweep.C0 = Xf.Position;
                Sweep.C = Xf.Position;
                Sweep.A0 = Sweep.A;
                return;
            }

            //Debug.Assert(Type == BodyType.Dynamic || Type == BodyType.Static);

            // Accumulate mass over all fixtures.
            Vector2F localCenter = Vector2F.Zero;
            foreach (Fixture f in FixtureList)
            {
                if (f.Shape.DensityPrivate == 0.0f)
                {
                    continue;
                }

                MassData massData = f.Shape.MassDataPrivate;
                mass += massData.Mass;
                localCenter += massData.Mass * massData.Centroid;
                inertia += massData.Inertia;
            }

            //Velcro: Static bodies only have mass, they don't have other properties. A little hacky tho...
            if (Type == BodyType.Static)
            {
                Sweep.C0 = Sweep.C = Xf.Position;
                return;
            }

            // Compute center of mass.
            if (mass > 0.0f)
            {
                InvMass = 1.0f / mass;
                localCenter *= InvMass;
            }

            if ((inertia > 0.0f) && ((Flags & BodyFlags.FixedRotationFlag) == 0))
            {
                // Center the inertia about the center of mass.
                inertia -= mass * Vector2F.Dot(localCenter, localCenter);

                //Debug.Assert(inertia > 0.0f);
                InvI = 1.0f / inertia;
            }
            else
            {
                inertia = 0.0f;
                InvI = 0.0f;
            }

            // Move center of mass.
            Vector2F oldCenter = Sweep.C;
            Sweep.LocalCenter = localCenter;
            Sweep.C0 = Sweep.C = MathUtils.Mul(ref Xf, ref Sweep.LocalCenter);

            // Update center of mass velocity.
            Vector2F a = Sweep.C - oldCenter;
            LinearVelocity += new Vector2F(-AngularVelocity * a.Y, AngularVelocity * a.X);
        }

        /// <summary>Get the world coordinates of a point given the local coordinates.</summary>
        /// <param name="localPoint">A point on the body measured relative the body's origin.</param>
        /// <returns>The same point expressed in world coordinates.</returns>
        public Vector2F GetWorldPoint(ref Vector2F localPoint) => MathUtils.Mul(ref Xf, ref localPoint);

        /// <summary>Get the world coordinates of a point given the local coordinates.</summary>
        /// <param name="localPoint">A point on the body measured relative the body's origin.</param>
        /// <returns>The same point expressed in world coordinates.</returns>
        public Vector2F GetWorldPoint(Vector2F localPoint) => GetWorldPoint(ref localPoint);

        /// <summary>
        ///     Get the world coordinates of a vector given the local coordinates. Note that the vector only takes the
        ///     rotation into account, not the position.
        /// </summary>
        /// <param name="localVector">A vector fixed in the body.</param>
        /// <returns>The same vector expressed in world coordinates.</returns>
        public Vector2F GetWorldVector(ref Vector2F localVector) => MathUtils.Mul(ref Xf.Rotation, localVector);

        /// <summary>Get the world coordinates of a vector given the local coordinates.</summary>
        /// <param name="localVector">A vector fixed in the body.</param>
        /// <returns>The same vector expressed in world coordinates.</returns>
        public Vector2F GetWorldVector(Vector2F localVector) => GetWorldVector(ref localVector);

        /// <summary>
        ///     Gets a local point relative to the body's origin given a world point. Note that the vector only takes the
        ///     rotation into account, not the position.
        /// </summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The corresponding local point relative to the body's origin.</returns>
        public Vector2F GetLocalPoint(ref Vector2F worldPoint) => MathUtils.MulT(ref Xf, worldPoint);

        /// <summary>Gets a local point relative to the body's origin given a world point.</summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The corresponding local point relative to the body's origin.</returns>
        public Vector2F GetLocalPoint(Vector2F worldPoint) => GetLocalPoint(ref worldPoint);

        /// <summary>
        ///     Gets a local vector given a world vector. Note that the vector only takes the rotation into account, not the
        ///     position.
        /// </summary>
        /// <param name="worldVector">A vector in world coordinates.</param>
        /// <returns>The corresponding local vector.</returns>
        public Vector2F GetLocalVector(ref Vector2F worldVector) => MathUtils.MulT(Xf.Rotation, worldVector);

        /// <summary>
        ///     Gets a local vector given a world vector. Note that the vector only takes the rotation into account, not the
        ///     position.
        /// </summary>
        /// <param name="worldVector">A vector in world coordinates.</param>
        /// <returns>The corresponding local vector.</returns>
        public Vector2F GetLocalVector(Vector2F worldVector) => GetLocalVector(ref worldVector);

        /// <summary>Get the world linear velocity of a world point attached to this body.</summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromWorldPoint(Vector2F worldPoint) =>
            GetLinearVelocityFromWorldPoint(ref worldPoint);

        /// <summary>Get the world linear velocity of a world point attached to this body.</summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromWorldPoint(ref Vector2F worldPoint) =>
            LinearVelocity + MathUtils.Cross(AngularVelocity, worldPoint - Sweep.C);

        /// <summary>Get the world velocity of a local point.</summary>
        /// <param name="localPoint">A point in local coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromLocalPoint(Vector2F localPoint) =>
            GetLinearVelocityFromLocalPoint(ref localPoint);

        /// <summary>Get the world velocity of a local point.</summary>
        /// <param name="localPoint">A point in local coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromLocalPoint(ref Vector2F localPoint) =>
            GetLinearVelocityFromWorldPoint(GetWorldPoint(ref localPoint));

        /// <summary> Calling this will remove the body from its associated world.</summary>
        public void RemoveFromWorld()
        {
            World.RemoveBody(this);
        }

        /// <summary>
        ///     Synchronizes the fixtures
        /// </summary>
        internal void SynchronizeFixtures()
        {
            IBroadPhase broadPhase = World.ContactManager.BroadPhase;

            if ((Flags & BodyFlags.AwakeFlag) == BodyFlags.AwakeFlag)
            {
                Transform xf1 = new Transform();
                xf1.Rotation.Set(Sweep.A0);
                xf1.Position = Sweep.C0 - MathUtils.Mul(xf1.Rotation, Sweep.LocalCenter);

                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].Synchronize(broadPhase, ref xf1, ref Xf);
                }
            }
            else
            {
                for (int i = 0; i < FixtureList.Count; i++)
                {
                    FixtureList[i].Synchronize(broadPhase, ref Xf, ref Xf);
                }
            }
        }

        /// <summary>
        ///     Synchronizes the transform
        /// </summary>
        internal void SynchronizeTransform()
        {
            Xf.Rotation.Set(Sweep.A);
            Xf.Position = Sweep.C - MathUtils.Mul(Xf.Rotation, Sweep.LocalCenter);
        }

        /// <summary>This is used to prevent connected bodies from colliding. It may lie, depending on the collideConnected flag.</summary>
        /// <param name="other">The other body.</param>
        internal bool ShouldCollide(Body other)
        {
            // At least one body should be dynamic.
            if ((Type != BodyType.Dynamic) && (other.Type != BodyType.Dynamic))
            {
                return false;
            }

            // Does a joint prevent collision?
            for (JointEdge jn = JointList; jn != null; jn = jn.Next)
            {
                if (jn.Other == other)
                {
                    if (!jn.Joint.CollideConnected)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     Advances the alpha
        /// </summary>
        /// <param name="alpha">The alpha</param>
        internal void Advance(float alpha)
        {
            // Advance to the new safe time. This doesn't sync the broad-phase.
            Sweep.Advance(alpha);
            Sweep.C = Sweep.C0;
            Sweep.A = Sweep.A0;
            Xf.Rotation.Set(Sweep.A);
            Xf.Position = Sweep.C - MathUtils.Mul(Xf.Rotation, Sweep.LocalCenter);
        }
    }
}