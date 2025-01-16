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
        ///     The force
        /// </summary>
        internal Vector2F Force { get; set; }

        /// <summary>
        ///     The inertia
        /// </summary>
        private float _inertia;

        /// <summary>
        ///     The inv
        /// </summary>
        internal float InvI { get; set; }

        /// <summary>
        ///     The inv mass
        /// </summary>
        internal float InvMass { get; set; }

        /// <summary>
        ///     The island
        /// </summary>
        internal bool _island;

        /// <summary>
        ///     The linear damping
        /// </summary>
        private float _linearDamping;

        /// <summary>
        ///     The linear velocity
        /// </summary>
        internal Vector2F _linearVelocity;

        /// <summary>
        ///     The lock
        /// </summary>
        internal int _lock;

        /// <summary>
        ///     The lock order
        /// </summary>
        internal int _lockOrder;

        /// <summary>
        ///     The mass
        /// </summary>
        private float _mass;

        /// <summary>
        ///     The sleeping allowed
        /// </summary>
        private bool _sleepingAllowed;

        /// <summary>
        ///     The sleep time
        /// </summary>
        internal float _sleepTime;

        /// <summary>
        ///     The sweep
        /// </summary>
        internal Sweep _sweep; // the swept motion for CCD

        /// <summary>
        ///     The torque
        /// </summary>
        internal float _torque;

        /// <summary>
        ///     The world
        /// </summary>
        internal World _world;

        /// <summary>
        ///     The xf
        /// </summary>
        internal Transform _xf; // the body origin transform

        /// <summary>
        ///     The all
        /// </summary>
        public ControllerFilter ControllerFilter = new ControllerFilter(ControllerCategory.All);

        /// <summary>
        ///     The on collision event handler
        /// </summary>
        internal OnCollisionEventHandler onCollisionEventHandler;

        /// <summary>
        ///     The on separation event handler
        /// </summary>
        internal OnSeparationEventHandler onSeparationEventHandler;

        /// <summary>
        ///     Set the user data. Use this to store your application specific data.
        /// </summary>
        /// <value>The user data.</value>
        public object Tag;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Body" /> class
        /// </summary>
        public Body()
        {
            FixtureList = new FixtureCollection(this);

            Enabled = true;
            _awake = true;
            _sleepingAllowed = true;
            _xf.Q = Complex.One;

            BodyType = BodyType.Static;
        }

        /// <summary>
        ///     Get the parent World of this body. This is null if the body is not attached.
        /// </summary>
        public World World => _world;

        /// <remarks>Deprecated in version 1.6</remarks>

        public int IslandIndex { get; internal set; }

        /// <summary>
        ///     Gets the total number revolutions the body has made.
        /// </summary>
        /// <value>The revolutions.</value>
        public float Revolutions => Rotation / (2 * (float) Math.PI);

        /// <summary>
        ///     Gets or sets the body type.
        ///     Warning: This property is readonly during callbacks.
        /// </summary>
        /// <value>The type of body.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public BodyType BodyType
        {
            get => _bodyType;
            set
            {
                if ((World != null) && World.IsLocked)
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
                    _linearVelocity = Vector2F.Zero;
                    AngularVelocity = 0.0f;
                    _sweep.A0 = _sweep.A;
                    _sweep.C0 = _sweep.C;
                    SynchronizeFixtures();
                }

                Awake = true;

                Force = Vector2F.Zero;
                _torque = 0.0f;

                // Delete the attached contacts.
                ContactEdge ce = ContactList;
                while (ce != null)
                {
                    ContactEdge ce0 = ce;
                    ce = ce.Next;
                    World.ContactManager.Destroy(ce0.Contact);
                }

                ContactList = null;

                if (World != null)
                {
                    // Touch the proxies so that new contacts will be created (when appropriate)
                    IBroadPhase broadPhase = World.ContactManager.BroadPhase;
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

                _linearVelocity = value;
            }
            get => _linearVelocity;
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
                        _sleepTime = 0.0f;
                    }
                }
                else
                {
                    ResetDynamics();
                    _sleepTime = 0.0f;
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
                if ((World != null) && World.IsLocked)
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
                    if (World != null)
                    {
                        CreateProxies();
                    }

                    // Contacts are created the next time step.
                }
                else
                {
                    if (World != null)
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
            get => _xf.P;
            set
            {
                Debug.Assert(!float.IsNaN(value.X) && !float.IsNaN(value.Y));

                if (World == null)
                {
                    _xf.P = value;
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
            get => _sweep.A;
            set
            {
                Debug.Assert(!float.IsNaN(value));

                if (World == null)
                {
                    _sweep.A = value;
                }
                else
                {
                    SetTransform(ref _xf.P, value);
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
        public Vector2F WorldCenter => _sweep.C;

        /// <summary>
        ///     Get the local position of the center of mass.
        ///     Warning: This property is readonly during callbacks.
        /// </summary>
        /// <value>The local position.</value>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public Vector2F LocalCenter
        {
            get => _sweep.LocalCenter;
            set
            {
                if ((World != null) && World.IsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                if (_bodyType != BodyType.Dynamic)
                {
                    return;
                }

                // Move center of mass.
                Vector2F oldCenter = _sweep.C;
                _sweep.LocalCenter = value;
                _sweep.C0 = _sweep.C = Transform.Multiply(ref _sweep.LocalCenter, ref _xf);

                // Update center of mass velocity.
                Vector2F a = _sweep.C - oldCenter;
                _linearVelocity += new Vector2F(-AngularVelocity * a.Y, AngularVelocity * a.X);
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
                if ((World != null) && World.IsLocked)
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
            get => _inertia + Mass * Vector2F.Dot(_sweep.LocalCenter, _sweep.LocalCenter);
            set
            {
                if ((World != null) && World.IsLocked)
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
        public bool IgnoreCCD { get; set; }

        /// <summary>
        ///     Create all proxies.
        /// </summary>
        internal void CreateProxies()
        {
            IBroadPhase broadPhase = World.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].CreateProxies(broadPhase, ref _xf);
            }
        }

        /// <summary>
        ///     Destroy all proxies.
        /// </summary>
        internal void DestroyProxies()
        {
            IBroadPhase broadPhase = World.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].DestroyProxies(broadPhase);
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
                World.ContactManager.Destroy(ce0.Contact);
            }

            ContactList = null;
        }

        /// <summary>
        ///     Resets the dynamics of this body.
        ///     Sets torque, force and linear/angular velocity to 0
        /// </summary>
        public void ResetDynamics()
        {
            _torque = 0;
            AngularVelocity = 0;
            Force = Vector2F.Zero;
            _linearVelocity = Vector2F.Zero;
        }

        /// <summary>
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// >
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Add(Fixture fixture)
        {
            if ((World != null) && World.IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (fixture == null)
            {
                throw new ArgumentNullException("fixture");
            }

            if (fixture.Body != null)
            {
                if (fixture.Body == this)
                {
                    throw new ArgumentException("You are adding the same fixture more than once.", "fixture");
                }

                throw new ArgumentException("fixture belongs to another body.", "fixture");
            }

            fixture.Body = this;
            FixtureList._list.Add(fixture);
            FixtureList._generationStamp++;
#if DEBUG
            if (fixture.Shape.ShapeType == ShapeType.Polygon)
            {
                ((PolygonShape) fixture.Shape).Vertices.AttachedToBody = true;
            }
#endif

            // Adjust mass properties if needed.
            if (fixture.Shape.Density > 0.0f)
            {
                ResetMassData();
            }

            if (World != null)
            {
                if (Enabled)
                {
                    IBroadPhase broadPhase = World.ContactManager.BroadPhase;
                    fixture.CreateProxies(broadPhase, ref _xf);
                }

                // Let the world know we have a new fixture. This will cause new contacts
                // to be created at the beginning of the next time step.
                World.WorldHasNewFixture = true;

                FixtureDelegate fixtureAddedHandler = World.FixtureAdded;
                if (fixtureAddedHandler != null)
                {
                    fixtureAddedHandler(World, this, fixture);
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
            if ((World != null) && World.IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (fixture == null)
            {
                throw new ArgumentNullException("fixture");
            }

            if (fixture.Body != this)
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
                    World.ContactManager.Destroy(c);
                }
            }

            if (Enabled)
            {
                IBroadPhase broadPhase = World.ContactManager.BroadPhase;
                fixture.DestroyProxies(broadPhase);
            }

            fixture.Body = null;
            FixtureList._list.Remove(fixture);
            FixtureList._generationStamp++;
#if DEBUG
            if (fixture.Shape.ShapeType == ShapeType.Polygon)
            {
                ((PolygonShape) fixture.Shape).Vertices.AttachedToBody = false;
            }
#endif

            FixtureDelegate fixtureRemovedHandler = World.FixtureRemoved;
            if (fixtureRemovedHandler != null)
            {
                fixtureRemovedHandler(World, this, fixture);
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

            World.ContactManager.FindNewContacts();
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
            Debug.Assert(World != null);
            if (World.IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            _xf.Q.Phase = angle;
            _xf.P = position;

            _sweep.C = Transform.Multiply(ref _sweep.LocalCenter, ref _xf);
            _sweep.A = angle;

            _sweep.C0 = _sweep.C;
            _sweep.A0 = angle;

            IBroadPhase broadPhase = World.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].Synchronize(broadPhase, ref _xf, ref _xf);
            }
        }

        /// <summary>
        ///     Get the body transform for the body's origin.
        /// </summary>
        /// <param name="transform">The transform of the body's origin.</param>
        public Transform GetTransform() => _xf;

        /// <summary>
        ///     Get the body transform for the body's origin.
        /// </summary>
        /// <param name="transform">The transform of the body's origin.</param>
        public void GetTransform(out Transform transform)
        {
            transform = _xf;
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
            ApplyForce(ref force, ref _xf.P);
        }

        /// <summary>
        ///     Applies a force at the center of mass.
        /// </summary>
        /// <param name="force">The force.</param>
        public void ApplyForce(Vector2F force)
        {
            ApplyForce(ref force, ref _xf.P);
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
                _torque += (point.X - _sweep.C.X) * force.Y - (point.Y - _sweep.C.Y) * force.X;
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

                _torque += torque;
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

            _linearVelocity += InvMass * impulse;
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

            _linearVelocity += InvMass * impulse;
            AngularVelocity += InvI * ((point.X - _sweep.C.X) * impulse.Y - (point.Y - _sweep.C.Y) * impulse.X);
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
            _sweep.LocalCenter = Vector2F.Zero;

            // Kinematic bodies have zero mass.
            if (BodyType == BodyType.Kinematic)
            {
                _sweep.C0 = _xf.P;
                _sweep.C = _xf.P;
                _sweep.A0 = _sweep.A;
                return;
            }

            Debug.Assert(BodyType == BodyType.Dynamic || BodyType == BodyType.Static);

            // Accumulate mass over all fixtures.
            Vector2F localCenter = Vector2F.Zero;
            foreach (Fixture f in FixtureList)
            {
                if (Math.Abs(f.Shape.Density) < SettingEnv.Epsilon)
                {
                    continue;
                }

                MassData massData = f.Shape.MassData;
                _mass += massData.Mass;
                localCenter += massData.Mass * massData.Centroid;
                _inertia += massData.Inertia;
            }

            //FPE: Static bodies only have mass, they don't have other properties. A little hacky tho...
            if (BodyType == BodyType.Static)
            {
                _sweep.C0 = _sweep.C = _xf.P;
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
            Vector2F oldCenter = _sweep.C;
            _sweep.LocalCenter = localCenter;
            _sweep.C0 = _sweep.C = Transform.Multiply(ref _sweep.LocalCenter, ref _xf);

            // Update center of mass velocity.
            Vector2F a = _sweep.C - oldCenter;
            _linearVelocity += new Vector2F(-AngularVelocity * a.Y, AngularVelocity * a.X);
        }

        /// <summary>
        ///     Get the world coordinates of a point given the local coordinates.
        /// </summary>
        /// <param name="localPoint">A point on the body measured relative the the body's origin.</param>
        /// <returns>The same point expressed in world coordinates.</returns>
        public Vector2F GetWorldPoint(ref Vector2F localPoint) => Transform.Multiply(ref localPoint, ref _xf);

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
        public Vector2F GetWorldVector(ref Vector2F localVector) => Complex.Multiply(ref localVector, ref _xf.Q);

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
        public Vector2F GetLocalPoint(ref Vector2F worldPoint) => Transform.Divide(ref worldPoint, ref _xf);

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
        public Vector2F GetLocalVector(ref Vector2F worldVector) => Complex.Divide(ref worldVector, ref _xf.Q);

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
        public Vector2F GetLinearVelocityFromWorldPoint(ref Vector2F worldPoint) => _linearVelocity +
                                                                                    new Vector2F(-AngularVelocity * (worldPoint.Y - _sweep.C.Y),
                                                                                        AngularVelocity * (worldPoint.X - _sweep.C.X));

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
            Transform xf1 = new Transform(Vector2F.Zero, _sweep.A0);
            xf1.P = _sweep.C0 - Complex.Multiply(ref _sweep.LocalCenter, ref xf1.Q);

            IBroadPhase broadPhase = World.ContactManager.BroadPhase;
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].Synchronize(broadPhase, ref xf1, ref _xf);
            }
        }

        /// <summary>
        ///     Synchronizes the transform
        /// </summary>
        internal void SynchronizeTransform()
        {
            _xf.Q.Phase = _sweep.A;
            _xf.P = _sweep.C - Complex.Multiply(ref _sweep.LocalCenter, ref _xf.Q);
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
            _sweep.Advance(alpha);
            _sweep.C = _sweep.C0;
            _sweep.A = _sweep.A0;
            _xf.Q.Phase = _sweep.A;
            _xf.P = _sweep.C - Complex.Multiply(ref _sweep.LocalCenter, ref _xf.Q);
        }

        /// <summary>
        ///     The on collision
        /// </summary>
        public event OnCollisionEventHandler OnCollision
        {
            add => onCollisionEventHandler += value;
            remove => onCollisionEventHandler -= value;
        }

        /// <summary>
        ///     The on separation
        /// </summary>
        public event OnSeparationEventHandler OnSeparation
        {
            add => onSeparationEventHandler += value;
            remove => onSeparationEventHandler -= value;
        }


        /// <summary>
        ///     Set restitution on all fixtures.
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <param name="restitution"></param>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetRestitution(float restitution)
        {
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].Restitution = restitution;
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
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].Friction = friction;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetCollisionCategories(Category category)
        {
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].CollisionCategories = category;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetCollidesWith(Category category)
        {
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].CollidesWith = category;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetCollisionGroup(short collisionGroup)
        {
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].CollisionGroup = collisionGroup;
            }
        }

        /// <summary>
        ///     Warning: This method applies the value on existing Fixtures. It's not a property of Body.
        /// </summary>
        /// <remarks>Deprecated in version 1.6</remarks>
        public void SetIsSensor(bool isSensor)
        {
            for (int i = 0; i < FixtureList._list.Count; i++)
            {
                FixtureList._list[i].IsSensor = isSensor;
            }
        }

        /// <summary>
        ///     Makes a clone of the body. Fixtures and therefore shapes are not included.
        ///     Use DeepClone() to clone the body, as well as fixtures and shapes.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public Body Clone(World world = null)
        {
            world = world ?? World;
            Body body = world.CreateBody(Position, Rotation);
            body._bodyType = _bodyType;
            body._linearVelocity = _linearVelocity;
            body.AngularVelocity = AngularVelocity;
            body.Tag = Tag;
            body.Enabled = Enabled;
            body._fixedRotation = _fixedRotation;
            body._sleepingAllowed = _sleepingAllowed;
            body._linearDamping = _linearDamping;
            body._angularDamping = _angularDamping;
            body._awake = _awake;
            body.IsBullet = IsBullet;
            body.IgnoreCCD = IgnoreCCD;
            body.IgnoreGravity = IgnoreGravity;
            body._torque = _torque;

            return body;
        }

        /// <summary>
        ///     Clones the body and all attached fixtures and shapes. Simply said, it makes a complete copy of the body.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public Body DeepClone(World world = null)
        {
            Body body = Clone(world ?? World);

            int count = FixtureList._list.Count; //Make a copy of the count. Otherwise it causes an infinite loop.
            for (int i = 0; i < count; i++)
            {
                FixtureList._list[i].CloneOnto(body);
            }

            return body;
        }
    }
}