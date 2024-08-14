// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StoreParameter.cs
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

namespace Alis.Extension.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The pixel store parameter enum
    /// </summary>
    public enum StoreParameter
    {
        /// <summary>
        ///     The unpack swap bytes pixel store parameter
        /// </summary>
        UnpackSwapBytes = 0x0CF0,
        
        /// <summary>
        ///     The unpack lsb first pixel store parameter
        /// </summary>
        UnpackLsbFirst = 0x0CF1,
        
        /// <summary>
        ///     The unpack row length pixel store parameter
        /// </summary>
        UnpackRowLength = 0x0CF2,
        
        /// <summary>
        ///     The unpack skip rows pixel store parameter
        /// </summary>
        UnpackSkipRows = 0x0CF3,
        
        /// <summary>
        ///     The unpack skip pixels pixel store parameter
        /// </summary>
        UnpackSkipPixels = 0x0CF4,
        
        /// <summary>
        ///     The unpack alignment pixel store parameter
        /// </summary>
        UnpackAlignment = 0x0CF5,
        
        /// <summary>
        ///     The pack swap bytes pixel store parameter
        /// </summary>
        PackSwapBytes = 0x0D00,
        
        /// <summary>
        ///     The pack lsb first pixel store parameter
        /// </summary>
        PackLsbFirst = 0x0D01,
        
        /// <summary>
        ///     The pack row length pixel store parameter
        /// </summary>
        PackRowLength = 0x0D02,
        
        /// <summary>
        ///     The pack skip rows pixel store parameter
        /// </summary>
        PackSkipRows = 0x0D03,
        
        /// <summary>
        ///     The pack skip pixels pixel store parameter
        /// </summary>
        PackSkipPixels = 0x0D04,
        
        /// <summary>
        ///     The pack alignment pixel store parameter
        /// </summary>
        PackAlignment = 0x0D05,
        
        /// <summary>
        ///     The pack skip images pixel store parameter
        /// </summary>
        PackSkipImages = 0x806B,
        
        /// <summary>
        ///     The pack skip images ext pixel store parameter
        /// </summary>
        PackSkipImagesExt = 0x806B,
        
        /// <summary>
        ///     The pack image height pixel store parameter
        /// </summary>
        PackImageHeight = 0x806C,
        
        /// <summary>
        ///     The pack image height ext pixel store parameter
        /// </summary>
        PackImageHeightExt = 0x806C,
        
        /// <summary>
        ///     The unpack skip images pixel store parameter
        /// </summary>
        UnpackSkipImages = 0x806D,
        
        /// <summary>
        ///     The unpack skip images ext pixel store parameter
        /// </summary>
        UnpackSkipImagesExt = 0x806D,
        
        /// <summary>
        ///     The unpack image height pixel store parameter
        /// </summary>
        UnpackImageHeight = 0x806E,
        
        /// <summary>
        ///     The unpack image height ext pixel store parameter
        /// </summary>
        UnpackImageHeightExt = 0x806E,
        
        /// <summary>
        ///     The pack skip volumes sgis pixel store parameter
        /// </summary>
        PackSkipVolumesSgis = 0x8130,
        
        /// <summary>
        ///     The pack image depth sgis pixel store parameter
        /// </summary>
        PackImageDepthSgis = 0x8131,
        
        /// <summary>
        ///     The unpack skip volumes sgis pixel store parameter
        /// </summary>
        UnpackSkipVolumesSgis = 0x8132,
        
        /// <summary>
        ///     The unpack image depth sgis pixel store parameter
        /// </summary>
        UnpackImageDepthSgis = 0x8133,
        
        /// <summary>
        ///     The pixel tile width sgix pixel store parameter
        /// </summary>
        TileWidthSgix = 0x8140,
        
        /// <summary>
        ///     The pixel tile height sgix pixel store parameter
        /// </summary>
        TileHeightSgix = 0x8141,
        
        /// <summary>
        ///     The pixel tile grid width sgix pixel store parameter
        /// </summary>
        TileGridWidthSgix = 0x8142,
        
        /// <summary>
        ///     The pixel tile grid height sgix pixel store parameter
        /// </summary>
        TileGridHeightSgix = 0x8143,
        
        /// <summary>
        ///     The pixel tile grid depth sgix pixel store parameter
        /// </summary>
        TileGridDepthSgix = 0x8144,
        
        /// <summary>
        ///     The pixel tile cache size sgix pixel store parameter
        /// </summary>
        TileCacheSizeSgix = 0x8145,
        
        /// <summary>
        ///     The pack resample sgix pixel store parameter
        /// </summary>
        PackResampleSgix = 0x842C,
        
        /// <summary>
        ///     The unpack resample sgix pixel store parameter
        /// </summary>
        UnpackResampleSgix = 0x842D,
        
        /// <summary>
        ///     The pack subsample rate sgix pixel store parameter
        /// </summary>
        PackSubsampleRateSgix = 0x85A0,
        
        /// <summary>
        ///     The unpack subsample rate sgix pixel store parameter
        /// </summary>
        UnpackSubsampleRateSgix = 0x85A1
    }
}