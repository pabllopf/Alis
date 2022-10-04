// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Context.cs
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
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    //////////////////////////////////////////////////////////////////
    /// <summary>
    ///     This class defines a .NET interface to an SFML OpenGL Context
    /// </summary>
    //////////////////////////////////////////////////////////////////
    public class Context
    {

        /// <summary>
        ///     The our global context
        /// </summary>
        private static Context _ourGlobalContext;

        /// <summary>
        ///     The zero
        /// </summary>
        private readonly IntPtr myThis = IntPtr.Zero;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Context() => myThis = sfContext_create();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the settings of the context.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public ContextSettings Settings => sfContext_getSettings(myThis);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Global helper context
        /// </summary>
        ////////////////////////////////////////////////////////////
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

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Finalizer
        /// </summary>
        ////////////////////////////////////////////////////////////
        ~Context()
        {
            sfContext_destroy(myThis);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Activate or deactivate the context
        /// </summary>
        /// <param name="active">True to activate, false to deactivate</param>
        /// <returns>true on success, false on failure</returns>
        ////////////////////////////////////////////////////////////
        public bool SetActive(bool active) => sfContext_setActive(myThis, active);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[Context]";

        /// <summary>
        ///     Sfs the context create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfContext_create();

        /// <summary>
        ///     Sfs the context destroy using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfContext_destroy(IntPtr view);

        /// <summary>
        ///     Describes whether sf context set active
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="active">The active</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfContext_setActive(IntPtr view, bool active);

        /// <summary>
        ///     Sfs the context get settings using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The context settings</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern ContextSettings sfContext_getSettings(IntPtr view);
    }
}