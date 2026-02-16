// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IContextHandler.cs
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

namespace Alis.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     The runner interface
    /// </summary>
    public interface IContextHandler<T>
    {
        /// <summary>
        ///     Gets the value of the context
        /// </summary>
        T Context { get; }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        void Run();

        /// <summary>
        ///     Exits this instance
        /// </summary>
        void Exit();

        /// <summary>
        ///     Saves this instance
        /// </summary>
        void Save();

        /// <summary>
        ///     Loads this instance
        /// </summary>
        void Load();

        /// <summary>
        ///     Loads the and run
        /// </summary>
        void LoadAndRun();

        /// <summary>
        /// Inits the preview
        /// </summary>
        void InitPreview();

        /// <summary>
        /// Previews this instance
        /// </summary>
        void Preview();
    }
}