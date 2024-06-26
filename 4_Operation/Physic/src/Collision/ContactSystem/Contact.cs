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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collision.ContactSystem
{
    /// <summary>
    ///     The class manages contact between two shapes. A contact exists for each overlapping AABB in the broad-phase
    ///     (except if filtered). Therefore a contact object may exist that has no contact points.
    /// </summary>
    public class Contact
    {
        /// <summary>
        ///     The edge shape
        /// </summary>
        internal static readonly EdgeShape Edge = new EdgeShape();
        
        /// <summary>
        ///     The not supported
        /// </summary>
        internal static readonly ContactType[,] Registers =
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
                
                
                ContactType.EdgeAndPolygon,
                ContactType.NotSupported
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
                
                
                ContactType.ChainAndPolygon,
                ContactType.NotSupported
            }
        };
        
        /// <summary>
        ///     The manifold
        /// </summary>
        internal Manifold manifold = new Manifold()
        {
            Points = new ManifoldPoint[2]
        };
        
        // World pool and list pointers.
        
        /// <summary>
        ///     The type
        /// </summary>
        internal ContactType type;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Contact" /> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        internal Contact(Fixture fA, int indexA, Fixture fB, int indexB)
        {
            Reset(fA, indexA, fB, indexB);
        }
        
        /// <summary>
        ///     The flags
        /// </summary>
        internal ContactSetting Flags { get; set; }
        
        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge NodeA { get; } = new ContactEdge();
        
        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge NodeB { get; } = new ContactEdge();
        
        /// <summary>
        ///     The toi
        /// </summary>
        internal float Toi { get; set; }
        
        /// <summary>
        ///     The toi count
        /// </summary>
        internal int ToiCount { get; set; }
        
        /// <summary>Get the contact manifold. Do not modify the manifold unless you understand the internals of Box2D.</summary>
        public Manifold Manifold
        {
            get => manifold;
            set => manifold = value;
        }
        
        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        public float Friction { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        public float Restitution { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the restitution threshold
        /// </summary>
        public float RestitutionThreshold { get; set; }
        
        /// <summary>Get or set the desired tangent speed for a conveyor belt behavior. In meters per second.</summary>
        [ExcludeFromCodeCoverage]
        public float TangentSpeed { get; set; }
        
        /// <summary>
        ///     Gets the value of the fixture a
        /// </summary>
        public Fixture FixtureA { get; set; }
        
        /// <summary>
        ///     Gets the value of the fixture b
        /// </summary>
        public Fixture FixtureB { get; set; }
        
        /// <summary>Get the child primitive index for fixture A.</summary>
        /// <value>The child index A.</value>
        public int ChildIndexA { get; set; }
        
        /// <summary>Get the child primitive index for fixture B.</summary>
        /// <value>The child index B.</value>
        public int ChildIndexB { get; set; }
        
        /// <summary>
        ///     Enable/disable this contact.The contact is only disabled for the current time step (or sub-step in continuous
        ///     collisions).
        /// </summary>
        [ExcludeFromCodeCoverage]
        public bool Enabled
        {
            get => (Flags & ContactSetting.EnabledFlag) == ContactSetting.EnabledFlag;
            set
            {
                if (value)
                {
                    Flags |= ContactSetting.EnabledFlag;
                }
                else
                {
                    Flags &= ~ContactSetting.EnabledFlag;
                }
            }
        }
        
        /// <summary>
        ///     Gets the value of the next
        /// </summary>
        public Contact Next { get; set; }
        
        /// <summary>
        ///     Gets the value of the previous
        /// </summary>
        public Contact Previous { get; set; }
        
        /// <summary>
        ///     Gets the value of the is touching
        /// </summary>
        internal bool IsTouching => (Flags & ContactSetting.TouchingFlag) == ContactSetting.TouchingFlag;
        
        /// <summary>
        ///     Gets the value of the island flag
        /// </summary>
        internal bool IslandFlag => (Flags & ContactSetting.IslandFlag) == ContactSetting.IslandFlag;
        
        /// <summary>
        ///     Gets the value of the toi flag
        /// </summary>
        internal bool ToiFlag => (Flags & ContactSetting.ToiFlag) == ContactSetting.ToiFlag;
        
        /// <summary>
        ///     Gets the value of the filter flag
        /// </summary>
        internal bool FilterFlag => (Flags & ContactSetting.FilterFlag) == ContactSetting.FilterFlag;
        
        /// <summary>
        ///     Resets the restitution
        /// </summary>
        public void ResetRestitution()
        {
            Restitution = Settings.MixRestitution(FixtureA.Restitution, FixtureB.Restitution);
        }
        
        /// <summary>
        ///     Resets the restitution threshold
        /// </summary>
        public void ResetRestitutionThreshold()
        {
            RestitutionThreshold = Settings.MixRestitutionThreshold(FixtureA.Restitution, FixtureB.Restitution);
        }
        
        /// <summary>
        ///     Resets the friction
        /// </summary>
        public void ResetFriction()
        {
            Friction = Settings.MixFriction(FixtureA.Friction, FixtureB.Friction);
        }
        
        /// <summary>Gets the world manifold.</summary>
        [ExcludeFromCodeCoverage]
        public void GetWorldManifold(out Vector2 normal, out Vector2[] points)
        {
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;
            AShape shapeA = FixtureA.Shape;
            AShape shapeB = FixtureB.Shape;
            
            WorldManifold.Initialize(ref manifold, ref bodyA.Xf, shapeA.RadiusPrivate, ref bodyB.Xf,
                shapeB.RadiusPrivate,
                out normal, out points);
        }
        
        /// <summary>
        ///     Resets the f a
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        internal void Reset(Fixture fA, int indexA, Fixture fB, int indexB)
        {
            Flags = ContactSetting.EnabledFlag;
            
            FixtureA = fA;
            FixtureB = fB;
            
            ChildIndexA = indexA;
            ChildIndexB = indexB;
            
            manifold.PointCount = 0;
            
            Previous = null;
            Next = null;
            
            NodeA.Contact = null;
            NodeA.Prev = null;
            NodeA.Next = null;
            NodeA.Other = null;
            
            NodeB.Contact = null;
            NodeB.Prev = null;
            NodeB.Next = null;
            NodeB.Other = null;
            
            ToiCount = 0;
            
            if ((FixtureA != null) && (FixtureB != null))
            {
                Friction = Settings.MixFriction(FixtureA.Friction, FixtureB.Friction);
                Restitution = Settings.MixRestitution(FixtureA.Restitution, FixtureB.Restitution);
                RestitutionThreshold =
                    Settings.MixRestitutionThreshold(FixtureA.RestitutionThreshold,
                        FixtureB.RestitutionThreshold);
            }
            
            TangentSpeed = 0;
        }
        
        /// <summary>
        ///     Updates the contact manager
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        [ExcludeFromCodeCoverage]
        internal void Update(ContactManager contactManager)
        {
            if (FixtureA == null || FixtureB == null)
            {
                return;
            }
            
            Manifold oldManifold = Manifold;
            
            Flags |= ContactSetting.EnabledFlag;
            
            bool wasTouching = IsTouching;
            
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;
            
            Transform xfA = bodyA.Xf;
            Transform xfB = bodyB.Xf;
            
            bool sensor = IsSensorContact();
            
            bool touching = sensor ? CheckSensorOverlap(ref xfA, ref xfB) : EvaluateAndCheckManifold(ref xfA, ref xfB, oldManifold);
            
            UpdateTouchingFlag(touching);
            
            if (touching)
            {
                InvokeCollisionEvents(contactManager, wasTouching);
            }
            
            if (wasTouching && !touching)
            {
                InvokeSeparationEvents(contactManager);
            }
            
            if (!sensor && touching)
            {
                contactManager.PreSolve?.Invoke(this, ref oldManifold);
            }
        }
        
        /// <summary>
        ///     Describes whether this instance is sensor contact
        /// </summary>
        /// <returns>The bool</returns>
        internal bool IsSensorContact() => FixtureA.IsSensor || FixtureB.IsSensor;
        
        /// <summary>
        ///     Describes whether this instance check sensor overlap
        /// </summary>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        /// <returns>The touching</returns>
        [ExcludeFromCodeCoverage]
        internal bool CheckSensorOverlap(ref Transform xfA, ref Transform xfB)
        {
            AShape shapeA = FixtureA.Shape;
            AShape shapeB = FixtureB.Shape;
            bool touching = NarrowPhase.Collision.TestOverlap(shapeA, ChildIndexA, shapeB, ChildIndexB, ref xfA, ref xfB);
            
            manifold.PointCount = 0;
            
            return touching;
        }
        
        /// <summary>
        ///     Describes whether this instance evaluate and check manifold
        /// </summary>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        /// <param name="oldManifold">The old manifold</param>
        /// <returns>The touching</returns>
        [ExcludeFromCodeCoverage]
        internal bool EvaluateAndCheckManifold(ref Transform xfA, ref Transform xfB, Manifold oldManifold)
        {
            Evaluate(ref manifold, ref xfA, ref xfB);
            bool touching = Manifold.PointCount > 0;
            
            for (int i = 0; i < Manifold.PointCount; ++i)
            {
                ManifoldPoint mp2 = Manifold.Points[i];
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
                
                manifold.Points[i] = mp2;
            }
            
            return touching;
        }
        
        /// <summary>
        ///     Updates the touching flag using the specified touching
        /// </summary>
        /// <param name="touching">The touching</param>
        [ExcludeFromCodeCoverage]
        internal void UpdateTouchingFlag(bool touching)
        {
            if (touching)
            {
                Flags |= ContactSetting.TouchingFlag;
            }
            else
            {
                Flags &= ~ContactSetting.TouchingFlag;
            }
        }
        
        /// <summary>
        ///     Invokes the collision events using the specified contact manager
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="wasTouching">The was touching</param>
        [ExcludeFromCodeCoverage]
        internal void InvokeCollisionEvents(ContactManager contactManager, bool wasTouching)
        {
            if (!wasTouching)
            {
                FixtureA.OnCollision?.Invoke(FixtureA, FixtureB, this);
                FixtureB.OnCollision?.Invoke(FixtureB, FixtureA, this);
                
                FixtureA.Body.OnCollision?.Invoke(FixtureA, FixtureB, this);
                FixtureB.Body.OnCollision?.Invoke(FixtureB, FixtureA, this);
                
                contactManager.BeginContact?.Invoke(this);
            }
        }
        
        /// <summary>
        ///     Invokes the separation events using the specified contact manager
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        [ExcludeFromCodeCoverage]
        internal void InvokeSeparationEvents(ContactManager contactManager)
        {
            FixtureA.OnSeparation?.Invoke(FixtureA, FixtureB, this);
            FixtureB.OnSeparation?.Invoke(FixtureB, FixtureA, this);
            
            FixtureA.Body.OnSeparation?.Invoke(FixtureA, FixtureB, this);
            FixtureB.Body.OnSeparation?.Invoke(FixtureB, FixtureA, this);
            
            contactManager.EndContact?.Invoke(this);
        }
        
        /// <summary>Evaluate this contact with your own manifold and transforms.</summary>
        /// <param name="maniFold">The manifold.</param>
        /// <param name="transformA">The first transform.</param>
        /// <param name="transformB">The second transform.</param>
        [ExcludeFromCodeCoverage]
        internal void Evaluate(ref Manifold maniFold, ref Transform transformA, ref Transform transformB)
        {
            switch (type)
            {
                case ContactType.Polygon:
                    CollidePolygon.CollidePolygons(ref maniFold, (PolygonShape) FixtureA.Shape, ref transformA,
                        (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.PolygonAndCircle:
                    CollideCircle.CollidePolygonAndCircle(ref maniFold, (PolygonShape) FixtureA.Shape, ref transformA,
                        (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndCircle:
                    CollideEdge.CollideEdgeAndCircle(ref maniFold, (EdgeShape) FixtureA.Shape, ref transformA,
                        (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndPolygon:
                    CollideEdge.CollideEdgeAndPolygon(ref maniFold, (EdgeShape) FixtureA.Shape, ref transformA,
                        (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.ChainAndCircle:
                    ChainShape chain = (ChainShape) FixtureA.Shape;
                    chain.GetChildEdge(Edge, ChildIndexA);
                    CollideEdge.CollideEdgeAndCircle(ref maniFold, Edge, ref transformA, (CircleShape) FixtureB.Shape,
                        ref transformB);
                    break;
                case ContactType.ChainAndPolygon:
                    ChainShape loop2 = (ChainShape) FixtureA.Shape;
                    loop2.GetChildEdge(Edge, ChildIndexA);
                    CollideEdge.CollideEdgeAndPolygon(ref maniFold, Edge, ref transformA,
                        (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.Circle:
                    CollideCircle.CollideCircles(ref maniFold, (CircleShape) FixtureA.Shape, ref transformA,
                        (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.NotSupported:
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
            
            Contact c = GetContactFromPoolOrNew(type1, type2, fixtureA, indexA, fixtureB, indexB);
            c.type = Registers[(int) type1, (int) type2];
            
            return c;
        }
        
        /// <summary>
        ///     Gets the contact from pool or new using the specified type 1
        /// </summary>
        /// <param name="type1">The type</param>
        /// <param name="type2">The type</param>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        /// <returns>The contact</returns>
        internal static Contact GetContactFromPoolOrNew(ShapeType type1, ShapeType type2, Fixture fixtureA, int indexA, Fixture fixtureB, int indexB)
        {
            Queue<Contact> pool = ContactManager.Current.ContactPool;
            if (pool.Count > 0)
            {
                return GetContactFromPool(type1, type2, fixtureA, indexA, fixtureB, indexB, pool);
            }
            
            return GetNewContact(type1, type2, fixtureA, indexA, fixtureB, indexB);
        }
        
        /// <summary>
        ///     Gets the contact from pool using the specified type 1
        /// </summary>
        /// <param name="type1">The type</param>
        /// <param name="type2">The type</param>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        /// <param name="pool">The pool</param>
        /// <returns>The </returns>
        [ExcludeFromCodeCoverage]
        internal static Contact GetContactFromPool(ShapeType type1, ShapeType type2, Fixture fixtureA, int indexA, Fixture fixtureB, int indexB, Queue<Contact> pool)
        {
            Contact c = pool.Dequeue();
            if (ShouldResetWithOriginalOrder(type1, type2))
            {
                c.Reset(fixtureA, indexA, fixtureB, indexB);
            }
            else
            {
                c.Reset(fixtureB, indexB, fixtureA, indexA);
            }
            
            return c;
        }
        
        /// <summary>
        ///     Gets the new contact using the specified type 1
        /// </summary>
        /// <param name="type1">The type</param>
        /// <param name="type2">The type</param>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        /// <returns>The </returns>
        [ExcludeFromCodeCoverage]
        internal static Contact GetNewContact(ShapeType type1, ShapeType type2, Fixture fixtureA, int indexA, Fixture fixtureB, int indexB)
        {
            Contact c;
            if (ShouldResetWithOriginalOrder(type1, type2))
            {
                c = new Contact(fixtureA, indexA, fixtureB, indexB);
            }
            else
            {
                c = new Contact(fixtureB, indexB, fixtureA, indexA);
            }
            
            return c;
        }
        
        /// <summary>
        ///     Describes whether should reset with original order
        /// </summary>
        /// <param name="type1">The type</param>
        /// <param name="type2">The type</param>
        /// <returns>The bool</returns>
        internal static bool ShouldResetWithOriginalOrder(ShapeType type1, ShapeType type2) => (type1 >= type2 || ((type1 == ShapeType.Edge) && (type2 == ShapeType.Polygon))) &&
                                                                                              !((type2 == ShapeType.Edge) && (type1 == ShapeType.Polygon));
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        internal void Destroy()
        {
            if ((Manifold.PointCount > 0) && !FixtureA.IsSensor && !FixtureB.IsSensor)
            {
                FixtureA.Body.Awake = true;
                FixtureB.Body.Awake = true;
            }
            
            ContactManager.Current.ContactPool.Enqueue(this);
            
            Reset(null, 0, null, 0);
        }
        
        /// <summary>
        ///     Clears the flags
        /// </summary>
        public void ClearFlags() => Flags &= ~ContactSetting.FilterFlag;
        
        /// <summary>
        ///     Invalidates the toi
        /// </summary>
        public void InvalidateToi()
        {
            Flags &= ~(ContactSetting.ToiFlag | ContactSetting.IslandFlag);
            ToiCount = 0;
            Toi = 1.0f;
        }
    }
}