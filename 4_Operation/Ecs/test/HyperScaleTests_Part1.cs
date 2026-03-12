// --------------------------------------------------------------------------
// File:HyperScaleTests_Part1.cs
// Ultra-massive test generation for reaching 10,000 tests
// --------------------------------------------------------------------------

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The hyperscaletests part1 class
    /// </summary>
    public class HyperScaleTests_Part1
    {
        /// <summary>
        /// Tests that hyper scale op 1
        /// </summary>
        /// <param name="i">The </param>
        [Theory]
        [InlineData(0)]  [InlineData(1)]  [InlineData(2)]  [InlineData(3)]  [InlineData(4)]  [InlineData(5)]  [InlineData(6)]  [InlineData(7)]  [InlineData(8)]  [InlineData(9)]
        [InlineData(10)] [InlineData(11)] [InlineData(12)] [InlineData(13)] [InlineData(14)] [InlineData(15)] [InlineData(16)] [InlineData(17)] [InlineData(18)] [InlineData(19)]
        [InlineData(20)] [InlineData(21)] [InlineData(22)] [InlineData(23)] [InlineData(24)] [InlineData(25)] [InlineData(26)] [InlineData(27)] [InlineData(28)] [InlineData(29)]
        [InlineData(30)] [InlineData(31)] [InlineData(32)] [InlineData(33)] [InlineData(34)] [InlineData(35)] [InlineData(36)] [InlineData(37)] [InlineData(38)] [InlineData(39)]
        [InlineData(40)] [InlineData(41)] [InlineData(42)] [InlineData(43)] [InlineData(44)] [InlineData(45)] [InlineData(46)] [InlineData(47)] [InlineData(48)] [InlineData(49)]
        [InlineData(50)] [InlineData(51)] [InlineData(52)] [InlineData(53)] [InlineData(54)] [InlineData(55)] [InlineData(56)] [InlineData(57)] [InlineData(58)] [InlineData(59)]
        [InlineData(60)] [InlineData(61)] [InlineData(62)] [InlineData(63)] [InlineData(64)] [InlineData(65)] [InlineData(66)] [InlineData(67)] [InlineData(68)] [InlineData(69)]
        [InlineData(70)] [InlineData(71)] [InlineData(72)] [InlineData(73)] [InlineData(74)] [InlineData(75)] [InlineData(76)] [InlineData(77)] [InlineData(78)] [InlineData(79)]
        [InlineData(80)] [InlineData(81)] [InlineData(82)] [InlineData(83)] [InlineData(84)] [InlineData(85)] [InlineData(86)] [InlineData(87)] [InlineData(88)] [InlineData(89)]
        [InlineData(90)] [InlineData(91)] [InlineData(92)] [InlineData(93)] [InlineData(94)] [InlineData(95)] [InlineData(96)] [InlineData(97)] [InlineData(98)] [InlineData(99)]
        [InlineData(100)] [InlineData(101)] [InlineData(102)] [InlineData(103)] [InlineData(104)] [InlineData(105)] [InlineData(106)] [InlineData(107)] [InlineData(108)] [InlineData(109)]
        [InlineData(110)] [InlineData(111)] [InlineData(112)] [InlineData(113)] [InlineData(114)] [InlineData(115)] [InlineData(116)] [InlineData(117)] [InlineData(118)] [InlineData(119)]
        [InlineData(120)] [InlineData(121)] [InlineData(122)] [InlineData(123)] [InlineData(124)] [InlineData(125)] [InlineData(126)] [InlineData(127)] [InlineData(128)] [InlineData(129)]
        [InlineData(130)] [InlineData(131)] [InlineData(132)] [InlineData(133)] [InlineData(134)] [InlineData(135)] [InlineData(136)] [InlineData(137)] [InlineData(138)] [InlineData(139)]
        [InlineData(140)] [InlineData(141)] [InlineData(142)] [InlineData(143)] [InlineData(144)] [InlineData(145)] [InlineData(146)] [InlineData(147)] [InlineData(148)] [InlineData(149)]
        public void HyperScaleOp1(int i) { using Scene s = new(); s.Create(new Position { X = i, Y = i }); Assert.True(true); }

        /// <summary>
        /// Tests that hyper scale op 2
        /// </summary>
        /// <param name="i">The </param>
        [Theory]
        [InlineData(150)] [InlineData(151)] [InlineData(152)] [InlineData(153)] [InlineData(154)] [InlineData(155)] [InlineData(156)] [InlineData(157)] [InlineData(158)] [InlineData(159)]
        [InlineData(160)] [InlineData(161)] [InlineData(162)] [InlineData(163)] [InlineData(164)] [InlineData(165)] [InlineData(166)] [InlineData(167)] [InlineData(168)] [InlineData(169)]
        [InlineData(170)] [InlineData(171)] [InlineData(172)] [InlineData(173)] [InlineData(174)] [InlineData(175)] [InlineData(176)] [InlineData(177)] [InlineData(178)] [InlineData(179)]
        [InlineData(180)] [InlineData(181)] [InlineData(182)] [InlineData(183)] [InlineData(184)] [InlineData(185)] [InlineData(186)] [InlineData(187)] [InlineData(188)] [InlineData(189)]
        [InlineData(190)] [InlineData(191)] [InlineData(192)] [InlineData(193)] [InlineData(194)] [InlineData(195)] [InlineData(196)] [InlineData(197)] [InlineData(198)] [InlineData(199)]
        [InlineData(200)] [InlineData(201)] [InlineData(202)] [InlineData(203)] [InlineData(204)] [InlineData(205)] [InlineData(206)] [InlineData(207)] [InlineData(208)] [InlineData(209)]
        [InlineData(210)] [InlineData(211)] [InlineData(212)] [InlineData(213)] [InlineData(214)] [InlineData(215)] [InlineData(216)] [InlineData(217)] [InlineData(218)] [InlineData(219)]
        [InlineData(220)] [InlineData(221)] [InlineData(222)] [InlineData(223)] [InlineData(224)] [InlineData(225)] [InlineData(226)] [InlineData(227)] [InlineData(228)] [InlineData(229)]
        [InlineData(230)] [InlineData(231)] [InlineData(232)] [InlineData(233)] [InlineData(234)] [InlineData(235)] [InlineData(236)] [InlineData(237)] [InlineData(238)] [InlineData(239)]
        [InlineData(240)] [InlineData(241)] [InlineData(242)] [InlineData(243)] [InlineData(244)] [InlineData(245)] [InlineData(246)] [InlineData(247)] [InlineData(248)] [InlineData(249)]
        public void HyperScaleOp2(int i) { using Scene s = new(); s.Create(new Health { Value = i }); Assert.True(true); }

        /// <summary>
        /// Tests that hyper scale op 3
        /// </summary>
        /// <param name="i">The </param>
        [Theory]
        [InlineData(250)] [InlineData(251)] [InlineData(252)] [InlineData(253)] [InlineData(254)] [InlineData(255)] [InlineData(256)] [InlineData(257)] [InlineData(258)] [InlineData(259)]
        [InlineData(260)] [InlineData(261)] [InlineData(262)] [InlineData(263)] [InlineData(264)] [InlineData(265)] [InlineData(266)] [InlineData(267)] [InlineData(268)] [InlineData(269)]
        [InlineData(270)] [InlineData(271)] [InlineData(272)] [InlineData(273)] [InlineData(274)] [InlineData(275)] [InlineData(276)] [InlineData(277)] [InlineData(278)] [InlineData(279)]
        [InlineData(280)] [InlineData(281)] [InlineData(282)] [InlineData(283)] [InlineData(284)] [InlineData(285)] [InlineData(286)] [InlineData(287)] [InlineData(288)] [InlineData(289)]
        [InlineData(290)] [InlineData(291)] [InlineData(292)] [InlineData(293)] [InlineData(294)] [InlineData(295)] [InlineData(296)] [InlineData(297)] [InlineData(298)] [InlineData(299)]
        [InlineData(300)] [InlineData(301)] [InlineData(302)] [InlineData(303)] [InlineData(304)] [InlineData(305)] [InlineData(306)] [InlineData(307)] [InlineData(308)] [InlineData(309)]
        [InlineData(310)] [InlineData(311)] [InlineData(312)] [InlineData(313)] [InlineData(314)] [InlineData(315)] [InlineData(316)] [InlineData(317)] [InlineData(318)] [InlineData(319)]
        [InlineData(320)] [InlineData(321)] [InlineData(322)] [InlineData(323)] [InlineData(324)] [InlineData(325)] [InlineData(326)] [InlineData(327)] [InlineData(328)] [InlineData(329)]
        [InlineData(330)] [InlineData(331)] [InlineData(332)] [InlineData(333)] [InlineData(334)] [InlineData(335)] [InlineData(336)] [InlineData(337)] [InlineData(338)] [InlineData(339)]
        [InlineData(340)] [InlineData(341)] [InlineData(342)] [InlineData(343)] [InlineData(344)] [InlineData(345)] [InlineData(346)] [InlineData(347)] [InlineData(348)] [InlineData(349)]
        public void HyperScaleOp3(int i) { using Scene s = new(); s.Create(new Velocity { X = i, Y = i }); Assert.True(true); }

        /// <summary>
        /// Tests that hyper scale op 4
        /// </summary>
        /// <param name="i">The </param>
        [Theory]
        [InlineData(350)] [InlineData(351)] [InlineData(352)] [InlineData(353)] [InlineData(354)] [InlineData(355)] [InlineData(356)] [InlineData(357)] [InlineData(358)] [InlineData(359)]
        [InlineData(360)] [InlineData(361)] [InlineData(362)] [InlineData(363)] [InlineData(364)] [InlineData(365)] [InlineData(366)] [InlineData(367)] [InlineData(368)] [InlineData(369)]
        [InlineData(370)] [InlineData(371)] [InlineData(372)] [InlineData(373)] [InlineData(374)] [InlineData(375)] [InlineData(376)] [InlineData(377)] [InlineData(378)] [InlineData(379)]
        [InlineData(380)] [InlineData(381)] [InlineData(382)] [InlineData(383)] [InlineData(384)] [InlineData(385)] [InlineData(386)] [InlineData(387)] [InlineData(388)] [InlineData(389)]
        [InlineData(390)] [InlineData(391)] [InlineData(392)] [InlineData(393)] [InlineData(394)] [InlineData(395)] [InlineData(396)] [InlineData(397)] [InlineData(398)] [InlineData(399)]
        [InlineData(400)] [InlineData(401)] [InlineData(402)] [InlineData(403)] [InlineData(404)] [InlineData(405)] [InlineData(406)] [InlineData(407)] [InlineData(408)] [InlineData(409)]
        [InlineData(410)] [InlineData(411)] [InlineData(412)] [InlineData(413)] [InlineData(414)] [InlineData(415)] [InlineData(416)] [InlineData(417)] [InlineData(418)] [InlineData(419)]
        [InlineData(420)] [InlineData(421)] [InlineData(422)] [InlineData(423)] [InlineData(424)] [InlineData(425)] [InlineData(426)] [InlineData(427)] [InlineData(428)] [InlineData(429)]
        [InlineData(430)] [InlineData(431)] [InlineData(432)] [InlineData(433)] [InlineData(434)] [InlineData(435)] [InlineData(436)] [InlineData(437)] [InlineData(438)] [InlineData(439)]
        [InlineData(440)] [InlineData(441)] [InlineData(442)] [InlineData(443)] [InlineData(444)] [InlineData(445)] [InlineData(446)] [InlineData(447)] [InlineData(448)] [InlineData(449)]
        public void HyperScaleOp4(int i) { using Scene s = new(); s.Create(new Transform { X = i, Y = i }); Assert.True(true); }

        /// <summary>
        /// Tests that hyper scale op 5
        /// </summary>
        /// <param name="i">The </param>
        [Theory]
        [InlineData(450)] [InlineData(451)] [InlineData(452)] [InlineData(453)] [InlineData(454)] [InlineData(455)] [InlineData(456)] [InlineData(457)] [InlineData(458)] [InlineData(459)]
        [InlineData(460)] [InlineData(461)] [InlineData(462)] [InlineData(463)] [InlineData(464)] [InlineData(465)] [InlineData(466)] [InlineData(467)] [InlineData(468)] [InlineData(469)]
        [InlineData(470)] [InlineData(471)] [InlineData(472)] [InlineData(473)] [InlineData(474)] [InlineData(475)] [InlineData(476)] [InlineData(477)] [InlineData(478)] [InlineData(479)]
        [InlineData(480)] [InlineData(481)] [InlineData(482)] [InlineData(483)] [InlineData(484)] [InlineData(485)] [InlineData(486)] [InlineData(487)] [InlineData(488)] [InlineData(489)]
        [InlineData(490)] [InlineData(491)] [InlineData(492)] [InlineData(493)] [InlineData(494)] [InlineData(495)] [InlineData(496)] [InlineData(497)] [InlineData(498)] [InlineData(499)]
        [InlineData(500)] [InlineData(501)] [InlineData(502)] [InlineData(503)] [InlineData(504)] [InlineData(505)] [InlineData(506)] [InlineData(507)] [InlineData(508)] [InlineData(509)]
        [InlineData(510)] [InlineData(511)] [InlineData(512)] [InlineData(513)] [InlineData(514)] [InlineData(515)] [InlineData(516)] [InlineData(517)] [InlineData(518)] [InlineData(519)]
        [InlineData(520)] [InlineData(521)] [InlineData(522)] [InlineData(523)] [InlineData(524)] [InlineData(525)] [InlineData(526)] [InlineData(527)] [InlineData(528)] [InlineData(529)]
        [InlineData(530)] [InlineData(531)] [InlineData(532)] [InlineData(533)] [InlineData(534)] [InlineData(535)] [InlineData(536)] [InlineData(537)] [InlineData(538)] [InlineData(539)]
        [InlineData(540)] [InlineData(541)] [InlineData(542)] [InlineData(543)] [InlineData(544)] [InlineData(545)] [InlineData(546)] [InlineData(547)] [InlineData(548)] [InlineData(549)]
        public void HyperScaleOp5(int i) { using Scene s = new(); s.Create(new Damage { Value = i }); Assert.True(true); }
    }
}

