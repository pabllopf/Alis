// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldXmlSerializer.cs
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
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory.Exceptions;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     The world xml serializer class
    /// </summary>
    internal static class WorldXmlSerializer
    {
        /// <summary>
        ///     The writer
        /// </summary>
        private static XmlWriter _writer;

        /// <summary>
        ///     Serializes the shape using the specified shape
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <exception cref="Exception"></exception>
        private static void SerializeShape(Shape shape)
        {
            _writer.WriteStartElement("Shape");
            _writer.WriteAttributeString("Type", shape.ShapeType.ToString());
            _writer.WriteAttributeString("Density", FloatToString(shape.Density));

            switch (shape.ShapeType)
            {
                case ShapeType.Circle:
                {
                    CircleShape circle = (CircleShape) shape;

                    WriteElement("Radius", circle.Radius);

                    WriteElement("Position", circle.Position);
                }
                    break;
                case ShapeType.Polygon:
                {
                    PolygonShape poly = (PolygonShape) shape;

                    _writer.WriteStartElement("Vertices");
                    foreach (Vector2F v in poly.Vertices)
                        WriteElement("Vertex", v);
                    _writer.WriteEndElement();

                    WriteElement("Centroid", poly.MassData.Centroid);
                }
                    break;
                case ShapeType.Edge:
                {
                    EdgeShape poly = (EdgeShape) shape;
                    WriteElement("Vertex1", poly.Vertex1);
                    WriteElement("Vertex2", poly.Vertex2);
                }
                    break;
                case ShapeType.Chain:
                {
                    ChainShape chain = (ChainShape) shape;

                    _writer.WriteStartElement("Vertices");
                    foreach (Vector2F v in chain.Vertices)
                        WriteElement("Vertex", v);
                    _writer.WriteEndElement();

                    WriteElement("NextVertex", chain.NextVertex);
                    WriteElement("PrevVertex", chain.PrevVertex);
                }
                    break;
                default:
                    throw new GeneralAlisException();
            }

            _writer.WriteEndElement();
        }

        /// <summary>
        ///     Serializes the fixture using the specified fixtures
        /// </summary>
        /// <param name="fixtures">The fixtures</param>
        /// <param name="fixture">The fixture</param>
        private static void SerializeFixture(List<Fixture> fixtures, Fixture fixture)
        {
            _writer.WriteStartElement("Fixture");
            _writer.WriteAttributeString("Id", fixtures.IndexOf(fixture).ToString());

            _writer.WriteStartElement("FilterData");
            _writer.WriteElementString("CategoryBits", ((int) fixture.CollisionCategories).ToString());
            _writer.WriteElementString("MaskBits", ((int) fixture.CollidesWith).ToString());
            _writer.WriteElementString("GroupIndex", fixture.CollisionGroup.ToString());
            _writer.WriteEndElement();

            WriteElement("Friction", fixture.Friction);
            _writer.WriteElementString("IsSensor", fixture.IsSensor.ToString());
            WriteElement("Restitution", fixture.Restitution);

            if (fixture.Tag != null)
            {
                _writer.WriteStartElement("Tag");
                WriteDynamicType(fixture.Tag.GetType(), fixture.Tag);
                _writer.WriteEndElement();
            }

            _writer.WriteEndElement();
        }

        /// <summary>
        ///     Serializes the body using the specified fixtures
        /// </summary>
        /// <param name="fixtures">The fixtures</param>
        /// <param name="shapes">The shapes</param>
        /// <param name="body">The body</param>
        private static void SerializeBody(List<Fixture> fixtures, List<Shape> shapes, Body body)
        {
            _writer.WriteStartElement("Body");
            _writer.WriteAttributeString("Type", body.BodyType.ToString());
            _writer.WriteElementString("Active", body.Enabled.ToString());
            _writer.WriteElementString("AllowSleep", body.SleepingAllowed.ToString());
            WriteElement("Angle", body.Rotation);
            WriteElement("AngularDamping", body.AngularDamping);
            WriteElement("AngularVelocity", body.AngularVelocity);
            _writer.WriteElementString("Awake", body.Awake.ToString());
            _writer.WriteElementString("Bullet", body.IsBullet.ToString());
            _writer.WriteElementString("FixedRotation", body.FixedRotation.ToString());
            WriteElement("LinearDamping", body.LinearDamping);
            WriteElement("LinearVelocity", body.LinearVelocity);
            WriteElement("Position", body.Position);

            if (body.Tag != null)
            {
                _writer.WriteStartElement("Tag");
                WriteDynamicType(body.Tag.GetType(), body.Tag);
                _writer.WriteEndElement();
            }

            _writer.WriteStartElement("Bindings");
            for (int i = 0; i < body.FixtureList._list.Count; i++)
            {
                _writer.WriteStartElement("Pair");
                _writer.WriteAttributeString("FixtureId", fixtures.IndexOf(body.FixtureList._list[i]).ToString());
                _writer.WriteAttributeString("ShapeId", shapes.IndexOf(body.FixtureList._list[i].Shape).ToString());
                _writer.WriteEndElement();
            }

            _writer.WriteEndElement();
            _writer.WriteEndElement();
        }

        /// <summary>
        ///     Serializes the joint using the specified bodies
        /// </summary>
        /// <param name="bodies">The bodies</param>
        /// <param name="joint">The joint</param>
        /// <exception cref="Exception">Gear joint not supported by serialization</exception>
        /// <exception cref="Exception">Joint not supported</exception>
        private static void SerializeJoint(List<Body> bodies, Joint joint)
        {
            _writer.WriteStartElement("Joint");
            _writer.WriteAttributeString("Type", joint.JointType.ToString());

            WriteElement("BodyA", bodies.IndexOf(joint.BodyA));
            WriteElement("BodyB", bodies.IndexOf(joint.BodyB));

            WriteElement("CollideConnected", joint.CollideConnected);

            WriteElement("Breakpoint", joint.Breakpoint);

            if (joint.Tag != null)
            {
                _writer.WriteStartElement("Tag");
                WriteDynamicType(joint.Tag.GetType(), joint.Tag);
                _writer.WriteEndElement();
            }

            switch (joint.JointType)
            {
                case JointType.Distance:
                {
                    DistanceJoint distanceJoint = (DistanceJoint) joint;
                    WriteElement("DampingRatio", distanceJoint.DampingRatio);
                    WriteElement("FrequencyHz", distanceJoint.Frequency);
                    WriteElement("Length", distanceJoint.Length);
                    WriteElement("LocalAnchorA", distanceJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", distanceJoint.LocalAnchorB);
                }
                    break;
                case JointType.Friction:
                {
                    FrictionJoint frictionJoint = (FrictionJoint) joint;
                    WriteElement("LocalAnchorA", frictionJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", frictionJoint.LocalAnchorB);
                    WriteElement("MaxForce", frictionJoint.MaxForce);
                    WriteElement("MaxTorque", frictionJoint.MaxTorque);
                }
                    break;
                case JointType.Gear:
                    throw new GeneralAlisException("Gear joint not supported by serialization");
                case JointType.Wheel:
                {
                    WheelJoint wheelJoint = (WheelJoint) joint;
                    WriteElement("EnableMotor", wheelJoint.MotorEnabled);
                    WriteElement("LocalAnchorA", wheelJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", wheelJoint.LocalAnchorB);
                    WriteElement("MotorSpeed", wheelJoint.MotorSpeed);
                    WriteElement("DampingRatio", wheelJoint.DampingRatio);
                    WriteElement("MaxMotorTorque", wheelJoint.MaxMotorTorque);
                    WriteElement("FrequencyHz", wheelJoint.Frequency);
                    WriteElement("Axis", wheelJoint.Axis);
                }
                    break;
                case JointType.Prismatic:
                {
                    //NOTE: Does not conform with Box2DScene

                    PrismaticJoint prismaticJoint = (PrismaticJoint) joint;
                    WriteElement("EnableLimit", prismaticJoint.LimitEnabled);
                    WriteElement("EnableMotor", prismaticJoint.MotorEnabled);
                    WriteElement("LocalAnchorA", prismaticJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", prismaticJoint.LocalAnchorB);
                    WriteElement("Axis", prismaticJoint.Axis1);
                    WriteElement("LowerTranslation", prismaticJoint.LowerLimit);
                    WriteElement("UpperTranslation", prismaticJoint.UpperLimit);
                    WriteElement("MaxMotorForce", prismaticJoint.MaxMotorForce);
                    WriteElement("MotorSpeed", prismaticJoint.MotorSpeed);
                }
                    break;
                case JointType.Pulley:
                {
                    PulleyJoint pulleyJoint = (PulleyJoint) joint;
                    WriteElement("WorldAnchorA", pulleyJoint.WorldAnchorA);
                    WriteElement("WorldAnchorB", pulleyJoint.WorldAnchorB);
                    WriteElement("LengthA", pulleyJoint.LengthA);
                    WriteElement("LengthB", pulleyJoint.LengthB);
                    WriteElement("LocalAnchorA", pulleyJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", pulleyJoint.LocalAnchorB);
                    WriteElement("Ratio", pulleyJoint.Ratio);
                    WriteElement("Constant", pulleyJoint.Constant);
                }
                    break;
                case JointType.Revolute:
                {
                    RevoluteJoint revoluteJoint = (RevoluteJoint) joint;
                    WriteElement("EnableLimit", revoluteJoint.LimitEnabled);
                    WriteElement("EnableMotor", revoluteJoint.MotorEnabled);
                    WriteElement("LocalAnchorA", revoluteJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", revoluteJoint.LocalAnchorB);
                    WriteElement("LowerAngle", revoluteJoint.LowerLimit);
                    WriteElement("MaxMotorTorque", revoluteJoint.MaxMotorTorque);
                    WriteElement("MotorSpeed", revoluteJoint.MotorSpeed);
                    WriteElement("ReferenceAngle", revoluteJoint.ReferenceAngle);
                    WriteElement("UpperAngle", revoluteJoint.UpperLimit);
                }
                    break;
                case JointType.Weld:
                {
                    WeldJoint weldJoint = (WeldJoint) joint;
                    WriteElement("LocalAnchorA", weldJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", weldJoint.LocalAnchorB);
                }
                    break;
                //
                // Not part of Box2DScene
                //
                case JointType.Rope:
                {
                    RopeJoint ropeJoint = (RopeJoint) joint;
                    WriteElement("LocalAnchorA", ropeJoint.LocalAnchorA);
                    WriteElement("LocalAnchorB", ropeJoint.LocalAnchorB);
                    WriteElement("MaxLength", ropeJoint.MaxLength);
                }
                    break;
                case JointType.Angle:
                {
                    AngleJoint angleJoint = (AngleJoint) joint;
                    WriteElement("BiasFactor", angleJoint.BiasFactor);
                    WriteElement("MaxImpulse", angleJoint.MaxImpulse);
                    WriteElement("Softness", angleJoint.Softness);
                    WriteElement("TargetAngle", angleJoint.TargetAngle);
                }
                    break;
                case JointType.Motor:
                {
                    MotorJoint motorJoint = (MotorJoint) joint;
                    WriteElement("AngularOffset", motorJoint.AngularOffset);
                    WriteElement("LinearOffset", motorJoint.LinearOffset);
                    WriteElement("MaxForce", motorJoint.MaxForce);
                    WriteElement("MaxTorque", motorJoint.MaxTorque);
                    WriteElement("CorrectionFactor", motorJoint.CorrectionFactor);
                }
                    break;
                default:
                    throw new GeneralAlisException("Joint not supported");
            }

            _writer.WriteEndElement();
        }

        /// <summary>
        ///     Writes the dynamic type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="val">The val</param>
        private static void WriteDynamicType(Type type, object val)
        {
            _writer.WriteElementString("Type", type.AssemblyQualifiedName);

            _writer.WriteStartElement("Value");
            XmlSerializer serializer = new XmlSerializer(type);
            serializer.Serialize(_writer, val);
            _writer.WriteEndElement();
        }

        /// <summary>
        ///     Writes the element using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="vec">The vec</param>
        private static void WriteElement(string name, Vector2F vec)
        {
            _writer.WriteElementString(name, FloatToString(vec.X) + " " + FloatToString(vec.Y));
        }

        /// <summary>
        ///     Writes the element using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="val">The val</param>
        private static void WriteElement(string name, int val)
        {
            _writer.WriteElementString(name, val.ToString());
        }

        /// <summary>
        ///     Writes the element using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="val">The val</param>
        private static void WriteElement(string name, bool val)
        {
            _writer.WriteElementString(name, val.ToString());
        }

        /// <summary>
        ///     Writes the element using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="val">The val</param>
        private static void WriteElement(string name, float val)
        {
            _writer.WriteElementString(name, FloatToString(val));
        }

        /// <summary>
        ///     Floats the to string using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The string</returns>
        private static string FloatToString(float value) => value.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        ///     Serializes the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="stream">The stream</param>
        internal static void Serialize(World world, Stream stream)
        {
            List<Body> bodies = new List<Body>();
            List<Fixture> fixtures = new List<Fixture>();
            List<Shape> shapes = new List<Shape>();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = false;
            settings.OmitXmlDeclaration = true;

            _writer = XmlWriter.Create(stream, settings);

            _writer.WriteStartElement("World");
            _writer.WriteAttributeString("Version", "3");
            WriteElement("Gravity", world.Gravity);

            _writer.WriteStartElement("Shapes");

            foreach (Body body in world.BodyList)
            {
                foreach (Fixture fixture in body.FixtureList)
                {
                    if (!shapes.Contains(fixture.Shape))
                    {
                        shapes.Add(fixture.Shape);
                        SerializeShape(fixture.Shape);
                    }
                }
            }

            _writer.WriteEndElement();
            _writer.WriteStartElement("Fixtures");

            foreach (Body body in world.BodyList)
            {
                foreach (Fixture fixture in body.FixtureList)
                {
                    if (!fixtures.Contains(fixture))
                    {
                        fixtures.Add(fixture);
                        SerializeFixture(fixtures, fixture);
                    }
                }
            }

            _writer.WriteEndElement();
            _writer.WriteStartElement("Bodies");

            foreach (Body body in world.BodyList)
            {
                bodies.Add(body);
                SerializeBody(fixtures, shapes, body);
            }

            _writer.WriteEndElement();
            _writer.WriteStartElement("Joints");

            foreach (Joint joint in world.JointList)
            {
                SerializeJoint(bodies, joint);
            }

            _writer.WriteEndElement();
            _writer.WriteEndElement();

            _writer.Flush();
        }
    }
}