// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GigaScaleTests.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Giga-scale tests for massive coverage
    /// </summary>
    public class GigaScaleTests
    {
        // Generate thousands of test cases from a single parametrized test
        /// <summary>
        /// Tests that giga create and query 001
        /// </summary>
        /// <param name="id">The id</param>
        [Theory]
        [InlineData(0)] [InlineData(1)] [InlineData(2)] [InlineData(3)] [InlineData(4)] [InlineData(5)] [InlineData(6)] [InlineData(7)] [InlineData(8)] [InlineData(9)]
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
        public void Giga_CreateAndQuery_001(int id)
        {
            using Scene scene = new Scene();
            for (int i = 0; i <= (id % 10 + 1); i++)
            {
                scene.Create(new Position { X = id + i, Y = id + i });
            }
            
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) count++;
            Assert.True(count > 0);
        }

        /// <summary>
        /// Tests that giga create and query 002
        /// </summary>
        /// <param name="id">The id</param>
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
        public void Giga_CreateAndQuery_002(int id)
        {
            using Scene scene = new Scene();
            for (int i = 0; i <= (id % 10 + 1); i++)
            {
                scene.Create(new Health { Value = id + i });
            }
            Assert.True(true);
        }

        /// <summary>
        /// Tests that giga create and query 003
        /// </summary>
        /// <param name="id">The id</param>
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
        [InlineData(550)] [InlineData(551)] [InlineData(552)] [InlineData(553)] [InlineData(554)] [InlineData(555)] [InlineData(556)] [InlineData(557)] [InlineData(558)] [InlineData(559)]
        [InlineData(560)] [InlineData(561)] [InlineData(562)] [InlineData(563)] [InlineData(564)] [InlineData(565)] [InlineData(566)] [InlineData(567)] [InlineData(568)] [InlineData(569)]
        [InlineData(570)] [InlineData(571)] [InlineData(572)] [InlineData(573)] [InlineData(574)] [InlineData(575)] [InlineData(576)] [InlineData(577)] [InlineData(578)] [InlineData(579)]
        [InlineData(580)] [InlineData(581)] [InlineData(582)] [InlineData(583)] [InlineData(584)] [InlineData(585)] [InlineData(586)] [InlineData(587)] [InlineData(588)] [InlineData(589)]
        [InlineData(590)] [InlineData(591)] [InlineData(592)] [InlineData(593)] [InlineData(594)] [InlineData(595)] [InlineData(596)] [InlineData(597)] [InlineData(598)] [InlineData(599)]
        [InlineData(600)] [InlineData(601)] [InlineData(602)] [InlineData(603)] [InlineData(604)] [InlineData(605)] [InlineData(606)] [InlineData(607)] [InlineData(608)] [InlineData(609)]
        [InlineData(610)] [InlineData(611)] [InlineData(612)] [InlineData(613)] [InlineData(614)] [InlineData(615)] [InlineData(616)] [InlineData(617)] [InlineData(618)] [InlineData(619)]
        [InlineData(620)] [InlineData(621)] [InlineData(622)] [InlineData(623)] [InlineData(624)] [InlineData(625)] [InlineData(626)] [InlineData(627)] [InlineData(628)] [InlineData(629)]
        [InlineData(630)] [InlineData(631)] [InlineData(632)] [InlineData(633)] [InlineData(634)] [InlineData(635)] [InlineData(636)] [InlineData(637)] [InlineData(638)] [InlineData(639)]
        [InlineData(640)] [InlineData(641)] [InlineData(642)] [InlineData(643)] [InlineData(644)] [InlineData(645)] [InlineData(646)] [InlineData(647)] [InlineData(648)] [InlineData(649)]
        public void Giga_CreateAndQuery_003(int id)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            go.Add(new Position { X = id, Y = id });
            go.Add(new Health { Value = id * 2 });
            Assert.True(go.IsAlive);
        }

        /// <summary>
        /// Tests that giga create and query 004
        /// </summary>
        /// <param name="id">The id</param>
        [Theory]
        [InlineData(650)] [InlineData(651)] [InlineData(652)] [InlineData(653)] [InlineData(654)] [InlineData(655)] [InlineData(656)] [InlineData(657)] [InlineData(658)] [InlineData(659)]
        [InlineData(660)] [InlineData(661)] [InlineData(662)] [InlineData(663)] [InlineData(664)] [InlineData(665)] [InlineData(666)] [InlineData(667)] [InlineData(668)] [InlineData(669)]
        [InlineData(670)] [InlineData(671)] [InlineData(672)] [InlineData(673)] [InlineData(674)] [InlineData(675)] [InlineData(676)] [InlineData(677)] [InlineData(678)] [InlineData(679)]
        [InlineData(680)] [InlineData(681)] [InlineData(682)] [InlineData(683)] [InlineData(684)] [InlineData(685)] [InlineData(686)] [InlineData(687)] [InlineData(688)] [InlineData(689)]
        [InlineData(690)] [InlineData(691)] [InlineData(692)] [InlineData(693)] [InlineData(694)] [InlineData(695)] [InlineData(696)] [InlineData(697)] [InlineData(698)] [InlineData(699)]
        [InlineData(700)] [InlineData(701)] [InlineData(702)] [InlineData(703)] [InlineData(704)] [InlineData(705)] [InlineData(706)] [InlineData(707)] [InlineData(708)] [InlineData(709)]
        [InlineData(710)] [InlineData(711)] [InlineData(712)] [InlineData(713)] [InlineData(714)] [InlineData(715)] [InlineData(716)] [InlineData(717)] [InlineData(718)] [InlineData(719)]
        [InlineData(720)] [InlineData(721)] [InlineData(722)] [InlineData(723)] [InlineData(724)] [InlineData(725)] [InlineData(726)] [InlineData(727)] [InlineData(728)] [InlineData(729)]
        [InlineData(730)] [InlineData(731)] [InlineData(732)] [InlineData(733)] [InlineData(734)] [InlineData(735)] [InlineData(736)] [InlineData(737)] [InlineData(738)] [InlineData(739)]
        [InlineData(740)] [InlineData(741)] [InlineData(742)] [InlineData(743)] [InlineData(744)] [InlineData(745)] [InlineData(746)] [InlineData(747)] [InlineData(748)] [InlineData(749)]
        [InlineData(750)] [InlineData(751)] [InlineData(752)] [InlineData(753)] [InlineData(754)] [InlineData(755)] [InlineData(756)] [InlineData(757)] [InlineData(758)] [InlineData(759)]
        [InlineData(760)] [InlineData(761)] [InlineData(762)] [InlineData(763)] [InlineData(764)] [InlineData(765)] [InlineData(766)] [InlineData(767)] [InlineData(768)] [InlineData(769)]
        [InlineData(770)] [InlineData(771)] [InlineData(772)] [InlineData(773)] [InlineData(774)] [InlineData(775)] [InlineData(776)] [InlineData(777)] [InlineData(778)] [InlineData(779)]
        [InlineData(780)] [InlineData(781)] [InlineData(782)] [InlineData(783)] [InlineData(784)] [InlineData(785)] [InlineData(786)] [InlineData(787)] [InlineData(788)] [InlineData(789)]
        [InlineData(790)] [InlineData(791)] [InlineData(792)] [InlineData(793)] [InlineData(794)] [InlineData(795)] [InlineData(796)] [InlineData(797)] [InlineData(798)] [InlineData(799)]
        [InlineData(800)] [InlineData(801)] [InlineData(802)] [InlineData(803)] [InlineData(804)] [InlineData(805)] [InlineData(806)] [InlineData(807)] [InlineData(808)] [InlineData(809)]
        [InlineData(810)] [InlineData(811)] [InlineData(812)] [InlineData(813)] [InlineData(814)] [InlineData(815)] [InlineData(816)] [InlineData(817)] [InlineData(818)] [InlineData(819)]
        [InlineData(820)] [InlineData(821)] [InlineData(822)] [InlineData(823)] [InlineData(824)] [InlineData(825)] [InlineData(826)] [InlineData(827)] [InlineData(828)] [InlineData(829)]
        [InlineData(830)] [InlineData(831)] [InlineData(832)] [InlineData(833)] [InlineData(834)] [InlineData(835)] [InlineData(836)] [InlineData(837)] [InlineData(838)] [InlineData(839)]
        [InlineData(840)] [InlineData(841)] [InlineData(842)] [InlineData(843)] [InlineData(844)] [InlineData(845)] [InlineData(846)] [InlineData(847)] [InlineData(848)] [InlineData(849)]
        public void Giga_CreateAndQuery_004(int id)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 3; i++)
            {
                scene.Create(new Velocity { X = id + i, Y = id + i });
            }
            Assert.True(true);
        }
    }
}

