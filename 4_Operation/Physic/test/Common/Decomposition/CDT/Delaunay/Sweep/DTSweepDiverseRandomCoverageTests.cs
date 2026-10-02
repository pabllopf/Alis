// --------------------------------------------------------------------------
//
//  File:DTSweepDiverseRandomCoverageTests.cs
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

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep diverse random coverage tests class
    /// </summary>
    public class DTSweepDiverseRandomCoverageTests
    {
        /// <summary>
        ///     Runs the triangulation on the given point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        private static void RunPointSet(List<TriangulationPoint> points)
        {
            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 3);
        }


        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom0_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(14.561528, -2.914914),
                new TriangulationPoint(5.477506, -7.252032),
                new TriangulationPoint(-0.95568, -5.78056),
                new TriangulationPoint(6.07283, -1.902907),
                new TriangulationPoint(13.769903, 0.70675),
                new TriangulationPoint(-0.965543, -0.351355),
                new TriangulationPoint(13.306709, -3.071832),
                new TriangulationPoint(-4.917512, -4.825191),
                new TriangulationPoint(8.661823, -0.889973),
                new TriangulationPoint(5.919917, -6.401326),
                new TriangulationPoint(14.276956, -1.164434),
                new TriangulationPoint(-2.131907, -1.951857),
                new TriangulationPoint(5.406981, 7.026749),
                new TriangulationPoint(11.326788, -4.228101),
                new TriangulationPoint(8.254769, -7.833237),
                new TriangulationPoint(9.693155, -4.74759),
                new TriangulationPoint(9.045872, 2.886758),
                new TriangulationPoint(13.389113, 1.733139),
                new TriangulationPoint(-0.480648, -2.225116),
                new TriangulationPoint(-4.131647, 0.277001),
                new TriangulationPoint(7.736703, -3.972808),
                new TriangulationPoint(1.577247, 6.998822),
                new TriangulationPoint(-0.5851, 5.422443),
                new TriangulationPoint(4.841533, -5.757954),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom1_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.584225, -0.219176),
                new TriangulationPoint(6.491251, 4.978002),
                new TriangulationPoint(1.141855, 2.945791),
                new TriangulationPoint(9.056746, 3.705297),
                new TriangulationPoint(1.854904, 3.431088),
                new TriangulationPoint(3.550633, 3.968612),
                new TriangulationPoint(7.651647, 4.033018),
                new TriangulationPoint(1.416434, -1.662957),
                new TriangulationPoint(1.237372, -0.812589),
                new TriangulationPoint(2.884099, -3.606629),
                new TriangulationPoint(4.903142, 5.304865),
                new TriangulationPoint(4.723718, -1.349768),
                new TriangulationPoint(8.190785, -2.481866),
                new TriangulationPoint(0.689405, 0.934407),
                new TriangulationPoint(2.688517, 2.689204),
                new TriangulationPoint(4.27244, -3.848381),
                new TriangulationPoint(6.077091, 2.116823),
                new TriangulationPoint(3.367989, -2.039288),
                new TriangulationPoint(5.130369, 0.899361),
                new TriangulationPoint(5.619659, -6.508444),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom2_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.98161, -3.810405),
                new TriangulationPoint(4.937149, -3.175337),
                new TriangulationPoint(5.066693, -2.54027),
                new TriangulationPoint(5.190207, -1.905202),
                new TriangulationPoint(6.360407, -3.175337),
                new TriangulationPoint(6.89015, -2.54027),
                new TriangulationPoint(7.437226, -1.905202),
                new TriangulationPoint(7.919759, -1.270135),
                new TriangulationPoint(8.140352, -0.635067),
                new TriangulationPoint(0.188401, 1.185575),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom3_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.090351, -2.007092),
                new TriangulationPoint(-0.193512, 0.02168),
                new TriangulationPoint(0.047914, 1.922868),
                new TriangulationPoint(-0.068909, 3.890204),
                new TriangulationPoint(1.97474, -1.90065),
                new TriangulationPoint(1.936232, -0.053485),
                new TriangulationPoint(1.896368, 1.947297),
                new TriangulationPoint(2.144137, 4.072093),
                new TriangulationPoint(3.866384, -2.145125),
                new TriangulationPoint(4.068074, 0.132488),
                new TriangulationPoint(3.819625, 2.086956),
                new TriangulationPoint(4.197581, 3.900386),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom4_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.67364, 1.080654),
                new TriangulationPoint(-1.744301, -2.194666),
                new TriangulationPoint(2.505281, -2.941369),
                new TriangulationPoint(3.605111, 1.882376),
                new TriangulationPoint(0.584749, 2.099073),
                new TriangulationPoint(-1.446574, 3.679536),
                new TriangulationPoint(-4.049334, 1.045594),
                new TriangulationPoint(-1.981574, -2.390587),
                new TriangulationPoint(1.836682, -1.894053),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom5_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.700896, 0.266512),
                new TriangulationPoint(6.214208, -2.004764),
                new TriangulationPoint(0.02622, 3.407381),
                new TriangulationPoint(14.797733, 4.575465),
                new TriangulationPoint(2.798258, -0.430583),
                new TriangulationPoint(9.708918, 3.247384),
                new TriangulationPoint(1.155543, -3.65434),
                new TriangulationPoint(13.508847, 4.647983),
                new TriangulationPoint(-3.428345, 7.606196),
                new TriangulationPoint(2.87334, -3.919731),
                new TriangulationPoint(4.541405, -6.329819),
                new TriangulationPoint(5.556094, 7.010418),
                new TriangulationPoint(7.572499, -0.064408),
                new TriangulationPoint(1.162506, 0.863276),
                new TriangulationPoint(3.178707, -7.730437),
                new TriangulationPoint(8.876876, 3.665321),
                new TriangulationPoint(3.487244, -0.833327),
                new TriangulationPoint(11.662368, 5.620501),
                new TriangulationPoint(-0.873116, -7.570167),
                new TriangulationPoint(10.780154, 6.611054),
                new TriangulationPoint(-3.391235, -2.202346),
                new TriangulationPoint(12.3014, 4.871673),
                new TriangulationPoint(11.860606, -0.328977),
                new TriangulationPoint(3.948255, 3.564512),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom6_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.768497, 0.520023),
                new TriangulationPoint(0.76867, 4.810833),
                new TriangulationPoint(5.698, 0.123991),
                new TriangulationPoint(2.397149, 5.151197),
                new TriangulationPoint(4.374678, -0.754717),
                new TriangulationPoint(9.09524, 4.288633),
                new TriangulationPoint(7.022674, 1.570233),
                new TriangulationPoint(6.899289, -1.191073),
                new TriangulationPoint(7.167952, 1.186781),
                new TriangulationPoint(7.237897, 4.961454),
                new TriangulationPoint(7.291444, 2.530589),
                new TriangulationPoint(9.142822, 5.179528),
                new TriangulationPoint(4.347128, -3.097473),
                new TriangulationPoint(4.039862, 3.3637),
                new TriangulationPoint(0.781225, -2.686444),
                new TriangulationPoint(1.865926, 5.682714),
                new TriangulationPoint(8.909335, 2.129557),
                new TriangulationPoint(7.615106, -0.571396),
                new TriangulationPoint(0.602793, -0.221472),
                new TriangulationPoint(2.970505, -2.304743),
                new TriangulationPoint(8.48206, 1.622553),
                new TriangulationPoint(8.209677, 4.921837),
                new TriangulationPoint(7.480434, 3.764421),
                new TriangulationPoint(6.046189, 0.772722),
                new TriangulationPoint(5.44237, -7.593768),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom7_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.486797, -6.016715),
                new TriangulationPoint(4.047926, -5.013929),
                new TriangulationPoint(4.507975, -4.011143),
                new TriangulationPoint(4.700678, -3.008357),
                new TriangulationPoint(5.196043, -2.005572),
                new TriangulationPoint(5.812838, -5.013929),
                new TriangulationPoint(6.319985, -4.011143),
                new TriangulationPoint(8.826997, 4.896786),
                new TriangulationPoint(4.552141, 4.516722),
                new TriangulationPoint(2.363071, 4.373227),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom8_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.102825, -1.907312),
                new TriangulationPoint(-0.102276, -0.009055),
                new TriangulationPoint(1.9959, -1.927379),
                new TriangulationPoint(2.143833, -0.01903),
                new TriangulationPoint(4.01311, -1.895648),
                new TriangulationPoint(4.105156, -0.00556),
                new TriangulationPoint(5.896962, -2.084341),
                new TriangulationPoint(6.088699, 0.186808),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom9_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.540274, -0.672923),
                new TriangulationPoint(-0.249547, -4.579419),
                new TriangulationPoint(4.32318, -1.134119),
                new TriangulationPoint(2.35006, 1.514798),
                new TriangulationPoint(0.344095, 2.857753),
                new TriangulationPoint(-3.264934, 0.543137),
                new TriangulationPoint(-2.940115, -3.581861),
                new TriangulationPoint(2.252872, -1.869807),
                new TriangulationPoint(2.184969, 1.002304),
                new TriangulationPoint(0.301574, 3.127018),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom10_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.172305, -1.233259),
                new TriangulationPoint(12.995406, -2.743956),
                new TriangulationPoint(7.911913, -1.504485),
                new TriangulationPoint(10.744552, -4.231757),
                new TriangulationPoint(1.386756, -5.703937),
                new TriangulationPoint(13.289916, -3.47862),
                new TriangulationPoint(3.90743, 3.877124),
                new TriangulationPoint(2.811062, -4.619244),
                new TriangulationPoint(9.215133, -4.484645),
                new TriangulationPoint(-0.707466, -0.71513),
                new TriangulationPoint(7.738215, -5.076072),
                new TriangulationPoint(-3.822391, -5.100155),
                new TriangulationPoint(1.482891, 7.811479),
                new TriangulationPoint(10.983658, 4.940951),
                new TriangulationPoint(0.508064, -5.602716),
                new TriangulationPoint(14.365899, 3.695539),
                new TriangulationPoint(-3.998888, 6.403876),
                new TriangulationPoint(2.40037, -7.464716),
                new TriangulationPoint(13.59369, 3.640273),
                new TriangulationPoint(4.43512, -0.826689),
                new TriangulationPoint(13.843586, 6.770489),
                new TriangulationPoint(3.81692, 1.16998),
                new TriangulationPoint(14.319095, 0.262263),
                new TriangulationPoint(13.209415, 6.542393),
                new TriangulationPoint(1.364537, -1.760643),
                new TriangulationPoint(11.206832, 4.105173),
                new TriangulationPoint(-4.61192, -7.95067),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom11_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.080505, 4.853344),
                new TriangulationPoint(9.427571, -0.848455),
                new TriangulationPoint(3.716767, 0.652628),
                new TriangulationPoint(5.891514, 4.5982),
                new TriangulationPoint(1.241318, 1.019662),
                new TriangulationPoint(9.954015, -3.934684),
                new TriangulationPoint(2.159415, 5.13558),
                new TriangulationPoint(1.349043, -0.829716),
                new TriangulationPoint(3.919324, 1.881832),
                new TriangulationPoint(4.651325, -2.988496),
                new TriangulationPoint(7.748926, 3.70187),
                new TriangulationPoint(0.288485, 2.037386),
                new TriangulationPoint(0.043832, 5.522397),
                new TriangulationPoint(6.230158, -3.129193),
                new TriangulationPoint(4.282576, 2.557792),
                new TriangulationPoint(4.591689, 2.882369),
                new TriangulationPoint(5.911669, -6.768911),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom12_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.801603, -6.077738),
                new TriangulationPoint(3.472299, -5.064782),
                new TriangulationPoint(3.766117, -4.051825),
                new TriangulationPoint(3.979507, -3.038869),
                new TriangulationPoint(4.304802, -2.025913),
                new TriangulationPoint(4.435331, -1.012956),
                new TriangulationPoint(4.965101, -5.064782),
                new TriangulationPoint(5.343115, -4.051825),
                new TriangulationPoint(5.832152, -3.038869),
                new TriangulationPoint(6.107627, -2.025913),
                new TriangulationPoint(6.335714, -1.012956),
                new TriangulationPoint(5.577918, 2.529762),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom13_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.132132, -2.057991),
                new TriangulationPoint(-0.009978, -0.156281),
                new TriangulationPoint(2.068111, -2.002708),
                new TriangulationPoint(1.906062, 0.045266),
                new TriangulationPoint(4.084606, -1.881824),
                new TriangulationPoint(4.102921, 0.196004),
                new TriangulationPoint(6.156393, -2.081009),
                new TriangulationPoint(5.829384, 0.131395),
                new TriangulationPoint(7.883585, -1.878335),
                new TriangulationPoint(7.94572, 0.017624),
                new TriangulationPoint(9.855611, -1.965434),
                new TriangulationPoint(9.889107, -0.023023),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom14_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.070364, 0.8272),
                new TriangulationPoint(-2.389829, -0.880979),
                new TriangulationPoint(-0.290273, -2.668445),
                new TriangulationPoint(1.800162, -2.114988),
                new TriangulationPoint(3.637062, -0.654817),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom15_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.202021, 6.376845),
                new TriangulationPoint(9.012044, 3.325796),
                new TriangulationPoint(9.724091, 0.862799),
                new TriangulationPoint(0.515838, 1.19995),
                new TriangulationPoint(1.439706, 0.362106),
                new TriangulationPoint(6.19071, 6.938316),
                new TriangulationPoint(11.21998, 6.73057),
                new TriangulationPoint(12.306078, 2.618995),
                new TriangulationPoint(-3.954492, -7.098036),
                new TriangulationPoint(7.753952, 6.80047),
                new TriangulationPoint(1.857457, -4.497553),
                new TriangulationPoint(8.375513, 0.557544),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom16_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.982422, 3.608156),
                new TriangulationPoint(8.146396, -3.413005),
                new TriangulationPoint(7.464414, 3.075621),
                new TriangulationPoint(8.304209, 2.823498),
                new TriangulationPoint(0.625587, 3.799501),
                new TriangulationPoint(0.249304, 4.721294),
                new TriangulationPoint(5.443383, 1.237126),
                new TriangulationPoint(3.255159, 4.489353),
                new TriangulationPoint(6.430835, 1.575735),
                new TriangulationPoint(9.684604, -2.470278),
                new TriangulationPoint(4.605173, -6.484588),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom17_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.600388, -2.085071),
                new TriangulationPoint(4.273878, -1.737559),
                new TriangulationPoint(4.572766, -1.390047),
                new TriangulationPoint(4.684371, -1.042535),
                new TriangulationPoint(4.893719, -0.695024),
                new TriangulationPoint(5.93702, -1.737559),
                new TriangulationPoint(6.384861, -1.390047),
                new TriangulationPoint(6.722412, -1.042535),
                new TriangulationPoint(6.954675, -0.695024),
                new TriangulationPoint(5.762256, 4.891754),
                new TriangulationPoint(3.587207, 2.330992),
                new TriangulationPoint(3.221707, 4.601648),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom18_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.08998, -1.848153),
                new TriangulationPoint(0.070356, 0.190037),
                new TriangulationPoint(-0.184228, 2.081278),
                new TriangulationPoint(-0.024224, 4.016215),
                new TriangulationPoint(2.170293, -2.015386),
                new TriangulationPoint(2.072666, 0.119019),
                new TriangulationPoint(1.991782, 1.921503),
                new TriangulationPoint(2.050983, 4.061589),
                new TriangulationPoint(4.133355, -2.150056),
                new TriangulationPoint(3.82134, 0.087011),
                new TriangulationPoint(3.976026, 2.119481),
                new TriangulationPoint(4.176785, 3.95201),
                new TriangulationPoint(5.867404, -2.189411),
                new TriangulationPoint(6.198878, -0.012532),
                new TriangulationPoint(5.828935, 1.927785),
                new TriangulationPoint(5.940131, 3.964201),
                new TriangulationPoint(8.125696, -1.868038),
                new TriangulationPoint(7.901187, 0.055165),
                new TriangulationPoint(7.996974, 1.827421),
                new TriangulationPoint(8.088719, 3.838601),
                new TriangulationPoint(9.929777, -2.076944),
                new TriangulationPoint(10.078734, 0.148438),
                new TriangulationPoint(10.192276, 2.104081),
                new TriangulationPoint(10.11914, 3.903455),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom19_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.980689, 4.665715),
                new TriangulationPoint(-2.626107, 3.620937),
                new TriangulationPoint(-2.142723, -1.251235),
                new TriangulationPoint(1.070037, -2.310983),
                new TriangulationPoint(2.645151, -2.037033),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom20_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.180842, 0.692153),
                new TriangulationPoint(7.312013, -3.526566),
                new TriangulationPoint(9.987272, -2.465428),
                new TriangulationPoint(8.72605, 5.829006),
                new TriangulationPoint(10.661853, -5.595243),
                new TriangulationPoint(12.885777, 3.932609),
                new TriangulationPoint(13.463028, 6.115107),
                new TriangulationPoint(-2.097596, -3.333853),
                new TriangulationPoint(4.231378, -6.574512),
                new TriangulationPoint(10.239901, -2.487914),
                new TriangulationPoint(13.854878, 0.928979),
                new TriangulationPoint(10.844505, 0.447895),
                new TriangulationPoint(4.400843, -6.43536),
                new TriangulationPoint(5.779583, -0.463356),
                new TriangulationPoint(11.022148, -2.207373),
                new TriangulationPoint(0.37063, -2.398301),
                new TriangulationPoint(-1.675944, 7.298017),
                new TriangulationPoint(-1.977687, -1.01511),
                new TriangulationPoint(8.035543, -3.932367),
                new TriangulationPoint(7.944129, 7.428121),
                new TriangulationPoint(7.259647, 6.943217),
                new TriangulationPoint(-0.830738, -4.210043),
                new TriangulationPoint(2.036722, 0.835565),
                new TriangulationPoint(2.398067, -0.425783),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom21_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.700074, -1.818185),
                new TriangulationPoint(2.449079, -2.983114),
                new TriangulationPoint(5.967455, -1.962446),
                new TriangulationPoint(1.106974, 4.942251),
                new TriangulationPoint(9.868009, 4.389867),
                new TriangulationPoint(3.846175, 4.602323),
                new TriangulationPoint(9.078137, -2.425071),
                new TriangulationPoint(2.966751, 5.569685),
                new TriangulationPoint(0.002723, -3.789667),
                new TriangulationPoint(4.991606, -5.328973),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom22_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.059024, -4.916684),
                new TriangulationPoint(3.587423, -4.097236),
                new TriangulationPoint(4.086901, -3.277789),
                new TriangulationPoint(4.369525, -2.458342),
                new TriangulationPoint(4.542267, -1.638895),
                new TriangulationPoint(4.972024, -0.819447),
                new TriangulationPoint(5.371547, -4.097236),
                new TriangulationPoint(5.57211, -3.277789),
                new TriangulationPoint(5.850116, -2.458342),
                new TriangulationPoint(6.080167, -1.638895),
                new TriangulationPoint(8.968845, 2.059644),
                new TriangulationPoint(9.653972, 3.400324),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom23_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.060484, -2.154662),
                new TriangulationPoint(0.155654, 0.17487),
                new TriangulationPoint(-0.166675, 1.994855),
                new TriangulationPoint(0.126701, 3.882363),
                new TriangulationPoint(2.027839, -1.916661),
                new TriangulationPoint(1.802069, 0.195401),
                new TriangulationPoint(2.0107, 2.072766),
                new TriangulationPoint(1.997152, 3.814251),
                new TriangulationPoint(4.090435, -1.802523),
                new TriangulationPoint(4.018873, 0.050524),
                new TriangulationPoint(4.046632, 1.845547),
                new TriangulationPoint(3.804384, 3.823396),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom24_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.348033, 3.053807),
                new TriangulationPoint(-3.006057, 1.735898),
                new TriangulationPoint(-1.961961, -3.496534),
                new TriangulationPoint(1.082306, -3.269193),
                new TriangulationPoint(2.560292, 0.105405),
                new TriangulationPoint(2.290698, 4.045279),
                new TriangulationPoint(-3.211017, 2.537627),
                new TriangulationPoint(-4.66951, 0.283621),
                new TriangulationPoint(-2.719565, -3.010816),
                new TriangulationPoint(2.721531, -2.995668),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom25_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.604879, 0.330017),
                new TriangulationPoint(5.951751, -4.582937),
                new TriangulationPoint(-1.414145, 3.379593),
                new TriangulationPoint(11.428277, -7.891812),
                new TriangulationPoint(11.617619, -3.548881),
                new TriangulationPoint(9.789421, -4.119332),
                new TriangulationPoint(4.010851, -6.494151),
                new TriangulationPoint(11.900687, 1.823472),
                new TriangulationPoint(9.295112, 7.516046),
                new TriangulationPoint(-1.458997, -5.260431),
                new TriangulationPoint(2.449081, 7.767902),
                new TriangulationPoint(11.87749, -5.137178),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom26_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.177532, -1.548394),
                new TriangulationPoint(2.353873, 5.669942),
                new TriangulationPoint(9.251948, 5.633153),
                new TriangulationPoint(6.257049, 1.44256),
                new TriangulationPoint(2.496956, 2.914563),
                new TriangulationPoint(7.233651, 0.313199),
                new TriangulationPoint(5.106674, 5.89989),
                new TriangulationPoint(6.799187, -2.334641),
                new TriangulationPoint(4.232489, 0.603342),
                new TriangulationPoint(2.288854, 2.651175),
                new TriangulationPoint(8.250805, -1.173808),
                new TriangulationPoint(6.443354, 3.049294),
                new TriangulationPoint(2.538076, 1.068993),
                new TriangulationPoint(5.153437, -7.960282),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom27_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.962941, -6.626205),
                new TriangulationPoint(5.091209, -5.521838),
                new TriangulationPoint(5.578117, -4.41747),
                new TriangulationPoint(6.064845, -5.521838),
                new TriangulationPoint(6.605971, -4.41747),
                new TriangulationPoint(6.935308, -3.313103),
                new TriangulationPoint(5.070982, 2.492844),
                new TriangulationPoint(2.396433, 1.343588),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom28_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.152366, -1.809236),
                new TriangulationPoint(-0.102513, 0.080002),
                new TriangulationPoint(-0.086677, 2.065932),
                new TriangulationPoint(-0.057457, 3.93775),
                new TriangulationPoint(2.02262, -1.806403),
                new TriangulationPoint(1.833195, 0.055544),
                new TriangulationPoint(1.947331, 2.092073),
                new TriangulationPoint(2.151899, 4.173485),
                new TriangulationPoint(4.094351, -2.012845),
                new TriangulationPoint(3.873654, -0.02343),
                new TriangulationPoint(4.11623, 2.036077),
                new TriangulationPoint(4.021002, 4.181781),
                new TriangulationPoint(6.054556, -2.117203),
                new TriangulationPoint(6.086906, -0.069693),
                new TriangulationPoint(5.987187, 1.842005),
                new TriangulationPoint(6.050005, 4.061814),
                new TriangulationPoint(7.992743, -2.106806),
                new TriangulationPoint(8.131211, 0.050285),
                new TriangulationPoint(8.125781, 2.143347),
                new TriangulationPoint(8.113965, 3.978245),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom29_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.673679, 1.136554),
                new TriangulationPoint(-2.594055, -1.900155),
                new TriangulationPoint(0.690903, -2.977713),
                new TriangulationPoint(2.578016, -0.817255),
                new TriangulationPoint(1.276249, 1.668099),
                new TriangulationPoint(-1.364147, 4.594301),
                new TriangulationPoint(-3.915721, 0.171528),
                new TriangulationPoint(-4.092219, -2.231757),
                new TriangulationPoint(2.274163, -4.170745),
                new TriangulationPoint(4.577299, -1.420336),
                new TriangulationPoint(3.323059, 2.049475),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom30_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.957741, 2.030331),
                new TriangulationPoint(0.330807, 0.747413),
                new TriangulationPoint(-4.26326, -4.394351),
                new TriangulationPoint(6.523297, -0.422438),
                new TriangulationPoint(11.055856, 3.187981),
                new TriangulationPoint(9.015088, -3.075889),
                new TriangulationPoint(6.47237, 4.519752),
                new TriangulationPoint(10.6477, -5.290637),
                new TriangulationPoint(13.836424, -5.865307),
                new TriangulationPoint(14.60156, 1.819551),
                new TriangulationPoint(3.315238, -7.981621),
                new TriangulationPoint(8.236409, 6.150374),
                new TriangulationPoint(-1.12185, 5.28322),
                new TriangulationPoint(7.534765, 2.523895),
                new TriangulationPoint(8.157152, -6.645287),
                new TriangulationPoint(-3.504338, 7.566398),
                new TriangulationPoint(6.297165, 6.584891),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom31_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.383921, 2.415665),
                new TriangulationPoint(4.758364, 4.911891),
                new TriangulationPoint(3.501775, -0.08791),
                new TriangulationPoint(5.023147, 3.915808),
                new TriangulationPoint(8.931166, 0.38606),
                new TriangulationPoint(8.230755, -3.789756),
                new TriangulationPoint(2.682261, 4.227345),
                new TriangulationPoint(4.788266, 0.088182),
                new TriangulationPoint(4.254499, -2.161763),
                new TriangulationPoint(8.594487, 1.713617),
                new TriangulationPoint(5.287276, 3.412328),
                new TriangulationPoint(4.814175, -5.640772),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom32_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.725626, -5.898275),
                new TriangulationPoint(3.965401, -4.91523),
                new TriangulationPoint(4.375544, -3.932184),
                new TriangulationPoint(5.073056, -4.91523),
                new TriangulationPoint(5.592656, -3.932184),
                new TriangulationPoint(6.703505, 2.447792),
                new TriangulationPoint(4.335047, 1.190505),
                new TriangulationPoint(6.780751, 2.518571),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom33_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.107583, -2.001356),
                new TriangulationPoint(0.182001, 0.106636),
                new TriangulationPoint(-0.085927, 2.043201),
                new TriangulationPoint(0.043004, 3.961304),
                new TriangulationPoint(1.89546, -2.183403),
                new TriangulationPoint(2.072862, 0.027008),
                new TriangulationPoint(1.959964, 1.972018),
                new TriangulationPoint(2.003986, 4.052077),
                new TriangulationPoint(3.803683, -2.070277),
                new TriangulationPoint(3.872522, -0.10148),
                new TriangulationPoint(3.930727, 2.155913),
                new TriangulationPoint(4.172954, 3.939509),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom34_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.892301, -4.101133),
                new TriangulationPoint(3.910921, -1.861372),
                new TriangulationPoint(3.303512, 3.519128),
                new TriangulationPoint(0.940844, 3.278505),
                new TriangulationPoint(-2.51338, 1.18111),
                new TriangulationPoint(-4.244424, -1.609309),
                new TriangulationPoint(1.091908, -3.467001),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom35_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.297683, -2.413309),
                new TriangulationPoint(11.37626, -1.88425),
                new TriangulationPoint(0.602504, -7.014656),
                new TriangulationPoint(4.158333, -2.224175),
                new TriangulationPoint(10.996529, 6.719623),
                new TriangulationPoint(1.688904, 3.748755),
                new TriangulationPoint(-3.429483, -1.066889),
                new TriangulationPoint(13.364354, -4.935983),
                new TriangulationPoint(-4.957297, 2.889514),
                new TriangulationPoint(14.750784, -2.370696),
                new TriangulationPoint(5.836388, 3.117018),
                new TriangulationPoint(-0.127838, 1.258448),
                new TriangulationPoint(0.148257, 2.543414),
                new TriangulationPoint(6.130527, -2.930478),
                new TriangulationPoint(12.066999, -4.672552),
                new TriangulationPoint(-2.604315, 0.646815),
                new TriangulationPoint(7.854606, 0.068928),
                new TriangulationPoint(7.110052, 6.496849),
                new TriangulationPoint(2.815592, 5.898151),
                new TriangulationPoint(1.717787, -4.500891),
                new TriangulationPoint(6.700378, -2.694624),
                new TriangulationPoint(-3.505933, 4.587119),
                new TriangulationPoint(12.289933, 1.583957),
                new TriangulationPoint(12.600265, -7.601049),
                new TriangulationPoint(7.821354, -3.181749),
                new TriangulationPoint(-1.316605, -3.843659),
                new TriangulationPoint(12.066355, -0.945738),
                new TriangulationPoint(8.960795, -6.588215),
                new TriangulationPoint(10.594938, -7.416204),
                new TriangulationPoint(14.590595, 6.113952),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom36_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.171525, 1.842495),
                new TriangulationPoint(0.812753, 2.746125),
                new TriangulationPoint(5.606661, 0.688347),
                new TriangulationPoint(1.939343, 3.746438),
                new TriangulationPoint(6.83145, 3.532311),
                new TriangulationPoint(9.091999, -1.279877),
                new TriangulationPoint(4.156661, 1.733496),
                new TriangulationPoint(3.526053, -3.278417),
                new TriangulationPoint(0.635337, 3.992998),
                new TriangulationPoint(9.759561, 2.61011),
                new TriangulationPoint(3.808788, 1.319541),
                new TriangulationPoint(5.156789, -0.196441),
                new TriangulationPoint(2.340791, -3.627697),
                new TriangulationPoint(5.628289, -6.080384),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom37_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.724866, -4.485001),
                new TriangulationPoint(3.559053, -3.737501),
                new TriangulationPoint(3.895334, -2.99),
                new TriangulationPoint(4.182728, -2.2425),
                new TriangulationPoint(4.422794, -1.495),
                new TriangulationPoint(4.957034, -3.737501),
                new TriangulationPoint(5.298092, -2.99),
                new TriangulationPoint(5.718563, -2.2425),
                new TriangulationPoint(6.260447, -1.495),
                new TriangulationPoint(6.565434, -0.7475),
                new TriangulationPoint(3.379466, 2.936298),
                new TriangulationPoint(8.866051, 2.249414),
                new TriangulationPoint(7.296583, 2.496371),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom38_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.179425, -1.881729),
                new TriangulationPoint(-0.137781, -0.001811),
                new TriangulationPoint(0.078577, 1.815896),
                new TriangulationPoint(0.185959, 3.848105),
                new TriangulationPoint(2.092503, -2.017576),
                new TriangulationPoint(2.185296, -0.195083),
                new TriangulationPoint(1.911134, 1.843746),
                new TriangulationPoint(1.935766, 3.930154),
                new TriangulationPoint(3.993117, -1.824742),
                new TriangulationPoint(4.008785, 0.137009),
                new TriangulationPoint(3.99109, 1.842999),
                new TriangulationPoint(4.058264, 4.162204),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom39_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.390574, -3.986239),
                new TriangulationPoint(3.671494, -1.215394),
                new TriangulationPoint(2.153328, 1.917498),
                new TriangulationPoint(0.140641, 3.159912),
                new TriangulationPoint(-2.153584, 1.556832),
                new TriangulationPoint(-3.326645, -2.039509),
                new TriangulationPoint(1.139317, -4.162288),
                new TriangulationPoint(2.147141, -1.857756),
                new TriangulationPoint(3.662436, 1.836752),
                new TriangulationPoint(0.158259, 2.035842),
                new TriangulationPoint(-2.396036, 4.232111),
                new TriangulationPoint(-3.059124, 1.136762),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom40_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(13.865365, -3.631838),
                new TriangulationPoint(3.729842, -7.83004),
                new TriangulationPoint(7.275486, -4.047762),
                new TriangulationPoint(-4.28732, 5.28409),
                new TriangulationPoint(-1.309598, 1.341816),
                new TriangulationPoint(14.991108, 3.169591),
                new TriangulationPoint(7.50072, 5.434045),
                new TriangulationPoint(11.478022, 1.711456),
                new TriangulationPoint(2.903839, 1.0843),
                new TriangulationPoint(13.241549, 1.558439),
                new TriangulationPoint(12.9602, -7.674732),
                new TriangulationPoint(13.467453, -7.282235),
                new TriangulationPoint(13.77694, 5.076686),
                new TriangulationPoint(12.895071, 4.81543),
                new TriangulationPoint(2.414132, -4.287636),
                new TriangulationPoint(14.574864, -7.87024),
                new TriangulationPoint(-2.148, 6.625457),
                new TriangulationPoint(12.463987, 0.606035),
                new TriangulationPoint(14.185407, 6.922055),
                new TriangulationPoint(9.252774, 0.905603),
                new TriangulationPoint(12.850194, 1.220684),
                new TriangulationPoint(-4.205719, 4.76374),
                new TriangulationPoint(12.236706, -7.695196),
                new TriangulationPoint(1.259327, -6.204521),
                new TriangulationPoint(-0.077432, -2.052558),
                new TriangulationPoint(14.67617, 3.933678),
                new TriangulationPoint(-0.23364, -0.411745),
                new TriangulationPoint(-3.046029, 5.243227),
                new TriangulationPoint(0.874173, -4.79035),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom41_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.407937, -0.516657),
                new TriangulationPoint(3.917361, -1.583008),
                new TriangulationPoint(8.641438, -2.816986),
                new TriangulationPoint(3.814401, 3.791683),
                new TriangulationPoint(0.889188, -2.36796),
                new TriangulationPoint(1.706783, 4.988415),
                new TriangulationPoint(1.472466, -3.411652),
                new TriangulationPoint(3.541646, 1.447872),
                new TriangulationPoint(0.286835, 5.428536),
                new TriangulationPoint(7.950621, 1.756974),
                new TriangulationPoint(8.793974, -1.845673),
                new TriangulationPoint(7.922992, -3.021734),
                new TriangulationPoint(8.613835, 3.529623),
                new TriangulationPoint(9.261018, -2.554527),
                new TriangulationPoint(7.778692, -3.842674),
                new TriangulationPoint(1.772496, 3.140852),
                new TriangulationPoint(5.199165, -6.500332),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom42_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.326425, -5.45239),
                new TriangulationPoint(2.967942, -4.543658),
                new TriangulationPoint(3.372568, -3.634927),
                new TriangulationPoint(4.454146, -4.543658),
                new TriangulationPoint(4.98426, -3.634927),
                new TriangulationPoint(5.319597, -2.726195),
                new TriangulationPoint(5.700285, -1.817463),
                new TriangulationPoint(6.110624, -0.908732),
                new TriangulationPoint(6.254812, 3.033594),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom43_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.078188, -1.865479),
                new TriangulationPoint(-0.047004, 0.051249),
                new TriangulationPoint(-0.041219, 2.100263),
                new TriangulationPoint(0.068234, 3.98216),
                new TriangulationPoint(1.948411, -2.08705),
                new TriangulationPoint(2.015641, -0.075484),
                new TriangulationPoint(1.936372, 2.124385),
                new TriangulationPoint(2.071073, 4.181326),
                new TriangulationPoint(3.803057, -1.976755),
                new TriangulationPoint(3.809665, -0.188763),
                new TriangulationPoint(4.141676, 2.093713),
                new TriangulationPoint(4.025006, 4.131428),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom44_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.007172, -2.555557),
                new TriangulationPoint(2.178427, 0.176935),
                new TriangulationPoint(2.311207, 2.90347),
                new TriangulationPoint(-0.164237, 2.168141),
                new TriangulationPoint(-2.215516, 2.323615),
                new TriangulationPoint(-3.131134, -0.07581),
                new TriangulationPoint(-2.241025, -1.2429),
                new TriangulationPoint(-0.723633, -4.810934),
                new TriangulationPoint(2.065949, -1.110463),
                new TriangulationPoint(2.281499, 2.003577),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom45_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.48205, 2.928056),
                new TriangulationPoint(5.506686, -6.550187),
                new TriangulationPoint(-2.911923, -3.778006),
                new TriangulationPoint(4.449932, -0.520731),
                new TriangulationPoint(4.236453, -1.902258),
                new TriangulationPoint(3.470294, 6.547854),
                new TriangulationPoint(11.017258, 6.710719),
                new TriangulationPoint(9.139982, 3.189711),
                new TriangulationPoint(6.581349, -2.410721),
                new TriangulationPoint(-2.55383, -4.21064),
                new TriangulationPoint(12.109163, -1.807332),
                new TriangulationPoint(1.309128, 0.634445),
                new TriangulationPoint(4.144293, 1.655233),
                new TriangulationPoint(11.848164, -2.396354),
                new TriangulationPoint(4.357856, -2.953203),
                new TriangulationPoint(-4.326686, 5.013578),
                new TriangulationPoint(9.58027, 6.229684),
                new TriangulationPoint(-3.040662, -2.330844),
                new TriangulationPoint(9.225721, -5.534375),
                new TriangulationPoint(8.811924, 3.203499),
                new TriangulationPoint(-0.1294, -2.884114),
                new TriangulationPoint(4.788987, -1.471515),
                new TriangulationPoint(0.760979, -7.161785),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom46_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.350614, 1.322892),
                new TriangulationPoint(3.832268, 2.747566),
                new TriangulationPoint(5.52138, 2.725992),
                new TriangulationPoint(4.52206, -2.145588),
                new TriangulationPoint(8.148312, -1.242077),
                new TriangulationPoint(4.073005, 2.400491),
                new TriangulationPoint(5.784643, -0.183584),
                new TriangulationPoint(7.968583, -3.790055),
                new TriangulationPoint(5.515789, 5.502006),
                new TriangulationPoint(2.935928, -2.715785),
                new TriangulationPoint(3.359638, 2.881781),
                new TriangulationPoint(3.289431, 4.665608),
                new TriangulationPoint(8.037203, -3.526531),
                new TriangulationPoint(3.8173, 5.864499),
                new TriangulationPoint(4.069219, -6.020653),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom47_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.450023, -4.850725),
                new TriangulationPoint(4.257157, -4.042271),
                new TriangulationPoint(4.413423, -3.233817),
                new TriangulationPoint(4.829989, -2.425363),
                new TriangulationPoint(5.654837, -4.042271),
                new TriangulationPoint(5.921704, -3.233817),
                new TriangulationPoint(6.438058, -2.425363),
                new TriangulationPoint(6.873572, -1.616908),
                new TriangulationPoint(7.226003, -0.808454),
                new TriangulationPoint(8.990928, 1.965017),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom48_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.033492, -2.179842),
                new TriangulationPoint(-0.137255, 0.133923),
                new TriangulationPoint(-0.091787, 1.964946),
                new TriangulationPoint(-0.067865, 4.118871),
                new TriangulationPoint(1.91901, -2.081232),
                new TriangulationPoint(1.924454, -0.064905),
                new TriangulationPoint(2.006003, 2.105156),
                new TriangulationPoint(1.945629, 4.070821),
                new TriangulationPoint(3.86028, -1.985791),
                new TriangulationPoint(3.905921, -0.114521),
                new TriangulationPoint(4.074457, 2.154791),
                new TriangulationPoint(4.079775, 3.801503),
                new TriangulationPoint(6.081885, -1.803293),
                new TriangulationPoint(5.969874, 0.132546),
                new TriangulationPoint(6.142069, 2.099913),
                new TriangulationPoint(5.930198, 3.834107),
                new TriangulationPoint(8.161679, -2.062735),
                new TriangulationPoint(8.175597, -0.014696),
                new TriangulationPoint(7.812982, 1.988869),
                new TriangulationPoint(8.017574, 4.094223),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom49_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.400178, -2.593829),
                new TriangulationPoint(2.820625, -0.84614),
                new TriangulationPoint(3.380433, 3.470415),
                new TriangulationPoint(-2.628859, 3.258051),
                new TriangulationPoint(-3.629133, -2.948602),
                new TriangulationPoint(-0.005351, -2.579214),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom50_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.276502, -1.318813),
                new TriangulationPoint(3.651562, -1.896635),
                new TriangulationPoint(4.312376, 7.918093),
                new TriangulationPoint(8.196963, 2.486731),
                new TriangulationPoint(3.845172, 3.662133),
                new TriangulationPoint(4.154092, 0.384673),
                new TriangulationPoint(12.201913, 0.867408),
                new TriangulationPoint(12.757475, 6.685059),
                new TriangulationPoint(4.139259, 6.262531),
                new TriangulationPoint(9.7165, 0.91495),
                new TriangulationPoint(3.514194, -0.710528),
                new TriangulationPoint(6.497138, 1.033491),
                new TriangulationPoint(12.119036, 1.231263),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom51_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.38468, 2.457252),
                new TriangulationPoint(1.743664, 3.292371),
                new TriangulationPoint(0.280404, 5.04253),
                new TriangulationPoint(0.671213, -2.621006),
                new TriangulationPoint(2.207561, -0.215379),
                new TriangulationPoint(7.59141, 5.571426),
                new TriangulationPoint(3.102594, 1.140244),
                new TriangulationPoint(9.206415, 4.919501),
                new TriangulationPoint(8.130811, -1.655109),
                new TriangulationPoint(4.784728, 1.075642),
                new TriangulationPoint(2.962008, 0.468808),
                new TriangulationPoint(1.523792, 1.915968),
                new TriangulationPoint(8.298381, 3.798929),
                new TriangulationPoint(2.691718, 2.442044),
                new TriangulationPoint(6.501813, -3.531033),
                new TriangulationPoint(5.799171, -6.914552),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom52_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.161024, -5.616778),
                new TriangulationPoint(2.884983, -4.680649),
                new TriangulationPoint(3.016435, -3.744519),
                new TriangulationPoint(3.406937, -2.808389),
                new TriangulationPoint(4.559012, -4.680649),
                new TriangulationPoint(5.043175, -3.744519),
                new TriangulationPoint(7.245259, 1.184275),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom53_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.09125, -1.986446),
                new TriangulationPoint(-0.161041, -0.084873),
                new TriangulationPoint(1.952795, -1.960693),
                new TriangulationPoint(2.059797, -0.058039),
                new TriangulationPoint(4.124384, -2.0678),
                new TriangulationPoint(4.199569, 0.016723),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom54_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.912075, 3.78634),
                new TriangulationPoint(-1.498381, 1.403127),
                new TriangulationPoint(-4.961534, 0.551946),
                new TriangulationPoint(-1.302866, -3.990962),
                new TriangulationPoint(0.75346, -4.164016),
                new TriangulationPoint(3.923441, -0.949906),
                new TriangulationPoint(1.309707, 4.580958),
                new TriangulationPoint(-0.8821, 1.842005),
                new TriangulationPoint(-2.250267, 1.919859),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom55_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.468464, -7.29614),
                new TriangulationPoint(-3.431726, -4.29967),
                new TriangulationPoint(12.009217, 2.447386),
                new TriangulationPoint(-3.816817, 0.510946),
                new TriangulationPoint(12.468735, 0.123991),
                new TriangulationPoint(10.619621, 4.773937),
                new TriangulationPoint(5.9662, 4.271873),
                new TriangulationPoint(7.885496, -6.746088),
                new TriangulationPoint(-2.326171, -5.022228),
                new TriangulationPoint(2.501869, -6.010579),
                new TriangulationPoint(6.9652, -5.118773),
                new TriangulationPoint(2.781736, 7.941774),
                new TriangulationPoint(-2.326598, 2.592301),
                new TriangulationPoint(3.306905, -5.173829),
                new TriangulationPoint(12.140313, 4.985033),
                new TriangulationPoint(10.669067, 5.575269),
                new TriangulationPoint(-4.764293, -6.325564),
                new TriangulationPoint(1.838601, -1.732952),
                new TriangulationPoint(0.197495, 1.907386),
                new TriangulationPoint(11.582789, 7.902609),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom56_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.302341, 1.18335),
                new TriangulationPoint(8.665634, 3.912285),
                new TriangulationPoint(8.640364, -0.92642),
                new TriangulationPoint(4.691527, 3.619683),
                new TriangulationPoint(9.425822, -3.932348),
                new TriangulationPoint(5.534955, 4.545058),
                new TriangulationPoint(1.742121, -0.620085),
                new TriangulationPoint(1.031768, -0.875066),
                new TriangulationPoint(4.958012, 1.31889),
                new TriangulationPoint(5.616047, 5.252959),
                new TriangulationPoint(3.301358, -3.323932),
                new TriangulationPoint(1.479048, 4.582189),
                new TriangulationPoint(3.51283, -0.225604),
                new TriangulationPoint(5.27795, -3.926046),
                new TriangulationPoint(4.131943, 1.462599),
                new TriangulationPoint(0.24747, -3.697795),
                new TriangulationPoint(2.208908, 0.099056),
                new TriangulationPoint(5.344296, 3.866032),
                new TriangulationPoint(4.985702, -5.843735),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom57_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.007122, -2.936436),
                new TriangulationPoint(3.531275, -2.44703),
                new TriangulationPoint(3.875518, -1.957624),
                new TriangulationPoint(5.33788, -2.44703),
                new TriangulationPoint(5.825022, -1.957624),
                new TriangulationPoint(6.246872, -1.468218),
                new TriangulationPoint(6.474653, -0.978812),
                new TriangulationPoint(5.993195, 3.606273),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom58_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.053838, -2.096115),
                new TriangulationPoint(0.097941, 0.063611),
                new TriangulationPoint(-0.138585, 1.945037),
                new TriangulationPoint(0.158292, 3.803296),
                new TriangulationPoint(1.940522, -1.857078),
                new TriangulationPoint(2.173991, -0.177189),
                new TriangulationPoint(2.142857, 1.893837),
                new TriangulationPoint(2.171015, 4.006387),
                new TriangulationPoint(4.13224, -2.11643),
                new TriangulationPoint(3.854298, 0.144684),
                new TriangulationPoint(3.847234, 2.077036),
                new TriangulationPoint(3.812408, 4.193327),
                new TriangulationPoint(6.057566, -1.857002),
                new TriangulationPoint(5.884849, 0.113368),
                new TriangulationPoint(5.808079, 1.857183),
                new TriangulationPoint(5.919931, 3.990997),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom59_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.33424, -2.184168),
                new TriangulationPoint(2.326423, -3.746441),
                new TriangulationPoint(2.633888, -0.915506),
                new TriangulationPoint(2.555244, 0.788582),
                new TriangulationPoint(-0.89388, 4.49212),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom60_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.026319, 0.339992),
                new TriangulationPoint(-2.567365, -1.312742),
                new TriangulationPoint(12.259243, 2.879344),
                new TriangulationPoint(4.477651, 5.327416),
                new TriangulationPoint(-2.986169, 4.483789),
                new TriangulationPoint(13.670558, 5.369539),
                new TriangulationPoint(1.534691, 7.422697),
                new TriangulationPoint(4.710079, 7.512664),
                new TriangulationPoint(11.969221, -1.888771),
                new TriangulationPoint(1.92748, 2.881069),
                new TriangulationPoint(2.586791, 0.314679),
                new TriangulationPoint(1.989911, -1.311543),
                new TriangulationPoint(10.395492, -4.984884),
                new TriangulationPoint(13.221584, 4.337308),
                new TriangulationPoint(14.104126, -1.839628),
                new TriangulationPoint(4.457134, 1.893889),
                new TriangulationPoint(-1.601685, -2.809188),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom61_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.730134, -2.222042),
                new TriangulationPoint(2.739702, 3.577364),
                new TriangulationPoint(9.030318, -2.44867),
                new TriangulationPoint(6.13721, -0.179945),
                new TriangulationPoint(4.378685, 4.891506),
                new TriangulationPoint(6.042975, 2.382225),
                new TriangulationPoint(2.898509, 1.381524),
                new TriangulationPoint(0.664376, -1.105404),
                new TriangulationPoint(1.380491, 2.359922),
                new TriangulationPoint(0.554951, 1.485815),
                new TriangulationPoint(5.937508, 5.76744),
                new TriangulationPoint(6.22531, 0.749394),
                new TriangulationPoint(4.473516, -6.549423),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom62_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.749984, -6.704134),
                new TriangulationPoint(3.412142, -5.586779),
                new TriangulationPoint(3.889407, -4.469423),
                new TriangulationPoint(3.99853, -3.352067),
                new TriangulationPoint(4.902178, -5.586779),
                new TriangulationPoint(5.125236, -4.469423),
                new TriangulationPoint(5.662498, -3.352067),
                new TriangulationPoint(5.943723, -2.234711),
                new TriangulationPoint(2.62975, 4.831083),
                new TriangulationPoint(4.325239, 2.581958),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom63_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.121478, -2.144937),
                new TriangulationPoint(0.104933, 0.154704),
                new TriangulationPoint(1.92204, -2.150682),
                new TriangulationPoint(2.094767, 0.131339),
                new TriangulationPoint(4.17824, -1.956161),
                new TriangulationPoint(3.825224, -0.192637),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom64_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.3308, -1.151821),
                new TriangulationPoint(1.926018, 1.596791),
                new TriangulationPoint(-1.044738, 3.718288),
                new TriangulationPoint(-4.553394, 1.245692),
                new TriangulationPoint(-4.018356, -1.032361),
                new TriangulationPoint(-0.075665, -4.552598),
                new TriangulationPoint(3.945233, -0.880812),
                new TriangulationPoint(1.363707, 2.961377),
                new TriangulationPoint(-2.556733, 1.886715),
                new TriangulationPoint(-3.228656, -1.649718),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom65_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(10.126179, 6.515832),
                new TriangulationPoint(14.34752, 0.295255),
                new TriangulationPoint(0.491537, 1.127967),
                new TriangulationPoint(7.790711, 6.784761),
                new TriangulationPoint(6.125671, 0.45008),
                new TriangulationPoint(6.958141, -2.51449),
                new TriangulationPoint(11.716823, 7.526648),
                new TriangulationPoint(2.057475, -3.05357),
                new TriangulationPoint(10.545859, 3.3483),
                new TriangulationPoint(-1.231518, -7.379967),
                new TriangulationPoint(4.313957, 0.034611),
                new TriangulationPoint(9.689505, 6.378111),
                new TriangulationPoint(11.414318, -5.28204),
                new TriangulationPoint(8.835968, -7.007051),
                new TriangulationPoint(-2.997025, 7.293806),
                new TriangulationPoint(6.122755, 1.638559),
                new TriangulationPoint(-4.874849, -4.774298),
                new TriangulationPoint(-4.30169, -3.252883),
                new TriangulationPoint(0.970813, -5.77059),
                new TriangulationPoint(-0.09578, 7.04176),
                new TriangulationPoint(-1.470572, 5.458367),
                new TriangulationPoint(-0.247885, 4.572023),
                new TriangulationPoint(-4.149663, -0.202095),
                new TriangulationPoint(3.395529, 0.754206),
                new TriangulationPoint(7.962015, -6.329124),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom66_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.710517, 3.410816),
                new TriangulationPoint(4.503673, 0.465291),
                new TriangulationPoint(1.854163, 4.363862),
                new TriangulationPoint(9.231056, -2.290742),
                new TriangulationPoint(0.141146, 0.528906),
                new TriangulationPoint(6.696576, 5.272171),
                new TriangulationPoint(7.102013, 2.793418),
                new TriangulationPoint(4.119784, 5.911873),
                new TriangulationPoint(0.339459, -0.636373),
                new TriangulationPoint(0.242413, 2.429418),
                new TriangulationPoint(8.022294, -0.45751),
                new TriangulationPoint(4.854783, 3.102474),
                new TriangulationPoint(1.068711, 1.27918),
                new TriangulationPoint(6.045724, 0.311469),
                new TriangulationPoint(0.508606, 3.836824),
                new TriangulationPoint(5.009548, -5.871572),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom67_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.03177, -5.360516),
                new TriangulationPoint(2.746229, -4.467096),
                new TriangulationPoint(2.933241, -3.573677),
                new TriangulationPoint(3.169503, -2.680258),
                new TriangulationPoint(4.226716, -4.467096),
                new TriangulationPoint(4.808882, -3.573677),
                new TriangulationPoint(5.233114, -2.680258),
                new TriangulationPoint(5.696054, -1.786839),
                new TriangulationPoint(6.288768, -0.893419),
                new TriangulationPoint(9.250199, 3.468899),
                new TriangulationPoint(4.33414, 4.510293),
                new TriangulationPoint(7.405149, 4.858284),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom68_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.140973, -2.121837),
                new TriangulationPoint(0.041614, 0.082542),
                new TriangulationPoint(-0.047845, 1.930962),
                new TriangulationPoint(0.087495, 4.043848),
                new TriangulationPoint(2.017576, -2.11644),
                new TriangulationPoint(2.043206, 0.044747),
                new TriangulationPoint(2.136603, 2.116824),
                new TriangulationPoint(2.074251, 3.810014),
                new TriangulationPoint(4.148476, -2.118571),
                new TriangulationPoint(4.123794, 0.077518),
                new TriangulationPoint(3.913097, 2.170665),
                new TriangulationPoint(3.975243, 3.998604),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom69_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-3.61164, -1.395247),
                new TriangulationPoint(-1.01192, -2.940968),
                new TriangulationPoint(1.198495, -1.739624),
                new TriangulationPoint(2.469075, -0.449891),
                new TriangulationPoint(1.19555, 1.665785),
                new TriangulationPoint(-0.417837, 2.084644),
                new TriangulationPoint(-4.002736, 0.450831),
                new TriangulationPoint(-1.610343, -4.489474),
                new TriangulationPoint(3.734458, -2.962236),
                new TriangulationPoint(4.137229, 0.335057),
                new TriangulationPoint(1.428479, 2.277871),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom70_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.213712, 1.11478),
                new TriangulationPoint(1.498647, 6.849666),
                new TriangulationPoint(2.02495, -7.675967),
                new TriangulationPoint(4.64351, 0.814349),
                new TriangulationPoint(-1.522168, 1.791936),
                new TriangulationPoint(-1.550464, -2.89132),
                new TriangulationPoint(6.467395, 5.051382),
                new TriangulationPoint(0.559532, -5.280898),
                new TriangulationPoint(-1.031182, -1.059368),
                new TriangulationPoint(5.312964, -0.428888),
                new TriangulationPoint(9.113721, -1.105201),
                new TriangulationPoint(9.897172, -4.996995),
                new TriangulationPoint(6.827628, 4.647062),
                new TriangulationPoint(-3.549056, 7.578183),
                new TriangulationPoint(10.674222, 4.862734),
                new TriangulationPoint(8.951262, 0.626221),
                new TriangulationPoint(2.432222, -3.725868),
                new TriangulationPoint(-3.339956, 1.285959),
                new TriangulationPoint(0.624414, -5.429807),
                new TriangulationPoint(8.508408, 3.576076),
                new TriangulationPoint(7.99239, 0.015211),
                new TriangulationPoint(-4.982227, -3.352035),
                new TriangulationPoint(11.605739, 7.519957),
                new TriangulationPoint(-4.999887, 4.329835),
                new TriangulationPoint(6.139015, -7.103956),
                new TriangulationPoint(4.771345, -6.593797),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom71_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.480021, 2.8272),
                new TriangulationPoint(7.542432, 0.14637),
                new TriangulationPoint(9.206051, -3.561601),
                new TriangulationPoint(8.690224, 0.754045),
                new TriangulationPoint(7.576002, 1.645224),
                new TriangulationPoint(0.683062, 0.721065),
                new TriangulationPoint(9.770868, 4.299514),
                new TriangulationPoint(6.682738, 1.307763),
                new TriangulationPoint(6.699153, 0.018646),
                new TriangulationPoint(7.612257, 4.268109),
                new TriangulationPoint(2.347303, 5.990534),
                new TriangulationPoint(0.610876, -2.35918),
                new TriangulationPoint(1.366068, -3.58177),
                new TriangulationPoint(9.751228, 5.38914),
                new TriangulationPoint(4.76005, -5.107711),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom72_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.806854, -2.514115),
                new TriangulationPoint(4.004078, -2.095096),
                new TriangulationPoint(4.392758, -1.676077),
                new TriangulationPoint(5.104524, -2.095096),
                new TriangulationPoint(5.594658, -1.676077),
                new TriangulationPoint(8.278131, 2.568044),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom73_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.097157, -2.197148),
                new TriangulationPoint(0.005824, -0.068255),
                new TriangulationPoint(0.042056, 1.920743),
                new TriangulationPoint(0.083698, 4.018184),
                new TriangulationPoint(1.98114, -2.116198),
                new TriangulationPoint(2.012746, -0.146924),
                new TriangulationPoint(1.889852, 2.011351),
                new TriangulationPoint(1.914963, 4.056889),
                new TriangulationPoint(4.006641, -1.982047),
                new TriangulationPoint(4.063928, -0.023703),
                new TriangulationPoint(4.030359, 2.111689),
                new TriangulationPoint(3.86645, 4.092252),
                new TriangulationPoint(6.023864, -2.126579),
                new TriangulationPoint(5.906661, 0.081213),
                new TriangulationPoint(5.882738, 1.848678),
                new TriangulationPoint(5.80834, 4.145687),
                new TriangulationPoint(8.13581, -2.003538),
                new TriangulationPoint(8.137678, -0.093039),
                new TriangulationPoint(7.987017, 1.949078),
                new TriangulationPoint(8.119968, 4.138981),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom74_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.565635, 3.712941),
                new TriangulationPoint(-2.495265, 1.191515),
                new TriangulationPoint(-2.193444, -3.912309),
                new TriangulationPoint(0.514136, -2.750819),
                new TriangulationPoint(3.834, -1.522354),
                new TriangulationPoint(1.49653, 3.593365),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom75_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(11.40767, -1.134183),
                new TriangulationPoint(5.449072, 7.968869),
                new TriangulationPoint(6.253604, 6.189246),
                new TriangulationPoint(-0.456769, 4.769255),
                new TriangulationPoint(1.353676, 3.952681),
                new TriangulationPoint(14.752256, -5.789979),
                new TriangulationPoint(7.663498, 6.008001),
                new TriangulationPoint(4.40793, 1.867899),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom76_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.535311, 0.876393),
                new TriangulationPoint(4.604039, 1.446189),
                new TriangulationPoint(0.376781, 5.276785),
                new TriangulationPoint(9.668488, -0.030502),
                new TriangulationPoint(6.704702, -3.819701),
                new TriangulationPoint(7.757032, -1.125215),
                new TriangulationPoint(4.670989, 0.574692),
                new TriangulationPoint(1.543569, 5.12004),
                new TriangulationPoint(0.244774, 3.802058),
                new TriangulationPoint(4.615163, 3.061595),
                new TriangulationPoint(6.07122, 0.949324),
                new TriangulationPoint(1.43707, 3.65603),
                new TriangulationPoint(2.687521, -3.914878),
                new TriangulationPoint(5.246166, 2.64818),
                new TriangulationPoint(7.347841, 2.421957),
                new TriangulationPoint(8.974909, -0.266066),
                new TriangulationPoint(0.915566, 1.11164),
                new TriangulationPoint(2.800543, 1.544142),
                new TriangulationPoint(2.932044, 5.123388),
                new TriangulationPoint(2.173778, 0.692443),
                new TriangulationPoint(4.931675, -5.609715),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom77_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.170837, -7.880281),
                new TriangulationPoint(3.740333, -6.5669),
                new TriangulationPoint(4.210721, -5.25352),
                new TriangulationPoint(5.473303, -6.5669),
                new TriangulationPoint(6.030789, -5.25352),
                new TriangulationPoint(6.411711, -3.94014),
                new TriangulationPoint(0.516442, 3.499397),
                new TriangulationPoint(8.420728, 4.533711),
                new TriangulationPoint(3.556047, 2.020661),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom78_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.051282, -2.069022),
                new TriangulationPoint(-0.104942, -0.111575),
                new TriangulationPoint(0.195211, 1.983246),
                new TriangulationPoint(1.947445, -1.922637),
                new TriangulationPoint(2.061558, -0.194691),
                new TriangulationPoint(1.861853, 1.969918),
                new TriangulationPoint(4.065816, -2.180415),
                new TriangulationPoint(3.81792, -0.071727),
                new TriangulationPoint(4.194844, 2.000581),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom79_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.708386, 2.232808),
                new TriangulationPoint(1.663074, 2.994393),
                new TriangulationPoint(-3.259123, 3.12219),
                new TriangulationPoint(-2.504673, -0.906467),
                new TriangulationPoint(-1.567295, -2.892797),
                new TriangulationPoint(2.560443, -1.518792),
                new TriangulationPoint(2.461837, 3.302745),
                new TriangulationPoint(-1.568308, 3.29636),
                new TriangulationPoint(-4.079999, 2.112091),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom80_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.508527, -7.617021),
                new TriangulationPoint(2.578249, 6.968169),
                new TriangulationPoint(14.956768, -1.178129),
                new TriangulationPoint(-4.046848, 2.850526),
                new TriangulationPoint(9.89336, 7.504886),
                new TriangulationPoint(-2.138239, -3.834492),
                new TriangulationPoint(12.166638, 3.922278),
                new TriangulationPoint(-0.925539, -6.17016),
                new TriangulationPoint(8.538089, 0.407117),
                new TriangulationPoint(-3.71931, -7.374345),
                new TriangulationPoint(8.241517, 0.631465),
                new TriangulationPoint(10.839652, -5.290583),
                new TriangulationPoint(-0.00486, -2.973536),
                new TriangulationPoint(-2.832218, -0.613538),
                new TriangulationPoint(8.054324, -5.996841),
                new TriangulationPoint(0.768531, 0.44592),
                new TriangulationPoint(6.026834, 7.469291),
                new TriangulationPoint(0.262069, -5.150804),
                new TriangulationPoint(-4.643132, -6.82513),
                new TriangulationPoint(0.448007, 1.130581),
                new TriangulationPoint(-3.592863, 4.425185),
                new TriangulationPoint(-4.949756, 3.22563),
                new TriangulationPoint(-3.813077, 6.002448),
                new TriangulationPoint(12.477294, 5.09824),
                new TriangulationPoint(9.847122, -6.302063),
                new TriangulationPoint(-0.452267, -2.140482),
                new TriangulationPoint(7.238074, 5.172007),
                new TriangulationPoint(2.667674, -6.873531),
                new TriangulationPoint(13.446281, -4.394315),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom81_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.216758, -1.319291),
                new TriangulationPoint(0.440118, 0.09891),
                new TriangulationPoint(8.10521, 4.681262),
                new TriangulationPoint(0.155009, -0.673463),
                new TriangulationPoint(5.937112, 0.724565),
                new TriangulationPoint(2.361564, -3.555899),
                new TriangulationPoint(9.23901, -1.732308),
                new TriangulationPoint(4.716924, -3.909061),
                new TriangulationPoint(3.519055, -1.931275),
                new TriangulationPoint(2.905764, 3.535369),
                new TriangulationPoint(1.233748, -1.880127),
                new TriangulationPoint(0.888282, -1.581762),
                new TriangulationPoint(0.771283, -0.691557),
                new TriangulationPoint(6.915313, 2.269349),
                new TriangulationPoint(2.761217, 3.686858),
                new TriangulationPoint(5.14492, 5.919774),
                new TriangulationPoint(4.630982, -7.537849),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom82_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.768212, -4.296099),
                new TriangulationPoint(5.151178, -3.580083),
                new TriangulationPoint(5.51603, -2.864066),
                new TriangulationPoint(5.98336, -3.580083),
                new TriangulationPoint(6.557536, -2.864066),
                new TriangulationPoint(8.783899, 3.888616),
                new TriangulationPoint(0.551763, 2.242288),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom83_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.16695, -2.132474),
                new TriangulationPoint(-0.009103, 0.023195),
                new TriangulationPoint(0.023244, 2.086824),
                new TriangulationPoint(-0.115694, 4.127385),
                new TriangulationPoint(2.147533, -2.054968),
                new TriangulationPoint(1.999122, -0.075585),
                new TriangulationPoint(2.015894, 2.006506),
                new TriangulationPoint(1.990626, 4.154895),
                new TriangulationPoint(4.137016, -1.833783),
                new TriangulationPoint(4.142672, 0.000476),
                new TriangulationPoint(3.921591, 2.137966),
                new TriangulationPoint(4.048126, 3.859523),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom84_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.986384, -0.701412),
                new TriangulationPoint(0.574559, -4.188003),
                new TriangulationPoint(4.784216, 0.041253),
                new TriangulationPoint(0.414128, 3.978747),
                new TriangulationPoint(-2.042036, 0.436119),
                new TriangulationPoint(-1.310857, -2.72118),
                new TriangulationPoint(0.054398, -2.159019),
                new TriangulationPoint(2.468232, -0.300571),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom85_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.034329, -6.911819),
                new TriangulationPoint(-2.344014, 1.097607),
                new TriangulationPoint(-1.377359, 1.139933),
                new TriangulationPoint(1.010662, -5.531403),
                new TriangulationPoint(14.167472, 4.412958),
                new TriangulationPoint(4.407341, -0.184669),
                new TriangulationPoint(8.91607, 0.829079),
                new TriangulationPoint(11.114263, -6.59784),
                new TriangulationPoint(1.16633, 2.838916),
                new TriangulationPoint(-0.809971, -3.33527),
                new TriangulationPoint(2.222397, -3.031976),
                new TriangulationPoint(12.868473, -6.772528),
                new TriangulationPoint(5.505937, 5.170808),
                new TriangulationPoint(7.584896, 3.359497),
                new TriangulationPoint(-3.916643, -2.285395),
                new TriangulationPoint(-0.046588, -2.434808),
                new TriangulationPoint(0.701272, 1.753369),
                new TriangulationPoint(11.66167, 2.740576),
                new TriangulationPoint(5.070423, -3.309536),
                new TriangulationPoint(10.666458, -3.82899),
                new TriangulationPoint(14.751701, 0.593082),
                new TriangulationPoint(-0.901945, 7.997915),
                new TriangulationPoint(3.508657, -6.114437),
                new TriangulationPoint(5.001223, -1.482655),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom86_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.706037, 0.281649),
                new TriangulationPoint(5.610971, 3.45334),
                new TriangulationPoint(0.969811, 0.011272),
                new TriangulationPoint(4.966694, -0.70327),
                new TriangulationPoint(2.077992, 1.954769),
                new TriangulationPoint(3.57879, 4.813436),
                new TriangulationPoint(8.682158, 4.365131),
                new TriangulationPoint(1.622153, 0.345579),
                new TriangulationPoint(2.195299, -1.410907),
                new TriangulationPoint(4.135997, -7.332019),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom87_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.036557, -5.094194),
                new TriangulationPoint(3.143552, -4.245162),
                new TriangulationPoint(3.310109, -3.396129),
                new TriangulationPoint(3.751381, -2.547097),
                new TriangulationPoint(3.90402, -1.698065),
                new TriangulationPoint(4.341222, -0.849032),
                new TriangulationPoint(4.144523, -4.245162),
                new TriangulationPoint(4.668667, -3.396129),
                new TriangulationPoint(8.075369, 1.854013),
                new TriangulationPoint(4.158612, 4.277437),
                new TriangulationPoint(8.109011, 4.957819),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom88_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.107071, -2.180064),
                new TriangulationPoint(0.140137, 0.168102),
                new TriangulationPoint(2.068117, -1.971824),
                new TriangulationPoint(2.074967, -0.097695),
                new TriangulationPoint(3.90422, -2.031963),
                new TriangulationPoint(3.892753, -0.125719),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom89_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.671235, 1.274759),
                new TriangulationPoint(-4.561299, -0.971682),
                new TriangulationPoint(-1.759448, -4.140082),
                new TriangulationPoint(4.118524, -2.653471),
                new TriangulationPoint(3.118641, 3.690218),
                new TriangulationPoint(-1.384088, 1.579509),
                new TriangulationPoint(-4.237949, -1.161638),
                new TriangulationPoint(0.919198, -3.671126),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom90_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(14.513047, -1.228852),
                new TriangulationPoint(-4.985367, 0.465349),
                new TriangulationPoint(13.659768, -2.172466),
                new TriangulationPoint(9.283203, -2.56864),
                new TriangulationPoint(13.462128, -1.672292),
                new TriangulationPoint(11.438322, 5.388851),
                new TriangulationPoint(11.082962, 2.352828),
                new TriangulationPoint(0.267087, 7.208676),
                new TriangulationPoint(13.007909, -3.088522),
                new TriangulationPoint(0.555296, 3.306145),
                new TriangulationPoint(10.964822, -3.913315),
                new TriangulationPoint(4.546789, 7.86744),
                new TriangulationPoint(2.838798, 4.937738),
                new TriangulationPoint(9.607453, -1.293227),
                new TriangulationPoint(6.079958, 2.859766),
                new TriangulationPoint(-3.323913, 0.256015),
                new TriangulationPoint(4.296881, 2.027988),
                new TriangulationPoint(1.37862, 4.660738),
                new TriangulationPoint(-4.546195, -5.780119),
                new TriangulationPoint(2.306212, -3.212162),
                new TriangulationPoint(13.323633, -6.885706),
                new TriangulationPoint(0.907638, -1.511687),
                new TriangulationPoint(1.170658, 0.140365),
                new TriangulationPoint(7.663798, -6.894643),
                new TriangulationPoint(14.518053, 3.021132),
                new TriangulationPoint(8.194383, 0.015249),
                new TriangulationPoint(3.055549, 6.883323),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom91_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.533209, -2.958902),
                new TriangulationPoint(0.625274, -1.170576),
                new TriangulationPoint(3.651359, 5.943635),
                new TriangulationPoint(5.841989, -2.931457),
                new TriangulationPoint(5.621197, 3.309072),
                new TriangulationPoint(4.667455, 1.193805),
                new TriangulationPoint(2.41758, 0.04682),
                new TriangulationPoint(6.70934, 3.298484),
                new TriangulationPoint(1.470662, -1.537689),
                new TriangulationPoint(9.377316, -1.501906),
                new TriangulationPoint(5.289416, 0.982177),
                new TriangulationPoint(2.92525, -2.299699),
                new TriangulationPoint(7.894505, -3.315237),
                new TriangulationPoint(8.018327, 3.53785),
                new TriangulationPoint(3.223002, -3.66664),
                new TriangulationPoint(3.289614, -1.807862),
                new TriangulationPoint(5.69823, -1.716518),
                new TriangulationPoint(7.767911, -2.09548),
                new TriangulationPoint(2.659559, 0.475225),
                new TriangulationPoint(3.226688, -3.262965),
                new TriangulationPoint(5.542969, -2.008211),
                new TriangulationPoint(4.059017, -7.325377),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom92_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.289809, -5.470285),
                new TriangulationPoint(3.608806, -4.558571),
                new TriangulationPoint(3.827989, -3.646857),
                new TriangulationPoint(4.012463, -2.735143),
                new TriangulationPoint(4.131824, -1.823428),
                new TriangulationPoint(4.376924, -0.911714),
                new TriangulationPoint(4.58401, -4.558571),
                new TriangulationPoint(5.104894, -3.646857),
                new TriangulationPoint(3.933464, 2.517243),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom93_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.010003, -2.022789),
                new TriangulationPoint(-0.097308, 0.15064),
                new TriangulationPoint(1.911453, -2.173782),
                new TriangulationPoint(1.978783, -0.071423),
                new TriangulationPoint(3.86561, -1.954093),
                new TriangulationPoint(3.881863, 0.044665),
                new TriangulationPoint(5.807969, -2.172259),
                new TriangulationPoint(6.017725, -0.107396),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom94_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.35076, 0.235816),
                new TriangulationPoint(-1.937435, -3.443283),
                new TriangulationPoint(2.564092, -3.506688),
                new TriangulationPoint(2.225621, -1.073854),
                new TriangulationPoint(2.635444, 0.644291),
                new TriangulationPoint(-0.497113, 4.675443),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom95_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.047164, 7.329916),
                new TriangulationPoint(-4.464151, 6.412749),
                new TriangulationPoint(3.431136, 6.316405),
                new TriangulationPoint(7.69039, -7.910205),
                new TriangulationPoint(11.336148, -5.439929),
                new TriangulationPoint(7.841772, 0.672783),
                new TriangulationPoint(14.536322, -2.963069),
                new TriangulationPoint(14.37253, -5.733038),
                new TriangulationPoint(7.25087, 6.985913),
                new TriangulationPoint(3.998087, 3.760448),
                new TriangulationPoint(-4.762293, -0.420305),
                new TriangulationPoint(9.783209, 3.806358),
                new TriangulationPoint(1.513768, -5.853071),
                new TriangulationPoint(14.782009, 0.498925),
                new TriangulationPoint(7.199439, 2.153731),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom96_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.26814, 1.589695),
                new TriangulationPoint(1.710628, 2.417773),
                new TriangulationPoint(4.629402, 0.680388),
                new TriangulationPoint(0.949056, 3.110315),
                new TriangulationPoint(8.881556, -3.794576),
                new TriangulationPoint(7.670536, -1.92603),
                new TriangulationPoint(4.056162, -2.901639),
                new TriangulationPoint(7.435297, 2.057854),
                new TriangulationPoint(4.203072, 4.819868),
                new TriangulationPoint(6.809039, 2.280427),
                new TriangulationPoint(8.436308, 1.904932),
                new TriangulationPoint(5.701005, -6.025237),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom97_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.549965, -7.90665),
                new TriangulationPoint(4.88554, -6.588875),
                new TriangulationPoint(5.269449, -5.2711),
                new TriangulationPoint(5.610776, -3.953325),
                new TriangulationPoint(5.753129, -2.63555),
                new TriangulationPoint(5.792861, -6.588875),
                new TriangulationPoint(6.386988, -5.2711),
                new TriangulationPoint(0.405123, 3.913907),
                new TriangulationPoint(7.391178, 3.48929),
                new TriangulationPoint(7.210741, 1.811875),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom98_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.106415, -2.051898),
                new TriangulationPoint(0.006759, -0.119156),
                new TriangulationPoint(0.049343, 2.112717),
                new TriangulationPoint(-0.1271, 3.863958),
                new TriangulationPoint(2.04247, -2.022714),
                new TriangulationPoint(1.847022, 0.116423),
                new TriangulationPoint(2.12019, 2.104919),
                new TriangulationPoint(1.952132, 3.931769),
                new TriangulationPoint(3.941164, -1.88486),
                new TriangulationPoint(3.931817, 0.128461),
                new TriangulationPoint(3.924648, 2.01231),
                new TriangulationPoint(4.112604, 3.859142),
                new TriangulationPoint(6.179021, -2.163074),
                new TriangulationPoint(5.813729, -0.041587),
                new TriangulationPoint(6.053232, 2.187718),
                new TriangulationPoint(5.801792, 3.879076),
                new TriangulationPoint(8.054457, -1.98219),
                new TriangulationPoint(7.97273, -0.106629),
                new TriangulationPoint(7.986033, 1.905317),
                new TriangulationPoint(7.826343, 3.975111),
                new TriangulationPoint(9.958242, -2.188864),
                new TriangulationPoint(9.850032, -0.170833),
                new TriangulationPoint(10.184928, 2.100151),
                new TriangulationPoint(9.968057, 4.087561),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom99_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.061023, 1.101608),
                new TriangulationPoint(-0.909316, 4.698455),
                new TriangulationPoint(-4.726, -0.881072),
                new TriangulationPoint(-3.055737, -2.543278),
                new TriangulationPoint(-0.067204, -2.491844),
                new TriangulationPoint(1.84307, -4.300727),
                new TriangulationPoint(4.248048, 1.300639),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom100_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(12.885203, 1.702009),
                new TriangulationPoint(6.612674, 3.077717),
                new TriangulationPoint(6.349189, 2.077463),
                new TriangulationPoint(0.704626, 0.963799),
                new TriangulationPoint(3.584314, 1.129952),
                new TriangulationPoint(7.282154, 6.219265),
                new TriangulationPoint(9.333102, 5.402055),
                new TriangulationPoint(-1.191875, -3.688714),
                new TriangulationPoint(8.903984, 2.397305),
                new TriangulationPoint(-4.065006, -0.019283),
                new TriangulationPoint(10.498011, 4.914098),
                new TriangulationPoint(1.36974, 4.344699),
                new TriangulationPoint(9.219201, 1.316337),
                new TriangulationPoint(8.66096, -1.509221),
                new TriangulationPoint(3.090589, -4.50565),
                new TriangulationPoint(3.493381, -7.50281),
                new TriangulationPoint(12.087977, -4.784164),
                new TriangulationPoint(9.586533, 5.041055),
                new TriangulationPoint(-2.975478, 7.311025),
                new TriangulationPoint(-0.715382, -6.211562),
                new TriangulationPoint(5.841153, 7.382723),
                new TriangulationPoint(2.335527, -6.247943),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom101_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.835749, -2.390826),
                new TriangulationPoint(6.321418, 2.251838),
                new TriangulationPoint(3.429378, -1.324381),
                new TriangulationPoint(1.990308, 1.045384),
                new TriangulationPoint(2.388244, 2.629416),
                new TriangulationPoint(1.797413, -0.999944),
                new TriangulationPoint(9.316627, 5.224828),
                new TriangulationPoint(9.506483, -2.042926),
                new TriangulationPoint(3.913549, 1.845149),
                new TriangulationPoint(5.840387, -6.529765),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom102_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.831419, -4.771341),
                new TriangulationPoint(3.625842, -3.976118),
                new TriangulationPoint(3.969788, -3.180894),
                new TriangulationPoint(5.151224, -3.976118),
                new TriangulationPoint(5.407875, -3.180894),
                new TriangulationPoint(0.054001, 2.710123),
                new TriangulationPoint(3.9798, 1.83656),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom103_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.082383, -1.931624),
                new TriangulationPoint(-0.192606, 0.080789),
                new TriangulationPoint(0.136978, 2.19205),
                new TriangulationPoint(1.822633, -1.92363),
                new TriangulationPoint(2.187742, -0.119927),
                new TriangulationPoint(1.903359, 2.037357),
                new TriangulationPoint(4.074385, -2.172042),
                new TriangulationPoint(3.963644, 0.086444),
                new TriangulationPoint(4.112537, 2.164339),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom104_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-3.018976, -2.700299),
                new TriangulationPoint(1.239406, -1.855663),
                new TriangulationPoint(2.605173, -0.860974),
                new TriangulationPoint(1.410533, 2.336668),
                new TriangulationPoint(-1.396346, 3.306755),
                new TriangulationPoint(-4.286452, 1.913058),
                new TriangulationPoint(-2.278635, -1.421444),
                new TriangulationPoint(2.427468, -3.965534),
                new TriangulationPoint(4.390453, 1.737639),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom105_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(12.112594, -3.182651),
                new TriangulationPoint(12.683791, -1.028077),
                new TriangulationPoint(4.531769, 4.450962),
                new TriangulationPoint(-2.192309, -0.24529),
                new TriangulationPoint(-1.323551, 6.711995),
                new TriangulationPoint(-4.291335, -7.231577),
                new TriangulationPoint(-0.261497, -4.691077),
                new TriangulationPoint(5.31162, -3.234804),
                new TriangulationPoint(11.317443, -2.876807),
                new TriangulationPoint(-2.437344, 2.118238),
                new TriangulationPoint(4.516462, -6.288686),
                new TriangulationPoint(6.312533, -1.722598),
                new TriangulationPoint(-4.610001, 1.871938),
                new TriangulationPoint(6.56623, -2.66791),
                new TriangulationPoint(-0.581491, 7.459251),
                new TriangulationPoint(2.443055, 4.047966),
                new TriangulationPoint(-4.450938, -1.609167),
                new TriangulationPoint(7.008882, 2.55984),
                new TriangulationPoint(11.659914, 5.846796),
                new TriangulationPoint(-0.530586, 3.515743),
                new TriangulationPoint(-0.585158, -7.340787),
                new TriangulationPoint(3.726135, 5.039865),
                new TriangulationPoint(13.961806, 3.427194),
                new TriangulationPoint(1.80593, -0.690027),
                new TriangulationPoint(12.128749, 5.850438),
                new TriangulationPoint(-1.842269, 0.910339),
                new TriangulationPoint(-0.630405, 3.201508),
                new TriangulationPoint(5.1257, 0.609694),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom106_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.723815, -1.440825),
                new TriangulationPoint(0.464249, -1.292375),
                new TriangulationPoint(7.271211, 1.067017),
                new TriangulationPoint(9.22973, 3.660544),
                new TriangulationPoint(9.553995, -0.774411),
                new TriangulationPoint(1.808074, -2.565625),
                new TriangulationPoint(9.227311, 5.373609),
                new TriangulationPoint(2.403287, 0.421084),
                new TriangulationPoint(2.04718, -1.931455),
                new TriangulationPoint(9.796517, 2.938264),
                new TriangulationPoint(4.17129, 3.390875),
                new TriangulationPoint(9.052849, 4.08869),
                new TriangulationPoint(3.294065, -3.785678),
                new TriangulationPoint(6.398612, 2.969658),
                new TriangulationPoint(5.494255, -5.925958),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom107_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.04679, -5.187756),
                new TriangulationPoint(4.186032, -4.32313),
                new TriangulationPoint(4.348293, -3.458504),
                new TriangulationPoint(4.451018, -2.593878),
                new TriangulationPoint(4.883639, -1.729252),
                new TriangulationPoint(5.258767, -4.32313),
                new TriangulationPoint(5.844254, -3.458504),
                new TriangulationPoint(5.616407, 2.03905),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom108_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.085675, -2.108797),
                new TriangulationPoint(0.166636, -0.022538),
                new TriangulationPoint(1.815288, -1.988293),
                new TriangulationPoint(1.819004, -0.199465),
                new TriangulationPoint(3.985696, -1.942194),
                new TriangulationPoint(4.170943, 0.03365),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom109_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.448443, -0.636227),
                new TriangulationPoint(3.593095, 0.801346),
                new TriangulationPoint(2.585912, 2.765793),
                new TriangulationPoint(-0.947399, 2.214067),
                new TriangulationPoint(-1.899912, 1.168539),
                new TriangulationPoint(-2.453212, -3.90489),
                new TriangulationPoint(1.53134, -2.608091),
                new TriangulationPoint(2.495406, 1.362165),
                new TriangulationPoint(1.132964, 1.711398),
                new TriangulationPoint(-2.706604, 3.534059),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom110_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.983379, 0.027874),
                new TriangulationPoint(12.567993, 2.616263),
                new TriangulationPoint(-0.451173, 6.490945),
                new TriangulationPoint(1.115429, -1.642056),
                new TriangulationPoint(-1.832205, 3.95818),
                new TriangulationPoint(2.443496, -1.615578),
                new TriangulationPoint(13.287044, 6.235239),
                new TriangulationPoint(-4.961823, 7.907795),
                new TriangulationPoint(9.722696, 0.231518),
                new TriangulationPoint(14.64001, -5.481024),
                new TriangulationPoint(-2.942949, 6.452144),
                new TriangulationPoint(1.897653, 7.34999),
                new TriangulationPoint(5.060148, 3.583317),
                new TriangulationPoint(8.059982, 0.229488),
                new TriangulationPoint(3.186381, 7.780055),
                new TriangulationPoint(7.39761, 4.308927),
                new TriangulationPoint(12.728491, -3.181466),
                new TriangulationPoint(-1.607451, -7.972738),
                new TriangulationPoint(-4.965604, 4.474471),
                new TriangulationPoint(0.549655, -1.551975),
                new TriangulationPoint(14.569022, 4.287791),
                new TriangulationPoint(-4.437881, -6.549383),
                new TriangulationPoint(9.660319, -7.220563),
                new TriangulationPoint(10.967724, 7.833475),
                new TriangulationPoint(2.372707, -5.969248),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom111_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.907269, 4.226639),
                new TriangulationPoint(6.348795, 4.230228),
                new TriangulationPoint(1.280801, 3.287632),
                new TriangulationPoint(5.725974, 0.154926),
                new TriangulationPoint(4.671425, 5.063078),
                new TriangulationPoint(5.706785, 2.374912),
                new TriangulationPoint(4.445854, 4.272352),
                new TriangulationPoint(1.544002, 4.064975),
                new TriangulationPoint(6.855742, -3.538824),
                new TriangulationPoint(0.136923, -2.720408),
                new TriangulationPoint(9.708254, 4.665045),
                new TriangulationPoint(3.18396, -3.59255),
                new TriangulationPoint(4.046401, 1.26162),
                new TriangulationPoint(0.111809, 5.764196),
                new TriangulationPoint(7.064972, 2.682743),
                new TriangulationPoint(0.972573, 4.760765),
                new TriangulationPoint(7.548144, -3.332235),
                new TriangulationPoint(8.33364, 2.60903),
                new TriangulationPoint(7.473984, -2.947582),
                new TriangulationPoint(9.335279, 2.728825),
                new TriangulationPoint(4.557801, 5.33096),
                new TriangulationPoint(6.410583, 0.080323),
                new TriangulationPoint(7.583871, -3.477265),
                new TriangulationPoint(4.256101, -5.275708),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom112_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.585298, -6.505725),
                new TriangulationPoint(4.719134, -5.421438),
                new TriangulationPoint(5.068012, -4.33715),
                new TriangulationPoint(5.751904, -5.421438),
                new TriangulationPoint(5.997151, -4.33715),
                new TriangulationPoint(6.493227, -3.252863),
                new TriangulationPoint(6.844674, -2.168575),
                new TriangulationPoint(1.313951, 4.75436),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom113_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.015935, -1.850787),
                new TriangulationPoint(0.056511, -0.147007),
                new TriangulationPoint(1.950618, -2.023187),
                new TriangulationPoint(1.981814, -0.072119),
                new TriangulationPoint(4.103341, -1.87905),
                new TriangulationPoint(4.108565, -0.041071),
                new TriangulationPoint(5.885752, -1.831554),
                new TriangulationPoint(5.884807, 0.102199),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom114_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.221643, -1.943486),
                new TriangulationPoint(-0.621189, -4.381998),
                new TriangulationPoint(2.586939, -1.184867),
                new TriangulationPoint(2.629767, 4.127264),
                new TriangulationPoint(-0.68557, 2.195657),
                new TriangulationPoint(-3.007081, -0.965292),
                new TriangulationPoint(0.213975, -2.4081),
                new TriangulationPoint(3.094978, -0.751668),
                new TriangulationPoint(1.809177, 1.175637),
                new TriangulationPoint(-0.612097, 4.206383),
                new TriangulationPoint(-4.767566, 1.412809),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom115_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(8.164049, -2.361474),
                new TriangulationPoint(1.659997, -0.331002),
                new TriangulationPoint(12.771403, 0.972765),
                new TriangulationPoint(-4.683501, 2.544741),
                new TriangulationPoint(2.614484, 0.479842),
                new TriangulationPoint(3.565894, -5.538689),
                new TriangulationPoint(10.296107, -0.684678),
                new TriangulationPoint(4.740011, 3.421944),
                new TriangulationPoint(6.125966, 1.997942),
                new TriangulationPoint(10.660211, -6.147426),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom116_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.009302, -1.267479),
                new TriangulationPoint(1.829211, 1.97135),
                new TriangulationPoint(5.876375, 5.511367),
                new TriangulationPoint(6.604937, 4.070597),
                new TriangulationPoint(5.33125, 5.455187),
                new TriangulationPoint(1.398723, 3.884354),
                new TriangulationPoint(4.233653, 5.664679),
                new TriangulationPoint(6.349417, 1.9244),
                new TriangulationPoint(9.953294, -3.071752),
                new TriangulationPoint(0.596848, -2.852169),
                new TriangulationPoint(5.132453, -6.310131),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom117_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.326673, -4.5167),
                new TriangulationPoint(3.67631, -3.763916),
                new TriangulationPoint(4.100117, -3.011133),
                new TriangulationPoint(4.54054, -2.25835),
                new TriangulationPoint(4.936685, -1.505567),
                new TriangulationPoint(5.189603, -0.752783),
                new TriangulationPoint(4.64631, -3.763916),
                new TriangulationPoint(4.961879, -3.011133),
                new TriangulationPoint(5.505893, -2.25835),
                new TriangulationPoint(5.786546, -1.505567),
                new TriangulationPoint(6.322601, -0.752783),
                new TriangulationPoint(2.458824, 3.204489),
                new TriangulationPoint(1.37753, 1.513796),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom118_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.141433, -2.181342),
                new TriangulationPoint(0.120457, -0.081949),
                new TriangulationPoint(-0.190894, 1.912692),
                new TriangulationPoint(1.814897, -1.930927),
                new TriangulationPoint(1.818234, -0.192593),
                new TriangulationPoint(2.160739, 2.164838),
                new TriangulationPoint(4.094043, -1.903664),
                new TriangulationPoint(3.985925, 0.115286),
                new TriangulationPoint(3.898839, 1.910154),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom119_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.523778, -2.256435),
                new TriangulationPoint(3.26586, -0.604603),
                new TriangulationPoint(2.208218, 2.489167),
                new TriangulationPoint(-0.264679, 2.762517),
                new TriangulationPoint(-1.653274, 1.58694),
                new TriangulationPoint(-2.780896, -2.725729),
                new TriangulationPoint(1.495633, -3.543221),
                new TriangulationPoint(3.384124, -2.313262),
                new TriangulationPoint(2.175428, -0.044082),
                new TriangulationPoint(4.202045, 2.02963),
                new TriangulationPoint(-0.422401, 4.578088),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom120_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.536776, 5.365533),
                new TriangulationPoint(7.129644, 4.465449),
                new TriangulationPoint(9.926233, -2.726003),
                new TriangulationPoint(-0.23038, -4.097147),
                new TriangulationPoint(13.563363, 7.045591),
                new TriangulationPoint(-4.44319, 0.705478),
                new TriangulationPoint(-1.847376, -1.569032),
                new TriangulationPoint(-1.727792, 7.149496),
                new TriangulationPoint(13.735729, 7.001499),
                new TriangulationPoint(4.813567, -2.08456),
                new TriangulationPoint(-2.612405, 6.792022),
                new TriangulationPoint(4.927445, -4.440527),
                new TriangulationPoint(-1.540405, 3.488461),
                new TriangulationPoint(0.200274, 1.836732),
                new TriangulationPoint(-3.803705, -4.615309),
                new TriangulationPoint(4.35826, -3.066041),
                new TriangulationPoint(-2.451894, 7.144922),
                new TriangulationPoint(-1.313433, -5.789812),
                new TriangulationPoint(0.123711, 0.3749),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom121_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.767409, 5.890962),
                new TriangulationPoint(1.7238, 0.950989),
                new TriangulationPoint(1.025522, 1.303713),
                new TriangulationPoint(1.398892, 1.995653),
                new TriangulationPoint(5.754382, -1.592269),
                new TriangulationPoint(7.122686, -3.605761),
                new TriangulationPoint(3.497799, -1.144163),
                new TriangulationPoint(0.29658, 3.706533),
                new TriangulationPoint(4.457684, 3.677363),
                new TriangulationPoint(6.829604, 3.587795),
                new TriangulationPoint(2.997331, -3.196639),
                new TriangulationPoint(6.977436, 3.758223),
                new TriangulationPoint(4.652775, 1.11804),
                new TriangulationPoint(3.413406, 5.861644),
                new TriangulationPoint(6.010775, 0.713965),
                new TriangulationPoint(1.046791, -0.484799),
                new TriangulationPoint(9.21686, 0.43514),
                new TriangulationPoint(6.081916, 3.423626),
                new TriangulationPoint(4.461405, 4.141245),
                new TriangulationPoint(8.628014, -3.62817),
                new TriangulationPoint(2.295463, 0.98775),
                new TriangulationPoint(4.213255, -7.718168),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom122_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.89162, -7.262569),
                new TriangulationPoint(4.0712, -6.052141),
                new TriangulationPoint(4.459449, -4.841713),
                new TriangulationPoint(4.572587, -3.631285),
                new TriangulationPoint(5.205164, -6.052141),
                new TriangulationPoint(5.753372, -4.841713),
                new TriangulationPoint(7.493231, 3.767724),
                new TriangulationPoint(2.526053, 4.024397),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom123_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.130079, -1.927096),
                new TriangulationPoint(0.109337, 0.072454),
                new TriangulationPoint(0.166281, 1.909113),
                new TriangulationPoint(0.074541, 4.123624),
                new TriangulationPoint(1.859939, -1.905673),
                new TriangulationPoint(2.134298, 0.02138),
                new TriangulationPoint(2.105591, 2.069892),
                new TriangulationPoint(2.129187, 3.882131),
                new TriangulationPoint(4.149494, -2.146502),
                new TriangulationPoint(3.994656, -0.078571),
                new TriangulationPoint(4.119199, 2.13256),
                new TriangulationPoint(3.95786, 3.94045),
                new TriangulationPoint(5.960323, -2.186044),
                new TriangulationPoint(5.921455, 0.158533),
                new TriangulationPoint(5.829492, 2.066642),
                new TriangulationPoint(5.884918, 4.008248),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom124_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-3.302966, -1.121778),
                new TriangulationPoint(-1.4978, -1.604297),
                new TriangulationPoint(0.468059, -3.275011),
                new TriangulationPoint(2.822396, -3.00785),
                new TriangulationPoint(2.667609, 0.680797),
                new TriangulationPoint(2.4267, 3.227818),
                new TriangulationPoint(0.605623, 3.149973),
                new TriangulationPoint(-3.664299, 2.436889),
                new TriangulationPoint(-3.085281, 0.186308),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom125_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.360893, 5.330406),
                new TriangulationPoint(6.800839, -2.062387),
                new TriangulationPoint(3.062654, -2.173582),
                new TriangulationPoint(7.774812, 2.541154),
                new TriangulationPoint(-2.325821, -0.793041),
                new TriangulationPoint(-0.662433, 1.030708),
                new TriangulationPoint(-4.388497, 1.864603),
                new TriangulationPoint(5.971024, 3.734694),
                new TriangulationPoint(9.635056, -3.470774),
                new TriangulationPoint(2.058102, 6.625461),
                new TriangulationPoint(-4.605246, -5.819762),
                new TriangulationPoint(13.427909, 4.191604),
                new TriangulationPoint(-0.710432, 0.059161),
                new TriangulationPoint(12.272633, 1.999132),
                new TriangulationPoint(-3.354079, 5.429202),
                new TriangulationPoint(0.407694, -7.846213),
                new TriangulationPoint(5.113786, -3.623386),
                new TriangulationPoint(7.395237, -5.388778),
                new TriangulationPoint(5.329436, -0.974689),
                new TriangulationPoint(5.787846, -7.034249),
                new TriangulationPoint(1.93791, -0.74098),
                new TriangulationPoint(-1.246852, 4.951159),
                new TriangulationPoint(4.016708, 3.529829),
                new TriangulationPoint(14.721409, 3.009257),
                new TriangulationPoint(11.814589, -5.389977),
                new TriangulationPoint(-4.783559, -3.65622),
                new TriangulationPoint(6.671856, 1.555889),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom126_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.068673, -2.724444),
                new TriangulationPoint(4.356805, 5.250922),
                new TriangulationPoint(3.031174, 3.837155),
                new TriangulationPoint(5.487984, 3.977439),
                new TriangulationPoint(8.013789, -0.929798),
                new TriangulationPoint(3.900195, 2.248552),
                new TriangulationPoint(4.956008, -0.961602),
                new TriangulationPoint(8.893568, 1.620856),
                new TriangulationPoint(6.54929, 4.280524),
                new TriangulationPoint(1.010164, -0.367945),
                new TriangulationPoint(6.245554, 5.445041),
                new TriangulationPoint(3.801428, -3.079308),
                new TriangulationPoint(3.987277, 3.286464),
                new TriangulationPoint(6.594233, -3.37612),
                new TriangulationPoint(8.556359, -3.204585),
                new TriangulationPoint(3.587469, 5.560468),
                new TriangulationPoint(2.658714, -2.84797),
                new TriangulationPoint(1.519014, -2.544394),
                new TriangulationPoint(8.785533, -2.478145),
                new TriangulationPoint(8.551444, 4.458972),
                new TriangulationPoint(8.279833, 0.332774),
                new TriangulationPoint(7.331568, -3.809186),
                new TriangulationPoint(4.72257, -5.136824),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom127_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.375015, -7.90539),
                new TriangulationPoint(4.576559, -6.587825),
                new TriangulationPoint(4.919928, -5.27026),
                new TriangulationPoint(5.175407, -3.952695),
                new TriangulationPoint(5.725993, -6.587825),
                new TriangulationPoint(6.317924, -5.27026),
                new TriangulationPoint(8.244522, 2.415547),
                new TriangulationPoint(0.487038, 2.176021),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom128_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.091332, -2.012636),
                new TriangulationPoint(0.016056, 0.164862),
                new TriangulationPoint(-0.091654, 2.067041),
                new TriangulationPoint(0.128815, 3.980033),
                new TriangulationPoint(2.036379, -1.825118),
                new TriangulationPoint(1.80988, 0.087494),
                new TriangulationPoint(1.899635, 1.960898),
                new TriangulationPoint(1.87006, 4.142925),
                new TriangulationPoint(4.04498, -2.169331),
                new TriangulationPoint(4.121517, -0.002289),
                new TriangulationPoint(4.029957, 1.807786),
                new TriangulationPoint(4.063598, 4.069298),
                new TriangulationPoint(5.831864, -2.122144),
                new TriangulationPoint(5.969322, 0.016655),
                new TriangulationPoint(5.966703, 1.872404),
                new TriangulationPoint(5.870516, 4.147206),
                new TriangulationPoint(7.857709, -2.027023),
                new TriangulationPoint(7.996492, -0.111148),
                new TriangulationPoint(8.077219, 1.908232),
                new TriangulationPoint(7.808507, 3.835059),
                new TriangulationPoint(10.162231, -2.033282),
                new TriangulationPoint(10.112947, 0.035656),
                new TriangulationPoint(10.174696, 2.005203),
                new TriangulationPoint(10.102241, 3.97286),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom129_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.498896, 0.60528),
                new TriangulationPoint(-3.525895, -2.32791),
                new TriangulationPoint(-1.422428, -2.335063),
                new TriangulationPoint(-0.413001, -3.038298),
                new TriangulationPoint(2.716209, -1.37135),
                new TriangulationPoint(1.13831, 1.899836),
                new TriangulationPoint(-1.889452, 3.060873),
                new TriangulationPoint(-4.02738, -1.257259),
                new TriangulationPoint(0.359967, -3.465521),
                new TriangulationPoint(3.239086, -2.22668),
                new TriangulationPoint(4.33044, 0.847047),
                new TriangulationPoint(2.838784, 3.45007),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom130_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.095774, -2.566009),
                new TriangulationPoint(13.11466, 6.475854),
                new TriangulationPoint(10.817719, 3.696098),
                new TriangulationPoint(1.092322, -4.393209),
                new TriangulationPoint(12.145181, -6.471056),
                new TriangulationPoint(6.434093, 4.905946),
                new TriangulationPoint(-2.467893, -1.032833),
                new TriangulationPoint(-1.217108, 1.665937),
                new TriangulationPoint(8.075729, 6.836036),
                new TriangulationPoint(10.167835, -5.343204),
                new TriangulationPoint(-3.888462, -6.653355),
                new TriangulationPoint(4.528312, 1.658352),
                new TriangulationPoint(2.998374, 7.555996),
                new TriangulationPoint(7.942693, -6.590869),
                new TriangulationPoint(13.9324, 1.879683),
                new TriangulationPoint(3.318367, 3.344644),
                new TriangulationPoint(6.394983, 1.212292),
                new TriangulationPoint(13.479772, -7.542027),
                new TriangulationPoint(6.386656, 6.474925),
                new TriangulationPoint(14.533699, 3.596683),
                new TriangulationPoint(6.786951, 5.640829),
                new TriangulationPoint(11.425972, 7.886892),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom131_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.998896, -0.72603),
                new TriangulationPoint(6.739812, 2.303455),
                new TriangulationPoint(4.193604, -3.047274),
                new TriangulationPoint(7.059393, 5.908149),
                new TriangulationPoint(9.318269, 1.653452),
                new TriangulationPoint(8.704242, 1.086508),
                new TriangulationPoint(7.13325, 3.335679),
                new TriangulationPoint(8.17644, 1.730393),
                new TriangulationPoint(7.85404, -2.758365),
                new TriangulationPoint(3.400211, 0.261659),
                new TriangulationPoint(6.888098, 5.566738),
                new TriangulationPoint(7.101331, 4.131884),
                new TriangulationPoint(6.126234, -0.764538),
                new TriangulationPoint(4.38402, -1.248484),
                new TriangulationPoint(8.605903, 1.198738),
                new TriangulationPoint(5.189851, 2.278296),
                new TriangulationPoint(1.435875, 4.477233),
                new TriangulationPoint(7.179042, -2.970523),
                new TriangulationPoint(5.656301, -1.946715),
                new TriangulationPoint(4.038111, -5.569571),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom132_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.970541, -4.996451),
                new TriangulationPoint(5.124338, -4.163709),
                new TriangulationPoint(5.325116, -3.330967),
                new TriangulationPoint(6.352112, -4.163709),
                new TriangulationPoint(6.891751, -3.330967),
                new TriangulationPoint(8.967689, 4.928697),
                new TriangulationPoint(0.485173, 3.672291),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom133_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.09664, -2.086382),
                new TriangulationPoint(0.074314, -0.068027),
                new TriangulationPoint(0.040057, 1.84673),
                new TriangulationPoint(1.822298, -1.933258),
                new TriangulationPoint(2.090982, 0.059839),
                new TriangulationPoint(1.993995, 1.862559),
                new TriangulationPoint(4.191413, -2.031721),
                new TriangulationPoint(3.83458, 0.199836),
                new TriangulationPoint(3.921075, 1.989238),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom134_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.584207, -1.512451),
                new TriangulationPoint(2.284173, -0.371233),
                new TriangulationPoint(2.033739, 1.944212),
                new TriangulationPoint(-0.477109, 2.038809),
                new TriangulationPoint(-4.473863, -0.239539),
                new TriangulationPoint(-3.366401, -2.573141),
                new TriangulationPoint(2.085175, -3.220937),
                new TriangulationPoint(4.710289, -1.401897),
                new TriangulationPoint(2.453514, 3.991813),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom135_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.445872, -0.195002),
                new TriangulationPoint(2.568884, -4.428809),
                new TriangulationPoint(0.678885, -6.863051),
                new TriangulationPoint(11.994522, -1.674029),
                new TriangulationPoint(8.494464, 0.062201),
                new TriangulationPoint(12.756246, -5.037532),
                new TriangulationPoint(-0.146847, -3.930046),
                new TriangulationPoint(10.002165, -7.446521),
                new TriangulationPoint(8.961367, 5.268873),
                new TriangulationPoint(-2.530061, 5.676911),
                new TriangulationPoint(5.374659, 6.576566),
                new TriangulationPoint(14.804485, 7.664368),
                new TriangulationPoint(2.17106, -0.902801),
                new TriangulationPoint(-1.484967, 7.046059),
                new TriangulationPoint(7.622436, 5.408257),
                new TriangulationPoint(11.415077, -0.595623),
                new TriangulationPoint(13.233121, -0.897234),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom136_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.580651, 2.239752),
                new TriangulationPoint(2.613403, 5.590674),
                new TriangulationPoint(7.489886, 0.762238),
                new TriangulationPoint(5.449489, 2.520034),
                new TriangulationPoint(8.565831, -2.252739),
                new TriangulationPoint(5.390833, -2.047568),
                new TriangulationPoint(0.423424, 3.685082),
                new TriangulationPoint(0.577589, -2.773725),
                new TriangulationPoint(7.461233, 4.887036),
                new TriangulationPoint(9.014075, 2.095373),
                new TriangulationPoint(4.228081, 3.354941),
                new TriangulationPoint(4.287102, 2.291486),
                new TriangulationPoint(5.35224, -7.664412),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom137_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.327269, -2.229884),
                new TriangulationPoint(4.338054, -1.858237),
                new TriangulationPoint(4.818957, -1.486589),
                new TriangulationPoint(5.180543, -1.114942),
                new TriangulationPoint(5.6563, -0.743295),
                new TriangulationPoint(5.886948, -0.371647),
                new TriangulationPoint(5.469671, -1.858237),
                new TriangulationPoint(5.707174, -1.486589),
                new TriangulationPoint(6.102045, -1.114942),
                new TriangulationPoint(5.779792, 4.904161),
                new TriangulationPoint(7.740418, 2.962138),
                new TriangulationPoint(3.491485, 4.260366),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom138_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.157413, -2.084366),
                new TriangulationPoint(-0.070065, -0.114211),
                new TriangulationPoint(0.049425, 2.024403),
                new TriangulationPoint(0.011355, 4.073129),
                new TriangulationPoint(2.077532, -2.087633),
                new TriangulationPoint(1.819447, 0.048942),
                new TriangulationPoint(1.841423, 1.922334),
                new TriangulationPoint(1.847251, 4.177954),
                new TriangulationPoint(3.99586, -1.807956),
                new TriangulationPoint(4.137828, -0.144489),
                new TriangulationPoint(3.877304, 2.0561),
                new TriangulationPoint(3.867467, 4.059525),
                new TriangulationPoint(5.988295, -1.947487),
                new TriangulationPoint(5.842212, -0.040392),
                new TriangulationPoint(5.992721, 2.092706),
                new TriangulationPoint(5.81941, 4.079961),
                new TriangulationPoint(8.139378, -2.01148),
                new TriangulationPoint(8.160476, -0.013391),
                new TriangulationPoint(8.064089, 1.930116),
                new TriangulationPoint(7.898638, 4.187791),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom139_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.593985, 2.211199),
                new TriangulationPoint(-2.098277, 4.138593),
                new TriangulationPoint(-2.724654, 2.001812),
                new TriangulationPoint(-4.165337, -1.202284),
                new TriangulationPoint(-1.882695, -1.698054),
                new TriangulationPoint(-1.586742, -4.167732),
                new TriangulationPoint(1.214832, -3.798275),
                new TriangulationPoint(4.536875, 1.376215),
                new TriangulationPoint(2.760545, 2.820867),
                new TriangulationPoint(0.761314, 4.474984),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom140_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(8.319026, 5.593329),
                new TriangulationPoint(5.271349, 2.894165),
                new TriangulationPoint(6.570239, -2.92091),
                new TriangulationPoint(6.844977, -6.750863),
                new TriangulationPoint(-3.178362, 7.48222),
                new TriangulationPoint(-3.8739, 7.1949),
                new TriangulationPoint(-0.463459, -1.53527),
                new TriangulationPoint(5.043742, -5.40898),
                new TriangulationPoint(7.164492, 6.521199),
                new TriangulationPoint(4.199019, -2.934473),
                new TriangulationPoint(0.162168, -1.326349),
                new TriangulationPoint(1.471068, 2.916029),
                new TriangulationPoint(7.104867, -2.092828),
                new TriangulationPoint(-0.475515, -2.332187),
                new TriangulationPoint(2.160202, 0.599314),
                new TriangulationPoint(-4.708496, 6.195226),
                new TriangulationPoint(11.023315, 3.837389),
                new TriangulationPoint(4.167749, -1.04734),
                new TriangulationPoint(-0.852005, 3.849488),
                new TriangulationPoint(3.809208, 1.792697),
                new TriangulationPoint(1.843791, 5.810849),
                new TriangulationPoint(12.243004, -3.255097),
                new TriangulationPoint(-1.626884, -7.839833),
                new TriangulationPoint(-4.066436, -2.650819),
                new TriangulationPoint(-3.664543, -5.49974),
                new TriangulationPoint(-2.950385, -1.03146),
                new TriangulationPoint(9.855064, -5.265238),
                new TriangulationPoint(8.032679, 4.651606),
                new TriangulationPoint(-0.009235, -4.79625),
                new TriangulationPoint(14.262048, 3.645737),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom141_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.759292, -3.46773),
                new TriangulationPoint(3.441456, -1.26798),
                new TriangulationPoint(0.598495, -2.57758),
                new TriangulationPoint(6.132064, 3.14806),
                new TriangulationPoint(0.573066, 3.257711),
                new TriangulationPoint(4.962784, 2.475572),
                new TriangulationPoint(5.086338, 3.519182),
                new TriangulationPoint(0.609047, 3.771803),
                new TriangulationPoint(4.976401, 3.647722),
                new TriangulationPoint(3.635511, -3.906339),
                new TriangulationPoint(0.934723, 5.50944),
                new TriangulationPoint(4.731235, -6.818125),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom142_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.194839, -5.204671),
                new TriangulationPoint(4.229882, -4.337226),
                new TriangulationPoint(4.341433, -3.469781),
                new TriangulationPoint(4.55075, -2.602336),
                new TriangulationPoint(5.441082, -4.337226),
                new TriangulationPoint(5.905367, -3.469781),
                new TriangulationPoint(6.15619, -2.602336),
                new TriangulationPoint(5.126659, 1.889238),
                new TriangulationPoint(2.142034, 3.808004),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom143_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.054338, -2.02534),
                new TriangulationPoint(-0.152036, 0.15429),
                new TriangulationPoint(-0.025732, 2.023118),
                new TriangulationPoint(0.127955, 4.043732),
                new TriangulationPoint(1.849098, -2.129744),
                new TriangulationPoint(1.971278, -0.074067),
                new TriangulationPoint(1.903632, 1.82658),
                new TriangulationPoint(1.93585, 3.833942),
                new TriangulationPoint(4.001115, -1.813174),
                new TriangulationPoint(3.828216, -0.108506),
                new TriangulationPoint(3.905333, 2.001665),
                new TriangulationPoint(4.144053, 4.026252),
                new TriangulationPoint(6.087479, -2.167716),
                new TriangulationPoint(5.99124, -0.19179),
                new TriangulationPoint(6.135137, 1.939389),
                new TriangulationPoint(6.124815, 3.846095),
                new TriangulationPoint(8.168032, -1.953694),
                new TriangulationPoint(7.805927, -0.059579),
                new TriangulationPoint(8.157671, 2.029601),
                new TriangulationPoint(8.11506, 3.980926),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom144_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.058405, 0.862746),
                new TriangulationPoint(1.28025, 2.538074),
                new TriangulationPoint(0.039134, 2.717368),
                new TriangulationPoint(-1.373752, 1.927712),
                new TriangulationPoint(-4.578501, -1.252854),
                new TriangulationPoint(0.471178, -2.135548),
                new TriangulationPoint(4.006451, -2.895966),
                new TriangulationPoint(2.487265, 2.065569),
                new TriangulationPoint(-2.326474, 3.327454),
                new TriangulationPoint(-3.668136, -1.350539),
                new TriangulationPoint(-0.563001, -3.276864),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom145_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(13.804876, -1.953675),
                new TriangulationPoint(-2.869058, -3.905739),
                new TriangulationPoint(5.645577, -0.461518),
                new TriangulationPoint(9.085796, 6.912459),
                new TriangulationPoint(10.844481, 3.939008),
                new TriangulationPoint(13.021286, 5.577107),
                new TriangulationPoint(8.904758, -2.21965),
                new TriangulationPoint(4.759562, 5.87484),
                new TriangulationPoint(-2.084233, -1.907899),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom146_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.150262, 1.669799),
                new TriangulationPoint(0.17058, 2.775545),
                new TriangulationPoint(3.803106, 5.593387),
                new TriangulationPoint(6.156826, -1.017294),
                new TriangulationPoint(7.660827, -0.166695),
                new TriangulationPoint(0.97811, 3.940581),
                new TriangulationPoint(6.891304, 4.319518),
                new TriangulationPoint(4.051222, 5.702989),
                new TriangulationPoint(5.25003, 1.85815),
                new TriangulationPoint(0.548602, 1.440557),
                new TriangulationPoint(5.74489, 5.314339),
                new TriangulationPoint(5.730138, 0.089251),
                new TriangulationPoint(0.914676, 4.956533),
                new TriangulationPoint(2.569261, 3.15777),
                new TriangulationPoint(1.571411, 5.434183),
                new TriangulationPoint(6.037345, 5.01388),
                new TriangulationPoint(7.0937, -0.414366),
                new TriangulationPoint(7.444923, -1.680341),
                new TriangulationPoint(1.816515, 5.064717),
                new TriangulationPoint(4.183531, -7.46503),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom147_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.033821, -6.983053),
                new TriangulationPoint(3.591717, -5.819211),
                new TriangulationPoint(4.033566, -4.655369),
                new TriangulationPoint(4.352204, -3.491527),
                new TriangulationPoint(5.159754, -5.819211),
                new TriangulationPoint(5.369782, -4.655369),
                new TriangulationPoint(9.863443, 3.355182),
                new TriangulationPoint(0.657561, 1.829148),
                new TriangulationPoint(9.596946, 4.811471),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom148_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.027592, -2.076661),
                new TriangulationPoint(-0.151788, 0.177119),
                new TriangulationPoint(1.906871, -1.830123),
                new TriangulationPoint(2.081377, 0.140548),
                new TriangulationPoint(4.110342, -2.009442),
                new TriangulationPoint(3.937343, 0.163429),
                new TriangulationPoint(6.187783, -2.050916),
                new TriangulationPoint(6.039519, -0.052152),
                new TriangulationPoint(7.905437, -2.130977),
                new TriangulationPoint(7.988769, -0.05314),
                new TriangulationPoint(10.048228, -2.107056),
                new TriangulationPoint(9.860203, -0.02822),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom149_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.854992, 3.114314),
                new TriangulationPoint(-3.902647, -0.845851),
                new TriangulationPoint(0.628085, -3.717966),
                new TriangulationPoint(4.404012, -1.011829),
                new TriangulationPoint(2.091237, 2.029056),
                new TriangulationPoint(1.338173, 4.373915),
                new TriangulationPoint(-0.534626, 3.444658),
                new TriangulationPoint(-2.306877, 1.449172),
                new TriangulationPoint(-2.161499, 0.019314),
                new TriangulationPoint(-2.055422, -1.959624),
                new TriangulationPoint(1.822999, -3.664941),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom150_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(13.026025, 1.144105),
                new TriangulationPoint(-4.269561, 5.90003),
                new TriangulationPoint(8.798962, 2.204179),
                new TriangulationPoint(7.777292, -0.248987),
                new TriangulationPoint(-2.27246, 4.981998),
                new TriangulationPoint(-0.164525, -4.253357),
                new TriangulationPoint(-3.824021, -6.152483),
                new TriangulationPoint(11.386854, -7.061682),
                new TriangulationPoint(10.050269, 5.44605),
                new TriangulationPoint(7.176228, 2.472866),
                new TriangulationPoint(7.986267, 1.737816),
                new TriangulationPoint(14.187784, -2.516446),
                new TriangulationPoint(7.863356, 1.223029),
                new TriangulationPoint(8.721269, -4.790666),
                new TriangulationPoint(3.474685, -0.027025),
                new TriangulationPoint(1.0648, 2.104513),
                new TriangulationPoint(3.293187, -0.997618),
                new TriangulationPoint(9.317212, 7.710417),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom151_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.861479, -1.217723),
                new TriangulationPoint(9.924238, 1.378822),
                new TriangulationPoint(8.392557, -3.49953),
                new TriangulationPoint(7.874375, 3.429148),
                new TriangulationPoint(1.452529, -2.51406),
                new TriangulationPoint(1.892447, 5.200769),
                new TriangulationPoint(4.214583, 0.826165),
                new TriangulationPoint(5.355635, -2.517907),
                new TriangulationPoint(4.675371, 5.538982),
                new TriangulationPoint(5.264418, 5.055441),
                new TriangulationPoint(7.808567, 2.935617),
                new TriangulationPoint(3.018185, 1.587931),
                new TriangulationPoint(7.974246, -0.094543),
                new TriangulationPoint(7.551084, -0.409042),
                new TriangulationPoint(1.815013, -1.079606),
                new TriangulationPoint(4.558139, -2.218333),
                new TriangulationPoint(4.222368, 0.148445),
                new TriangulationPoint(3.731074, 5.3652),
                new TriangulationPoint(4.777852, -1.032748),
                new TriangulationPoint(1.77759, 1.657181),
                new TriangulationPoint(4.219292, -7.433699),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom152_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.760469, -7.040994),
                new TriangulationPoint(3.859221, -5.867495),
                new TriangulationPoint(4.124736, -4.693996),
                new TriangulationPoint(5.005519, -5.867495),
                new TriangulationPoint(5.246578, -4.693996),
                new TriangulationPoint(5.546362, -3.520497),
                new TriangulationPoint(6.035266, -2.346998),
                new TriangulationPoint(6.525563, 3.688481),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom153_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.019077, -1.809139),
                new TriangulationPoint(-0.104568, 0.039234),
                new TriangulationPoint(0.187972, 1.883161),
                new TriangulationPoint(1.83309, -1.948556),
                new TriangulationPoint(2.023763, 0.197449),
                new TriangulationPoint(2.041588, 1.913461),
                new TriangulationPoint(4.023321, -1.996801),
                new TriangulationPoint(4.124248, 0.0052),
                new TriangulationPoint(3.963568, 1.864956),
                new TriangulationPoint(6.073959, -1.931298),
                new TriangulationPoint(5.939865, -0.198583),
                new TriangulationPoint(6.039884, 1.856588),
                new TriangulationPoint(7.856814, -1.940438),
                new TriangulationPoint(7.877634, 0.104307),
                new TriangulationPoint(7.945551, 1.998944),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom154_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.331791, 4.215509),
                new TriangulationPoint(-1.552006, 1.44399),
                new TriangulationPoint(-4.328996, 0.844154),
                new TriangulationPoint(-0.767401, -4.649009),
                new TriangulationPoint(1.99474, -2.749534),
                new TriangulationPoint(2.282145, -1.275543),
                new TriangulationPoint(1.899463, 2.767167),
                new TriangulationPoint(-2.394866, 2.066184),
                new TriangulationPoint(-4.081769, -0.128188),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom155_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.135639, -3.80602),
                new TriangulationPoint(-4.37061, -1.37819),
                new TriangulationPoint(9.249664, 1.20353),
                new TriangulationPoint(0.549074, 1.003042),
                new TriangulationPoint(12.746468, 7.839447),
                new TriangulationPoint(9.801385, -2.751412),
                new TriangulationPoint(9.430684, 4.903853),
                new TriangulationPoint(14.51098, -2.757658),
                new TriangulationPoint(11.618837, -6.734001),
                new TriangulationPoint(8.764445, 3.951554),
                new TriangulationPoint(0.415797, -6.369791),
                new TriangulationPoint(2.624337, -1.9127),
                new TriangulationPoint(-0.106896, 1.396466),
                new TriangulationPoint(-2.024771, 7.322265),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom156_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.309294, 2.795344),
                new TriangulationPoint(4.567203, 5.81503),
                new TriangulationPoint(6.087288, 1.653568),
                new TriangulationPoint(8.526108, 0.503573),
                new TriangulationPoint(0.156381, -0.028232),
                new TriangulationPoint(5.339739, 4.203793),
                new TriangulationPoint(2.574351, 2.324267),
                new TriangulationPoint(6.471231, -1.715855),
                new TriangulationPoint(8.371109, 0.66222),
                new TriangulationPoint(4.584473, -2.103164),
                new TriangulationPoint(6.371924, -1.532344),
                new TriangulationPoint(0.999233, -3.982435),
                new TriangulationPoint(8.388535, 1.168843),
                new TriangulationPoint(7.076179, 3.154038),
                new TriangulationPoint(2.505131, -1.575698),
                new TriangulationPoint(1.329552, 5.710044),
                new TriangulationPoint(2.374904, -0.539508),
                new TriangulationPoint(6.21202, 5.927693),
                new TriangulationPoint(2.602299, -3.187772),
                new TriangulationPoint(9.949441, 5.794694),
                new TriangulationPoint(4.409697, -7.041408),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom157_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.265785, -7.868745),
                new TriangulationPoint(4.578068, -6.557287),
                new TriangulationPoint(5.008688, -5.24583),
                new TriangulationPoint(5.478505, -3.934372),
                new TriangulationPoint(5.955272, -2.622915),
                new TriangulationPoint(5.573629, -6.557287),
                new TriangulationPoint(6.049644, -5.24583),
                new TriangulationPoint(6.307806, -3.934372),
                new TriangulationPoint(1.037903, 4.818194),
                new TriangulationPoint(4.54496, 3.522607),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom158_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.102379, -2.124634),
                new TriangulationPoint(0.066984, 0.004201),
                new TriangulationPoint(-0.050782, 2.048343),
                new TriangulationPoint(0.135918, 3.809196),
                new TriangulationPoint(1.888747, -1.948268),
                new TriangulationPoint(2.07042, -0.157208),
                new TriangulationPoint(2.041839, 1.857357),
                new TriangulationPoint(2.189863, 3.876456),
                new TriangulationPoint(4.08433, -2.163229),
                new TriangulationPoint(4.057064, 0.019066),
                new TriangulationPoint(3.909807, 2.016257),
                new TriangulationPoint(3.917247, 3.897697),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom159_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.981403, -3.766291),
                new TriangulationPoint(1.574544, -4.191807),
                new TriangulationPoint(3.906779, -0.042986),
                new TriangulationPoint(1.903873, 0.785844),
                new TriangulationPoint(1.356088, 4.789881),
                new TriangulationPoint(-2.047539, 1.629059),
                new TriangulationPoint(-3.009297, -3.382222),
                new TriangulationPoint(0.740574, -3.032758),
                new TriangulationPoint(2.050752, 0.044643),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom160_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.441128, -1.529875),
                new TriangulationPoint(1.835341, -4.254011),
                new TriangulationPoint(0.277409, -1.310815),
                new TriangulationPoint(5.712439, -2.729066),
                new TriangulationPoint(11.515642, 3.972096),
                new TriangulationPoint(4.931923, -7.476976),
                new TriangulationPoint(1.915781, -6.250969),
                new TriangulationPoint(-0.93865, -5.758356),
                new TriangulationPoint(9.598686, -2.192607),
                new TriangulationPoint(7.705087, 3.008449),
                new TriangulationPoint(0.93522, -0.304338),
                new TriangulationPoint(6.67316, 7.092798),
                new TriangulationPoint(-3.498385, 7.539159),
                new TriangulationPoint(14.452467, 1.865647),
                new TriangulationPoint(8.671344, -5.299778),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom161_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.600024, -1.920849),
                new TriangulationPoint(4.75074, 3.425877),
                new TriangulationPoint(6.65981, 3.373112),
                new TriangulationPoint(9.496459, 4.26216),
                new TriangulationPoint(9.788417, -3.016029),
                new TriangulationPoint(4.037674, 3.092754),
                new TriangulationPoint(9.511626, -3.38024),
                new TriangulationPoint(1.638367, 1.983627),
                new TriangulationPoint(9.631275, -2.747677),
                new TriangulationPoint(2.233676, 3.768949),
                new TriangulationPoint(6.360476, 0.585132),
                new TriangulationPoint(9.686037, 1.002607),
                new TriangulationPoint(0.759011, 0.409368),
                new TriangulationPoint(6.045263, 2.808391),
                new TriangulationPoint(5.50104, 4.927281),
                new TriangulationPoint(8.887125, -0.843104),
                new TriangulationPoint(8.10436, 4.084151),
                new TriangulationPoint(2.705629, -0.12738),
                new TriangulationPoint(3.219733, 2.967817),
                new TriangulationPoint(5.281977, -5.631239),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom162_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.463114, -2.244349),
                new TriangulationPoint(3.209286, -1.870291),
                new TriangulationPoint(3.552952, -1.496233),
                new TriangulationPoint(3.733543, -1.122175),
                new TriangulationPoint(4.769394, -1.870291),
                new TriangulationPoint(5.272394, -1.496233),
                new TriangulationPoint(2.775788, 1.964466),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom163_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.151543, -1.876097),
                new TriangulationPoint(0.025356, 0.099306),
                new TriangulationPoint(0.034774, 2.128167),
                new TriangulationPoint(2.05225, -1.98713),
                new TriangulationPoint(2.118359, -0.189209),
                new TriangulationPoint(1.961774, 1.882088),
                new TriangulationPoint(3.892379, -1.960546),
                new TriangulationPoint(3.98943, 0.043026),
                new TriangulationPoint(3.819586, 2.060626),
                new TriangulationPoint(5.847539, -2.026628),
                new TriangulationPoint(5.803941, 0.122802),
                new TriangulationPoint(5.811861, 1.811245),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom164_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.256385, -4.123479),
                new TriangulationPoint(2.079959, -3.269503),
                new TriangulationPoint(2.234674, 0.005227),
                new TriangulationPoint(2.231007, 1.709704),
                new TriangulationPoint(-1.831281, 3.327535),
                new TriangulationPoint(-4.7554, 0.252687),
                new TriangulationPoint(-1.270541, -1.997571),
                new TriangulationPoint(-0.074208, -2.702227),
                new TriangulationPoint(1.65939, -2.006714),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom165_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.762404, -0.390093),
                new TriangulationPoint(7.219335, 0.540521),
                new TriangulationPoint(2.927008, -5.495305),
                new TriangulationPoint(12.924538, 7.874867),
                new TriangulationPoint(0.767856, -1.258115),
                new TriangulationPoint(6.623544, 4.809158),
                new TriangulationPoint(0.351001, -5.562038),
                new TriangulationPoint(-3.397657, 0.363454),
                new TriangulationPoint(-1.922865, 2.092899),
                new TriangulationPoint(6.711605, 3.715851),
                new TriangulationPoint(11.186287, 7.804876),
                new TriangulationPoint(1.590664, -3.25206),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom166_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.018056, -3.0287),
                new TriangulationPoint(0.906333, -2.47123),
                new TriangulationPoint(1.056467, 2.492633),
                new TriangulationPoint(6.569348, 4.106958),
                new TriangulationPoint(0.427865, -3.442841),
                new TriangulationPoint(4.174611, -3.501938),
                new TriangulationPoint(3.586078, -3.375864),
                new TriangulationPoint(0.082437, 3.556688),
                new TriangulationPoint(3.810029, 0.854032),
                new TriangulationPoint(4.060522, 2.959963),
                new TriangulationPoint(0.315627, 4.979829),
                new TriangulationPoint(9.608325, -3.337403),
                new TriangulationPoint(6.601254, 3.843748),
                new TriangulationPoint(4.044181, -0.402563),
                new TriangulationPoint(5.685699, 1.933857),
                new TriangulationPoint(1.619537, 3.118854),
                new TriangulationPoint(4.456764, -7.737046),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom167_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.987964, -5.46614),
                new TriangulationPoint(3.591865, -4.555117),
                new TriangulationPoint(3.857299, -3.644093),
                new TriangulationPoint(4.224859, -2.73307),
                new TriangulationPoint(5.322964, -4.555117),
                new TriangulationPoint(5.775911, -3.644093),
                new TriangulationPoint(6.353124, -2.73307),
                new TriangulationPoint(6.942841, -1.822047),
                new TriangulationPoint(7.312386, -0.911023),
                new TriangulationPoint(5.889323, 4.28972),
                new TriangulationPoint(1.543482, 4.815633),
                new TriangulationPoint(6.030262, 1.470488),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom168_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.068766, -2.09141),
                new TriangulationPoint(0.013629, -0.170108),
                new TriangulationPoint(0.178103, 2.029907),
                new TriangulationPoint(0.153869, 4.05926),
                new TriangulationPoint(2.12446, -2.05843),
                new TriangulationPoint(1.936787, 0.111659),
                new TriangulationPoint(1.923502, 1.880317),
                new TriangulationPoint(1.914559, 4.13511),
                new TriangulationPoint(4.087933, -1.838311),
                new TriangulationPoint(4.11052, -0.00084),
                new TriangulationPoint(4.109978, 1.979351),
                new TriangulationPoint(4.163024, 4.04488),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom169_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.354204, 2.098511),
                new TriangulationPoint(0.561679, 3.157747),
                new TriangulationPoint(-1.985794, 1.10175),
                new TriangulationPoint(-2.859198, -0.536186),
                new TriangulationPoint(-0.701825, -3.355119),
                new TriangulationPoint(1.549706, -1.462215),
                new TriangulationPoint(2.910861, -0.008211),
                new TriangulationPoint(1.345904, 3.811221),
                new TriangulationPoint(-1.362771, 1.908017),
                new TriangulationPoint(-4.054597, 2.12592),
                new TriangulationPoint(-2.903033, -0.518742),
                new TriangulationPoint(-1.307678, -1.665454),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom170_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(8.436932, -2.657537),
                new TriangulationPoint(-1.156393, -1.272197),
                new TriangulationPoint(6.15968, -7.051496),
                new TriangulationPoint(12.374807, 7.831498),
                new TriangulationPoint(5.662491, -3.680324),
                new TriangulationPoint(7.57523, -4.428287),
                new TriangulationPoint(11.395232, -6.349364),
                new TriangulationPoint(-0.747527, -0.055644),
                new TriangulationPoint(13.559141, -2.198994),
                new TriangulationPoint(-3.710275, 6.497436),
                new TriangulationPoint(13.343427, 7.436152),
                new TriangulationPoint(0.882131, -0.432206),
                new TriangulationPoint(11.334503, 5.422099),
                new TriangulationPoint(6.824245, -5.40064),
                new TriangulationPoint(-3.845595, -2.022606),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom171_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.518451, -3.933702),
                new TriangulationPoint(3.33396, 0.347067),
                new TriangulationPoint(5.7634, -0.162574),
                new TriangulationPoint(1.994633, 3.007353),
                new TriangulationPoint(6.071347, 0.525167),
                new TriangulationPoint(5.367763, -1.320348),
                new TriangulationPoint(6.23935, 3.185056),
                new TriangulationPoint(2.399271, 4.046752),
                new TriangulationPoint(9.408716, 5.968431),
                new TriangulationPoint(5.397608, 3.17635),
                new TriangulationPoint(3.097749, 0.558262),
                new TriangulationPoint(9.132154, 3.470257),
                new TriangulationPoint(8.125523, -2.327256),
                new TriangulationPoint(9.876658, 3.644486),
                new TriangulationPoint(5.457204, 3.419007),
                new TriangulationPoint(0.485021, 4.180081),
                new TriangulationPoint(6.917219, -2.703748),
                new TriangulationPoint(9.923161, -2.092917),
                new TriangulationPoint(9.261081, -1.837904),
                new TriangulationPoint(1.973387, 1.737706),
                new TriangulationPoint(0.248339, -2.413632),
                new TriangulationPoint(3.485863, 1.393125),
                new TriangulationPoint(7.945, 3.882297),
                new TriangulationPoint(5.12026, -6.895921),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom172_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.903035, -7.566486),
                new TriangulationPoint(4.256306, -6.305405),
                new TriangulationPoint(4.477612, -5.044324),
                new TriangulationPoint(5.050262, -6.305405),
                new TriangulationPoint(5.400834, -5.044324),
                new TriangulationPoint(5.707793, -3.783243),
                new TriangulationPoint(6.220591, -2.522162),
                new TriangulationPoint(6.661866, -1.261081),
                new TriangulationPoint(0.858696, 2.023061),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom173_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.135985, -2.043007),
                new TriangulationPoint(-0.145951, -0.140745),
                new TriangulationPoint(0.131015, 1.929414),
                new TriangulationPoint(-0.083227, 4.099357),
                new TriangulationPoint(1.849165, -2.037381),
                new TriangulationPoint(1.818071, 0.088437),
                new TriangulationPoint(2.178784, 2.036263),
                new TriangulationPoint(1.898864, 3.894333),
                new TriangulationPoint(3.958822, -1.974119),
                new TriangulationPoint(3.86361, -0.012835),
                new TriangulationPoint(4.049504, 1.956592),
                new TriangulationPoint(3.929644, 3.834179),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom174_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.858208, 2.09965),
                new TriangulationPoint(-3.084337, -2.086572),
                new TriangulationPoint(1.874979, -3.223594),
                new TriangulationPoint(3.08334, 1.538026),
                new TriangulationPoint(-0.004995, 4.081882),
                new TriangulationPoint(-3.291788, 1.467888),
                new TriangulationPoint(-1.642633, -2.17634),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom175_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(14.94199, 5.022268),
                new TriangulationPoint(14.940093, -2.695031),
                new TriangulationPoint(10.567454, 4.586174),
                new TriangulationPoint(-3.459062, 3.656222),
                new TriangulationPoint(0.329343, -5.087462),
                new TriangulationPoint(-0.635173, -6.765822),
                new TriangulationPoint(-3.400585, -1.33979),
                new TriangulationPoint(5.403776, 5.44107),
                new TriangulationPoint(11.70189, 7.849496),
                new TriangulationPoint(14.793344, 6.626193),
                new TriangulationPoint(0.650944, -5.854679),
                new TriangulationPoint(4.268937, -2.451246),
                new TriangulationPoint(13.551451, 6.218451),
                new TriangulationPoint(1.378401, -6.717224),
                new TriangulationPoint(-3.579724, 7.66497),
                new TriangulationPoint(12.693016, -2.596252),
                new TriangulationPoint(-4.891553, -3.11631),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom176_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.847917, 5.1657),
                new TriangulationPoint(4.798244, 0.87614),
                new TriangulationPoint(3.652067, 2.50661),
                new TriangulationPoint(6.398543, -0.010922),
                new TriangulationPoint(7.929232, 1.461607),
                new TriangulationPoint(6.180976, 1.061606),
                new TriangulationPoint(5.603591, -3.695794),
                new TriangulationPoint(8.59234, 4.154718),
                new TriangulationPoint(0.358976, -3.065975),
                new TriangulationPoint(5.765931, -5.042099),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom177_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.933219, -5.962869),
                new TriangulationPoint(3.561773, -4.969057),
                new TriangulationPoint(3.768911, -3.975246),
                new TriangulationPoint(3.941292, -2.981434),
                new TriangulationPoint(5.189489, -4.969057),
                new TriangulationPoint(5.390919, -3.975246),
                new TriangulationPoint(5.77344, -2.981434),
                new TriangulationPoint(6.200112, -1.987623),
                new TriangulationPoint(4.337027, 3.9867),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom178_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.081626, -2.102331),
                new TriangulationPoint(0.156581, -0.091921),
                new TriangulationPoint(0.161409, 1.889543),
                new TriangulationPoint(-0.132418, 3.822645),
                new TriangulationPoint(1.874479, -2.180458),
                new TriangulationPoint(2.05011, -0.114627),
                new TriangulationPoint(2.008677, 1.802855),
                new TriangulationPoint(2.003622, 4.127595),
                new TriangulationPoint(3.915153, -2.01167),
                new TriangulationPoint(4.013615, -0.136559),
                new TriangulationPoint(4.070024, 2.158499),
                new TriangulationPoint(4.111802, 3.910789),
                new TriangulationPoint(5.832767, -1.866203),
                new TriangulationPoint(5.916834, 0.176158),
                new TriangulationPoint(6.001174, 2.062428),
                new TriangulationPoint(5.822633, 4.059341),
                new TriangulationPoint(7.992794, -1.965053),
                new TriangulationPoint(8.136561, 0.071154),
                new TriangulationPoint(7.817413, 2.179779),
                new TriangulationPoint(7.96994, 4.056672),
                new TriangulationPoint(9.882905, -1.968521),
                new TriangulationPoint(9.865787, 0.069938),
                new TriangulationPoint(10.149263, 1.906582),
                new TriangulationPoint(9.896013, 3.935254),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom179_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.492997, -0.884061),
                new TriangulationPoint(2.663051, 2.564797),
                new TriangulationPoint(0.713438, 4.45366),
                new TriangulationPoint(-0.710717, 2.797191),
                new TriangulationPoint(-3.606468, 0.047546),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom180_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(12.390574, -1.476562),
                new TriangulationPoint(-2.934661, 0.952804),
                new TriangulationPoint(8.382487, -7.3975),
                new TriangulationPoint(5.233158, 3.201237),
                new TriangulationPoint(10.361549, 1.372936),
                new TriangulationPoint(6.980963, -2.955052),
                new TriangulationPoint(7.80002, -7.312155),
                new TriangulationPoint(3.559708, 5.42376),
                new TriangulationPoint(-1.258258, -7.769599),
                new TriangulationPoint(4.235481, -1.841559),
                new TriangulationPoint(7.857018, -3.585901),
                new TriangulationPoint(9.769616, 5.236814),
                new TriangulationPoint(-0.015876, 6.19441),
                new TriangulationPoint(8.829778, -0.455535),
                new TriangulationPoint(-3.076038, 1.657607),
                new TriangulationPoint(3.622711, 1.050689),
                new TriangulationPoint(14.539128, -4.97407),
                new TriangulationPoint(13.241852, -3.748105),
                new TriangulationPoint(-1.591871, 6.718274),
                new TriangulationPoint(5.218746, -5.805805),
                new TriangulationPoint(8.748291, -4.94913),
                new TriangulationPoint(12.046339, 1.354074),
                new TriangulationPoint(1.788371, -5.732477),
                new TriangulationPoint(-3.076099, 7.958917),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom181_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.057763, 2.58069),
                new TriangulationPoint(8.226839, -1.598357),
                new TriangulationPoint(2.612112, 1.350656),
                new TriangulationPoint(9.467901, 1.725149),
                new TriangulationPoint(1.958759, -1.297623),
                new TriangulationPoint(2.464355, -0.342276),
                new TriangulationPoint(7.851407, -1.74434),
                new TriangulationPoint(5.333479, 1.208768),
                new TriangulationPoint(2.483955, 0.165194),
                new TriangulationPoint(7.959427, 5.443569),
                new TriangulationPoint(4.947293, -7.362034),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom182_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.136364, -6.805382),
                new TriangulationPoint(3.177581, -5.671152),
                new TriangulationPoint(3.524136, -4.536921),
                new TriangulationPoint(3.848136, -3.402691),
                new TriangulationPoint(4.311654, -5.671152),
                new TriangulationPoint(4.858936, -4.536921),
                new TriangulationPoint(5.409728, -3.402691),
                new TriangulationPoint(4.682331, 1.877047),
                new TriangulationPoint(4.636893, 2.919734),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom183_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.187364, -2.163467),
                new TriangulationPoint(0.06049, 0.056238),
                new TriangulationPoint(0.120584, 2.14955),
                new TriangulationPoint(-0.129432, 3.819834),
                new TriangulationPoint(1.838123, -1.804105),
                new TriangulationPoint(1.808982, -0.142523),
                new TriangulationPoint(1.867168, 2.137312),
                new TriangulationPoint(2.056212, 4.069207),
                new TriangulationPoint(4.010292, -1.982489),
                new TriangulationPoint(4.0443, 0.156715),
                new TriangulationPoint(4.09659, 2.044197),
                new TriangulationPoint(4.186064, 3.919322),
                new TriangulationPoint(6.007536, -2.164609),
                new TriangulationPoint(6.057344, -0.076605),
                new TriangulationPoint(5.918722, 1.838861),
                new TriangulationPoint(5.817994, 4.071307),
                new TriangulationPoint(7.952093, -2.005409),
                new TriangulationPoint(7.971098, 0.037676),
                new TriangulationPoint(8.171711, 2.017883),
                new TriangulationPoint(7.854989, 3.982365),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom184_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.872924, 3.883159),
                new TriangulationPoint(-2.513857, 1.16387),
                new TriangulationPoint(-2.051807, -3.374727),
                new TriangulationPoint(2.176879, -1.989781),
                new TriangulationPoint(2.552283, 2.760053),
                new TriangulationPoint(-0.441694, 2.292779),
                new TriangulationPoint(-3.668404, 3.128313),
                new TriangulationPoint(-3.207013, -0.843367),
                new TriangulationPoint(-1.241961, -4.234995),
                new TriangulationPoint(2.591937, -2.624655),
                new TriangulationPoint(2.436318, -0.548604),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom185_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.761326, -7.319496),
                new TriangulationPoint(5.905061, 1.216274),
                new TriangulationPoint(12.024437, 7.703705),
                new TriangulationPoint(8.635526, 6.103106),
                new TriangulationPoint(-4.315325, -1.267698),
                new TriangulationPoint(1.552663, -4.873954),
                new TriangulationPoint(-4.546213, -0.450936),
                new TriangulationPoint(3.454384, 3.386653),
                new TriangulationPoint(7.320447, 3.10316),
                new TriangulationPoint(8.527789, -7.905542),
                new TriangulationPoint(-1.973805, -6.45575),
                new TriangulationPoint(3.734965, 6.33654),
                new TriangulationPoint(-1.545517, 7.781757),
                new TriangulationPoint(10.241106, -2.178662),
                new TriangulationPoint(3.770753, -3.952023),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom186_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.279354, -2.300706),
                new TriangulationPoint(8.576261, 1.049129),
                new TriangulationPoint(4.395173, -3.009359),
                new TriangulationPoint(2.329586, 2.715088),
                new TriangulationPoint(9.436142, -1.275259),
                new TriangulationPoint(3.206752, 4.203922),
                new TriangulationPoint(4.429652, -0.789758),
                new TriangulationPoint(2.99151, 2.184431),
                new TriangulationPoint(0.802541, 5.758947),
                new TriangulationPoint(5.769579, 2.474267),
                new TriangulationPoint(1.385507, 2.109343),
                new TriangulationPoint(5.234284, -0.79295),
                new TriangulationPoint(5.374153, -0.752191),
                new TriangulationPoint(7.853199, 1.005283),
                new TriangulationPoint(0.723162, -0.396831),
                new TriangulationPoint(9.419403, 4.880991),
                new TriangulationPoint(6.80832, 1.481383),
                new TriangulationPoint(3.77426, 5.500216),
                new TriangulationPoint(1.249717, 1.49395),
                new TriangulationPoint(2.609747, 4.230118),
                new TriangulationPoint(8.247538, -0.601718),
                new TriangulationPoint(1.88648, 1.808365),
                new TriangulationPoint(5.79382, 4.297344),
                new TriangulationPoint(1.696408, 3.940784),
                new TriangulationPoint(5.470846, -5.634175),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom187_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.530733, -3.279928),
                new TriangulationPoint(3.222098, -2.733274),
                new TriangulationPoint(3.332976, -2.186619),
                new TriangulationPoint(3.615111, -1.639964),
                new TriangulationPoint(4.114191, -1.093309),
                new TriangulationPoint(4.375701, -0.546655),
                new TriangulationPoint(4.733275, -2.733274),
                new TriangulationPoint(5.125263, -2.186619),
                new TriangulationPoint(5.351428, -1.639964),
                new TriangulationPoint(5.738543, -1.093309),
                new TriangulationPoint(6.051654, -0.546655),
                new TriangulationPoint(9.221092, 1.28597),
                new TriangulationPoint(4.243541, 1.944049),
                new TriangulationPoint(7.063858, 3.99543),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom188_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.085323, -2.066494),
                new TriangulationPoint(0.137906, 0.128071),
                new TriangulationPoint(0.007483, 1.951413),
                new TriangulationPoint(2.157455, -1.976392),
                new TriangulationPoint(1.954205, 0.14921),
                new TriangulationPoint(1.962263, 2.015795),
                new TriangulationPoint(3.925032, -2.055334),
                new TriangulationPoint(4.11009, -0.0735),
                new TriangulationPoint(3.830622, 2.07936),
                new TriangulationPoint(5.839884, -1.983177),
                new TriangulationPoint(5.867825, -0.183669),
                new TriangulationPoint(6.105332, 1.917778),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom189_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.863646, -2.26758),
                new TriangulationPoint(1.97114, -4.584743),
                new TriangulationPoint(3.844254, 0.815519),
                new TriangulationPoint(2.786351, 3.138416),
                new TriangulationPoint(-1.160769, 2.05892),
                new TriangulationPoint(-2.966144, 0.833065),
                new TriangulationPoint(-1.316171, -2.910125),
                new TriangulationPoint(0.381169, -3.843915),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom190_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(12.231813, -6.77648),
                new TriangulationPoint(11.476969, 0.316074),
                new TriangulationPoint(6.087623, -5.016042),
                new TriangulationPoint(11.151953, -2.247823),
                new TriangulationPoint(7.351261, -0.379367),
                new TriangulationPoint(2.723956, -5.717046),
                new TriangulationPoint(-2.862063, -4.333755),
                new TriangulationPoint(-3.252675, 6.798653),
                new TriangulationPoint(1.383695, -4.678072),
                new TriangulationPoint(1.006371, -2.34542),
                new TriangulationPoint(6.808658, 1.154282),
                new TriangulationPoint(14.374676, -1.764017),
                new TriangulationPoint(0.232788, 3.814291),
                new TriangulationPoint(-2.02935, 2.033166),
                new TriangulationPoint(2.169855, -7.979736),
                new TriangulationPoint(7.982988, 1.796392),
                new TriangulationPoint(-0.675622, 4.047562),
                new TriangulationPoint(-3.648464, 2.017943),
                new TriangulationPoint(14.743437, 3.896525),
                new TriangulationPoint(11.001861, 5.7683),
                new TriangulationPoint(2.501758, -2.243899),
                new TriangulationPoint(10.207046, 3.664077),
                new TriangulationPoint(1.968256, -0.517151),
                new TriangulationPoint(-4.146204, -4.380972),
                new TriangulationPoint(2.582554, -7.138074),
                new TriangulationPoint(0.52069, -0.475792),
                new TriangulationPoint(6.784024, 4.800303),
                new TriangulationPoint(-4.497991, 4.656505),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom191_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.683973, 5.959805),
                new TriangulationPoint(0.557487, 5.438117),
                new TriangulationPoint(4.634178, 5.610243),
                new TriangulationPoint(3.074612, 1.897798),
                new TriangulationPoint(0.569389, 5.847688),
                new TriangulationPoint(3.443177, 1.487111),
                new TriangulationPoint(4.02365, 2.41306),
                new TriangulationPoint(3.11375, 5.437365),
                new TriangulationPoint(1.497761, -1.645614),
                new TriangulationPoint(4.041339, -5.712575),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom192_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.283566, -5.563447),
                new TriangulationPoint(4.664473, -4.636206),
                new TriangulationPoint(5.153044, -3.708965),
                new TriangulationPoint(5.567419, -2.781723),
                new TriangulationPoint(5.869026, -1.854482),
                new TriangulationPoint(5.473756, -4.636206),
                new TriangulationPoint(5.868731, -3.708965),
                new TriangulationPoint(9.846639, 3.067775),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom193_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.075174, -1.867919),
                new TriangulationPoint(0.198425, -0.160952),
                new TriangulationPoint(0.048902, 2.075024),
                new TriangulationPoint(-0.160305, 4.014793),
                new TriangulationPoint(1.871739, -1.813586),
                new TriangulationPoint(2.018051, -0.038846),
                new TriangulationPoint(1.955704, 1.824075),
                new TriangulationPoint(1.90501, 3.933898),
                new TriangulationPoint(4.044883, -2.189351),
                new TriangulationPoint(3.928194, -0.041492),
                new TriangulationPoint(3.936163, 2.029809),
                new TriangulationPoint(3.824554, 3.810628),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom194_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.238402, 2.022226),
                new TriangulationPoint(-1.291056, 2.335311),
                new TriangulationPoint(-4.833784, 1.236579),
                new TriangulationPoint(-4.278978, -1.687509),
                new TriangulationPoint(-2.357698, -4.194187),
                new TriangulationPoint(2.069517, -2.972227),
                new TriangulationPoint(4.509748, 1.873541),
                new TriangulationPoint(-0.852754, 2.489076),
                new TriangulationPoint(-2.232297, -0.744308),
                new TriangulationPoint(-1.976761, -4.339083),
                new TriangulationPoint(2.420133, -3.458095),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom195_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-3.429585, -6.999476),
                new TriangulationPoint(3.236041, -3.624514),
                new TriangulationPoint(14.341876, 1.504766),
                new TriangulationPoint(7.43763, 2.886236),
                new TriangulationPoint(8.191152, 4.447227),
                new TriangulationPoint(3.367297, -0.277673),
                new TriangulationPoint(3.774566, 2.751967),
                new TriangulationPoint(0.447829, -0.689628),
                new TriangulationPoint(4.900059, -5.07465),
                new TriangulationPoint(-1.556992, 4.072941),
                new TriangulationPoint(10.19875, 6.046281),
                new TriangulationPoint(12.587888, 6.228669),
                new TriangulationPoint(3.765721, 3.987078),
                new TriangulationPoint(4.712943, 3.719197),
                new TriangulationPoint(-1.255607, 5.341876),
                new TriangulationPoint(3.324311, 7.990074),
                new TriangulationPoint(2.594563, -7.398205),
                new TriangulationPoint(2.207204, -4.325935),
                new TriangulationPoint(11.535146, -2.09049),
                new TriangulationPoint(13.9845, 0.858411),
                new TriangulationPoint(8.039766, 5.808853),
                new TriangulationPoint(-4.005517, 7.575922),
                new TriangulationPoint(-4.722478, -7.209849),
                new TriangulationPoint(-0.550916, -7.426104),
                new TriangulationPoint(11.48919, 0.997459),
                new TriangulationPoint(7.041451, 5.792508),
                new TriangulationPoint(11.01027, 3.114265),
                new TriangulationPoint(-1.681078, 4.855678),
                new TriangulationPoint(9.01805, 0.407294),
                new TriangulationPoint(4.506678, 2.856396),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom196_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(8.32485, 0.453604),
                new TriangulationPoint(8.725139, -1.436915),
                new TriangulationPoint(7.095758, 5.618874),
                new TriangulationPoint(9.633893, -0.293123),
                new TriangulationPoint(8.720218, 2.950801),
                new TriangulationPoint(1.920377, -1.004617),
                new TriangulationPoint(8.952899, -2.872595),
                new TriangulationPoint(3.817688, 2.603369),
                new TriangulationPoint(9.412462, 2.734139),
                new TriangulationPoint(4.185566, 5.671205),
                new TriangulationPoint(7.143255, 5.264083),
                new TriangulationPoint(7.472997, -3.213029),
                new TriangulationPoint(0.735436, 1.234733),
                new TriangulationPoint(2.972316, 4.412069),
                new TriangulationPoint(2.331092, -2.21985),
                new TriangulationPoint(2.949695, 1.166828),
                new TriangulationPoint(4.389206, -1.194897),
                new TriangulationPoint(3.310105, 5.09603),
                new TriangulationPoint(5.978908, 3.209412),
                new TriangulationPoint(8.443512, -3.512806),
                new TriangulationPoint(4.200399, 5.753328),
                new TriangulationPoint(3.178402, 1.946048),
                new TriangulationPoint(3.234013, 2.630675),
                new TriangulationPoint(7.822801, 1.626223),
                new TriangulationPoint(8.860868, 3.119766),
                new TriangulationPoint(5.906649, -5.13146),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom197_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.683426, -2.294722),
                new TriangulationPoint(3.830408, -1.912269),
                new TriangulationPoint(4.297629, -1.529815),
                new TriangulationPoint(4.550573, -1.147361),
                new TriangulationPoint(5.067919, -1.912269),
                new TriangulationPoint(5.652429, -1.529815),
                new TriangulationPoint(6.131166, -1.147361),
                new TriangulationPoint(1.653788, 1.51506),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom198_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.067084, -1.990672),
                new TriangulationPoint(-0.181317, -0.016545),
                new TriangulationPoint(-0.133168, 1.885189),
                new TriangulationPoint(0.131835, 4.129855),
                new TriangulationPoint(2.16747, -1.916447),
                new TriangulationPoint(1.971435, -0.117904),
                new TriangulationPoint(2.0795, 1.970604),
                new TriangulationPoint(2.079914, 3.866659),
                new TriangulationPoint(3.882731, -1.822949),
                new TriangulationPoint(3.913478, -0.145508),
                new TriangulationPoint(4.129738, 1.825804),
                new TriangulationPoint(4.177637, 3.850848),
                new TriangulationPoint(6.039188, -2.053242),
                new TriangulationPoint(6.179514, -0.104658),
                new TriangulationPoint(6.197176, 2.097676),
                new TriangulationPoint(6.104074, 3.803085),
                new TriangulationPoint(8.096908, -1.809103),
                new TriangulationPoint(8.063518, 0.148324),
                new TriangulationPoint(7.896933, 2.030575),
                new TriangulationPoint(7.84298, 4.058227),
                new TriangulationPoint(9.992976, -2.022447),
                new TriangulationPoint(10.169351, 0.064246),
                new TriangulationPoint(9.954702, 2.152684),
                new TriangulationPoint(10.081429, 3.873064),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom199_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.96078, -0.568175),
                new TriangulationPoint(4.028184, 1.706961),
                new TriangulationPoint(0.534977, 2.130919),
                new TriangulationPoint(-0.658416, 2.11447),
                new TriangulationPoint(-2.74964, -0.834019),
                new TriangulationPoint(-1.309268, -1.610473),
                new TriangulationPoint(1.380549, -1.51277),
                new TriangulationPoint(3.150547, 1.743839),
                new TriangulationPoint(0.357794, 2.02141),
                new TriangulationPoint(-3.166105, 3.161499),
                new TriangulationPoint(-1.992273, -1.522787),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom200_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.714936, 6.263122),
                new TriangulationPoint(7.008636, -3.79395),
                new TriangulationPoint(4.582698, 1.931029),
                new TriangulationPoint(13.22265, 5.989559),
                new TriangulationPoint(-0.089193, -1.970212),
                new TriangulationPoint(9.683827, -0.034401),
                new TriangulationPoint(14.948098, -2.475916),
                new TriangulationPoint(10.055435, -2.262506),
                new TriangulationPoint(-0.996902, -6.467173),
                new TriangulationPoint(14.14357, -2.586863),
                new TriangulationPoint(-3.070825, 0.967222),
                new TriangulationPoint(1.72106, -3.432811),
                new TriangulationPoint(8.439231, -6.140352),
                new TriangulationPoint(2.397093, 3.12112),
                new TriangulationPoint(2.110835, -0.790328),
                new TriangulationPoint(-3.517511, 1.778851),
                new TriangulationPoint(13.57561, -6.946163),
                new TriangulationPoint(-0.420353, -3.028157),
                new TriangulationPoint(-1.974326, -7.114494),
                new TriangulationPoint(3.856322, -3.690469),
                new TriangulationPoint(7.639646, -1.7461),
                new TriangulationPoint(10.958143, 5.884152),
                new TriangulationPoint(1.983978, -6.606405),
                new TriangulationPoint(7.259313, 3.25933),
                new TriangulationPoint(12.00755, -2.967113),
                new TriangulationPoint(13.562356, 3.139052),
                new TriangulationPoint(10.98314, -0.125684),
                new TriangulationPoint(11.696427, 1.101185),
                new TriangulationPoint(11.572107, -7.854137),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom201_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(8.742939, 2.85537),
                new TriangulationPoint(5.930484, 5.355476),
                new TriangulationPoint(0.782983, 0.45868),
                new TriangulationPoint(8.993881, 5.898812),
                new TriangulationPoint(5.964933, 3.918514),
                new TriangulationPoint(0.69142, -1.537147),
                new TriangulationPoint(8.067827, 1.093766),
                new TriangulationPoint(9.485242, 3.690679),
                new TriangulationPoint(3.06312, 0.884837),
                new TriangulationPoint(5.522685, 5.301506),
                new TriangulationPoint(8.742556, -3.198167),
                new TriangulationPoint(9.479635, 1.459867),
                new TriangulationPoint(6.013231, 4.281634),
                new TriangulationPoint(3.41526, 2.800547),
                new TriangulationPoint(5.268498, 2.841311),
                new TriangulationPoint(7.134671, 2.321792),
                new TriangulationPoint(6.178711, 0.474099),
                new TriangulationPoint(9.975045, -0.244949),
                new TriangulationPoint(9.157372, 4.450959),
                new TriangulationPoint(9.611833, 0.316041),
                new TriangulationPoint(2.081266, 5.248128),
                new TriangulationPoint(8.513468, 2.39661),
                new TriangulationPoint(4.583961, -7.801123),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom202_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.800175, -7.376891),
                new TriangulationPoint(3.903448, -6.147409),
                new TriangulationPoint(4.12936, -4.917928),
                new TriangulationPoint(4.951214, -6.147409),
                new TriangulationPoint(5.285874, -4.917928),
                new TriangulationPoint(5.544206, -3.688446),
                new TriangulationPoint(5.914034, -2.458964),
                new TriangulationPoint(6.73946, 2.255484),
                new TriangulationPoint(3.864054, 3.17846),
                new TriangulationPoint(6.143259, 4.206563),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom203_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.185835, -1.909915),
                new TriangulationPoint(-0.112962, 0.104867),
                new TriangulationPoint(-0.086161, 1.897706),
                new TriangulationPoint(1.803327, -2.009537),
                new TriangulationPoint(2.024108, -0.084661),
                new TriangulationPoint(2.194391, 1.850165),
                new TriangulationPoint(4.014827, -1.953504),
                new TriangulationPoint(3.834361, 0.057577),
                new TriangulationPoint(3.81573, 2.1249),
                new TriangulationPoint(6.103637, -1.939919),
                new TriangulationPoint(5.844513, 0.134824),
                new TriangulationPoint(6.117398, 2.094309),
                new TriangulationPoint(7.865053, -2.163943),
                new TriangulationPoint(7.861997, -0.022328),
                new TriangulationPoint(8.115916, 2.044387),
                new TriangulationPoint(10.086211, -2.133487),
                new TriangulationPoint(9.810609, 0.1029),
                new TriangulationPoint(9.939871, 1.973548),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom204_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.21147, 1.880978),
                new TriangulationPoint(-3.249752, 0.120122),
                new TriangulationPoint(-2.020406, -3.333435),
                new TriangulationPoint(0.366192, -4.597755),
                new TriangulationPoint(3.879463, -1.058818),
                new TriangulationPoint(2.336598, 0.533255),
                new TriangulationPoint(1.697097, 3.571739),
                new TriangulationPoint(-2.542277, 2.246576),
                new TriangulationPoint(-2.245281, -1.419731),
                new TriangulationPoint(1.291275, -3.845168),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom205_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.773977, -1.104722),
                new TriangulationPoint(12.143479, -4.608879),
                new TriangulationPoint(-0.85747, -2.017079),
                new TriangulationPoint(1.008896, -0.416128),
                new TriangulationPoint(5.664723, -4.961119),
                new TriangulationPoint(0.336723, -4.974334),
                new TriangulationPoint(11.538802, -5.572009),
                new TriangulationPoint(2.380943, -3.777637),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom206_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.063446, 2.828482),
                new TriangulationPoint(4.938992, 5.734523),
                new TriangulationPoint(2.298462, 2.534407),
                new TriangulationPoint(6.396402, -1.804615),
                new TriangulationPoint(7.610154, 4.067222),
                new TriangulationPoint(9.423573, 0.992278),
                new TriangulationPoint(6.757447, 4.102947),
                new TriangulationPoint(3.84732, -1.86116),
                new TriangulationPoint(5.524023, -7.133485),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom207_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.882584, -2.45156),
                new TriangulationPoint(4.860092, -2.042967),
                new TriangulationPoint(5.293991, -1.634373),
                new TriangulationPoint(5.561311, -1.22578),
                new TriangulationPoint(6.059872, -2.042967),
                new TriangulationPoint(6.602077, -1.634373),
                new TriangulationPoint(6.910119, -1.22578),
                new TriangulationPoint(7.136519, -0.817187),
                new TriangulationPoint(7.682097, -0.408593),
                new TriangulationPoint(1.190391, 1.960755),
                new TriangulationPoint(8.016006, 1.659622),
                new TriangulationPoint(8.873968, 4.171801),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom208_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.049521, -2.023342),
                new TriangulationPoint(-0.17938, -0.04539),
                new TriangulationPoint(-0.106078, 2.134906),
                new TriangulationPoint(-0.059519, 4.044223),
                new TriangulationPoint(1.98476, -1.835132),
                new TriangulationPoint(1.858524, -0.132774),
                new TriangulationPoint(2.198197, 2.110653),
                new TriangulationPoint(1.897926, 4.150053),
                new TriangulationPoint(4.065379, -1.844816),
                new TriangulationPoint(3.817783, 0.084474),
                new TriangulationPoint(3.878082, 2.01766),
                new TriangulationPoint(3.918166, 3.883184),
                new TriangulationPoint(6.111548, -2.189547),
                new TriangulationPoint(5.824312, -0.022062),
                new TriangulationPoint(6.025864, 2.093811),
                new TriangulationPoint(5.921602, 4.090129),
                new TriangulationPoint(8.036273, -1.809321),
                new TriangulationPoint(7.815498, 0.109067),
                new TriangulationPoint(7.853292, 2.12865),
                new TriangulationPoint(8.022756, 3.994516),
                new TriangulationPoint(9.866436, -1.963702),
                new TriangulationPoint(9.978582, 0.026712),
                new TriangulationPoint(9.954549, 1.951339),
                new TriangulationPoint(9.866468, 4.008145),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom209_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-3.664957, 0.125198),
                new TriangulationPoint(-0.237963, -3.224039),
                new TriangulationPoint(4.043176, -1.1357),
                new TriangulationPoint(1.641186, 4.259275),
                new TriangulationPoint(-1.942057, 0.923827),
                new TriangulationPoint(-2.302767, -0.357347),
                new TriangulationPoint(-0.342814, -4.520513),
                new TriangulationPoint(3.261257, -0.330227),
                new TriangulationPoint(3.268066, 1.649396),
                new TriangulationPoint(1.167055, 2.308896),
                new TriangulationPoint(-1.059635, 3.31169),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom210_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.67639, -1.399464),
                new TriangulationPoint(11.651326, 4.58798),
                new TriangulationPoint(14.722401, -6.841281),
                new TriangulationPoint(14.310519, -4.596525),
                new TriangulationPoint(5.955805, -2.704466),
                new TriangulationPoint(0.63773, -5.48789),
                new TriangulationPoint(7.267626, 3.747493),
                new TriangulationPoint(10.562626, 3.511668),
                new TriangulationPoint(12.765272, 6.598264),
                new TriangulationPoint(0.981874, -0.384218),
                new TriangulationPoint(12.723956, 3.638747),
                new TriangulationPoint(10.17559, -7.481112),
                new TriangulationPoint(4.953451, 2.307394),
                new TriangulationPoint(-4.481143, -3.511463),
                new TriangulationPoint(5.903002, -7.501135),
                new TriangulationPoint(10.514443, 3.492871),
                new TriangulationPoint(2.168912, -5.849842),
                new TriangulationPoint(6.787469, 0.548114),
                new TriangulationPoint(11.711705, -4.437512),
                new TriangulationPoint(-1.973465, -7.967324),
                new TriangulationPoint(2.087479, -1.142753),
                new TriangulationPoint(14.431108, -5.90219),
                new TriangulationPoint(1.319514, -1.393589),
                new TriangulationPoint(0.541774, 3.751895),
                new TriangulationPoint(-4.483176, -3.442823),
                new TriangulationPoint(3.884933, 5.693688),
                new TriangulationPoint(-1.343492, 7.655055),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom211_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.989215, -2.171682),
                new TriangulationPoint(5.788239, 2.085379),
                new TriangulationPoint(2.146183, -3.214275),
                new TriangulationPoint(8.599746, 3.974716),
                new TriangulationPoint(0.902179, 1.59685),
                new TriangulationPoint(0.621896, 3.230475),
                new TriangulationPoint(2.241233, 2.403772),
                new TriangulationPoint(0.7941, -1.740838),
                new TriangulationPoint(4.352446, 5.921646),
                new TriangulationPoint(2.122083, 0.919132),
                new TriangulationPoint(0.494568, 2.385702),
                new TriangulationPoint(5.30552, 2.811656),
                new TriangulationPoint(9.475045, 0.376926),
                new TriangulationPoint(4.662331, 0.001965),
                new TriangulationPoint(9.867072, -0.431991),
                new TriangulationPoint(7.043912, 4.590984),
                new TriangulationPoint(1.343162, -1.175558),
                new TriangulationPoint(1.205987, -2.057182),
                new TriangulationPoint(7.874767, -3.95847),
                new TriangulationPoint(5.441264, -6.956331),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom212_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.200184, -5.385399),
                new TriangulationPoint(3.159324, -4.487832),
                new TriangulationPoint(3.401382, -3.590266),
                new TriangulationPoint(3.677089, -2.692699),
                new TriangulationPoint(3.840298, -1.795133),
                new TriangulationPoint(4.499255, -4.487832),
                new TriangulationPoint(5.050975, -3.590266),
                new TriangulationPoint(5.287512, -2.692699),
                new TriangulationPoint(5.662591, -1.795133),
                new TriangulationPoint(3.840742, 2.06079),
                new TriangulationPoint(4.914881, 2.45102),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom213_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.150341, -2.09424),
                new TriangulationPoint(0.026622, -0.045045),
                new TriangulationPoint(0.04877, 1.843307),
                new TriangulationPoint(0.195261, 3.887131),
                new TriangulationPoint(1.802484, -2.114754),
                new TriangulationPoint(2.169952, -0.101647),
                new TriangulationPoint(2.120134, 2.187836),
                new TriangulationPoint(2.048865, 4.086274),
                new TriangulationPoint(4.012779, -1.807302),
                new TriangulationPoint(3.967249, 0.021405),
                new TriangulationPoint(4.02314, 2.0329),
                new TriangulationPoint(4.121748, 3.89668),
                new TriangulationPoint(5.959712, -2.122535),
                new TriangulationPoint(5.897701, 0.154632),
                new TriangulationPoint(6.119308, 1.988035),
                new TriangulationPoint(6.189977, 3.805023),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom214_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.412531, -4.628608),
                new TriangulationPoint(1.89142, -2.191346),
                new TriangulationPoint(4.07023, 0.319149),
                new TriangulationPoint(2.744695, 2.62486),
                new TriangulationPoint(0.142317, 4.651223),
                new TriangulationPoint(-4.864812, 0.797169),
                new TriangulationPoint(-3.432766, -3.257607),
                new TriangulationPoint(1.333248, -4.612858),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom215_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.707641, 3.817085),
                new TriangulationPoint(11.396663, -1.514677),
                new TriangulationPoint(-2.381244, -0.234185),
                new TriangulationPoint(12.978894, -6.204443),
                new TriangulationPoint(5.993733, 5.880782),
                new TriangulationPoint(4.292533, -1.224117),
                new TriangulationPoint(-0.016066, -3.098568),
                new TriangulationPoint(-0.057572, 3.828455),
                new TriangulationPoint(0.758332, -4.95333),
                new TriangulationPoint(14.067726, 1.033016),
                new TriangulationPoint(-0.646106, -2.948054),
                new TriangulationPoint(7.369899, -3.642198),
                new TriangulationPoint(2.83918, 6.538259),
                new TriangulationPoint(9.852322, -4.275394),
                new TriangulationPoint(0.671892, 0.838971),
                new TriangulationPoint(5.244258, 7.65636),
                new TriangulationPoint(-3.684971, 6.94492),
                new TriangulationPoint(-2.906248, 6.343943),
                new TriangulationPoint(0.898732, -3.983015),
                new TriangulationPoint(-1.747912, 5.846665),
                new TriangulationPoint(9.737618, 2.702974),
                new TriangulationPoint(0.902301, -6.604608),
                new TriangulationPoint(3.542859, -0.167318),
                new TriangulationPoint(-4.451318, -5.451916),
                new TriangulationPoint(7.729599, 3.289782),
                new TriangulationPoint(0.97367, -7.003271),
                new TriangulationPoint(-4.003219, -2.251347),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom216_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.920071, 0.325591),
                new TriangulationPoint(6.833649, 2.180436),
                new TriangulationPoint(9.727625, -3.430826),
                new TriangulationPoint(2.732748, -3.326219),
                new TriangulationPoint(5.361132, -2.640029),
                new TriangulationPoint(5.87373, 0.938989),
                new TriangulationPoint(1.998135, 4.234716),
                new TriangulationPoint(4.181139, -0.031599),
                new TriangulationPoint(1.683499, 1.869522),
                new TriangulationPoint(6.078296, 4.830246),
                new TriangulationPoint(6.49525, 2.720001),
                new TriangulationPoint(6.781296, -1.035347),
                new TriangulationPoint(2.759332, -0.582475),
                new TriangulationPoint(6.864974, -2.747412),
                new TriangulationPoint(5.265042, -2.574867),
                new TriangulationPoint(9.771078, -2.087528),
                new TriangulationPoint(5.024028, 2.452111),
                new TriangulationPoint(6.24957, 2.9471),
                new TriangulationPoint(9.568737, 0.138764),
                new TriangulationPoint(7.396913, 4.586149),
                new TriangulationPoint(6.157935, -3.718768),
                new TriangulationPoint(3.145209, -2.35156),
                new TriangulationPoint(7.340717, 4.391477),
                new TriangulationPoint(7.538274, -1.307392),
                new TriangulationPoint(5.27118, -5.216048),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom217_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.12937, -7.839507),
                new TriangulationPoint(2.65873, -6.532922),
                new TriangulationPoint(2.890499, -5.226338),
                new TriangulationPoint(3.389063, -3.919753),
                new TriangulationPoint(3.498766, -2.613169),
                new TriangulationPoint(3.711139, -1.306584),
                new TriangulationPoint(4.292235, -6.532922),
                new TriangulationPoint(4.841629, -5.226338),
                new TriangulationPoint(7.729233, 1.371723),
                new TriangulationPoint(4.800826, 4.096924),
                new TriangulationPoint(1.424854, 2.314007),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom218_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.09951, -2.03242),
                new TriangulationPoint(0.065217, -0.141213),
                new TriangulationPoint(0.061966, 1.903422),
                new TriangulationPoint(0.087319, 4.126087),
                new TriangulationPoint(1.961169, -2.16309),
                new TriangulationPoint(1.817625, -0.088756),
                new TriangulationPoint(2.198552, 1.837668),
                new TriangulationPoint(1.80739, 4.019292),
                new TriangulationPoint(3.990126, -1.877665),
                new TriangulationPoint(4.015752, -0.193223),
                new TriangulationPoint(3.9048, 1.841671),
                new TriangulationPoint(4.056998, 4.196187),
                new TriangulationPoint(6.07008, -1.901461),
                new TriangulationPoint(6.056219, 0.044243),
                new TriangulationPoint(5.964767, 1.942422),
                new TriangulationPoint(5.901577, 4.131934),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom219_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.82189, -3.825199),
                new TriangulationPoint(2.912026, 0.662305),
                new TriangulationPoint(2.778559, 3.727057),
                new TriangulationPoint(0.129464, 2.335803),
                new TriangulationPoint(-2.373611, 2.210435),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom220_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.362775, 3.092319),
                new TriangulationPoint(1.768305, 1.27512),
                new TriangulationPoint(9.410538, -5.897933),
                new TriangulationPoint(-2.761558, -1.715853),
                new TriangulationPoint(-0.244014, -7.960455),
                new TriangulationPoint(5.302801, -3.714279),
                new TriangulationPoint(2.759795, -0.256673),
                new TriangulationPoint(-4.46733, -0.462673),
                new TriangulationPoint(0.966844, -4.007932),
                new TriangulationPoint(5.052755, 6.547043),
                new TriangulationPoint(-1.854219, -5.852907),
                new TriangulationPoint(8.526886, -0.445855),
                new TriangulationPoint(10.293968, -3.903686),
                new TriangulationPoint(4.060267, -3.533639),
                new TriangulationPoint(13.32299, 5.910535),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom221_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.602395, 0.165387),
                new TriangulationPoint(0.919238, 3.808559),
                new TriangulationPoint(0.431437, 5.43033),
                new TriangulationPoint(9.823716, -1.896579),
                new TriangulationPoint(2.842525, -2.779443),
                new TriangulationPoint(9.451757, -3.908491),
                new TriangulationPoint(0.182098, 5.784653),
                new TriangulationPoint(5.60097, 1.363184),
                new TriangulationPoint(0.616903, 4.218553),
                new TriangulationPoint(7.583068, -3.852032),
                new TriangulationPoint(3.937613, -1.000156),
                new TriangulationPoint(3.119569, -1.380449),
                new TriangulationPoint(8.029718, 2.305342),
                new TriangulationPoint(2.179299, 0.138222),
                new TriangulationPoint(3.997694, 0.192466),
                new TriangulationPoint(7.710643, 2.273848),
                new TriangulationPoint(2.0631, 3.648047),
                new TriangulationPoint(0.400914, -1.448026),
                new TriangulationPoint(3.721425, -3.554362),
                new TriangulationPoint(6.41617, -1.276728),
                new TriangulationPoint(7.498824, 2.351307),
                new TriangulationPoint(7.628965, 5.973003),
                new TriangulationPoint(4.422693, -6.810115),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom222_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.789833, -4.127513),
                new TriangulationPoint(4.254036, -3.439594),
                new TriangulationPoint(4.536701, -2.751675),
                new TriangulationPoint(4.984394, -2.063757),
                new TriangulationPoint(5.146134, -1.375838),
                new TriangulationPoint(5.337047, -0.687919),
                new TriangulationPoint(5.185028, -3.439594),
                new TriangulationPoint(5.632107, -2.751675),
                new TriangulationPoint(6.01943, -2.063757),
                new TriangulationPoint(5.781626, 3.245716),
                new TriangulationPoint(0.042271, 2.214225),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom223_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.091718, -1.918954),
                new TriangulationPoint(0.004216, 0.05483),
                new TriangulationPoint(1.959139, -2.080477),
                new TriangulationPoint(2.190183, 0.063462),
                new TriangulationPoint(3.813182, -2.119905),
                new TriangulationPoint(4.091687, -0.155174),
                new TriangulationPoint(6.099461, -2.086066),
                new TriangulationPoint(6.141125, -0.08742),
                new TriangulationPoint(7.989037, -2.084987),
                new TriangulationPoint(8.117738, 0.183284),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom224_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.419928, 1.095546),
                new TriangulationPoint(-0.042546, 3.118099),
                new TriangulationPoint(-3.792826, 2.943456),
                new TriangulationPoint(-2.58538, -0.937762),
                new TriangulationPoint(-0.197529, -3.547363),
                new TriangulationPoint(2.713472, -2.137104),
                new TriangulationPoint(2.344921, 0.5956),
                new TriangulationPoint(1.593765, 2.342334),
                new TriangulationPoint(-0.872818, 2.005722),
                new TriangulationPoint(-2.005039, 1.713583),
                new TriangulationPoint(-4.109201, -0.122029),
                new TriangulationPoint(-3.283066, -2.713713),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom225_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.22645, 3.033262),
                new TriangulationPoint(5.792491, -3.754175),
                new TriangulationPoint(6.529692, -0.40548),
                new TriangulationPoint(11.063185, 6.602821),
                new TriangulationPoint(14.597789, 5.468371),
                new TriangulationPoint(14.844674, -7.813287),
                new TriangulationPoint(10.110642, -7.291598),
                new TriangulationPoint(-0.482838, 2.984849),
                new TriangulationPoint(-1.513795, -5.561741),
                new TriangulationPoint(-4.797069, 7.455504),
                new TriangulationPoint(7.209391, 6.623479),
                new TriangulationPoint(0.512116, -1.598777),
                new TriangulationPoint(-0.770661, -0.735017),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom226_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.380189, 1.976412),
                new TriangulationPoint(9.05444, -1.439097),
                new TriangulationPoint(0.998673, 5.325279),
                new TriangulationPoint(2.187758, 2.357036),
                new TriangulationPoint(5.905843, 0.525859),
                new TriangulationPoint(3.128186, -3.99305),
                new TriangulationPoint(6.928978, -3.900073),
                new TriangulationPoint(3.551226, 3.704331),
                new TriangulationPoint(7.767185, 2.440031),
                new TriangulationPoint(7.10002, -2.272544),
                new TriangulationPoint(6.736625, -0.01215),
                new TriangulationPoint(9.596603, 0.111528),
                new TriangulationPoint(9.507178, 2.534125),
                new TriangulationPoint(7.488218, 5.483474),
                new TriangulationPoint(3.875564, 5.983788),
                new TriangulationPoint(5.037127, -3.521105),
                new TriangulationPoint(6.572355, 5.578004),
                new TriangulationPoint(4.110054, -6.022283),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom227_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.44753, -7.052617),
                new TriangulationPoint(3.763243, -5.877181),
                new TriangulationPoint(3.868913, -4.701745),
                new TriangulationPoint(4.068501, -3.526308),
                new TriangulationPoint(4.685827, -5.877181),
                new TriangulationPoint(5.114502, -4.701745),
                new TriangulationPoint(5.713053, -3.526308),
                new TriangulationPoint(5.952442, -2.350872),
                new TriangulationPoint(6.28606, -1.175436),
                new TriangulationPoint(6.240651, 3.551151),
                new TriangulationPoint(4.309687, 1.687287),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom228_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.13709, -1.988059),
                new TriangulationPoint(-0.052878, 0.135135),
                new TriangulationPoint(-0.031564, 2.160734),
                new TriangulationPoint(-0.145948, 4.085446),
                new TriangulationPoint(1.973956, -1.903448),
                new TriangulationPoint(1.827907, 0.199726),
                new TriangulationPoint(2.046292, 1.867446),
                new TriangulationPoint(2.055001, 3.939369),
                new TriangulationPoint(4.17752, -1.929087),
                new TriangulationPoint(4.179968, -0.116275),
                new TriangulationPoint(4.093373, 1.94414),
                new TriangulationPoint(4.015467, 4.09067),
                new TriangulationPoint(6.082027, -2.084155),
                new TriangulationPoint(5.856995, 0.17101),
                new TriangulationPoint(5.959125, 2.114247),
                new TriangulationPoint(6.0715, 4.106579),
                new TriangulationPoint(8.172354, -2.045698),
                new TriangulationPoint(8.098042, -0.059022),
                new TriangulationPoint(7.954591, 1.995506),
                new TriangulationPoint(7.810799, 4.005329),
                new TriangulationPoint(10.060517, -1.829202),
                new TriangulationPoint(10.029398, -0.18922),
                new TriangulationPoint(10.076415, 2.133135),
                new TriangulationPoint(9.992859, 3.999224),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom229_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.438028, -1.052708),
                new TriangulationPoint(1.459327, 3.094069),
                new TriangulationPoint(-1.494419, 1.548075),
                new TriangulationPoint(-4.667215, 1.091881),
                new TriangulationPoint(-3.035967, -0.845231),
                new TriangulationPoint(1.033395, -3.626829),
                new TriangulationPoint(2.641836, -3.048596),
                new TriangulationPoint(4.894357, 0.267481),
                new TriangulationPoint(0.157308, 4.70546),
                new TriangulationPoint(-3.905089, 0.99423),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom230_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.524682, -5.609073),
                new TriangulationPoint(4.594833, 6.054997),
                new TriangulationPoint(3.714875, -0.854256),
                new TriangulationPoint(7.327174, 6.765218),
                new TriangulationPoint(13.484927, -1.833725),
                new TriangulationPoint(10.639883, 7.524182),
                new TriangulationPoint(5.330745, 5.579572),
                new TriangulationPoint(3.112282, -1.622474),
                new TriangulationPoint(3.291328, 5.825102),
                new TriangulationPoint(5.983445, -7.783138),
                new TriangulationPoint(3.48304, 2.547721),
                new TriangulationPoint(9.653581, -6.474287),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom231_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(8.838992, -0.229164),
                new TriangulationPoint(1.821628, -2.941432),
                new TriangulationPoint(5.846, 4.502136),
                new TriangulationPoint(3.983441, 0.654824),
                new TriangulationPoint(2.72107, 0.659422),
                new TriangulationPoint(3.301988, 1.129905),
                new TriangulationPoint(6.891966, -2.142228),
                new TriangulationPoint(4.527827, 1.360889),
                new TriangulationPoint(5.574272, 0.555285),
                new TriangulationPoint(6.137181, -2.710467),
                new TriangulationPoint(4.85543, 1.521639),
                new TriangulationPoint(2.704835, -0.626092),
                new TriangulationPoint(6.673893, -0.434203),
                new TriangulationPoint(6.912202, -1.206605),
                new TriangulationPoint(4.053764, -5.193775),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom232_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.619808, -6.977814),
                new TriangulationPoint(4.646749, -5.814845),
                new TriangulationPoint(4.973478, -4.651876),
                new TriangulationPoint(5.251134, -3.488907),
                new TriangulationPoint(5.677832, -2.325938),
                new TriangulationPoint(5.756765, -5.814845),
                new TriangulationPoint(6.234516, -4.651876),
                new TriangulationPoint(6.505612, -3.488907),
                new TriangulationPoint(7.020364, -2.325938),
                new TriangulationPoint(1.746534, 1.85967),
                new TriangulationPoint(1.977947, 2.011027),
                new TriangulationPoint(6.6213, 1.998223),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom233_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.137553, -1.882071),
                new TriangulationPoint(-0.134604, 0.059774),
                new TriangulationPoint(0.154836, 2.077674),
                new TriangulationPoint(-0.08955, 4.142566),
                new TriangulationPoint(2.198201, -2.134947),
                new TriangulationPoint(1.849849, -0.02649),
                new TriangulationPoint(2.08818, 1.927388),
                new TriangulationPoint(1.897882, 4.101015),
                new TriangulationPoint(3.867412, -1.861423),
                new TriangulationPoint(4.01939, -0.17655),
                new TriangulationPoint(4.095671, 2.036886),
                new TriangulationPoint(3.800306, 4.002051),
                new TriangulationPoint(6.076744, -2.10937),
                new TriangulationPoint(6.04615, 0.00689),
                new TriangulationPoint(5.921989, 1.968632),
                new TriangulationPoint(5.940776, 4.032877),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom234_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.023305, -3.884433),
                new TriangulationPoint(2.246222, 0.562305),
                new TriangulationPoint(1.738496, 3.263827),
                new TriangulationPoint(-1.488052, 2.018732),
                new TriangulationPoint(-1.748713, -1.191821),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom235_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(11.900981, -4.072027),
                new TriangulationPoint(14.898505, 6.56605),
                new TriangulationPoint(14.149166, -2.29245),
                new TriangulationPoint(12.771859, 1.92514),
                new TriangulationPoint(8.129004, 2.489195),
                new TriangulationPoint(12.276445, 6.927381),
                new TriangulationPoint(3.86953, -2.161761),
                new TriangulationPoint(2.703989, 3.924951),
                new TriangulationPoint(-1.083996, -7.265843),
                new TriangulationPoint(1.608151, -2.12855),
                new TriangulationPoint(9.237109, 3.860903),
                new TriangulationPoint(12.97084, 6.42536),
                new TriangulationPoint(11.023978, 3.904266),
                new TriangulationPoint(11.116778, -0.536799),
                new TriangulationPoint(14.632576, 6.296855),
                new TriangulationPoint(-0.435273, -1.61386),
                new TriangulationPoint(1.33875, 0.759397),
                new TriangulationPoint(8.44374, 3.815973),
                new TriangulationPoint(9.111748, -3.06859),
                new TriangulationPoint(8.774619, 4.125214),
                new TriangulationPoint(11.591307, 4.534188),
                new TriangulationPoint(12.49309, -5.180058),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom236_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.829036, 1.842995),
                new TriangulationPoint(8.214309, -2.677136),
                new TriangulationPoint(5.881102, 1.646425),
                new TriangulationPoint(2.09999, 2.257559),
                new TriangulationPoint(1.411979, 1.590267),
                new TriangulationPoint(6.195196, 0.394709),
                new TriangulationPoint(8.08969, -0.20007),
                new TriangulationPoint(4.761618, -1.280298),
                new TriangulationPoint(8.545194, -3.173417),
                new TriangulationPoint(5.171052, 5.609298),
                new TriangulationPoint(5.245072, -1.746549),
                new TriangulationPoint(7.216964, 0.379376),
                new TriangulationPoint(5.51422, -6.122431),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom237_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.016097, -5.866408),
                new TriangulationPoint(4.193375, -4.888673),
                new TriangulationPoint(4.549393, -3.910939),
                new TriangulationPoint(4.751748, -2.933204),
                new TriangulationPoint(5.186055, -1.955469),
                new TriangulationPoint(5.375809, -4.888673),
                new TriangulationPoint(5.775477, -3.910939),
                new TriangulationPoint(6.016916, -2.933204),
                new TriangulationPoint(6.414628, -1.955469),
                new TriangulationPoint(0.499979, 1.787084),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom238_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.029916, -2.158983),
                new TriangulationPoint(0.176133, 0.003384),
                new TriangulationPoint(2.166415, -2.182616),
                new TriangulationPoint(2.149652, -0.114128),
                new TriangulationPoint(3.883193, -1.800351),
                new TriangulationPoint(3.942896, -0.159715),
                new TriangulationPoint(5.87098, -1.829802),
                new TriangulationPoint(5.813613, -0.01197),
                new TriangulationPoint(8.134668, -1.957131),
                new TriangulationPoint(7.978049, -0.15059),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom239_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.9952, -2.308764),
                new TriangulationPoint(2.44756, -0.343316),
                new TriangulationPoint(2.594883, 0.868279),
                new TriangulationPoint(-0.269987, 3.213759),
                new TriangulationPoint(-2.962039, -0.242742),
                new TriangulationPoint(-0.971241, -2.493658),
                new TriangulationPoint(2.412895, -1.76641),
                new TriangulationPoint(3.113212, 2.599679),
                new TriangulationPoint(0.328259, 3.009342),
                new TriangulationPoint(-4.535025, 0.666166),
                new TriangulationPoint(-4.608461, -1.67624),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom240_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.106152, 5.471663),
                new TriangulationPoint(12.073852, -3.983417),
                new TriangulationPoint(10.589848, -3.461517),
                new TriangulationPoint(8.274937, -2.827698),
                new TriangulationPoint(7.117591, 5.350384),
                new TriangulationPoint(-2.036769, -2.723119),
                new TriangulationPoint(13.444255, 0.285959),
                new TriangulationPoint(9.719405, -7.252421),
                new TriangulationPoint(7.644963, 6.358935),
                new TriangulationPoint(10.738083, 3.055955),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom241_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.323864, 4.929444),
                new TriangulationPoint(3.276988, 4.53577),
                new TriangulationPoint(0.462117, 1.728693),
                new TriangulationPoint(1.551176, 0.171804),
                new TriangulationPoint(9.193166, -2.286483),
                new TriangulationPoint(6.871247, -2.742158),
                new TriangulationPoint(7.679655, 3.471472),
                new TriangulationPoint(7.572729, -0.320668),
                new TriangulationPoint(5.031876, 1.846358),
                new TriangulationPoint(3.003651, -0.008183),
                new TriangulationPoint(7.010884, 1.244054),
                new TriangulationPoint(7.770826, 5.462301),
                new TriangulationPoint(3.137279, -0.205796),
                new TriangulationPoint(7.686544, 1.745127),
                new TriangulationPoint(0.014587, -2.323559),
                new TriangulationPoint(8.807012, 1.412773),
                new TriangulationPoint(5.849147, -1.253684),
                new TriangulationPoint(4.881987, -5.402646),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom242_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.196075, -5.121296),
                new TriangulationPoint(3.463813, -4.267747),
                new TriangulationPoint(3.864247, -3.414197),
                new TriangulationPoint(4.197853, -2.560648),
                new TriangulationPoint(4.376279, -4.267747),
                new TriangulationPoint(4.735541, -3.414197),
                new TriangulationPoint(5.170705, -2.560648),
                new TriangulationPoint(5.33745, 3.657666),
                new TriangulationPoint(7.081061, 4.326111),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom243_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.07636, -2.032173),
                new TriangulationPoint(0.125902, 0.072009),
                new TriangulationPoint(1.985277, -1.881069),
                new TriangulationPoint(1.991921, 0.171726),
                new TriangulationPoint(3.855328, -2.133798),
                new TriangulationPoint(4.173075, -0.170572),
                new TriangulationPoint(6.052219, -2.106197),
                new TriangulationPoint(6.112948, 0.034013),
                new TriangulationPoint(8.104522, -2.031107),
                new TriangulationPoint(8.189604, 0.122444),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom244_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.471967, -2.205144),
                new TriangulationPoint(2.251321, -1.025383),
                new TriangulationPoint(4.500943, 1.582083),
                new TriangulationPoint(-0.106868, 2.836141),
                new TriangulationPoint(-2.783241, 2.392472),
                new TriangulationPoint(-4.738852, -0.41573),
                new TriangulationPoint(-2.647501, -2.0144),
                new TriangulationPoint(-1.137484, -2.468804),
                new TriangulationPoint(2.512557, -2.854279),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom245_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.301736, 7.59055),
                new TriangulationPoint(5.470973, 6.083385),
                new TriangulationPoint(11.708009, -5.260159),
                new TriangulationPoint(7.549136, 6.050598),
                new TriangulationPoint(-4.873362, -4.559695),
                new TriangulationPoint(2.989146, -0.978759),
                new TriangulationPoint(11.906419, 3.114111),
                new TriangulationPoint(-1.423562, 1.114009),
                new TriangulationPoint(13.453048, -5.054997),
                new TriangulationPoint(3.128006, 0.821087),
                new TriangulationPoint(2.458023, 4.028938),
                new TriangulationPoint(9.976854, 5.056391),
                new TriangulationPoint(10.288318, -4.461034),
                new TriangulationPoint(11.70042, -1.72602),
                new TriangulationPoint(4.496725, -3.718156),
                new TriangulationPoint(-3.205335, 2.688666),
                new TriangulationPoint(3.202193, -4.672539),
                new TriangulationPoint(13.31964, -3.508795),
                new TriangulationPoint(-0.270754, -3.704178),
                new TriangulationPoint(6.379835, 3.857904),
                new TriangulationPoint(-1.149869, 1.01029),
                new TriangulationPoint(8.345553, -3.919283),
                new TriangulationPoint(10.630611, 5.272606),
                new TriangulationPoint(1.846272, -3.68424),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom246_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.658511, -1.382838),
                new TriangulationPoint(5.1559, -3.448768),
                new TriangulationPoint(4.884635, 4.602627),
                new TriangulationPoint(3.364067, 4.945991),
                new TriangulationPoint(9.693015, -2.042918),
                new TriangulationPoint(1.499835, -3.353587),
                new TriangulationPoint(6.402711, -0.85269),
                new TriangulationPoint(0.576856, -2.231959),
                new TriangulationPoint(5.984624, 5.633779),
                new TriangulationPoint(7.109763, 4.293527),
                new TriangulationPoint(4.729833, 2.525461),
                new TriangulationPoint(0.057833, -3.370855),
                new TriangulationPoint(9.355828, -1.841465),
                new TriangulationPoint(8.422166, 1.118987),
                new TriangulationPoint(8.096688, 4.972789),
                new TriangulationPoint(7.776197, -1.866186),
                new TriangulationPoint(4.123915, -5.488801),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom247_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.493014, -4.221074),
                new TriangulationPoint(4.16648, -3.517562),
                new TriangulationPoint(4.317636, -2.814049),
                new TriangulationPoint(4.439251, -2.110537),
                new TriangulationPoint(5.870448, -3.517562),
                new TriangulationPoint(6.121737, -2.814049),
                new TriangulationPoint(6.540572, -2.110537),
                new TriangulationPoint(5.23603, 1.851226),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom248_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.077666, -2.059565),
                new TriangulationPoint(-0.187109, 0.084997),
                new TriangulationPoint(0.008826, 1.850393),
                new TriangulationPoint(0.159003, 4.181857),
                new TriangulationPoint(2.083686, -1.998394),
                new TriangulationPoint(2.112305, -0.139401),
                new TriangulationPoint(1.949604, 1.875137),
                new TriangulationPoint(1.928593, 3.948734),
                new TriangulationPoint(4.097561, -2.033217),
                new TriangulationPoint(4.176191, -0.176076),
                new TriangulationPoint(3.969153, 2.197255),
                new TriangulationPoint(4.057677, 3.948646),
                new TriangulationPoint(6.069459, -1.850968),
                new TriangulationPoint(5.837686, 0.098058),
                new TriangulationPoint(5.87185, 1.985071),
                new TriangulationPoint(6.024956, 4.022315),
                new TriangulationPoint(7.892326, -2.171531),
                new TriangulationPoint(8.158745, 0.000381),
                new TriangulationPoint(8.117137, 1.896689),
                new TriangulationPoint(8.003807, 4.126838),
                new TriangulationPoint(10.101653, -2.120548),
                new TriangulationPoint(10.130685, 0.068425),
                new TriangulationPoint(10.151558, 1.996586),
                new TriangulationPoint(9.92455, 3.836659),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom249_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.218219, 1.589958),
                new TriangulationPoint(0.719519, 2.294615),
                new TriangulationPoint(-2.175862, 1.09415),
                new TriangulationPoint(-1.592835, -1.893807),
                new TriangulationPoint(2.182582, -2.479413),
                new TriangulationPoint(4.379902, 1.960347),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom250_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.848146, 4.593471),
                new TriangulationPoint(6.348044, 5.405),
                new TriangulationPoint(12.693964, 5.648944),
                new TriangulationPoint(7.191794, -4.108694),
                new TriangulationPoint(9.891893, -1.287596),
                new TriangulationPoint(0.360183, 6.237264),
                new TriangulationPoint(6.181018, -2.887629),
                new TriangulationPoint(0.050108, -4.26512),
                new TriangulationPoint(10.622819, 4.994554),
                new TriangulationPoint(13.053781, -2.855409),
                new TriangulationPoint(7.412587, 3.463583),
                new TriangulationPoint(11.490525, 0.983806),
                new TriangulationPoint(-4.04211, 4.129317),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom251_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.229544, 2.293066),
                new TriangulationPoint(3.311097, -1.780476),
                new TriangulationPoint(3.488782, 4.311199),
                new TriangulationPoint(1.471267, -2.912388),
                new TriangulationPoint(0.870212, -3.370976),
                new TriangulationPoint(9.437712, 5.261643),
                new TriangulationPoint(5.637769, 3.627319),
                new TriangulationPoint(8.840665, 3.777299),
                new TriangulationPoint(9.814958, 1.781183),
                new TriangulationPoint(8.942464, -1.34008),
                new TriangulationPoint(1.80836, -3.073129),
                new TriangulationPoint(4.320187, -6.540789),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom252_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.188611, -5.720537),
                new TriangulationPoint(2.781377, -4.767114),
                new TriangulationPoint(2.983028, -3.813692),
                new TriangulationPoint(3.445353, -2.860269),
                new TriangulationPoint(4.356595, -4.767114),
                new TriangulationPoint(4.606182, -3.813692),
                new TriangulationPoint(4.620826, 2.588837),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom253_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.179407, -2.023312),
                new TriangulationPoint(-0.119242, 0.158081),
                new TriangulationPoint(2.032164, -2.170803),
                new TriangulationPoint(1.896645, -0.075936),
                new TriangulationPoint(3.947596, -1.92901),
                new TriangulationPoint(3.890906, -0.038324),
                new TriangulationPoint(5.915703, -2.185718),
                new TriangulationPoint(5.94123, -0.088986),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom254_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.054354, 0.715784),
                new TriangulationPoint(1.824226, 3.774749),
                new TriangulationPoint(-0.924307, 2.989693),
                new TriangulationPoint(-3.138453, 0.416628),
                new TriangulationPoint(-0.859345, -3.096278),
                new TriangulationPoint(2.155683, -3.766398),
                new TriangulationPoint(1.829567, -0.99929),
                new TriangulationPoint(2.16115, 2.503397),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom255_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.000197, 0.013483),
                new TriangulationPoint(0.983686, 5.165986),
                new TriangulationPoint(7.196043, 0.414135),
                new TriangulationPoint(-3.784518, 5.73142),
                new TriangulationPoint(1.417748, -5.291139),
                new TriangulationPoint(-3.252246, 1.820597),
                new TriangulationPoint(0.962787, -6.074115),
                new TriangulationPoint(9.203267, -1.055277),
                new TriangulationPoint(8.109634, 5.597419),
                new TriangulationPoint(-2.14495, 3.996696),
                new TriangulationPoint(8.408847, -3.876368),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom256_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.115461, 1.221113),
                new TriangulationPoint(8.683025, -3.890314),
                new TriangulationPoint(3.14955, 5.605901),
                new TriangulationPoint(2.131853, 5.447829),
                new TriangulationPoint(0.968631, 5.262656),
                new TriangulationPoint(8.406211, 4.685807),
                new TriangulationPoint(7.600894, 2.524887),
                new TriangulationPoint(1.784415, -2.114295),
                new TriangulationPoint(6.31167, 4.377172),
                new TriangulationPoint(7.105228, 3.404721),
                new TriangulationPoint(2.856323, 0.795532),
                new TriangulationPoint(3.690334, 3.265089),
                new TriangulationPoint(8.351432, 2.735544),
                new TriangulationPoint(5.001464, 0.617165),
                new TriangulationPoint(3.377443, -1.620458),
                new TriangulationPoint(6.204868, 1.715549),
                new TriangulationPoint(2.070514, 2.505323),
                new TriangulationPoint(4.321743, 5.103814),
                new TriangulationPoint(9.314522, -1.635416),
                new TriangulationPoint(2.726261, 3.784187),
                new TriangulationPoint(9.333203, 1.435228),
                new TriangulationPoint(7.716052, 0.252123),
                new TriangulationPoint(1.900979, -2.581465),
                new TriangulationPoint(4.65207, -6.047057),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom257_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.542489, -2.778421),
                new TriangulationPoint(4.123496, -2.315351),
                new TriangulationPoint(4.240367, -1.852281),
                new TriangulationPoint(4.495772, -1.38921),
                new TriangulationPoint(4.956286, -0.92614),
                new TriangulationPoint(5.193984, -0.46307),
                new TriangulationPoint(5.64949, -2.315351),
                new TriangulationPoint(6.152128, -1.852281),
                new TriangulationPoint(6.566295, -1.38921),
                new TriangulationPoint(6.771044, -0.92614),
                new TriangulationPoint(7.228463, -0.46307),
                new TriangulationPoint(4.532913, 4.275806),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom258_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.104302, -2.060345),
                new TriangulationPoint(0.195173, -0.181976),
                new TriangulationPoint(-0.197622, 1.819788),
                new TriangulationPoint(0.01001, 3.824581),
                new TriangulationPoint(2.132156, -1.823844),
                new TriangulationPoint(1.800747, -0.162193),
                new TriangulationPoint(1.824878, 2.092328),
                new TriangulationPoint(2.12907, 4.174945),
                new TriangulationPoint(3.833708, -1.863368),
                new TriangulationPoint(3.944477, -0.062488),
                new TriangulationPoint(4.096874, 1.855678),
                new TriangulationPoint(4.17665, 3.941469),
                new TriangulationPoint(5.999085, -1.981612),
                new TriangulationPoint(5.839976, 0.012556),
                new TriangulationPoint(5.814127, 2.09521),
                new TriangulationPoint(6.152778, 3.975227),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom259_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.204347, -3.681398),
                new TriangulationPoint(2.460774, 0.294913),
                new TriangulationPoint(0.797874, 2.384595),
                new TriangulationPoint(-3.138256, 3.847159),
                new TriangulationPoint(-2.976192, -2.130971),
                new TriangulationPoint(0.397773, -4.91217),
                new TriangulationPoint(2.844564, -3.883174),
                new TriangulationPoint(4.152761, -2.353776),
                new TriangulationPoint(3.809168, 1.605268),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom260_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.511607, -1.974597),
                new TriangulationPoint(-0.647306, -6.219436),
                new TriangulationPoint(14.837223, 3.460662),
                new TriangulationPoint(8.372649, 1.317631),
                new TriangulationPoint(-4.154266, -0.252406),
                new TriangulationPoint(12.838448, 6.553211),
                new TriangulationPoint(11.462262, -2.404229),
                new TriangulationPoint(1.790839, -2.402073),
                new TriangulationPoint(6.568846, 2.484588),
                new TriangulationPoint(-1.867272, -2.674287),
                new TriangulationPoint(8.419977, -7.195585),
                new TriangulationPoint(4.789661, 0.734302),
                new TriangulationPoint(14.985493, 5.324165),
                new TriangulationPoint(13.687206, 2.181139),
                new TriangulationPoint(9.922781, 6.099904),
                new TriangulationPoint(8.88874, -4.580675),
                new TriangulationPoint(12.027559, 4.327388),
                new TriangulationPoint(10.152, 1.843153),
                new TriangulationPoint(6.446072, -4.36005),
                new TriangulationPoint(-3.143886, 7.48281),
                new TriangulationPoint(-4.08113, 3.289524),
                new TriangulationPoint(3.557901, -6.26292),
                new TriangulationPoint(6.206908, 7.975887),
                new TriangulationPoint(13.071929, -3.849086),
                new TriangulationPoint(-3.420877, -5.345174),
                new TriangulationPoint(13.768114, 1.871186),
                new TriangulationPoint(-1.061629, 7.473064),
                new TriangulationPoint(6.46136, 4.015829),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom261_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.264664, 4.762485),
                new TriangulationPoint(2.265794, -2.265909),
                new TriangulationPoint(3.475736, 2.729578),
                new TriangulationPoint(1.847104, 3.439319),
                new TriangulationPoint(6.228493, -3.046641),
                new TriangulationPoint(0.515778, 0.996022),
                new TriangulationPoint(2.771528, 0.412653),
                new TriangulationPoint(1.126855, 1.054423),
                new TriangulationPoint(5.372484, 4.04417),
                new TriangulationPoint(2.263269, 2.866622),
                new TriangulationPoint(6.342674, 4.752297),
                new TriangulationPoint(6.465167, 4.760981),
                new TriangulationPoint(8.443436, -3.873289),
                new TriangulationPoint(0.878354, -2.149085),
                new TriangulationPoint(8.247907, 4.910362),
                new TriangulationPoint(5.337689, 1.407515),
                new TriangulationPoint(1.042005, -1.496503),
                new TriangulationPoint(8.728338, -3.536842),
                new TriangulationPoint(5.3714, 4.219254),
                new TriangulationPoint(3.327918, 5.498884),
                new TriangulationPoint(9.683404, -2.862411),
                new TriangulationPoint(5.193747, -2.002166),
                new TriangulationPoint(3.936187, 3.464684),
                new TriangulationPoint(1.987858, 3.836837),
                new TriangulationPoint(5.021848, -7.888672),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom262_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.949003, -4.256904),
                new TriangulationPoint(4.208501, -3.54742),
                new TriangulationPoint(4.4025, -2.837936),
                new TriangulationPoint(5.068555, -3.54742),
                new TriangulationPoint(5.368408, -2.837936),
                new TriangulationPoint(5.85361, -2.128452),
                new TriangulationPoint(6.351615, -1.418968),
                new TriangulationPoint(4.021522, 1.866039),
                new TriangulationPoint(4.664826, 2.829899),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom263_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.196394, -2.05203),
                new TriangulationPoint(-0.033679, -0.072606),
                new TriangulationPoint(-0.095697, 2.098041),
                new TriangulationPoint(2.092377, -1.898307),
                new TriangulationPoint(2.198892, -0.127643),
                new TriangulationPoint(1.8205, 2.156962),
                new TriangulationPoint(4.023438, -2.02309),
                new TriangulationPoint(4.057942, -0.004628),
                new TriangulationPoint(4.070723, 2.157889),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom264_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-4.258389, -2.320124),
                new TriangulationPoint(-0.498811, -2.62849),
                new TriangulationPoint(3.215029, -1.673111),
                new TriangulationPoint(2.118726, 2.949973),
                new TriangulationPoint(-2.334227, 3.527217),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom265_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(13.685756, 4.857643),
                new TriangulationPoint(2.279063, -3.482024),
                new TriangulationPoint(0.905655, 6.851912),
                new TriangulationPoint(13.505986, -2.935065),
                new TriangulationPoint(11.070372, -4.951795),
                new TriangulationPoint(-0.391721, 3.767678),
                new TriangulationPoint(0.072464, 4.819493),
                new TriangulationPoint(10.52619, -2.515642),
                new TriangulationPoint(9.649896, -3.932933),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom266_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.374551, -2.963381),
                new TriangulationPoint(0.006439, 1.396309),
                new TriangulationPoint(0.868749, 2.080004),
                new TriangulationPoint(9.13739, -0.41953),
                new TriangulationPoint(0.956657, 3.730924),
                new TriangulationPoint(6.221749, 4.237713),
                new TriangulationPoint(3.85557, -2.520752),
                new TriangulationPoint(8.019197, -3.216879),
                new TriangulationPoint(4.617918, 5.238244),
                new TriangulationPoint(6.798278, -0.55219),
                new TriangulationPoint(8.181887, 4.771058),
                new TriangulationPoint(3.696426, 5.581074),
                new TriangulationPoint(1.584109, -0.083371),
                new TriangulationPoint(5.12753, -5.994277),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom267_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.245371, -2.802853),
                new TriangulationPoint(4.408322, -2.33571),
                new TriangulationPoint(4.620381, -1.868568),
                new TriangulationPoint(4.720902, -1.401426),
                new TriangulationPoint(4.90372, -0.934284),
                new TriangulationPoint(5.188568, -0.467142),
                new TriangulationPoint(5.4394, -2.33571),
                new TriangulationPoint(5.83072, -1.868568),
                new TriangulationPoint(8.805178, 4.096942),
                new TriangulationPoint(4.472481, 4.043152),
                new TriangulationPoint(1.189346, 2.92374),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom268_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.015953, -2.165174),
                new TriangulationPoint(-0.089174, 0.189635),
                new TriangulationPoint(0.116884, 1.991019),
                new TriangulationPoint(1.837182, -1.923659),
                new TriangulationPoint(2.026335, 0.081265),
                new TriangulationPoint(2.108171, 1.911956),
                new TriangulationPoint(4.030938, -1.888201),
                new TriangulationPoint(4.054619, 0.08569),
                new TriangulationPoint(3.831802, 2.110012),
                new TriangulationPoint(5.992407, -2.052016),
                new TriangulationPoint(5.929292, 0.023318),
                new TriangulationPoint(5.832047, 1.830208),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom269_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.214938, -2.634544),
                new TriangulationPoint(3.07848, -2.588342),
                new TriangulationPoint(3.516723, 0.787426),
                new TriangulationPoint(0.991349, 2.405539),
                new TriangulationPoint(-0.740923, 2.450224),
                new TriangulationPoint(-3.225332, 1.659634),
                new TriangulationPoint(-2.137634, -0.061662),
                new TriangulationPoint(0.193769, -3.438214),
                new TriangulationPoint(2.941352, -3.263653),
                new TriangulationPoint(2.160314, 0.218846),
                new TriangulationPoint(2.203863, 3.452698),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom270_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(14.978083, 4.240822),
                new TriangulationPoint(5.815085, 3.647669),
                new TriangulationPoint(7.736231, -6.443501),
                new TriangulationPoint(9.964351, -4.345308),
                new TriangulationPoint(9.34955, -5.286276),
                new TriangulationPoint(3.633641, 2.090863),
                new TriangulationPoint(-2.026869, 7.725662),
                new TriangulationPoint(7.563794, -4.066183),
                new TriangulationPoint(2.150459, -3.732207),
                new TriangulationPoint(12.168271, -0.5947),
                new TriangulationPoint(2.528513, 6.569905),
                new TriangulationPoint(-4.258089, -2.844276),
                new TriangulationPoint(1.057645, 0.439652),
                new TriangulationPoint(-2.01162, 2.986811),
                new TriangulationPoint(5.735857, -0.619845),
                new TriangulationPoint(5.013936, -7.719117),
                new TriangulationPoint(-3.399201, 5.378747),
                new TriangulationPoint(14.101086, -3.331273),
                new TriangulationPoint(-0.326651, -0.628696),
                new TriangulationPoint(3.412179, -4.027644),
                new TriangulationPoint(11.705325, -3.088773),
                new TriangulationPoint(4.737955, 5.001813),
                new TriangulationPoint(5.326499, 5.404418),
                new TriangulationPoint(1.977498, -2.503657),
                new TriangulationPoint(-1.84568, -2.519026),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom271_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.212665, -2.156561),
                new TriangulationPoint(2.452751, 1.901186),
                new TriangulationPoint(0.500354, 2.832959),
                new TriangulationPoint(5.500181, 4.490012),
                new TriangulationPoint(2.537913, -0.697578),
                new TriangulationPoint(6.828082, 1.836203),
                new TriangulationPoint(6.505036, 4.008382),
                new TriangulationPoint(1.299694, 3.309293),
                new TriangulationPoint(2.020511, 4.385289),
                new TriangulationPoint(6.218083, 2.623873),
                new TriangulationPoint(9.806517, 4.602396),
                new TriangulationPoint(5.782677, -2.738628),
                new TriangulationPoint(9.395725, -0.055067),
                new TriangulationPoint(5.337173, 3.283114),
                new TriangulationPoint(1.931998, -1.864372),
                new TriangulationPoint(7.467446, 0.929868),
                new TriangulationPoint(5.669655, -0.228365),
                new TriangulationPoint(1.738051, 1.153534),
                new TriangulationPoint(4.936611, -3.713155),
                new TriangulationPoint(6.954982, -1.722577),
                new TriangulationPoint(5.191446, -5.730228),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom272_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.892288, -2.01215),
                new TriangulationPoint(5.367437, -1.676792),
                new TriangulationPoint(5.792185, -1.341433),
                new TriangulationPoint(5.981909, -1.006075),
                new TriangulationPoint(6.096723, -1.676792),
                new TriangulationPoint(6.432458, -1.341433),
                new TriangulationPoint(5.269108, 3.469677),
                new TriangulationPoint(2.486085, 3.355402),
                new TriangulationPoint(7.370443, 1.068101),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom273_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.046764, -1.98532),
                new TriangulationPoint(0.191289, -0.160583),
                new TriangulationPoint(0.038933, 1.920815),
                new TriangulationPoint(2.15444, -1.937301),
                new TriangulationPoint(2.022513, -0.000608),
                new TriangulationPoint(1.957107, 2.183399),
                new TriangulationPoint(3.834976, -2.016312),
                new TriangulationPoint(3.870755, 0.006695),
                new TriangulationPoint(3.954615, 2.107787),
                new TriangulationPoint(6.108918, -2.169817),
                new TriangulationPoint(6.143343, -0.191916),
                new TriangulationPoint(5.96045, 2.156293),
                new TriangulationPoint(8.17924, -1.800419),
                new TriangulationPoint(8.116031, 0.054145),
                new TriangulationPoint(7.994367, 2.037383),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom274_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.717853, 1.156128),
                new TriangulationPoint(-0.332689, 4.966667),
                new TriangulationPoint(-3.352409, 3.35938),
                new TriangulationPoint(-3.641599, -1.512775),
                new TriangulationPoint(0.932888, -3.636682),
                new TriangulationPoint(2.850028, -1.284426),
                new TriangulationPoint(4.168486, 0.914407),
                new TriangulationPoint(-0.769267, 3.978021),
                new TriangulationPoint(-4.459125, 1.99731),
                new TriangulationPoint(-2.348218, -1.693787),
                new TriangulationPoint(0.016885, -3.017503),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom275_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.093658, -4.765051),
                new TriangulationPoint(12.946749, -3.315977),
                new TriangulationPoint(13.841148, -0.94164),
                new TriangulationPoint(14.374453, 4.82574),
                new TriangulationPoint(6.502826, 1.161601),
                new TriangulationPoint(-3.095286, 4.589149),
                new TriangulationPoint(8.814471, 7.3751),
                new TriangulationPoint(9.703523, -0.696597),
                new TriangulationPoint(4.075735, 6.812502),
                new TriangulationPoint(3.376421, 7.507877),
                new TriangulationPoint(9.882541, 0.829454),
                new TriangulationPoint(9.558828, 7.609504),
                new TriangulationPoint(-2.401308, 3.781574),
                new TriangulationPoint(11.024124, 0.181724),
                new TriangulationPoint(8.79139, 1.478094),
                new TriangulationPoint(3.859313, 6.685),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom276_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.696004, -2.107067),
                new TriangulationPoint(2.974278, -3.505789),
                new TriangulationPoint(1.884035, -0.371451),
                new TriangulationPoint(4.618049, 2.480199),
                new TriangulationPoint(1.084781, 1.283948),
                new TriangulationPoint(4.626792, 1.317052),
                new TriangulationPoint(3.168985, 2.192376),
                new TriangulationPoint(5.796776, 1.828044),
                new TriangulationPoint(6.046505, 5.309276),
                new TriangulationPoint(6.032484, 5.601405),
                new TriangulationPoint(8.739058, -3.664083),
                new TriangulationPoint(5.896558, -3.20216),
                new TriangulationPoint(8.530972, -0.779334),
                new TriangulationPoint(8.455042, 5.242844),
                new TriangulationPoint(0.101791, -1.562324),
                new TriangulationPoint(5.299173, -1.333492),
                new TriangulationPoint(7.741129, -3.507575),
                new TriangulationPoint(8.400694, -2.564919),
                new TriangulationPoint(5.756912, -7.836727),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom277_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.402158, -6.726337),
                new TriangulationPoint(3.051541, -5.605281),
                new TriangulationPoint(3.502212, -4.484225),
                new TriangulationPoint(4.585666, -5.605281),
                new TriangulationPoint(5.156634, -4.484225),
                new TriangulationPoint(1.441254, 1.147156),
                new TriangulationPoint(3.138628, 3.017983),
                new TriangulationPoint(6.056236, 4.334906),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom278_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.180057, -2.072641),
                new TriangulationPoint(0.06009, -0.128451),
                new TriangulationPoint(-0.121733, 1.828777),
                new TriangulationPoint(1.87609, -1.927225),
                new TriangulationPoint(2.067134, 0.091745),
                new TriangulationPoint(2.183408, 2.020077),
                new TriangulationPoint(4.08805, -2.165954),
                new TriangulationPoint(4.188293, 0.003099),
                new TriangulationPoint(4.073918, 1.906576),
                new TriangulationPoint(6.001762, -2.19522),
                new TriangulationPoint(5.954408, -0.190404),
                new TriangulationPoint(5.804322, 1.897473),
                new TriangulationPoint(7.835695, -1.9126),
                new TriangulationPoint(8.173231, 0.148923),
                new TriangulationPoint(8.111511, 2.149983),
                new TriangulationPoint(10.10621, -1.929484),
                new TriangulationPoint(9.807936, -0.106748),
                new TriangulationPoint(9.825897, 2.147865),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom279_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.137912, -0.530245),
                new TriangulationPoint(0.506252, 4.353279),
                new TriangulationPoint(-1.694183, 3.387751),
                new TriangulationPoint(-3.465894, 2.743192),
                new TriangulationPoint(-1.97502, -0.780993),
                new TriangulationPoint(-1.523814, -1.656642),
                new TriangulationPoint(3.172278, -3.376785),
                new TriangulationPoint(4.021356, -0.819217),
                new TriangulationPoint(2.215336, 3.90041),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom280_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.057399, -2.572045),
                new TriangulationPoint(-3.056823, 0.908055),
                new TriangulationPoint(-0.916336, -7.314999),
                new TriangulationPoint(4.034127, -5.516943),
                new TriangulationPoint(-4.13155, -0.93591),
                new TriangulationPoint(7.176584, 7.012944),
                new TriangulationPoint(5.568913, -0.227311),
                new TriangulationPoint(5.943554, -6.507083),
                new TriangulationPoint(-4.880238, 0.407421),
                new TriangulationPoint(4.708258, 7.165707),
                new TriangulationPoint(-1.715332, -2.437631),
                new TriangulationPoint(13.6482, 6.793319),
                new TriangulationPoint(2.170576, -6.282318),
                new TriangulationPoint(14.821028, 4.857737),
                new TriangulationPoint(-3.866889, -5.944507),
                new TriangulationPoint(12.681106, 2.377726),
                new TriangulationPoint(4.769085, -4.57071),
                new TriangulationPoint(0.774361, 0.642253),
                new TriangulationPoint(7.822393, -4.42021),
                new TriangulationPoint(9.654652, 4.366623),
                new TriangulationPoint(-3.786126, 0.6172),
                new TriangulationPoint(8.914801, 2.065583),
                new TriangulationPoint(6.811107, -5.088316),
                new TriangulationPoint(5.043353, -5.418648),
                new TriangulationPoint(6.118013, 2.117733),
                new TriangulationPoint(1.868257, -5.375938),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom281_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.688824, 5.377465),
                new TriangulationPoint(0.135285, 4.482517),
                new TriangulationPoint(3.776126, 3.282615),
                new TriangulationPoint(3.807936, 2.620603),
                new TriangulationPoint(2.40258, 2.944771),
                new TriangulationPoint(5.63649, 3.081064),
                new TriangulationPoint(4.849738, 0.351406),
                new TriangulationPoint(3.987673, 1.587433),
                new TriangulationPoint(8.542427, -3.907054),
                new TriangulationPoint(8.387034, 1.813412),
                new TriangulationPoint(4.669841, 0.496386),
                new TriangulationPoint(3.10604, -0.028056),
                new TriangulationPoint(7.369404, -3.080848),
                new TriangulationPoint(8.565976, 3.691503),
                new TriangulationPoint(5.140936, 1.362727),
                new TriangulationPoint(9.8751, -0.276804),
                new TriangulationPoint(9.180317, 3.647277),
                new TriangulationPoint(9.299622, 2.63032),
                new TriangulationPoint(3.054603, 5.365469),
                new TriangulationPoint(1.570902, 5.046642),
                new TriangulationPoint(3.300214, -3.095051),
                new TriangulationPoint(5.462027, -6.894505),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom282_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.770303, -5.318092),
                new TriangulationPoint(4.405862, -4.431743),
                new TriangulationPoint(4.551113, -3.545394),
                new TriangulationPoint(4.927227, -2.659046),
                new TriangulationPoint(5.291203, -1.772697),
                new TriangulationPoint(5.933525, -4.431743),
                new TriangulationPoint(6.282607, -3.545394),
                new TriangulationPoint(7.566934, 3.307014),
                new TriangulationPoint(3.943167, 1.995135),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom283_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-0.174154, -2.081253),
                new TriangulationPoint(-0.156936, -0.085386),
                new TriangulationPoint(-0.036337, 1.96913),
                new TriangulationPoint(1.938977, -1.899381),
                new TriangulationPoint(2.196238, -0.115841),
                new TriangulationPoint(1.91403, 2.17603),
                new TriangulationPoint(3.910411, -2.127196),
                new TriangulationPoint(3.981232, 0.172988),
                new TriangulationPoint(4.041769, 2.139228),
                new TriangulationPoint(5.822239, -1.879391),
                new TriangulationPoint(5.923468, 0.024073),
                new TriangulationPoint(5.848739, 2.069379),
                new TriangulationPoint(7.940023, -2.06431),
                new TriangulationPoint(7.862568, 0.144668),
                new TriangulationPoint(7.8925, 2.055005),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom284_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.581518, -0.512591),
                new TriangulationPoint(2.498375, 4.145508),
                new TriangulationPoint(-1.583998, 2.780122),
                new TriangulationPoint(-2.593386, -1.49664),
                new TriangulationPoint(-1.029936, -2.814526),
                new TriangulationPoint(2.091527, -3.164154),
                new TriangulationPoint(4.133422, -2.693422),
                new TriangulationPoint(3.997818, 2.080291),
                new TriangulationPoint(-0.680454, 4.015033),
                new TriangulationPoint(-2.032856, 2.943406),
                new TriangulationPoint(-2.880405, -0.254437),
                new TriangulationPoint(-2.40077, -2.507294),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom285_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.609842, 4.615337),
                new TriangulationPoint(11.962153, -0.58618),
                new TriangulationPoint(14.405245, 3.40355),
                new TriangulationPoint(8.466029, -0.324132),
                new TriangulationPoint(12.392966, 1.259279),
                new TriangulationPoint(11.336349, 0.070642),
                new TriangulationPoint(5.177782, -1.499039),
                new TriangulationPoint(10.425687, 2.009172),
                new TriangulationPoint(0.474833, 0.258797),
                new TriangulationPoint(-2.519244, -7.872819),
                new TriangulationPoint(4.076995, -4.859555),
                new TriangulationPoint(-0.413865, -0.75402),
                new TriangulationPoint(10.523493, 4.014516),
                new TriangulationPoint(14.345853, -4.301515),
                new TriangulationPoint(3.096475, 3.532579),
                new TriangulationPoint(14.641438, 2.306862),
                new TriangulationPoint(3.363064, -2.625303),
                new TriangulationPoint(6.819313, 4.91643),
                new TriangulationPoint(-0.446982, 0.553869),
                new TriangulationPoint(13.524821, 7.75632),
                new TriangulationPoint(-2.795088, -2.892065),
                new TriangulationPoint(3.821622, -7.561397),
                new TriangulationPoint(13.090592, 5.473724),
                new TriangulationPoint(1.42082, 2.44207),
                new TriangulationPoint(3.012885, -6.345673),
                new TriangulationPoint(3.749012, -2.23052),
                new TriangulationPoint(-0.024569, -2.021093),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom286_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.623852, 0.643635),
                new TriangulationPoint(8.943218, -1.402263),
                new TriangulationPoint(2.873384, 1.336706),
                new TriangulationPoint(5.47495, 0.91661),
                new TriangulationPoint(3.57574, -2.774655),
                new TriangulationPoint(9.976169, 2.930226),
                new TriangulationPoint(1.345816, -2.915048),
                new TriangulationPoint(3.77769, 5.059289),
                new TriangulationPoint(8.762515, -3.05783),
                new TriangulationPoint(8.211162, 2.853101),
                new TriangulationPoint(0.937498, 5.954737),
                new TriangulationPoint(0.788968, -3.349882),
                new TriangulationPoint(4.070596, -1.380188),
                new TriangulationPoint(4.944359, 4.869632),
                new TriangulationPoint(9.502591, 1.19203),
                new TriangulationPoint(3.800708, 5.277677),
                new TriangulationPoint(3.141043, -0.240101),
                new TriangulationPoint(1.801363, 5.332183),
                new TriangulationPoint(4.906186, -7.713319),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom287_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.274982, -2.212095),
                new TriangulationPoint(3.507959, -1.843413),
                new TriangulationPoint(3.874019, -1.47473),
                new TriangulationPoint(4.326383, -1.106048),
                new TriangulationPoint(4.772742, -0.737365),
                new TriangulationPoint(4.983078, -0.368683),
                new TriangulationPoint(4.623255, -1.843413),
                new TriangulationPoint(4.986567, -1.47473),
                new TriangulationPoint(4.468161, 3.468078),
                new TriangulationPoint(6.814838, 1.448223),
                new TriangulationPoint(5.434638, 3.140921),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom288_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.032156, -2.015051),
                new TriangulationPoint(0.045073, 0.167228),
                new TriangulationPoint(-0.108493, 1.996433),
                new TriangulationPoint(-0.154374, 4.117859),
                new TriangulationPoint(1.991766, -1.884336),
                new TriangulationPoint(2.052786, 0.08322),
                new TriangulationPoint(1.979524, 1.893302),
                new TriangulationPoint(2.140896, 3.918711),
                new TriangulationPoint(4.021583, -1.927671),
                new TriangulationPoint(4.012603, 0.144111),
                new TriangulationPoint(4.074561, 1.804618),
                new TriangulationPoint(4.183706, 4.148528),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom289_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.835914, -2.986844),
                new TriangulationPoint(-0.18546, -3.300767),
                new TriangulationPoint(0.946648, -2.211164),
                new TriangulationPoint(3.721107, -2.607662),
                new TriangulationPoint(3.654205, 1.808337),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom290_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(14.544348, 2.152554),
                new TriangulationPoint(1.789198, -0.615587),
                new TriangulationPoint(-0.073809, 7.861992),
                new TriangulationPoint(14.935918, -6.342132),
                new TriangulationPoint(10.347364, 5.465665),
                new TriangulationPoint(12.051044, 3.000322),
                new TriangulationPoint(11.703561, -7.578081),
                new TriangulationPoint(3.474267, -2.75296),
                new TriangulationPoint(0.912311, 2.955157),
                new TriangulationPoint(-2.047481, 4.639799),
                new TriangulationPoint(-3.356992, -5.581209),
                new TriangulationPoint(6.049216, -3.567847),
                new TriangulationPoint(2.174245, -4.134399),
                new TriangulationPoint(-3.214669, 2.249615),
                new TriangulationPoint(3.342921, 3.41986),
                new TriangulationPoint(4.457968, 1.338149),
                new TriangulationPoint(-0.467987, -5.462261),
                new TriangulationPoint(-3.043563, -6.074126),
                new TriangulationPoint(7.084431, 4.101836),
                new TriangulationPoint(-4.716048, -2.290738),
                new TriangulationPoint(9.394008, -3.852399),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom291_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.045914, -3.289118),
                new TriangulationPoint(9.612879, 0.477767),
                new TriangulationPoint(0.225215, 1.538243),
                new TriangulationPoint(5.506957, 1.503415),
                new TriangulationPoint(7.23719, -3.237476),
                new TriangulationPoint(9.440915, -3.442137),
                new TriangulationPoint(6.404646, 2.069972),
                new TriangulationPoint(2.928411, 5.865804),
                new TriangulationPoint(7.435264, -1.631023),
                new TriangulationPoint(0.916666, 5.921921),
                new TriangulationPoint(6.284457, -1.315121),
                new TriangulationPoint(7.294811, 2.046334),
                new TriangulationPoint(3.737351, -1.91492),
                new TriangulationPoint(7.545267, -0.948833),
                new TriangulationPoint(9.654851, 0.707073),
                new TriangulationPoint(3.140988, -2.748606),
                new TriangulationPoint(1.366575, 4.525479),
                new TriangulationPoint(9.179935, 5.009849),
                new TriangulationPoint(1.515547, 5.83438),
                new TriangulationPoint(3.439981, 5.097347),
                new TriangulationPoint(5.012255, 4.248187),
                new TriangulationPoint(1.653204, -2.455141),
                new TriangulationPoint(0.34389, 5.261279),
                new TriangulationPoint(5.269907, 3.5073),
                new TriangulationPoint(8.4536, 3.696692),
                new TriangulationPoint(5.003075, -6.142854),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom292_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.47654, -6.321686),
                new TriangulationPoint(3.253785, -5.268071),
                new TriangulationPoint(3.483701, -4.214457),
                new TriangulationPoint(3.913207, -3.160843),
                new TriangulationPoint(4.585774, -5.268071),
                new TriangulationPoint(5.130289, -4.214457),
                new TriangulationPoint(5.652256, -3.160843),
                new TriangulationPoint(0.490622, 2.857963),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom293_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.123687, -2.059562),
                new TriangulationPoint(0.118422, 0.096015),
                new TriangulationPoint(0.157701, 2.078429),
                new TriangulationPoint(-0.074368, 3.856471),
                new TriangulationPoint(1.868289, -1.8918),
                new TriangulationPoint(1.861756, -0.085059),
                new TriangulationPoint(1.875192, 1.986852),
                new TriangulationPoint(2.036334, 4.025388),
                new TriangulationPoint(4.132984, -1.851278),
                new TriangulationPoint(3.988567, -0.048846),
                new TriangulationPoint(3.994006, 2.169617),
                new TriangulationPoint(3.933832, 4.0166),
                new TriangulationPoint(6.197824, -1.818854),
                new TriangulationPoint(6.180731, -0.102709),
                new TriangulationPoint(6.190685, 1.922059),
                new TriangulationPoint(6.148767, 3.983028),
                new TriangulationPoint(8.115435, -1.809204),
                new TriangulationPoint(8.071585, -0.120011),
                new TriangulationPoint(7.833234, 2.084808),
                new TriangulationPoint(8.181171, 3.950131),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom294_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.388502, 2.338267),
                new TriangulationPoint(-4.337927, -1.2225),
                new TriangulationPoint(-1.254666, -3.84919),
                new TriangulationPoint(3.851095, -2.302044),
                new TriangulationPoint(2.809599, 2.330468),
                new TriangulationPoint(2.071581, 4.112714),
                new TriangulationPoint(-0.619964, 3.69149),
                new TriangulationPoint(-2.290187, 0.931421),
                new TriangulationPoint(-3.994813, -0.352995),
                new TriangulationPoint(-1.430729, -2.11707),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom295_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.246298, -7.786704),
                new TriangulationPoint(4.592648, 4.056366),
                new TriangulationPoint(-3.23185, -6.092254),
                new TriangulationPoint(13.31754, -3.836746),
                new TriangulationPoint(-0.31836, -3.869039),
                new TriangulationPoint(2.946808, 0.729831),
                new TriangulationPoint(8.749192, -5.861042),
                new TriangulationPoint(11.252074, -3.564112),
                new TriangulationPoint(11.436593, -2.069544),
                new TriangulationPoint(12.009174, -1.350709),
                new TriangulationPoint(-2.552512, 7.5918),
                new TriangulationPoint(-3.053328, 6.430782),
                new TriangulationPoint(8.036664, 0.856105),
                new TriangulationPoint(8.987548, 1.134533),
                new TriangulationPoint(7.630442, -0.791857),
                new TriangulationPoint(2.703624, -7.953219),
                new TriangulationPoint(10.327098, -0.522196),
                new TriangulationPoint(14.365387, -2.284896),
                new TriangulationPoint(1.385011, 0.614102),
                new TriangulationPoint(11.355622, 0.718993),
                new TriangulationPoint(9.126494, 0.006818),
                new TriangulationPoint(10.221729, 5.348673),
                new TriangulationPoint(12.474105, 3.894132),
                new TriangulationPoint(4.850263, -4.939106),
                new TriangulationPoint(-0.154715, 7.199913),
                new TriangulationPoint(-3.391385, 7.02412),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom296_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.5434, 1.65122),
                new TriangulationPoint(9.678613, -2.529256),
                new TriangulationPoint(5.657477, 5.155964),
                new TriangulationPoint(8.845735, 1.581104),
                new TriangulationPoint(2.013972, -0.842862),
                new TriangulationPoint(9.302242, -3.190753),
                new TriangulationPoint(8.5013, -0.668247),
                new TriangulationPoint(3.624982, -2.637305),
                new TriangulationPoint(8.432505, 1.730382),
                new TriangulationPoint(3.323548, 5.236976),
                new TriangulationPoint(4.506472, -2.456703),
                new TriangulationPoint(3.591015, 3.156645),
                new TriangulationPoint(2.586562, -2.138695),
                new TriangulationPoint(1.090942, 5.204367),
                new TriangulationPoint(3.337171, 1.414258),
                new TriangulationPoint(5.240624, -2.045797),
                new TriangulationPoint(5.053366, -1.561175),
                new TriangulationPoint(1.231431, 0.471789),
                new TriangulationPoint(4.360475, -6.052148),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom297_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.419905, -3.49329),
                new TriangulationPoint(4.800378, -2.911075),
                new TriangulationPoint(5.047154, -2.32886),
                new TriangulationPoint(5.149069, -1.746645),
                new TriangulationPoint(5.409526, -1.16443),
                new TriangulationPoint(5.670373, -2.911075),
                new TriangulationPoint(6.249399, -2.32886),
                new TriangulationPoint(6.626529, -1.746645),
                new TriangulationPoint(1.52503, 1.496333),
                new TriangulationPoint(8.809688, 4.810528),
                new TriangulationPoint(0.508963, 1.870202),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom298_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.098854, -2.129921),
                new TriangulationPoint(-0.026895, -0.074071),
                new TriangulationPoint(1.864288, -2.092446),
                new TriangulationPoint(1.981331, 0.155953),
                new TriangulationPoint(4.069554, -2.122672),
                new TriangulationPoint(4.083866, 0.083575),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a diverse random point set triangulates correctly.
        /// </summary>
        [Fact]
        public void Triangulate_DiverseRandom299_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.407675, 1.488693),
                new TriangulationPoint(-1.574925, 2.847478),
                new TriangulationPoint(-3.226966, 0.053033),
                new TriangulationPoint(-3.236178, -3.458012),
                new TriangulationPoint(-0.089353, -4.92517),
                new TriangulationPoint(3.086882, 0.021747),
                new TriangulationPoint(1.234965, 2.227238),
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Runs the triangulation on a triangle point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        private static void RunTriangle(List<TriangulationPoint> points)
        {
            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 1);
        }

        /// <summary>
        ///     Tests that a triangle shaped point set triggers the convex hull finalization.
        /// </summary>
        [Fact]
        public void Triangulate_TriangleConvexHull01_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.1916288599218452, 0.6256418102433369),
                new TriangulationPoint(0.5594989467068232, 1.0080616059259822),
                new TriangulationPoint(-0.6030538098242083, 0.9938802057516984)
            };

            RunTriangle(points);
        }

        /// <summary>
        ///     Tests that a triangle shaped point set triggers the convex hull finalization.
        /// </summary>
        [Fact]
        public void Triangulate_TriangleConvexHull02_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.449845575934357, 1.025697076913143),
                new TriangulationPoint(-0.10899002382965996, 1.3854145509479165),
                new TriangulationPoint(-2.2394549225894633, 1.246869737871254)
            };

            RunTriangle(points);
        }

        /// <summary>
        ///     Tests that a triangle shaped point set triggers the convex hull finalization.
        /// </summary>
        [Fact]
        public void Triangulate_TriangleConvexHull03_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-2.976539783124858, -1.0360879698045915),
                new TriangulationPoint(-0.994093299831102, -1.476498561281781),
                new TriangulationPoint(0.44592962173266515, -2.859092896766738)
            };

            RunTriangle(points);
        }

        /// <summary>
        ///     Tests that a point cloud with a steep descent produces reflex angle nodes.
        /// </summary>
        [Fact]
        public void Triangulate_ReflexAngleCloud01_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.9081476679575387, 2.4964954208100663),
                new TriangulationPoint(6.335956382721642, -0.4008613179441829),
                new TriangulationPoint(4.707093292245219, 3.0045029846972335),
                new TriangulationPoint(5.769300985042611, 3.999086290131829),
                new TriangulationPoint(7.737922690686734, -1.1572118392946253),
                new TriangulationPoint(9.244703147208646, 2.02995024855712),
                new TriangulationPoint(0.8993341917634635, 4.839204087778556),
                new TriangulationPoint(9.920386942066433, 0.9287661220546655),
                new TriangulationPoint(5.952932455555039, 3.7424964563653322),
                new TriangulationPoint(2.909823853014886, 0.5724077315872571),
                new TriangulationPoint(4.749875871813798, 1.0984240305137005),
                new TriangulationPoint(9.802955444810426, 1.323192494140562),
                new TriangulationPoint(9.809249797747121, 2.721726096105634),
                new TriangulationPoint(2.5625705824059297, 2.150840914412793),
                new TriangulationPoint(5.098772065294335, 2.7707512405564785),
                new TriangulationPoint(5.258729544123043, 0.7367134484167739),
                new TriangulationPoint(9.94193659626969, 1.6158988683558526)
            };

            RunPointSet(points);
        }

        /// <summary>
        ///     Tests that a valley with a steep descent produces reflex angle nodes.
        /// </summary>
        [Fact]
        public void Triangulate_ReflexAngleValley02_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.0, -3.840039347223956),
                new TriangulationPoint(3.7016612136278586, -3.2224702405890957),
                new TriangulationPoint(3.954341794948253, -0.879600333272379),
                new TriangulationPoint(4.410619242866812, -1.8644077691926249),
                new TriangulationPoint(4.6090034405277125, 1.1922568586384874),
                new TriangulationPoint(5.093932152210703, 2.4212533452435836),
                new TriangulationPoint(5.503837418371736, 4.1440995004112775),
                new TriangulationPoint(5.2, -2.585530765021165),
                new TriangulationPoint(5.446598288252297, -1.2374650307237465),
                new TriangulationPoint(5.893751195675578, -1.060786159774736),
                new TriangulationPoint(6.119975377675135, 0.22034581107638518),
                new TriangulationPoint(6.63725043839647, 2.6395258904140504),
                new TriangulationPoint(4.611106037446813, 1.740355052398683),
                new TriangulationPoint(5.84293967384982, 1.3714629236475857),
                new TriangulationPoint(2.9443856761531837, 1.852115775855312),
                new TriangulationPoint(4.206064720966883, 3.8489906894271217)
            };

            RunPointSet(points);
        }
    }
}
