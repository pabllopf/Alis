// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotColormap.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Predefined colormaps available in ImPlot for coloring data series.
    /// </summary>
    public enum ImPlotColormap
    {
        /// <summary>
        ///     Deep color gradient (dark blues and greens).
        /// </summary>
        Deep = 0,

        /// <summary>
        ///     Dark color gradient (dark tones).
        /// </summary>
        Dark = 1,

        /// <summary>
        ///     Pastel color gradient (soft, light colors).
        /// </summary>
        Pastel = 2,

        /// <summary>
        ///     Paired color map (alternating colors suitable for categories).
        /// </summary>
        Paired = 3,

        /// <summary>
        ///     Viridis perceptually uniform colormap (green-blue-purple-yellow).
        /// </summary>
        Viridis = 4,

        /// <summary>
        ///     Plasma perceptually uniform colormap (dark blue to bright yellow).
        /// </summary>
        Plasma = 5,

        /// <summary>
        ///     Hot colormap (black through red, orange, yellow to white).
        /// </summary>
        Hot = 6,

        /// <summary>
        ///     Cool colormap (cyan to magenta gradient).
        /// </summary>
        Cool = 7,

        /// <summary>
        ///     Pink colormap (dark to light pink tones).
        /// </summary>
        Pink = 8,

        /// <summary>
        ///     Jet colormap (blue-cyan-yellow-orange-red).
        /// </summary>
        Jet = 9,

        /// <summary>
        ///     Twilight colormap (cyclic blue-red-blue).
        /// </summary>
        Twilight = 10,

        /// <summary>
        ///     Red-Blue diverging colormap.
        /// </summary>
        RdBu = 11,

        /// <summary>
        ///     Brown-Blue-Green diverging colormap.
        /// </summary>
        BrBg = 12,

        /// <summary>
        ///     Pink-Yellow-Green diverging colormap.
        /// </summary>
        PiYg = 13,

        /// <summary>
        ///     Spectral colormap (rainbow, high contrast).
        /// </summary>
        Spectral = 14,

        /// <summary>
        ///     Greyscale colormap (black to white).
        /// </summary>
        Greys = 15
    }
}