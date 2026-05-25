// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquares.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Common.TextureTools
{
    /// <summary>
    ///     The marching squares class
    /// </summary>
    public static class MarchingSquares
    {
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


        /// <summary>
        ///     The look march
        /// </summary>
        internal static readonly int[] LookMarch =
        {
            0x00, 0xE0, 0x38, 0xD8, 0x0E, 0xEE, 0x36, 0xD6, 0x83, 0x63, 0xBB, 0x5B, 0x8D,
            0x6D, 0xB5, 0x55
        };

        /// <summary>
        ///     Marching squares over the given domain using the mesh defined via the dimensions
        ///     (wid,hei) to build a set of polygons such that f(x,y) less than 0, using the given number
        ///     'bin' for recursive linear inteprolation along cell boundaries.
        ///     if 'comb' is true, then the polygons will also be composited into larger possible concave
        ///     polygons.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="cellWidth"></param>
        /// <param name="cellHeight"></param>
        /// <param name="f"></param>
        /// <param name="lerpCount"></param>
        /// <param name="combine"></param>
        /// <returns></returns>
        internal static List<Vertices> DetectSquares(Aabb domain, float cellWidth, float cellHeight, sbyte[,] f,
            int lerpCount, bool combine)
        {
            CxFastList<GeomPoly> ret = new CxFastList<GeomPoly>();

            List<Vertices> verticesList = new List<Vertices>();

            //NOTE: removed assignments as they were not used.
            List<GeomPoly> polyList;
            GeomPoly gp;

            int xn = (int) (domain.Extents.X * 2 / cellWidth);
            bool xp = Math.Abs(xn - domain.Extents.X * 2 / cellWidth) < float.Epsilon;
            int yn = (int) (domain.Extents.Y * 2 / cellHeight);
            bool yp = Math.Abs(yn - domain.Extents.Y * 2 / cellHeight) < float.Epsilon;
            if (!xp)
            {
                xn++;
            }

            if (!yp)
            {
                yn++;
            }

            sbyte[,] fs = new sbyte[xn + 1, yn + 1];
            GeomPolyVal[,] ps = new GeomPolyVal[xn + 1, yn + 1];

            //populate shared function lookups.
            for (int x = 0; x < xn + 1; x++)
            {
                int x0;
                if (x == xn)
                {
                    x0 = (int) domain.UpperBound.X;
                }
                else
                {
                    x0 = (int) (x * cellWidth + domain.LowerBound.X);
                }

                for (int y = 0; y < yn + 1; y++)
                {
                    int y0;
                    if (y == yn)
                    {
                        y0 = (int) domain.UpperBound.Y;
                    }
                    else
                    {
                        y0 = (int) (y * cellHeight + domain.LowerBound.Y);
                    }

                    fs[x, y] = f[x0, y0];
                }
            }

            //generate sub-polys and combine to scan lines
            for (int y = 0; y < yn; y++)
            {
                float y0 = y * cellHeight + domain.LowerBound.Y;
                float y1;
                if (y == yn - 1)
                {
                    y1 = domain.UpperBound.Y;
                }
                else
                {
                    y1 = y0 + cellHeight;
                }

                GeomPoly pre = null;
                for (int x = 0; x < xn; x++)
                {
                    float x0 = x * cellWidth + domain.LowerBound.X;
                    float x1;
                    if (x == xn - 1)
                    {
                        x1 = domain.UpperBound.X;
                    }
                    else
                    {
                        x1 = x0 + cellWidth;
                    }

                    gp = new GeomPoly();

                    int key = MarchSquare(f, fs, ref gp, x, y, x0, y0, x1, y1, lerpCount);
                    if (gp.Length != 0)
                    {
                        if (combine && (pre != null) && ((key & 9) != 0))
                        {
                            CombLeft(ref pre, ref gp);
                            gp = pre;
                        }
                        else
                        {
                            ret.Add(gp);
                        }

                        ps[x, y] = new GeomPolyVal(gp, key);
                    }
                    else
                    {
                        gp = null;
                    }

                    pre = gp;
                }
            }

            if (!combine)
            {
                polyList = ret.GetListOfElements();

                foreach (GeomPoly poly in polyList)
                {
                    verticesList.Add(new Vertices(poly.Points.GetListOfElements()));
                }

                return verticesList;
            }

            //combine scan lines together
            for (int y = 1; y < yn; y++)
            {
                int x = 0;
                while (x < xn)
                {
                    GeomPolyVal p = ps[x, y];

                    //skip along scan line if no polygon exists at this point
                    if (p == null)
                    {
                        x++;
                        continue;
                    }

                    //skip along if current polygon cannot be combined above.
                    if ((p.Key & 12) == 0)
                    {
                        x++;
                        continue;
                    }

                    //skip along if no polygon exists above.
                    GeomPolyVal u = ps[x, y - 1];
                    if (u == null)
                    {
                        x++;
                        continue;
                    }

                    //skip along if polygon above cannot be combined with.
                    if ((u.Key & 3) == 0)
                    {
                        x++;
                        continue;
                    }

                    float ax = x * cellWidth + domain.LowerBound.X;
                    float ay = y * cellHeight + domain.LowerBound.Y;

                    CxFastList<Vector2F> bp = p.GeomP.Points;
                    CxFastList<Vector2F> ap = u.GeomP.Points;

                    //skip if it's already been combined with above polygon
                    if (u.GeomP == p.GeomP)
                    {
                        x++;
                        continue;
                    }

                    //combine above (but disallow the hole thingies
                    CxFastListNode<Vector2F> bi = bp.Begin();
                    while (Square(bi.GetElem().Y - ay) > SettingEnv.Epsilon || bi.GetElem().X < ax)
                    {
                        bi = bi.NextPos();
                    }

                    Vector2F b1 = bi.NextPos().GetElem();
                    if (Square(b1.Y - ay) > SettingEnv.Epsilon)
                    {
                        x++;
                        continue;
                    }

                    bool brk = true;
                    CxFastListNode<Vector2F> ai = ap.Begin();
                    while (ai != ap.End())
                    {
                        if (VecDsq(ai.GetElem(), b1) < SettingEnv.Epsilon)
                        {
                            brk = false;
                            break;
                        }

                        ai = ai.NextPos();
                    }

                    if (brk)
                    {
                        x++;
                        continue;
                    }

                    CxFastListNode<Vector2F> bj = bi.NextPos().NextPos();
                    if (bj == bp.End())
                    {
                        bj = bp.Begin();
                    }

                    while (bj != bi)
                    {
                        ai = ap.Insert(ai, bj.GetElem()); // .clone()
                        bj = bj.NextPos();
                        if (bj == bp.End())
                        {
                            bj = bp.Begin();
                        }

                        u.GeomP.Length++;
                    }

                    ax = x + 1;
                    while (ax < xn)
                    {
                        GeomPolyVal p2 = ps[(int) ax, y];
                        if (p2 == null || p2.GeomP != p.GeomP)
                        {
                            ax++;
                            continue;
                        }

                        p2.GeomP = u.GeomP;
                        ax++;
                    }

                    ax = x - 1;
                    while (ax >= 0)
                    {
                        GeomPolyVal p2 = ps[(int) ax, y];
                        if (p2 == null || p2.GeomP != p.GeomP)
                        {
                            ax--;
                            continue;
                        }

                        p2.GeomP = u.GeomP;
                        ax--;
                    }

                    ret.Remove(p.GeomP);
                    p.GeomP = u.GeomP;

                    x = (int) ((bi.NextPos().GetElem().X - domain.LowerBound.X) / cellWidth) + 1;
                }
            }

            polyList = ret.GetListOfElements();

            foreach (GeomPoly poly in polyList)
            {
                verticesList.Add(new Vertices(poly.Points.GetListOfElements()));
            }

            return verticesList;
        }

        /// <summary>
        ///     Lerps the x 0
        /// </summary>
        /// <param name="x0">The </param>
        /// <param name="x1">The </param>
        /// <param name="v0">The </param>
        /// <param name="v1">The </param>
        /// <returns>The float</returns>
        internal static float Lerp(float x0, float x1, float v0, float v1)
        {
            float dv = v0 - v1;
            float t;
            if (dv * dv < SettingEnv.Epsilon)
            {
                t = 0.5f;
            }
            else
            {
                t = v0 / dv;
            }

            return x0 + t * (x1 - x0);
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        /** Recursive linear interpolation for use in marching squares **/
        internal static float Xlerp(float x0, float x1, float y, float v0, float v1, sbyte[,] f, int c)
        {
            float xm = Lerp(x0, x1, v0, v1);
            if (c == 0)
            {
                return xm;
            }

            sbyte vm = f[(int) xm, (int) y];

            if (v0 * vm < 0)
            {
                return Xlerp(x0, xm, y, v0, vm, f, c - 1);
            }

            return Xlerp(xm, x1, y, vm, v1, f, c - 1);
        }

        /** Recursive linear interpolation for use in marching squares **/
        internal static float Ylerp(float y0, float y1, float x, float v0, float v1, sbyte[,] f, int c)
        {
            float ym = Lerp(y0, y1, v0, v1);
            if (c == 0)
            {
                return ym;
            }

            sbyte vm = f[(int) x, (int) ym];

            if (v0 * vm < 0)
            {
                return Ylerp(y0, ym, x, v0, vm, f, c - 1);
            }

            return Ylerp(ym, y1, x, vm, v1, f, c - 1);
        }

        /** Square value for use in marching squares **/
        internal static float Square(float x) => x * x;

        /// <summary>
        ///     Vecs the dsq using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        internal static float VecDsq(Vector2F a, Vector2F b)
        {
            Vector2F d = a - b;
            return d.X * d.X + d.Y * d.Y;
        }

        /// <summary>
        ///     Vecs the cross using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        internal static float VecCross(Vector2F a, Vector2F b) => a.X * b.Y - a.Y * b.X;


        /// <summary>
        ///     Marches the square using the specified f
        /// </summary>
        /// <param name="f">The </param>
        /// <param name="fs">The fs</param>
        /// <param name="poly">The poly</param>
        /// <param name="ax">The ax</param>
        /// <param name="ay">The ay</param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="bin">The bin</param>
        /// <returns>The key</returns>
        internal static int MarchSquare(sbyte[,] f, sbyte[,] fs, ref GeomPoly poly, int ax, int ay, float x0, float y0,
            float x1, float y1, int bin)
        {
            int key = BuildKey(fs, ax, ay);
            int val = LookMarch[key];

            if (val != 0)
            {
                ProcessKey(val, x0, y0, x1, y1, ax, ay, f, fs, bin, ref poly);
            }

            return key;
        }

        /// <summary>
        ///     Builds the lookup key from vertex values
        /// </summary>
        private static int BuildKey(sbyte[,] fs, int ax, int ay)
        {
            int key = 0;

            if (fs[ax, ay] < 0)
                key |= 8;

            if (fs[ax + 1, ay] < 0)
                key |= 4;

            if (fs[ax + 1, ay + 1] < 0)
                key |= 2;

            if (fs[ax, ay + 1] < 0)
                key |= 1;

            return key;
        }

        /// <summary>
        ///     Processes the lookup value and inserts points into the polygon
        /// </summary>
        private static void ProcessKey(int val, float x0, float y0, float x1, float y1, int ax, int ay, sbyte[,] f, sbyte[,] fs, int bin, ref GeomPoly poly)
        {
            CxFastListNode<Vector2F> pi = null;
            sbyte v0 = fs[ax, ay];
            sbyte v1 = fs[ax + 1, ay];
            sbyte v2 = fs[ax + 1, ay + 1];
            sbyte v3 = fs[ax, ay + 1];

            for (int i = 0; i < 8; i++)
            {
                if ((val & (1 << i)) != 0)
                {
                    Vector2F p = GetVertexPosition(i, x0, y0, x1, y1, v0, v1, v2, v3, f, bin);

                    if (i != 7 || (val & 1) != 0)
                    {
                        pi = poly.Points.Insert(pi, p);
                    }
                    else
                    {
                        poly.Points.Add(p = new Vector2F(x0, Ylerp(y0, y1, x0, v0, v3, f, bin)));
                    }

                    poly.Length++;
                }
            }
        }

        /// <summary>
        ///     Gets the vertex position for a given index
        /// </summary>
        private static Vector2F GetVertexPosition(int i, float x0, float y0, float x1, float y1, sbyte v0, sbyte v1, sbyte v2, sbyte v3, sbyte[,] f, int bin)
        {
            return i switch
            {
                0 => new Vector2F(x0, y0),
                2 => new Vector2F(x1, y0),
                4 => new Vector2F(x1, y1),
                6 => new Vector2F(x0, y1),
                1 => new Vector2F(Xlerp(x0, x1, y0, v0, v1, f, bin), y0),
                5 => new Vector2F(Xlerp(x0, x1, y1, v3, v2, f, bin), y1),
                3 => new Vector2F(x1, Ylerp(y0, y1, x1, v1, v2, f, bin)),
                _ => new Vector2F(x0, Ylerp(y0, y1, x0, v0, v3, f, bin))
            };
        }


        /// <summary>
        ///     Combs the left using the specified polya
        /// </summary>
        /// <param name="polya">The polya</param>
        /// <param name="polyb">The polyb</param>
        internal static void CombLeft(ref GeomPoly polya, ref GeomPoly polyb)
        {
            CxFastList<Vector2F> ap = polya.Points;
            CxFastList<Vector2F> bp = polyb.Points;
            CxFastListNode<Vector2F> ai = ap.Begin();
            CxFastListNode<Vector2F> bi = bp.Begin();

            Vector2F b = bi.GetElem();
            while (ai != ap.End())
            {
                Vector2F a = ai.GetElem();
                if (VecDsq(a, b) < SettingEnv.Epsilon)
                {
                    InsertPolyIntoPoly(ref ap, ref polya, ref bp, ref ai);
                    RemoveParallelVerticesAfterInsertion(ref ap, ref polya, ai);
                    return;
                }

                ai = ai.NextPos();
            }
        }

        /// <summary>
        ///     Inserts polyb into polya at the current position
        /// </summary>
        private static void InsertPolyIntoPoly(ref CxFastList<Vector2F> ap, ref GeomPoly polya, ref CxFastList<Vector2F> bp, ref CxFastListNode<Vector2F> ai)
        {
            bool fst = true;
            CxFastListNode<Vector2F> preb = null;

            while (!bp.Empty())
            {
                Vector2F bb = bp.Front();
                bp.Pop();
                if (!fst && !bp.Empty())
                {
                    ai = ap.Insert(ai, bb);
                    polya.Length++;
                    preb = ai;
                }

                fst = false;
            }
        }

        /// <summary>
        ///     Removes parallel vertices after insertion
        /// </summary>
        private static void RemoveParallelVerticesAfterInsertion(ref CxFastList<Vector2F> ap, ref GeomPoly polya, CxFastListNode<Vector2F> ai)
        {
            Vector2F a1 = ai.GetElem();
            ai = ai.NextPos();
            if (ai == ap.End())
            {
                ai = ap.Begin();
            }

            Vector2F a2 = ai.GetElem();
            CxFastListNode<Vector2F> preb = null;

            // We need to find preb - the last inserted node
            // For simplicity, we search backwards from ai
            CxFastListNode<Vector2F> current = ap.Begin();
            while (current != ap.End())
            {
                if (current.NextPos() == ai)
                {
                    preb = current;
                    break;
                }
                current = current.NextPos();
            }

            if (preb != null)
            {
                Vector2F a00 = preb.GetElem();
                Vector2F uu = a1 - a00;
                Vector2F vv = a2 - a1;
                float dot1 = VecCross(uu, vv);
                if (dot1 * dot1 < SettingEnv.Epsilon)
                {
                    ap.Erase(preb, preb.NextPos());
                    polya.Length--;
                }
            }
        }


        /// <summary>
        ///     Designed as a complete port of CxFastList from CxStd.
        /// </summary>
        internal class CxFastList<T>
        {
            /// <summary>
            ///     The count
            /// </summary>
            internal int _count;

            // first node in the list
            /// <summary>
            ///     The head
            /// </summary>
            internal CxFastListNode<T> _head;

            /// <summary>
            ///     Iterator to start of list (O(1))
            /// </summary>
            public CxFastListNode<T> Begin() => _head;

            /// <summary>
            ///     Iterator to end of list (O(1))
            /// </summary>
            public CxFastListNode<T> End() => null;

            /// <summary>
            ///     Returns first element of list (O(1))
            /// </summary>
            public T Front() => _head.GetElem();

            /// <summary>
            ///     add object to list (O(1))
            /// </summary>
            public CxFastListNode<T> Add(T value)
            {
                CxFastListNode<T> newNode = new CxFastListNode<T>(value);
                if (_head == null)
                {
                    newNode.Next = null;
                    _head = newNode;
                    _count++;
                    return newNode;
                }

                newNode.Next = _head;
                _head = newNode;

                _count++;

                return newNode;
            }

            /// <summary>
            ///     remove object from list, returns true if an element was removed (O(n))
            /// </summary>
            public bool Remove(T value)
            {
                CxFastListNode<T> head = _head;
                CxFastListNode<T> prev = _head;

                EqualityComparer<T> comparer = EqualityComparer<T>.Default;

                if (head != null)
                {
                    if (!EqualityComparer<T>.Default.Equals(value, default(T)))
                    {
                        do
                        {
                            // if we are on the value to be removed
                            if (comparer.Equals(head.Elt, value))
                            {
                                // then we need to patch the list
                                // check to see if we are removing the _head
                                if (head == _head)
                                {
                                    _head = head.Next;
                                    _count--;
                                    return true;
                                }

                                // were not at the head
                                prev.Next = head.Next;
                                _count--;
                                return true;
                            }

                            // cache the current as the previous for the next go around
                            prev = head;
                            head = head.Next;
                        } while (head != null);
                    }
                }

                return false;
            }

            /// <summary>
            ///     pop element from head of list (O(1)) Note: this does not return the object popped!
            ///     There is good reason to this, and it regards the Alloc list variants which guarantee
            ///     objects are released to the object pool. You do not want to retrieve an element
            ///     through pop or else that object may suddenly be used by another piece of code which
            ///     retrieves it from the object pool.
            /// </summary>
            public CxFastListNode<T> Pop() => Erase(null, _head);

            /// <summary>
            ///     insert object after 'node' returning an iterator to the inserted object.
            /// </summary>
            public CxFastListNode<T> Insert(CxFastListNode<T> node, T value)
            {
                if (node == null)
                {
                    return Add(value);
                }

                CxFastListNode<T> newNode = new CxFastListNode<T>(value);
                CxFastListNode<T> nextNode = node.Next;
                newNode.Next = nextNode;
                node.Next = newNode;

                _count++;

                return newNode;
            }

            /// <summary>
            ///     removes the element pointed to by 'node' with 'prev' being the previous iterator,
            ///     returning an iterator to the element following that of 'node' (O(1))
            /// </summary>
            public CxFastListNode<T> Erase(CxFastListNode<T> prev, CxFastListNode<T> node)
            {
                // cache the node after the node to be removed
                CxFastListNode<T> nextNode = node.Next;
                if (prev != null)
                {
                    prev.Next = nextNode;
                }
                else if (_head != null)
                {
                    _head = _head.Next;
                }
                else
                {
                    return null;
                }

                _count--;
                return nextNode;
            }

            /// <summary>
            ///     whether the list is empty (O(1))
            /// </summary>
            public bool Empty()
            {
                if (_head == null)
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            ///     computes size of list (O(n))
            /// </summary>
            public int Size()
            {
                CxFastListNode<T> i = Begin();
                int count = 0;

                do
                {
                    count++;
                } while (i.NextPos() != null);

                return count;
            }

            /// <summary>
            ///     empty the list (O(1) if CxMixList, O(n) otherwise)
            /// </summary>
            public void Clear()
            {
                CxFastListNode<T> head = _head;
                while (head != null)
                {
                    CxFastListNode<T> node2 = head;
                    head = head.Next;
                    node2.Next = null;
                }

                _head = null;
                _count = 0;
            }

            /// <summary>
            ///     returns true if 'value' is an element of the list (O(n))
            /// </summary>
            public bool Has(T value) => Find(value) != null;

            // Non CxFastList Methods 
            /// <summary>
            ///     Finds the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>A cx fast list node of t</returns>
            public CxFastListNode<T> Find(T value)
            {
                // start at head
                CxFastListNode<T> head = _head;
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                if (head != null)
                {
                    if (!EqualityComparer<T>.Default.Equals(value, default(T)))
                    {
                        do
                        {
                            if (comparer.Equals(head.Elt, value))
                            {
                                return head;
                            }

                            head = head.Next;
                        } while (head != _head);
                    }
                    else
                    {
                        do
                        {
                            if (EqualityComparer<T>.Default.Equals(head.Elt, default(T)))
                            {
                                return head;
                            }

                            head = head.Next;
                        } while (head != _head);
                    }
                }

                return null;
            }

            /// <summary>
            ///     Gets the list of elements
            /// </summary>
            /// <returns>The list</returns>
            public List<T> GetListOfElements()
            {
                List<T> list = new List<T>();

                CxFastListNode<T> iter = Begin();

                if (iter != null)
                {
                    do
                    {
                        list.Add(iter.Elt);
                        iter = iter.Next;
                    } while (iter != null);
                }

                return list;
            }
        }


        /// <summary>
        ///     The geom poly class
        /// </summary>
        internal class GeomPoly
        {
            /// <summary>
            ///     The points
            /// </summary>
            public readonly CxFastList<Vector2F> Points;

            /// <summary>
            ///     The length
            /// </summary>
            public int Length;

            /// <summary>
            ///     Initializes a new instance of the <see cref="GeomPoly" /> class
            /// </summary>
            public GeomPoly()
            {
                Points = new CxFastList<Vector2F>();
                Length = 0;
            }
        }
    }
}