// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StoreParameterTest.cs
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
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the StoreParameter enum validating pixel store parameters.
    /// </summary>
    public class StoreParameterTest
    {
        /// <summary>
        /// Tests that unpack swap bytes has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackSwapBytes_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF0, (int)StoreParameter.UnpackSwapBytes); }

        /// <summary>
        /// Tests that unpack lsb first has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackLsbFirst_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF1, (int)StoreParameter.UnpackLsbFirst); }

        /// <summary>
        /// Tests that unpack row length has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackRowLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF2, (int)StoreParameter.UnpackRowLength); }

        /// <summary>
        /// Tests that unpack skip rows has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackSkipRows_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF3, (int)StoreParameter.UnpackSkipRows); }

        /// <summary>
        /// Tests that unpack skip pixels has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackSkipPixels_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF4, (int)StoreParameter.UnpackSkipPixels); }

        /// <summary>
        /// Tests that unpack alignment has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackAlignment_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF5, (int)StoreParameter.UnpackAlignment); }

        /// <summary>
        /// Tests that pack swap bytes has correct value equals expected
        /// </summary>
        [Fact]
        public void PackSwapBytes_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D00, (int)StoreParameter.PackSwapBytes); }

        /// <summary>
        /// Tests that pack lsb first has correct value equals expected
        /// </summary>
        [Fact]
        public void PackLsbFirst_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D01, (int)StoreParameter.PackLsbFirst); }

        /// <summary>
        /// Tests that pack row length has correct value equals expected
        /// </summary>
        [Fact]
        public void PackRowLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D02, (int)StoreParameter.PackRowLength); }

        /// <summary>
        /// Tests that pack skip rows has correct value equals expected
        /// </summary>
        [Fact]
        public void PackSkipRows_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D03, (int)StoreParameter.PackSkipRows); }

        /// <summary>
        /// Tests that pack skip pixels has correct value equals expected
        /// </summary>
        [Fact]
        public void PackSkipPixels_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D04, (int)StoreParameter.PackSkipPixels); }

        /// <summary>
        /// Tests that pack alignment has correct value equals expected
        /// </summary>
        [Fact]
        public void PackAlignment_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D05, (int)StoreParameter.PackAlignment); }

        /// <summary>
        /// Tests that pack skip images has correct value equals expected
        /// </summary>
        [Fact]
        public void PackSkipImages_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806B, (int)StoreParameter.PackSkipImages); }

        /// <summary>
        /// Tests that pack skip images ext has correct value equals expected
        /// </summary>
        [Fact]
        public void PackSkipImagesExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806B, (int)StoreParameter.PackSkipImagesExt); }

        /// <summary>
        /// Tests that pack image height has correct value equals expected
        /// </summary>
        [Fact]
        public void PackImageHeight_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806C, (int)StoreParameter.PackImageHeight); }

        /// <summary>
        /// Tests that pack image height ext has correct value equals expected
        /// </summary>
        [Fact]
        public void PackImageHeightExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806C, (int)StoreParameter.PackImageHeightExt); }

        /// <summary>
        /// Tests that unpack skip images has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackSkipImages_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806D, (int)StoreParameter.UnpackSkipImages); }

        /// <summary>
        /// Tests that unpack skip images ext has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackSkipImagesExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806D, (int)StoreParameter.UnpackSkipImagesExt); }

        /// <summary>
        /// Tests that unpack image height has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackImageHeight_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806E, (int)StoreParameter.UnpackImageHeight); }

        /// <summary>
        /// Tests that unpack image height ext has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackImageHeightExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806E, (int)StoreParameter.UnpackImageHeightExt); }

        /// <summary>
        /// Tests that pack skip volumes sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void PackSkipVolumesSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8130, (int)StoreParameter.PackSkipVolumesSgis); }

        /// <summary>
        /// Tests that pack image depth sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void PackImageDepthSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8131, (int)StoreParameter.PackImageDepthSgis); }

        /// <summary>
        /// Tests that unpack skip volumes sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackSkipVolumesSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8132, (int)StoreParameter.UnpackSkipVolumesSgis); }

        /// <summary>
        /// Tests that unpack image depth sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackImageDepthSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8133, (int)StoreParameter.UnpackImageDepthSgis); }

        /// <summary>
        /// Tests that tile width sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void TileWidthSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8140, (int)StoreParameter.TileWidthSgix); }

        /// <summary>
        /// Tests that tile height sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void TileHeightSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8141, (int)StoreParameter.TileHeightSgix); }

        /// <summary>
        /// Tests that tile grid width sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void TileGridWidthSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8142, (int)StoreParameter.TileGridWidthSgix); }

        /// <summary>
        /// Tests that tile grid height sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void TileGridHeightSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8143, (int)StoreParameter.TileGridHeightSgix); }

        /// <summary>
        /// Tests that tile grid depth sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void TileGridDepthSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8144, (int)StoreParameter.TileGridDepthSgix); }

        /// <summary>
        /// Tests that tile cache size sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void TileCacheSizeSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8145, (int)StoreParameter.TileCacheSizeSgix); }

        /// <summary>
        /// Tests that pack resample sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void PackResampleSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x842C, (int)StoreParameter.PackResampleSgix); }

        /// <summary>
        /// Tests that unpack resample sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackResampleSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x842D, (int)StoreParameter.UnpackResampleSgix); }

        /// <summary>
        /// Tests that pack subsample rate sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void PackSubsampleRateSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x85A0, (int)StoreParameter.PackSubsampleRateSgix); }

        /// <summary>
        /// Tests that unpack subsample rate sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void UnpackSubsampleRateSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x85A1, (int)StoreParameter.UnpackSubsampleRateSgix); }

        /// <summary>
        /// Tests that store parameter is enum type is correct
        /// </summary>
        [Fact]
        public void StoreParameter_IsEnum_TypeIsCorrect() { Assert.True(typeof(StoreParameter).IsEnum); }

        /// <summary>
        /// Tests that store parameter is public can be accessed
        /// </summary>
        [Fact]
        public void StoreParameter_IsPublic_CanBeAccessed() { Assert.True(typeof(StoreParameter).IsPublic); }

        /// <summary>
        /// Tests that store parameter has multiple values count is not zero
        /// </summary>
        [Fact]
        public void StoreParameter_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(StoreParameter));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that store parameter can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void StoreParameter_CanCastToInt_ConversionIsValid()
        {
            int value = (int)StoreParameter.UnpackAlignment;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that store parameter can compare values equality works
        /// </summary>
        [Fact]
        public void StoreParameter_CanCompareValues_EqualityWorks()
        {
            StoreParameter param1 = StoreParameter.UnpackAlignment;
            StoreParameter param2 = StoreParameter.UnpackAlignment;
            Assert.Equal(param1, param2);
        }

        /// <summary>
        /// Tests that store parameter different values are not equal
        /// </summary>
        [Fact]
        public void StoreParameter_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(StoreParameter.UnpackAlignment, StoreParameter.PackAlignment);
        }

        /// <summary>
        /// Tests that pack skip images ext is alias equals pack skip images
        /// </summary>
        [Fact]
        public void PackSkipImagesExt_IsAlias_EqualsPackSkipImages()
        {
            Assert.Equal((int)StoreParameter.PackSkipImages, (int)StoreParameter.PackSkipImagesExt);
        }

        /// <summary>
        /// Tests that pack image height ext is alias equals pack image height
        /// </summary>
        [Fact]
        public void PackImageHeightExt_IsAlias_EqualsPackImageHeight()
        {
            Assert.Equal((int)StoreParameter.PackImageHeight, (int)StoreParameter.PackImageHeightExt);
        }

        /// <summary>
        /// Tests that unpack skip images ext is alias equals unpack skip images
        /// </summary>
        [Fact]
        public void UnpackSkipImagesExt_IsAlias_EqualsUnpackSkipImages()
        {
            Assert.Equal((int)StoreParameter.UnpackSkipImages, (int)StoreParameter.UnpackSkipImagesExt);
        }

        /// <summary>
        /// Tests that unpack image height ext is alias equals unpack image height
        /// </summary>
        [Fact]
        public void UnpackImageHeightExt_IsAlias_EqualsUnpackImageHeight()
        {
            Assert.Equal((int)StoreParameter.UnpackImageHeight, (int)StoreParameter.UnpackImageHeightExt);
        }
    }
}
