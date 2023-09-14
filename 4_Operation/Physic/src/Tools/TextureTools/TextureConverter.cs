// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureConverter.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Tools.TextureTools
{
    /// <summary>
    ///     The texture converter class
    /// </summary>
    public sealed class TextureConverter
    {
        /// <summary>
        ///     The close pixels length
        /// </summary>
        private const int ClosePixelsLength = 8;

        /// <summary>This array is meant to be read-only. It's not because it is accessed very frequently.</summary>
        private static readonly int[,] ClosePixels =
            {{-1, -1}, {0, -1}, {1, -1}, {1, 0}, {1, 1}, {0, 1}, {-1, 1}, {-1, 0}};

        /// <summary>
        ///     The alpha tolerance
        /// </summary>
        private uint alphaTolerance;

        /// <summary>
        ///     The data
        /// </summary>
        private uint[] data;

        /// <summary>
        ///     The data length
        /// </summary>
        private int dataLength;

        /// <summary>
        ///     The height
        /// </summary>
        private int height;

        /// <summary>
        ///     The hole detection
        /// </summary>
        private bool holeDetection;

        /// <summary>
        ///     The hull tolerance
        /// </summary>
        private float hullTolerance;

        /// <summary>
        ///     The multipart detection
        /// </summary>
        private bool multipartDetection;

        /// <summary>
        ///     The polygon detection type
        /// </summary>
        private VerticesDetectionType polygonDetectionType;

        /// <summary>
        ///     The temp is solid
        /// </summary>
        private int tempIsSolidX;

        /// <summary>
        ///     The temp is solid
        /// </summary>
        private int tempIsSolidY;

        /// <summary>
        ///     The identity
        /// </summary>
        private Matrix4X4F transform = Matrix4X4F.Identity;

        /// <summary>
        ///     The width
        /// </summary>
        private int width;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextureConverter" /> class
        /// </summary>
        public TextureConverter()
        {
            Initialize(null, null, null, null, null, null, null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextureConverter" /> class
        /// </summary>
        /// <param name="alphaTolerance">The alpha tolerance</param>
        /// <param name="hullTolerance">The hull tolerance</param>
        /// <param name="holeDetection">The hole detection</param>
        /// <param name="multipartDetection">The multipart detection</param>
        /// <param name="transform">The transform</param>
        public TextureConverter(byte? alphaTolerance, float? hullTolerance,
            bool? holeDetection, bool? multipartDetection, Matrix4X4F? transform)
        {
            Initialize(null, null, alphaTolerance, hullTolerance, holeDetection,
                multipartDetection, transform);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextureConverter" /> class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="width">The width</param>
        private TextureConverter(uint[] data, int width)
        {
            Initialize(data, width, null, null, null, null, null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextureConverter" /> class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="width">The width</param>
        /// <param name="alphaTolerance">The alpha tolerance</param>
        /// <param name="hullTolerance">The hull tolerance</param>
        /// <param name="holeDetection">The hole detection</param>
        /// <param name="multipartDetection">The multipart detection</param>
        /// <param name="transform">The transform</param>
        public TextureConverter(uint[] data, int width, byte? alphaTolerance,
            float? hullTolerance, bool? holeDetection, bool? multipartDetection, Matrix4X4F? transform)
        {
            Initialize(data, width, alphaTolerance, hullTolerance, holeDetection,
                multipartDetection, transform);
        }

        /// <summary>Get or set the polygon detection type.</summary>
        public VerticesDetectionType PolygonDetectionType
        {
            get => polygonDetectionType;
            set => polygonDetectionType = value;
        }

        /// <summary>Will detect texture 'holes' if set to true. Slows down the detection. Default is false.</summary>
        public bool HoleDetection
        {
            get => holeDetection;
            set => holeDetection = value;
        }

        /// <summary>Will detect texture multiple 'solid' isles if set to true. Slows down the detection. Default is false.</summary>
        public bool MultipartDetection
        {
            get => multipartDetection;
            set => multipartDetection = value;
        }

        /// <summary>Can be used for scaling.</summary>
        public Matrix4X4F Transform
        {
            get => transform;
            set => transform = value;
        }

        /// <summary>
        ///     Alpha (coverage) tolerance. Default is 20: Every pixel with a coverage value equal or greater to 20 will be
        ///     counts as solid.
        /// </summary>
        public byte AlphaTolerance
        {
            get => (byte) (alphaTolerance >> 24);
            set => alphaTolerance = (uint) value << 24;
        }

        /// <summary>Default is 1.5f.</summary>
        public float HullTolerance
        {
            get => hullTolerance;
            set
            {
                if (value > 4f)
                {
                    hullTolerance = 4f;
                }
                else if (value < 0.9f)
                {
                    hullTolerance = 0.9f;
                }
                else
                {
                    hullTolerance = value;
                }
            }
        }

        /// <summary>
        ///     Initializes the data
        /// </summary>
        /// <param name="dataLocal">The data</param>
        /// <param name="widthLocal">The width</param>
        /// <param name="alphaToleranceLocal">The alpha tolerance</param>
        /// <param name="hullToleranceLocal">The hull tolerance</param>
        /// <param name="holeDetectionLocal">The hole detection</param>
        /// <param name="multipartDetectionLocal">The multipart detection</param>
        /// <param name="transformLocal">The transform</param>
        /// <exception cref="ArgumentNullException">'data' can't be null if 'width' is set.</exception>
        /// <exception cref="ArgumentNullException">'width' can't be null if 'data' is set.</exception>
        private void Initialize(uint[] dataLocal, int? widthLocal, byte? alphaToleranceLocal, float? hullToleranceLocal, bool? holeDetectionLocal, bool? multipartDetectionLocal, Matrix4X4F? transformLocal)
        {
            if ((dataLocal != null) && !widthLocal.HasValue)
            {
                throw new ArgumentNullException(nameof(widthLocal), "'width' can't be null if 'data' is set.");
            }

            if ((dataLocal == null) && widthLocal.HasValue)
            {
                throw new ArgumentNullException(nameof(dataLocal), "'data' can't be null if 'width' is set.");
            }

            if (dataLocal != null)
            {
                SetTextureData(dataLocal, widthLocal.Value);
            }

            AlphaTolerance = alphaToleranceLocal ?? 20;

            HullTolerance = hullToleranceLocal ?? 1.5f;

            HoleDetection = holeDetectionLocal.HasValue && holeDetectionLocal.Value;

            MultipartDetection = multipartDetectionLocal.HasValue && multipartDetectionLocal.Value;

            Transform = transformLocal ?? Matrix4X4F.Identity;
        }

        /// <summary>
        ///     Sets the texture data using the specified data
        /// </summary>
        /// <param name="dataLocal">The data</param>
        /// <param name="widthLocal">The width</param>
        /// <exception cref="ArgumentNullException">'data' can't be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     'data' length can't be less then 4. Your texture must be at least 2 x 2
        ///     pixels in size.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     'width' can't be less then 2. Your texture must be at least 2 x 2 pixels
        ///     in size.
        /// </exception>
        /// <exception cref="ArgumentException">'width' has an invalid value.</exception>
        private void SetTextureData(uint[] dataLocal, int widthLocal)
        {
            if (dataLocal == null)
            {
                throw new ArgumentNullException(nameof(dataLocal), "'data' can't be null.");
            }

            if (dataLocal.Length < 4)
            {
                throw new ArgumentOutOfRangeException(nameof(dataLocal),
                    "'data' length can't be less then 4. Your texture must be at least 2 x 2 pixels in size.");
            }

            if (widthLocal < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(widthLocal),
                    "'width' can't be less then 2. Your texture must be at least 2 x 2 pixels in size.");
            }

            if (dataLocal.Length % widthLocal != 0)
            {
                throw new ArgumentException("'width' has an invalid value.");
            }

            data = dataLocal;
            dataLength = data.Length;
            width = widthLocal;
            height = dataLength / widthLocal;
        }

        /// <summary>Detects the vertices of the supplied texture data. (PolygonDetectionType.Integrated)</summary>
        /// <param name="data">The texture data.</param>
        /// <param name="width">The texture width.</param>
        /// <returns></returns>
        public static Vertices DetectVertices(uint[] data, int width)
        {
            TextureConverter tc = new TextureConverter(data, width);

            List<Vertices> detectedVerticesList = tc.DetectVertices();

            return detectedVerticesList[0];
        }

        /// <summary>Detects the vertices of the supplied texture data.</summary>
        /// <param name="data">The texture data.</param>
        /// <param name="width">The texture width.</param>
        /// <param name="holeDetection">if set to <c>true</c> it will perform hole detection.</param>
        /// <returns></returns>
        public static Vertices DetectVertices(uint[] data, int width, bool holeDetection)
        {
            TextureConverter tc = new TextureConverter(data, width)
            {
                HoleDetection = holeDetection
            };

            List<Vertices> detectedVerticesList = tc.DetectVertices();

            return detectedVerticesList[0];
        }

        /// <summary>Detects the vertices of the supplied texture data.</summary>
        /// <param name="data">The texture data.</param>
        /// <param name="width">The texture width.</param>
        /// <param name="holeDetection">if set to <c>true</c> it will perform hole detection.</param>
        /// <param name="hullTolerance">The hull tolerance.</param>
        /// <param name="alphaTolerance">The alpha tolerance.</param>
        /// <param name="multiPartDetection">if set to <c>true</c> it will perform multi part detection.</param>
        /// <returns></returns>
        public static List<Vertices> DetectVertices(uint[] data, int width, float hullTolerance, byte alphaTolerance,
            bool multiPartDetection, bool holeDetection)
        {
            TextureConverter tc =
                new TextureConverter(data, width)
                {
                    HullTolerance = hullTolerance,
                    AlphaTolerance = alphaTolerance,
                    MultipartDetection = multiPartDetection,
                    HoleDetection = holeDetection
                };

            List<Vertices> detectedVerticesList = tc.DetectVertices();
            List<Vertices> result = new List<Vertices>();

            for (int i = 0; i < detectedVerticesList.Count; i++)
            {
                result.Add(detectedVerticesList[i]);
            }

            return result;
        }

        /// <summary>
        ///     Detects the vertices
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception">
        ///     '_data' can't be null. You have to use SetTextureData(uint[] data, int width) before
        ///     calling this method.
        /// </exception>
        /// <exception cref="Exception">
        ///     '_width' has an invalid value. You have to use SetTextureData(uint[] data, int width)
        ///     before calling this method.
        /// </exception>
        /// <exception cref="Exception">Couldn't detect any vertices.</exception>
        /// <returns>The detected polygons</returns>
        private List<Vertices> DetectVertices()
        {
            if (data == null)
            {
                throw new Exception(
                    "'_data' can't be null. You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }

            if (data.Length < 4)
            {
                throw new Exception(
                    "'_data' length can't be less then 4. Your texture must be at least 2 x 2 pixels in size. " +
                    "You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }

            if (width < 2)
            {
                throw new Exception(
                    "'_width' can't be less then 2. Your texture must be at least 2 x 2 pixels in size. " +
                    "You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }

            if (data.Length % width != 0)
            {
                throw new Exception(
                    "'_width' has an invalid value. You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }

            List<Vertices> detectedPolygons = new List<Vertices>();

            Vector2? holeEntrance = null;
            Vector2? polygonEntrance = null;

            List<Vector2> blackList = new List<Vector2>();

            bool searchOn;
            do
            {
                Vertices polygon;
                if (detectedPolygons.Count == 0)
                {
                    // First pass / single polygon
                    polygon = new Vertices(CreateSimplePolygon(Vector2.Zero, Vector2.Zero));

                    if (polygon.Count > 2)
                    {
                        polygonEntrance = GetTopMostVertex(polygon);
                    }
                }
                else if (polygonEntrance.HasValue)
                {
                    // Multi pass / multiple polygons
                    polygon = new Vertices(CreateSimplePolygon(polygonEntrance.Value,
                        new Vector2(polygonEntrance.Value.X - 1f, polygonEntrance.Value.Y)));
                }
                else
                {
                    break;
                }

                searchOn = false;

                if (polygon.Count > 2)
                {
                    if (holeDetection)
                    {
                        do
                        {
                            holeEntrance = SearchHoleEntrance(polygon, holeEntrance);

                            if (holeEntrance.HasValue)
                            {
                                if (!blackList.Contains(holeEntrance.Value))
                                {
                                    blackList.Add(holeEntrance.Value);
                                    Vertices holePolygon = CreateSimplePolygon(holeEntrance.Value,
                                        new Vector2(holeEntrance.Value.X + 1, holeEntrance.Value.Y));

                                    if ((holePolygon != null) && (holePolygon.Count > 2))
                                    {
                                        switch (polygonDetectionType)
                                        {
                                            case VerticesDetectionType.Integrated:

                                                // Add first hole polygon vertex to close the hole polygon.
                                                holePolygon.Add(holePolygon[0]);

                                                if (SplitPolygonEdge(polygon, holeEntrance.Value,
                                                        out int vertex2Index))
                                                {
                                                    polygon.InsertRange(vertex2Index, holePolygon);
                                                }

                                                break;

                                            case VerticesDetectionType.Separated:
                                                polygon.Holes ??= new List<Vertices>();

                                                polygon.Holes.Add(holePolygon);
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        } while (true);
                    }

                    detectedPolygons.Add(polygon);
                }

                if (multipartDetection || polygon.Count <= 2)
                {
                    if ((polygonEntrance != null) && SearchNextHullEntrance(detectedPolygons, polygonEntrance.Value, out polygonEntrance))
                    {
                        searchOn = true;
                    }
                }
            } while (searchOn);

            if (detectedPolygons.Count == 0)
            {
                throw new Exception("Couldn't detect any vertices.");
            }

            // Post processing.
            if (PolygonDetectionType ==
                VerticesDetectionType.Separated) // Only when VerticesDetectionType.Separated? -> Recheck.
            {
                ApplyTriangulationCompatibleWinding(ref detectedPolygons);
            }

            if (transform != Matrix4X4F.Identity)
            {
                ApplyTransform(ref detectedPolygons);
            }

            return detectedPolygons;
        }

        /// <summary>
        ///     Applies the triangulation compatible winding using the specified detected polygons
        /// </summary>
        /// <param name="detectedPolygons">The detected polygons</param>
        private void ApplyTriangulationCompatibleWinding(ref List<Vertices> detectedPolygons)
        {
            for (int i = 0; i < detectedPolygons.Count; i++)
            {
                detectedPolygons[i].Reverse();

                if ((detectedPolygons[i].Holes != null) && (detectedPolygons[i].Holes.Count > 0))
                {
                    for (int j = 0; j < detectedPolygons[i].Holes.Count; j++)
                    {
                        detectedPolygons[i].Holes[j].Reverse();
                    }
                }
            }
        }

        /// <summary>
        ///     Applies the transform using the specified detected polygons
        /// </summary>
        /// <param name="detectedPolygons">The detected polygons</param>
        private void ApplyTransform(ref List<Vertices> detectedPolygons)
        {
            for (int i = 0; i < detectedPolygons.Count; i++)
            {
                detectedPolygons[i].Transform(ref transform);
            }
        }

        /// <summary>
        ///     Function to search for an entrance point of a hole in a polygon. It searches the polygon from top to bottom
        ///     between the polygon edges.
        /// </summary>
        /// <param name="polygon">The polygon to search in.</param>
        /// <param name="lastHoleEntrance">The last entrance point.</param>
        /// <returns>The next holes entrance point. Null if there are no holes.</returns>
        private Vector2? SearchHoleEntrance(Vertices polygon, Vector2? lastHoleEntrance)
        {
            if (polygon == null)
            {
                throw new ArgumentNullException("'polygon' can't be null.");
            }

            if (polygon.Count < 3)
            {
                throw new ArgumentException("'polygon.MainPolygon.Count' can't be less then 3.");
            }

            int startY;

            int lastSolid = 0;

            // Set start y coordinate.
            if (lastHoleEntrance.HasValue)
            {
                // We need the y coordinate only.
                startY = (int) lastHoleEntrance.Value.Y;
            }
            else
            {
                // Start from the top of the polygon if last entrance == null.
                startY = (int) GetTopMostCoord(polygon);
            }

            // Set the end y coordinate.
            int endY = (int) GetBottomMostCoord(polygon);

            if ((startY > 0) && (startY < height) && (endY > 0) && (endY < height))
            {
                // go from top to bottom of the polygon
                for (int y = startY; y <= endY; y++)
                {
                    // get x-coord of every polygon edge which crosses y
                    List<float> xCoords = SearchCrossingEdges(polygon, y);

                    // We need an even number of crossing edges. 
                    // It's always a pair of start and end edge: nothing | polygon | hole | polygon | nothing ...
                    // If it's not then don't bother, it's probably a peak ...
                    // ...which should be filtered out by SearchCrossingEdges() anyway.
                    if ((xCoords.Count > 1) && (xCoords.Count % 2 == 0))
                    {
                        // Ok, this is short, but probably a little bit confusing.
                        // This part searches from left to right between the edges inside the polygon.
                        // The problem: We are using the polygon data to search in the texture data.
                        // That's simply not accurate, but necessary because of performance.
                        for (int i = 0; i < xCoords.Count; i += 2)
                        {
                            bool foundSolid = false;
                            bool foundTransparent = false;

                            // We search between the edges inside the polygon.
                            for (int x = (int) xCoords[i]; x <= (int) xCoords[i + 1]; x++)
                            {
                                // First pass: IsSolid might return false.
                                // In that case the polygon edge doesn't lie on the texture's solid pixel, because of the hull tolerance.
                                // If the edge lies before the first solid pixel then we need to skip our transparent pixel finds.

                                // The algorithm starts to search for a relevant transparent pixel (which indicates a possible hole) 
                                // after it has found a solid pixel.

                                // After we've found a solid and a transparent pixel (a hole's left edge) 
                                // we search for a solid pixel again (a hole's right edge).
                                // When found the distance of that coordinate has to be greater then the hull tolerance.

                                if (IsSolid(ref x, ref y))
                                {
                                    if (!foundTransparent)
                                    {
                                        foundSolid = true;
                                        lastSolid = x;
                                    }

                                    /*
                                    if (foundTransparent)
                                    {
                                        Vector2F? entrance = new Vector2F(lastSolid, y);

                                        if (DistanceToHullAcceptable(polygon, entrance.Value, true))
                                        {
                                            return entrance;
                                        }

                                        break;
                                    }*/
                                }
                                else
                                {
                                    if (foundSolid)
                                    {
                                        foundTransparent = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (xCoords.Count % 2 == 0)
                        {
                            Debug.WriteLine("SearchCrossingEdges() % 2 != 0");
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        ///     Describes whether this instance distance to hull acceptable holes
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="point">The point</param>
        /// <param name="higherDetail">The higher detail</param>
        /// <exception cref="ArgumentNullException">'polygon' can't be null.</exception>
        /// <exception cref="ArgumentException">'polygon.MainPolygon.Count' can't be less then 3.</exception>
        /// <returns>The bool</returns>
        private bool DistanceToHullAcceptableHoles(Vertices polygon, Vector2 point, bool higherDetail)
        {
            if (polygon == null)
            {
                throw new ArgumentNullException(nameof(polygon), "'polygon' can't be null.");
            }

            if (polygon.Count < 3)
            {
                throw new ArgumentException("'polygon.MainPolygon.Count' can't be less then 3.");
            }

            // Check the distance to main polygon.
            if (DistanceToHullAcceptable(polygon, point, higherDetail))
            {
                if (polygon.Holes != null)
                {
                    for (int i = 0; i < polygon.Holes.Count; i++)
                    {
                        // If there is one distance not acceptable then return false.
                        if (!DistanceToHullAcceptable(polygon.Holes[i], point, higherDetail))
                        {
                            return false;
                        }
                    }
                }

                // All distances are larger then _hullTolerance.
                return true;
            }

            // Default to false.
            return false;
        }

        /// <summary>
        ///     Describes whether this instance distance to hull acceptable
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="point">The point</param>
        /// <param name="higherDetail">The higher detail</param>
        /// <exception cref="ArgumentNullException">'polygon' can't be null.</exception>
        /// <exception cref="ArgumentException">'polygon.Count' can't be less then 3.</exception>
        /// <returns>The bool</returns>
        private bool DistanceToHullAcceptable(Vertices polygon, Vector2 point, bool higherDetail)
        {
            if (polygon == null)
            {
                throw new ArgumentNullException(nameof(polygon), "'polygon' can't be null.");
            }

            if (polygon.Count < 3)
            {
                throw new ArgumentException("'polygon.Count' can't be less then 3.");
            }

            Vector2 edgeVertex2 = polygon[polygon.Count - 1];
            Vector2 edgeVertex1;

            if (higherDetail)
            {
                for (int i = 0; i < polygon.Count; i++)
                {
                    edgeVertex1 = polygon[i];

                    if (Line.DistanceBetweenPointAndLineSegment( point,  edgeVertex1,  edgeVertex2) <=
                        hullTolerance || Vector2.Distance(point, edgeVertex1) <= hullTolerance)
                    {
                        return false;
                    }

                    edgeVertex2 = polygon[i];
                }

                return true;
            }

            for (int i = 0; i < polygon.Count; i++)
            {
                edgeVertex1 = polygon[i];

                if (Line.DistanceBetweenPointAndLineSegment( point,  edgeVertex1,  edgeVertex2) <=
                    hullTolerance)
                {
                    return false;
                }

                edgeVertex2 = polygon[i];
            }

            return true;
        }

        /// <summary>
        ///     Describes whether this instance in polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        private bool InPolygon(Vertices polygon, Vector2 point)
        {
            bool inPolygon = !DistanceToHullAcceptableHoles(polygon, point, true);

            if (!inPolygon)
            {
                List<float> xCoords = SearchCrossingEdgesHoles(polygon, (int) point.Y);

                if ((xCoords.Count > 0) && (xCoords.Count % 2 == 0))
                {
                    for (int i = 0; i < xCoords.Count; i += 2)
                    {
                        if ((xCoords[i] <= point.X) && (xCoords[i + 1] >= point.X))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            return true;
        }

        /// <summary>
        ///     Gets the top most vertex using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The top most</returns>
        private Vector2? GetTopMostVertex(Vertices vertices)
        {
            float topMostValue = float.MaxValue;
            Vector2? topMost = null;

            for (int i = 0; i < vertices.Count; i++)
            {
                if (topMostValue > vertices[i].Y)
                {
                    topMostValue = vertices[i].Y;
                    topMost = vertices[i];
                }
            }

            return topMost;
        }

        /// <summary>
        ///     Gets the top most coord using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The return value</returns>
        private float GetTopMostCoord(Vertices vertices)
        {
            float returnValue = float.MaxValue;

            for (int i = 0; i < vertices.Count; i++)
            {
                if (returnValue > vertices[i].Y)
                {
                    returnValue = vertices[i].Y;
                }
            }

            return returnValue;
        }

        /// <summary>
        ///     Gets the bottom most coord using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The return value</returns>
        private float GetBottomMostCoord(Vertices vertices)
        {
            float returnValue = float.MinValue;

            for (int i = 0; i < vertices.Count; i++)
            {
                if (returnValue < vertices[i].Y)
                {
                    returnValue = vertices[i].Y;
                }
            }

            return returnValue;
        }

        /// <summary>
        ///     Searches the crossing edges holes using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="y">The </param>
        /// <exception cref="ArgumentNullException">'polygon' can't be null.</exception>
        /// <exception cref="ArgumentException">'polygon.MainPolygon.Count' can't be less then 3.</exception>
        /// <returns>The result</returns>
        private List<float> SearchCrossingEdgesHoles(Vertices polygon, int y)
        {
            if (polygon == null)
            {
                throw new ArgumentNullException(nameof(polygon), "'polygon' can't be null.");
            }

            if (polygon.Count < 3)
            {
                throw new ArgumentException("'polygon.MainPolygon.Count' can't be less then 3.");
            }

            List<float> result = SearchCrossingEdges(polygon, y);

            if (polygon.Holes != null)
            {
                for (int i = 0; i < polygon.Holes.Count; i++)
                {
                    result.AddRange(SearchCrossingEdges(polygon.Holes[i], y));
                }
            }

            result.Sort();
            return result;
        }

        /// <summary>Searches the polygon for the x coordinates of the edges that cross the specified y coordinate.</summary>
        /// <param name="polygon">Polygon to search in.</param>
        /// <param name="y">Y coordinate to check for edges.</param>
        /// <returns>Descending sorted list of x coordinates of edges that cross the specified y coordinate.</returns>
        private List<float> SearchCrossingEdges(Vertices polygon, int y)
        {
            List<float> edges = new List<float>();

            if (polygon.Count > 2)
            {
                // There is a gap between the last and the first vertex in the vertex list.
                // We will bridge that by setting the last vertex (vertex2) to the last 
                // vertex in the list.
                Vector2 vertex2 = polygon[polygon.Count - 1]; // i - 1

                // We are moving along the polygon edges.
                for (int i = 0; i < polygon.Count; i++)
                {
                    Vector2 vertex1 = polygon[i]; // i

                    // Approx. check if the edge crosses our y coord.
                    if (((vertex1.Y >= y) && (vertex2.Y <= y)) ||
                        ((vertex1.Y <= y) && (vertex2.Y >= y)))
                    {
                        // Ignore edges that are parallel to y.
                        if (Math.Abs(vertex1.Y - vertex2.Y) > 0.0001f)
                        {
                            bool addFind = true;
                            Vector2 slope = vertex2 - vertex1;

                            // Special treatment for edges that end at the y coord.
                            if (Math.Abs(vertex1.Y - y) < 0.0001f)
                            {
                                // Create preview of the next edge.
                                Vector2 nextVertex = polygon[(i + 1) % polygon.Count]; // i + 1
                                Vector2 nextSlope = vertex1 - nextVertex;

                                // Ignore peaks. 
                                // If two edges are aligned like this: /\ and the y coordinate lies on the top,
                                // then we get the same x coord twice and we don't need that.
                                if (slope.Y > 0)
                                {
                                    addFind = nextSlope.Y <= 0;
                                }
                                else
                                {
                                    addFind = nextSlope.Y >= 0;
                                }
                            }

                            if (addFind)
                            {
                                edges.Add((y - vertex1.Y) / slope.Y * slope.X +
                                          vertex1.X); // Calculate and add the x coord.
                            }
                        }
                    }

                    // vertex1 becomes vertex2 :).
                    vertex2 = vertex1;
                }
            }

            edges.Sort();
            return edges;
        }

        /// <summary>
        ///     Describes whether this instance split polygon edge
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="coordInsideThePolygon">The coord inside the polygon</param>
        /// <param name="vertex2Index">The vertex index</param>
        /// <returns>The bool</returns>
        private bool SplitPolygonEdge(Vertices polygon, Vector2 coordInsideThePolygon, out int vertex2Index)
        {
            int nearestEdgeVertex1Index = 0;
            int nearestEdgeVertex2Index = 0;
            bool edgeFound = false;

            float shortestDistance = float.MaxValue;

            bool edgeCoordFound = false;
            Vector2 foundEdgeCoord = Vector2.Zero;

            List<float> xCoords = SearchCrossingEdges(polygon, (int) coordInsideThePolygon.Y);

            vertex2Index = 0;

            foundEdgeCoord = new Vector2(foundEdgeCoord.X, coordInsideThePolygon.Y);

            if ((xCoords != null) && (xCoords.Count > 1) && (xCoords.Count % 2 == 0))
            {
                float distance;
                for (int i = 0; i < xCoords.Count; i++)
                {
                    if (xCoords[i] < coordInsideThePolygon.X)
                    {
                        distance = coordInsideThePolygon.X - xCoords[i];

                        if (distance < shortestDistance)
                        {
                            shortestDistance = distance;
                            foundEdgeCoord = new Vector2(xCoords[i], foundEdgeCoord.Y);
                            edgeCoordFound = true;
                        }
                    }
                }

                if (edgeCoordFound)
                {
                    shortestDistance = float.MaxValue;

                    int edgeVertex2Index = polygon.Count - 1;

                    int edgeVertex1Index;
                    for (edgeVertex1Index = 0; edgeVertex1Index < polygon.Count; edgeVertex1Index++)
                    {
                        Vector2 tempVector1 = polygon[edgeVertex1Index];
                        Vector2 tempVector2 = polygon[edgeVertex2Index];
                        distance = Line.DistanceBetweenPointAndLineSegment( foundEdgeCoord,
                             tempVector1,  tempVector2);
                        if (distance < shortestDistance)
                        {
                            shortestDistance = distance;

                            nearestEdgeVertex1Index = edgeVertex1Index;
                            nearestEdgeVertex2Index = edgeVertex2Index;

                            edgeFound = true;
                        }

                        edgeVertex2Index = edgeVertex1Index;
                    }

                    if (edgeFound)
                    {
                        Vector2 slope = polygon[nearestEdgeVertex2Index] - polygon[nearestEdgeVertex1Index];
                        slope = Vector2.Normalize(slope);

                        Vector2 tempVector = polygon[nearestEdgeVertex1Index];
                        distance = Vector2.Distance(tempVector, foundEdgeCoord);

                        vertex2Index = nearestEdgeVertex1Index + 1;

                        polygon.Insert(nearestEdgeVertex1Index, distance * slope + polygon[nearestEdgeVertex1Index]);
                        polygon.Insert(nearestEdgeVertex1Index, distance * slope + polygon[vertex2Index]);

                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary></summary>
        /// <param name="entrance"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        private Vertices CreateSimplePolygon(Vector2 entrance, Vector2 last)
        {
            bool entranceFound = false;
            bool endOfHull = false;

            Vertices polygon = new Vertices(32);
            Vertices hullArea = new Vertices(32);
            Vertices endOfHullArea = new Vertices(32);

            Vector2 current = Vector2.Zero;

            // Get the entrance point.
            if (entrance == Vector2.Zero || !InBounds(ref entrance))
            {
                entranceFound = SearchHullEntrance(out entrance);

                if (entranceFound)
                {
                    current = new Vector2(entrance.X - 1f, entrance.Y);
                }
            }
            else
            {
                if (IsSolid(ref entrance))
                {
                    if (IsNearPixel(ref entrance, ref last))
                    {
                        current = last;
                        entranceFound = true;
                    }
                    else
                    {
                        if (SearchNearPixels(false, ref entrance, out Vector2 temp))
                        {
                            current = temp;
                            entranceFound = true;
                        }
                    }
                }
            }

            if (entranceFound)
            {
                polygon.Add(entrance);
                hullArea.Add(entrance);

                Vector2 next = entrance;

                do
                {
                    // Search in the pre vision list for an outstanding point.
                    if (SearchForOutstandingVertex(hullArea, out Vector2 outstanding))
                    {
                        if (endOfHull)
                        {
                            // We have found the next pixel, but is it on the last bit of the hull?
                            if (endOfHullArea.Contains(outstanding))
                            {
                                // Indeed.
                                polygon.Add(outstanding);
                            }

                            // That's enough, quit.
                            break;
                        }

                        // Add it and remove all vertices that don't matter anymore
                        // (all the vertices before the outstanding).
                        polygon.Add(outstanding);
                        hullArea.RemoveRange(0, hullArea.IndexOf(outstanding));
                    }

                    // Last point gets current and current gets next. Our little spider is moving forward on the hull ;).
                    last = current;
                    current = next;

                    // Get the next point on hull.
                    if (GetNextHullPoint(ref last, ref current, out next))
                    {
                        // Add the vertex to a hull pre-vision list.
                        hullArea.Add(next);
                    }
                    else
                    {
                        // Quit
                        break;
                    }

                    if ((next == entrance) && !endOfHull)
                    {
                        // It's the last bit of the hull, search on and exit at next found vertex.
                        endOfHull = true;
                        endOfHullArea.AddRange(hullArea);

                        // We don't want the last vertex to be the same as the first one, because it causes the triangulation code to crash.
                        if (endOfHullArea.Contains(entrance))
                        {
                            endOfHullArea.Remove(entrance);
                        }
                    }
                } while (true);
            }

            return polygon;
        }

        /// <summary>
        ///     Describes whether this instance search near pixels
        /// </summary>
        /// <param name="searchingForSolidPixel">The searching for solid pixel</param>
        /// <param name="current">The current</param>
        /// <param name="foundPixel">The found pixel</param>
        /// <returns>The bool</returns>
        private bool SearchNearPixels(bool searchingForSolidPixel, ref Vector2 current, out Vector2 foundPixel)
        {
            for (int i = 0; i < ClosePixelsLength; i++)
            {
                int x = (int) current.X + ClosePixels[i, 0];
                int y = (int) current.Y + ClosePixels[i, 1];

                if (!searchingForSolidPixel ^ IsSolid(ref x, ref y))
                {
                    foundPixel = new Vector2(x, y);
                    return true;
                }
            }

            // Nothing found.
            foundPixel = Vector2.Zero;
            return false;
        }

        /// <summary>
        ///     Describes whether this instance is near pixel
        /// </summary>
        /// <param name="current">The current</param>
        /// <param name="near">The near</param>
        /// <returns>The bool</returns>
        private bool IsNearPixel(ref Vector2 current, ref Vector2 near)
        {
            for (int i = 0; i < ClosePixelsLength; i++)
            {
                int x = (int) current.X + ClosePixels[i, 0];
                int y = (int) current.Y + ClosePixels[i, 1];

                if ((x >= 0) && (x <= width) && (y >= 0) && (y <= height))
                {
                    if ((x == (int) near.X) && (y == (int) near.Y))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Describes whether this instance search hull entrance
        /// </summary>
        /// <param name="entrance">The entrance</param>
        /// <returns>The bool</returns>
        private bool SearchHullEntrance(out Vector2 entrance)
        {
            // Search for first solid pixel.
            for (int y = 0; y <= height; y++)
            {
                for (int x = 0; x <= width; x++)
                {
                    if (IsSolid(ref x, ref y))
                    {
                        entrance = new Vector2(x, y);
                        return true;
                    }
                }
            }

            // If there are no solid pixels.
            entrance = Vector2.Zero;
            return false;
        }

        /// <summary>Searches for the next shape.</summary>
        /// <param name="detectedPolygons">Already detected polygons.</param>
        /// <param name="start">Search start coordinate.</param>
        /// <param name="entrance">Returns the found entrance coordinate. Null if no other shapes found.</param>
        /// <returns>True if a new shape was found.</returns>
        private bool SearchNextHullEntrance(List<Vertices> detectedPolygons, Vector2 start, out Vector2? entrance)
        {
            bool foundTransparent = false;

            for (int i = (int) start.X + (int) start.Y * width; i <= dataLength; i++)
            {
                if (IsSolid(ref i))
                {
                    if (foundTransparent)
                    {
                        int x = i % width;
                        entrance = new Vector2(x, (i - x) / (float) width);

                        bool inPolygon = false;
                        for (int polygonIdx = 0; polygonIdx < detectedPolygons.Count; polygonIdx++)
                        {
                            if (InPolygon(detectedPolygons[polygonIdx], entrance.Value))
                            {
                                inPolygon = true;
                                break;
                            }
                        }

                        if (inPolygon)
                        {
                            foundTransparent = false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    foundTransparent = true;
                }
            }

            entrance = null;
            return false;
        }

        /// <summary>
        ///     Describes whether this instance get next hull point
        /// </summary>
        /// <param name="last">The last</param>
        /// <param name="current">The current</param>
        /// <param name="next">The next</param>
        /// <returns>The bool</returns>
        private bool GetNextHullPoint(ref Vector2 last, ref Vector2 current, out Vector2 next)
        {
            int indexOfFirstPixelToCheck = GetIndexOfFirstPixelToCheck(ref last, ref current);

            for (int i = 0; i < ClosePixelsLength; i++)
            {
                int indexOfPixelToCheck = (indexOfFirstPixelToCheck + i) % ClosePixelsLength;

                int x = (int) current.X + ClosePixels[indexOfPixelToCheck, 0];
                int y = (int) current.Y + ClosePixels[indexOfPixelToCheck, 1];

                if ((x >= 0) && (x < width) && (y >= 0) && (y <= height))
                {
                    if (IsSolid(ref x, ref y))
                    {
                        next = new Vector2(x, y);
                        return true;
                    }
                }
            }

            next = Vector2.Zero;
            return false;
        }

        /// <summary>
        ///     Describes whether this instance search for outstanding vertex
        /// </summary>
        /// <param name="hullArea">The hull area</param>
        /// <param name="outstanding">The outstanding</param>
        /// <returns>The found</returns>
        private bool SearchForOutstandingVertex(Vertices hullArea, out Vector2 outstanding)
        {
            Vector2 outstandingResult = Vector2.Zero;
            bool found = false;

            if (hullArea.Count > 2)
            {
                int hullAreaLastPoint = hullArea.Count - 1;

                Vector2 tempVector2 = hullArea[0];
                Vector2 tempVector3 = hullArea[hullAreaLastPoint];

                // Search between the first and last hull point.
                for (int i = 1; i < hullAreaLastPoint; i++)
                {
                    Vector2 tempVector1 = hullArea[i];

                    // Check if the distance is over the one that's tolerable.
                    if (Line.DistanceBetweenPointAndLineSegment( tempVector1,  tempVector2,
                             tempVector3) >= hullTolerance)
                    {
                        outstandingResult = hullArea[i];
                        found = true;
                        break;
                    }
                }
            }

            outstanding = outstandingResult;
            return found;
        }

        /// <summary>
        ///     Gets the index of first pixel to check using the specified last
        /// </summary>
        /// <param name="last">The last</param>
        /// <param name="current">The current</param>
        /// <returns>The int</returns>
        private int GetIndexOfFirstPixelToCheck(ref Vector2 last, ref Vector2 current)
        {
            // .: pixel
            // l: last position
            // c: current position
            // f: first pixel for next search

            // f . .
            // l c .
            // . . .

            //Calculate in which direction the last move went and decide over the next pixel to check.
            switch ((int) (current.X - last.X))
            {
                case 1:
                    switch ((int) (current.Y - last.Y))
                    {
                        case 1:
                            return 1;

                        case 0:
                            return 0;

                        case -1:
                            return 7;
                    }

                    break;

                case 0:
                    switch ((int) (current.Y - last.Y))
                    {
                        case 1:
                            return 2;

                        case -1:
                            return 6;
                    }

                    break;

                case -1:
                    switch ((int) (current.Y - last.Y))
                    {
                        case 1:
                            return 3;

                        case 0:
                            return 4;

                        case -1:
                            return 5;
                    }

                    break;
            }

            return 0;
        }

        /// <summary>
        ///     Describes whether this instance is solid
        /// </summary>
        /// <param name="v">The </param>
        /// <returns>The bool</returns>
        private bool IsSolid(ref Vector2 v)
        {
            tempIsSolidX = (int) v.X;
            tempIsSolidY = (int) v.Y;

            if ((tempIsSolidX >= 0) && (tempIsSolidX < width) && (tempIsSolidY >= 0) && (tempIsSolidY < height))
            {
                return data[tempIsSolidX + tempIsSolidY * width] >= alphaTolerance;
            }

            //return ((_data[_tempIsSolidX + _tempIsSolidY * _width] & 0xFF000000) >= _alphaTolerance);

            return false;
        }

        /// <summary>
        ///     Describes whether this instance is solid
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The bool</returns>
        private bool IsSolid(ref int x, ref int y)
        {
            if ((x >= 0) && (x < width) && (y >= 0) && (y < height))
            {
                return data[x + y * width] >= alphaTolerance;
            }

            //return ((_data[x + y * _width] & 0xFF000000) >= _alphaTolerance);

            return false;
        }

        /// <summary>
        ///     Describes whether this instance is solid
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The bool</returns>
        private bool IsSolid(ref int index)
        {
            if ((index >= 0) && (index < dataLength))
            {
                return data[index] >= alphaTolerance;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether this instance in bounds
        /// </summary>
        /// <param name="coord">The coord</param>
        /// <returns>The bool</returns>
        private bool InBounds(ref Vector2 coord) => (coord.X >= 0f) && (coord.X < width) && (coord.Y >= 0f) && (coord.Y < height);
    }
}