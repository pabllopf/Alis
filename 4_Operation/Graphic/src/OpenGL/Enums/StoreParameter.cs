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

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The pixel store parameter enum
    /// </summary>
    public enum StoreParameter
    {
        /// <summary>
        ///     Swaps byte order when unpacking pixels (GL_UNPACK_SWAP_BYTES)
        /// </summary>
        UnpackSwapBytes = 0x0CF0,

        /// <summary>
        ///     LSB-first bit order when unpacking pixels (GL_UNPACK_LSB_FIRST)
        /// </summary>
        UnpackLsbFirst = 0x0CF1,

        /// <summary>
        ///     Row length hint for unpacking pixel data (GL_UNPACK_ROW_LENGTH)
        /// </summary>
        UnpackRowLength = 0x0CF2,

        /// <summary>
        ///     Number of rows skipped when unpacking (GL_UNPACK_SKIP_ROWS)
        /// </summary>
        UnpackSkipRows = 0x0CF3,

        /// <summary>
        ///     Number of pixels skipped when unpacking (GL_UNPACK_SKIP_PIXELS)
        /// </summary>
        UnpackSkipPixels = 0x0CF4,

        /// <summary>
        ///     Memory alignment for unpacked pixel data (GL_UNPACK_ALIGNMENT)
        /// </summary>
        UnpackAlignment = 0x0CF5,

        /// <summary>
        ///     Swaps byte order when packing pixels (GL_PACK_SWAP_BYTES)
        /// </summary>
        PackSwapBytes = 0x0D00,

        /// <summary>
        ///     LSB-first bit order when packing pixels (GL_PACK_LSB_FIRST)
        /// </summary>
        PackLsbFirst = 0x0D01,

        /// <summary>
        ///     Row length hint for packing pixel data (GL_PACK_ROW_LENGTH)
        /// </summary>
        PackRowLength = 0x0D02,

        /// <summary>
        ///     Number of rows skipped when packing (GL_PACK_SKIP_ROWS)
        /// </summary>
        PackSkipRows = 0x0D03,

        /// <summary>
        ///     Number of pixels skipped when packing (GL_PACK_SKIP_PIXELS)
        /// </summary>
        PackSkipPixels = 0x0D04,

        /// <summary>
        ///     Memory alignment for packed pixel data (GL_PACK_ALIGNMENT)
        /// </summary>
        PackAlignment = 0x0D05,

        /// <summary>
        ///     Number of images skipped when packing (GL_PACK_SKIP_IMAGES)
        /// </summary>
        PackSkipImages = 0x806B,

        /// <summary>
        ///     Number of images skipped when packing, EXT version (GL_PACK_SKIP_IMAGES_EXT)
        /// </summary>
        PackSkipImagesExt = 0x806B,

        /// <summary>
        ///     Image height hint for packing pixel data (GL_PACK_IMAGE_HEIGHT)
        /// </summary>
        PackImageHeight = 0x806C,

        /// <summary>
        ///     Image height hint for packing pixel data, EXT version (GL_PACK_IMAGE_HEIGHT_EXT)
        /// </summary>
        PackImageHeightExt = 0x806C,

        /// <summary>
        ///     Number of images skipped when unpacking (GL_UNPACK_SKIP_IMAGES)
        /// </summary>
        UnpackSkipImages = 0x806D,

        /// <summary>
        ///     Number of images skipped when unpacking, EXT version (GL_UNPACK_SKIP_IMAGES_EXT)
        /// </summary>
        UnpackSkipImagesExt = 0x806D,

        /// <summary>
        ///     Image height hint for unpacking pixel data (GL_UNPACK_IMAGE_HEIGHT)
        /// </summary>
        UnpackImageHeight = 0x806E,

        /// <summary>
        ///     Image height hint for unpacking pixel data, EXT version (GL_UNPACK_IMAGE_HEIGHT_EXT)
        /// </summary>
        UnpackImageHeightExt = 0x806E,

        /// <summary>
        ///     Number of volumes skipped when packing, SGIS (GL_PACK_SKIP_VOLUMES_SGIS)
        /// </summary>
        PackSkipVolumesSgis = 0x8130,

        /// <summary>
        ///     Image depth hint for packing, SGIS (GL_PACK_IMAGE_DEPTH_SGIS)
        /// </summary>
        PackImageDepthSgis = 0x8131,

        /// <summary>
        ///     Number of volumes skipped when unpacking, SGIS (GL_UNPACK_SKIP_VOLUMES_SGIS)
        /// </summary>
        UnpackSkipVolumesSgis = 0x8132,

        /// <summary>
        ///     Image depth hint for unpacking, SGIS (GL_UNPACK_IMAGE_DEPTH_SGIS)
        /// </summary>
        UnpackImageDepthSgis = 0x8133,

        /// <summary>
        ///     Pixel tile width, SGIX (GL_PIXEL_TILE_WIDTH_SGIX)
        /// </summary>
        TileWidthSgix = 0x8140,

        /// <summary>
        ///     Pixel tile height, SGIX (GL_PIXEL_TILE_HEIGHT_SGIX)
        /// </summary>
        TileHeightSgix = 0x8141,

        /// <summary>
        ///     Pixel tile grid width, SGIX (GL_PIXEL_TILE_GRID_WIDTH_SGIX)
        /// </summary>
        TileGridWidthSgix = 0x8142,

        /// <summary>
        ///     Pixel tile grid height, SGIX (GL_PIXEL_TILE_GRID_HEIGHT_SGIX)
        /// </summary>
        TileGridHeightSgix = 0x8143,

        /// <summary>
        ///     Pixel tile grid depth, SGIX (GL_PIXEL_TILE_GRID_DEPTH_SGIX)
        /// </summary>
        TileGridDepthSgix = 0x8144,

        /// <summary>
        ///     Pixel tile cache size, SGIX (GL_PIXEL_TILE_CACHE_SIZE_SGIX)
        /// </summary>
        TileCacheSizeSgix = 0x8145,

        /// <summary>
        ///     Pack resampling mode, SGIX (GL_PACK_RESAMPLE_SGIX)
        /// </summary>
        PackResampleSgix = 0x842C,

        /// <summary>
        ///     Unpack resampling mode, SGIX (GL_UNPACK_RESAMPLE_SGIX)
        /// </summary>
        UnpackResampleSgix = 0x842D,

        /// <summary>
        ///     Pack subsample rate, SGIX (GL_PACK_SUBSAMPLE_RATE_SGIX)
        /// </summary>
        PackSubsampleRateSgix = 0x85A0,

        /// <summary>
        ///     Unpack subsample rate, SGIX (GL_UNPACK_SUBSAMPLE_RATE_SGIX)
        /// </summary>
        UnpackSubsampleRateSgix = 0x85A1
    }
}