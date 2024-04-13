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
using Alis.Core.Physic.Figure;
using Alis.Core.Physic.Shared;

namespace Alis.Extension.Math.PathGenerator.TextureTools
{
    /// <summary>
    ///     The texture converter class
    /// </summary>
    public class TextureConverter
    {
        /// <summary>
        ///     The close pixels length
        /// </summary>
        private const int ClosePixelsLength = 8;
        
        
        /// <summary>
        ///     The close pixels
        /// </summary>
        private static readonly int[,] ClosePixels = {{-1, -1}, {0, -1}, {1, -1}, {1, 0}, {1, 1}, {0, 1}, {-1, 1}, {-1, 0}};
        
        
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
        private Matrix4X4 transform = Matrix4X4.Identity;
        
        
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
            bool? holeDetection, bool? multipartDetection, Matrix4X4? transform)
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
            float? hullTolerance, bool? holeDetection, bool? multipartDetection, Matrix4X4? transform)
        {
            Initialize(data, width, alphaTolerance, hullTolerance, holeDetection,
                multipartDetection, transform);
        }
        
        
        /// <summary>
        ///     Gets or sets the value of the polygon detection type
        /// </summary>
        public VerticesDetectionType PolygonDetectionType
        {
            get => polygonDetectionType;
            set => polygonDetectionType = value;
        }
        
        
        /// <summary>
        ///     Gets or sets the value of the hole detection
        /// </summary>
        public bool HoleDetection
        {
            get => holeDetection;
            set => holeDetection = value;
        }
        
        
        /// <summary>
        ///     Gets or sets the value of the multipart detection
        /// </summary>
        public bool MultipartDetection
        {
            get => multipartDetection;
            set => multipartDetection = value;
        }
        
        
        /// <summary>
        ///     Gets or sets the value of the transform
        /// </summary>
        public Matrix4X4 Transform
        {
            get => transform;
            set => transform = value;
        }
        
        
        /// <summary>
        ///     Gets or sets the value of the alpha tolerance
        /// </summary>
        public byte AlphaTolerance
        {
            get => (byte) (alphaTolerance >> 24);
            set => alphaTolerance = (uint) value << 24;
        }
        
        
        /// <summary>
        ///     Gets or sets the value of the hull tolerance
        /// </summary>
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
        ///     Initializes the data local
        /// </summary>
        /// <param name="dataLocal">The data local</param>
        /// <param name="widthLocal">The width local</param>
        /// <param name="alphaToleranceLocal">The alpha tolerance local</param>
        /// <param name="hullToleranceLocal">The hull tolerance local</param>
        /// <param name="holeDetectionLocal">The hole detection local</param>
        /// <param name="multipartDetectionLocal">The multipart detection local</param>
        /// <param name="transformLocal">The transform local</param>
        /// <exception cref="ArgumentNullException">'data' can't be null if 'width' is set.</exception>
        /// <exception cref="ArgumentNullException">'width' can't be null if 'data' is set.</exception>
        private void Initialize(uint[] dataLocal, int? widthLocal, byte? alphaToleranceLocal, float? hullToleranceLocal, bool? holeDetectionLocal, bool? multipartDetectionLocal, Matrix4X4? transformLocal)
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
            
            Transform = transformLocal ?? Matrix4X4.Identity;
        }
        
        
        /// <summary>
        ///     Sets the texture data using the specified data local
        /// </summary>
        /// <param name="dataLocal">The data local</param>
        /// <param name="widthLocal">The width local</param>
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
        
        
        /// <summary>
        ///     Detects the vertices using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="width">The width</param>
        /// <returns>The vertices</returns>
        public static Vertices DetectVertices(uint[] data, int width)
        {
            TextureConverter tc = new TextureConverter(data, width);
            
            List<Vertices> detectedVerticesList = tc.DetectVertices();
            
            return detectedVerticesList[0];
        }
        
        
        /// <summary>
        ///     Detects the vertices using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="width">The width</param>
        /// <param name="holeDetection">The hole detection</param>
        /// <returns>The vertices</returns>
        public static Vertices DetectVertices(uint[] data, int width, bool holeDetection)
        {
            TextureConverter tc = new TextureConverter(data, width)
            {
                HoleDetection = holeDetection
            };
            
            List<Vertices> detectedVerticesList = tc.DetectVertices();
            
            return detectedVerticesList[0];
        }
        
        
        /// <summary>
        ///     Detects the vertices using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="width">The width</param>
        /// <param name="hullTolerance">The hull tolerance</param>
        /// <param name="alphaTolerance">The alpha tolerance</param>
        /// <param name="multiPartDetection">The multi part detection</param>
        /// <param name="holeDetection">The hole detection</param>
        /// <returns>The result</returns>
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
        /// <exception cref="Exception">Couldn't detect any vertices.</exception>
        /// <returns>The detected polygons</returns>
        private List<Vertices> DetectVertices()
        {
            ValidateInput();
            
            List<Vertices> detectedPolygons = new List<Vertices>();
            Vector2? holeEntrance = null;
            Vector2? polygonEntrance = null;
            List<Vector2> blackList = new List<Vector2>();
            
            bool searchOn;
            
            do
            {
                Vertices polygon = CreatePolygon(detectedPolygons, ref polygonEntrance);
                
                searchOn = false;
                
                if (polygon.Count > 2)
                {
                    ProcessHoleDetection(polygon, ref holeEntrance, blackList);
                    AddPolygonToList(detectedPolygons, polygon);
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
            
            PostProcessPolygons(ref detectedPolygons);
            
            return detectedPolygons;
        }
        
        
        /// <summary>
        ///     Creates the polygon using the specified detected polygons
        /// </summary>
        /// <param name="detectedPolygons">The detected polygons</param>
        /// <param name="polygonEntrance">The polygon entrance</param>
        /// <returns>The vertices</returns>
        private Vertices CreatePolygon(List<Vertices> detectedPolygons, ref Vector2? polygonEntrance)
        {
            if (detectedPolygons.Count == 0)
            {
                // First pass / single polygon
                return CreateInitialPolygon(ref polygonEntrance);
            }
            
            if (polygonEntrance.HasValue)
            {
                // Multi pass / multiple polygons
                return CreateNextPolygon(polygonEntrance.Value);
            }
            
            return new Vertices();
        }
        
        
        /// <summary>
        ///     Processes the hole detection using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="holeEntrance">The hole entrance</param>
        /// <param name="blackList">The black list</param>
        private void ProcessHoleDetection(Vertices polygon, ref Vector2? holeEntrance, List<Vector2> blackList)
        {
            if (holeDetection)
            {
                do
                {
                    holeEntrance = SearchHoleEntrance(polygon, holeEntrance);
                    
                    if (holeEntrance.HasValue && !blackList.Contains(holeEntrance.Value))
                    {
                        blackList.Add(holeEntrance.Value);
                        Vertices holePolygon = CreateSimplePolygon(holeEntrance.Value,
                            new Vector2(holeEntrance.Value.X + 1, holeEntrance.Value.Y));
                        
                        if ((holePolygon != null) && (holePolygon.Count > 2))
                        {
                            ProcessHolePolygon(polygon, holeEntrance.Value, holePolygon);
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
        }
        
        
        /// <summary>
        ///     Adds the polygon to list using the specified detected polygons
        /// </summary>
        /// <param name="detectedPolygons">The detected polygons</param>
        /// <param name="polygon">The polygon</param>
        private void AddPolygonToList(List<Vertices> detectedPolygons, Vertices polygon)
        {
            detectedPolygons.Add(polygon);
        }
        
        
        /// <summary>
        ///     Creates the initial polygon using the specified polygon entrance
        /// </summary>
        /// <param name="polygonEntrance">The polygon entrance</param>
        /// <returns>The polygon</returns>
        private Vertices CreateInitialPolygon(ref Vector2? polygonEntrance)
        {
            Vertices polygon = new Vertices(CreateSimplePolygon(Vector2.Zero, Vector2.Zero));
            
            if (polygon.Count > 2)
            {
                polygonEntrance = GetTopMostVertex(polygon);
            }
            
            return polygon;
        }
        
        
        /// <summary>
        ///     Creates the next polygon using the specified entrance
        /// </summary>
        /// <param name="entrance">The entrance</param>
        /// <returns>The vertices</returns>
        private Vertices CreateNextPolygon(Vector2 entrance) => new Vertices(CreateSimplePolygon(entrance, new Vector2(entrance.X - 1f, entrance.Y)));
        
        
        /// <summary>
        ///     Processes the hole polygon using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="holeEntrance">The hole entrance</param>
        /// <param name="holePolygon">The hole polygon</param>
        private void ProcessHolePolygon(Vertices polygon, Vector2 holeEntrance, Vertices holePolygon)
        {
            if (polygonDetectionType == VerticesDetectionType.Integrated)
            {
                holePolygon.Add(holePolygon[0]);
                
                if (SplitPolygonEdge(polygon, holeEntrance, out int vertex2Index))
                {
                    polygon.InsertRange(vertex2Index, holePolygon);
                }
            }
            else if (polygonDetectionType == VerticesDetectionType.Separated)
            {
                polygon.Holes ??= new List<Vertices>();
                polygon.Holes.Add(holePolygon);
            }
        }
        
        
        /// <summary>
        ///     Posts the process polygons using the specified detected polygons
        /// </summary>
        /// <param name="detectedPolygons">The detected polygons</param>
        private void PostProcessPolygons(ref List<Vertices> detectedPolygons)
        {
            if (polygonDetectionType == VerticesDetectionType.Separated)
            {
                ApplyTriangulationCompatibleWinding(ref detectedPolygons);
            }
            
            if (transform != Matrix4X4.Identity)
            {
                ApplyTransform(ref detectedPolygons);
            }
        }
        
        
        /// <summary>
        ///     Validates the input
        /// </summary>
        /// <exception cref="DataSizeException">
        ///     'data' can't be null. You have to use SetTextureData(uint[] data, int width) before
        ///     calling this method.
        /// </exception>
        /// <exception cref="DataSizeException">
        ///     'data' length can't be less than 4. Your texture must be at least 2 x 2 pixels in
        ///     size. You have to use SetTextureData(uint[] data, int width) before calling this method.
        /// </exception>
        /// <exception cref="DataSizeException">
        ///     'width' can't be less than 2. Your texture must be at least 2 x 2 pixels in size.
        ///     You have to use SetTextureData(uint[] data, int width) before calling this method.
        /// </exception>
        /// <exception cref="DataSizeException">
        ///     'width' has an invalid value. You have to use SetTextureData(uint[] data, int
        ///     width) before calling this method.
        /// </exception>
        private void ValidateInput()
        {
            if (data == null)
            {
                throw new DataSizeException("'data' can't be null. You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }
            
            if (data.Length < 4)
            {
                throw new DataSizeException("'data' length can't be less than 4. Your texture must be at least 2 x 2 pixels in size. You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }
            
            if (width < 2)
            {
                throw new DataSizeException("'width' can't be less than 2. Your texture must be at least 2 x 2 pixels in size. You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }
            
            if (data.Length % width != 0)
            {
                throw new DataSizeException("'width' has an invalid value. You have to use SetTextureData(uint[] data, int width) before calling this method.");
            }
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
        ///     Searches the hole entrance using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="lastHoleEntrance">The last hole entrance</param>
        /// <exception cref="ArgumentException">'polygon.MainPolygon.Count' can't be less then 3.</exception>
        /// <exception cref="ArgumentNullException">polygon</exception>
        /// <returns>The vector</returns>
        private Vector2? SearchHoleEntrance(Vertices polygon, Vector2? lastHoleEntrance)
        {
            if (polygon == null)
            {
                throw new ArgumentNullException(nameof(polygon));
            }
            
            if (polygon.Count < 3)
            {
                throw new ArgumentException("'polygon.MainPolygon.Count' can't be less then 3.");
            }
            
            DetermineStartAndEndY(polygon, lastHoleEntrance, out int startY, out int endY);
            
            if ((startY > 0) && (startY < height) && (endY > 0) && (endY < height))
            {
                for (int y = startY; y <= endY; y++)
                {
                    List<float> xCoords = SearchEdges(polygon, y);
                    ProcessXCoordinates(xCoords, y);
                }
            }
            
            return null;
        }
        
        
        /// <summary>
        ///     Determines the start and end y using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="lastHoleEntrance">The last hole entrance</param>
        /// <param name="startY">The start</param>
        /// <param name="endY">The end</param>
        private void DetermineStartAndEndY(Vertices polygon, Vector2? lastHoleEntrance, out int startY, out int endY)
        {
            if (lastHoleEntrance.HasValue)
            {
                startY = (int) lastHoleEntrance.Value.Y;
            }
            else
            {
                startY = (int) GetTopMostCoordinate(polygon);
            }
            
            endY = (int) GetBottomMostCoordinate(polygon);
        }
        
        
        /// <summary>
        ///     Processes the x coordinates using the specified x coords
        /// </summary>
        /// <param name="xCoords">The coords</param>
        /// <param name="y">The </param>
        private void ProcessXCoordinates(List<float> xCoords, int y)
        {
            if ((xCoords.Count > 1) && (xCoords.Count % 2 == 0))
            {
                for (int i = 0; i < xCoords.Count; i += 2)
                {
                    for (int x = (int) xCoords[i]; x <= (int) xCoords[i + 1]; x++)
                    {
                        if (IsSolid(ref x, ref y))
                        {
                            return;
                        }
                    }
                }
            }
            else if (xCoords.Count % 2 == 0)
            {
                Debug.WriteLine("SearchCrossingEdges() % 2 != 0");
            }
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
                    
                    if (Line.DistanceBetweenPointAndLineSegment(point, edgeVertex1, edgeVertex2) <=
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
                
                if (Line.DistanceBetweenPointAndLineSegment(point, edgeVertex1, edgeVertex2) <=
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
        ///     Gets the top most coordinate using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The return value</returns>
        private float GetTopMostCoordinate(Vertices vertices)
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
        ///     Gets the bottom most coordinate using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The return value</returns>
        private float GetBottomMostCoordinate(Vertices vertices)
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
            
            List<float> result = SearchEdges(polygon, y);
            
            if (polygon.Holes != null)
            {
                for (int i = 0; i < polygon.Holes.Count; i++)
                {
                    result.AddRange(SearchEdges(polygon.Holes[i], y));
                }
            }
            
            result.Sort();
            return result;
        }
        
        
        /// <summary>
        ///     Searches the edges using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="y">The </param>
        /// <returns>The edges</returns>
        private List<float> SearchEdges(Vertices polygon, int y)
        {
            List<float> edges = new List<float>();
            
            if (polygon.Count <= 2)
            {
                return edges;
            }
            
            IterateSearchEdges(polygon, y, edges);
            
            edges.Sort();
            return edges;
        }
        
        /// <summary>
        ///     Iterates the search edges using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="y">The </param>
        /// <param name="edges">The edges</param>
        private void IterateSearchEdges(Vertices polygon, int y, List<float> edges)
        {
            Vector2 vertex2 = polygon[polygon.Count - 1];
            
            for (int i = 0; i < polygon.Count; i++)
            {
                Vector2 vertex1 = polygon[i];
                
                if (!(((vertex1.Y >= y) && (vertex2.Y <= y)) || ((vertex1.Y <= y) && (vertex2.Y >= y))))
                {
                    continue;
                }
                
                if (!(System.Math.Abs(vertex1.Y - vertex2.Y) > 0.0001f))
                {
                    continue;
                }
                
                Vector2 slope = vertex2 - vertex1;
                bool addFind = Find(vertex1, vertex2, polygon, i, y);
                
                if (addFind)
                {
                    edges.Add((y - vertex1.Y) / slope.Y * slope.X + vertex1.X);
                }
                
                
                vertex2 = vertex1;
            }
        }
        
        /// <summary>
        ///     Describes whether this instance find
        /// </summary>
        /// <param name="vertex1">The vertex</param>
        /// <param name="vertex2">The vertex</param>
        /// <param name="polygon">The polygon</param>
        /// <param name="index">The index</param>
        /// <param name="y">The </param>
        /// <returns>The add find</returns>
        public bool Find(Vector2 vertex1, Vector2 vertex2, Vertices polygon, int index, int y)
        {
            bool addFind = true;
            Vector2 slope = vertex2 - vertex1;
            
            if (System.Math.Abs(vertex1.Y - y) < 0.0001f)
            {
                Vector2 nextVertex = polygon[(index + 1) % polygon.Count];
                Vector2 nextSlope = vertex1 - nextVertex;
                
                if (slope.Y > 0)
                {
                    addFind = nextSlope.Y <= 0;
                }
                else
                {
                    addFind = nextSlope.Y >= 0;
                }
            }
            
            return addFind;
        }
        
        
        /// <summary>
        ///     Describes whether this instance split polygon edge
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="coordinateInsideThePolygon">The coordinate inside the polygon</param>
        /// <param name="vertex2Index">The vertex index</param>
        /// <returns>The bool</returns>
        private bool SplitPolygonEdge(Vertices polygon, Vector2 coordinateInsideThePolygon, out int vertex2Index)
        {
            List<float> xCoords = SearchEdges(polygon, (int) coordinateInsideThePolygon.Y);
            Vector2 foundEdgeCoordinate = FindEdgeCoordinate(xCoords, coordinateInsideThePolygon);
            
            if (foundEdgeCoordinate != Vector2.Zero)
            {
                int[] nearestEdgeVertices = FindNearestEdgeVertices(polygon, foundEdgeCoordinate);
                
                if ((nearestEdgeVertices[0] != -1) && (nearestEdgeVertices[1] != -1))
                {
                    vertex2Index = InsertNewVertices(polygon, nearestEdgeVertices, foundEdgeCoordinate);
                    return true;
                }
            }
            
            vertex2Index = 0;
            return false;
        }
        
        
        /// <summary>
        ///     Finds the edge coordinate using the specified x coords
        /// </summary>
        /// <param name="xCoords">The coords</param>
        /// <param name="coordinateInsideThePolygon">The coordinate inside the polygon</param>
        /// <returns>The found edge coordinate</returns>
        private Vector2 FindEdgeCoordinate(List<float> xCoords, Vector2 coordinateInsideThePolygon)
        {
            float shortestDistance = float.MaxValue;
            Vector2 foundEdgeCoordinate = Vector2.Zero;
            
            if ((xCoords != null) && (xCoords.Count > 1) && (xCoords.Count % 2 == 0))
            {
                for (int i = 0; i < xCoords.Count; i++)
                {
                    if (xCoords[i] < coordinateInsideThePolygon.X)
                    {
                        float distance = coordinateInsideThePolygon.X - xCoords[i];
                        
                        if (distance < shortestDistance)
                        {
                            shortestDistance = distance;
                            foundEdgeCoordinate = new Vector2(xCoords[i], coordinateInsideThePolygon.Y);
                        }
                    }
                }
            }
            
            return foundEdgeCoordinate;
        }
        
        /// <summary>
        ///     Finds the nearest edge vertices using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="foundEdgeCoordinate">The found edge coordinate</param>
        /// <returns>The int array</returns>
        private int[] FindNearestEdgeVertices(Vertices polygon, Vector2 foundEdgeCoordinate)
        {
            int nearestEdgeVertex1Index = -1;
            int nearestEdgeVertex2Index = -1;
            float shortestDistance = float.MaxValue;
            
            int edgeVertex2Index = polygon.Count - 1;
            
            for (int edgeVertex1Index = 0; edgeVertex1Index < polygon.Count; edgeVertex1Index++)
            {
                Vector2 tempVector1 = polygon[edgeVertex1Index];
                Vector2 tempVector2 = polygon[edgeVertex2Index];
                float distance = Line.DistanceBetweenPointAndLineSegment(foundEdgeCoordinate, tempVector1, tempVector2);
                
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestEdgeVertex1Index = edgeVertex1Index;
                    nearestEdgeVertex2Index = edgeVertex2Index;
                }
                
                edgeVertex2Index = edgeVertex1Index;
            }
            
            return new[] {nearestEdgeVertex1Index, nearestEdgeVertex2Index};
        }
        
        /// <summary>
        ///     Inserts the new vertices using the specified polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <param name="nearestEdgeVertices">The nearest edge vertices</param>
        /// <param name="foundEdgeCoordinate">The found edge coordinate</param>
        /// <returns>The vertex index</returns>
        private int InsertNewVertices(Vertices polygon, int[] nearestEdgeVertices, Vector2 foundEdgeCoordinate)
        {
            Vector2 slope = polygon[nearestEdgeVertices[1]] - polygon[nearestEdgeVertices[0]];
            slope = Vector2.Normalize(slope);
            
            Vector2 tempVector = polygon[nearestEdgeVertices[0]];
            float distance = Vector2.Distance(tempVector, foundEdgeCoordinate);
            
            int vertex2Index = nearestEdgeVertices[0] + 1;
            
            polygon.Insert(nearestEdgeVertices[0], distance * slope + polygon[nearestEdgeVertices[0]]);
            polygon.Insert(nearestEdgeVertices[0], distance * slope + polygon[vertex2Index]);
            
            return vertex2Index;
        }
        
        /// <summary>
        ///     Creates the simple polygon using the specified entrance
        /// </summary>
        /// <param name="entrance">The entrance</param>
        /// <param name="last">The last</param>
        /// <returns>The polygon</returns>
        private Vertices CreateSimplePolygon(Vector2 entrance, Vector2 last)
        {
            bool endOfHull = false;
            
            Vertices polygon = new Vertices(32);
            Vertices hullArea = new Vertices(32);
            Vertices endOfHullArea = new Vertices(32);
            
            Vector2 current = Vector2.Zero;
            
            bool entranceFound = GetEntrancePoint(ref entrance, ref last, ref current);
            
            if (entranceFound)
            {
                polygon.Add(entrance);
                hullArea.Add(entrance);
                
                Vector2 next = entrance;
                
                do
                {
                    ProcessOutstandingVertex(ref endOfHull, hullArea, endOfHullArea, polygon);
                    
                    last = current;
                    current = next;
                    
                    if (!GetNextHullPoint(ref last, ref current, out next))
                    {
                        break;
                    }
                    
                    if ((next == entrance) && !endOfHull)
                    {
                        endOfHull = true;
                        endOfHullArea.AddRange(hullArea);
                        
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
        ///     Describes whether this instance get entrance point
        /// </summary>
        /// <param name="entrance">The entrance</param>
        /// <param name="last">The last</param>
        /// <param name="current">The current</param>
        /// <returns>The entrance found</returns>
        private bool GetEntrancePoint(ref Vector2 entrance, ref Vector2 last, ref Vector2 current)
        {
            bool entranceFound = false;
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
            
            return entranceFound;
        }
        
        /// <summary>
        ///     Processes the outstanding vertex using the specified end of hull
        /// </summary>
        /// <param name="endOfHull">The end of hull</param>
        /// <param name="hullArea">The hull area</param>
        /// <param name="endOfHullArea">The end of hull area</param>
        /// <param name="polygon">The polygon</param>
        private void ProcessOutstandingVertex(ref bool endOfHull, Vertices hullArea, Vertices endOfHullArea, Vertices polygon)
        {
            if (SearchForOutstandingVertex(hullArea, out Vector2 outstanding))
            {
                if (endOfHull)
                {
                    if (endOfHullArea.Contains(outstanding))
                    {
                        endOfHull = false;
                    }
                    
                    if (endOfHull)
                    {
                        return;
                    }
                }
                
                polygon.Add(outstanding);
                hullArea.RemoveRange(0, hullArea.IndexOf(outstanding));
            }
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
        
        /// <summary>
        ///     Describes whether this instance search next hull entrance
        /// </summary>
        /// <param name="detectedPolygons">The detected polygons</param>
        /// <param name="start">The start</param>
        /// <param name="entrance">The entrance</param>
        /// <returns>The bool</returns>
        private bool SearchNextHullEntrance(List<Vertices> detectedPolygons, Vector2 start, out Vector2? entrance)
        {
            bool foundTransparent = false;
            
            for (int i = CalculateStartIndex(start); i <= dataLength; i++)
            {
                if (IsSolid(ref i))
                {
                    if (foundTransparent)
                    {
                        entrance = CalculateEntrance(i);
                        
                        if (IsInPolygon(detectedPolygons, entrance.Value))
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
        ///     Calculates the start index using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <returns>The int</returns>
        private int CalculateStartIndex(Vector2 start) => (int) start.X + (int) start.Y * width;
        
        /// <summary>
        ///     Calculates the entrance using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <returns>The vector</returns>
        private Vector2 CalculateEntrance(int i)
        {
            int x = i % width;
            return new Vector2(x, (i - x) / (float) width);
        }
        
        /// <summary>
        ///     Describes whether this instance is in polygon
        /// </summary>
        /// <param name="detectedPolygons">The detected polygons</param>
        /// <param name="entrance">The entrance</param>
        /// <returns>The bool</returns>
        private bool IsInPolygon(List<Vertices> detectedPolygons, Vector2 entrance)
        {
            for (int polygonIdx = 0; polygonIdx < detectedPolygons.Count; polygonIdx++)
            {
                if (InPolygon(detectedPolygons[polygonIdx], entrance))
                {
                    return true;
                }
            }
            
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
                    if (Line.DistanceBetweenPointAndLineSegment(tempVector1, tempVector2,
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
        /// <param name="coordinate">The coordinate</param>
        /// <returns>The bool</returns>
        private bool InBounds(ref Vector2 coordinate) => (coordinate.X >= 0f) && (coordinate.X < width) && (coordinate.Y >= 0f) && (coordinate.Y < height);
    }
}