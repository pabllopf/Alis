
        
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Runtime.InteropServices;
        using Alis.Core.Graphic;
        using Alis.Core.Graphic.OpenGL;
        using Alis.Core.Graphic.OpenGL.Enums;

        namespace Alis.App.Hub.Utils
        {
            public static class ImageLoader
            {
               
                private class CachedTexture
                {
                    public uint TextureId;
                    public int Width;
                    public int Height;
                    public int RefCount;
                    public DateTime LastAccessUtc;
                }
        
                private static readonly Dictionary<string, CachedTexture> s_cache = new Dictionary<string, CachedTexture>(StringComparer.OrdinalIgnoreCase);
                private static readonly object s_lock = new object();
                private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(5);
        
                public static IntPtr LoadTextureFromFile(string filePath)
                {
                    string key = Path.GetFileName(filePath) ?? filePath;
        
                    lock (s_lock)
                    {
                        if (s_cache.TryGetValue(key, out var cached))
                        {
                            cached.RefCount++;
                            cached.LastAccessUtc = DateTime.UtcNow;
                            return (IntPtr)cached.TextureId;
                        }
                    }
        
                    // Si no está en caché, cargar la imagen y crear la textura GPU
                    Image image = Image.LoadImageFromResources(key);
                    if (image == null)
                        throw new FileNotFoundException($"Image not found in resources: {key}");
        
                    uint texture = 0;
                    GCHandle imageHandle = default;
                    try
                    {
                        texture = Gl.GenTexture();
                        Gl.GlBindTexture(TextureTarget.Texture2D, texture);
        
                        Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                        Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
                        Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                        Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
        
                        imageHandle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                        Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte,imageHandle.AddrOfPinnedObject());
        
                        Gl.GenerateMipmap(TextureTarget.Texture2D);
                        Gl.GlBindTexture(TextureTarget.Texture2D, 0);
                    }
                    catch
                    {
                        // en caso de error, intentar liberar la textura si fue creada
                        if (texture != 0)
                        {
                            try { Gl.DeleteTexture(texture); } catch { /* ignore */ }
                        }
                        throw;
                    }
                    finally
                    {
                        if (imageHandle.IsAllocated) imageHandle.Free();
                    }
        
                    var entry = new CachedTexture
                    {
                        TextureId = texture,
                        Width = image.Width,
                        Height = image.Height,
                        RefCount = 1,
                        LastAccessUtc = DateTime.UtcNow
                    };
        
                    lock (s_lock)
                    {
                        // doble comprobación por si otro hilo la cargó al mismo tiempo
                        if (s_cache.TryGetValue(key, out var existing))
                        {
                            // liberar la textura recién creada y usar la existente
                            try { Gl.DeleteTexture(texture); } catch { /* ignore */ }
                            existing.RefCount++;
                            existing.LastAccessUtc = DateTime.UtcNow;
                            return (IntPtr)existing.TextureId;
                        }
        
                        s_cache[key] = entry;
                    }
        
                    return (IntPtr)texture;
                }
        
                // Llamar cuando ya no necesites la textura (por ejemplo al cerrar una ventana)
                public static void ReleaseTexture(string filePath)
                {
                    string key = Path.GetFileName(filePath) ?? filePath;
        
                    lock (s_lock)
                    {
                        if (!s_cache.TryGetValue(key, out var cached)) return;
        
                        cached.RefCount = Math.Max(0, cached.RefCount - 1);
                        if (cached.RefCount == 0)
                        {
                            try { Gl.DeleteTexture(cached.TextureId); } catch { /* ignore */ }
                            s_cache.Remove(key);
                        }
                        else
                        {
                            cached.LastAccessUtc = DateTime.UtcNow;
                        }
                    }
                }
        
                // Elimina texturas no usadas por más tiempo (por defecto DefaultExpiration)
                public static void ClearUnused(TimeSpan? expiration = null)
                {
                    var exp = expiration ?? DefaultExpiration;
                    var now = DateTime.UtcNow;
                    List<string> toRemove = new List<string>();
        
                    lock (s_lock)
                    {
                        foreach (var kv in s_cache)
                        {
                            var cached = kv.Value;
                            if (cached.RefCount == 0 && (now - cached.LastAccessUtc) >= exp)
                            {
                                toRemove.Add(kv.Key);
                            }
                        }
        
                        foreach (var key in toRemove)
                        {
                            if (s_cache.TryGetValue(key, out var cached))
                            {
                                try { Gl.DeleteTexture(cached.TextureId); } catch { /* ignore */ }
                                s_cache.Remove(key);
                            }
                        }
                    }
                }
            }
        }