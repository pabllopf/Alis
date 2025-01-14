// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldXmlDeserializer.cs
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
    ///     The world xml deserializer class
    /// </summary>
    internal static class WorldXmlDeserializer
    {
        /// <summary>
        ///     Deserializes the stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The world</returns>
        internal static World Deserialize(Stream stream)
        {
            World world = new World(Vector2F.Zero);
            Deserialize(world, stream);
            return world;
        }

        /// <summary>
        ///     Deserializes the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="stream">The stream</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception">Gear joint is unsupported</exception>
        /// <exception cref="Exception">GearJoint is not supported.</exception>
        /// <exception cref="Exception">Invalid or unsupported joint.</exception>
        private static void Deserialize(World world, Stream stream)
        {
            List<Body> bodies = new List<Body>();
            List<Fixture> fixtures = new List<Fixture>();

            List<Joint> joints = new List<Joint>();
            List<Shape> shapes = new List<Shape>();

            XMLFragmentElement root = XMLFragmentParser.LoadFromStream(stream);

            if (root.Name.ToLower() != "world")
            {
                throw new GeneralAlisException();
            }

            //Read gravity
            foreach (XMLFragmentElement element in root.Elements)
            {
                if (element.Name.ToLower() == "gravity")
                {
                    world.Gravity = ReadVector(element);
                    break;
                }
            }

            //Read shapes
            foreach (XMLFragmentElement shapeElement in root.Elements)
            {
                if (shapeElement.Name.ToLower() == "shapes")
                {
                    foreach (XMLFragmentElement element in shapeElement.Elements)
                    {
                        if (element.Name.ToLower() != "shape")
                        {
                            throw new GeneralAlisException();
                        }

                        ShapeType type = (ShapeType) Enum.Parse(typeof(ShapeType), element.Attributes[0].Value, true);
                        float density = ParseFloat(element.Attributes[1].Value);

                        switch (type)
                        {
                            case ShapeType.Circle:
                            {
                                CircleShape shape = new CircleShape();
                                shape.Density = density;

                                foreach (XMLFragmentElement sn in element.Elements)
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "radius":
                                            shape.GetRadius = ParseFloat(sn.Value);
                                            break;
                                        case "position":
                                            shape.Position = ReadVector(sn);
                                            break;
                                        default:
                                            throw new GeneralAlisException();
                                    }
                                }

                                shapes.Add(shape);
                            }
                                break;
                            case ShapeType.Polygon:
                            {
                                PolygonShape shape = new PolygonShape();
                                shape.Density = density;

                                foreach (XMLFragmentElement sn in element.Elements)
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "vertices":
                                        {
                                            List<Vector2F> verts = new List<Vector2F>(sn.Elements.Count);

                                            foreach (XMLFragmentElement vert in sn.Elements)
                                            {
                                                verts.Add(ReadVector(vert));
                                            }

                                            shape.Vertices = new Vertices(verts);
                                        }
                                            break;
                                        case "centroid":
                                            shape.MassData.Centroid = ReadVector(sn);
                                            break;
                                    }
                                }

                                shapes.Add(shape);
                            }
                                break;
                            case ShapeType.Edge:
                            {
                                EdgeShape shape = new EdgeShape();
                                shape.Density = density;

                                foreach (XMLFragmentElement sn in element.Elements)
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "hasvertex0":
                                            shape.HasVertex0 = bool.Parse(sn.Value);
                                            break;
                                        case "hasvertex3":
                                            shape.HasVertex0 = bool.Parse(sn.Value);
                                            break;
                                        case "vertex0":
                                            shape.Vertex0 = ReadVector(sn);
                                            break;
                                        case "vertex1":
                                            shape.Vertex1 = ReadVector(sn);
                                            break;
                                        case "vertex2":
                                            shape.Vertex2 = ReadVector(sn);
                                            break;
                                        case "vertex3":
                                            shape.Vertex3 = ReadVector(sn);
                                            break;
                                        default:
                                            throw new GeneralAlisException();
                                    }
                                }

                                shapes.Add(shape);
                            }
                                break;
                            case ShapeType.Chain:
                            {
                                ChainShape shape = new ChainShape();
                                shape.Density = density;

                                foreach (XMLFragmentElement sn in element.Elements)
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "vertices":
                                        {
                                            List<Vector2F> verts = new List<Vector2F>(sn.Elements.Count);

                                            foreach (XMLFragmentElement vert in sn.Elements)
                                            {
                                                verts.Add(ReadVector(vert));
                                            }

                                            shape.Vertices = new Vertices(verts);
                                        }
                                            break;
                                        case "nextvertex":
                                            shape.NextVertex = ReadVector(sn);
                                            break;
                                        case "prevvertex":
                                            shape.PrevVertex = ReadVector(sn);
                                            break;

                                        default:
                                            throw new GeneralAlisException();
                                    }
                                }

                                shapes.Add(shape);
                            }
                                break;
                        }
                    }
                }
            }

            //Read fixtures
            foreach (XMLFragmentElement fixtureElement in root.Elements)
            {
                if (fixtureElement.Name.ToLower() == "fixtures")
                {
                    foreach (XMLFragmentElement element in fixtureElement.Elements)
                    {
                        Fixture fixture = new Fixture();

                        if (element.Name.ToLower() != "fixture")
                        {
                            throw new GeneralAlisException();
                        }

                        int fixtureId = int.Parse(element.Attributes[0].Value);

                        foreach (XMLFragmentElement sn in element.Elements)
                        {
                            switch (sn.Name.ToLower())
                            {
                                case "filterdata":
                                    foreach (XMLFragmentElement ssn in sn.Elements)
                                    {
                                        switch (ssn.Name.ToLower())
                                        {
                                            case "categorybits":
                                                fixture._collisionCategories = (Category) int.Parse(ssn.Value);
                                                break;
                                            case "maskbits":
                                                fixture._collidesWith = (Category) int.Parse(ssn.Value);
                                                break;
                                            case "groupindex":
                                                fixture._collisionGroup = short.Parse(ssn.Value);
                                                break;
                                        }
                                    }

                                    break;
                                case "friction":
                                    fixture.Friction = ParseFloat(sn.Value);
                                    break;
                                case "issensor":
                                    fixture.IsSensor = bool.Parse(sn.Value);
                                    break;
                                case "restitution":
                                    fixture.Restitution = ParseFloat(sn.Value);
                                    break;
                                case "tag":
                                    fixture.Tag = ReadSimpleType(sn, null, false);
                                    break;
                            }
                        }

                        fixtures.Add(fixture);
                    }
                }
            }

            //Read bodies
            Dictionary<Fixture, Fixture> mapFixtureClones = new Dictionary<Fixture, Fixture>();
            foreach (XMLFragmentElement bodyElement in root.Elements)
            {
                if (bodyElement.Name.ToLower() == "bodies")
                {
                    foreach (XMLFragmentElement element in bodyElement.Elements)
                    {
                        Body body = world.CreateBody();

                        if (element.Name.ToLower() != "body")
                        {
                            throw new GeneralAlisException();
                        }

                        body.BodyType = (BodyType) Enum.Parse(typeof(BodyType), element.Attributes[0].Value, true);

                        foreach (XMLFragmentElement sn in element.Elements)
                        {
                            switch (sn.Name.ToLower())
                            {
                                case "active":
                                    body.Enabled = bool.Parse(sn.Value);
                                    break;
                                case "allowsleep":
                                    body.SleepingAllowed = bool.Parse(sn.Value);
                                    break;
                                case "angle":
                                {
                                    Vector2F position = body.Position;
                                    body.SetTransformIgnoreContacts(ref position, ParseFloat(sn.Value));
                                }
                                    break;
                                case "angulardamping":
                                    body.AngularDamping = ParseFloat(sn.Value);
                                    break;
                                case "angularvelocity":
                                    body.AngularVelocity = ParseFloat(sn.Value);
                                    break;
                                case "awake":
                                    body.Awake = bool.Parse(sn.Value);
                                    break;
                                case "bullet":
                                    body.IsBullet = bool.Parse(sn.Value);
                                    break;
                                case "fixedrotation":
                                    body.FixedRotation = bool.Parse(sn.Value);
                                    break;
                                case "lineardamping":
                                    body.LinearDamping = ParseFloat(sn.Value);
                                    break;
                                case "linearvelocity":
                                    body.LinearVelocity = ReadVector(sn);
                                    break;
                                case "position":
                                {
                                    float rotation = body.Rotation;
                                    Vector2F position = ReadVector(sn);
                                    body.SetTransformIgnoreContacts(ref position, rotation);
                                }
                                    break;
                                case "tag":
                                    body.Tag = ReadSimpleType(sn, null, false);
                                    break;
                                case "bindings":
                                {
                                    foreach (XMLFragmentElement pair in sn.Elements)
                                    {
                                        Fixture fix = fixtures[int.Parse(pair.Attributes[0].Value)];
                                        Shape shape = shapes[int.Parse(pair.Attributes[1].Value)].Clone();
                                        Fixture clone = fix.CloneOnto(body, shape);
                                        mapFixtureClones[fix] = clone;
                                    }

                                    break;
                                }
                            }
                        }

                        bodies.Add(body);
                    }
                }
            }

            //Read joints
            foreach (XMLFragmentElement jointElement in root.Elements)
            {
                if (jointElement.Name.ToLower() == "joints")
                {
                    foreach (XMLFragmentElement n in jointElement.Elements)
                    {
                        Joint joint;

                        if (n.Name.ToLower() != "joint")
                        {
                            throw new GeneralAlisException();
                        }

                        JointType type = (JointType) Enum.Parse(typeof(JointType), n.Attributes[0].Value, true);

                        int bodyAIndex = -1, bodyBIndex = -1;
                        bool collideConnected = false;
                        object jointTag = null;

                        foreach (XMLFragmentElement sn in n.Elements)
                        {
                            switch (sn.Name.ToLower())
                            {
                                case "bodya":
                                    bodyAIndex = int.Parse(sn.Value);
                                    break;
                                case "bodyb":
                                    bodyBIndex = int.Parse(sn.Value);
                                    break;
                                case "collideconnected":
                                    collideConnected = bool.Parse(sn.Value);
                                    break;
                                case "tag":
                                    jointTag = ReadSimpleType(sn, null, false);
                                    break;
                            }
                        }

                        Body bodyA = bodies[bodyAIndex];
                        Body bodyB = bodies[bodyBIndex];

                        switch (type)
                        {
                            //case JointType.FixedMouse:
                            //    joint = new FixedMouseJoint();
                            //    break;
                            //case JointType.FixedRevolute:
                            //    break;
                            //case JointType.FixedDistance:
                            //    break;
                            //case JointType.FixedLine:
                            //    break;
                            //case JointType.FixedPrismatic:
                            //    break;
                            //case JointType.FixedAngle:
                            //    break;
                            //case JointType.FixedFriction:
                            //    break;
                            case JointType.Distance:
                                joint = new DistanceJoint();
                                break;
                            case JointType.Friction:
                                joint = new FrictionJoint();
                                break;
                            case JointType.Wheel:
                                joint = new WheelJoint();
                                break;
                            case JointType.Prismatic:
                                joint = new PrismaticJoint();
                                break;
                            case JointType.Pulley:
                                joint = new PulleyJoint();
                                break;
                            case JointType.Revolute:
                                joint = new RevoluteJoint();
                                break;
                            case JointType.Weld:
                                joint = new WeldJoint();
                                break;
                            case JointType.Rope:
                                joint = new RopeJoint();
                                break;
                            case JointType.Angle:
                                joint = new AngleJoint();
                                break;
                            case JointType.Motor:
                                joint = new MotorJoint();
                                break;
                            case JointType.Gear:
                                throw new GeneralAlisException("GearJoint is not supported.");
                            default:
                                throw new GeneralAlisException("Invalid or unsupported joint.");
                        }

                        joint.CollideConnected = collideConnected;
                        joint.Tag = jointTag;
                        joint.BodyA = bodyA;
                        joint.BodyB = bodyB;
                        joints.Add(joint);
                        world.Add(joint);

                        foreach (XMLFragmentElement sn in n.Elements)
                        {
                            // check for specific nodes
                            switch (type)
                            {
                                case JointType.Distance:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "dampingratio":
                                            ((DistanceJoint) joint).DampingRatio = ParseFloat(sn.Value);
                                            break;
                                        case "frequencyhz":
                                            ((DistanceJoint) joint).Frequency = ParseFloat(sn.Value);
                                            break;
                                        case "length":
                                            ((DistanceJoint) joint).Length = ParseFloat(sn.Value);
                                            break;
                                        case "localanchora":
                                            ((DistanceJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((DistanceJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Friction:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "localanchora":
                                            ((FrictionJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((FrictionJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                        case "maxforce":
                                            ((FrictionJoint) joint).MaxForce = ParseFloat(sn.Value);
                                            break;
                                        case "maxtorque":
                                            ((FrictionJoint) joint).MaxTorque = ParseFloat(sn.Value);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Wheel:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "enablemotor":
                                            ((WheelJoint) joint).MotorEnabled = bool.Parse(sn.Value);
                                            break;
                                        case "localanchora":
                                            ((WheelJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((WheelJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                        case "motorspeed":
                                            ((WheelJoint) joint).MotorSpeed = ParseFloat(sn.Value);
                                            break;
                                        case "dampingratio":
                                            ((WheelJoint) joint).DampingRatio = ParseFloat(sn.Value);
                                            break;
                                        case "maxmotortorque":
                                            ((WheelJoint) joint).MaxMotorTorque = ParseFloat(sn.Value);
                                            break;
                                        case "frequencyhz":
                                            ((WheelJoint) joint).Frequency = ParseFloat(sn.Value);
                                            break;
                                        case "axis":
                                            ((WheelJoint) joint).Axis = ReadVector(sn);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Prismatic:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "enablelimit":
                                            ((PrismaticJoint) joint).LimitEnabled = bool.Parse(sn.Value);
                                            break;
                                        case "enablemotor":
                                            ((PrismaticJoint) joint).MotorEnabled = bool.Parse(sn.Value);
                                            break;
                                        case "localanchora":
                                            ((PrismaticJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((PrismaticJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                        case "axis":
                                            ((PrismaticJoint) joint).Axis1 = ReadVector(sn);
                                            break;
                                        case "maxmotorforce":
                                            ((PrismaticJoint) joint).MaxMotorForce = ParseFloat(sn.Value);
                                            break;
                                        case "motorspeed":
                                            ((PrismaticJoint) joint).MotorSpeed = ParseFloat(sn.Value);
                                            break;
                                        case "lowertranslation":
                                            ((PrismaticJoint) joint).LowerLimit = ParseFloat(sn.Value);
                                            break;
                                        case "uppertranslation":
                                            ((PrismaticJoint) joint).UpperLimit = ParseFloat(sn.Value);
                                            break;
                                        case "referenceangle":
                                            ((PrismaticJoint) joint).ReferenceAngle = ParseFloat(sn.Value);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Pulley:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "worldanchora":
                                            ((PulleyJoint) joint).WorldAnchorA = ReadVector(sn);
                                            break;
                                        case "worldanchorb":
                                            ((PulleyJoint) joint).WorldAnchorB = ReadVector(sn);
                                            break;
                                        case "lengtha":
                                            ((PulleyJoint) joint).LengthA = ParseFloat(sn.Value);
                                            break;
                                        case "lengthb":
                                            ((PulleyJoint) joint).LengthB = ParseFloat(sn.Value);
                                            break;
                                        case "localanchora":
                                            ((PulleyJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((PulleyJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                        case "ratio":
                                            ((PulleyJoint) joint).Ratio = ParseFloat(sn.Value);
                                            break;
                                        case "constant":
                                            ((PulleyJoint) joint).Constant = ParseFloat(sn.Value);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Revolute:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "enablelimit":
                                            ((RevoluteJoint) joint).LimitEnabled = bool.Parse(sn.Value);
                                            break;
                                        case "enablemotor":
                                            ((RevoluteJoint) joint).MotorEnabled = bool.Parse(sn.Value);
                                            break;
                                        case "localanchora":
                                            ((RevoluteJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((RevoluteJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                        case "maxmotortorque":
                                            ((RevoluteJoint) joint).MaxMotorTorque = ParseFloat(sn.Value);
                                            break;
                                        case "motorspeed":
                                            ((RevoluteJoint) joint).MotorSpeed = ParseFloat(sn.Value);
                                            break;
                                        case "lowerangle":
                                            ((RevoluteJoint) joint).LowerLimit = ParseFloat(sn.Value);
                                            break;
                                        case "upperangle":
                                            ((RevoluteJoint) joint).UpperLimit = ParseFloat(sn.Value);
                                            break;
                                        case "referenceangle":
                                            ((RevoluteJoint) joint).ReferenceAngle = ParseFloat(sn.Value);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Weld:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "localanchora":
                                            ((WeldJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((WeldJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Rope:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "localanchora":
                                            ((RopeJoint) joint).LocalAnchorA = ReadVector(sn);
                                            break;
                                        case "localanchorb":
                                            ((RopeJoint) joint).LocalAnchorB = ReadVector(sn);
                                            break;
                                        case "maxlength":
                                            ((RopeJoint) joint).MaxLength = ParseFloat(sn.Value);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Gear:
                                    throw new GeneralAlisException("Gear joint is unsupported");
                                case JointType.Angle:
                                {
                                    switch (sn.Name.ToLower())
                                    {
                                        case "biasfactor":
                                            ((AngleJoint) joint).BiasFactor = ParseFloat(sn.Value);
                                            break;
                                        case "maximpulse":
                                            ((AngleJoint) joint).MaxImpulse = ParseFloat(sn.Value);
                                            break;
                                        case "softness":
                                            ((AngleJoint) joint).Softness = ParseFloat(sn.Value);
                                            break;
                                        case "targetangle":
                                            ((AngleJoint) joint).TargetAngle = ParseFloat(sn.Value);
                                            break;
                                    }
                                }
                                    break;
                                case JointType.Motor:
                                    switch (sn.Name.ToLower())
                                    {
                                        case "angularoffset":
                                            ((MotorJoint) joint).AngularOffset = ParseFloat(sn.Value);
                                            break;
                                        case "linearoffset":
                                            ((MotorJoint) joint).LinearOffset = ReadVector(sn);
                                            break;
                                        case "maxforce":
                                            ((MotorJoint) joint).MaxForce = ParseFloat(sn.Value);
                                            break;
                                        case "maxtorque":
                                            ((MotorJoint) joint).MaxTorque = ParseFloat(sn.Value);
                                            break;
                                        case "correctionfactor":
                                            ((MotorJoint) joint).CorrectionFactor = ParseFloat(sn.Value);
                                            break;
                                    }

                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Reads the vector using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>The vector</returns>
        private static Vector2F ReadVector(XMLFragmentElement node)
        {
            string[] values = node.Value.Split(' ');
            return new Vector2F(ParseFloat(values[0]), ParseFloat(values[1]));
        }

        /// <summary>
        ///     Reads the simple type using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        /// <param name="type">The type</param>
        /// <param name="outer">The outer</param>
        /// <returns>The object</returns>
        private static object ReadSimpleType(XMLFragmentElement node, Type type, bool outer)
        {
            if (type == null)
            {
                return ReadSimpleType(node.Elements[1], Type.GetType(node.Elements[0].Value), outer);
            }

            XmlSerializer serializer = new XmlSerializer(type);

            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                {
                    writer.Write(outer ? node.OuterXml : node.InnerXml);
                    writer.Flush();
                    stream.Position = 0;
                }
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;

                return serializer.Deserialize(XmlReader.Create(stream, settings));
            }
        }

        /// <summary>
        ///     Parses the float using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        private static float ParseFloat(string value) => float.Parse(value, CultureInfo.InvariantCulture);
    }
}