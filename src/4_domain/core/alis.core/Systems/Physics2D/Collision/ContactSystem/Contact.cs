// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Contact.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.Narrowphase;
using Alis.Core.Systems.Physics2D.Collision.Shapes;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Shared.Optimization;

namespace Alis.Core.Systems.Physics2D.Collision.ContactSystem
{
    /// <summary>
    ///     The class manages contact between two shapes. A contact exists for each overlapping AABB in the broad-phase
    ///     (except if filtered). Therefore a contact object may exist that has no contact points.
    /// </summary>
    public class Contact
    {
        /// <summary>
        ///     The fixture
        /// </summary>
        internal Fixture _fixtureA;

        /// <summary>
        ///     The fixture
        /// </summary>
        internal Fixture _fixtureB;

        //private bool _initialized;

        /// <summary>
        ///     The flags
        /// </summary>
        internal ContactFlags _flags;

        /// <summary>
        ///     The friction
        /// </summary>
        internal float _friction;

        /// <summary>
        ///     The index
        /// </summary>
        private int _indexA;

        /// <summary>
        ///     The index
        /// </summary>
        private int _indexB;

        /// <summary>
        ///     The manifold
        /// </summary>
        internal Manifold _manifold;

        /// <summary>
        ///     The next
        /// </summary>
        internal Contact _next;

        // Nodes for connecting bodies.
        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge _nodeA = new ContactEdge();

        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge _nodeB = new ContactEdge();

        // World pool and list pointers.
        /// <summary>
        ///     The prev
        /// </summary>
        internal Contact _prev;

        /// <summary>
        ///     The restitution
        /// </summary>
        internal float _restitution;

        /// <summary>
        ///     The restitution threshold
        /// </summary>
        internal float _restitutionThreshold;

        /// <summary>
        ///     The tangent speed
        /// </summary>
        internal float _tangentSpeed;

        /// <summary>
        ///     The toi
        /// </summary>
        internal float _toi;

        /// <summary>
        ///     The toi count
        /// </summary>
        internal int _toiCount;

        /// <summary>
        ///     The type
        /// </summary>
        private ContactType _type;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Contact" /> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        private Contact(Fixture fA, int indexA, Fixture fB, int indexB)
        {
            Reset(fA, indexA, fB, indexB);
        }

        /// <summary>Get the contact manifold. Do not modify the manifold unless you understand the internals of Box2D.</summary>
        public Manifold Manifold => _manifold;

        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        public float Friction
        {
            get => _friction;
            set => _friction = value;
        }

        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        public float Restitution
        {
            get => _restitution;
            set => _restitution = value;
        }

        /// <summary>
        ///     Gets or sets the value of the restitution threshold
        /// </summary>
        public float RestitutionThreshold
        {
            get => _restitutionThreshold;
            set => _restitutionThreshold = value;
        }

        /// <summary>Get or set the desired tangent speed for a conveyor belt behavior. In meters per second.</summary>
        public float TangentSpeed
        {
            get => _tangentSpeed;
            set => _tangentSpeed = value;
        }

        /// <summary>
        ///     Gets the value of the fixture a
        /// </summary>
        public Fixture FixtureA => _fixtureA;

        /// <summary>
        ///     Gets the value of the fixture b
        /// </summary>
        public Fixture FixtureB => _fixtureB;

        /// <summary>Get the child primitive index for fixture A.</summary>
        /// <value>The child index A.</value>
        public int ChildIndexA => _indexA;

        /// <summary>Get the child primitive index for fixture B.</summary>
        /// <value>The child index B.</value>
        public int ChildIndexB => _indexB;

        /// <summary>
        ///     Enable/disable this contact.The contact is only disabled for the current time step (or sub-step in continuous
        ///     collisions).
        /// </summary>
        public bool Enabled
        {
            get => (_flags & ContactFlags.EnabledFlag) == ContactFlags.EnabledFlag;
            set
            {
                if (value)
                {
                    _flags |= ContactFlags.EnabledFlag;
                }
                else
                {
                    _flags &= ~ContactFlags.EnabledFlag;
                }
            }
        }

        /// <summary>
        ///     Gets the value of the next
        /// </summary>
        public Contact Next => _next;

        /// <summary>
        ///     Gets the value of the previous
        /// </summary>
        public Contact Previous => _prev;

