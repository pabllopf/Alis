// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbImage.Generated.Bmp.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stb image class
    /// </summary>
    public partial class StbImage
    {
        /// <summary>
        ///     Stbis the bmp test using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static int Stbibmptest(StbiContext s)
        {
            int r = Stbibmptestraw(s);
            Stbirewind(s);
            return r;
        }

        /// <summary>
        ///     Stbis the bmp load using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqComp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The out</returns>
        public static IntPtr Stbibmpload(StbiContext s, out int x, out int y, out int comp, int reqComp, out StbiResultInfo ri)
        {
            x = 0;
            y = 0;
            comp = 0;
            ri = new StbiResultInfo();

            byte[] output = null;
            byte[][] pal = Utility.CreateArray<byte>(256, 4);
            int psize = 0;
            int width = 0;
            int pad = 0;
            int target = 0;
            int z = 0;

            StbiBmpData info = new StbiBmpData {all_a = 255};
            if (Stbibmpparseheader(s, ref info) == IntPtr.Zero)
                return IntPtr.Zero;
            ;

            int flipVertically = s.ImgY > 0 ? 1 : 0;
            s.ImgY = (uint) Math.Abs((int) s.ImgY);
            if (s.ImgY > (1 << 24) || s.ImgX > (1 << 24))
                return IntPtr.Zero;

            if (info.hsz == 12 && info.bpp < 24)
                psize = (info.offset - info.extra_read - 24) / 3;
            else if (info.bpp < 16)
                psize = (info.offset - info.extra_read - info.hsz) >> 2;

            int bytesReadSoFar = (int) s.Stream.Position;
            if (psize == 0)
            {
                if (bytesReadSoFar <= 0 || bytesReadSoFar > 1024)
                    return IntPtr.Zero;
                if (info.offset < bytesReadSoFar || info.offset - bytesReadSoFar > 1024)
                    return IntPtr.Zero;
                stbi__skip(s, info.offset - bytesReadSoFar);
            }

            s.ImgN = (info.bpp == 24 && info.ma == 0xff000000) ? 3 : (info.ma != 0 ? 4 : 3);
            target = (reqComp != 0 && reqComp >= 3) ? reqComp : s.ImgN;

            if (Stbimad3Sizesvalid(target, (int) s.ImgX, (int) s.ImgY, 0) == 0)
                return IntPtr.Zero;

            output = new byte[target * (int) s.ImgX * (int) s.ImgY];
            if (output == null)
                return IntPtr.Zero;

            if (info.bpp < 16)
            {
                if (psize == 0 || psize > 256)
                    return IntPtr.Zero;

                for (int i = 0; i < psize; ++i)
                {
                    pal[i][2] = stbi__get8(s);
                    pal[i][1] = stbi__get8(s);
                    pal[i][0] = stbi__get8(s);
                    if (info.hsz != 12) stbi__get8(s);
                    pal[i][3] = 255;
                }

                stbi__skip(s, info.offset - info.extra_read - info.hsz - psize * (info.hsz == 12 ? 3 : 4));

                if (info.bpp == 1)
                    width = ((int) s.ImgX + 7) >> 3;
                else if (info.bpp == 4)
                    width = ((int) s.ImgX + 1) >> 1;
                else if (info.bpp == 8)
                    width = (int) s.ImgX;
                else
                    return IntPtr.Zero;

                pad = -width & 3;

                for (int j = 0; j < (int) s.ImgY; ++j)
                {
                    int i = 0;
                    if (info.bpp == 1)
                    {
                        int bitOffset = 7;
                        int v = stbi__get8(s);
                        for (; i < (int) s.ImgX; ++i)
                        {
                            int color = (v >> bitOffset) & 0x1;
                            Array.Copy(pal[color], 0, output, z, 3);
                            z += 3;
                            if (target == 4) output[z++] = 255;
                            if (--bitOffset < 0 && i + 1 < (int) s.ImgX)
                            {
                                bitOffset = 7;
                                v = stbi__get8(s);
                            }
                        }
                    }
                    else
                    {
                        for (; i < (int) s.ImgX; i += 2)
                        {
                            int v = stbi__get8(s);
                            int v2 = 0;
                            if (info.bpp == 4)
                            {
                                v2 = v & 15;
                                v >>= 4;
                            }

                            Array.Copy(pal[v], 0, output, z, 3);
                            z += 3;
                            if (target == 4) output[z++] = 255;

                            if (i + 1 == (int) s.ImgX) break;

                            v = info.bpp == 8 ? stbi__get8(s) : v2;
                            Array.Copy(pal[v], 0, output, z, 3);
                            z += 3;
                            if (target == 4) output[z++] = 255;
                        }
                    }

                    stbi__skip(s, pad);
                }
            }
            else
            {
                stbi__skip(s, info.offset - info.extra_read - info.hsz);
                width = info.bpp == 24 ? 3 * (int) s.ImgX : 2 * (int) s.ImgX;
                pad = -width & 3;

                for (int j = 0; j < (int) s.ImgY; ++j)
                {
                    for (int i = 0; i < (int) s.ImgX; ++i)
                    {
                        byte r, g, b, a = 255;
                        if (info.bpp == 24 || info.bpp == 32)
                        {
                            b = stbi__get8(s);
                            g = stbi__get8(s);
                            r = stbi__get8(s);
                            if (info.bpp == 32) a = stbi__get8(s);
                        }
                        else if (info.bpp == 16)
                        {
                            int val = Stbiget16Le(s);
                            r = (byte) (((val & info.mr) >> Stbihighbit(info.mr)) << 3);
                            g = (byte) (((val & info.mg) >> Stbihighbit(info.mg)) << 3);
                            b = (byte) (((val & info.mb) >> Stbihighbit(info.mb)) << 3);
                            a = (info.ma != 0) ? (byte) (((val & info.ma) >> Stbihighbit(info.ma)) << 3) : (byte) 255;
                        }
                        else
                        {
                            return IntPtr.Zero;
                        }

                        output[z++] = r;
                        output[z++] = g;
                        output[z++] = b;
                        if (target == 4) output[z++] = a;
                    }

                    stbi__skip(s, pad);
                }
            }

            x = (int) s.ImgX;
            y = (int) s.ImgY;
            comp = s.ImgN;
            
            // Asignar memoria no administrada y copiar los datos
            IntPtr unmanagedOutput = Marshal.AllocHGlobal(output.Length);
            Marshal.Copy(output, 0, unmanagedOutput, output.Length);

            return unmanagedOutput;
        }


        /// <summary>
        ///     Stbis the bmp info using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int Stbibmpinfo(StbiContext s, out int x, out int y, out int comp)
        {
            StbiBmpData info = new StbiBmpData();
            info.all_a = 255;
        
            IntPtr p = Stbibmpparseheader(s, ref info);
            if (p == IntPtr.Zero)
            {
                Stbirewind(s);
                x = 0;
                y = 0;
                comp = 0;
                return 0;
            }
        
            x = (int)s.ImgX;
            y = (int)s.ImgY;
        
            if ((info.bpp == 24) && (info.ma == 0xff000000))
            {
                comp = 3;
            }
            else
            {
                comp = info.ma != 0 ? 4 : 3;
            }
        
            return 1;
        }

        /// <summary>
        ///     Stbis the bmp test raw using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static int Stbibmptestraw(StbiContext s)
        {
            int r = 0;
            int sz = 0;
            if (stbi__get8(s) != 66)
            {
                return 0;
            }

            if (stbi__get8(s) != 77)
            {
                return 0;
            }

            Stbiget32Le(s);
            Stbiget16Le(s);
            Stbiget16Le(s);
            Stbiget32Le(s);
            sz = (int) Stbiget32Le(s);
            r = sz == 12 || sz == 40 || sz == 56 || sz == 108 || sz == 124 ? 1 : 0;
            return r;
        }

      public static int Stbibmpsetmaskdefaults(ref StbiBmpData info, int compress)
      {
          if (compress == 3)
          {
              return 1;
          }
      
          if (compress == 0)
          {
              if (info.bpp == 16)
              {
                  info.mr = 31u << 10;
                  info.mg = 31u << 5;
                  info.mb = 31u << 0;
              }
              else if (info.bpp == 32)
              {
                  info.mr = 0xffu << 16;
                  info.mg = 0xffu << 8;
                  info.mb = 0xffu << 0;
                  info.ma = 0xffu << 24;
                  info.all_a = 0;
              }
              else
              {
                  info.mr = info.mg = info.mb = info.ma = 0;
              }
      
              return 1;
          }
      
          return 0;
      }

       public static IntPtr Stbibmpparseheader(StbiContext s, ref StbiBmpData info)
       {
           int hsz = 0;
           if (StbImage.stbi__get8(s) != 66 || StbImage.stbi__get8(s) != 77)
           {
               return IntPtr.Zero;
           }
       
           StbImage.Stbiget32Le(s);
           StbImage.Stbiget16Le(s);
           StbImage.Stbiget16Le(s);
           info.offset = (int)StbImage.Stbiget32Le(s);
           info.hsz = hsz = (int)StbImage.Stbiget32Le(s);
           info.mr = info.mg = info.mb = info.ma = 0;
           info.extra_read = 14;
       
           if (info.offset < 0)
           {
               return IntPtr.Zero;
           }
       
           if (hsz != 12 && hsz != 40 && hsz != 56 && hsz != 108 && hsz != 124)
           {
               return IntPtr.Zero;
           }
       
           if (hsz == 12)
           {
               s.ImgX = (uint)StbImage.Stbiget16Le(s);
               s.ImgY = (uint)StbImage.Stbiget16Le(s);
           }
           else
           {
               s.ImgX = StbImage.Stbiget32Le(s);
               s.ImgY = StbImage.Stbiget32Le(s);
           }
       
           if (StbImage.Stbiget16Le(s) != 1)
           {
               return IntPtr.Zero;
           }
       
           info.bpp = StbImage.Stbiget16Le(s);
           if (hsz != 12)
           {
               int compress = (int)StbImage.Stbiget32Le(s);
               if (compress == 1 || compress == 2 || compress >= 4)
               {
                   return IntPtr.Zero;
               }
       
               if (compress == 3 && info.bpp != 16 && info.bpp != 32)
               {
                   return IntPtr.Zero;
               }
       
               StbImage.Stbiget32Le(s);
               StbImage.Stbiget32Le(s);
               StbImage.Stbiget32Le(s);
               StbImage.Stbiget32Le(s);
               StbImage.Stbiget32Le(s);
       
               if (hsz == 40 || hsz == 56)
               {
                   if (hsz == 56)
                   {
                       StbImage.Stbiget32Le(s);
                       StbImage.Stbiget32Le(s);
                       StbImage.Stbiget32Le(s);
                       StbImage.Stbiget32Le(s);
                   }
       
                   if (info.bpp == 16 || info.bpp == 32)
                   {
                       if (compress == 0)
                       {
                           Stbibmpsetmaskdefaults(ref info, compress);
                       }
                       else if (compress == 3)
                       {
                           info.mr = StbImage.Stbiget32Le(s);
                           info.mg = StbImage.Stbiget32Le(s);
                           info.mb = StbImage.Stbiget32Le(s);
                           info.extra_read += 12;
       
                           if (info.mr == info.mg && info.mg == info.mb)
                           {
                               return IntPtr.Zero;
                           }
                       }
                       else
                       {
                           return IntPtr.Zero;
                       }
                   }
               }
               else
               {
                   if (hsz != 108 && hsz != 124)
                   {
                       return IntPtr.Zero;
                   }
       
                   info.mr = StbImage.Stbiget32Le(s);
                   info.mg = StbImage.Stbiget32Le(s);
                   info.mb = StbImage.Stbiget32Le(s);
                   info.ma = StbImage.Stbiget32Le(s);
       
                   if (compress != 3)
                   {
                       Stbibmpsetmaskdefaults(ref info, compress);
                   }
       
                   StbImage.Stbiget32Le(s);
                   for (int i = 0; i < 12; ++i)
                   {
                       StbImage.Stbiget32Le(s);
                   }
       
                   if (hsz == 124)
                   {
                       StbImage.Stbiget32Le(s);
                       StbImage.Stbiget32Le(s);
                       StbImage.Stbiget32Le(s);
                       StbImage.Stbiget32Le(s);
                   }
               }
           }
       
           return new IntPtr(1);
       }
    }
}