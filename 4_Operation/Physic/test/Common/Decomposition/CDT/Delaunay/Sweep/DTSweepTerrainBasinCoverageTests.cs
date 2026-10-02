// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:DTSweepTerrainBasinCoverageTests.cs
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
    ///     The dt sweep terrain basin coverage tests class
    /// </summary>
    public class DTSweepTerrainBasinCoverageTests
    {
        /// <summary>
        ///     Runs the triangulation on the given point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        /// <returns>The resulting triangle count</returns>
        private static int RunPointSet(List<TriangulationPoint> points)
        {
            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 3);
            return pointSet.GetTriangles.Count;
        }


        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin1_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -6.7743804104506875),
                new TriangulationPoint(3.3522634065487718, -4.275047128535835),
                new TriangulationPoint(3.7124147903231974, -1.510092123527138),
                new TriangulationPoint(3.9605396524819265, 0.22097710393286807),
                new TriangulationPoint(4.155734591863926, -0.005995401654886656),
                new TriangulationPoint(5.2, -5.056587043684493),
                new TriangulationPoint(5.5636893451976075, -2.626864224033742),
                new TriangulationPoint(5.921103703845806, 1.2896281213828615),
                new TriangulationPoint(6.574253234860605, 0.2387531828939089),
                new TriangulationPoint(7.208680032849628, 4.31239280889068),
                new TriangulationPoint(1.7241235178541967, 1.3172268477814397),
                new TriangulationPoint(2.542909245259552, 1.7238476279768382),
                new TriangulationPoint(8.29046144070591, 1.0334476716972179),
                new TriangulationPoint(3.536559205519296, 3.706375613206241),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin2_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -7.330080772438124),
                new TriangulationPoint(3.1488734028064056, -4.904918569879388),
                new TriangulationPoint(3.3336544419795526, -1.467378960853229),
                new TriangulationPoint(3.619654361726555, -3.802901740196623),
                new TriangulationPoint(4.000966922333914, 0.12010561821525911),
                new TriangulationPoint(4.3742578892848725, 4.579129162768935),
                new TriangulationPoint(5.2, -5.104194576087087),
                new TriangulationPoint(5.669465254046705, -2.5237949370771977),
                new TriangulationPoint(5.92639601189941, 1.3244521773393574),
                new TriangulationPoint(6.44840617852677, 3.206262731509896),
                new TriangulationPoint(5.651348287077317, 1.6463930917188492),
                new TriangulationPoint(6.625932541967339, 1.8785156453393939),
                new TriangulationPoint(4.32214323283273, 3.107384297581103),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin3_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(3.9966557752325462, -1.3391492242641512),
                new TriangulationPoint(4.649510069121378, -0.6324199422413574),
                new TriangulationPoint(4.290983325005967, 0.5947602934179645),
                new TriangulationPoint(3.643352931199294, 0.15571570589938943),
                new TriangulationPoint(3.144011969279503, -2.9606868210065582),
                new TriangulationPoint(7.746876621500998, 1.7794082824976218),
                new TriangulationPoint(0.8761964695882967, 3.2237236272654144),
                new TriangulationPoint(3.835145269443814, 1.1184404963247667),
                new TriangulationPoint(1.3661512645735177, 1.8148599852877014),
                new TriangulationPoint(4.912212525919179, 1.1973133781912333),
                new TriangulationPoint(2.8314984137339043, 1.2657006966256077),
                new TriangulationPoint(7.562832938303627, -1.4141640204070898),
                new TriangulationPoint(7.5453171541659705, -2.1944658040043272),
                new TriangulationPoint(5.996990243902891, -3.4137393196177386),
                new TriangulationPoint(5.0094371405474085, -2.3028532892013214),
                new TriangulationPoint(5.856888122324314, -5.409346925285341),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin4_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -8.965909886623692),
                new TriangulationPoint(3.77016660606962, -5.873815858774799),
                new TriangulationPoint(4.086823630792472, -3.545763014508215),
                new TriangulationPoint(4.538985405554523, -0.5128865335664834),
                new TriangulationPoint(4.9421467824104, 4.069322329919952),
                new TriangulationPoint(5.239548063576011, 7.934069819502604),
                new TriangulationPoint(5.2, -7.035688680509171),
                new TriangulationPoint(5.57547153829386, -3.9197962411692453),
                new TriangulationPoint(5.900005896622318, -2.725602537580489),
                new TriangulationPoint(6.276356518211009, 1.2635498769379918),
                new TriangulationPoint(5.403128036019917, 1.7086947461164996),
                new TriangulationPoint(5.833838715140632, 1.8727265442128882),
                new TriangulationPoint(9.735627416398202, 2.734454484532799),
                new TriangulationPoint(9.85498036716831, 2.842246076018664),
                new TriangulationPoint(4.021539614778729, 3.6730168357831503),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin5_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -8.364867198450895),
                new TriangulationPoint(3.518213652315649, -5.122261266462602),
                new TriangulationPoint(3.703861793411831, -2.685928811246364),
                new TriangulationPoint(4.1770736108427275, -0.2332089412642233),
                new TriangulationPoint(4.509177215960425, 3.480902722400975),
                new TriangulationPoint(5.2, -6.329519167372618),
                new TriangulationPoint(5.527064086090338, -2.284800595991266),
                new TriangulationPoint(5.890625172336877, 0.7788524295196382),
                new TriangulationPoint(6.367134405983209, 0.09993017632508838),
                new TriangulationPoint(5.346653333560868, 1.2104551225018012),
                new TriangulationPoint(9.580632662205321, 1.8112714862503445),
                new TriangulationPoint(1.5447644617151304, 2.279627407565539),
                new TriangulationPoint(4.280446275500789, 3.0572373071020644),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin6_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2.890985772428562, 3.6978699712538488),
                new TriangulationPoint(3.1858855267920925, 3.355286787895154),
                new TriangulationPoint(1.6916688586080766, 1.1122655072772245),
                new TriangulationPoint(6.95099903128622, -1.9922608723827921),
                new TriangulationPoint(6.7108271628203, 1.776599685557466),
                new TriangulationPoint(0.18601593570132552, 3.8732729926115246),
                new TriangulationPoint(2.506040261362698, 0.5997987783513024),
                new TriangulationPoint(1.2200433626864307, -0.0002471115441280425),
                new TriangulationPoint(3.369244259488417, 1.9106143964038296),
                new TriangulationPoint(2.201639838610608, 2.5453794889829027),
                new TriangulationPoint(2.7256595635440477, -2.7965696932731987),
                new TriangulationPoint(5.170086578079539, 0.7790976747773115),
                new TriangulationPoint(3.0706231496625684, 2.1312303012848037),
                new TriangulationPoint(4.505578877639761, 1.7567649584993559),
                new TriangulationPoint(5.641935994216211, -4.710243993769513),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin7_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.560597012546191, -0.5603258221225467),
                new TriangulationPoint(7.755479634625595, -1.0046416246353842),
                new TriangulationPoint(8.981683807904684, -0.5636025725694385),
                new TriangulationPoint(0.2694288269939966, 3.342141180924206),
                new TriangulationPoint(6.273225166962121, 3.0547532136806996),
                new TriangulationPoint(9.408848145701386, 2.2726582988503656),
                new TriangulationPoint(7.673745685105093, -0.8740332112061013),
                new TriangulationPoint(4.915585869418264, -3.5885463019779635),
                new TriangulationPoint(4.285103159158073, 2.4661928557167725),
                new TriangulationPoint(1.2015788169585069, -2.058066911091128),
                new TriangulationPoint(5.377886721574648, -1.4605646717644132),
                new TriangulationPoint(5.818538500842889, -0.3772935999451641),
                new TriangulationPoint(8.624981943808955, -3.5889407915943026),
                new TriangulationPoint(0.47236209757270387, 3.620193153442905),
                new TriangulationPoint(7.332123884620203, 3.775937020674318),
                new TriangulationPoint(7.666805855774696, -0.9479920179340953),
                new TriangulationPoint(3.4920585590843385, -0.006762219596077923),
                new TriangulationPoint(2.9401394971367623, -0.4457141442437256),
                new TriangulationPoint(5.858670531706266, 0.5424419178359408),
                new TriangulationPoint(0.6525716281740794, -1.8929965150975607),
                new TriangulationPoint(4.859105080766187, 2.686267915501384),
                new TriangulationPoint(0.9309654407813053, -0.368491055615475),
                new TriangulationPoint(5.716828451825691, -5.897867414121454),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin8_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -8.715360469517933),
                new TriangulationPoint(3.1505396394760066, -6.9486214112329865),
                new TriangulationPoint(3.3355397992932887, -3.7506436205040767),
                new TriangulationPoint(3.6977507748164937, 0.19420112673724077),
                new TriangulationPoint(4.0319161906521375, 1.5977420360646217),
                new TriangulationPoint(4.285778548422166, 3.377442637571548),
                new TriangulationPoint(4.574062973574764, 6.278350225355306),
                new TriangulationPoint(5.2, -5.730215294371336),
                new TriangulationPoint(5.523741521324842, -4.860379469526297),
                new TriangulationPoint(6.055210022607451, -2.9699058872837316),
                new TriangulationPoint(6.312956917757615, -3.424579135029477),
                new TriangulationPoint(4.35066078060803, 1.0247927578281577),
                new TriangulationPoint(5.987309783691219, 1.7281195953153632),
                new TriangulationPoint(3.6467629781210626, 2.0047753886341937),
                new TriangulationPoint(3.9888800491992757, 3.3021718409388194),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin9_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -7.15819536389699),
                new TriangulationPoint(3.985381212078678, -5.896304587307244),
                new TriangulationPoint(4.28504811049674, -3.374748962508355),
                new TriangulationPoint(4.659154426334032, -0.29580342647702373),
                new TriangulationPoint(4.886143647966042, 0.5285057620009548),
                new TriangulationPoint(5.346666305394223, -1.2265116389185104),
                new TriangulationPoint(5.2, -4.445136878551103),
                new TriangulationPoint(5.490817958158822, -4.600410252174663),
                new TriangulationPoint(6.085152690664471, 0.713042263604045),
                new TriangulationPoint(6.675661908125348, -0.2236503317304841),
                new TriangulationPoint(9.561652638745333, 1.352867883794414),
                new TriangulationPoint(9.762932867632681, 2.987613245839073),
                new TriangulationPoint(3.5493652327216068, 3.733123819685133),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin10_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -8.992195847906263),
                new TriangulationPoint(3.8269834536253398, -6.605550474492776),
                new TriangulationPoint(4.265818561131981, -6.038766357087416),
                new TriangulationPoint(4.538777589024407, -0.008399191934607586),
                new TriangulationPoint(5.01417170759019, 2.629091074868196),
                new TriangulationPoint(5.2, -6.073960592312892),
                new TriangulationPoint(5.855732060808564, -3.611024536426992),
                new TriangulationPoint(6.359745420077697, 1.1779849185298747),
                new TriangulationPoint(9.280176488347433, 2.727499801538652),
                new TriangulationPoint(2.926411089918768, 1.3247727548353248),
                new TriangulationPoint(3.7351468015625824, 3.807411634739214),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin11_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.9166250847823103, -1.0810127691743023),
                new TriangulationPoint(1.8183033782142697, -0.31285337932075086),
                new TriangulationPoint(0.7398474080207978, 0.04493849912888326),
                new TriangulationPoint(7.886459123290358, -1.312013930320746),
                new TriangulationPoint(3.8611821289459156, -3.9487820118427193),
                new TriangulationPoint(1.444522040637453, 1.8362289210018838),
                new TriangulationPoint(3.27931202635137, -1.653266343126663),
                new TriangulationPoint(2.9593887985494867, -0.27292875772012826),
                new TriangulationPoint(6.151627747412598, -2.1178343101021992),
                new TriangulationPoint(5.497733403694692, -1.3002201455180629),
                new TriangulationPoint(5.869781256592731, -1.7047497544925427),
                new TriangulationPoint(3.1272997768257276, 1.5021825197628615),
                new TriangulationPoint(2.12375451909553, -0.48524412349110646),
                new TriangulationPoint(0.9500805432675781, 3.424932397634225),
                new TriangulationPoint(3.99728557746731, 0.6664856246982165),
                new TriangulationPoint(5.585075869963074, -5.874377457366501),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin12_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -9.438229307270715),
                new TriangulationPoint(3.5503812593176876, -6.676503494798453),
                new TriangulationPoint(3.9808875110377038, -3.1423910969795585),
                new TriangulationPoint(4.432684263415954, 1.0808791938761146),
                new TriangulationPoint(4.686947214876743, 4.972331786703258),
                new TriangulationPoint(5.2, -7.462513975628276),
                new TriangulationPoint(5.718010359684942, -1.9892308024707939),
                new TriangulationPoint(6.19915624563543, 1.171881339159773),
                new TriangulationPoint(6.583611794600083, 4.104952005043533),
                new TriangulationPoint(6.952441773820874, 0.1883774798152178),
                new TriangulationPoint(7.282057859786813, 9.207740269287074),
                new TriangulationPoint(5.67145928538938, 1.3014825658413967),
                new TriangulationPoint(9.340796903400122, 1.8140862857988505),
                new TriangulationPoint(3.893274168434215, 2.6483008841277567),
                new TriangulationPoint(3.8701211872371477, 3.721043279264608),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin13_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -6.621456647581168),
                new TriangulationPoint(3.762105616164443, -4.66066742206994),
                new TriangulationPoint(4.157372852720959, -2.2815720894445572),
                new TriangulationPoint(4.537491286610016, 0.06566961391562298),
                new TriangulationPoint(4.651590238582152, -0.10049219945410925),
                new TriangulationPoint(5.2, -4.999966756711135),
                new TriangulationPoint(5.748811945341906, -2.2251875594367307),
                new TriangulationPoint(6.329574775663007, -3.0650337653557354),
                new TriangulationPoint(6.640136614088033, 0.9588443257616586),
                new TriangulationPoint(7.2475062186119645, 0.1285205638891629),
                new TriangulationPoint(7.692763367943821, 3.7706657044989704),
                new TriangulationPoint(8.035621809789735, 1.5160198987070563),
                new TriangulationPoint(3.0166756515468824, 1.8478851983546676),
                new TriangulationPoint(3.9905307816763087, 3.761682922840902),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin14_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -8.56635647572873),
                new TriangulationPoint(3.4810900308569384, -5.900768786708328),
                new TriangulationPoint(3.9327077413130125, -4.450799004643192),
                new TriangulationPoint(4.145018769681928, -0.06034466622849344),
                new TriangulationPoint(4.535487157495454, 2.623537258582047),
                new TriangulationPoint(5.2, -6.180975234104246),
                new TriangulationPoint(5.89288206803281, -3.179450899957174),
                new TriangulationPoint(6.435569282684275, 0.23486184087576945),
                new TriangulationPoint(6.806299980919017, 4.16087692383913),
                new TriangulationPoint(7.280884317020367, 7.5229273788312),
                new TriangulationPoint(8.828371739400723, 1.270450349091762),
                new TriangulationPoint(6.013293697504929, 1.1795160137952845),
                new TriangulationPoint(1.247286666765477, 2.643006978390276),
                new TriangulationPoint(4.329203158537486, 3.8821019133935226),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin15_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.718954374417176, -1.8555205081848056),
                new TriangulationPoint(7.395724136100954, -2.8059750752551365),
                new TriangulationPoint(2.928748625763109, 3.448273107152559),
                new TriangulationPoint(8.467970010111095, -0.9233321160652359),
                new TriangulationPoint(9.862824566598434, 3.117367196417119),
                new TriangulationPoint(4.752262506984296, -2.2821108839856974),
                new TriangulationPoint(5.439237717277948, 1.0073237032663656),
                new TriangulationPoint(3.63326625136345, 1.3507408226610815),
                new TriangulationPoint(0.47176059357438266, 2.5277235240338944),
                new TriangulationPoint(3.9039171831234905, 3.9158994443322994),
                new TriangulationPoint(1.8519291569720626, -2.349060065275552),
                new TriangulationPoint(8.686787462181778, -3.8971127010402795),
                new TriangulationPoint(0.7866831732851841, -1.3782355698655526),
                new TriangulationPoint(6.380833185455218, 1.342315408094933),
                new TriangulationPoint(2.172669694839357, -1.1219829531023198),
                new TriangulationPoint(4.804850260170573, 3.0357712689022396),
                new TriangulationPoint(6.526399732812493, -0.5712467639573138),
                new TriangulationPoint(2.1632688828572952, -3.262704025610678),
                new TriangulationPoint(6.678230509477775, -0.9562362679076548),
                new TriangulationPoint(5.34504513924245, -4.892466549245858),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin16_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -9.477571669722707),
                new TriangulationPoint(3.547713169617445, -7.283599748067765),
                new TriangulationPoint(3.7896610318169284, -6.0938279981665335),
                new TriangulationPoint(3.9386713756894096, -0.6396503880813036),
                new TriangulationPoint(4.13388482231362, 4.932205628765397),
                new TriangulationPoint(5.2, -7.993992152004921),
                new TriangulationPoint(5.753855139507845, -2.7541921273999614),
                new TriangulationPoint(5.969135631885909, -1.74941167647557),
                new TriangulationPoint(6.469487861296855, 5.088698493453155),
                new TriangulationPoint(6.542526593684465, 2.38012205966754),
                new TriangulationPoint(8.847743370033681, 2.4857261681397103),
                new TriangulationPoint(7.198895070328794, 1.41914992612747),
                new TriangulationPoint(3.9576507641270995, 3.986426217009512),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin17_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -8.963825545722537),
                new TriangulationPoint(3.482342719325024, -5.994975317632294),
                new TriangulationPoint(3.634396296988426, -3.9084313726513242),
                new TriangulationPoint(4.004713549094607, 0.9179669073087631),
                new TriangulationPoint(4.449809093377464, 4.132849718254285),
                new TriangulationPoint(5.2, -6.542692484101969),
                new TriangulationPoint(5.809057557074846, -3.907991071196556),
                new TriangulationPoint(6.288827145466967, 1.645206505561001),
                new TriangulationPoint(8.80181270130063, 2.433960964639653),
                new TriangulationPoint(5.90936886421841, 2.3458432645284772),
                new TriangulationPoint(1.870624531000212, 2.1259421879080787),
                new TriangulationPoint(3.961029948648545, 1.0892535066647704),
                new TriangulationPoint(4.054584037770789, 3.953389304202697),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin18_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -4.631276146802714),
                new TriangulationPoint(3.9069100883355876, -3.6283872665371373),
                new TriangulationPoint(4.066663038063171, -2.1423398088498984),
                new TriangulationPoint(4.439656595717955, -1.377422540003936),
                new TriangulationPoint(4.92122764476632, -0.04812044227977719),
                new TriangulationPoint(5.066979615607754, 3.9292119914447223),
                new TriangulationPoint(5.458258359673552, 2.0236560819636367),
                new TriangulationPoint(5.2, -3.875095367633162),
                new TriangulationPoint(5.8892638551486955, -2.4317593464704452),
                new TriangulationPoint(6.365190209851224, -0.6505351350559478),
                new TriangulationPoint(6.620970822507968, 1.6645580336641972),
                new TriangulationPoint(0.8712806277308989, 2.9296200424105026),
                new TriangulationPoint(8.734222663908369, 2.4881492915973764),
                new TriangulationPoint(6.29679391919486, 2.2560138978324895),
                new TriangulationPoint(4.30285264495893, 3.4374006318102595),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin19_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(8.979797148601989, 3.836699917836441),
                new TriangulationPoint(3.4228853059107833, 2.8889105575573213),
                new TriangulationPoint(2.7282162023373955, -2.5671576925400448),
                new TriangulationPoint(3.330203114696873, 2.8929896461279085),
                new TriangulationPoint(5.151206289954114, 0.8816848941527704),
                new TriangulationPoint(2.861798588587809, -2.9228161419382395),
                new TriangulationPoint(7.846843957829682, 3.4864378867142083),
                new TriangulationPoint(7.4001743073576005, 2.624818085983777),
                new TriangulationPoint(4.477621686867262, 1.1059347154134578),
                new TriangulationPoint(8.067468725176282, 3.7342940940215694),
                new TriangulationPoint(2.8440632870625997, 3.6284196784852165),
                new TriangulationPoint(2.4197356879803054, -3.2364488315006943),
                new TriangulationPoint(0.39212531428417435, -0.5099951049825155),
                new TriangulationPoint(4.408088226061356, 1.9120052447132787),
                new TriangulationPoint(1.4621247451110393, -0.4954530505907968),
                new TriangulationPoint(0.7883477121537308, -1.9804934514595631),
                new TriangulationPoint(7.22814504859417, 1.9858026793160493),
                new TriangulationPoint(6.672586201072011, -1.4887492086220298),
                new TriangulationPoint(5.544566777788367, -6.32364234063944),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin20_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -9.338025666465064),
                new TriangulationPoint(3.1298845564620033, -7.04789359634114),
                new TriangulationPoint(3.3241252346076657, -2.9493959717496105),
                new TriangulationPoint(3.4668845353959523, 0.48752028497492184),
                new TriangulationPoint(3.616320563534424, 3.647307660828142),
                new TriangulationPoint(4.069317864286396, -0.2733652028190221),
                new TriangulationPoint(5.2, -7.405401666042414),
                new TriangulationPoint(5.8309137961505515, -6.093562424733271),
                new TriangulationPoint(6.527784317605097, -4.47116596960941),
                new TriangulationPoint(7.073874353744963, 1.340019540601208),
                new TriangulationPoint(1.623446713957678, 2.748498014057287),
                new TriangulationPoint(7.62152559013177, 1.203673538846743),
                new TriangulationPoint(1.2914664723404992, 2.4612197053903806),
                new TriangulationPoint(7.0218534753759645, 1.2199238977487776),
                new TriangulationPoint(4.416357769126239, 3.881499307640595),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin21_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -9.159443143363783),
                new TriangulationPoint(3.9045288236367184, -6.596859806942495),
                new TriangulationPoint(4.3362583584321, -5.884083708608358),
                new TriangulationPoint(4.825256226316679, -1.2842170996553381),
                new TriangulationPoint(4.993756291593311, 5.048730706659445),
                new TriangulationPoint(5.378172254272816, 7.002486145310838),
                new TriangulationPoint(5.7997417739125625, 1.885237073344964),
                new TriangulationPoint(5.2, -5.657085219690341),
                new TriangulationPoint(5.814635108278429, -3.2039208783332995),
                new TriangulationPoint(6.2062953579734526, 1.3539809947182366),
                new TriangulationPoint(8.911851327359607, 2.3221359119387976),
                new TriangulationPoint(4.073923120309563, 2.779275528983807),
                new TriangulationPoint(2.8098757764370537, 2.237621446716423),
                new TriangulationPoint(3.7962557963543833, 3.7954778758787913),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin22_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.061004647082186, -3.60211567934701),
                new TriangulationPoint(6.989629202051847, -1.5937069121718905),
                new TriangulationPoint(1.8811890864191527, -0.6792724675868045),
                new TriangulationPoint(5.881114865597857, -0.08880661618374575),
                new TriangulationPoint(0.22261399786109753, -2.1955409414114158),
                new TriangulationPoint(2.6369937568143915, -3.2664808366757265),
                new TriangulationPoint(2.045843071325609, 1.747118028694353),
                new TriangulationPoint(2.575080856948663, 2.4767027117669134),
                new TriangulationPoint(0.6332040255112592, -0.9486282230115628),
                new TriangulationPoint(9.1304872600038, -0.11064908472385682),
                new TriangulationPoint(3.062253055657378, -3.1648741807625043),
                new TriangulationPoint(5.846733290630734, -1.9566575130245916),
                new TriangulationPoint(9.320388408061298, -0.20263287248212514),
                new TriangulationPoint(3.458563719623985, -0.1982151550232505),
                new TriangulationPoint(4.912921136670244, 0.43774102834879436),
                new TriangulationPoint(5.789067990048355, 3.6770536525533783),
                new TriangulationPoint(6.137338502396521, -2.640336617194273),
                new TriangulationPoint(6.75011536420794, 2.7240867795069175),
                new TriangulationPoint(7.511543225269552, -3.379091191747734),
                new TriangulationPoint(8.627444393293672, -1.0061657228535812),
                new TriangulationPoint(6.619774287855148, -1.068524638688436),
                new TriangulationPoint(6.799542716145303, 0.13456433831460934),
                new TriangulationPoint(5.9156664521040705, -5.9982198979697285),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin23_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -8.066689643108607),
                new TriangulationPoint(3.4514726272092537, -4.975149323911829),
                new TriangulationPoint(3.94231391849104, -2.0922127100916956),
                new TriangulationPoint(4.363734677975874, -0.625361048141003),
                new TriangulationPoint(4.740362022184004, 2.115220448825271),
                new TriangulationPoint(5.2, -6.008113073808861),
                new TriangulationPoint(5.510548133082012, -5.467188478550389),
                new TriangulationPoint(5.816505018163708, 0.6381093942589064),
                new TriangulationPoint(3.528679964844454, 1.8114237733238487),
                new TriangulationPoint(9.017229252037232, 2.2123002797422466),
                new TriangulationPoint(3.994605122830069, 3.008759086490031),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin24_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -9.359979174733152),
                new TriangulationPoint(3.4604011194130413, -6.045261474008211),
                new TriangulationPoint(3.815054590308599, -2.270607711721973),
                new TriangulationPoint(4.08305357763686, 1.297322801761963),
                new TriangulationPoint(4.35584915785857, -0.5614609233815209),
                new TriangulationPoint(4.646894513371818, 9.292125368629197),
                new TriangulationPoint(5.2, -7.265538628148349),
                new TriangulationPoint(5.8232447985202285, -4.4262001089820115),
                new TriangulationPoint(6.0859969811448815, -4.772741310075674),
                new TriangulationPoint(6.446570281659518, 0.40767989888217215),
                new TriangulationPoint(7.038637600624299, -0.28950717984981367),
                new TriangulationPoint(9.653913355271293, 1.1444954742419047),
                new TriangulationPoint(1.3613024453452336, 1.3137802268908267),
                new TriangulationPoint(3.5434645693951587, 3.5869913164465648),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin25_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -6.8216455862026875),
                new TriangulationPoint(3.1488925941050483, -4.983735117067322),
                new TriangulationPoint(3.4093697930264146, -3.4251581128681856),
                new TriangulationPoint(3.7566118074378987, -3.203587615433955),
                new TriangulationPoint(4.050939100119723, 4.05646121315674),
                new TriangulationPoint(4.25268772125835, 5.3393647146500145),
                new TriangulationPoint(4.354323513179237, 9.248444381470122),
                new TriangulationPoint(5.2, -4.2466580897520405),
                new TriangulationPoint(5.442705441612148, -3.597415649833254),
                new TriangulationPoint(6.107006177681967, -0.7318758295110275),
                new TriangulationPoint(6.518828672179407, -2.2287172894836127),
                new TriangulationPoint(6.727381188761155, 0.8043866096615204),
                new TriangulationPoint(6.3313891162776335, 1.5139242124342938),
                new TriangulationPoint(4.633120440241471, 1.8247067000831976),
                new TriangulationPoint(9.201245740615411, 1.5656740062710242),
                new TriangulationPoint(4.019703640378873, 3.9237963794375754),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin26_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -5.673693371784731),
                new TriangulationPoint(3.08834023451821, -4.415167675819729),
                new TriangulationPoint(3.2204589064793936, -3.1635445764394516),
                new TriangulationPoint(3.645462998303335, -0.711648987768017),
                new TriangulationPoint(3.926271498029247, 1.2051405478763346),
                new TriangulationPoint(4.040307159368092, -0.03508125288636066),
                new TriangulationPoint(4.412013709690429, 5.309739583404546),
                new TriangulationPoint(5.2, -3.9660563351311193),
                new TriangulationPoint(5.692820934342603, -2.4470527806578914),
                new TriangulationPoint(6.340440918710288, 0.696918033788763),
                new TriangulationPoint(6.710481208660864, 0.24350724199568763),
                new TriangulationPoint(7.400881749764496, -1.1073680997560746),
                new TriangulationPoint(2.771105893315331, 1.475338512321626),
                new TriangulationPoint(9.305637399342674, 1.15760465625562),
                new TriangulationPoint(3.8930844247308953, 3.3376545171894385),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin27_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -9.915295939853088),
                new TriangulationPoint(3.8749713030992874, -7.751998222576676),
                new TriangulationPoint(4.008814404676117, -2.3889957138381384),
                new TriangulationPoint(4.184470021344941, -1.602009043733684),
                new TriangulationPoint(5.2, -8.22419191299971),
                new TriangulationPoint(5.582659086390706, -6.768246038872324),
                new TriangulationPoint(6.1706676701412855, 0.33571888446521747),
                new TriangulationPoint(6.849646697030239, 3.5771027022406177),
                new TriangulationPoint(5.448038692329097, 1.5347138953091175),
                new TriangulationPoint(9.18867913968334, 2.1275795377453695),
                new TriangulationPoint(3.7052316661948486, 3.416499617703492),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin28_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -5.717043978961671),
                new TriangulationPoint(3.49222940974507, -4.639541806899138),
                new TriangulationPoint(3.9106174564038483, -1.6185469115415678),
                new TriangulationPoint(4.211724756011611, -1.7138821450143693),
                new TriangulationPoint(4.492131636660607, 2.352679684061261),
                new TriangulationPoint(4.806916070639582, 4.72438594079253),
                new TriangulationPoint(5.2, -4.211318103303312),
                new TriangulationPoint(5.708824426405516, -3.618234828760099),
                new TriangulationPoint(6.262760049413313, 0.3737787541515578),
                new TriangulationPoint(5.128482456844524, 1.7171213825778668),
                new TriangulationPoint(7.443746103646115, 2.241886277330055),
                new TriangulationPoint(4.639417107514766, 2.220670966068595),
                new TriangulationPoint(9.411702318774397, 1.8272032834716156),
                new TriangulationPoint(4.184981155062551, 3.448965522669705),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin29_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -4.661682335036659),
                new TriangulationPoint(3.136054646287139, -3.116033179630857),
                new TriangulationPoint(3.3625752116844874, -3.140109922647339),
                new TriangulationPoint(3.5706573346493102, -1.6206854248069673),
                new TriangulationPoint(3.9817612381101406, 2.3648228431319556),
                new TriangulationPoint(5.2, -3.859043341725563),
                new TriangulationPoint(5.796974157028354, -3.1525299513281855),
                new TriangulationPoint(6.367137332943798, -1.5211646499224614),
                new TriangulationPoint(6.785571335994439, 1.1291463244828233),
                new TriangulationPoint(7.471196354819088, 0.30366389157406104),
                new TriangulationPoint(3.615292838595478, 1.7475956728437896),
                new TriangulationPoint(5.377269082412715, 2.418367759985089),
                new TriangulationPoint(9.680145759917863, 1.1373763699724229),
                new TriangulationPoint(3.7156043742856033, 3.3286110457631812),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin30_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -5.778278572381604),
                new TriangulationPoint(3.4274937242397545, -4.417641629464635),
                new TriangulationPoint(3.6088972948998665, -1.6005156118043447),
                new TriangulationPoint(3.8046278635992796, -2.213006387758174),
                new TriangulationPoint(4.278912713275716, 2.843627166463712),
                new TriangulationPoint(5.2, -4.5663161660607035),
                new TriangulationPoint(5.451238053036499, -3.908722577960196),
                new TriangulationPoint(5.932431163327969, -3.057596479474543),
                new TriangulationPoint(6.431653687512341, -1.639513332997856),
                new TriangulationPoint(5.5068563090203595, 2.4129161366321688),
                new TriangulationPoint(8.567075975503343, 2.642080108468458),
                new TriangulationPoint(6.093756889968066, 1.4904090401206207),
                new TriangulationPoint(4.433796243245618, 3.468911006799392),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin31_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -4.017214064494341),
                new TriangulationPoint(3.3350969656999676, -3.136488530771249),
                new TriangulationPoint(3.662808111572083, -2.0118069577679067),
                new TriangulationPoint(4.086113969835506, -1.653782209037768),
                new TriangulationPoint(4.208122077448351, 0.6100959325569999),
                new TriangulationPoint(5.2, -3.3559744988474605),
                new TriangulationPoint(5.6938268383936155, -2.1071233491239116),
                new TriangulationPoint(6.33863249166805, -0.3674821471267795),
                new TriangulationPoint(6.910836620261351, 2.0626839224162374),
                new TriangulationPoint(7.571111800182198, 1.2838048006672933),
                new TriangulationPoint(5.97225413004507, 2.8909902236848093),
                new TriangulationPoint(2.4957628280370323, 2.2507959498329067),
                new TriangulationPoint(9.47587239531608, 2.8132739289725546),
                new TriangulationPoint(3.8556863364557206, 3.316322989909129),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin32_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -6.856538804646832),
                new TriangulationPoint(3.681567747463271, -5.575606532212852),
                new TriangulationPoint(4.0996009589171045, -3.5153682354857088),
                new TriangulationPoint(4.220710183224041, -0.6168786412059282),
                new TriangulationPoint(4.533268721603449, -0.9034638631342515),
                new TriangulationPoint(5.2, -4.910347633451725),
                new TriangulationPoint(5.65328520394549, -3.5763702513776403),
                new TriangulationPoint(6.075466102815916, 0.2120190848545116),
                new TriangulationPoint(9.177361437667795, 1.6045859747587636),
                new TriangulationPoint(5.322901138720523, 1.4129735587225172),
                new TriangulationPoint(3.520119141796659, 3.465545361612712),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin33_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -6.59495109906185),
                new TriangulationPoint(3.0259408131362595, -3.9857818501467186),
                new TriangulationPoint(3.2954868161098503, -2.587281498575206),
                new TriangulationPoint(3.742988870173222, -3.354786932799219),
                new TriangulationPoint(5.2, -5.53172682878656),
                new TriangulationPoint(5.451848619036306, -3.768482670908492),
                new TriangulationPoint(5.864106019523044, -0.4067973085335366),
                new TriangulationPoint(6.254316169933563, 1.0609821499416503),
                new TriangulationPoint(6.673971977398718, 0.5401531016920931),
                new TriangulationPoint(8.038551936875354, 1.1958853444996687),
                new TriangulationPoint(1.0951533685881427, 2.2299133926769317),
                new TriangulationPoint(3.761803784063926, 3.944836160142364),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin34_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -7.64349990600883),
                new TriangulationPoint(3.2538635480468456, -6.2571590158089805),
                new TriangulationPoint(3.6085166980086436, -2.6163183994530517),
                new TriangulationPoint(4.041717690807635, -0.08302765559589709),
                new TriangulationPoint(5.2, -6.25679910210221),
                new TriangulationPoint(5.413584950013824, -4.433432273369133),
                new TriangulationPoint(5.924091482359959, 0.6490989903946849),
                new TriangulationPoint(6.41344089178063, -1.4760308700091116),
                new TriangulationPoint(8.961538630054118, 2.027091605135748),
                new TriangulationPoint(3.089444303461092, 2.3432489183467107),
                new TriangulationPoint(5.449545269575689, 1.3232329107463512),
                new TriangulationPoint(3.58158359494134, 3.8513361643307547),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin35_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.964802372252942, -0.05671118016201593),
                new TriangulationPoint(3.971846277812424, -3.6123317478282058),
                new TriangulationPoint(0.2629419836508772, 3.726989913604683),
                new TriangulationPoint(1.1399488482344657, 3.849946789373619),
                new TriangulationPoint(3.7946275173661426, -1.42366349577143),
                new TriangulationPoint(1.5938845330820814, 3.0104370336096906),
                new TriangulationPoint(3.3821333448319386, 0.8860349975926969),
                new TriangulationPoint(8.631500619757688, 1.9082667929624515),
                new TriangulationPoint(8.91217012373366, 1.5816079515878148),
                new TriangulationPoint(4.434966172294209, -3.5610304733556837),
                new TriangulationPoint(9.057081061907615, -3.1432013880196967),
                new TriangulationPoint(0.12321420019642179, -1.6563827347272926),
                new TriangulationPoint(5.321309704017504, 2.9473234335646605),
                new TriangulationPoint(8.022634665492287, -0.4867894670398858),
                new TriangulationPoint(0.13084980199618723, -3.6315550951434092),
                new TriangulationPoint(3.783727783609055, -0.9659423664984956),
                new TriangulationPoint(7.9311510910890775, -3.9156425147855853),
                new TriangulationPoint(4.7112716150988225, -2.8803820269556635),
                new TriangulationPoint(9.962231260706778, -3.9247594922430626),
                new TriangulationPoint(6.51279496332295, -2.304890341267404),
                new TriangulationPoint(7.856514522738994, -0.29958060956540544),
                new TriangulationPoint(0.9986273623065218, 1.949022038816019),
                new TriangulationPoint(6.960643798560204, 0.6875914729608184),
                new TriangulationPoint(5.289768759761829, -5.274987740104547),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin36_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -6.92932955777707),
                new TriangulationPoint(3.5683496573792537, -5.433098532897223),
                new TriangulationPoint(3.848380748065366, -4.409699356009449),
                new TriangulationPoint(4.287271859351207, 0.28465285123140305),
                new TriangulationPoint(4.41107876585381, -0.990175420839841),
                new TriangulationPoint(5.2, -4.469537056309566),
                new TriangulationPoint(5.62383958134979, -4.247180034948022),
                new TriangulationPoint(6.1181335590398565, -2.4088182518624137),
                new TriangulationPoint(6.714246318356249, 1.8512146068015518),
                new TriangulationPoint(7.1888226583548, 1.395152518709727),
                new TriangulationPoint(8.152998261224942, 1.5371526333210768),
                new TriangulationPoint(7.27707326751066, 1.2235976020915422),
                new TriangulationPoint(8.355208671817188, 2.8626058948517805),
                new TriangulationPoint(3.8897034723263717, 3.92210694724792),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin37_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.311898233048571, -2.397410611807094),
                new TriangulationPoint(8.651801603218448, 3.315564721504024),
                new TriangulationPoint(2.463280480570756, 2.5689230629098248),
                new TriangulationPoint(7.104402280926891, 0.994600987525005),
                new TriangulationPoint(6.288548957690852, 2.384568645797935),
                new TriangulationPoint(4.758868806417505, 1.1036805683298407),
                new TriangulationPoint(9.108073371047189, 2.7269250334831536),
                new TriangulationPoint(2.9855264271542086, -3.248356569208371),
                new TriangulationPoint(2.6753443631694394, 1.2340890603298735),
                new TriangulationPoint(5.361818762198938, 2.402747622878639),
                new TriangulationPoint(5.369085276205599, -1.6748428855439847),
                new TriangulationPoint(5.6594312496760075, 2.8681151675377574),
                new TriangulationPoint(6.611483905749155, 1.8908162032676934),
                new TriangulationPoint(0.5554776967295807, 0.9423287198610275),
                new TriangulationPoint(7.73446638031605, -0.14810764982742608),
                new TriangulationPoint(3.999803096055893, 3.730932436758155),
                new TriangulationPoint(6.2865252356447865, -3.2121863324251896),
                new TriangulationPoint(5.735437222167588, -6.785068999410173),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin38_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5, -7.647800310350862),
                new TriangulationPoint(3.5253389875988193, -4.956448665710056),
                new TriangulationPoint(3.7177726052784235, -3.1766557266573265),
                new TriangulationPoint(3.9891545987637502, -1.371540085140186),
                new TriangulationPoint(4.219661630838952, 2.521323531562345),
                new TriangulationPoint(4.364940627648002, 4.95575070486673),
                new TriangulationPoint(5.2, -6.013369348876921),
                new TriangulationPoint(5.414512150787987, -2.535823939746086),
                new TriangulationPoint(5.914722125332207, 0.21739911559311764),
                new TriangulationPoint(6.3645591439979885, -2.4252599416753418),
                new TriangulationPoint(6.983537897925608, 1.8954246053145027),
                new TriangulationPoint(8.90061310906923, 2.2739696648316317),
                new TriangulationPoint(7.05693964243724, 1.6753876724631467),
                new TriangulationPoint(4.381351710474748, 1.895189704790334),
                new TriangulationPoint(3.7727372554469563, 3.4518193939942026),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin39_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.1667259694853453, 1.8597432700264003),
                new TriangulationPoint(5.332956051143332, 0.6006950571204976),
                new TriangulationPoint(4.653826022825123, 2.5956991420107425),
                new TriangulationPoint(7.009895433210719, 0.5472526198938734),
                new TriangulationPoint(0.7711998050898312, -1.5414145167644202),
                new TriangulationPoint(4.939784265560928, 2.785522348613256),
                new TriangulationPoint(5.398680295515192, 1.828127249063983),
                new TriangulationPoint(2.5200920936279427, -2.682637266201264),
                new TriangulationPoint(2.4860437971009146, -3.8488423153054168),
                new TriangulationPoint(5.795382925213959, 0.623728161968164),
                new TriangulationPoint(8.482305988893987, 0.6674472115316652),
                new TriangulationPoint(2.650361607154068, -3.977607700963322),
                new TriangulationPoint(2.9699847069429164, -2.1219047671751605),
                new TriangulationPoint(0.8314409809333463, 1.09640734880064),
                new TriangulationPoint(5.5211785601084955, 2.0654933108321822),
                new TriangulationPoint(7.422809231757563, 0.037146912904990614),
                new TriangulationPoint(9.193211956505298, 3.714450616256544),
                new TriangulationPoint(5.018304355916708, -1.7640597288329434),
                new TriangulationPoint(0.6080037730783241, 1.4508346009304907),
                new TriangulationPoint(2.7267925360830465, 3.0567040588039456),
                new TriangulationPoint(9.720485429149347, 1.7329664555066113),
                new TriangulationPoint(5.0635492415463315, -4.461894225078586),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a complex valley terrain triangulates and triggers the basin fill.
        /// </summary>
        [Fact]
        public void Triangulate_TerrainBasin40_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.055730268385135694, -3.4688864832133457),
                new TriangulationPoint(6.368188800461678, -2.783195882469041),
                new TriangulationPoint(6.617667594280871, -3.063780936907875),
                new TriangulationPoint(5.581904349653937, 0.10850126860127851),
                new TriangulationPoint(6.167521596032904, 2.607234495974721),
                new TriangulationPoint(8.031163587249425, -2.2493165015472645),
                new TriangulationPoint(2.082425640934345, 3.68059112116722),
                new TriangulationPoint(5.691096147378486, 1.8223697197727722),
                new TriangulationPoint(4.05268075133333, -3.6940658873385126),
                new TriangulationPoint(3.5637276682833803, -1.0114621394367247),
                new TriangulationPoint(5.143274583454838, 3.282258327716151),
                new TriangulationPoint(5.196895545905873, -1.4936634774755984),
                new TriangulationPoint(7.887935525685519, 2.2204972385524293),
                new TriangulationPoint(1.0231046569641236, -2.0277714980895496),
                new TriangulationPoint(4.433790601060628, -1.8494767834662817),
                new TriangulationPoint(4.048480998747275, -3.516634400708896),
                new TriangulationPoint(4.653820118239997, 2.806300814638986),
                new TriangulationPoint(5.262818110763476, -6.6291854556785825),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a point cloud with a deep pit triangulates and reaches the basin left edge.
        /// </summary>
        [Fact]
        public void Triangulate_PointCloudPit_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(9.560597012546191, -0.5603258221225467),
                new TriangulationPoint(7.755479634625595, -1.0046416246353842),
                new TriangulationPoint(8.981683807904684, -0.5636025725694385),
                new TriangulationPoint(0.2694288269939966, 3.342141180924206),
                new TriangulationPoint(6.273225166962121, 3.0547532136806996),
                new TriangulationPoint(9.408848145701386, 2.2726582988503656),
                new TriangulationPoint(7.673745685105093, -0.8740332112061013),
                new TriangulationPoint(4.915585869418264, -3.5885463019779635),
                new TriangulationPoint(4.285103159158073, 2.4661928557167725),
                new TriangulationPoint(1.2015788169585069, -2.058066911091128),
                new TriangulationPoint(5.377886721574648, -1.4605646717644132),
                new TriangulationPoint(5.818538500842889, -0.3772935999451641),
                new TriangulationPoint(8.624981943808955, -3.5889407915943026),
                new TriangulationPoint(0.47236209757270387, 3.620193153442905),
                new TriangulationPoint(7.332123884620203, 3.775937020674318),
                new TriangulationPoint(7.666805855774696, -0.9479920179340953),
                new TriangulationPoint(3.4920585590843385, -0.006762219596077923),
                new TriangulationPoint(2.9401394971367623, -0.4457141442437256),
                new TriangulationPoint(5.858670531706266, 0.5424419178359408),
                new TriangulationPoint(0.6525716281740794, -1.8929965150975607),
                new TriangulationPoint(4.859105080766187, 2.686267915501384),
                new TriangulationPoint(0.9309654407813053, -0.368491055615475),
                new TriangulationPoint(5.716828451825691, -5.897867414121454)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 15);
        }

        /// <summary>
        ///     Tests that a valley terrain with a steep right side triangulates and fills the basin.
        /// </summary>
        [Fact]
        public void Triangulate_SteepRightValley_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(5.0, -6.7743804104506875),
                new TriangulationPoint(3.3522634065487718, -4.275047128535835),
                new TriangulationPoint(3.7124147903231974, -1.510092123527138),
                new TriangulationPoint(3.9605396524819265, 0.22097710393286807),
                new TriangulationPoint(4.155734591863926, -0.005995401654886656),
                new TriangulationPoint(5.2, -5.056587043684493),
                new TriangulationPoint(5.5636893451976075, -2.626864224033742),
                new TriangulationPoint(5.921103703845806, 1.2896281213828615),
                new TriangulationPoint(6.574253234860605, 0.2387531828939089),
                new TriangulationPoint(7.208680032849628, 4.31239280889068),
                new TriangulationPoint(1.7241235178541967, 1.3172268477814397),
                new TriangulationPoint(2.542909245259552, 1.7238476279768382),
                new TriangulationPoint(8.29046144070591, 1.0334476716972179),
                new TriangulationPoint(3.536559205519296, 3.706375613206241)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 10);
        }

        /// <summary>
        ///     Tests that a deep pit point cloud triangulates and reaches the basin right edge.
        /// </summary>
        [Fact]
        public void Triangulate_PitCloudRightEdge_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(6.296507832266627, -8.07131631582571),
                new TriangulationPoint(5.2733993862166075, -7.107374478440842),
                new TriangulationPoint(5.779822211004712, -4.15916566618975),
                new TriangulationPoint(6.3568255278546495, -5.268636826307529),
                new TriangulationPoint(6.8134198947406475, -4.787195564579672),
                new TriangulationPoint(7.123165006946384, -3.5714498853436716),
                new TriangulationPoint(6.496507832266627, -6.36523587830208),
                new TriangulationPoint(7.054967680133399, -3.467267264010827),
                new TriangulationPoint(7.440854170844357, -3.438225292528326),
                new TriangulationPoint(7.271604776043261, 2.749190695001367),
                new TriangulationPoint(1.2525675600639394, 2.6288249476947003),
                new TriangulationPoint(2.311327581438854, 2.774521648778823),
                new TriangulationPoint(2.809031681534383, 1.8267969278743477),
                new TriangulationPoint(5.225846310484152, 3.370066354223558)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 10);
        }

        /// <summary>
        ///     Tests that a large point cloud triangulates and reaches the basin interior step.
        /// </summary>
        [Fact]
        public void Triangulate_LargeCloudInteriorStep_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(1.3338636301149913, -0.9585475544252189),
                new TriangulationPoint(10.10130285802358, -1.818304946561486),
                new TriangulationPoint(0.2859656388340359, 5.5065241351288385),
                new TriangulationPoint(0.1042646249310415, 5.806417068376399),
                new TriangulationPoint(10.416219336640193, 1.2836363461258067),
                new TriangulationPoint(8.614862910292512, -2.2521851026696083),
                new TriangulationPoint(3.511646047472789, 5.672797429222985),
                new TriangulationPoint(1.2090251400177485, 4.599467910174033),
                new TriangulationPoint(4.607496102157746, 1.834729436708023),
                new TriangulationPoint(-0.3606821314248638, 4.8179290615105685),
                new TriangulationPoint(8.864386836935015, -2.5491506795162104),
                new TriangulationPoint(-0.6530596556389051, -3.437190079799476),
                new TriangulationPoint(10.367963462773693, 2.9048336646076445),
                new TriangulationPoint(7.837774861994095, 5.531806953964665),
                new TriangulationPoint(6.99697554856398, -0.5318169288951049),
                new TriangulationPoint(5.6708191533902745, -3.3336984605219673),
                new TriangulationPoint(3.4475104680506092, 1.0603691698333106),
                new TriangulationPoint(3.550614029425482, 0.5484484613633009),
                new TriangulationPoint(7.989636574401352, 5.9959476711209625),
                new TriangulationPoint(0.9989430466661897, -3.629641687325035),
                new TriangulationPoint(2.49078837199639, -2.6547940544107904),
                new TriangulationPoint(5.879197091273589, -6.691905705114783)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 15);
        }

        /// <summary>
        ///     Tests that a large point cloud triangulates and reaches the basin left edge orientation.
        /// </summary>
        [Fact]
        public void Triangulate_LargeCloudLeftOrientation_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(7.208167864572335, 5.405931156317671),
                new TriangulationPoint(2.776867706690388, 2.6321130667962658),
                new TriangulationPoint(5.412928939523608, 0.5285321145916972),
                new TriangulationPoint(-1.0311611541691987, -0.19129964438793223),
                new TriangulationPoint(-0.908078651366792, -2.751028730418081),
                new TriangulationPoint(2.319498892090981, 3.456704742022188),
                new TriangulationPoint(1.1824694933288122, -1.2118832209202846),
                new TriangulationPoint(9.651015356951866, 0.21772457622817054),
                new TriangulationPoint(11.377086532012134, 2.58022713408816),
                new TriangulationPoint(6.086193603503608, 5.805154612197146),
                new TriangulationPoint(1.8968127257641467, -3.1430004854421134),
                new TriangulationPoint(11.25932466297379, 0.9040949511826488),
                new TriangulationPoint(3.592459847029512, 3.037131151667392),
                new TriangulationPoint(1.8137906984490297, 0.5940056734690469),
                new TriangulationPoint(1.6390679532843961, 5.024394493095761),
                new TriangulationPoint(-1.06166018595065, 5.5439682800993175),
                new TriangulationPoint(11.756732328681617, 5.665162224166636),
                new TriangulationPoint(5.990683344188465, 5.23274058719759),
                new TriangulationPoint(9.184294399425525, 0.8708053221324477),
                new TriangulationPoint(9.204697088899415, -4.337342424940943),
                new TriangulationPoint(4.511059869318763, 3.600945165195011),
                new TriangulationPoint(3.596681627257113, 5.462090479425196),
                new TriangulationPoint(6.55724568225315, -2.040046949889533),
                new TriangulationPoint(2.413140914595286, 1.1796840169372427),
                new TriangulationPoint(-0.18232457255121548, 1.331711848886549),
                new TriangulationPoint(-0.7296377060607251, 4.534412268332398),
                new TriangulationPoint(-0.8820667531723467, 1.5351667294908156),
                new TriangulationPoint(7.918657746128114, 0.3779895218918057),
                new TriangulationPoint(11.984587717794156, 3.8491582469312284),
                new TriangulationPoint(2.121138601620281, 3.7873130151011587),
                new TriangulationPoint(1.222522901940403, 1.1672248482551542),
                new TriangulationPoint(5.177221152548316, -5.666743167055186),
            };

            int count = RunPointSet(points);

            Assert.True(count >= 20);
        }
    }
}