        /// <summary>
        ///     Gets the value of the is touching
        /// </summary>
        internal bool IsTouching => (_flags & ContactFlags.TouchingFlag) == ContactFlags.TouchingFlag;

        /// <summary>
        ///     Gets the value of the island flag
        /// </summary>
        internal bool IslandFlag => (_flags & ContactFlags.IslandFlag) == ContactFlags.IslandFlag;

        /// <summary>
        ///     Gets the value of the toi flag
        /// </summary>
        internal bool TOIFlag => (_flags & ContactFlags.TOIFlag) == ContactFlags.TOIFlag;

        /// <summary>
        ///     Gets the value of the filter flag
        /// </summary>
        internal bool FilterFlag => (_flags & ContactFlags.FilterFlag) == ContactFlags.FilterFlag;

        /// <summary>
        ///     The edge shape
        /// </summary>
        private static readonly EdgeShape _edge = new EdgeShape();

        /// <summary>
        ///     The not supported
        /// </summary>
        private static readonly ContactType[,] _registers =
        {
            {
                ContactType.Circle,
                ContactType.EdgeAndCircle,
                ContactType.PolygonAndCircle,
                ContactType.ChainAndCircle
            },
            {
                ContactType.EdgeAndCircle,
                ContactType.NotSupported,

                // 1,1 is invalid (no ContactType.Edge)
                ContactType.EdgeAndPolygon,
                ContactType.NotSupported

                // 1,3 is invalid (no ContactType.EdgeAndLoop)
            },
            {
                ContactType.PolygonAndCircle,
                ContactType.EdgeAndPolygon,
                ContactType.Polygon,
                ContactType.ChainAndPolygon
            },
            {
                ContactType.ChainAndCircle,
                ContactType.NotSupported,

                // 3,1 is invalid (no ContactType.EdgeAndLoop)
                ContactType.ChainAndPolygon,
                ContactType.NotSupported

                // 3,3 is invalid (no ContactType.Loop)
            }
        };

        /// <summary>
        ///     Resets the restitution
        /// </summary>
        public void ResetRestitution()
        {
            _restitution = Settings.MixRestitution(_fixtureA.Restitution, _fixtureB.Restitution);
        }

        /// <summary>
        ///     Resets the restitution threshold
        /// </summary>
        public void ResetRestitutionThreshold()
        {
            _restitutionThreshold = Settings.MixRestitutionThreshold(_fixtureA.Restitution, _fixtureB.Restitution);
        }

        /// <summary>
        ///     Resets the friction
        /// </summary>
        public void ResetFriction()
        {
            _friction = Settings.MixFriction(_fixtureA.Friction, _fixtureB.Friction);
        }

        /// <summary>Gets the world manifold.</summary>
        public void GetWorldManifold(out Vector2 normal, out FixedArray2<Vector2> points)
        {
            Body bodyA = _fixtureA.Body;
            Body bodyB = _fixtureB.Body;
            Shape shapeA = _fixtureA.Shape;
            Shape shapeB = _fixtureB.Shape;

            WorldManifold.Initialize(ref _manifold, ref bodyA._xf, shapeA._radius, ref bodyB._xf, shapeB._radius,
                out normal, out points, out _);
        }

        /// <summary>
        ///     Resets the f a
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        private void Reset(Fixture fA, int indexA, Fixture fB, int indexB)
        {
            _flags = ContactFlags.EnabledFlag;

            _fixtureA = fA;
            _fixtureB = fB;

            _indexA = indexA;
            _indexB = indexB;

            _manifold.PointCount = 0;

            _prev = null;
            _next = null;

            _nodeA.Contact = null;
            _nodeA.Prev = null;
            _nodeA.Next = null;
            _nodeA.Other = null;

            _nodeB.Contact = null;
            _nodeB.Prev = null;
            _nodeB.Next = null;
            _nodeB.Other = null;

            _toiCount = 0;

            //Velcro: We only set the friction and restitution if we are not resetting the contact
            if (_fixtureA != null && _fixtureB != null)
            {
                _friction = Settings.MixFriction(_fixtureA._friction, _fixtureB._friction);
                _restitution = Settings.MixRestitution(_fixtureA._restitution, _fixtureB._restitution);
                _restitutionThreshold =
                    Settings.MixRestitutionThreshold(_fixtureA._restitutionThreshold, _fixtureB._restitutionThreshold);
            }

            _tangentSpeed = 0;
        }

