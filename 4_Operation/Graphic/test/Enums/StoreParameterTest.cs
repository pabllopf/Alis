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
        [Fact]
        public void UnpackSwapBytes_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF0, (int)StoreParameter.UnpackSwapBytes); }

        [Fact]
        public void UnpackLsbFirst_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF1, (int)StoreParameter.UnpackLsbFirst); }

        [Fact]
        public void UnpackRowLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF2, (int)StoreParameter.UnpackRowLength); }

        [Fact]
        public void UnpackSkipRows_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF3, (int)StoreParameter.UnpackSkipRows); }

        [Fact]
        public void UnpackSkipPixels_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF4, (int)StoreParameter.UnpackSkipPixels); }

        [Fact]
        public void UnpackAlignment_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0CF5, (int)StoreParameter.UnpackAlignment); }

        [Fact]
        public void PackSwapBytes_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D00, (int)StoreParameter.PackSwapBytes); }

        [Fact]
        public void PackLsbFirst_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D01, (int)StoreParameter.PackLsbFirst); }

        [Fact]
        public void PackRowLength_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D02, (int)StoreParameter.PackRowLength); }

        [Fact]
        public void PackSkipRows_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D03, (int)StoreParameter.PackSkipRows); }

        [Fact]
        public void PackSkipPixels_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D04, (int)StoreParameter.PackSkipPixels); }

        [Fact]
        public void PackAlignment_HasCorrectValue_EqualsExpected() { Assert.Equal(0x0D05, (int)StoreParameter.PackAlignment); }

        [Fact]
        public void PackSkipImages_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806B, (int)StoreParameter.PackSkipImages); }

        [Fact]
        public void PackSkipImagesExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806B, (int)StoreParameter.PackSkipImagesExt); }

        [Fact]
        public void PackImageHeight_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806C, (int)StoreParameter.PackImageHeight); }

        [Fact]
        public void PackImageHeightExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806C, (int)StoreParameter.PackImageHeightExt); }

        [Fact]
        public void UnpackSkipImages_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806D, (int)StoreParameter.UnpackSkipImages); }

        [Fact]
        public void UnpackSkipImagesExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806D, (int)StoreParameter.UnpackSkipImagesExt); }

        [Fact]
        public void UnpackImageHeight_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806E, (int)StoreParameter.UnpackImageHeight); }

        [Fact]
        public void UnpackImageHeightExt_HasCorrectValue_EqualsExpected() { Assert.Equal(0x806E, (int)StoreParameter.UnpackImageHeightExt); }

        [Fact]
        public void PackSkipVolumesSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8130, (int)StoreParameter.PackSkipVolumesSgis); }

        [Fact]
        public void PackImageDepthSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8131, (int)StoreParameter.PackImageDepthSgis); }

        [Fact]
        public void UnpackSkipVolumesSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8132, (int)StoreParameter.UnpackSkipVolumesSgis); }

        [Fact]
        public void UnpackImageDepthSgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8133, (int)StoreParameter.UnpackImageDepthSgis); }

        [Fact]
        public void TileWidthSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8140, (int)StoreParameter.TileWidthSgix); }

        [Fact]
        public void TileHeightSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8141, (int)StoreParameter.TileHeightSgix); }

        [Fact]
        public void TileGridWidthSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8142, (int)StoreParameter.TileGridWidthSgix); }

        [Fact]
        public void TileGridHeightSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8143, (int)StoreParameter.TileGridHeightSgix); }

        [Fact]
        public void TileGridDepthSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8144, (int)StoreParameter.TileGridDepthSgix); }

        [Fact]
        public void TileCacheSizeSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8145, (int)StoreParameter.TileCacheSizeSgix); }

        [Fact]
        public void PackResampleSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x842C, (int)StoreParameter.PackResampleSgix); }

        [Fact]
        public void UnpackResampleSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x842D, (int)StoreParameter.UnpackResampleSgix); }

        [Fact]
        public void PackSubsampleRateSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x85A0, (int)StoreParameter.PackSubsampleRateSgix); }

        [Fact]
        public void UnpackSubsampleRateSgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x85A1, (int)StoreParameter.UnpackSubsampleRateSgix); }

        [Fact]
        public void StoreParameter_IsEnum_TypeIsCorrect() { Assert.True(typeof(StoreParameter).IsEnum); }

        [Fact]
        public void StoreParameter_IsPublic_CanBeAccessed() { Assert.True(typeof(StoreParameter).IsPublic); }

        [Fact]
        public void StoreParameter_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(StoreParameter));
            Assert.NotEmpty(enumValues);
        }

        [Fact]
        public void StoreParameter_CanCastToInt_ConversionIsValid()
        {
            int value = (int)StoreParameter.UnpackAlignment;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void StoreParameter_CanCompareValues_EqualityWorks()
        {
            StoreParameter param1 = StoreParameter.UnpackAlignment;
            StoreParameter param2 = StoreParameter.UnpackAlignment;
            Assert.Equal(param1, param2);
        }

        [Fact]
        public void StoreParameter_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(StoreParameter.UnpackAlignment, StoreParameter.PackAlignment);
        }

        [Fact]
        public void PackSkipImagesExt_IsAlias_EqualsPackSkipImages()
        {
            Assert.Equal((int)StoreParameter.PackSkipImages, (int)StoreParameter.PackSkipImagesExt);
        }

        [Fact]
        public void PackImageHeightExt_IsAlias_EqualsPackImageHeight()
        {
            Assert.Equal((int)StoreParameter.PackImageHeight, (int)StoreParameter.PackImageHeightExt);
        }

        [Fact]
        public void UnpackSkipImagesExt_IsAlias_EqualsUnpackSkipImages()
        {
            Assert.Equal((int)StoreParameter.UnpackSkipImages, (int)StoreParameter.UnpackSkipImagesExt);
        }

        [Fact]
        public void UnpackImageHeightExt_IsAlias_EqualsUnpackImageHeight()
        {
            Assert.Equal((int)StoreParameter.UnpackImageHeight, (int)StoreParameter.UnpackImageHeightExt);
        }
    }
}
