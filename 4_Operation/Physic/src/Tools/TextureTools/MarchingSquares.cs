// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MarchingSquares.cs
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

using System.Collections.Generic;
using System.Numerics;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Tools.TextureTools
{
    // Ported by Matthew Bettcher - Feb 2011

    /*
    Copyright (c) 2010, Luca Deltodesco
    All rights reserved.

    Redistribution and use in source and binary forms, with or without modification, are permitted
    provided that the following conditions are met:

        * Redistributions of source code must retain the above copyright notice, this list of conditions
	      and the following disclaimer.
        * Redistributions in binary form must reproduce the above copyright notice, this list of
	      conditions and the following disclaimer in the documentation and/or other materials provided
	      with the distribution.
        * Neither the name of the nape project nor the names of its contributors may be used to endorse
	     or promote products derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
    IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
    FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
    CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
    DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
    DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
    IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
    OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
    */

    /// <summary>
    ///     The marching squares class
    /// </summary>
    public static class MarchingSquares
    {
        /// <summary>
        ///     Linearly interpolate between (x0 to x1) given a value at these coordinates (v0 and v1) such as to approximate
        ///     value(return) = 0
        /// </summary>
        private static readonly int[] LookMarch =
        {
            0x00, 0xE0, 0x38, 0xD8, 0x0E, 0xEE, 0x36, 0xD6, 0x83, 0x63, 0xBB, 0x5B, 0x8D,
            0x6D, 0xB5, 0x55
        };

        /// <summary>
        ///     Marching squares over the given domain using the mesh defined via the dimensions (wid,hei) to build a set of
        ///     polygons such that f(x,y) less than 0, using the given number 'bin' for recursive linear inteprolation along cell
        ///     boundaries. if 'comb' is true, then the polygons will also be composited into larger possible concave polygons.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="cellWidth"></param>
        /// <param name="cellHeight"></param>
        /// <param name="f"></param>
        /// <param name="lerpCount"></param>
        /// <param name="combine"></param>
        /// <returns></returns>
        public static List<Vertices> DetectSquares(Aabb domain, float cellWidth, float cellHeight, sbyte[,] f,
            int lerpCount, bool combine)
        {
            CxFastList<GeomPoly> ret = new CxFastList<GeomPoly>();

            List<Vertices> verticesList = new List<Vertices>();

            //NOTE: removed assignments as they were not used.
            List<GeomPoly> polyList;
            GeomPoly gp;

            int xn = (int) (domain.Extents.X * 2 / cellWidth);
            bool xp = xn == domain.Extents.X * 2 / cellWidth;
            int yn = (int) (domain.Extents.Y * 2 / cellHeight);
            bool yp = yn == domain.Extents.Y * 2 / cellHeight;
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
                        if (combine && pre != null && (key & 9) != 0)
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

                    CxFastList<Vector2> bp = p.GeomP.Points;
                    CxFastList<Vector2> ap = u.GeomP.Points;

                    //skip if it's already been combined with above polygon
                    if (u.GeomP == p.GeomP)
                    {
                        x++;
                        continue;
                    }

                    //combine above (but disallow the hole thingies
                    CxFastListNode<Vector2> bi = bp.Begin();
                    while (Square(bi.GetElem().Y - ay) > MathConstants.Epsilon || bi.GetElem().X < ax)
                    {
                        bi = bi.GetNext();
                    }

                    //NOTE: Unused
                    //Vector2 b0 = bi.elem();
                    Vector2 b1 = bi.GetNext().GetElem();
                    if (Square(b1.Y - ay) > MathConstants.Epsilon)
                    {
                        x++;
                        continue;
                    }

                    bool brk = true;
                    CxFastListNode<Vector2> ai = ap.Begin();
                    while (ai != ap.End())
                    {
                        if (VecDsq(ai.GetElem(), b1) < MathConstants.Epsilon)
                        {
                            brk = false;
                            break;
                        }

                        ai = ai.GetNext();
                    }

                    if (brk)
                    {
                        x++;
                        continue;
                    }

                    CxFastListNode<Vector2> bj = bi.GetNext().GetNext();
                    if (bj == bp.End())
                    {
                        bj = bp.Begin();
                    }

                    while (bj != bi)
                    {
                        ai = ap.Insert(ai, bj.GetElem()); // .clone()
                        bj = bj.GetNext();
                        if (bj == bp.End())
                        {
                            bj = bp.Begin();
                        }

                        u.GeomP.Length++;
                    }

                    //u.p.simplify(float.Epsilon,float.Epsilon);
                    //
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

                    x = (int) ((bi.GetNext().GetElem().X - domain.LowerBound.X) / cellWidth) + 1;

                    //x++; this was already commented out!
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
        private static float Lerp(float x0, float x1, float v0, float v1)
        {
            float dv = v0 - v1;
            float t;
            if (dv * dv < MathConstants.Epsilon)
            {
                t = 0.5f;
            }
            else
            {
                t = v0 / dv;
            }

            return x0 + t * (x1 - x0);
        }

        /// <summary>Recursive linear interpolation for use in marching squares</summary>
        private static float Xlerp(float x0, float x1, float y, float v0, float v1, sbyte[,] f, int c)
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

        /// <summary>Recursive linear interpolation for use in marching squares</summary>
        private static float Ylerp(float y0, float y1, float x, float v0, float v1, sbyte[,] f, int c)
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

        /// <summary>Square value for use in marching squares</summary>
        private static float Square(float x) => x * x;

        /// <summary>
        ///     Vecs the dsq using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        private static float VecDsq(Vector2 a, Vector2 b)
        {
            Vector2 d = a - b;
            return d.X * d.X + d.Y * d.Y;
        }

        /// <summary>
        ///     Vecs the cross using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        private static float VecCross(Vector2 a, Vector2 b) => a.X * b.Y - a.Y * b.X;

        /// <summary>
        ///     Look-up table to relate polygon key with the vertices that should be used for the sub polygon in marching
        ///     squares Perform a single celled marching square for for the given cell defined by (x0,y0) (x1,y1) using the
        ///     function f
        ///     for recursive interpolation, given the look-up table 'fs' of the values of 'f' at cell vertices with the result to
        ///     be
        ///     stored in 'poly' given the actual coordinates of 'ax' 'ay' in the marching squares mesh.
        /// </summary>
        private static int MarchSquare(sbyte[,] f, sbyte[,] fs, ref GeomPoly poly, int ax, int ay, float x0, float y0,
            float x1, float y1, int bin)
        {
            //key lookup
            int key = 0;
            sbyte v0 = fs[ax, ay];
            if (v0 < 0)
            {
                key |= 8;
            }

            sbyte v1 = fs[ax + 1, ay];
            if (v1 < 0)
            {
                key |= 4;
            }

            sbyte v2 = fs[ax + 1, ay + 1];
            if (v2 < 0)
            {
                key |= 2;
            }

            sbyte v3 = fs[ax, ay + 1];
            if (v3 < 0)
            {
                key |= 1;
            }

            int val = LookMarch[key];
            if (val != 0)
            {
                CxFastListNode<Vector2> pi = null;
                for (int i = 0; i < 8; i++)
                {
                    Vector2 p;
                    if ((val & (1 << i)) != 0)
                    {
                        if (i == 7 && (val & 1) == 0)
                        {
                            poly.Points.Add(p = new Vector2(x0, Ylerp(y0, y1, x0, v0, v3, f, bin)));
                        }
                        else
                        {
                            if (i == 0)
                            {
                                p = new Vector2(x0, y0);
                            }
                            else if (i == 2)
                            {
                                p = new Vector2(x1, y0);
                            }
                            else if (i == 4)
                            {
                                p = new Vector2(x1, y1);
                            }
                            else if (i == 6)
                            {
                                p = new Vector2(x0, y1);
                            }

                            else if (i == 1)
                            {
                                p = new Vector2(Xlerp(x0, x1, y0, v0, v1, f, bin), y0);
                            }
                            else if (i == 5)
                            {
                                p = new Vector2(Xlerp(x0, x1, y1, v3, v2, f, bin), y1);
                            }

                            else if (i == 3)
                            {
                                p = new Vector2(x1, Ylerp(y0, y1, x1, v1, v2, f, bin));
                            }
                            else
                            {
                                p = new Vector2(x0, Ylerp(y0, y1, x0, v0, v3, f, bin));
                            }

                            pi = poly.Points.Insert(pi, p);
                        }

                        poly.Length++;
                    }
                }

                //poly.simplify(float.Epsilon,float.Epsilon);
            }

            return key;
        }

        /// <summary>
        ///     Used in polygon composition to composit polygons into scan lines Combining polya and polyb into one
        ///     super-polygon stored in polya.
        /// </summary>
        private static void CombLeft(ref GeomPoly polya, ref GeomPoly polyb)
        {
            CxFastList<Vector2> ap = polya.Points;
            CxFastList<Vector2> bp = polyb.Points;
            CxFastListNode<Vector2> ai = ap.Begin();
            CxFastListNode<Vector2> bi = bp.Begin();

            Vector2 b = bi.GetElem();
            CxFastListNode<Vector2> prea = null;
            while (ai != ap.End())
            {
                Vector2 a = ai.GetElem();
                if (VecDsq(a, b) < MathConstants.Epsilon)
                {
                    //ignore shared vertex if parallel
                    if (prea != null)
                    {
                        Vector2 a0 = prea.GetElem();
                        b = bi.GetNext().GetElem();

                        Vector2 u = a - a0;

                        //vec_new(u); vec_sub(a.p.p, a0.p.p, u);
                        Vector2 v = b - a;

                        //vec_new(v); vec_sub(b.p.p, a.p.p, v);
                        float dot = VecCross(u, v);
                        if (dot * dot < MathConstants.Epsilon)
                        {
                            ap.Erase(prea, ai);
                            polya.Length--;
                            ai = prea;
                        }
                    }

                    //insert polyb into polya
                    bool fst = true;
                    CxFastListNode<Vector2> preb = null;
                    while (!bp.Empty())
                    {
                        Vector2 bb = bp.Front();
                        bp.Pop();
                        if (!fst && !bp.Empty())
                        {
                            ai = ap.Insert(ai, bb);
                            polya.Length++;
                            preb = ai;
                        }

                        fst = false;
                    }

                    //ignore shared vertex if parallel
                    ai = ai.GetNext();
                    Vector2 a1 = ai.GetElem();
                    ai = ai.GetNext();
                    if (ai == ap.End())
                    {
                        ai = ap.Begin();
                    }

                    Vector2 a2 = ai.GetElem();
                    Vector2 a00 = preb.GetElem();
                    Vector2 uu = a1 - a00;

                    //vec_new(u); vec_sub(a1.p, a0.p, u);
                    Vector2 vv = a2 - a1;

                    //vec_new(v); vec_sub(a2.p, a1.p, v);
                    float dot1 = VecCross(uu, vv);
                    if (dot1 * dot1 < MathConstants.Epsilon)
                    {
                        ap.Erase(preb, preb.GetNext());
                        polya.Length--;
                    }

                    return;
                }

                prea = ai;
                ai = ai.GetNext();
            }
        }

        /// <summary>Designed as a complete port of CxFastList from CxStd.</summary>
        internal class CxFastList<T>
        {
            // first node in the list
            /// <summary>
            ///     The head
            /// </summary>
            private CxFastListNode<T> head;

            /// <summary>Iterator to start of list (O(1))</summary>
            public CxFastListNode<T> Begin() => head;

            /// <summary>Iterator to end of list (O(1))</summary>
            public CxFastListNode<T> End() => null;

            /// <summary>Returns first element of list (O(1))</summary>
            public T Front() => head.GetElem();

            /// <summary>add object to list (O(1))</summary>
            public CxFastListNode<T> Add(T value)
            {
                CxFastListNode<T> newNode = new CxFastListNode<T>(value);
                if (head == null)
                {
                    newNode.Next = null;
                    head = newNode;
                    return newNode;
                }

                newNode.Next = head;
                head = newNode;

                return newNode;
            }

            /// <summary>remove object from list, returns true if an element was removed (O(n))</summary>
            public bool Remove(T value)
            {
                CxFastListNode<T> head = this.head;
                CxFastListNode<T> prev = this.head;

                EqualityComparer<T> comparer = EqualityComparer<T>.Default;

                if (head != null)
                {
                    if (value != null)
                    {
                        do
                        {
                            // if we are on the value to be removed
                            if (comparer.Equals(head.Elt, value))
                            {
                                // then we need to patch the list
                                // check to see if we are removing the _head
                                if (head == this.head)
                                {
                                    this.head = head.Next;
                                    return true;
                                }

                                // were not at the head
                                prev.Next = head.Next;
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
            ///     pop element from head of list (O(1)) Note: this does not return the object popped! There is good reason to
            ///     this, and it regards the Alloc list variants which guarantee objects are released to the object pool. You do not
            ///     want
            ///     to retrieve an element through pop or else that object may suddenly be used by another piece of code which
            ///     retrieves it
            ///     from the object pool.
            /// </summary>
            public CxFastListNode<T> Pop() => Erase(null, head);

            /// <summary>insert object after 'node' returning an iterator to the inserted object.</summary>
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

                return newNode;
            }

            /// <summary>
            ///     removes the element pointed to by 'node' with 'prev' being the previous iterator, returning an iterator to the
            ///     element following that of 'node' (O(1))
            /// </summary>
            public CxFastListNode<T> Erase(CxFastListNode<T> prev, CxFastListNode<T> node)
            {
                // cache the node after the node to be removed
                CxFastListNode<T> nextNode = node.Next;
                if (prev != null)
                {
                    prev.Next = nextNode;
                }
                else if (head != null)
                {
                    head = head.Next;
                }
                else
                {
                    return null;
                }

                return nextNode;
            }

            /// <summary>whether the list is empty (O(1))</summary>
            public bool Empty()
            {
                if (head == null)
                {
                    return true;
                }

                return false;
            }

            /// <summary>computes size of list (O(n))</summary>
            public int Size()
            {
                CxFastListNode<T> i = Begin();
                int count = 0;

                do
                {
                    count++;
                } while (i.GetNext() != null);

                return count;
            }

            /// <summary>empty the list (O(1) if CxMixList, O(n) otherwise)</summary>
            public void Clear()
            {
                CxFastListNode<T> head = this.head;
                while (head != null)
                {
                    CxFastListNode<T> node2 = head;
                    head = head.Next;
                    node2.Next = null;
                }

                this.head = null;
            }

            /// <summary>returns true if 'value' is an element of the list (O(n))</summary>
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
                CxFastListNode<T> head = this.head;
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                if (head != null)
                {
                    if (value != null)
                    {
                        do
                        {
                            if (comparer.Equals(head.Elt, value))
                            {
                                return head;
                            }

                            head = head.Next;
                        } while (head != this.head);
                    }
                    else
                    {
                        do
                        {
                            if (head.Elt == null)
                            {
                                return head;
                            }

                            head = head.Next;
                        } while (head != this.head);
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
        ///     The cx fast list node class
        /// </summary>
        internal class CxFastListNode<T>
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="CxFastListNode{T}" /> class
            /// </summary>
            /// <param name="obj">The obj</param>
            public CxFastListNode(T obj) => Elt = obj;

            /// <summary>
            ///     The elt
            /// </summary>
            internal T Elt { get; set; }

            /// <summary>
            ///     The next
            /// </summary>
            internal CxFastListNode<T> Next { get; set; }

            /// <summary>
            ///     Elems this instance
            /// </summary>
            /// <returns>The elt</returns>
            public T GetElem() => Elt;

            /// <summary>
            ///     Nexts this instance
            /// </summary>
            /// <returns>The next</returns>
            public CxFastListNode<T> GetNext() => Next;
        }

        /// <summary>
        ///     The geom poly class
        /// </summary>
        internal class GeomPoly
        {
            /// <summary>
            ///     The length
            /// </summary>
            public int Length;

            /// <summary>
            ///     The points
            /// </summary>
            public CxFastList<Vector2> Points;

            /// <summary>
            ///     Initializes a new instance of the <see cref="GeomPoly" /> class
            /// </summary>
            public GeomPoly()
            {
                Points = new CxFastList<Vector2>();
                Length = 0;
            }
        }

        /// <summary>
        ///     The geom poly val class
        /// </summary>
        private class GeomPolyVal
        {
            /**
             * Associated polygon at coordinate *
             * Key of original sub-polygon *
             */
            public readonly int Key;

            /// <summary>
            ///     The geom
            /// </summary>
            public GeomPoly GeomP;

            /// <summary>
            ///     Initializes a new instance of the <see cref="GeomPolyVal" /> class
            /// </summary>
            /// <param name="geomP">The geom</param>
            /// <param name="k">The </param>
            public GeomPolyVal(GeomPoly geomP, int k)
            {
                GeomP = geomP;
                Key = k;
            }
        }
    }
}