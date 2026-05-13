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
    /// Defines the pixel storage parameters used by glPixelStorei to control pixel data packing and unpacking.
    /// Affects how pixel data is read from and written to client memory during texture and framebuffer operations.
    /// </summary>
    public enum StoreParameter
    {
        /// <summary>Swap bytes for unpack operations (GL_UNPACK_SWAP_BYTES = 0x0CF0).</summary>
        UnpackSwapBytes = 0x0CF0,

        /// <summary>LSB first for unpack operations (GL_UNPACK_LSB_FIRST = 0x0CF1).</summary>
        UnpackLsbFirst = 0x0CF1,

        /// <summary>Row length for unpack operations (GL_UNPACK_ROW_LENGTH = 0x0CF2).</summary>
        UnpackRowLength = 0x0CF2,

        /// <summary>Skip rows for unpack operations (GL_UNPACK_SKIP_ROWS = 0x0CF3).</summary>
        UnpackSkipRows = 0x0CF3,

        /// <summary>Skip pixels for unpack operations (GL_UNPACK_SKIP_PIXELS = 0x0CF4).</summary>
        UnpackSkipPixels = 0x0CF4,

        /// <summary>Alignment for unpack operations (GL_UNPACK_ALIGNMENT = 0x0CF5).</summary>
        UnpackAlignment = 0x0CF5,

        /// <summary>Swap bytes for pack operations (GL_PACK_SWAP_BYTES = 0x0D00).</summary>
        PackSwapBytes = 0x0D00,

        /// <summary>LSB first for pack operations (GL_PACK_LSB_FIRST = 0x0D01).</summary>
        PackLsbFirst = 0x0D01,

        /// <summary>Row length for pack operations (GL_PACK_ROW_LENGTH = 0x0D02).</summary>
        PackRowLength = 0x0D02,

        /// <summary>Skip rows for pack operations (GL_PACK_SKIP_ROWS = 0x0D03).</summary>
        PackSkipRows = 0x0D03,

        /// <summary>Skip pixels for pack operations (GL_PACK_SKIP_PIXELS = 0x0D04).</summary>
        PackSkipPixels = 0x0D04,

        /// <summary>Alignment for pack operations (GL_PACK_ALIGNMENT = 0x0D05).</summary>
        PackAlignment = 0x0D05,

        /// <summary>Skip images for pack (GL_PACK_SKIP_IMAGES = 0x806B).</summary>
        PackSkipImages = 0x806B,

        /// <summary>Extension alias for pack skip images (GL_PACK_SKIP_IMAGES_EXT = 0x806B).</summary>
        PackSkipImagesExt = 0x806B,

        /// <summary>Image height for pack (GL_PACK_IMAGE_HEIGHT = 0x806C).</summary>
        PackImageHeight = 0x806C,

        /// <summary>Extension alias for pack image height (GL_PACK_IMAGE_HEIGHT_EXT = 0x806C).</summary>
        PackImageHeightExt = 0x806C,

        /// <summary>Skip images for unpack (GL_UNPACK_SKIP_IMAGES = 0x806D).</summary>
        UnpackSkipImages = 0x806D,

        /// <summary>Extension alias for unpack skip images (GL_UNPACK_SKIP_IMAGES_EXT = 0x806D).</summary>
        UnpackSkipImagesExt = 0x806D,

        /// <summary>Image height for unpack (GL_UNPACK_IMAGE_HEIGHT = 0x806E).</summary>
        UnpackImageHeight = 0x806E,

        /// <summary>Extension alias for unpack image height (GL_UNPACK_IMAGE_HEIGHT_EXT = 0x806E).</summary>
        UnpackImageHeightExt = 0x806E,

        /// <summary>Extension: skip volumes for pack (GL_PACK_SKIP_VOLUMES_SGIS = 0x8130).</summary>
        PackSkipVolumesSgis = 0x8130,

        /// <summary>Extension: image depth for pack (GL_PACK_IMAGE_DEPTH_SGIS = 0x8131).</summary>
        PackImageDepthSgis = 0x8131,

        /// <summary>Extension: skip volumes for unpack (GL_UNPACK_SKIP_VOLUMES_SGIS = 0x8132).</summary>
        UnpackSkipVolumesSgis = 0x8132,

        /// <summary>Extension: image depth for unpack (GL_UNPACK_IMAGE_DEPTH_SGIS = 0x8133).</summary>
        UnpackImageDepthSgis = 0x8133,

        /// <summary>Extension: tile width (GL_TILE_WIDTH_SGIX = 0x8140).</summary>
        TileWidthSgix = 0x8140,

        /// <summary>Extension: tile height (GL_TILE_HEIGHT_SGIX = 0x8141).</summary>
        TileHeightSgix = 0x8141,

        /// <summary>Extension: tile grid width (GL_TILE_GRID_WIDTH_SGIX = 0x8142).</summary>
        TileGridWidthSgix = 0x8142,

        /// <summary>Extension: tile grid height (GL_TILE_GRID_HEIGHT_SGIX = 0x8143).</summary>
        TileGridHeightSgix = 0x8143,

        /// <summary>Extension: tile grid depth (GL_TILE_GRID_DEPTH_SGIX = 0x8144).</summary>
        TileGridDepthSgix = 0x8144,

        /// <summary>Extension: tile cache size (GL_TILE_CACHE_SIZE_SGIX = 0x8145).</summary>
        TileCacheSizeSgix = 0x8145,

        /// <summary>Extension: pack resample (GL_PACK_RESAMPLE_SGIX = 0x842C).</summary>
        PackResampleSgix = 0x842C,

        /// <summary>Extension: unpack resample (GL_UNPACK_RESAMPLE_SGIX = 0x842D).</summary>
        UnpackResampleSgix = 0x842D,

        /// <summary>Extension: pack subsample rate (GL_PACK_SUBSAMPLE_RATE_SGIX = 0x85A0).</summary>
        PackSubsampleRateSgix = 0x85A0,

        /// <summary>Extension: unpack subsample rate (GL_UNPACK_SUBSAMPLE_RATE_SGIX = 0x85A1).</summary>
        UnpackSubsampleRateSgix = 0x85A1
    }
}