        /// <summary>
        ///     Update the contact manifold and touching status. Note: do not assume the fixture AABBs are overlapping or are
        ///     valid.
        /// </summary>
        /// <param name="contactManager">The contact manager.</param>
        internal void Update(ContactManager contactManager)
        {
            //Velcro: Do not try and update destroyed contacts
            if (_fixtureA == null || _fixtureB == null)
            {
                return;
            }

            Manifold oldManifold = _manifold;

            // Re-enable this contact.
            _flags |= ContactFlags.EnabledFlag;

            bool touching;
            bool wasTouching = IsTouching;

            bool sensor = _fixtureA.IsSensor || _fixtureB.IsSensor;

            Body bodyA = _fixtureA.Body;
            Body bodyB = _fixtureB.Body;

            Transform xfA = bodyA._xf;
            Transform xfB = bodyB._xf;

            // Is this contact a sensor?
            if (sensor)
            {
                Shape shapeA = _fixtureA.Shape;
                Shape shapeB = _fixtureB.Shape;
                touching = Narrowphase.Collision.TestOverlap(shapeA, _indexA, shapeB, _indexB, ref xfA, ref xfB);

                // Sensors don't generate manifolds.
                _manifold.PointCount = 0;
            }
            else
            {
                Evaluate(ref _manifold, ref xfA, ref xfB);
                touching = _manifold.PointCount > 0;

                // Match old contact ids to new contact ids and copy the
                // stored impulses to warm start the solver.
                for (int i = 0; i < _manifold.PointCount; ++i)
                {
                    ManifoldPoint mp2 = _manifold.Points[i];
                    mp2.NormalImpulse = 0.0f;
                    mp2.TangentImpulse = 0.0f;
                    ContactId id2 = mp2.Id;

                    for (int j = 0; j < oldManifold.PointCount; ++j)
                    {
                        ManifoldPoint mp1 = oldManifold.Points[j];

                        if (mp1.Id.Key == id2.Key)
                        {
                            mp2.NormalImpulse = mp1.NormalImpulse;
                            mp2.TangentImpulse = mp1.TangentImpulse;
                            break;
                        }
                    }

                    _manifold.Points[i] = mp2;
                }

                if (touching != wasTouching)
                {
                    bodyA.Awake = true;
                    bodyB.Awake = true;
                }
            }

            if (touching)
            {
                _flags |= ContactFlags.TouchingFlag;
            }
            else
            {
                _flags &= ~ContactFlags.TouchingFlag;
            }

            if (wasTouching == false && touching)
            {
                //Velcro: Report the collision to both fixtures:
                _fixtureA.OnCollision?.Invoke(_fixtureA, _fixtureB, this);
                _fixtureB.OnCollision?.Invoke(_fixtureB, _fixtureA, this);

                //Velcro: Report the collision to both bodies:
                bodyA.OnCollision?.Invoke(_fixtureA, _fixtureB, this);
                bodyB.OnCollision?.Invoke(_fixtureB, _fixtureA, this);

                // Call BeginContact. It can disable the contact as well.
                contactManager.BeginContact?.Invoke(this);

                // Velcro: If the user disabled the contact (needed to exclude it in TOI solver) at any point by
                // any of the callbacks, we need to mark it as not touching and call any separation
                // callbacks for fixtures that didn't explicitly disable the collision.
                if (!Enabled)
                {
                    touching = false;
                }
            }

            if (wasTouching && !touching)
            {
                //Report the separation to both fixtures:
                _fixtureA.OnSeparation?.Invoke(_fixtureA, _fixtureB, this);
                _fixtureB.OnSeparation?.Invoke(_fixtureB, _fixtureA, this);

                //Report the separation to both bodies:
                bodyA.OnSeparation?.Invoke(_fixtureA, _fixtureB, this);
                bodyB.OnSeparation?.Invoke(_fixtureB, _fixtureA, this);

                contactManager.EndContact?.Invoke(this);
            }

            if (!sensor && touching)
            {
                contactManager.PreSolve?.Invoke(this, ref oldManifold);
            }
        }

