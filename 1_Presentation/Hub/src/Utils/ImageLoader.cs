

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Graphic;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.App.Hub.Utils
{
    /// <summary>
    ///     The image loader class
    /// </summary>
    public static class ImageLoader
    {
        /// <summary>
        ///     The ordinal ignore case
        /// </summary>
        private static readonly Dictionary<string, CachedTexture> s_cache = new Dictionary<string, CachedTexture>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     The lock
        /// </summary>
        private static readonly object s_lock = new object();

        /// <summary>
        ///     The from minutes
        /// </summary>
        private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(5);

        /// <summary>
        ///     Loads the texture from file using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <exception cref="FileNotFoundException">Image not found in resources: {key}</exception>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadTextureFromFile(string filePath)
        {
            string key = Path.GetFileName(filePath) ?? filePath;

            lock (s_lock)
            {
                if (s_cache.TryGetValue(key, out CachedTexture cached))
                {
                    cached.RefCount++;
                    cached.LastAccessUtc = DateTime.UtcNow;
                    return (IntPtr) cached.TextureId;
                }
            }

            Image image = Image.LoadImageFromResources(key);
            if (image == null)
            {
                throw new FileNotFoundException($"Image not found in resources: {key}");
            }

            uint texture = 0;
            GCHandle imageHandle = default(GCHandle);
            try
            {
                texture = Gl.GenTexture();
                Gl.GlBindTexture(TextureTarget.Texture2D, texture);

                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);

                imageHandle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imageHandle.AddrOfPinnedObject());

                Gl.GenerateMipmap(TextureTarget.Texture2D);
                Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            }
            catch
            {
                if (texture != 0)
                {
                    try
                    {
                        Gl.DeleteTexture(texture);
                    }
                    catch
                    {
                        /* ignore */
                    }
                }

                throw;
            }
            finally
            {
                if (imageHandle.IsAllocated)
                {
                    imageHandle.Free();
                }
            }

            CachedTexture entry = new CachedTexture
            {
                TextureId = texture,
                Width = image.Width,
                Height = image.Height,
                RefCount = 1,
                LastAccessUtc = DateTime.UtcNow
            };

            lock (s_lock)
            {
                if (s_cache.TryGetValue(key, out CachedTexture existing))
                {
                    try
                    {
                        Gl.DeleteTexture(texture);
                    }
                    catch
                    {
                        /* ignore */
                    }

                    existing.RefCount++;
                    existing.LastAccessUtc = DateTime.UtcNow;
                    return (IntPtr) existing.TextureId;
                }

                s_cache[key] = entry;
            }

            return (IntPtr) texture;
        }

        /// <summary>
        ///     Releases the texture using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        public static void ReleaseTexture(string filePath)
        {
            string key = Path.GetFileName(filePath) ?? filePath;

            lock (s_lock)
            {
                if (!s_cache.TryGetValue(key, out CachedTexture cached))
                {
                    return;
                }

                cached.RefCount = Math.Max(0, cached.RefCount - 1);
                if (cached.RefCount == 0)
                {
                    try
                    {
                        Gl.DeleteTexture(cached.TextureId);
                    }
                    catch
                    {
                        /* ignore */
                    }

                    s_cache.Remove(key);
                }
                else
                {
                    cached.LastAccessUtc = DateTime.UtcNow;
                }
            }
        }

        /// <summary>
        ///     Clears the unused using the specified expiration
        /// </summary>
        /// <param name="expiration">The expiration</param>
        public static void ClearUnused(TimeSpan? expiration = null)
        {
            TimeSpan exp = expiration ?? DefaultExpiration;
            DateTime now = DateTime.UtcNow;
            List<string> toRemove = new List<string>();

            lock (s_lock)
            {
                foreach (KeyValuePair<string, CachedTexture> kv in s_cache)
                {
                    CachedTexture cached = kv.Value;
                    if ((cached.RefCount == 0) && (now - cached.LastAccessUtc >= exp))
                    {
                        toRemove.Add(kv.Key);
                    }
                }

                foreach (string key in toRemove)
                {
                    if (s_cache.TryGetValue(key, out CachedTexture cached))
                    {
                        try
                        {
                            Gl.DeleteTexture(cached.TextureId);
                        }
                        catch
                        {
                            /* ignore */
                        }

                        s_cache.Remove(key);
                    }
                }
            }
        }

        /// <summary>
        ///     The cached texture class
        /// </summary>
        private class CachedTexture
        {
            /// <summary>
            ///     The height
            /// </summary>
            public int Height;

            /// <summary>
            ///     The last access utc
            /// </summary>
            public DateTime LastAccessUtc;

            /// <summary>
            ///     The ref count
            /// </summary>
            public int RefCount;

            /// <summary>
            ///     The texture id
            /// </summary>
            public uint TextureId;

            /// <summary>
            ///     The width
            /// </summary>
            public int Width;
        }
    }
}