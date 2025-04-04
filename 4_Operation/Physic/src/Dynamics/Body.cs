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

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PhysicsLogic;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The body class
    /// </summary>
    public partial class Body
    {
        /// <summary>
        ///     Gets all the fixtures attached to this body.
        /// </summary>
        /// <value>The fixture list.</value>
        internal readonly FixtureCollection FixtureList;

        /// <summary>
        ///     The angular damping
        /// </summary>
        private float _angularDamping;

        /// <summary>
        ///     The angular velocity
        /// </summary>
        private float _angularVelocity;

        /// <summary>
        ///     The awake
        /// </summary>
        private bool _awake;

        /// <summary>
        ///     The body type
        /// </summary>
        private BodyType _bodyType;

        /// <summary>
        ///     The enabled
        /// </summary>
        private bool _enabled;

        /// <summary>
        ///     The fixed rotation
        /// </summary>
        private bool _fixedRotation;

        /// <summary>
        ///     The inertia
        /// </summary>
        private float _inertia;

        /// <summary>
        ///     The linear damping
        /// </summary>
        private float _linearDamping;

        /// <summary>
        ///     The mass
        /// </summary>
        private float _mass;

        /// <summary>
        ///     The sleeping allowed
        /// </summary>
        private bool _sleepingAllowed;

        /// <summary>
        ///     The all
        /// </summary>
        public ControllerFilter ControllerFilter = new ControllerFilter(ControllerCategory.All);

        /// <summary>
        ///     The island
        /// </summary>
        internal bool Island;

        /// <summary>
        ///     The linear velocity
        /// </summary>
        internal Vector2F LinearVelocityInternal;

        /// <summary>
        ///     The lock
        /// </summary>
        internal int Lock;

        /// <summary>
        ///     The lock order
        /// </summary>
        internal int LockOrder;

        /// <summary>
        ///     The on collision event handler
        /// </summary>
        internal OnCollisionEventHandler OnCollisionEventHandler;

        /// <summary>
        ///     The on separation event handler
        /// </summary>
        internal OnSeparationEventHandler OnSeparationEventHandler;

        /// <summary>
        ///     The sleep time
        /// </summary>
        internal float SleepTime;

        /// <summary>
        ///     The sweep
        /// </summary>
        internal Sweep Sweep; // the swept motion for CCD

        /// <summary>
        ///     Set the user data. Use this to store your application specific data.
        /// </summary>
        /// <value>The user data.</value>
        public object Tag;

        /// <summary>
        ///     The torque
        /// </summary>
        internal float Torque;

        /// <summary>
        ///     The world
        /// </summary>
        internal WorldPhysic WorldPhysic;

        /// <summary>
        ///     The xf
        /// </summary>
        internal Transform Xf; // the body origin transform

        /// <summary>
        ///     Initializes a new instance of the <see cref="Body" /> class
        /// </summary>
        public Body()
        {
            FixtureList = new FixtureCollection(this);

            Enabled = true;
            _awake = true;
            _sleepingAllowed = true;
            Xf.Q = Complex.One;

            GetBodyType = BodyType.Static;
        }

        /// <summary>
        ///     The force
        /// </summary>
        internal Vector2F Force { get; set; }

        /// <summary>
        ///     The inv
        /// </summary>
        internal float InvI { get; set; }

        /// <summary>
        ///     The inv mass
        /// </summary>
        internal float InvMass { get; set; }

        /// <summary>
        ///     Get the parent World of this body. This is null if the body is not attached.
        /// </summary>
        public WorldPhysic GetWorldPhysic => WorldPhysic;

        /// <remarks>Deprecated in version 1.6</remarks>

        public int GetIslandIndex { get; internal set; }

        /// <summary>
        ///     Gets the total number revolutions the body has made.
        /// </summary>
        /// <value>The revolutions.</value>
        public float GetRevolutions => Rotation / (2 * (float) Math.PI);

        /// <summary>
        ///     Gets or sets the body type.
        ///     Warning: This property is readonly during callbacks.
        /// </summary>
        /// <value>The type of body.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public BodyType GetBodyType
        {
            get => _bodyType;
            set
            {
                if ((GetWorldPhysic != null) && GetWorldPhysic.GetIsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                if (_bodyType == value)
                {
                    return;
                }

                _bodyType = value;

                ResetMassData();

                if (_bodyType == BodyType.Static)
                {
                    LinearVelocityInternal = Vector2F.Zero;
                    AngularVelocity = 0.0f;
                    Sweep.A0 = Sweep.A;
                    Sweep.C0 = Sweep.C;
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
                    GetWorldPhysic.ContactManager.Destroy(ce0.Contact);
                }

                ContactList = null;

                if (GetWorldPhysic != null)
                {
                    // Touch the proxies so that new contacts will be created (when appropriate)
                    IBroadPhase broadPhase = GetWorldPhysic.ContactManager.BroadPhase;
                    foreach (Fixture fixture in FixtureList)
                    {
                        fixture.TouchProxies(broadPhase);
                    }
                }
            }
        }

        /// <summary>
        ///     Get or sets the linear velocity of the center of mass. Property has no effect on <see cref="BodyType.Static" />
        ///     bodies.
        /// </summary>
        /// <value>The linear velocity.</value>
        public Vector2F LinearVelocity
        {
            set
            {
                Debug.Assert(!float.IsNaN(value.X) && !float.IsNaN(value.Y));

                if (_bodyType == BodyType.Static)
                {
                    return;
                }

                if (Vector2F.Dot(value, value) > 0.0f)
                {
                    Awake = true;
                }

                LinearVelocityInternal = value;
            }
            get => LinearVelocityInternal;
        }

        /// <summary>
        ///     Gets or sets the angular velocity. Radians/second.
        /// </summary>
        /// <value>The angular velocity.</value>
        public float AngularVelocity
        {
            set
            {
                Debug.Assert(!float.IsNaN(value));

                if (_bodyType == BodyType.Static)
                {
                    return;
                }

                if (value * value > 0.0f)
                {
                    Awake = true;
                }

                _angularVelocity = value;
            }
            get => _angularVelocity;
        }

        /// <summary>
        ///     Gets or sets the linear damping.
        /// </summary>
        /// <value>The linear damping.</value>
        public float LinearDamping
        {
            get => _linearDamping;
            set
            {
                Debug.Assert(!float.IsNaN(value));

                _linearDamping = value;
            }
        }

        /// <summary>
        ///     Gets or sets the angular damping.
        /// </summary>
        /// <value>The angular damping.</value>
        public float AngularDamping
        {
            get => _angularDamping;
            set
            {
                Debug.Assert(!float.IsNaN(value));

                _angularDamping = value;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this body should be included in the CCD solver.
        /// </summary>
        /// <value><c>true</c> if this instance is included in CCD; otherwise, <c>false</c>.</value>
        public bool IsBullet { get; set; }

        /// <summary>
        ///     You can disable sleeping on this body. If you disable sleeping, the
        ///     body will be woken.
        /// </summary>
        /// <value><c>true</c> if sleeping is allowed; otherwise, <c>false</c>.</value>
        public bool SleepingAllowed
        {
            set
            {
                if (!value)
                {
                    Awake = true;
                }

                _sleepingAllowed = value;
            }
            get => _sleepingAllowed;
        }

        /// <summary>
        ///     Set the sleep state of the body. A sleeping body has very
        ///     low CPU cost.
        /// </summary>
        /// <value><c>true</c> if awake; otherwise, <c>false</c>.</value>
        public bool Awake
        {
            set
            {
                if (value)
                {
                    if (!_awake)
                    {
                        SleepTime = 0.0f;
                    }
                }
                else
                {
                    ResetDynamics();
                    SleepTime = 0.0f;
                }

                _awake = value;
            }
            get => _awake;
        }

        /// <summary>
        ///     Set the active state of the body. An inactive body is not
        ///     simulated and cannot be collided with or woken up.
        ///     If you pass a flag of true, all fixtures will be added to the
        ///     broad-phase.
        ///     If you pass a flag of false, all fixtures will be removed from
        ///     the broad-phase and all contacts will be destroyed.
        ///     Fixtures and joints are otherwise unaffected. You may continue
        ///     to create/destroy fixtures and joints on inactive bodies.
        ///     Fixtures on an inactive body are implicitly inactive and will
        ///     not participate in collisions, ray-casts, or queries.
        ///     Joints connected to an inactive body are implicitly inactive.
        ///     An inactive body is still owned by a b2World object and remains
        ///     in the body list.
        ///     Warning: This property is readonly during callbacks.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if ((GetWorldPhysic != null) && GetWorldPhysic.GetIsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                if (value == _enabled)
                {
                    return;
                }

                _enabled = value;

                if (Enabled)
                {
                    if (GetWorldPhysic != null)
                    {
                        CreateProxies();
                    }

                    // Contacts are created the next time step.
                }
                else
                {
                    if (GetWorldPhysic != null)
                    {
                        DestroyProxies();
                        DestroyContacts();
                    }
                }
            }
        }


        /// <summary>
        ///     Set this body to have fixed rotation. This causes the mass
        ///     to be reset.
        /// </summary>
        /// <value><c>true</c> if it has fixed rotation; otherwise, <c>false</c>.</value>
        public bool FixedRotation
        {
            set
            {
                if (_fixedRotation == value)
                {
                    return;
                }

                _fixedRotation = value;

                AngularVelocity = 0f;
                ResetMassData();
            }
            get => _fixedRotation;
        }

        /// <summary>
        ///     Get the list of all joints attached to this body.
        /// </summary>
        /// <value>The joint list.</value>
        public JointEdge JointList { get; internal set; }

        /// <summary>
        ///     Get the list of all contacts attached to this body.
        ///     Warning: this list changes during the time step and you may
        ///     miss some collisions if you don't use callback events.
        /// </summary>
        /// <value>The contact list.</value>
        public ContactEdge ContactList { get; internal set; }

        /// <summary>
        ///     Get the world body origin position.
        /// </summary>
        /// <returns>Return the world position of the body's origin.</returns>
        public Vector2F Position
        {
            get => Xf.P;
            set
            {
                Debug.Assert(!float.IsNaN(value.X) && !float.IsNaN(value.Y));

                if (GetWorldPhysic == null)
                {
                    Xf.P = value;
                }
                else
                {
                    SetTransform(ref value, Rotation);
                }
            }
        }

        /// <summary>
        ///     Get the angle in radians.
        /// </summary>
        /// <returns>Return the current world rotation angle in radians.</returns>
        public float Rotation
        {
            get => Sweep.A;
            set
            {
                Debug.Assert(!float.IsNaN(value));

                if (GetWorldPhysic == null)
                {
                    Sweep.A = value;
                }
                else
                {
                    SetTransform(ref Xf.P, value);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this body ignores gravity.
        /// </summary>
        /// <value><c>true</c> if  it ignores gravity; otherwise, <c>false</c>.</value>
        public bool IgnoreGravity { get; set; }

        /// <summary>
        ///     Get the world position of the center of mass.
        /// </summary>
        /// <value>The world position.</value>
        public Vector2F WorldCenter => Sweep.C;

        /// <summary>
        ///     Get the local position of the center of mass.
        ///     Warning: This property is readonly during callbacks.
        /// </summary>
        /// <value>The local position.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public Vector2F LocalCenter
        {
            get => Sweep.LocalCenter;
            set
            {
                if ((GetWorldPhysic != null) && GetWorldPhysic.GetIsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                if (_bodyType != BodyType.Dynamic)
                {
                    return;
                }

                // Move center of mass.
                Vector2F oldCenter = Sweep.C;
                Sweep.LocalCenter = value;
                Sweep.C0 = Sweep.C = Transform.Multiply(ref Sweep.LocalCenter, ref Xf);

                // Update center of mass velocity.
                Vector2F a = Sweep.C - oldCenter;
                LinearVelocityInternal += new Vector2F(-AngularVelocity * a.Y, AngularVelocity * a.X);
            }
        }

        /// <summary>
        ///     Gets or sets the mass. Usually in kilograms (kg).
        ///     Warning: This property is readonly during callbacks.
        /// </summary>
        /// <value>The mass.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public float Mass
        {
            get => _mass;
            set
            {
                if ((GetWorldPhysic != null) && GetWorldPhysic.GetIsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                Debug.Assert(!float.IsNaN(value));

                if (_bodyType != BodyType.Dynamic) //Make an assert
                {
                    return;
                }

                _mass = value;

                if (_mass <= 0.0f)
                {
                    _mass = 1.0f;
                }

                InvMass = 1.0f / _mass;
            }
        }

        /// <summary>
        ///     Get or set the rotational inertia of the body about the local origin. usually in kg-m^2.
        ///     Warning: This property is readonly during callbacks.
        /// </summary>
        /// <value>The inertia.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public float Inertia
        {
            get => _inertia + Mass * Vector2F.Dot(Sweep.LocalCenter, Sweep.LocalCenter);
            set
            {
                if ((GetWorldPhysic != null) && GetWorldPhysic.GetIsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                Debug.Assert(!float.IsNaN(value));

                if (_bodyType != BodyType.Dynamic) //Make an assert
                {
                    return;
                }

                if ((value > 0.0f) && !_fixedRotation) //Make an assert
                {
                    _inertia = value - Mass * Vector2F.Dot(LocalCenter, LocalCenter);
                    Debug.Assert(_inertia > 0.0f);
                    InvI = 1.0f / _inertia;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the value of the ignore ccd
        /// </summary>
        public bool IgnoreCcd { get; set; }

        /// <summary>
        ///     Create all proxies.
        /// </summary>
        internal void CreateProxies()
        {
            IBroadPhase broadPhase = GetWorldPhysic.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].CreateProxies(broadPhase, ref Xf);
            }
        }

        /// <summary>
        ///     Destroy all proxies.
        /// </summary>
        internal void DestroyProxies()
        {
            IBroadPhase broadPhase = GetWorldPhysic.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].DestroyProxies(broadPhase);
            }
        }

        /// <summary>
        ///     Destroy the attached contacts.
        /// </summary>
        private void DestroyContacts()
        {
            ContactEdge ce = ContactList;
            while (ce != null)
            {
                ContactEdge ce0 = ce;
                ce = ce.Next;
                GetWorldPhysic.ContactManager.Destroy(ce0.Contact);
            }

            ContactList = null;
        }

        /// <summary>
        ///     Resets the dynamics of this body.
        ///     Sets torque, force and linear/angular velocity to 0
        /// </summary>
        public void ResetDynamics()
        {
            Torque = 0;
            AngularVelocity = 0;
            Force = Vector2F.Zero;
            LinearVelocityInternal = Vector2F.Zero;
        }

        /// <summary>
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// >
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Add(Fixture fixture)
        {
            if ((GetWorldPhysic != null) && GetWorldPhysic.GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (fixture == null)
            {
                throw new ArgumentNullException("fixture");
            }

            if (fixture.GetBody != null)
            {
                if (fixture.GetBody == this)
                {
                    throw new ArgumentException("You are adding the same fixture more than once.", "fixture");
                }

                throw new ArgumentException("fixture belongs to another body.", "fixture");
            }

            fixture.GetBody = this;
            FixtureList.List.Add(fixture);
            FixtureList.GenerationStamp++;
#if DEBUG
            if (fixture.GetShape.ShapeType == ShapeType.Polygon)
            {
                ((PolygonShape) fixture.GetShape).Vertices.AttachedToBody = true;
            }
#endif

            // Adjust mass properties if needed.
            if (fixture.GetShape.Density > 0.0f)
            {
                ResetMassData();
            }

            if (GetWorldPhysic != null)
            {
                if (Enabled)
                {
                    IBroadPhase broadPhase = GetWorldPhysic.ContactManager.BroadPhase;
                    fixture.CreateProxies(broadPhase, ref Xf);
                }

                // Let the world know we have a new fixture. This will cause new contacts
                // to be created at the beginning of the next time step.
                GetWorldPhysic.WorldHasNewFixture = true;

                FixtureDelegate fixtureAddedHandler = GetWorldPhysic.FixtureAdded;
                if (fixtureAddedHandler != null)
                {
                    fixtureAddedHandler(GetWorldPhysic, this, fixture);
                }
            }
        }

        /// <summary>
        ///     Destroy a fixture. This removes the fixture from the broad-phase and
        ///     destroys all contacts associated with this fixture. This will
        ///     automatically adjust the mass of the body if the body is dynamic and the
        ///     fixture has positive density.
        ///     All fixtures attached to a body are implicitly destroyed when the body is destroyed.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="fixture">The fixture to be removed.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public virtual void Remove(Fixture fixture)
        {
            if ((GetWorldPhysic != null) && GetWorldPhysic.GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (fixture == null)
            {
                throw new ArgumentNullException("fixture");
            }

            if (fixture.GetBody != this)
            {
                throw new ArgumentException("You are removing a fixture that does not belong to this Body.", "fixture");
            }

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
                    GetWorldPhysic.ContactManager.Destroy(c);
                }
            }

            if (Enabled)
            {
                IBroadPhase broadPhase = GetWorldPhysic.ContactManager.BroadPhase;
                fixture.DestroyProxies(broadPhase);
            }

            fixture.GetBody = null;
            FixtureList.List.Remove(fixture);
            FixtureList.GenerationStamp++;
#if DEBUG
            if (fixture.GetShape.ShapeType == ShapeType.Polygon)
            {
                ((PolygonShape) fixture.GetShape).Vertices.AttachedToBody = false;
            }
#endif

            FixtureDelegate fixtureRemovedHandler = GetWorldPhysic.FixtureRemoved;
            if (fixtureRemovedHandler != null)
            {
                fixtureRemovedHandler(GetWorldPhysic, this, fixture);
            }

            ResetMassData();
        }

        /// <summary>
        ///     Set the position of the body's origin and rotation.
        ///     This breaks any contacts and wakes the other bodies.
        ///     Manipulating a body's transform may cause non-physical behavior.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="position">The world position of the body's local origin.</param>
        /// <param name="rotation">The world rotation in radians.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void SetTransform(ref Vector2F position, float rotation)
        {
            SetTransformIgnoreContacts(ref position, rotation);

            GetWorldPhysic.ContactManager.FindNewContacts();
        }

        /// <summary>
        ///     Set the position of the body's origin and rotation.
        ///     This breaks any contacts and wakes the other bodies.
        ///     Manipulating a body's transform may cause non-physical behavior.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="position">The world position of the body's local origin.</param>
        /// <param name="rotation">The world rotation in radians.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void SetTransform(Vector2F position, float rotation)
        {
            SetTransform(ref position, rotation);
        }

        /// <summary>
        ///     For teleporting a body without considering new contacts immediately.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The angle.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void SetTransformIgnoreContacts(ref Vector2F position, float angle)
        {
            Debug.Assert(GetWorldPhysic != null);
            if (GetWorldPhysic.GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            Xf.Q.Phase = angle;
            Xf.P = position;

            Sweep.C = Transform.Multiply(ref Sweep.LocalCenter, ref Xf);
            Sweep.A = angle;

            Sweep.C0 = Sweep.C;
            Sweep.A0 = angle;

            IBroadPhase broadPhase = GetWorldPhysic.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].Synchronize(broadPhase, ref Xf, ref Xf);
            }
        }

        /// <summary>
        ///     Get the body transform for the body's origin.
        /// </summary>
        /// <param name="transform">The transform of the body's origin.</param>
        public Transform GetTransform() => Xf;

        /// <summary>
        ///     Get the body transform for the body's origin.
        /// </summary>
        /// <param name="transform">The transform of the body's origin.</param>
        public void GetTransform(out Transform transform)
        {
            transform = Xf;
        }

        /// <summary>
        ///     Apply a force at a world point. If the force is not
        ///     applied at the center of mass, it will generate a torque and
        ///     affect the angular velocity. This wakes up the body.
        /// </summary>
        /// <param name="force">The world force vector, usually in Newtons (N).</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyForce(Vector2F force, Vector2F point)
        {
            ApplyForce(ref force, ref point);
        }

        /// <summary>
        ///     Applies a force at the center of mass.
        /// </summary>
        /// <param name="force">The force.</param>
        public void ApplyForce(ref Vector2F force)
        {
            ApplyForce(ref force, ref Xf.P);
        }

        /// <summary>
        ///     Applies a force at the center of mass.
        /// </summary>
        /// <param name="force">The force.</param>
        public void ApplyForce(Vector2F force)
        {
            ApplyForce(ref force, ref Xf.P);
        }

        /// <summary>
        ///     Apply a force at a world point. If the force is not
        ///     applied at the center of mass, it will generate a torque and
        ///     affect the angular velocity. This wakes up the body.
        /// </summary>
        /// <param name="force">The world force vector, usually in Newtons (N).</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyForce(ref Vector2F force, ref Vector2F point)
        {
            Debug.Assert(!float.IsNaN(force.X));
            Debug.Assert(!float.IsNaN(force.Y));
            Debug.Assert(!float.IsNaN(point.X));
            Debug.Assert(!float.IsNaN(point.Y));

            if (_bodyType == BodyType.Dynamic)
            {
                if (Awake == false)
                {
                    Awake = true;
                }

                Force += force;
                Torque += (point.X - Sweep.C.X) * force.Y - (point.Y - Sweep.C.Y) * force.X;
            }
        }

        /// <summary>
        ///     Apply a torque. This affects the angular velocity
        ///     without affecting the linear velocity of the center of mass.
        ///     This wakes up the body.
        /// </summary>
        /// <param name="torque">The torque about the z-axis (out of the screen), usually in N-m.</param>
        public void ApplyTorque(float torque)
        {
            Debug.Assert(!float.IsNaN(torque));

            if (_bodyType == BodyType.Dynamic)
            {
                if (Awake == false)
                {
                    Awake = true;
                }

                Torque += torque;
            }
        }

        /// <summary>
        ///     Apply an impulse at a point. This immediately modifies the velocity.
        ///     This wakes up the body.
        /// </summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        public void ApplyLinearImpulse(Vector2F impulse)
        {
            ApplyLinearImpulse(ref impulse);
        }

        /// <summary>
        ///     Apply an impulse at a point. This immediately modifies the velocity.
        ///     It also modifies the angular velocity if the point of application
        ///     is not at the center of mass.
        ///     This wakes up the body.
        /// </summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyLinearImpulse(Vector2F impulse, Vector2F point)
        {
            ApplyLinearImpulse(ref impulse, ref point);
        }

        /// <summary>
        ///     Apply an impulse at a point. This immediately modifies the velocity.
        ///     This wakes up the body.
        /// </summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        public void ApplyLinearImpulse(ref Vector2F impulse)
        {
            if (_bodyType != BodyType.Dynamic)
            {
                return;
            }

            if (Awake == false)
            {
                Awake = true;
            }

            LinearVelocityInternal += InvMass * impulse;
        }

        /// <summary>
        ///     Apply an impulse at a point. This immediately modifies the velocity.
        ///     It also modifies the angular velocity if the point of application
        ///     is not at the center of mass.
        ///     This wakes up the body.
        /// </summary>
        /// <param name="impulse">The world impulse vector, usually in N-seconds or kg-m/s.</param>
        /// <param name="point">The world position of the point of application.</param>
        public void ApplyLinearImpulse(ref Vector2F impulse, ref Vector2F point)
        {
            if (_bodyType != BodyType.Dynamic)
            {
                return;
            }

            if (Awake == false)
            {
                Awake = true;
            }

            LinearVelocityInternal += InvMass * impulse;
            AngularVelocity += InvI * ((point.X - Sweep.C.X) * impulse.Y - (point.Y - Sweep.C.Y) * impulse.X);
        }

        /// <summary>
        ///     Apply an angular impulse.
        /// </summary>
        /// <param name="impulse">The angular impulse in units of kg*m*m/s.</param>
        public void ApplyAngularImpulse(float impulse)
        {
            if (_bodyType != BodyType.Dynamic)
            {
                return;
            }

            if (Awake == false)
            {
                Awake = true;
            }

            AngularVelocity += InvI * impulse;
        }

        /// <summary>
        ///     This resets the mass properties to the sum of the mass properties of the fixtures.
        ///     This normally does not need to be called unless you called SetMassData to override
        ///     the mass and you later want to reset the mass.
        /// </summary>
        public void ResetMassData()
        {
            // Compute mass data from shapes. Each shape has its own density.
            _mass = 0.0f;
            InvMass = 0.0f;
            _inertia = 0.0f;
            InvI = 0.0f;
            Sweep.LocalCenter = Vector2F.Zero;

            // Kinematic bodies have zero mass.
            if (GetBodyType == BodyType.Kinematic)
            {
                Sweep.C0 = Xf.P;
                Sweep.C = Xf.P;
                Sweep.A0 = Sweep.A;
                return;
            }

            Debug.Assert(GetBodyType == BodyType.Dynamic || GetBodyType == BodyType.Static);

            // Accumulate mass over all fixtures.
            Vector2F localCenter = Vector2F.Zero;
            foreach (Fixture f in FixtureList)
            {
                if (Math.Abs(f.GetShape.Density) < SettingEnv.Epsilon)
                {
                    continue;
                }

                MassData massData = f.GetShape.MassData;
                _mass += massData.Mass;
                localCenter += massData.Mass * massData.Centroid;
                _inertia += massData.Inertia;
            }

            //FPE: Static bodies only have mass, they don't have other properties. A little hacky tho...
            if (GetBodyType == BodyType.Static)
            {
                Sweep.C0 = Sweep.C = Xf.P;
                return;
            }

            // Compute center of mass.
            if (_mass > 0.0f)
            {
                InvMass = 1.0f / _mass;
                localCenter *= InvMass;
            }
            else
            {
                // Force all dynamic bodies to have a positive mass.
                _mass = 1.0f;
                InvMass = 1.0f;
            }

            if ((_inertia > 0.0f) && !_fixedRotation)
            {
                // Center the inertia about the center of mass.
                _inertia -= _mass * Vector2F.Dot(localCenter, localCenter);

                Debug.Assert(_inertia > 0.0f);
                InvI = 1.0f / _inertia;
            }
            else
            {
                _inertia = 0.0f;
                InvI = 0.0f;
            }

            // Move center of mass.
            Vector2F oldCenter = Sweep.C;
            Sweep.LocalCenter = localCenter;
            Sweep.C0 = Sweep.C = Transform.Multiply(ref Sweep.LocalCenter, ref Xf);

            // Update center of mass velocity.
            Vector2F a = Sweep.C - oldCenter;
            LinearVelocityInternal += new Vector2F(-AngularVelocity * a.Y, AngularVelocity * a.X);
        }

        /// <summary>
        ///     Get the world coordinates of a point given the local coordinates.
        /// </summary>
        /// <param name="localPoint">A point on the body measured relative the the body's origin.</param>
        /// <returns>The same point expressed in world coordinates.</returns>
        public Vector2F GetWorldPoint(ref Vector2F localPoint) => Transform.Multiply(ref localPoint, ref Xf);

        /// <summary>
        ///     Get the world coordinates of a point given the local coordinates.
        /// </summary>
        /// <param name="localPoint">A point on the body measured relative the the body's origin.</param>
        /// <returns>The same point expressed in world coordinates.</returns>
        public Vector2F GetWorldPoint(Vector2F localPoint) => GetWorldPoint(ref localPoint);

        /// <summary>
        ///     Get the world coordinates of a vector given the local coordinates.
        ///     Note that the vector only takes the rotation into account, not the position.
        /// </summary>
        /// <param name="localVector">A vector fixed in the body.</param>
        /// <returns>The same vector expressed in world coordinates.</returns>
        public Vector2F GetWorldVector(ref Vector2F localVector) => Complex.Multiply(ref localVector, ref Xf.Q);

        /// <summary>
        ///     Get the world coordinates of a vector given the local coordinates.
        /// </summary>
        /// <param name="localVector">A vector fixed in the body.</param>
        /// <returns>The same vector expressed in world coordinates.</returns>
        public Vector2F GetWorldVector(Vector2F localVector) => GetWorldVector(ref localVector);

        /// <summary>
        ///     Gets a local point relative to the body's origin given a world point.
        ///     Note that the vector only takes the rotation into account, not the position.
        /// </summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The corresponding local point relative to the body's origin.</returns>
        public Vector2F GetLocalPoint(ref Vector2F worldPoint) => Transform.Divide(ref worldPoint, ref Xf);

        /// <summary>
        ///     Gets a local point relative to the body's origin given a world point.
        /// </summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The corresponding local point relative to the body's origin.</returns>
        public Vector2F GetLocalPoint(Vector2F worldPoint) => GetLocalPoint(ref worldPoint);

        /// <summary>
        ///     Gets a local vector given a world vector.
        ///     Note that the vector only takes the rotation into account, not the position.
        /// </summary>
        /// <param name="worldVector">A vector in world coordinates.</param>
        /// <returns>The corresponding local vector.</returns>
        public Vector2F GetLocalVector(ref Vector2F worldVector) => Complex.Divide(ref worldVector, ref Xf.Q);

        /// <summary>
        ///     Gets a local vector given a world vector.
        ///     Note that the vector only takes the rotation into account, not the position.
        /// </summary>
        /// <param name="worldVector">A vector in world coordinates.</param>
        /// <returns>The corresponding local vector.</returns>
        public Vector2F GetLocalVector(Vector2F worldVector) => GetLocalVector(ref worldVector);

        /// <summary>
        ///     Get the world linear velocity of a world point attached to this body.
        /// </summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromWorldPoint(Vector2F worldPoint) => GetLinearVelocityFromWorldPoint(ref worldPoint);

        /// <summary>
        ///     Get the world linear velocity of a world point attached to this body.
        /// </summary>
        /// <param name="worldPoint">A point in world coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromWorldPoint(ref Vector2F worldPoint) => LinearVelocityInternal +
                                                                                    new Vector2F(-AngularVelocity * (worldPoint.Y - Sweep.C.Y),
                                                                                        AngularVelocity * (worldPoint.X - Sweep.C.X));

        /// <summary>
        ///     Get the world velocity of a local point.
        /// </summary>
        /// <param name="localPoint">A point in local coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromLocalPoint(Vector2F localPoint) => GetLinearVelocityFromLocalPoint(ref localPoint);

        /// <summary>
        ///     Get the world velocity of a local point.
        /// </summary>
        /// <param name="localPoint">A point in local coordinates.</param>
        /// <returns>The world velocity of a point.</returns>
        public Vector2F GetLinearVelocityFromLocalPoint(ref Vector2F localPoint) => GetLinearVelocityFromWorldPoint(GetWorldPoint(ref localPoint));

        /// <summary>
        ///     Synchronizes the fixtures
        /// </summary>
        internal void SynchronizeFixtures()
        {
            Transform xf1 = new Transform(Vector2F.Zero, Sweep.A0);
            xf1.P = Sweep.C0 - Complex.Multiply(ref Sweep.LocalCenter, ref xf1.Q);

            IBroadPhase broadPhase = GetWorldPhysic.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].Synchronize(broadPhase, ref xf1, ref Xf);
            }
        }

        /// <summary>
        ///     Synchronizes the transform
        /// </summary>
        internal void SynchronizeTransform()
        {
            Xf.Q.Phase = Sweep.A;
            Xf.P = Sweep.C - Complex.Multiply(ref Sweep.LocalCenter, ref Xf.Q);
        }

        /// <summary>
        ///     This is used to prevent connected bodies from colliding.
        ///     It may lie, depending on the collideConnected flag.
        /// </summary>
        /// <param name="other">The other body.</param>
        /// <returns></returns>
        internal bool ShouldCollide(Body other)
        {
            // At least one body should be dynamic.
            if ((_bodyType != BodyType.Dynamic) && (other._bodyType != BodyType.Dynamic))
            {
                return false;
            }

            // Does a joint prevent collision?
            for (JointEdge jn = JointList; jn != null; jn = jn.Next)
            {
                if (jn.Other == other)
                {
                    if (jn.Joint.CollideConnected == false)
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
            Xf.Q.Phase = Sweep.A;
            Xf.P = Sweep.C - Complex.Multiply(ref Sweep.LocalCenter, ref Xf.Q);
        }

        /// <summary>
        ///     The on collision
        /// </summary>
        public event OnCollisionEventHandler OnCollision
        {
            add => OnCollisionEventHandler += value;
            remove => OnCollisionEventHandler -= value;
        }

        /// <summary>
        ///     The on separation
        /// </summary>
        public event OnSeparationEventHandler OnSeparation
        {
            add => OnSeparationEventHandler += value;
            remove => OnSeparationEventHandler -= value;
        }


        /// <summary>
        ///     Set restitution on all fixtures.
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <param name="restitution"></param>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetRestitution(float restitution)
        {
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].GetRestitution = restitution;
            }
        }

        /// <summary>
        ///     Set friction on all fixtures.
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <param name="friction"></param>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetFriction(float friction)
        {
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].GetFriction = friction;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetCollisionCategories(Category category)
        {
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].GetCollisionCategories = category;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetCollidesWith(Category category)
        {
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].GetCollidesWith = category;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetCollisionGroup(short collisionGroup)
        {
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].GetCollisionGroup = collisionGroup;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetIsSensor(bool isSensor)
        {
            for (int i = 0; i < FixtureList.List.Count; i++)
            {
                FixtureList.List[i].GetIsSensor = isSensor;
            }
        }

        /// <summary>
        ///     Makes a clone of the body. Fixtures and therefore shapes are not included.
        ///     Use DeepClone() to clone the body, as well as fixtures and shapes.
        /// </summary>
        /// <param name="worldPhysic"></param>
        /// <returns></returns>
        public Body Clone(WorldPhysic worldPhysic = null)
        {
            worldPhysic = worldPhysic ?? GetWorldPhysic;
            Body body = worldPhysic.CreateBody(Position, Rotation);
            body._bodyType = _bodyType;
            body.LinearVelocityInternal = LinearVelocityInternal;
            body.AngularVelocity = AngularVelocity;
            body.Tag = Tag;
            body.Enabled = Enabled;
            body._fixedRotation = _fixedRotation;
            body._sleepingAllowed = _sleepingAllowed;
            body._linearDamping = _linearDamping;
            body._angularDamping = _angularDamping;
            body._awake = _awake;
            body.IsBullet = IsBullet;
            body.IgnoreCcd = IgnoreCcd;
            body.IgnoreGravity = IgnoreGravity;
            body.Torque = Torque;

            return body;
        }

        /// <summary>
        ///     Clones the body and all attached fixtures and shapes. Simply said, it makes a complete copy of the body.
        /// </summary>
        /// <param name="worldPhysic"></param>
        /// <returns></returns>
        public Body DeepClone(WorldPhysic worldPhysic = null)
        {
            Body body = Clone(worldPhysic ?? GetWorldPhysic);

            int count = FixtureList.List.Count; //Make a copy of the count. Otherwise it causes an infinite loop.
            for (int i = 0; i < count; i++)
            {
                FixtureList.List[i].CloneOnto(body);
            }

            return body;
        }
    }
}