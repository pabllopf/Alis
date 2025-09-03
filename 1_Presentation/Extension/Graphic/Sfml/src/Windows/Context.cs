using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Data.Dll;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    //////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class defines a .NET interface to an SFML OpenGL Context
    /// </summary>
    //////////////////////////////////////////////////////////////////
    public class Context : CriticalFinalizerObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class
        /// </summary>
        static Context() 
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("sfml", DllType.File, Properties.SfmlDlls.SfmlDllBytes, Assembly.GetAssembly(typeof(Properties.SfmlDlls)));
        }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        
        public Context()
        {
            myThis = sfContext_create();
        }

        
        /// <summary>
        /// Finalizer
        /// </summary>
        
        ~Context()
        {
            sfContext_destroy(myThis);
        }

        
        /// <summary>
        /// Activate or deactivate the context
        /// </summary>
        /// <param name="active">True to activate, false to deactivate</param>
        /// <returns>true on success, false on failure</returns>
        
        public bool SetActive(bool active)
        {
            return sfContext_setActive(myThis, active);
        }

        
        /// <summary>
        /// Get the settings of the context.
        /// </summary>
        
        public ContextSettings Settings
        {
            get { return sfContext_getSettings(myThis); }
        }

        
        /// <summary>
        /// Global helper context
        /// </summary>
        
        public static Context Global
        {
            get
            {
                if (_ourGlobalContext == null)
                {
                    _ourGlobalContext = new Context();
                }

                return _ourGlobalContext;
            }
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[Context]";
        }

        /// <summary>
        /// The our global context
        /// </summary>
        private static Context _ourGlobalContext = null;

        /// <summary>
        /// The zero
        /// </summary>
        private readonly IntPtr myThis = IntPtr.Zero;

        #region Imports
        /// <summary>
        /// Sfs the context create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfContext_create();

        /// <summary>
        /// Sfs the context destroy using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfContext_destroy(IntPtr view);

        /// <summary>
        /// Sfs the context set active using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="active">The active</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfContext_setActive(IntPtr view, bool active);

        /// <summary>
        /// Sfs the context get settings using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The context settings</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern ContextSettings sfContext_getSettings(IntPtr view);
        #endregion
    }
}