        /// <summary>Evaluate this contact with your own manifold and transforms.</summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="transformA">The first transform.</param>
        /// <param name="transformB">The second transform.</param>
        private void Evaluate(ref Manifold manifold, ref Transform transformA, ref Transform transformB)
        {
            switch (_type)
            {
                case ContactType.Polygon:
                    CollidePolygon.CollidePolygons(ref manifold, (PolygonShape) _fixtureA.Shape, ref transformA,
                        (PolygonShape) _fixtureB.Shape, ref transformB);
                    break;
                case ContactType.PolygonAndCircle:
                    CollideCircle.CollidePolygonAndCircle(ref manifold, (PolygonShape) _fixtureA.Shape, ref transformA,
                        (CircleShape) _fixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndCircle:
                    CollideEdge.CollideEdgeAndCircle(ref manifold, (EdgeShape) _fixtureA.Shape, ref transformA,
                        (CircleShape) _fixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndPolygon:
                    CollideEdge.CollideEdgeAndPolygon(ref manifold, (EdgeShape) _fixtureA.Shape, ref transformA,
                        (PolygonShape) _fixtureB.Shape, ref transformB);
                    break;
                case ContactType.ChainAndCircle:
                    ChainShape chain = (ChainShape) _fixtureA.Shape;
                    chain.GetChildEdge(_edge, ChildIndexA);
                    CollideEdge.CollideEdgeAndCircle(ref manifold, _edge, ref transformA, (CircleShape) _fixtureB.Shape,
                        ref transformB);
                    break;
                case ContactType.ChainAndPolygon:
                    ChainShape loop2 = (ChainShape) _fixtureA.Shape;
                    loop2.GetChildEdge(_edge, ChildIndexA);
                    CollideEdge.CollideEdgeAndPolygon(ref manifold, _edge, ref transformA,
                        (PolygonShape) _fixtureB.Shape, ref transformB);
                    break;
                case ContactType.Circle:
                    CollideCircle.CollideCircles(ref manifold, (CircleShape) _fixtureA.Shape, ref transformA,
                        (CircleShape) _fixtureB.Shape, ref transformB);
                    break;
                default:
                    throw new ArgumentException("You are using an unsupported contact type.");
            }
        }

        /// <summary>
        ///     Creates the fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        /// <returns>The </returns>
        internal static Contact Create(Fixture fixtureA, int indexA, Fixture fixtureB, int indexB)
        {
            ShapeType type1 = fixtureA.Shape.ShapeType;
            ShapeType type2 = fixtureB.Shape.ShapeType;

            Debug.Assert(ShapeType.Unknown < type1 && type1 < ShapeType.TypeCount);
            Debug.Assert(ShapeType.Unknown < type2 && type2 < ShapeType.TypeCount);

            Contact c;
            Queue<Contact> pool = fixtureA.Body._world._contactPool;
            if (pool.Count > 0)
            {
                c = pool.Dequeue();
                if ((type1 >= type2 || type1 == ShapeType.Edge && type2 == ShapeType.Polygon) &&
                    !(type2 == ShapeType.Edge && type1 == ShapeType.Polygon))
                {
                    c.Reset(fixtureA, indexA, fixtureB, indexB);
                }
                else
                {
                    c.Reset(fixtureB, indexB, fixtureA, indexA);
                }
            }
            else
            {
                // Edge+Polygon is non-symmetrical due to the way Erin handles collision type registration.
                if ((type1 >= type2 || type1 == ShapeType.Edge && type2 == ShapeType.Polygon) &&
                    !(type2 == ShapeType.Edge && type1 == ShapeType.Polygon))
                {
                    c = new Contact(fixtureA, indexA, fixtureB, indexB);
                }
                else
                {
                    c = new Contact(fixtureB, indexB, fixtureA, indexA);
                }
            }

            c._type = _registers[(int) type1, (int) type2];

            return c;
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        internal void Destroy()
        {
            //Debug.Assert(_initialized);

            //Fixture fixtureA = _fixtureA;
            //Fixture fixtureB = _fixtureB;

            if (_manifold.PointCount > 0 && !_fixtureA.IsSensor && !_fixtureB.IsSensor)
            {
                _fixtureA.Body.Awake = true;
                _fixtureB.Body.Awake = true;
            }

            //b2Shape::Type typeA = fixtureA->GetType();
            //b2Shape::Type typeB = fixtureB->GetType();

            //Debug.Assert(0 <= typeA && typeA < b2Shape::e_typeCount);
            //Debug.Assert(0 <= typeB && typeB < b2Shape::e_typeCount);

            _fixtureA._body._world._contactPool.Enqueue(this);

            Reset(null, 0, null, 0);
        }
    }
}