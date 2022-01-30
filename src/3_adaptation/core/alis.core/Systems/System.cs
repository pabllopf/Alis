// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   System.cs
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

namespace Alis.Core.Systems
{
    /// <summary>Define a system.</summary>
    public abstract class System
    {
        /// <summary>Awakes this instance.</summary>
        public abstract void Awake();

        /// <summary>Starts this instance.</summary>
        public abstract void Start();

        /// <summary>Befores the update.</summary>
        public abstract void BeforeUpdate();

        /// <summary>Updates this instance.</summary>
        public abstract void Update();

        /// <summary>Afters the update.</summary>
        public abstract void AfterUpdate();

        /// <summary>Fixeds the update.</summary>
        public abstract void FixedUpdate();

        /// <summary>Dispatches the events.</summary>
        public abstract void DispatchEvents();

        /// <summary>Resets this instance.</summary>
        public abstract void Reset();

        /// <summary>Stops this instance.</summary>
        public abstract void Stop();

        /// <summary>Exits this instance.</summary>
        public abstract void Exit();
    }
}