using System;
                using System.Runtime.InteropServices.JavaScript;
                
                namespace Alis.Sample.King.Platform.Web
                {
                    /// <summary>
                    /// The interop class
                    /// </summary>
                    internal static partial class Interop
                    {
                        /// <summary>
                        /// Initializes
                        /// </summary>
                        [JSImport("initialize", "main.js")]
                        public static partial void Initialize();
                        
                        /// <summary>
                        /// Ons the key down using the specified shift
                        /// </summary>
                        /// <param name="shift">The shift</param>
                        /// <param name="ctrl">The ctrl</param>
                        /// <param name="alt">The alt</param>
                        /// <param name="repeat">The repeat</param>
                        /// <param name="code">The code</param>
                        [JSExport]
                        public static void OnKeyDown(bool shift, bool ctrl, bool alt, bool repeat, int code)
                        {
                        }
                        
                        /// <summary>
                        /// Ons the key up using the specified shift
                        /// </summary>
                        /// <param name="shift">The shift</param>
                        /// <param name="ctrl">The ctrl</param>
                        /// <param name="alt">The alt</param>
                        /// <param name="code">The code</param>
                        [JSExport]
                        public static void OnKeyUp(bool shift, bool ctrl, bool alt, int code)
                        {
                        }
                        
                        /// <summary>
                        /// Ons the mouse move using the specified x
                        /// </summary>
                        /// <param name="x">The </param>
                        /// <param name="y">The </param>
                        [JSExport]
                        public static void OnMouseMove(float x, float y)
                        {
                        }
                        
                        /// <summary>
                        /// Ons the mouse down using the specified shift
                        /// </summary>
                        /// <param name="shift">The shift</param>
                        /// <param name="ctrl">The ctrl</param>
                        /// <param name="alt">The alt</param>
                        /// <param name="button">The button</param>
                        [JSExport]
                        public static void OnMouseDown(bool shift, bool ctrl, bool alt, int button)
                        {
                        }
                        
                        /// <summary>
                        /// Ons the mouse up using the specified shift
                        /// </summary>
                        /// <param name="shift">The shift</param>
                        /// <param name="ctrl">The ctrl</param>
                        /// <param name="alt">The alt</param>
                        /// <param name="button">The button</param>
                        [JSExport]
                        public static void OnMouseUp(bool shift, bool ctrl, bool alt, int button)
                        {
                        }
                        
                        /// <summary>
                        /// Ons the canvas resize using the specified width
                        /// </summary>
                        /// <param name="width">The width</param>
                        /// <param name="height">The height</param>
                        /// <param name="devicePixelRatio">The device pixel ratio</param>
                        [JSExport]
                        public static void OnCanvasResize(float width, float height, float devicePixelRatio)
                        {
                            EntryPoint.CanvasResized((int)width, (int)height);
                        }
                        
                        /// <summary>
                        /// Sets the root uri using the specified uri
                        /// </summary>
                        /// <param name="uri">The uri</param>
                        [JSExport]
                        public static void SetRootUri(string uri)
                        {
                            EntryPoint.BaseAddress = new Uri(uri);
                        }
                        
                        /// <summary>
                        /// Adds the locale using the specified locale
                        /// </summary>
                        /// <param name="locale">The locale</param>
                        [JSExport]
                        public static void AddLocale(string locale)
                        {
                        }
                    }
                }
