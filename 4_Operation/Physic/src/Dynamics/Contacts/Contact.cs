// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Contact.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The class manages contact between two shapes. A contact exists for each overlapping
    ///     AABB in the broad-phase (except if filtered). Therefore a contact object may exist
    ///     that has no contact points.
    /// </summary>
    public class Contact
    {
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

        // Nodes for connecting bodies.
        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge _nodeA = new ContactEdge();

        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge _nodeB = new ContactEdge();

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
        ///     Get the contact manifold. Do not modify the manifold unless you understand the
        ///     internals of Box2D.
        /// </summary>
        public Manifold Manifold;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Contact" /> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        protected Contact(Fixture fA, int indexA, Fixture fB, int indexB)
        {
            Reset(fA, indexA, fB, indexB);
        }

        /// <summary>
        ///     Gets or sets the value of the fixture a
        /// </summary>
        public Fixture FixtureA { get; internal set; }

        /// <summary>
        ///     Gets or sets the value of the fixture b
        /// </summary>
        public Fixture FixtureB { get; internal set; }

        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        public float Friction { get; set; }

        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        public float Restitution { get; set; }

        /// Get or set the desired tangent speed for a conveyor belt behavior. In meters per second.
        public float TangentSpeed { get; set; }

        /// Enable/disable this contact. This can be used inside the pre-solve
        /// contact listener. The contact is only disabled for the current
        /// time step (or sub-step in continuous collisions).
        /// NOTE: If you are setting Enabled to a constant true or false,
        /// use the explicit Enable() or Disable() functions instead to 
        /// save the CPU from doing a branch operation.
        public bool Enabled { get; set; }

        /// <summary>
        ///     Get the child primitive index for fixture A.
        /// </summary>
        /// <value>The child index A.</value>
        public int ChildIndexA { get; internal set; }

        /// <summary>
        ///     Get the child primitive index for fixture B.
        /// </summary>
        /// <value>The child index B.</value>
        public int ChildIndexB { get; internal set; }

        /// <summary>
        ///     Get the next contact in the world's contact list.
        /// </summary>
        /// <value>The next.</value>
        public Contact Next { get; internal set; }

        /// <summary>
        ///     Get the previous contact in the world's contact list.
        /// </summary>
        /// <value>The prev.</value>
        public Contact Prev { get; internal set; }

        /// <summary>
        ///     Determines whether this contact is touching.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this instance is touching; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTouching { get; set; }

        /// <summary>
        ///     Gets or sets the value of the island flag
        /// </summary>
        internal bool IslandFlag { get; set; }

        /// <summary>
        ///     Gets or sets the value of the toi flag
        /// </summary>
        internal bool TOIFlag { get; set; }

        /// <summary>
        ///     Gets or sets the value of the filter flag
        /// </summary>
        internal bool FilterFlag { get; set; }

        /// <summary>
        ///     Resets the restitution
        /// </summary>
        public void ResetRestitution()
        {
            Restitution = SettingEnv.MixRestitution(FixtureA.Restitution, FixtureB.Restitution);
        }

        /// <summary>
        ///     Resets the friction
        /// </summary>
        public void ResetFriction()
        {
            Friction = SettingEnv.MixFriction(FixtureA.Friction, FixtureB.Friction);
        }

        /// <summary>
        ///     Gets the world manifold.
        /// </summary>
        public void GetWorldManifold(out Vector2F normal, out FixedArray2<Vector2F> points)
        {
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;
            Shape shapeA = FixtureA.Shape;
            Shape shapeB = FixtureB.Shape;

            ContactSolver.WorldManifold.Initialize(ref Manifold, ref bodyA._xf, shapeA.Radius, ref bodyB._xf, shapeB.Radius, out normal, out points);
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
            Enabled = true;
            IsTouching = false;
            IslandFlag = false;
            FilterFlag = false;
            TOIFlag = false;

            FixtureA = fA;
            FixtureB = fB;

            ChildIndexA = indexA;
            ChildIndexB = indexB;

            Manifold.PointCount = 0;

            Next = null;
            Prev = null;

            _nodeA.Contact = null;
            _nodeA.Other = null;
            _nodeA.Next = null;
            _nodeA.Prev = null;

            _nodeB.Contact = null;
            _nodeB.Other = null;
            _nodeB.Next = null;
            _nodeB.Prev = null;

            _toiCount = 0;

            //FPE: We only set the friction and restitution if we are not destroying the contact
            if ((FixtureA != null) && (FixtureB != null))
            {
                Friction = SettingEnv.MixFriction(FixtureA.Friction, FixtureB.Friction);
                Restitution = SettingEnv.MixRestitution(FixtureA.Restitution, FixtureB.Restitution);
            }

            TangentSpeed = 0;
        }

        /// <summary>
        ///     Update the contact manifold and touching status.
        ///     Note: do not assume the fixture AABBs are overlapping or are valid.
        /// </summary>
        /// <param name="contactManager">The contact manager.</param>
        internal void Update(ContactManager contactManager)
        {
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;

            Manifold oldManifold = Manifold;

            // Re-enable this contact.
            Enabled = true;

            bool touching;
            bool wasTouching = IsTouching;

            bool sensor = FixtureA.IsSensor || FixtureB.IsSensor;

            // Is this contact a sensor?
            if (sensor)
            {
                Shape shapeA = FixtureA.Shape;
                Shape shapeB = FixtureB.Shape;
                touching = Collision.Collision.TestOverlap(shapeA, ChildIndexA, shapeB, ChildIndexB, ref bodyA._xf, ref bodyB._xf);

                // Sensors don't generate manifolds.
                Manifold.PointCount = 0;
            }
            else
            {
                Evaluate(ref Manifold, ref bodyA._xf, ref bodyB._xf);
                touching = Manifold.PointCount > 0;

                // Match old contact ids to new contact ids and copy the
                // stored impulses to warm start the solver.
                for (int i = 0; i < Manifold.PointCount; ++i)
                {
                    ManifoldPoint mp2 = Manifold.Points[i];
                    mp2.NormalImpulse = 0.0f;
                    mp2.TangentImpulse = 0.0f;
                    ContactID id2 = mp2.Id;

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

                    Manifold.Points[i] = mp2;
                }

                if (touching != wasTouching)
                {
                    bodyA.Awake = true;
                    bodyB.Awake = true;
                }
            }

            IsTouching = touching;

            if (wasTouching == false)
            {
                if (touching)
                {
                    bool enabledA = true, enabledB = true;

                    // Report the collision to both participants. Track which ones returned true so we can
                    // later call OnSeparation if the contact is disabled for a different reason.
                    OnCollisionEventHandler onFixtureCollisionHandlerA = FixtureA.OnCollision;
                    if (onFixtureCollisionHandlerA != null)
                    {
                        foreach (OnCollisionEventHandler handler in onFixtureCollisionHandlerA.GetInvocationList())
                            enabledA = handler(FixtureA, FixtureB, this) && enabledA;
                    }

                    // Reverse the order of the reported fixtures. The first fixture is always the one that the
                    // user subscribed to.
                    OnCollisionEventHandler onFixtureCollisionHandlerB = FixtureB.OnCollision;
                    if (onFixtureCollisionHandlerB != null)
                    {
                        foreach (OnCollisionEventHandler handler in onFixtureCollisionHandlerB.GetInvocationList())
                            enabledB = handler(FixtureB, FixtureA, this) && enabledB;
                    }

                    // Report the collision to both bodies:
                    OnCollisionEventHandler onBodyCollisionHandlerA = bodyA.onCollisionEventHandler;
                    if (onBodyCollisionHandlerA != null)
                    {
                        foreach (OnCollisionEventHandler handler in onBodyCollisionHandlerA.GetInvocationList())
                            enabledA = handler(FixtureA, FixtureB, this) && enabledA;
                    }

                    // Reverse the order of the reported fixtures. The first fixture is always the one that the
                    // user subscribed to.
                    OnCollisionEventHandler onBodyCollisionHandlerB = bodyB.onCollisionEventHandler;
                    if (onBodyCollisionHandlerB != null)
                    {
                        foreach (OnCollisionEventHandler handler in onBodyCollisionHandlerB.GetInvocationList())
                            enabledB = handler(FixtureB, FixtureA, this) && enabledB;
                    }


                    Enabled = enabledA && enabledB;

                    // BeginContact can also return false and disable the contact
                    BeginContactDelegate beginContactHandler = contactManager.BeginContact;
                    if (enabledA && enabledB && (beginContactHandler != null))
                    {
                        Enabled = beginContactHandler(this);
                    }

                    // If the user disabled the contact (needed to exclude it in TOI solver) at any point by
                    // any of the callbacks, we need to mark it as not touching and call any separation
                    // callbacks for fixtures that didn't explicitly disable the collision.
                    if (!Enabled)
                    {
                        IsTouching = false;
                    }
                }
            }
            else
            {
                if (touching == false)
                {
                    //Report the separation to both participants:
                    OnSeparationEventHandler onFixtureSeparationHandlerA = FixtureA.OnSeparation;
                    if (onFixtureSeparationHandlerA != null)
                    {
                        onFixtureSeparationHandlerA(FixtureA, FixtureB, this);
                    }

                    //Reverse the order of the reported fixtures. The first fixture is always the one that the
                    //user subscribed to.
                    OnSeparationEventHandler onFixtureSeparationHandlerB = FixtureB.OnSeparation;
                    if (onFixtureSeparationHandlerB != null)
                    {
                        onFixtureSeparationHandlerB(FixtureB, FixtureA, this);
                    }

                    //Report the separation to both bodies:
                    OnSeparationEventHandler onBodySeparationHandlerA = bodyA.onSeparationEventHandler;
                    if (onBodySeparationHandlerA != null)
                    {
                        onBodySeparationHandlerA(FixtureA, FixtureB, this);
                    }

                    //Reverse the order of the reported fixtures. The first fixture is always the one that the
                    //user subscribed to.
                    OnSeparationEventHandler onBodySeparationHandlerB = bodyB.onSeparationEventHandler;
                    if (onBodySeparationHandlerB != null)
                    {
                        onBodySeparationHandlerB(FixtureB, FixtureA, this);
                    }

                    EndContactDelegate endContactHandler = contactManager.EndContact;
                    if (endContactHandler != null)
                    {
                        endContactHandler(this);
                    }
                }
            }

            if (sensor)
            {
                return;
            }

            PreSolveDelegate preSolveHandler = contactManager.PreSolve;
            if (preSolveHandler != null)
            {
                preSolveHandler(this, ref oldManifold);
            }
        }

        /// <summary>
        ///     Evaluate this contact with your own manifold and transforms.
        /// </summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="transformA">The first transform.</param>
        /// <param name="transformB">The second transform.</param>
        private void Evaluate(ref Manifold manifold, ref Transform transformA, ref Transform transformB)
        {
            switch (_type)
            {
                case ContactType.Polygon:
                    Collision.Collision.CollidePolygons(ref manifold, (PolygonShape) FixtureA.Shape, ref transformA, (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.PolygonAndCircle:
                    Collision.Collision.CollidePolygonAndCircle(ref manifold, (PolygonShape) FixtureA.Shape, ref transformA, (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndCircle:
                    Collision.Collision.CollideEdgeAndCircle(ref manifold, (EdgeShape) FixtureA.Shape, ref transformA, (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndPolygon:
                    Collision.Collision.CollideEdgeAndPolygon(ref manifold, (EdgeShape) FixtureA.Shape, ref transformA, (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.ChainAndCircle:
                    ChainShape chain = (ChainShape) FixtureA.Shape;
                    chain.GetChildEdge(_edge, ChildIndexA);
                    Collision.Collision.CollideEdgeAndCircle(ref manifold, _edge, ref transformA, (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.ChainAndPolygon:
                    ChainShape loop2 = (ChainShape) FixtureA.Shape;
                    loop2.GetChildEdge(_edge, ChildIndexA);
                    Collision.Collision.CollideEdgeAndPolygon(ref manifold, _edge, ref transformA, (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.Circle:
                    Collision.Collision.CollideCircles(ref manifold, (CircleShape) FixtureA.Shape, ref transformA, (CircleShape) FixtureB.Shape, ref transformB);
                    break;
            }
        }

        /// <summary>
        ///     Creates the contact manager
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        /// <returns>The </returns>
        internal static Contact Create(ContactManager contactManager, Fixture fixtureA, int indexA, Fixture fixtureB, int indexB)
        {
            ShapeType type1 = fixtureA.Shape.ShapeType;
            ShapeType type2 = fixtureB.Shape.ShapeType;

            Debug.Assert((ShapeType.Unknown < type1) && (type1 < ShapeType.TypeCount));
            Debug.Assert((ShapeType.Unknown < type2) && (type2 < ShapeType.TypeCount));

            Contact c = null;
            ContactListHead contactPoolList = contactManager._contactPoolList;
            if (contactPoolList.Next != contactPoolList)
            {
                // get first item in the pool.
                c = contactPoolList.Next;
                // Remove from the pool.
                contactPoolList.Next = c.Next;
                c.Next = null;
            }

            // Edge+Polygon is non-symetrical due to the way Erin handles collision type registration.
            if ((type1 >= type2 || ((type1 == ShapeType.Edge) && (type2 == ShapeType.Polygon))) && !((type2 == ShapeType.Edge) && (type1 == ShapeType.Polygon)))
            {
                if (c == null)
                {
                    c = new Contact(fixtureA, indexA, fixtureB, indexB);
                }
                else
                {
                    c.Reset(fixtureA, indexA, fixtureB, indexB);
                }
            }
            else
            {
                if (c == null)
                {
                    c = new Contact(fixtureB, indexB, fixtureA, indexA);
                }
                else
                {
                    c.Reset(fixtureB, indexB, fixtureA, indexA);
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
            if ((Manifold.PointCount > 0) && (FixtureA.IsSensor == false) && (FixtureB.IsSensor == false))
            {
                FixtureA.Body.Awake = true;
                FixtureB.Body.Awake = true;
            }

            Reset(null, 0, null, 0);
        }

        #region Nested type: ContactType

        /// <summary>
        ///     The contact type enum
        /// </summary>
        private enum ContactType
        {
            /// <summary>
            ///     The not supported contact type
            /// </summary>
            NotSupported,

            /// <summary>
            ///     The polygon contact type
            /// </summary>
            Polygon,

            /// <summary>
            ///     The polygon and circle contact type
            /// </summary>
            PolygonAndCircle,

            /// <summary>
            ///     The circle contact type
            /// </summary>
            Circle,

            /// <summary>
            ///     The edge and polygon contact type
            /// </summary>
            EdgeAndPolygon,

            /// <summary>
            ///     The edge and circle contact type
            /// </summary>
            EdgeAndCircle,

            /// <summary>
            ///     The chain and polygon contact type
            /// </summary>
            ChainAndPolygon,

            /// <summary>
            ///     The chain and circle contact type
            /// </summary>
            ChainAndCircle
        }

        #endregion
    }
}