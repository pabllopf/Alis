// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdsManager.cs
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

using Alis.Core.EcsOld.System.Manager;
using Alis.Core.EcsOld.System.Scope;

namespace Alis.Extension.Ads.GoogleAds
{
    /// <summary>
    ///     The ads manager class
    /// </summary>
    /// <seealso cref="AManager" />
    /// <seealso cref="IAdsManager" />
    public class AdsManager : AManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdsManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public AdsManager(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdsManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        public AdsManager(string id, string name, string tag, bool isEnable, Context context) : base(id, name, tag, isEnable, context)
        {
        }
    }
}