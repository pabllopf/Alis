# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


## [v0.1.9] - 2023-10-02
### :bug: Bug Fixes
- [`6dce735`](https://github.com/pabllopf/Alis/commit/6dce73589d39c674ee4ec83acc30eafec5628a2c) - the main audio module with native backend *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.8] - 2023-10-02
### :sparkles: New Features
- [`d7ba807`](https://github.com/pabllopf/Alis/commit/d7ba807112d788c4119cab6ee2cfae9231848f5f) - fix all repository and the workflows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4aa5585`](https://github.com/pabllopf/Alis/commit/4aa55857142e40d213ad481ba0538f48c9cc4d81) - refactor the main publish workflow *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`d7bf530`](https://github.com/pabllopf/Alis/commit/d7bf5301900fd0563d4202b85a7bb86d9f274599) - the version to publish *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.7]
### :sparkles: New Features
- [`47437e2`](https://github.com/pabllopf/Alis/commit/47437e23dcfbed35cc7fec47a587bf03356b7878) - new network module with cross-platform code and native full on c# *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f3b4ca3`](https://github.com/pabllopf/Alis/commit/f3b4ca3f1d2396597efa3dc11548db95cd1043f6) - add new defaults builders for main components of Alis *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ea550df`](https://github.com/pabllopf/Alis/commit/ea550df9509abf305e772f36c6fdcd4a5ddb4e71) - add id for settings of Alis *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`a07668d`](https://github.com/pabllopf/Alis/commit/a07668d7fe6853b9ce2e1fb6882cae95e96fc0a0) - delete static reference on GraphicManager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`05d81f0`](https://github.com/pabllopf/Alis/commit/05d81f01ae877683a4767f0e1d097b62950212cc) - delete static reference on singleton on SceneManager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`bf6edc5`](https://github.com/pabllopf/Alis/commit/bf6edc57e5e4907ba3151c8ffd8cadf159dc0ebd) - create new method for setview on GraphicManager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b73f2aa`](https://github.com/pabllopf/Alis/commit/b73f2aa6397d59f3c84d1ba62a6fa9174552c93f) - delete all module network because is only for windows. And start to creating a cross-platform network. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`382ba19`](https://github.com/pabllopf/Alis/commit/382ba1936aafc7968217a58e4c9aa8d77397ddc5) - add static program on samples of alis *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d50e485`](https://github.com/pabllopf/Alis/commit/d50e485ae14de99c29467eb2acf9804c54bf5f73) - delete comments of Fixture *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`bff4998`](https://github.com/pabllopf/Alis/commit/bff4998c9c46782795905bcb27301c813cb0a246) - delete comments of RayCastHelper *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a46d8f0`](https://github.com/pabllopf/Alis/commit/a46d8f0428afff8c6914410448587859ce6b5434) - add new type MaskKeyLengthException *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`713ba41`](https://github.com/pabllopf/Alis/commit/713ba4138875a4ed96bd4ad7c45753ed46477832) - extract Identification struct and IdentificationMarshalData struct *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`94360ee`](https://github.com/pabllopf/Alis/commit/94360eee6422be50658c103bc4874471f8235c18) - Remove the field 'localCenterB' and declare it as a local variable in the relevant methods. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d748ea6`](https://github.com/pabllopf/Alis/commit/d748ea6d30bd8e23e6345bff7cfb879e5c15d70c) - default build for  IBuild<RigidBody> *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a3743d5`](https://github.com/pabllopf/Alis/commit/a3743d5a6b247356c357a8f7eab7aa772b8e8f93) - Remove the member initializer, all constructors set an initial value for the member of SplashScreen class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4339f8e`](https://github.com/pabllopf/Alis/commit/4339f8e91d39a94a2e505ea61d01d7961c820af9) - Remove the field 'videoMode' and declare it as a local variable in the relevant methods on videogame class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2812248`](https://github.com/pabllopf/Alis/commit/281224879d83f288acc21e27fa8f56edad3b7e2c) - implement default methods of TimeManager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`710d2ba`](https://github.com/pabllopf/Alis/commit/710d2ba2c0393042d2c28986f8af3168fd8b5084) - Use 'string.IsNullOrEmpty()' instead of comparing to empty string on AudioClipBase *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e7e0ccd`](https://github.com/pabllopf/Alis/commit/e7e0ccd0f004fffa2648649f996aecbc4647dec8) - Use 'string.IsNullOrEmpty()' instead of comparing to empty string on AudioClipBase *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a78747d`](https://github.com/pabllopf/Alis/commit/a78747d22b93f94cc073151615f350dfb3369fa8) - delete deprecated code sfRenderTexture_create *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2aea21c`](https://github.com/pabllopf/Alis/commit/2aea21ced72626ba408275e18457b0e32c31dab8) - delete using that dont use *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a19dfcf`](https://github.com/pabllopf/Alis/commit/a19dfcf415eb532e2bf8d139a0acad488514b4cd) - Refactor this method to reduce its Cognitive Complexity from 16 to the 15 allowed. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f0c6913`](https://github.com/pabllopf/Alis/commit/f0c6913309918d7065e7447b4c3123f64470be4f) - Refactor this method to reduce its Cognitive Complexity from 17 to the 15 allowed. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7f30297`](https://github.com/pabllopf/Alis/commit/7f30297d6a7b78fa4f1eb2aff9f13aed434042fa) - Refactor this method to reduce its Cognitive Complexity from 36 to the 15 allowed. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a93fa01`](https://github.com/pabllopf/Alis/commit/a93fa019c5ea8f819c4544d468c486acd6b2039b) - Refactor this method to reduce its Cognitive Complexity from 21 to the 15 allowed. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c5c638d`](https://github.com/pabllopf/Alis/commit/c5c638d2aeed8dfcc869cb24f5551493be3d4dff) - Refactor this method to reduce its Cognitive Complexity from 24 to the 15 allowed of DTSweep *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`66e2e1a`](https://github.com/pabllopf/Alis/commit/66e2e1ad8dc6d684624c9fe85c577a2805235885) - Refactor this method to reduce its Cognitive Complexity from 69 to the 15 allowed of TextureConverter *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`996fff7`](https://github.com/pabllopf/Alis/commit/996fff729691e462b8b904ab43feedacd20b5531) - Refactor this method to reduce its Cognitive Complexity from 20 to the 15 allowed of SimplifyTools *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6d6dbbe`](https://github.com/pabllopf/Alis/commit/6d6dbbe42df6e4563b12618b14ad085495e1216e) - Refactor this method to reduce its Cognitive Complexity from 30 to the 15 allowed of SimpleCombiner *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3ecb9d8`](https://github.com/pabllopf/Alis/commit/3ecb9d853094efdcf6eeb41dcfcb7d06738b5bd6) - Refactor this method to reduce its Cognitive Complexity from SimpleCombiner 57 to the 15 allowed of *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f93f75b`](https://github.com/pabllopf/Alis/commit/f93f75b18f2fe75bbf5644820c97089e96ea966d) - Refactor this method to reduce its Cognitive Complexity from 20 to the 15 allowed of DTSweep *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`20354d2`](https://github.com/pabllopf/Alis/commit/20354d26a0107eb6b597a43cf8316c0abd587e65) - Remove this unread private field '_pingPongManager' or refactor the code to use its value. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5138fb3`](https://github.com/pabllopf/Alis/commit/5138fb3db97eb09b24ff55f0cff1eba8c8bf7db0) - remove _pingTask *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`af6c320`](https://github.com/pabllopf/Alis/commit/af6c3200edb473951d54fa515f7f82fdc85d8d31) - Refactor this method to reduce its Cognitive Complexity from DynamicTree 16 to the 15 allowed of *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`163a482`](https://github.com/pabllopf/Alis/commit/163a48219f6a3e56a45cd0d8494c87dd8fc6fb2d) - Refactor this method to reduce its Cognitive Complexity from 24 to the 15 allowed of DynamicTree *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6a92f12`](https://github.com/pabllopf/Alis/commit/6a92f12bf328ad6c968d6842c7131167325b87b4) - Refactor this method to reduce its Cognitive Complexity from 16 to the 15 allowed of  DynamicTree *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`289f51d`](https://github.com/pabllopf/Alis/commit/289f51d360a7059df5f8158b5d733c39b535cca5) - Refactor this method to reduce its Cognitive Complexity from 36 to the 15 allowed of PolygonShape *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cb91d69`](https://github.com/pabllopf/Alis/commit/cb91d696bf468d7604783430ad58499f9cad0211) - Either remove this useless object instantiation of class 'PingPongManager' or use it. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9a7c6ef`](https://github.com/pabllopf/Alis/commit/9a7c6efd47b3dc8cf2eddcfaa7334f01a619782e) - Refactor this method to reduce its Cognitive Complexity from 16 to the 15 allowed of DistanceGJK *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b77ca4c`](https://github.com/pabllopf/Alis/commit/b77ca4ca25f17e3942b5162140cd5e8b0ffc2106) - Refactor this method to reduce its Cognitive Complexity from 33 to the 15 allowed of ChainHull *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b059f58`](https://github.com/pabllopf/Alis/commit/b059f5820f963fb3411306acca98c75a62bf1b70) - Refactor this method to reduce its Cognitive Complexity from 16 to the 15 allowed of Vertices *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`22f5ff5`](https://github.com/pabllopf/Alis/commit/22f5ff59affc65544e73791e1e6d7c74ccc02993) - Refactor this method to reduce its Cognitive Complexity from 16 to the 15 allowed of Curve *(commit by [@pabllopf](https://github.com/pabllopf))*

### :memo: Documentation Changes
- [`cc4bb30`](https://github.com/pabllopf/Alis/commit/cc4bb302d9f737cf5e1905451eaf3fa285ff5a84) - add default samples for modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`579ebf2`](https://github.com/pabllopf/Alis/commit/579ebf2ac555aa6b2d1713075de885f998a12523) - delete some comments of ContactManager *(commit by [@pabllopf](https://github.com/pabllopf))*

### :art: Code Style Changes
- [`1eb8b1d`](https://github.com/pabllopf/Alis/commit/1eb8b1d1e05f5190ccc1bef3b5d3e07cb28cb098) - delete Test_To_Load_A_Shader_From_Assembly_Resources test *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d20def4`](https://github.com/pabllopf/Alis/commit/d20def4e547cdba61cd23042f26d06c7cfbe8951) - refactor the main class line to reduce Complexity *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`936ed78`](https://github.com/pabllopf/Alis/commit/936ed78100cd6c521471f36205b9c5fd21572275) - reduce Complexity of Triangulate *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`434bc66`](https://github.com/pabllopf/Alis/commit/434bc669f24fce17c1fd9551852bebac1ef1142c) - refactor Triangulator *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`655891e`](https://github.com/pabllopf/Alis/commit/655891e4999ea2563b45a69c066742edd7fa08fc) - reduce size of BoundingBox *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d7605f9`](https://github.com/pabllopf/Alis/commit/d7605f9f943021825d67f4656205b0d525a4d462) - refactor names of vars on PulleyJoint class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`83364d2`](https://github.com/pabllopf/Alis/commit/83364d224c8318c031ceb3ff44c441c07b47a16e) - new Identification condtructor *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6d0dfb9`](https://github.com/pabllopf/Alis/commit/6d0dfb91870412e9783b08f9a2c4d1b4a8caa46c) - reduce complexity FrictionJoint *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fe93237`](https://github.com/pabllopf/Alis/commit/fe93237a97c3b76e2f053fa69874b89d742d5350) - delete key "this" from sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ec10d61`](https://github.com/pabllopf/Alis/commit/ec10d610ebfee55ff347f0feb40ea835166100e2) - extract body test class of benchmarks *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5ea4252`](https://github.com/pabllopf/Alis/commit/5ea425286d21814eaae4590ac19d94b28f02fd29) - add default AudioManager methods *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`91c9222`](https://github.com/pabllopf/Alis/commit/91c922244a9eb93e96f74f6c7000304739a57572) - delete useless button class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7b85f74`](https://github.com/pabllopf/Alis/commit/7b85f74f6ad34aa212bd13e4cabfe0b749a0ff3c) - change the name EarClip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5a57e19`](https://github.com/pabllopf/Alis/commit/5a57e19b753690c6c005709ec10ff7d3dac46343) - EarClipDecomposer names *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`986927d`](https://github.com/pabllopf/Alis/commit/986927d3b7f75a490d0ede2503d6db9754cc6c4f) - DTSweep conventions names *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`040b215`](https://github.com/pabllopf/Alis/commit/040b215aa1b9fa498629aa4b5ecff77e3da36e7e) - name conventions of vars SimplifyTools *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8e58e94`](https://github.com/pabllopf/Alis/commit/8e58e9464e2131a77ca2327aae6b2683b1a4dcd5) - refactor SimpleCombiner with name conventions *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0cb9b09`](https://github.com/pabllopf/Alis/commit/0cb9b09966bf72cc3a66ef572bdad02d83ac9b25) - name vars of DistanceGJK *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0cad471`](https://github.com/pabllopf/Alis/commit/0cad47149336317201dd28c5ba92c5877e7d5495) - refactor names of ChainHull *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`64259b7`](https://github.com/pabllopf/Alis/commit/64259b7171918d896bf0c1fc8014953b52e042de) - refactor names of Vertices *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dffe188`](https://github.com/pabllopf/Alis/commit/dffe1888a9e9b7ec1e9a141ca819fe49627ed69e) - refactor names of Curve *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.6] - 2023-09-13
### :art: Code Style Changes
- [`14fd971`](https://github.com/pabllopf/Alis/commit/14fd9716aa0884e5c48fe00138f1761ad20a7037) - delete .personal folder and delete temp files *(commit by @pabllopf)*

## [v0.1.5] - 2023-09-12
### :sparkles: New Features
- [`54ebf53`](https://github.com/pabllopf/Alis/commit/54ebf534cc42cbbab19967e01419a7306b62e4c3) - include a new default demo to render colors, and test if run the game with only one line "VideoGame.Builder().Run();" *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`13b63c9`](https://github.com/pabllopf/Alis/commit/13b63c964bc57dc56c1390d72012cafaecc213c7) - delete zip compress LZMA *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`94df1c4`](https://github.com/pabllopf/Alis/commit/94df1c4e35c439dc7fbd7e0263d34ef8219d4478) - windows systems *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3958a96`](https://github.com/pabllopf/Alis/commit/3958a9602f2795e494418cacad2c23913bbbba97) - compile to windows and linux platforms. And include on windows the openal lib *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.4] - 2023-09-11
### :sparkles: New Features
- [`df4a9e5`](https://github.com/pabllopf/Alis/commit/df4a9e58d984e7c6df52389e5d94c25c792ac895) - new config to optimice the release libs *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`158487e`](https://github.com/pabllopf/Alis/commit/158487e52d3b0459f6a4e0aba16c6c1f4e4f179d) - new type of compress dlls *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b9d3273`](https://github.com/pabllopf/Alis/commit/b9d3273c6601c4d66c2565fcd7a9de4ba7c33d09) - compress all dlls of all platforms 8%. The big dll is 1.8mb *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.3] - 2023-09-10
### :sparkles: New Features
- [`b94beca`](https://github.com/pabllopf/Alis/commit/b94beca23cf79289719bcc6b94845cdf8fdeae44) - compress on zip native dlls *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2e58475`](https://github.com/pabllopf/Alis/commit/2e5847537b4e9f601ee2b70d11c18cea80c7436d) - can compress on .zip all native dlls *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`16e96f7`](https://github.com/pabllopf/Alis/commit/16e96f75833b6739dea0e12887c243a1c975118f) - compress all dlls natives of graphic to less than 1mb *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2f09b09`](https://github.com/pabllopf/Alis/commit/2f09b0950b25e45d6cbe373011dd77c0d21a8b29) - redue size of dlls of native audio than less 1mb *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`4eedcc2`](https://github.com/pabllopf/Alis/commit/4eedcc2c123e97a9a157c01324069ec21e83aae9) - the main loop with simple game *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`18182b3`](https://github.com/pabllopf/Alis/commit/18182b382a0c11a57b56825c7227a51493fb92dc) - default samples of alis games *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`348818d`](https://github.com/pabllopf/Alis/commit/348818d1c72a3aecd26f98a7f13b5e1f5990d43e) - win-x64 zip files *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`873bdb1`](https://github.com/pabllopf/Alis/commit/873bdb14acff7e2a065bd9bae75f254dd7e0c8e7) - win-x86 zip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5f6ba7e`](https://github.com/pabllopf/Alis/commit/5f6ba7e5848e21e9ae91dd1d08a754cf86342ed6) - win-arm zip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`14a2470`](https://github.com/pabllopf/Alis/commit/14a2470985b6be1bbbf58cd69f97a92c05f16d0b) - win-arm64 zip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7fd165e`](https://github.com/pabllopf/Alis/commit/7fd165ea123d0ea1a1e8f2e750b506e2d9f5ed73) - osx-x64 zip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c609c46`](https://github.com/pabllopf/Alis/commit/c609c467b5107d1a774e7296b95141074af4bd15) - linux-x64 zip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0219f03`](https://github.com/pabllopf/Alis/commit/0219f03884fe789a8e45e353ba11de60308de9b5) - linux-x86 zip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3cf384c`](https://github.com/pabllopf/Alis/commit/3cf384c30906c15ec9318998293ec348526c52b3) - linux-arm zip *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2d5a36f`](https://github.com/pabllopf/Alis/commit/2d5a36f344a9c810dc148e7d2e1c9fe49e6229c4) - linux arm64 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8592bfb`](https://github.com/pabllopf/Alis/commit/8592bfb1cbdb2646a18de6c73f0cd45a82ba8a45) - physic error when open clean project *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.2] - 2023-09-10
### :sparkles: New Features
- [`f63fd4c`](https://github.com/pabllopf/Alis/commit/f63fd4cccc2245e79ec6c0080fad9c4f8d6286c8) - compile depend of platform to reduce size *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ec89d65`](https://github.com/pabllopf/Alis/commit/ec89d658b6320aab1a56b9d3f15ef29a83c8b220) - include new configurations to compile tiny modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1bfc60b`](https://github.com/pabllopf/Alis/commit/1bfc60b42084e436161b2a3eeb148714417302c6) - tiny windows compilation 1MB Alis. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b4030ce`](https://github.com/pabllopf/Alis/commit/b4030ce00ae39ff6d35bfb5c78382d6d13a0926b) - windows arm 64 bits configuration *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e12c670`](https://github.com/pabllopf/Alis/commit/e12c670b9805c4834e7fa0d0c2450cce8d4610c7) - add new win arm64 platform. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5170720`](https://github.com/pabllopf/Alis/commit/51707205254b21d97be9d76ad6fdbe7e7a10fc81) - update namespace of engine module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0f27aaf`](https://github.com/pabllopf/Alis/commit/0f27aaf9b236e0805dbbaca264fe62f928d545a2) - auto pack with diferents platforms *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`439b507`](https://github.com/pabllopf/Alis/commit/439b507a1dcd67e529790123780c3013469ffe36) - add new custom build for linux x64 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`79eca3c`](https://github.com/pabllopf/Alis/commit/79eca3c1d439e65a6addecd86b7cc34c9563bb1c) - add custom build for linux x86 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`654fc26`](https://github.com/pabllopf/Alis/commit/654fc2616bbb2d08c25890d493955efaf9e8f417) - add custom build for linux arm64 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4fca5e2`](https://github.com/pabllopf/Alis/commit/4fca5e236b5f9d03656d28ecad69c9ed870fb54c) - add new custom build for linux arm *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`811ecf7`](https://github.com/pabllopf/Alis/commit/811ecf7831a5a9701cc9e6110dbc5349b2041af7) - add win x86 platform *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1a0b902`](https://github.com/pabllopf/Alis/commit/1a0b90270909c65a9ab1c7135178c4aaad4e6468) - add new platform win arm *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`8923729`](https://github.com/pabllopf/Alis/commit/8923729ecebe04ebe53b42b36baf980a94dff22e) - namespace of engine *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`451ae90`](https://github.com/pabllopf/Alis/commit/451ae90a88e6048d8f22a1cc0cf63b849d4c1877) - windows platform optimization for x64 bits *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0328fb8`](https://github.com/pabllopf/Alis/commit/0328fb86e542820e4eec40c44211ba0d02f736cb) - the engine module with new bakend with opengl and sdl2 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4d4d914`](https://github.com/pabllopf/Alis/commit/4d4d914291e51c3d363143169f5f72a6ecc55a1d) - the dlls audio of sdl2 on engine *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`04b4d76`](https://github.com/pabllopf/Alis/commit/04b4d7664dad1b57469988e8a933694b4de40b4b) - reduce the size of dlls *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`eeb7ad4`](https://github.com/pabllopf/Alis/commit/eeb7ad409c217e431899b81674874931d701718a) - windows x64 build *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0694e4c`](https://github.com/pabllopf/Alis/commit/0694e4cca73704fad32628c17ab4e5a35938ff1a) - dlls of windows arm 64 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`45631a4`](https://github.com/pabllopf/Alis/commit/45631a451d7b87a0a1dc52e011c8d73d85df3db3) - the sfml controller *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`44b8a6c`](https://github.com/pabllopf/Alis/commit/44b8a6c19ce265d7049a9e60b22df0e11b3a7df6) - 3 issues of public to change internal class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7dada55`](https://github.com/pabllopf/Alis/commit/7dada5579edce443edc4bebba3a6b1b9278ab3e3) - add dll system to audio module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`26c40a4`](https://github.com/pabllopf/Alis/commit/26c40a440dd2a235eaf5c6558dcfe3e57ad94f9d) - audio module to include sfml backend *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`adc0b1e`](https://github.com/pabllopf/Alis/commit/adc0b1e606051e8c2e8135470e07d0f1fbe85275) - the osx x64 bilding of engine, audio and graphic modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c7d0c11`](https://github.com/pabllopf/Alis/commit/c7d0c11aef37affeaa2d2a5cb05d36594edc2880) - native engine platform osx-arm64 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5bcd1d3`](https://github.com/pabllopf/Alis/commit/5bcd1d36c6c8470608c7f429a8662e081b35ee49) - windows platforms *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1e50177`](https://github.com/pabllopf/Alis/commit/1e50177d1a9d8b01b4df5c46ee38b6b14c4f99ba) - add build all platforms *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.1] - 2023-08-29
### :sparkles: New Features
- [`25ede11`](https://github.com/pabllopf/Alis/commit/25ede11dbd5ecb2d63743e45b72ef91a4d209efb) - include native aot to compile c code *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5d78486`](https://github.com/pabllopf/Alis/commit/5d78486f595a83f2357d184dc2e1f2832279acd8) - add new menus for engine *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`55ab483`](https://github.com/pabllopf/Alis/commit/55ab48330ababaa3d04be5581ade0c5a38e09c99) - 0 dependencies with nugets *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`41837f3`](https://github.com/pabllopf/Alis/commit/41837f3c48b61d65c485c6378aae7f0cf1d550ea) - add all comments to sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e1b4a39`](https://github.com/pabllopf/Alis/commit/e1b4a39e5a87e2c89b4d510173a44f399a49952d) - names of sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0b5399c`](https://github.com/pabllopf/Alis/commit/0b5399c443e565eb9f835d82548f746df3391cd3) - linux .so files to arm64 systems *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6ad8c61`](https://github.com/pabllopf/Alis/commit/6ad8c61693777e3f05cd40ef033e5025a6935764) - delete unsafe keyword of class and change name of imguizmo *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`04145d9`](https://github.com/pabllopf/Alis/commit/04145d9772d789653db43cdb357f78495097c79b) - implicit conversions *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6e32cb4`](https://github.com/pabllopf/Alis/commit/6e32cb404ba64fb502f0fc6005f8413d7d3db3d0) - private dlls *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c2aa23b`](https://github.com/pabllopf/Alis/commit/c2aa23bfee11b1a3c77c88936a6f69f5e1a51d21) - the infinite loop of gamebase *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5902c65`](https://github.com/pabllopf/Alis/commit/5902c6575c0e224f096efa02af10f2b9c30014ff) - names and refactor sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`db354a7`](https://github.com/pabllopf/Alis/commit/db354a78adbcf64f0ed04a72e2cfa893594605c7) - change namespace from Imgui to UI *(commit by [@pabllopf](https://github.com/pabllopf))*

### :art: Code Style Changes
- [`4d44bbd`](https://github.com/pabllopf/Alis/commit/4d44bbdc03c62da2e2c6114371e3d96fb61321cb) - change name of imnodes *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8c78621`](https://github.com/pabllopf/Alis/commit/8c78621c5112b34afc77c6e4c4681e5c280e8f38) - change names of implot *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7e85ac0`](https://github.com/pabllopf/Alis/commit/7e85ac075b08642bff5bb8dfe067e13e36dc268f) - change names of main class of implot *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`69d2317`](https://github.com/pabllopf/Alis/commit/69d2317733527f3200aceaacbebe7a35affe98f3) - refactor implot file to change names *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.1.0] - 2023-08-14
### :sparkles: New Features
- [`f62f07e`](https://github.com/pabllopf/Alis/commit/f62f07e5e32011999133283aa0e8d2716aafb83a) - generate automatic binding for csfml *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`60fb38b`](https://github.com/pabllopf/Alis/commit/60fb38b2befb585cf8eeef459a191d809c1c0f57) - add binding sdl2 *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`c7b47e4`](https://github.com/pabllopf/Alis/commit/c7b47e4dbceed68bc164e73ccae7d800362f969f) - delete all csproj of csfml binding *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.0.9] - 2023-08-13
### :sparkles: New Features
- [`15058b5`](https://github.com/pabllopf/Alis/commit/15058b586800c84472c5ebb0009d06f0dac0be08) - plugin manager and iplugin to control plugins *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1b0f850`](https://github.com/pabllopf/Alis/commit/1b0f850c9f3fae8a147e43059a914c68fb8b3eea) - new plugin module and a simple sample. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1994426`](https://github.com/pabllopf/Alis/commit/19944262ad7241e743a77582bc8ff12484a9a0eb) - the Cloud, ADS and ECS(entity component system) modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b03743a`](https://github.com/pabllopf/Alis/commit/b03743ae77e93cae73999254e5d4b4f07b5c459d) - do compatible with .netstandard 2.0 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8dccfd0`](https://github.com/pabllopf/Alis/commit/8dccfd0209a0ba167cd21ebb1f2c8ee58992abf4) - add null checker on security module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cd0e7a7`](https://github.com/pabllopf/Alis/commit/cd0e7a76e0fe86d1a63bc06d8edb94f1e9c34046) - new proxy config *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fbe189b`](https://github.com/pabllopf/Alis/commit/fbe189b4832552e8a80b77d3c98b099959b77285) - new attributes to check not null, not empty and not zero. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4cfac7e`](https://github.com/pabllopf/Alis/commit/4cfac7e921c1f8ba93a098624fb7ced86406a907) - new utf8 manager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`963cefd`](https://github.com/pabllopf/Alis/commit/963cefdf4dfe95c554dbd6c4ae1df42ee58a7de4) - add demo to web *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7479d79`](https://github.com/pabllopf/Alis/commit/7479d79d3b789f6baa7588cbcfe64a7d50626fe0) - add the engine to web format *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`314bc68`](https://github.com/pabllopf/Alis/commit/314bc68b03a6af26063f7f41bb789daa62e41c21) - integrate vulkan, opengl, metal and directx backends *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes
- [`d79057b`](https://github.com/pabllopf/Alis/commit/d79057b0b73be842705fdcaf53b62bc8bcb58380) - move all extern code to custom class of SdlTtf *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ff20713`](https://github.com/pabllopf/Alis/commit/ff20713249188be98525b53881b66ecb8836d53e) - the dlls extractor *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b808e9d`](https://github.com/pabllopf/Alis/commit/b808e9dbc4f26524f44e74c0cf3d1c8712d1f1ee) - the buf with the buffers and LayoutKind.Sequential *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3f51d96`](https://github.com/pabllopf/Alis/commit/3f51d9682dbcf5b549677dd5fa4a80db3f9c8f41) - random security level issue *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`61ce295`](https://github.com/pabllopf/Alis/commit/61ce295936470d30db906099303c6db15436f7c5) - gethashcode of matrices *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4dd5da4`](https://github.com/pabllopf/Alis/commit/4dd5da43177e4d1494089210f1bb90acd183ab18) - gethashcode of vector3f *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dbc1936`](https://github.com/pabllopf/Alis/commit/dbc1936bf029b04dba73a64ad81465eb76cc168a) - to internal ImGuiNative *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`062665e`](https://github.com/pabllopf/Alis/commit/062665e369b09a2a180a7c88468f19fda087dcf8) - 3 bugs with private and readonly class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`404db67`](https://github.com/pabllopf/Alis/commit/404db67b424d0b4d2a6706fe5aa4b2895f087d21) - resources of core and alis module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9bf7db8`](https://github.com/pabllopf/Alis/commit/9bf7db84c452f5c46eb0668daabb38022751215c) - the default value of methods *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d06880e`](https://github.com/pabllopf/Alis/commit/d06880eab3a6b8ee62cc89d3aa34db2608499f6c) - logger sln format and create new log levels *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`44698af`](https://github.com/pabllopf/Alis/commit/44698af2d33f59832201987a5b6810ba20f8c54c) - some critical issues of logger *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2b0b2a8`](https://github.com/pabllopf/Alis/commit/2b0b2a81a72feffacc36293aaca2a1cee2bfbca4) - readonly values *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3d8b81e`](https://github.com/pabllopf/Alis/commit/3d8b81e8b881e231705c6e4b233256e32f8474f3) - Obsolete code *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7a124a0`](https://github.com/pabllopf/Alis/commit/7a124a04b921826f8f2a98f91b9ca468f1980590) - check and refactor names and comments of sdl structs *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a7ad1b2`](https://github.com/pabllopf/Alis/commit/a7ad1b28e703654314da1dbf8e597c9bb89c8926) - names and format sdl code of graphic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`77580cc`](https://github.com/pabllopf/Alis/commit/77580cce0561a411f6a8758e45fb375d321c8a79) - the engine start method *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`afb01f2`](https://github.com/pabllopf/Alis/commit/afb01f29c643b2e4ad908014b339e940cf3d6463) - Refactor this method to reduce its Cognitive Complexity from 19 to the 15 allowed. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a547854`](https://github.com/pabllopf/Alis/commit/a547854e4d8cb4b16f25d98d2d17dfcea204d2ea) - Refactor this constructor to reduce its Cognitive Complexity from 18 to the 15 allowed. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c810bb4`](https://github.com/pabllopf/Alis/commit/c810bb4275ca12c1dedc3263e3ac7700d7bb8fde) - flag name of imgui module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8e2eecf`](https://github.com/pabllopf/Alis/commit/8e2eecfdf13719c1a78d9cc6b250c61137166499) - some methods of extern ttf module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c707092`](https://github.com/pabllopf/Alis/commit/c7070929c009115d9c1e22c8a8abf3a782a9c7e0) - format folder of sdl *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4141153`](https://github.com/pabllopf/Alis/commit/41411535b13c42827da38799a482108cc0704cdd) - enums names *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f0acc23`](https://github.com/pabllopf/Alis/commit/f0acc23986bb707bb3a59ec7b161363151f6aeaf) - NotNull attribute *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f2db666`](https://github.com/pabllopf/Alis/commit/f2db6660f827129498108872df78f73963e7b330) - 'TTF_ByteSwappedUNICODE' less trivial. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dfb7c1c`](https://github.com/pabllopf/Alis/commit/dfb7c1cf213b1fd6bfe6a9b6c0df1642a77dc094) - the wrapper of sdl ttf *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`31ab0c1`](https://github.com/pabllopf/Alis/commit/31ab0c172b68d1e6a012d72eea6363c9e8f075e4) - all sdl ttf *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`092d751`](https://github.com/pabllopf/Alis/commit/092d7511b8c530112c6edbbf326b0c7bae6796c4) - the sdl image *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1a7cc79`](https://github.com/pabllopf/Alis/commit/1a7cc79f3c07143f356cefe38962c073d5b73eb0) - the name *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f0cb2e2`](https://github.com/pabllopf/Alis/commit/f0cb2e24ade0c79009c4d6cce75715961c9bb407) - one line sdl image class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`51020ac`](https://github.com/pabllopf/Alis/commit/51020ac2fe88374d5105367c4d85f2c3f3536242) - sdl main class names and delegates *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`803acd9`](https://github.com/pabllopf/Alis/commit/803acd9b005240e005758c97fd21ff0f8af0314a) - names and sdl vars *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`92dd1b1`](https://github.com/pabllopf/Alis/commit/92dd1b18ba446f9b9958cf05cf6af672703bf69d) - move out struct on music class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`819b1b0`](https://github.com/pabllopf/Alis/commit/819b1b08264c820d96326d7770f3b76925043ed3) - names of sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`471ad17`](https://github.com/pabllopf/Alis/commit/471ad17afa85b41439844c6911b28c6f0af6c27a) - the validator of all entities *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`edf5242`](https://github.com/pabllopf/Alis/commit/edf52428ac95c0f0bda49d6e4103479c54465966) - name entry point *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b6c85ac`](https://github.com/pabllopf/Alis/commit/b6c85acccb6239c2668e3b638a9ec5de89366b7e) - names of SdlPixelType *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6cd01e8`](https://github.com/pabllopf/Alis/commit/6cd01e8af56eb5033fa1798f54f146b31e4c5e8e) - names of PackedOrder *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7cbf05b`](https://github.com/pabllopf/Alis/commit/7cbf05b1078e8b9e5de2a057088676a83c3fc9ad) - PixelType name *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1bb5179`](https://github.com/pabllopf/Alis/commit/1bb5179d0212048684f4a1239767d71e0ac05ca8) - names of PackedLayout *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`de94bc9`](https://github.com/pabllopf/Alis/commit/de94bc966b69dbb40637d97ab0219365a4437efc) - names of sdl *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a44ecbd`](https://github.com/pabllopf/Alis/commit/a44ecbd6e8a042f3ab203c5f77fcce438fa4b3ec) - sdl new changes *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7d53177`](https://github.com/pabllopf/Alis/commit/7d531778208068b0a796a2b1c45b681896165045) - name attributes of sdl class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1b009d8`](https://github.com/pabllopf/Alis/commit/1b009d8a9a0b2e0f289dfdb7b4ad44dcf923f8d4) - sdl warper *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dee9927`](https://github.com/pabllopf/Alis/commit/dee992734b781c48b5c164347e2e2125d3d1475d) - sdl names of init method *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5b34414`](https://github.com/pabllopf/Alis/commit/5b344143dee4fab03f2094b6e913290ec97e085f) - add new wrapers and names corrections *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`aa7c0da`](https://github.com/pabllopf/Alis/commit/aa7c0da5c3680176f1a839a8622e0cd7b851a5d1) - sdl names *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`87a8a5d`](https://github.com/pabllopf/Alis/commit/87a8a5d87c9bf8b4e2f33c7c79772fa4970abcc4) - correct 30 names *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`72292a4`](https://github.com/pabllopf/Alis/commit/72292a42b64024c92a478823beb56cc109c31885) - 40 names of sdl *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b63cae0`](https://github.com/pabllopf/Alis/commit/b63cae0c9abbb4a33a6b3e61a3dac382e90de54b) - 100 names of sdl *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`45cfbe4`](https://github.com/pabllopf/Alis/commit/45cfbe4dcc3dc8fecc44ba1fe16db5ee1a99b4cf) - 100 names of sdl *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5fe1e77`](https://github.com/pabllopf/Alis/commit/5fe1e77171844ed0407cc75aad36a05e8daade74) - sdl 79 change names *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d682724`](https://github.com/pabllopf/Alis/commit/d6827248c41a1174d4fb050ef6828366a2592165) - all imgui *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cfa30ea`](https://github.com/pabllopf/Alis/commit/cfa30ea291a8a840566bc4d5a4638a5d23c3ff53) - alis engine web with new main *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f85adb3`](https://github.com/pabllopf/Alis/commit/f85adb32c0d6f9eec4bd4259ae0210668f4f8d10) - web imgui *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`60d7339`](https://github.com/pabllopf/Alis/commit/60d7339de0c31fa288b2716c317b017abf92b2bc) - net version *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cb9a0f7`](https://github.com/pabllopf/Alis/commit/cb9a0f764d86d29dc74400fba7904c6e44d80fc0) - the imgui loader *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`31cd1f1`](https://github.com/pabllopf/Alis/commit/31cd1f16294466cffecb573587c59215395b5195) - build folder *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f816c33`](https://github.com/pabllopf/Alis/commit/f816c33bb7a9515884a76714ceda6f6a27c7c923) - the main js *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d826bfd`](https://github.com/pabllopf/Alis/commit/d826bfd0c46ab4860aca7b437f81a596d9d0ba70) - font *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3fc6f57`](https://github.com/pabllopf/Alis/commit/3fc6f5763002963a06ea5c3bc9c11b84381b20a8) - add new imgui plot, grizmo and nodes extras *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3868813`](https://github.com/pabllopf/Alis/commit/386881315fb6196dbc4e00b06ba749719cb71c78) - warning as errors and new class of engine *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c98a954`](https://github.com/pabllopf/Alis/commit/c98a9542617d7a4e5ac99042f786bcb9134f1b04) - veldrid config *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ae086b9`](https://github.com/pabllopf/Alis/commit/ae086b94acc69f94699be425384b8450eb0633ef) - osx dlls of sdl2 sfmal and cimgui *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cc9a349`](https://github.com/pabllopf/Alis/commit/cc9a34934d09e83da53e0c77c218d30646d3cd99) - windows loader *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`64fed43`](https://github.com/pabllopf/Alis/commit/64fed43bbc05678277be6395ad42df84116b0523) - config file *(commit by [@pabllopf](https://github.com/pabllopf))*

### :memo: Documentation Changes
- [`e84d559`](https://github.com/pabllopf/Alis/commit/e84d559631891320f2ef0901109384ba6d438c42) - update the main xmls folder format *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`918f8fb`](https://github.com/pabllopf/Alis/commit/918f8fbe9541291f3cecc01e21f128c03bd4d3fa) - add new comments to imgui extras *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ae5987f`](https://github.com/pabllopf/Alis/commit/ae5987fbaa29ec723a9e7c0cf7bfa7490a6e61a8) - create new samples of opengl opengles vulkan dx11 and metal *(commit by [@pabllopf](https://github.com/pabllopf))*

### :art: Code Style Changes
- [`7e35ed6`](https://github.com/pabllopf/Alis/commit/7e35ed66afe3c40f7d58461a6722f3262df51e3b) - delete comment and regions zones *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1527856`](https://github.com/pabllopf/Alis/commit/15278564af142df690270a99d55987af6d890b3a) - refactor and clean the sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1fa2387`](https://github.com/pabllopf/Alis/commit/1fa2387a3322d83686ef76d360569cebe5fbeb88) - clean and refactor sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1875628`](https://github.com/pabllopf/Alis/commit/1875628308789392d27a1b1b9d959cc8237f0e23) - change name of vector and matrix to include Type float *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9e688f3`](https://github.com/pabllopf/Alis/commit/9e688f3617792089fed376a5b7028a23a3cee5f1) - change name of matrix with new format *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a5fdc1f`](https://github.com/pabllopf/Alis/commit/a5fdc1f571734d4675e0f1716ef9ce523da36947) - refactor style of math module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`db48bd8`](https://github.com/pabllopf/Alis/commit/db48bd8f2386e657e038f339e6c84d0fac7bba9c) - big refactor of opengl module, extract the enums and delegates and change names format. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d8b4e92`](https://github.com/pabllopf/Alis/commit/d8b4e9262afd61938f4e710e057c8f4cd300b5ad) - delete useless class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e106dc3`](https://github.com/pabllopf/Alis/commit/e106dc3571c3bcf94fb79bd18bd24e6f1c8ca1ff) - organize the imgui folder *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`580b27f`](https://github.com/pabllopf/Alis/commit/580b27f89e88ae68d15ee689672cb24a98dd10ca) - refactor sln to include a new namespace *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`02959f3`](https://github.com/pabllopf/Alis/commit/02959f36e6874280b3eb39f75b274079741cd795) - refactor the ImDrawList *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a6ef227`](https://github.com/pabllopf/Alis/commit/a6ef227172923f8da585aadd436b9b2cffc54895) - wrapper sdl ttf *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`66ab6c9`](https://github.com/pabllopf/Alis/commit/66ab6c98986ad1f12a571e546d9ea7b5907a538c) - refactor namespaces to do more simple *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.0.8] - 2023-06-09

### :sparkles: New Features

- [`f69c4b4`](https://github.com/pabllopf/Alis/commit/f69c4b45cf1929cbf9c03aa59b4a7d47e5d22e12) - add the gravity config
  to physic settings of the videogame *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`37beb39`](https://github.com/pabllopf/Alis/commit/37beb39c229796ef555c7f729b30452b73a5e1a4) - add the angulr
  velocity to the boxcollider *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`793b734`](https://github.com/pabllopf/Alis/commit/793b734e2aab2c3c8ade8e7671aa0760a0f45e8d) - create new directory
  to engine Alis.App.Engine *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fbe66a7`](https://github.com/pabllopf/Alis/commit/fbe66a7bdd696a004845a481cc0de2ab5341ee59) - add native sdl2, imgui
  and opengl *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`247fad2`](https://github.com/pabllopf/Alis/commit/247fad2f031316e86870304ed5ffc6deffc56237) - add support with sdl2
  and opengl *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`98685a2`](https://github.com/pabllopf/Alis/commit/98685a27ce3117374d0f5fa77aea6833da8332dc) - add new sln file to
  templates of alis *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6114c95`](https://github.com/pabllopf/Alis/commit/6114c95e86f3b78b845ac1473682fbd98c343def) - add new sln to
  alis.templates *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6dbc2f8`](https://github.com/pabllopf/Alis/commit/6dbc2f801b6338abb100ec09c274291b5e21d8db) - new module Ia and new
  module profiling *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5b8b791`](https://github.com/pabllopf/Alis/commit/5b8b791a17cd5ff016c5fe99f82ea778236e48da) - add sdl audio backend
  to audio module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`55e68ab`](https://github.com/pabllopf/Alis/commit/55e68ab54b3df3eb708eb0ac8aea6004a60b6e3a) - refactor sdl main
  class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fdd681b`](https://github.com/pabllopf/Alis/commit/fdd681bc7cd5221d43f8f15646053e32263bcec0) - add new 2 controller
  of windows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8a5f623`](https://github.com/pabllopf/Alis/commit/8a5f623c0c17171136c7d7a3da470dce7be8a6c1) - new module "Scripting"
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b10e3b8`](https://github.com/pabllopf/Alis/commit/b10e3b81ce0ca1a54d863bb1bdf3e9d7f7ab0ad5) - delete all unsafe code
  to do more security of sdl module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`bb4991f`](https://github.com/pabllopf/Alis/commit/bb4991f3b7d474c4206e8888cabbee5b4f3c1e97) - create store and
  translation modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5dd931f`](https://github.com/pabllopf/Alis/commit/5dd931f41cdcf0366e337d750ccc5f985028296d) - new module "store" to
  include the system pay. *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes

- [`44df77f`](https://github.com/pabllopf/Alis/commit/44df77fa94854aab373bf83a8346269b9c9515b8) - resources of api
  graphic *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`31c6e36`](https://github.com/pabllopf/Alis/commit/31c6e369e3fcf1e7dbfa0e82a7ad99fb5730a58e) - the unsafe block of
  code *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6080680`](https://github.com/pabllopf/Alis/commit/60806801f94709f629f3b1a44378171ac636725f) - delete dependencie
  with unsafe code *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ac73804`](https://github.com/pabllopf/Alis/commit/ac738040b969d75608dc0420dd0cda4c007182b0) - restore the sln and
  update the assets folder of engine. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8239997`](https://github.com/pabllopf/Alis/commit/8239997cd367fd1b143e8aadcf167948372d1424) - imgui module and gen
  code *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`409c7a5`](https://github.com/pabllopf/Alis/commit/409c7a56e9a3f1a40b9fec43c6f04108eb6113b6) - refactor the resources
  folder to equals on input graphic and audio modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`aa85caa`](https://github.com/pabllopf/Alis/commit/aa85caa6b8db0ca6dab9f8f7771b6bedaa26d4b3) - the resources files *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`0e403fa`](https://github.com/pabllopf/Alis/commit/0e403fa6c025f70b43a7805eb6746829d6ca5a42) - sdl sintax of the main
  solution *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1542166`](https://github.com/pabllopf/Alis/commit/1542166c01d32fdb6b1225af32080d18955fd67e) - the dir access on
  windows machines *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d7dd99c`](https://github.com/pabllopf/Alis/commit/d7dd99c160f808ebec29400b13f56514a5fd3890) - Unvalidated local
  pointer arithmetic *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`96915bd`](https://github.com/pabllopf/Alis/commit/96915bdac406013346c77cc4d88f9b949cb9c71f) - Unvalidated local
  pointer arithmetic *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6556c13`](https://github.com/pabllopf/Alis/commit/6556c13bd5cfb0c7ff47e7cd6523b06e95a2112b) - the last memory
  Unvalidated local pointer arithmetic *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`48d978e`](https://github.com/pabllopf/Alis/commit/48d978ea45510794ba73588cb4998f46c48b16cb) - the ramdon generator
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9dbc58e`](https://github.com/pabllopf/Alis/commit/9dbc58e9b284de36c09f1821759b6937ca4162c7) - Make sure that using
  this pseudorandom number generator is safe here *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e35987b`](https://github.com/pabllopf/Alis/commit/e35987b7dbe5366fdd317d7ecc3f00021c5ffc02) - Remove this unread
  private field '_seed' or refactor the code to use its value. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8e8833a`](https://github.com/pabllopf/Alis/commit/8e8833a8e8e77d41b4c6f5865f5e87a2f4de1dbe) - Use the 'value'
  parameter in this property set accessor declaration *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`91f4d71`](https://github.com/pabllopf/Alis/commit/91f4d716fe8ce1833ec400f9b062d8a06db66701) - Make sure this weak
  hash algorithm is not used in a sensitive context here. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`43ad053`](https://github.com/pabllopf/Alis/commit/43ad0538398dc98a4e7642eff6f55c6603486d6a) - the sdl audio *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`6b0c449`](https://github.com/pabllopf/Alis/commit/6b0c4497b937a2c120f2bcddafcacae11778bf8b) - the input system of
  alis *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`539d624`](https://github.com/pabllopf/Alis/commit/539d6249ae8e4ee9a0a21bf1764ff7f37ff0e0f8) - sdl error with vars *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`e2ad49c`](https://github.com/pabllopf/Alis/commit/e2ad49c0a8c9e5e571175728496253a846f207f7) - separate the calls of
  OpenGL and context code. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1682f83`](https://github.com/pabllopf/Alis/commit/1682f83008ea32b1dab06e360aa1edeac006b79f) - the main sln names *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`44ec8d9`](https://github.com/pabllopf/Alis/commit/44ec8d9dad7a088cb24be550d3ab38cc857a2af0) - 'preb' is null on at
  least one execution path. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`efff881`](https://github.com/pabllopf/Alis/commit/efff88152cad37427fd3ebdf761bd03421482d01) - Add a nested comment
  explaining why this method is empty, throw a 'NotSupportedException' or complete the implementation. *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`97b7787`](https://github.com/pabllopf/Alis/commit/97b77870550200eb1015d5fe8ea982883bfee474) - Dispose 'tcpClient'
  when it is no longer needed. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ed62613`](https://github.com/pabllopf/Alis/commit/ed62613632a30eb5c7b4c6e3857797423dfb3b16) - Refactor Vector2F '
  GetHashCode' to not reference mutable fields. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d1a04d6`](https://github.com/pabllopf/Alis/commit/d1a04d6c22a315b9e06e8b958c76d32d32140fe2) - Vector3F Refactor '
  GetHashCode' to not reference mutable fields *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2258072`](https://github.com/pabllopf/Alis/commit/225807205b8d1419e86a0076cf9ed0bad4c5df2a) - Matrix4X4F Refactor '
  GetHashCode' to not reference mutable fields. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0cc58e6`](https://github.com/pabllopf/Alis/commit/0cc58e67d23c25d4db03807d5a83e9bfc6ac0707) - RectangleF Refactor '
  GetHashCode' to not reference mutable fields *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4bbf783`](https://github.com/pabllopf/Alis/commit/4bbf783e6e885b21eef792cc89fbc2678445bc25) - reduce size of the Sdl
  file *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`41ac71c`](https://github.com/pabllopf/Alis/commit/41ac71c7f52aca8c3e870546d8c00c9b63addae5) - the main sdl class *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`b7a6b8c`](https://github.com/pabllopf/Alis/commit/b7a6b8c112f2956663a798969537344432f6e591) - delete all unsafe code
  of audio module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`159c75f`](https://github.com/pabllopf/Alis/commit/159c75f33832d030ead462467061aba41d8baf90) - resolve some unsafe
  code to to safe *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fb6c6b0`](https://github.com/pabllopf/Alis/commit/fb6c6b08b57143d7c58bf18a019b3d0ada3c1e9f) - delete some unsafe
  code of graphic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`73d8319`](https://github.com/pabllopf/Alis/commit/73d8319801f651cf1972acc704be51055d275914) - the encoding text *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`035d853`](https://github.com/pabllopf/Alis/commit/035d85301df7a0302432cffa025c024b3ac184b5) - delete all unsafe code
  of sfml module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`377002b`](https://github.com/pabllopf/Alis/commit/377002b6663851ef0936de5ff0a7711f6d4ce9f1) - abstract the input
  system *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b63a640`](https://github.com/pabllopf/Alis/commit/b63a640bd058c88f9fe4627422cf1c6684f7d260) - the sdl unsafe code *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`2b8caf2`](https://github.com/pabllopf/Alis/commit/2b8caf2309bf4013572c89b9786819c5dd4549e8) - the event unsafe code
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7b92206`](https://github.com/pabllopf/Alis/commit/7b92206bfab0bfdeb0b6150d95c8d56700a9352a) - delete unsafe code
  SdlHapticCondition *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`31f7a96`](https://github.com/pabllopf/Alis/commit/31f7a96b0f7b706d0bd433255821d18d0bc46715) - allow SizeConst of
  arrays *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ad75acf`](https://github.com/pabllopf/Alis/commit/ad75acf78e49f2b70290c43dafb943edd88f1a87) - delete all unsafe code
  of byte[] *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9ddaf77`](https://github.com/pabllopf/Alis/commit/9ddaf77ef1ac5727f410778fa97efc1661d5bfb9) - the sdl unsafe code of
  events *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1bb469e`](https://github.com/pabllopf/Alis/commit/1bb469e2c0ccde37c99aebfadfdcfc4424508b32) - byte[] unsafe code to
  do with intptr *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d056781`](https://github.com/pabllopf/Alis/commit/d056781c3f9e8206428b9d850f2ad461d08ce0fb) - the SdlSensorEvent *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`e1f9e9a`](https://github.com/pabllopf/Alis/commit/e1f9e9a4f2ac46d647fc7c02a6cb026a55d7915a) - SdlRendererInfo *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`d8da437`](https://github.com/pabllopf/Alis/commit/d8da437acefdc5d48ad7dc7c5aa22acde3458668) - delete unsafe code of
  opengl module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4dcc5fe`](https://github.com/pabllopf/Alis/commit/4dcc5fe09762c0f102eaf62d6d7cea57120180f1) - the engine with imgui
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6260ad6`](https://github.com/pabllopf/Alis/commit/6260ad6e144be16f7a2f47f2485e11c752ecf55b) - delete unsafe code of
  ImDrawCmd *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3b7fb5b`](https://github.com/pabllopf/Alis/commit/3b7fb5b83a400a8efa94e0849dc8f1cbe3c3f0a0) - the byte sdl input
  event *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`abeb900`](https://github.com/pabllopf/Alis/commit/abeb9003ad68504b40a54035c6a743a7b363fbec) - padding byte converter
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0cfa609`](https://github.com/pabllopf/Alis/commit/0cfa609eee00bc00d48a2425537188d42ed55c0e) - quite unsafe code of
  rendered sdl imgui *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`bc6899d`](https://github.com/pabllopf/Alis/commit/bc6899d38d7b72894dbb2511f7d90addfd8024b7) - the imgui unsafe code
  to compile *(commit by [@pabllopf](https://github.com/pabllopf))*

### :white_check_mark: Tests

- [`dc2dfb3`](https://github.com/pabllopf/Alis/commit/dc2dfb3256d0a4954509428581ed06fc6a2b2a4a) - new 4 test to world
  class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`19f22be`](https://github.com/pabllopf/Alis/commit/19f22be324817d1bb23148b6db1bf60347dd2827) - 4 new test for world
  class to checj add and remove of joints *(commit by [@pabllopf](https://github.com/pabllopf))*

### :construction_worker: Build System

- [`72a843c`](https://github.com/pabllopf/Alis/commit/72a843cb7838c9fe2c05a45fca2f2301808b28ee) - **deps**: bump
  SkiaSharp.NativeAssets.Linux from 2.88.1 to 2.88.3 *(commit
  by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`bb4f4ba`](https://github.com/pabllopf/Alis/commit/bb4f4ba2972cbef28d1cf0a4d65c34bd14365e5d) - **deps**: bump
  SkiaSharp.Views.Maui.Controls.Compatibility *(commit by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`541b120`](https://github.com/pabllopf/Alis/commit/541b120d80f806dd7e959d3d2a1f95d6b4bdd664) - **deps**: bump
  Microsoft.AspNetCore.Components.WebAssembly *(commit by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`8302a07`](https://github.com/pabllopf/Alis/commit/8302a071df5fe2ec82d94c4d196067fc98900cb2) - **deps**: bump
  Microsoft.AspNetCore.Components.WebAssembly.DevServer *(commit
  by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`283764c`](https://github.com/pabllopf/Alis/commit/283764c4a5e361802f0e63d72d68f34b985ea38c) - **deps**: bump
  SkiaSharp.Views.Maui.Controls from 2.88.1 to 2.88.3 *(commit
  by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`220af10`](https://github.com/pabllopf/Alis/commit/220af1064ace0b7d52ba2aa3ede709953a80540a) - **deps**: bump
  actions/dependency-review-action from 2 to 3 *(commit by [@dependabot[bot]](https://github.com/apps/dependabot))*

### :art: Code Style Changes

- [`d4537d9`](https://github.com/pabllopf/Alis/commit/d4537d9d794261ab4ce1ec2d80ec7099161b778f) - update the sln with
  new scripts and configs *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4ec3d77`](https://github.com/pabllopf/Alis/commit/4ec3d7757dc06355dd177341eb18d9f31ff69198) - refactor all class and
  structs of imgui to do more clean code. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e6db497`](https://github.com/pabllopf/Alis/commit/e6db497c8afa9002d510a43b50a373ea312c2d0b) - refactor to do more
  clean code the sln files *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b451740`](https://github.com/pabllopf/Alis/commit/b45174028fc7139a0a6711e49bcac83aad49cace) - move sln templates to
  folder templates *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`28c4dc2`](https://github.com/pabllopf/Alis/commit/28c4dc24b7764fb00c70d1dab4c94aa35216a50e) - extract class of
  sdl_mixer *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0699bd6`](https://github.com/pabllopf/Alis/commit/0699bd61f44e38b343e975fead1d69dfecdd816a) - Use the 'value'
  parameter in this property set accessor declaration *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cc3ec2c`](https://github.com/pabllopf/Alis/commit/cc3ec2c1dd5ab975a6230e44c2bed81e64af9df9) - refactor names of sln
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5d87492`](https://github.com/pabllopf/Alis/commit/5d87492d3911c696aec53e3dcb1d8d2def31ce34) - refactor the main sln
  files *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`69294cf`](https://github.com/pabllopf/Alis/commit/69294cff7f8ea162c6d78af772bf197a8a06eca6) - delete all bugs of
  Graph *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0163c08`](https://github.com/pabllopf/Alis/commit/0163c08331e5bdcb94012d3465a57062f6cc6299) - refactor the main sdl2
  file *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1b813a8`](https://github.com/pabllopf/Alis/commit/1b813a8b1ee9c67a0e417721d15a7744413975af) - moce delegates to
  files *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`107dc2f`](https://github.com/pabllopf/Alis/commit/107dc2f2c5ddf9e163c3759f25ad7ebd4787f682) - reset sln with new
  modules *(commit by [@pabllopf](https://github.com/pabllopf))*

### :flying_saucer: Other Changes

- [`6e10cf0`](https://github.com/pabllopf/Alis/commit/6e10cf08e530d4f94c5853dd76e18ec035fba8bc) - delete the class
  consolegame and soundgame *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fe931d1`](https://github.com/pabllopf/Alis/commit/fe931d1a66c543ce4eb7330d95e81e664b13c1af) - delete matrix2x2f of
  physic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`de37ae2`](https://github.com/pabllopf/Alis/commit/de37ae23b19bb974fd68a8ca90a5eaf0ba95995b) - reduce langversion to
  8 *(commit by [@pabllopf](https://github.com/pabllopf))*

## [v0.0.7] - 2023-04-30

### :sparkles: New Features

- [`c3086e5`](https://github.com/pabllopf/Alis/commit/c3086e5e962c5c594ad6c692144972b65f40b7cb) - create a custom math
  entities. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`69f28a1`](https://github.com/pabllopf/Alis/commit/69f28a1b901aa5e905cb095b391ec0eb81249251) - add new entities of
  math *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`288bcc1`](https://github.com/pabllopf/Alis/commit/288bcc159986305985309b876e2f3892ebddc37f) - add new matrix and
  vector namespace of math module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b300666`](https://github.com/pabllopf/Alis/commit/b3006660933ce6890434697f9a004af192d51028) - new input system based
  on sdl2 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f571eb1`](https://github.com/pabllopf/Alis/commit/f571eb16eac5d66d13e3c3cad1f40c083712f8d4) - add buttons controller
  for input manager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`76d2dc1`](https://github.com/pabllopf/Alis/commit/76d2dc1286ce9eb21343ff5b851594fe20eb9ba3) - include sdl2 dlls on
  compilation *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fed11dd`](https://github.com/pabllopf/Alis/commit/fed11dd4fdd5d3511b4aa23952cde42a02614a55) - new sample of game "
  7colors" of cards *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4e8a2b5`](https://github.com/pabllopf/Alis/commit/4e8a2b5c5327498b09e56e6db830d78e75450159) - add the universe that
  contains worlds on physics module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ba78c06`](https://github.com/pabllopf/Alis/commit/ba78c0684dbc21d9a0d3f02be9f7fabd9f50f22d) - create a workflow to
  update changelog *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2a605cd`](https://github.com/pabllopf/Alis/commit/2a605cda7a6d86d901c96853ab38920fbb0972ea) - update all scripts
  with the same name of the main sln *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes

- [`3b6fc6a`](https://github.com/pabllopf/Alis/commit/3b6fc6a27fb1dd4007373845bf0a550740b3f3c0) - delete dependencies of
  vector2 with system libs *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`79e4fd4`](https://github.com/pabllopf/Alis/commit/79e4fd4db550bf55e1ca2fb0ded13cdd30c62f7c) - the runtime of windows
  arm64 platforms *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`20dbdc0`](https://github.com/pabllopf/Alis/commit/20dbdc04c76b6612acc22abad0fdd71e71e1f011) - keyboard input when
  press on windows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8f5dc35`](https://github.com/pabllopf/Alis/commit/8f5dc35b030c07d287c02ad28f702594b44a4a67) - keyboard input when
  updateEvents *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`de7c8b4`](https://github.com/pabllopf/Alis/commit/de7c8b41611bdeda23b60bb0b72de27e571d0588) - fix the changelog file
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9f0822e`](https://github.com/pabllopf/Alis/commit/9f0822e244e8ae7cab62f3105ddd371c5b0b5a1f) - delete test on
  changelog workflow *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`44ca3ba`](https://github.com/pabllopf/Alis/commit/44ca3ba4f186a1fb0a72288d2c398d6874a28352) - delete the changelog
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`938b6c1`](https://github.com/pabllopf/Alis/commit/938b6c1e4e3191bae9e00ac50888dd34b54cf6dd) - test without install
  workloads *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8578e03`](https://github.com/pabllopf/Alis/commit/8578e03149cb8a38387aa99338e958fb06ddfc19) - windows test *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`73ebd49`](https://github.com/pabllopf/Alis/commit/73ebd49c5e1b0457379395e006b6e4ae5355d267) - delete tools of
  repository *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3049688`](https://github.com/pabllopf/Alis/commit/30496888897f7ddfe3204c97f8d446e29ed5fdbe) - update sln files *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`ed4a5d8`](https://github.com/pabllopf/Alis/commit/ed4a5d87f28f442f1df1eca5312e95a96f6455ee) - the for of the
  workflows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a7a5e02`](https://github.com/pabllopf/Alis/commit/a7a5e02060d9fd6be45c1be103bf0fb43c48dfea) - the for test *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`08c1c48`](https://github.com/pabllopf/Alis/commit/08c1c487808de5f9847b65bb61ac0a7e63daba91) - the dev test on
  windows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f1630c0`](https://github.com/pabllopf/Alis/commit/f1630c009c4778e04c066453e9dde0098b62c74d) - the main workflow of
  test *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`02fedc0`](https://github.com/pabllopf/Alis/commit/02fedc080cd8eb35c00ed4becee4b321baa49659) - test *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`2a0791e`](https://github.com/pabllopf/Alis/commit/2a0791efe16d8452b73882b25c1d479d636d0aba) - resources path *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`8d870c8`](https://github.com/pabllopf/Alis/commit/8d870c8b0b65542e226687264965463286860872) - the resources path *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`bd75fc6`](https://github.com/pabllopf/Alis/commit/bd75fc6926b078c397ed866ef1f3f15adc727a81) - update the dirs of
  templates *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`861c69a`](https://github.com/pabllopf/Alis/commit/861c69ac419b75c39b0b85deaba785846659224f) - alis test that return
  exceptions *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b986c64`](https://github.com/pabllopf/Alis/commit/b986c6441a64b0bed53e03f794440b030b6125d8) - the dir of unit tests
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`23ac407`](https://github.com/pabllopf/Alis/commit/23ac407b994d8d6d5d6b4ae16bcb614f80f87897) - the name of test
  scripts *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1ae8f32`](https://github.com/pabllopf/Alis/commit/1ae8f323baf3151501e1493ecaf7484de552aa56) - change || to && on
  scripts of linux and macos *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c4caa07`](https://github.com/pabllopf/Alis/commit/c4caa07c74be98fb812d56705eb6a45695a19a6d) - update the scripts to
  linux and macos *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2b917ac`](https://github.com/pabllopf/Alis/commit/2b917aca517f305b65e0d82a73690c0ff702234e) - windows input module
  *(commit by [@pabllopf](https://github.com/pabllopf))*

### :white_check_mark: Tests

- [`a842cab`](https://github.com/pabllopf/Alis/commit/a842cab8603822636e05d81141848e074bf05f2a) - create 3 new unit test
  for method ClearForces of World class. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e85a578`](https://github.com/pabllopf/Alis/commit/e85a578aadc3ab4ff1cfdd1d58c87a8b15ae95c5) - add new tests to
  method addbody of world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e7b93ec`](https://github.com/pabllopf/Alis/commit/e7b93ecaabb1129de40f1c7d0f6ae2ee7833b9d3) - add test to remove a
  body from world *(commit by [@pabllopf](https://github.com/pabllopf))*

### :construction_worker: Build System

- [`1179d33`](https://github.com/pabllopf/Alis/commit/1179d338146307b9b1ea178b8b384383d405afba) - **deps**: bump
  SkiaSharp.Views.Maui.Controls.Compatibility *(commit by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`a661956`](https://github.com/pabllopf/Alis/commit/a66195688ac7817df3e7b32c04e5a849804945e5) - **deps**: bump
  SkiaSharp.NativeAssets.Linux from 2.88.1 to 2.88.3 *(commit
  by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`d5c2f11`](https://github.com/pabllopf/Alis/commit/d5c2f118ff68442275e92375aa35709302254118) - **deps**: bump
  Microsoft.AspNetCore.Components.WebAssembly *(commit by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`65f9dca`](https://github.com/pabllopf/Alis/commit/65f9dcaa5a2be569de527c2c4e7f96471d224293) - **deps**: bump
  Microsoft.AspNetCore.Components.WebAssembly.DevServer *(commit
  by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`e68e0ad`](https://github.com/pabllopf/Alis/commit/e68e0ad61dc4d06539b5a22c36e7a10bef4a7e52) - **deps**: bump
  SkiaSharp.Views.Maui.Controls from 2.88.1 to 2.88.3 *(commit
  by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`c9c794f`](https://github.com/pabllopf/Alis/commit/c9c794f1946975e39cb6bce3044410109bedd392) - **deps**: bump
  Microsoft.AspNetCore.Components.WebAssembly *(commit by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`62a9810`](https://github.com/pabllopf/Alis/commit/62a9810f836de216729287eb278d4c961bf8475a) - **deps**: bump
  Microsoft.AspNetCore.Components.WebAssembly.DevServer *(commit
  by [@dependabot[bot]](https://github.com/apps/dependabot))*
- [`bb93572`](https://github.com/pabllopf/Alis/commit/bb9357221888314bc2d734332c8e182f8e06c65e) - **deps**: bump
  actions/stale from 5 to 8 *(commit by [@dependabot[bot]](https://github.com/apps/dependabot))*

### :memo: Documentation Changes

- [`d30c821`](https://github.com/pabllopf/Alis/commit/d30c8217ba3a3083aaa05b9af078b1cb1c10eeb6) - create automatic web.

### :art: Code Style Changes

- [`022dfe8`](https://github.com/pabllopf/Alis/commit/022dfe8a7e75d8b16782e651982d68fbdd32b659) - change the names of
  workflows of github *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`538bd9a`](https://github.com/pabllopf/Alis/commit/538bd9a3ac5021246db4ad1174256df68f3bd48f) - refactor matrix and
  vector of numerics module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c304839`](https://github.com/pabllopf/Alis/commit/c30483957f4813f422f4cff3bd78de64236f32c8) - refactor main sln *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`a50c18d`](https://github.com/pabllopf/Alis/commit/a50c18dac6b363a9156b83176ae0bb406dcb11d5) - refactor name of
  matrix of physic module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`69360e8`](https://github.com/pabllopf/Alis/commit/69360e89a1b5eb959fbf39c1ea2e2d1918b8a075) - refactor name of
  transform var of position and rotation *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`941af60`](https://github.com/pabllopf/Alis/commit/941af60c8e10abdb770ac16eeb243d3ea3ae2069) - move transform and rot
  struct to math module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`769ffee`](https://github.com/pabllopf/Alis/commit/769ffee461a5422b6585fbb50532c3184d53afaa) - refactor name rot to
  rotation *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`02d80c6`](https://github.com/pabllopf/Alis/commit/02d80c6c577d8e1947fe4856069ddcd861397adb) - delete dependecies of
  numerics module on physics and create custom vectors *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ed486ba`](https://github.com/pabllopf/Alis/commit/ed486ba42b744df372933e3217384fdb3d8afbb5) - refactor the main sln
  files *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3bccc85`](https://github.com/pabllopf/Alis/commit/3bccc85cb5e4ed2df488d8e820b7647726b8bc87) - refactor delete
  fixturedef of physic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a2a06b8`](https://github.com/pabllopf/Alis/commit/a2a06b86963175a4a7142ab45c46ebee7218569f) - delete body def to
  simply the class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e24cfbf`](https://github.com/pabllopf/Alis/commit/e24cfbf83e3728de8021437d21c806e3ae60a562) - delete all def of
  physic module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2f506d1`](https://github.com/pabllopf/Alis/commit/2f506d17ef28d695415479799c4371d6204108e0) - change timeStep to
  time module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`31bd68e`](https://github.com/pabllopf/Alis/commit/31bd68efd898b7cca04cfa8ace5e94209b5df2d1) - delete misc folder of
  physic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cdff2ce`](https://github.com/pabllopf/Alis/commit/cdff2ce5dfc42012df77e8dc0b89ca49b1194b6d) - delete cont of max
  value float to float.MaxValue *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0e4b5b3`](https://github.com/pabllopf/Alis/commit/0e4b5b347133f38a7e6eec7c9161dcc552969142) - delete regions of code
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7a0d175`](https://github.com/pabllopf/Alis/commit/7a0d17560182771ea9a76dd161c3ab28262ed84c) - refactor rogue sample
  deleting the native old libs *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ab89372`](https://github.com/pabllopf/Alis/commit/ab8937284c53699c4f350f595951991a21089a6f) - update the xml files
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b72aa0d`](https://github.com/pabllopf/Alis/commit/b72aa0d0cc2907cfff6f5e573d826daac31c2bbf) - refactor the math
  helper to include on the math module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`187afd5`](https://github.com/pabllopf/Alis/commit/187afd56b7013c09753a7c18b1f87b7f24123f6b) - include new matrix3x3
  on math module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7c314cf`](https://github.com/pabllopf/Alis/commit/7c314cf4d799a0dc60226b98988fb86a5bd8b565) - add the pong game to
  web interactive *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2bd593d`](https://github.com/pabllopf/Alis/commit/2bd593ded6e035c4f8d4f9fee2c095554f2588c6) - refactor the matrix
  2x2 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8010512`](https://github.com/pabllopf/Alis/commit/8010512d38ca9406051ccfc9fc04d04c6b920148) - refactor names of sln
  files and vars. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3a1b17d`](https://github.com/pabllopf/Alis/commit/3a1b17d4015cc8829d546641a799259aeceee9bd) - run cleanup and
  refactor code *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6b0f886`](https://github.com/pabllopf/Alis/commit/6b0f886ce53927d18e4fc1f0628327132519853b) - extract class and
  struct of sdlmixer *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`132979b`](https://github.com/pabllopf/Alis/commit/132979b88453088891a7ae7b38edf23d4d6a3a54) - refactor the input
  module to include new class/struct of sdl lib *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0bb60de`](https://github.com/pabllopf/Alis/commit/0bb60deaa2de1d72b73c795ae3b7087133a3f835) - end refactor of sdl to
  extract all class and struct in files. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a96faaf`](https://github.com/pabllopf/Alis/commit/a96faafaaff9114dc3d08364455c83102a3422e7) - refactor the static
  text of files sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9d2ba0d`](https://github.com/pabllopf/Alis/commit/9d2ba0d4dccd4f30a64eff12b78a2c13ea1500d8) - refactor the physic
  module and include new properties on world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b4caad8`](https://github.com/pabllopf/Alis/commit/b4caad8da5a4b0598fd712194953bd2615a2d317) - create simple class
  world *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`beb2731`](https://github.com/pabllopf/Alis/commit/beb27318155ce5e0bcea4849e316f61205e1a81d) - new docs md for class
  world *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`494bb29`](https://github.com/pabllopf/Alis/commit/494bb29d9435764859504eca4b1a0919cd67dfc0) - update docs of world
  class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fafc89f`](https://github.com/pabllopf/Alis/commit/fafc89f97cf85db6de441e33c0a1f9921c4484be) - refactor workflow of
  test *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a46dd39`](https://github.com/pabllopf/Alis/commit/a46dd39cdcc81a4a887fd14da92d404412d3ce13) - refactoring the world
  class of physic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d3d0bed`](https://github.com/pabllopf/Alis/commit/d3d0bed93940b308d2bb3323975d305b51ec66de) - refactor contact list
  to do a real list *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`40a5875`](https://github.com/pabllopf/Alis/commit/40a58755faaff750a2924e5889eda13153aa55ea) - refactor the world
  ClearFlags() *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`92ffd7b`](https://github.com/pabllopf/Alis/commit/92ffd7bd8ec71692ed262e83ddac5968088d8cf7) - remove rest method
  from island *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b03dfd1`](https://github.com/pabllopf/Alis/commit/b03dfd1342ee574d25d8884ddba119b4f8975d8d) - delete BodiesStack on
  world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`15af303`](https://github.com/pabllopf/Alis/commit/15af303a10481d10457d9fd717dae741bb18a1c5) - refactor to do more
  simple the solve method *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4a976ea`](https://github.com/pabllopf/Alis/commit/4a976ea1a80514d8832c8e41337343c483792ff7) - create new methods on
  body and world to do more simple the class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`90e48d1`](https://github.com/pabllopf/Alis/commit/90e48d10a27c140725be80d835c95db2bc3bef56) - change body[] to
  list<body> on island class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d7235ec`](https://github.com/pabllopf/Alis/commit/d7235ecbd9ad8e2c4e70f0427e3c7ff174cd51ae) - change arrays to list
  on class island and contactsolver *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`270a7ad`](https://github.com/pabllopf/Alis/commit/270a7add5b2b52aa8072b69a839f148c2258dfac) - refactor style of the
  solution *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8daf77d`](https://github.com/pabllopf/Alis/commit/8daf77d20e847a87343ac4e9a925d03ae9758f3d) - remove contact manager
  reference of island class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8d9f0af`](https://github.com/pabllopf/Alis/commit/8d9f0af76b2c16c35e895a54163880d62e38132b) - simple solve method of
  world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f76def1`](https://github.com/pabllopf/Alis/commit/f76def19147f24960e3305631521018e2fbaa46a) - add new method to
  invalidate TOI *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`584f8b5`](https://github.com/pabllopf/Alis/commit/584f8b5b10493c34494749963e86f0309c55989f) - new method called
  SynchronizeBodies on island *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b9dd6f8`](https://github.com/pabllopf/Alis/commit/b9dd6f8ea7170bbe96c57ba4550e6dc9bf7a642a) - simple more toi events
  method of wold class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e1d7c7b`](https://github.com/pabllopf/Alis/commit/e1d7c7b1e8b021fcfc8e77e4f3795f8bc5e1dd36) - create new method to
  get mincontact *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`76863ad`](https://github.com/pabllopf/Alis/commit/76863ad093fa36d89c3ab7e50bfbfc3c31208b37) - add new method called
  AdvanceBody on world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6536db4`](https://github.com/pabllopf/Alis/commit/6536db455d2de10a9ec8324c5ae6e8c659487c77) - create the fast
  iterator of list *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ef0695e`](https://github.com/pabllopf/Alis/commit/ef0695e2072026a1ffb57ff48dbc7190e91775e6) - refactor the world
  class and create new method IsMinAlphaGreaterThanEpsilon *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9d33957`](https://github.com/pabllopf/Alis/commit/9d33957359203694189bf6111dcf15180ae4b242) - refactor the island
  class to include a timestep *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`62fc6a1`](https://github.com/pabllopf/Alis/commit/62fc6a147922337c9f31cfa9815c6884d72e7097) - delete a ref of
  minalpha *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`409cff9`](https://github.com/pabllopf/Alis/commit/409cff93a0c48f78a08d83ed82103361bc066b96) - refactor the world
  class to do bodies list private. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`058d59a`](https://github.com/pabllopf/Alis/commit/058d59ab163fa844e00e09f1fe9dd50cea570f10) - delete the static
  world copies on objects. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e0937e6`](https://github.com/pabllopf/Alis/commit/e0937e63b6c6511f83977f33221ca8f7650bc938) - delete dummies test *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`8a6f4ef`](https://github.com/pabllopf/Alis/commit/8a6f4ef941a3bb42daf28ceca67e3c95e3a71782) - creating new figures
  to delete the factory methods *(commit by [@pabllopf](https://github.com/pabllopf))*

## [v0.0.6] - 2023-04-28

### :sparkles: New Features

- [`da7b547`](https://github.com/pabllopf/Alis/commit/da7b5470ff9aa0ec9ff9668456bd8fa2bc060159) - update automatic wiki.
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fdcde42`](https://github.com/pabllopf/Alis/commit/fdcde4204f389cdfc1dc8ed1518f10e86a2fb2c6) - change the structure
  of docs folder to include wiki, web, documentation, and resources folder *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`31dab88`](https://github.com/pabllopf/Alis/commit/31dab885c17e9b237ce4c2c7dd01b12b73095594) - first version of web
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e86a06e`](https://github.com/pabllopf/Alis/commit/e86a06ebb5ac1580935d5cb767a94ef9d32b96ec) - add Content Security
  Policy to web *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`bd81036`](https://github.com/pabllopf/Alis/commit/bd810369e333ea0c9afdff6d1502833337d62763) - add new policy *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`02d9697`](https://github.com/pabllopf/Alis/commit/02d96974516516d684e1b7243b4ab37e92f50177) - add new control of
  logs. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a976136`](https://github.com/pabllopf/Alis/commit/a9761369fdd535c6d54d5c766afa911108c4781a) - add new style logs and
  new tool to see full logs. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f9bde5f`](https://github.com/pabllopf/Alis/commit/f9bde5f0cb250d95aba18cffc7ed1955595ada7f) - add new template to
  create games withs alis and 2d new render manager. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`962034d`](https://github.com/pabllopf/Alis/commit/962034d7d1ad476e5765eca327a5636b2488e9f9) - add new extract method
  to load resources dlls *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d4bcec3`](https://github.com/pabllopf/Alis/commit/d4bcec3737965e900cc9f469280a3a5d509d81a5) - add template to build
  game on web. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7334131`](https://github.com/pabllopf/Alis/commit/7334131becddb85c67696945992aa11acc2e870e) - add .runtimes folder
  on sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f5c27d6`](https://github.com/pabllopf/Alis/commit/f5c27d6397e14616540d9e4cfa56a7b8a9c97eec) - adapt the packages
  config for graphic modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6ce06d5`](https://github.com/pabllopf/Alis/commit/6ce06d508834a216dd521072292290547875d9d6) - add native dlls on
  audio module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b0193a3`](https://github.com/pabllopf/Alis/commit/b0193a3dc03ee0545aa96bdd58e45ab33efc846e) - compile the alis lib
  with native dlls *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes

- [`5f67f24`](https://github.com/pabllopf/Alis/commit/5f67f24278dcf5b8081fdc80fbf9e6d99f0e5cf6) - workflows of github *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`3e5bc8f`](https://github.com/pabllopf/Alis/commit/3e5bc8f76485b4e309cde3e4e45d842f8c7f6b58) - size of web *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`bb9df06`](https://github.com/pabllopf/Alis/commit/bb9df062e4e31a0b200c4945677b14867738dde0) - email send of web *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`81e9186`](https://github.com/pabllopf/Alis/commit/81e9186da82ec246e2c4aa8c5dfe073528fb43c8) - the Indexing of the
  web *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4003a59`](https://github.com/pabllopf/Alis/commit/4003a5987eeff17126a0147a57a469be5c21ac33) - change gifs to video
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c52566b`](https://github.com/pabllopf/Alis/commit/c52566b58a1430640fa9856ce16746b6e1885e71) - footer web and time
  load of scripts *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`16b237d`](https://github.com/pabllopf/Alis/commit/16b237d9c163ea3a22960af942f387a00586df8f) - web jquery version *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`5c84c21`](https://github.com/pabllopf/Alis/commit/5c84c213064174503d2e46c4d4db3c294ffc1d01) - video format of web *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`8819bd1`](https://github.com/pabllopf/Alis/commit/8819bd15d54013d53263056a72f61f84d7523a12) - logo web format *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`e517ca8`](https://github.com/pabllopf/Alis/commit/e517ca848c51e1e185281cfd2635864ae1ac4135) - update bootstrap *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`88dc942`](https://github.com/pabllopf/Alis/commit/88dc94213032f1dda92bbd3c95547d036fe65afc) - resolution logo alis
  on web *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6d7bb99`](https://github.com/pabllopf/Alis/commit/6d7bb99dc9112262086dd97da8d540f99c33af59) - console errors *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`dd02d93`](https://github.com/pabllopf/Alis/commit/dd02d9335238ab7b18076c334a50591c4d2e8060) - web Ensure CSP *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`78dcb86`](https://github.com/pabllopf/Alis/commit/78dcb86cfcbbb1fb0396de1bbba058c68cada849) - web contact form *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`b3002fe`](https://github.com/pabllopf/Alis/commit/b3002feac16d541664bc4df87f8ede317f919687) - navegation menu web *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`f26d084`](https://github.com/pabllopf/Alis/commit/f26d084763029bed99571a7c4e145d6d67c1faa4) - change images folder
  of wiki *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`76f9217`](https://github.com/pabllopf/Alis/commit/76f9217c03ce52a176265a51319e30ef703292eb) - the index canonical
  web deploy on google domains *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`05244a0`](https://github.com/pabllopf/Alis/commit/05244a00d9db39d432e80a7c63a6d03b6b44a064) - homepage redirection
  on nav header *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d737d1b`](https://github.com/pabllopf/Alis/commit/d737d1bca7b66764bb9f34c4e5bde7bb8b1a5450) - change id marks and
  color of namenu of web. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`76399b6`](https://github.com/pabllopf/Alis/commit/76399b6a8a6fb28d1245610696c485489688483f) - logo imagen ref of web
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`177cedb`](https://github.com/pabllopf/Alis/commit/177cedb09265b039d7aa6dd70aae441e35de517b) - resolution web icon *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`f964a23`](https://github.com/pabllopf/Alis/commit/f964a234da5d4164bcce633142fc295d602d0a42) - video load source *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`019859c`](https://github.com/pabllopf/Alis/commit/019859c3d14a6e56d1be4f3828d61780c5031c19) - homepage video play *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`4202090`](https://github.com/pabllopf/Alis/commit/420209019db710b750f66c012a129f9900aa320f) - nav menu control
  jquery *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`73cd06d`](https://github.com/pabllopf/Alis/commit/73cd06dc18ad3d8e24c70a8a7429acca8625ef08) - change workflows to
  install macos workload *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f9a3b97`](https://github.com/pabllopf/Alis/commit/f9a3b9736531383eae83dc68245cc67611ac1791) - the templates of alis
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f6cce0f`](https://github.com/pabllopf/Alis/commit/f6cce0fc1a839b435c743c386c8dab26ecd302c4) - icon problen *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`84a58be`](https://github.com/pabllopf/Alis/commit/84a58beca15196a55cef3c2c5a49c2acedf2979d) - add new template with
  windows for arm *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`02f8713`](https://github.com/pabllopf/Alis/commit/02f8713ff753a5bae9fc9ea330c79d84d7f804e1) - windows template
  builder *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c1ef08c`](https://github.com/pabllopf/Alis/commit/c1ef08c094d4e98cf2b528febcdbfb21466dcbf1) - simple render of web
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`827aaf3`](https://github.com/pabllopf/Alis/commit/827aaf340c891073ee705c15992489008a910a5d) - add new conditions on
  the linux template csproj *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`40e9353`](https://github.com/pabllopf/Alis/commit/40e9353416f3478ce8cfc53cd7c4f9ce7485b8d5) - change the dir of
  resources to load dlls of systems. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8d4145e`](https://github.com/pabllopf/Alis/commit/8d4145e3efc8ec31862fbb98f93399bccb46fd4f) - change folder of
  resources location *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`09ad3ae`](https://github.com/pabllopf/Alis/commit/09ad3aeae0f642dcb1188d9c417307b2ee2d4b2a) - the dll extract of
  native files *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`baf30a8`](https://github.com/pabllopf/Alis/commit/baf30a8b195df4894b5f07618586bac2f4b4dcc6) - compilation on windows
  for external dlls *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8da2575`](https://github.com/pabllopf/Alis/commit/8da2575e56ecc0e3d59a3a2f70fba5793e3e6c99) - vector 2 structure *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`8e6b359`](https://github.com/pabllopf/Alis/commit/8e6b359459b8faa228ba7e09ed1d43d11a17ef20) - the automatic create
  test *(commit by [@pabllopf](https://github.com/pabllopf))*

### :white_check_mark: Tests

- [`04b1a2c`](https://github.com/pabllopf/Alis/commit/04b1a2c15e1384b9422c2bcec1ab3eddc678a5a9) - create 240 empty test
  for alis.test module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`94d427c`](https://github.com/pabllopf/Alis/commit/94d427cd8fff693a82470d4ee61594961f88839a) - fixed default tests
  and start to testing videogame class *(commit by [@pabllopf](https://github.com/pabllopf))*

### :memo: Documentation Changes

- [`de5bc04`](https://github.com/pabllopf/Alis/commit/de5bc04bc2e8a8d8b4b18018bfe9ba52d3d2c85a) - create automatic web.
- [`71811cc`](https://github.com/pabllopf/Alis/commit/71811cc9cfff5af26fd8ea1ae0fb08ee341ef104) - create automatic web.
- [`1d0cb26`](https://github.com/pabllopf/Alis/commit/1d0cb2612fbed22260d5ab9f0774d3e7df5ef6c5) - create automatic web.
- [`fe7ce86`](https://github.com/pabllopf/Alis/commit/fe7ce861037af867edb72f5e7a5e51aa728ac46b) - refactor the docs
  folder to include wiki documentation and web. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`71b3441`](https://github.com/pabllopf/Alis/commit/71b34419a97d48ab158a0a64def66c2f5f19ae26) - update wiki with new
  structure. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1970890`](https://github.com/pabllopf/Alis/commit/19708906120d8aecbb49fcd8e440784d630bd4af) - include footer *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`cc601c3`](https://github.com/pabllopf/Alis/commit/cc601c33ef463139f36cd1bf287c07ceef7ac848) - create automatic web.
- [`b29c24e`](https://github.com/pabllopf/Alis/commit/b29c24e76ec8decea798b133624dd0faeff565d0) - create automatic web.
- [`df6ef96`](https://github.com/pabllopf/Alis/commit/df6ef960a192ddaa11503edb18e160b9d152c08c) - delete templates of
  web folder *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2043f2f`](https://github.com/pabllopf/Alis/commit/2043f2f03a584875212f65689f6ddda80342a2f3) - create automatic web.
- [`3fbb522`](https://github.com/pabllopf/Alis/commit/3fbb52238f9b0fb3b36bfc64a33f04d1d01515a4) - create donation web
  section *(commit by [@pabllopf](https://github.com/pabllopf))*

### :art: Code Style Changes

- [`8a07408`](https://github.com/pabllopf/Alis/commit/8a074080705fde48a1c01461129c2f04d2eac69a) - change names of docs
  subfolders *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2a90ed6`](https://github.com/pabllopf/Alis/commit/2a90ed65d957305c53c40bad5dd5a9f78c18e6a4) - remove all
  cansole.writeline to inclide logs messages *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`312dd22`](https://github.com/pabllopf/Alis/commit/312dd22ce19fa2b32735e3e45f6943033bd84582) - refactor the sln of
  templates *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`67fd0b0`](https://github.com/pabllopf/Alis/commit/67fd0b03b5ab636b99c88c8219504302bb06e8b5) - refactor the tmeplate
  of ios to do more simple *(commit by [@pabllopf](https://github.com/pabllopf))*

### :flying_saucer: Other Changes

- [`a4ec78a`](https://github.com/pabllopf/Alis/commit/a4ec78a96d041ba07c61891258131ad49215a704) - update bookmarks of
  log tool. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b1d1605`](https://github.com/pabllopf/Alis/commit/b1d1605baf2a641081e2682a6a25e7dba5369ada) - change the resource
  files *(commit by [@pabllopf](https://github.com/pabllopf))*

## [v0.0.5] - 2022-10-23

### :sparkles: New Features

- [`607bdac`](https://github.com/pabllopf/Alis/commit/607bdac1980a07f9e84a56e0d112ade09af3ecc4) - add bot to check
  security *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`376596d`](https://github.com/pabllopf/Alis/commit/376596dc45b22c97b0bfdbd3c1d72ccf623aa89d) - create workflow to
  auto create web *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`94423ea`](https://github.com/pabllopf/Alis/commit/94423eacd9e805e4ac8dfb84b804305a32e3b52a) - Add gpg4win tool for
  windows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`97b981d`](https://github.com/pabllopf/Alis/commit/97b981dc5f3f4189ce410f9e351f53501d298614) - add rider for windows
  tool *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`91d3616`](https://github.com/pabllopf/Alis/commit/91d3616f80fff9da0f7c9d55cf9d787dd2534405) - add git tool for
  windows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`de37217`](https://github.com/pabllopf/Alis/commit/de37217e4453b14b169d043d1c7b535928b478bd) - add github desktop to
  windows tools *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ee67417`](https://github.com/pabllopf/Alis/commit/ee674177fc0de9f0eb962b127c113b7a3b505684) - add SFML *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`eec1de1`](https://github.com/pabllopf/Alis/commit/eec1de1e29e94700f99c365b81a3a0fcb4e34c80) - add .net6.0 *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`9940504`](https://github.com/pabllopf/Alis/commit/9940504e6c2eec9bd2281e93ca09ac4e408e2992) - simple render
  cross-platform *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0bbcbd0`](https://github.com/pabllopf/Alis/commit/0bbcbd0cb71c7144c88287acc489496f69389134) - add new script to
  macos os for develop on alis *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c44c934`](https://github.com/pabllopf/Alis/commit/c44c934150f163c990742a2a9b670b2723d2a3c2) - add global.json with
  net6.0 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d6df8e7`](https://github.com/pabllopf/Alis/commit/d6df8e72e5ca912fda69b299e60d23eca7a5e8a4) - new render
  cross-platform *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a42580c`](https://github.com/pabllopf/Alis/commit/a42580c164f9425627869a45ae39387526289d6a) - add new network socket
  module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2bdbdfc`](https://github.com/pabllopf/Alis/commit/2bdbdfc27ddd15707a7348cf72b96a230a06a126) - add simple structure
  of a game on alis. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`53c9fb3`](https://github.com/pabllopf/Alis/commit/53c9fb3ad61c39db7c63b29b388df9f072fe7162) - add installer of
  rider. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`faa8f8d`](https://github.com/pabllopf/Alis/commit/faa8f8d4fdb21d0e5844dcb0383d065c3aebd347) - add installer github
  desktop *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4e11c10`](https://github.com/pabllopf/Alis/commit/4e11c100750c224c35c886defc8dfff4f0ea5937) - add installer dotnet
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0cd30dc`](https://github.com/pabllopf/Alis/commit/0cd30dc0f6b79fa58b4720247d183fea4abcf67a) - add controller
  xbox/play module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0b0a002`](https://github.com/pabllopf/Alis/commit/0b0a00253511d2710f8676898b667b783a3577ee) - add test for all class
  of physics module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8ca2bca`](https://github.com/pabllopf/Alis/commit/8ca2bca17cea19b3185399654299b1292dcf24a0) - add empty unit test of
  physic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3041698`](https://github.com/pabllopf/Alis/commit/3041698df8e2e6095c017732ab9856eb0aed11ba) - delete body
  linkedlist, and create simple list<body> on world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5a29a42`](https://github.com/pabllopf/Alis/commit/5a29a42cd79f83b7c5ad5aa1e32a6b90406de909) - add new expection of
  lock world *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8b8fd2e`](https://github.com/pabllopf/Alis/commit/8b8fd2ec2e1d73c5fccf9555acac7173d6390ee7) - refactor to create a
  world more simple. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`986654d`](https://github.com/pabllopf/Alis/commit/986654d2a4f73dba2b3a908de45cd77fa9d05038) - create entity shape on
  world. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d6240c2`](https://github.com/pabllopf/Alis/commit/d6240c22a3926ec541e975c9723266cd0a3c4cfc) - add new entity joint
  to world *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`bce7b1c`](https://github.com/pabllopf/Alis/commit/bce7b1cc276863f7ca5966ce1a562c83fd568d76) - PublishTrimmed *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`21ae75b`](https://github.com/pabllopf/Alis/commit/21ae75b113209d6c2364680630a6d9f45513d4f2) - add new arquitecture
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7ad08db`](https://github.com/pabllopf/Alis/commit/7ad08dbf83e334c0067e08eb4899b2bc76eb6c76) - create new
  arquitecture of alis.core *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`740e5d4`](https://github.com/pabllopf/Alis/commit/740e5d47da3133aa23961d458971302294a4590f) - create system and
  manager control *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cb66212`](https://github.com/pabllopf/Alis/commit/cb662128335c5f26c8bce36ad8ba812b0d49231a) - change mode on debug
  and release with files linked *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c3e0f6f`](https://github.com/pabllopf/Alis/commit/c3e0f6fe8500b2222bc3f97558a8cb466542ab48) - add default tools to
  build project *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`223a986`](https://github.com/pabllopf/Alis/commit/223a98600fbeb731447f561d52f94ccf95395b05) - add managers
  controller *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ffcb0f0`](https://github.com/pabllopf/Alis/commit/ffcb0f098f798959ee281d80cf081e62a98dbcd1) - add transform for 2d
  games *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b5f5533`](https://github.com/pabllopf/Alis/commit/b5f553323cdc57c750bdc504eece1b286145cb45) - add new builder of
  scene and scenemanager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b9f5037`](https://github.com/pabllopf/Alis/commit/b9f503704eb689b852a6b5354b6d82af410a178c) - add grapich sample and
  add compability with macos *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0fcfcbd`](https://github.com/pabllopf/Alis/commit/0fcfcbd461809efef11d66a808867ab2847e4e1f) - add graphic manager
  and simple windows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`db15105`](https://github.com/pabllopf/Alis/commit/db15105a5a41fb4a248401e45b93a6b2c1ffaeb4) - add new audio cross
  platform with net standar *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1ac3e4b`](https://github.com/pabllopf/Alis/commit/1ac3e4b69ed92f40ba1b123648a33ce6dc0ff5b6) - assets folder include
  automatic in sample projects *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`aa27e61`](https://github.com/pabllopf/Alis/commit/aa27e6198007351e004705d6fab276e991fa35ea) - add timer control *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`db27866`](https://github.com/pabllopf/Alis/commit/db2786655cfd4f6d52ab5316146edb371d4366fc) - add sprite component
  builder and add new sample with this component *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9976bec`](https://github.com/pabllopf/Alis/commit/9976bec969c7db871241faf3ae33e381fcdbd1bb) - add new builder for
  components of alis.core *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7c449e7`](https://github.com/pabllopf/Alis/commit/7c449e73c745c499d8c488a121aba75f77f18bf0) - integrate sfml modules
  of grapichs, audio and input *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`187c813`](https://github.com/pabllopf/Alis/commit/187c813c95c18d8df15462346f55b99987060537) - new input manager *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`9e6b057`](https://github.com/pabllopf/Alis/commit/9e6b057a4679d15a78e00938f3bcae25968921d4) - implement the native
  and sfml audio module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e58388f`](https://github.com/pabllopf/Alis/commit/e58388f5b3ae3f1aec0a295eeb429d4a76aee9ec) - create audio general
  clases for build components *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7bcf0bd`](https://github.com/pabllopf/Alis/commit/7bcf0bd6d7340e3ed0c84c6786466331d2b4bb78) - add new words for api
  fluent and integrate the audiosource builder. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0bba00c`](https://github.com/pabllopf/Alis/commit/0bba00c1466fc2c2fe46c6b361db84ef8d124d0c) - new builders of lights
  and meshs *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b0364a1`](https://github.com/pabllopf/Alis/commit/b0364a12a64d5401ca71e7aed96bc9783d43747a) - add new builders
  config for audioclip and audiosource *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4c614d8`](https://github.com/pabllopf/Alis/commit/4c614d87fa6dec0e734fff260c737a355f014df4) - setting builder *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`0f68c8a`](https://github.com/pabllopf/Alis/commit/0f68c8a233f3c2111d0e96d36173bcb2c4eaa3e5) - add new simple input
  manager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f2d0135`](https://github.com/pabllopf/Alis/commit/f2d0135e60fe6e2db5f05c04c20a9faa053ea133) - add animator simple *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`bd8eb78`](https://github.com/pabllopf/Alis/commit/bd8eb7863e4103f333258b2edac003f752dff5f7) - add player move
  controller with simple input *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8647b7e`](https://github.com/pabllopf/Alis/commit/8647b7e668f96f761fc09e025e6c0f59062402fa) - implement managerbase
  clases to create interface into alis.core and alis *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4b0a3be`](https://github.com/pabllopf/Alis/commit/4b0a3beec3a8488893c211290903fd1c025d0d39) - add tool to create
  comments *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1bd6db7`](https://github.com/pabllopf/Alis/commit/1bd6db7a4bc0aa5ad7bec0ca1bcb9b651b327ff7) - add animator simple
  builder with api fluent *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1c0ef96`](https://github.com/pabllopf/Alis/commit/1c0ef9699d43f1159ed7d98e3be7ebf7207cded8) - change animation by
  name *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`ca1609f`](https://github.com/pabllopf/Alis/commit/ca1609f27c99a9e0b3ab38c5ef874f18e36845c3) - add camera *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`080124a`](https://github.com/pabllopf/Alis/commit/080124a39c30681f226f58f78dbab12403ea3a9e) - add new debug *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`2dc87cc`](https://github.com/pabllopf/Alis/commit/2dc87cc91e198a3ef491e1d641064fc4434e3ca3) - add icon setting on
  general settings. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`975ab29`](https://github.com/pabllopf/Alis/commit/975ab29c9e02512a650c30b20f4ae26d8925c8cc) - add new setting of
  window and general. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`26937f1`](https://github.com/pabllopf/Alis/commit/26937f1af7b051ab1650a908ee48628aa423139d) - resize the windows *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`2cce91f`](https://github.com/pabllopf/Alis/commit/2cce91f5ff812ac20b5ec39542ea2022dad0a453) - can change to resize
  and fullscreen mode with alt + enter *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a9fd920`](https://github.com/pabllopf/Alis/commit/a9fd920a8f660facbd099fad45c60cc3d53787f9) - add benchmark module.
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fd020a8`](https://github.com/pabllopf/Alis/commit/fd020a89dee7b993e665acaff7a8e934feb6dd6c) - add basic templates of
  game with alis. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8e06194`](https://github.com/pabllopf/Alis/commit/8e06194180e8adc65341f491ea3ac81340f1a1fa) - simple template
  cross-platform of alis. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`19c3af6`](https://github.com/pabllopf/Alis/commit/19c3af66183db42d25ffe137a47eca7902bc52a7) - basic physics with
  dynamic/static objects. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`053d5ae`](https://github.com/pabllopf/Alis/commit/053d5ae322613f0f2ebc130bcb4f9e358fb2d04b) - add simple game ping
  pong with physics. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9e1920c`](https://github.com/pabllopf/Alis/commit/9e1920c06a470ee08da17cbfc73387f5d35b23fe) - add simple player
  controller of ping pong game *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4d1206c`](https://github.com/pabllopf/Alis/commit/4d1206c7f4017692999d50178b4e88098a33b69c) - detect collision of
  two object. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f425b95`](https://github.com/pabllopf/Alis/commit/f425b95afd318efd13f6874bb5f814dd4bc0ed0b) - add simple
  geometrydash controller *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`45e2436`](https://github.com/pabllopf/Alis/commit/45e24361ba0800ab368ec28765c2234d5d690f62) - add simple sample of
  collisions *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes

- [`e3b827a`](https://github.com/pabllopf/Alis/commit/e3b827a3b465225a84469fe770dab0ff21969a2b) - change config file of
  bot dependency *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`926f652`](https://github.com/pabllopf/Alis/commit/926f652dc33fd5c9f6c814ebfacc99a04d377e78) - generation of xmls
  files by targetframework *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3a3cbfa`](https://github.com/pabllopf/Alis/commit/3a3cbfaac2324820f1ef757656d94035aa6abc82) - namespace of timestep
  class in the time module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9d9e787`](https://github.com/pabllopf/Alis/commit/9d9e7872fc5e4029939c340ccf5cde8baae4a198) - the output dir of
  build sln include $configuration in the path. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`59891ad`](https://github.com/pabllopf/Alis/commit/59891ad428040ac4367e35674c5839d1eddfbdd1) - netstandar 1.3 *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`74e5cb8`](https://github.com/pabllopf/Alis/commit/74e5cb8e7bc45e7f11ef5f734f006d65e5248400) - add dlls for macos m1
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`30583e8`](https://github.com/pabllopf/Alis/commit/30583e87b955c9d1b1bb36b87389a186a5a91282) - dont include xml files
  in repo *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`cf1fa2f`](https://github.com/pabllopf/Alis/commit/cf1fa2fca9b5bc53ca75dbd7abf6549569d03545) - give permission files
  sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`73ef303`](https://github.com/pabllopf/Alis/commit/73ef3033dd6f1ae6000376029a6ada26d5731062) - android manifiest *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`3610521`](https://github.com/pabllopf/Alis/commit/3610521a741f6c7efe6ce644a54c01f99a77c28c) - the tests on dev
  branche *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5791a4a`](https://github.com/pabllopf/Alis/commit/5791a4adc2510d2258f8960cd76323d9164c9086) - example of the desktop
  windows *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3d043bf`](https://github.com/pabllopf/Alis/commit/3d043bf80359ec9129770cb1f10c8ee221f0af86) - change names of
  folders and rules. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`57500e0`](https://github.com/pabllopf/Alis/commit/57500e01c0a12c65628f08ecfff5663f5507d51e) - change all class to
  individual files on input module. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`168a3a8`](https://github.com/pabllopf/Alis/commit/168a3a88c8ced0f27d9f759d21a6fb44301a8728) - refactor a style of
  code. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`078fb22`](https://github.com/pabllopf/Alis/commit/078fb22dcd3e66fae68c3a58efdf97a4952ebf76) - dependency of samples
  alis. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a250b64`](https://github.com/pabllopf/Alis/commit/a250b640da4c0a95c0cf643b54e8e8b6c8378757) - run desktop template
  on macos *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`350a674`](https://github.com/pabllopf/Alis/commit/350a674ba838b097b5d693f031d6723fa29ddbba) - windows platform for
  develop *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`41634df`](https://github.com/pabllopf/Alis/commit/41634df66dfde95c7083c1481d080c65cc6a7f89) - add new option to see
  internal var on projest of testing. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4e1239b`](https://github.com/pabllopf/Alis/commit/4e1239b2a7dae085d9fcac027643695d110c924d) - namespaces of solution
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8862b5c`](https://github.com/pabllopf/Alis/commit/8862b5c81b2b9d0838bb4e8452e4899118b70ada) - combine all partials
  class of collision in one class. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d81f392`](https://github.com/pabllopf/Alis/commit/d81f392406f57359fb17999da9273beb038c070a) - some name usings. *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`a08034a`](https://github.com/pabllopf/Alis/commit/a08034a28e57a049eaf6c0989dbe1d88948fa80c) - add nuget config. *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`8eebac8`](https://github.com/pabllopf/Alis/commit/8eebac80881ed25fd7339ea3929beca02e074b98) - refactor world class
  to reduce menbers *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`155378f`](https://github.com/pabllopf/Alis/commit/155378fe6f03f2d2cbca21ab23b0fee920fb602b) - null reference to
  bodylist on world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`932eea0`](https://github.com/pabllopf/Alis/commit/932eea03537c0cc6f37377cba998eb5d25eee3b9) - refactor world class
  to more simple *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`afea91d`](https://github.com/pabllopf/Alis/commit/afea91db1b1b1e654b08d76175c10da7cb99359c) - refactor world class
  to do more simple class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dfd2a9e`](https://github.com/pabllopf/Alis/commit/dfd2a9edb48dfb2bc762fc9a9d81b146d4515fb6) - delete raycast of
  world class. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b9d0de5`](https://github.com/pabllopf/Alis/commit/b9d0de555d02c2a72425bd9a2bb87bd7aa72381a) - change names of
  create/delete to add/remove of list world class *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e16346d`](https://github.com/pabllopf/Alis/commit/e16346dedbf1128b7d09d6d9fdd28a549288839c) - change color class to
  logging module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`136ac6d`](https://github.com/pabllopf/Alis/commit/136ac6d99fa7ecec24aab623f3c06eac11cb5856) - refactor the math
  module to add the helper class. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0229c45`](https://github.com/pabllopf/Alis/commit/0229c451182b7fe64e5de82a25d6de027ff66fa4) - diagram class of sln
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c956ef4`](https://github.com/pabllopf/Alis/commit/c956ef4b55a4bfc9be45b572d7d82692954b4f4d) - 2000 errors *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`871b912`](https://github.com/pabllopf/Alis/commit/871b912132ba8de1d81f32d088ee9219ceaaa5fd) - compile the original
  files *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`82cff54`](https://github.com/pabllopf/Alis/commit/82cff548f007e763f5b840199ae4b772d4a85a18) - the folder names sln
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`32e9ade`](https://github.com/pabllopf/Alis/commit/32e9ade8d79a96f8e80fc42e70b39ba2fa57f382) - delete input module
  and updater module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0050d83`](https://github.com/pabllopf/Alis/commit/0050d830ddcc7ed73ec03dce6e0142067c5b4f31) - delete some unit files
  and order folder of modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e651f66`](https://github.com/pabllopf/Alis/commit/e651f66731cf6b3f373047bff1a783c3824c9bba) - obsolete code *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`4166706`](https://github.com/pabllopf/Alis/commit/4166706becb300a413ec57d4df663ce9ed3b3483) - change base module *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`5923d59`](https://github.com/pabllopf/Alis/commit/5923d598c2f2254f8100e427fce675154a02c68a) - refactor contac class
  to extract enums definitions *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`153a203`](https://github.com/pabllopf/Alis/commit/153a2033682d27cf678c9373fd33315d3d5f1c31) - namespace on sln *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`43b41db`](https://github.com/pabllopf/Alis/commit/43b41db1c5c2996acc7158cb1702bdfc3f642227) - debug mode with
  projects references *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`2284c27`](https://github.com/pabllopf/Alis/commit/2284c27c066b75697d44d158ff78f65af86dff1c) - base module to new
  arquitecture *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f2236d3`](https://github.com/pabllopf/Alis/commit/f2236d3db9402812c63d79f9c31772e5e280cf85) - dir and files name
  capitals *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`0941c0b`](https://github.com/pabllopf/Alis/commit/0941c0bfb841ea2c5bb730007426670be6c077f9) - delete temp files *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`8300398`](https://github.com/pabllopf/Alis/commit/83003984fc579db70a8f66362ea8155c00bbbf93) - add new arquitecure
  with new names and folders *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1f4880b`](https://github.com/pabllopf/Alis/commit/1f4880b0c95aab376260c615e866005ced2ef11e) - smple rogue when run
  debug and release config *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d068fd7`](https://github.com/pabllopf/Alis/commit/d068fd762d34a2d264e53f7ff641c721358a7678) - csfml dlls on windows
  x64 x86 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dc3bbd2`](https://github.com/pabllopf/Alis/commit/dc3bbd26fc833e2c34b6fcc7c1405795d0fe5250) - the setting builder *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`ec1b1d4`](https://github.com/pabllopf/Alis/commit/ec1b1d441b729d0987b765e2ad8de6107234eac0) - add runtimes to sample
  rogue *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5f3118f`](https://github.com/pabllopf/Alis/commit/5f3118f6499bdb5254706187a1ef642d50566e5e) - change name add and
  remove component *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`64a32b9`](https://github.com/pabllopf/Alis/commit/64a32b9e148d9f3eac37349f09157fff9eac545c) - using on debug mode *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`71cf747`](https://github.com/pabllopf/Alis/commit/71cf74774c59dc5ae71d22423a1b64ab742ea16f) - src folder compiler
  names *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b3c3ec1`](https://github.com/pabllopf/Alis/commit/b3c3ec14d40bfeaa97cc1b547474974f50e2413e) - videogame sample dont
  found input manager *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3f91a44`](https://github.com/pabllopf/Alis/commit/3f91a44d6d5d2a16aa1f1bc727cb4b9f02ddcdf2) - input manager obsolete
  keys. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`7e7e085`](https://github.com/pabllopf/Alis/commit/7e7e085dab94c57f33126cb73a0ceada356d7f94) - change import of alis
  because the dlls of smfl cant be loaded with xamarin *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`4959e99`](https://github.com/pabllopf/Alis/commit/4959e9989c3fc7bbb99f668a1278bb3e42cc6347) - linex workflow of
  github *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6375a64`](https://github.com/pabllopf/Alis/commit/6375a6466c15e5f2b32dfbf2e94d8f3f4e953e85) - dev code scan *(commit
  by [@pabllopf](https://github.com/pabllopf))*
- [`b8805c5`](https://github.com/pabllopf/Alis/commit/b8805c51d6e804a498f48afe6dcf9b96e9ab127e) - delete workflow
  net6.0-macos *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8b86a28`](https://github.com/pabllopf/Alis/commit/8b86a281959d7c72d8ca4579ddf68f2d6d0491c8) - workflow of github *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`0b1944c`](https://github.com/pabllopf/Alis/commit/0b1944cf3ff84cfa81ac1ba0d8d16626cc066c70) - name sln namespaces of
  modules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`3ca85bd`](https://github.com/pabllopf/Alis/commit/3ca85bdf4e722a0d715ed659a7ce8343f5790d51) - names, some docs
  files, and update version of readme. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`47d8c7a`](https://github.com/pabllopf/Alis/commit/47d8c7ac1d348e18011845c5461e3595b1f4148d) - fixed the workflows.
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`fa9ee51`](https://github.com/pabllopf/Alis/commit/fa9ee519ad8bb8b0963d3724f7c8351e79321706) - packs of nuget
  templates *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`c6ecd6e`](https://github.com/pabllopf/Alis/commit/c6ecd6e669e42f0dfae51a56256f45f7d3d09773) - automatic packs *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`d5c22f5`](https://github.com/pabllopf/Alis/commit/d5c22f5b303c59c4fdf730f7ab12990c1a426961) - create publish *(
  commit by [@pabllopf](https://github.com/pabllopf))*

### :white_check_mark: Tests

- [`e4aa8f4`](https://github.com/pabllopf/Alis/commit/e4aa8f4794a00067274ffa1e3a5eef6761bdf735) - add simple test to
  math module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9b7adbf`](https://github.com/pabllopf/Alis/commit/9b7adbf4b8e9060505ee0e3398a09dfae53a5ebc) - add test simple to
  matrix22 on math module. *(commit by [@pabllopf](https://github.com/pabllopf))*

### :memo: Documentation Changes

- [`cce9b68`](https://github.com/pabllopf/Alis/commit/cce9b688234bcb46da41a226ae4c439f7f5ca133) - create web config auto
  documentation *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a11c1e3`](https://github.com/pabllopf/Alis/commit/a11c1e3a28e2b8e74628bce79b1275adf5ad4210) - update the main readme
  to include new sections *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`37efcbd`](https://github.com/pabllopf/Alis/commit/37efcbd14fb5b7de617f849c27f9bf506c411cc7) - update readme with new
  spaces *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`a2fc0ab`](https://github.com/pabllopf/Alis/commit/a2fc0ab1551206edd250eeb20e1e63fbf8eb6731) - document text
  automatic *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`48dc37c`](https://github.com/pabllopf/Alis/commit/48dc37c51b9811ec5effc53098584d0d22d545a8) - create security file.
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`befa0c0`](https://github.com/pabllopf/Alis/commit/befa0c023059d0e19fe1a02852459acac77b9d2b) - document code. *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`7e6f304`](https://github.com/pabllopf/Alis/commit/7e6f3043314969e0624d7ea1a901c21c00a4ddec) - add the min lang
  version comment *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`5beb44b`](https://github.com/pabllopf/Alis/commit/5beb44b71ab6af0bface277f5e2bdc8a6a33f8c9) - add test cover *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`b13b5cd`](https://github.com/pabllopf/Alis/commit/b13b5cd26fc7feaf4e7a812fb1b5f3217d0c23de) - create page folder to
  document all things of framework. *(commit by [@pabllopf](https://github.com/pabllopf))*

### :art: Code Style Changes

- [`191bf44`](https://github.com/pabllopf/Alis/commit/191bf44ad10a58957130d447473ad146f5e39a74) - refactor name of
  vector2 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`241f97a`](https://github.com/pabllopf/Alis/commit/241f97aea17a84e30fece47957a685d29601a045) - refactor name of
  vec3 -> vector3 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f20dc4d`](https://github.com/pabllopf/Alis/commit/f20dc4da13695ed982a0c5bde135981988f3fda3) - refactor name of
  matrix2x2 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`9f80538`](https://github.com/pabllopf/Alis/commit/9f80538c11ee920b25b279ccbe3056d21845e5c1) - refactor name of
  matrix3x3 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8bb6399`](https://github.com/pabllopf/Alis/commit/8bb63996084367d1f5527d8045e4ff8a0418565a) - refactor name of
  matrix22 and matrix33 *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6b2aadc`](https://github.com/pabllopf/Alis/commit/6b2aadc5e25458c0db1f1eeeaec35833a02457d2) - refactor the default
  sln file. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1c5ccbb`](https://github.com/pabllopf/Alis/commit/1c5ccbb30605dc621db6dab2e3a893379ffbb230) - restore the sln *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`cfe8736`](https://github.com/pabllopf/Alis/commit/cfe8736f7e24a84498efcaa478413d140e37ab3a) - change names of
  projects of test. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`97dfeef`](https://github.com/pabllopf/Alis/commit/97dfeefd67f48787eb69e0a1086d7a539b08edac) - change the world class
  to main directory of physic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`6f29fc1`](https://github.com/pabllopf/Alis/commit/6f29fc1bc0cdae4de92d1f9b011c2f6484ddcd8f) - change TimeStep struct
  to module Time *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`8b30f73`](https://github.com/pabllopf/Alis/commit/8b30f737a9a21686e38a640b9345018632a75e3a) - delete TODOs of some
  file on physic module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`1a04b97`](https://github.com/pabllopf/Alis/commit/1a04b97ef158ecbd1373be2d40cf8460b1145676) - add header licence on
  all files. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`f89ca3f`](https://github.com/pabllopf/Alis/commit/f89ca3fcfd1d8b529eeef6e345eb97435bb08a13) - refactor folders of
  physics module *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dca72a8`](https://github.com/pabllopf/Alis/commit/dca72a8464d7448e643279846e000231b04fe244) - refactor and cleanup.
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`b792726`](https://github.com/pabllopf/Alis/commit/b792726ed890193afab02dc94494e26a060474a0) - add class diagram *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`d14dbae`](https://github.com/pabllopf/Alis/commit/d14dbae0ee1a20876bec005f828402ae058bb08b) - upgrade the diagram
  class of solution *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`579e596`](https://github.com/pabllopf/Alis/commit/579e596f56e601f8d66b064c31faa945cd907156) - refactor editor config
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`460e85e`](https://github.com/pabllopf/Alis/commit/460e85eb7bc14f4e212987d9325fb43c46ddf3d3) - refactor with news
  rules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`dc6a98f`](https://github.com/pabllopf/Alis/commit/dc6a98fa7d0ce2267411f9e889d6fcad9f5d9264) - refactor sln with new
  rules *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`38f4104`](https://github.com/pabllopf/Alis/commit/38f41049da56fd47fc5a940b0f4295b37edea0f1) - change folder names *(
  commit by [@pabllopf](https://github.com/pabllopf))*
- [`7be117b`](https://github.com/pabllopf/Alis/commit/7be117b87554e3b45b29241abcff41fed2f9c952) - refactor the main
  style of sln *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`37ae840`](https://github.com/pabllopf/Alis/commit/37ae8407d82a702ade54e800b454be4d6b80c82b) - refactor and delete
  all using than don´t used by code. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`77fce4f`](https://github.com/pabllopf/Alis/commit/77fce4ff2a202473ea053cc67621f83519566f3c) - refactor style code.
  *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`03f5695`](https://github.com/pabllopf/Alis/commit/03f5695a9de1c3307af6362410e8be8498f57896) - refactor other files
  style. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`d27d1e0`](https://github.com/pabllopf/Alis/commit/d27d1e0b7e815b7b1cb35dc76a1ac5dc9f11a81c) - refactor the modules
  of 4_operation to control the warnings. *(commit by [@pabllopf](https://github.com/pabllopf))*
- [`e930434`](https://github.com/pabllopf/Alis/commit/e9304348750d7b6fe0ce1786621d04b139a8e41d) - remove all TODO that
  are trash of other versions *(commit by [@pabllopf](https://github.com/pabllopf))*

### :flying_saucer: Other Changes

- [`f2abee6`](https://github.com/pabllopf/Alis/commit/f2abee6a9dc7f11021c9cc4ad8dc57df97a0c7b1) - refactor the class
  diagram to include new definition of physics module *(commit by [@pabllopf](https://github.com/pabllopf))*

## [v0.0.4] - 2022-07-13

### :sparkles: New Features

- [`176f0b5`](https://github.com/pabllopf/Alis/commit/176f0b58c041b0016d56e21fffe811a2a87e73f8) - automatic deploy
  version *(commit by [@pabllopf](https://github.com/pabllopf))*

### :bug: Bug Fixes

- [`46ac1a9`](https://github.com/pabllopf/Alis/commit/46ac1a97d8dae3cb4dbfd3156a29be2dc9e03f41) - workflow of release *(
  commit by [@pabllopf](https://github.com/pabllopf))*

### :white_check_mark: Tests

- [`f2e24f1`](https://github.com/pabllopf/Alis/commit/f2e24f1a4f38456d10e004f6242af5d5f752a976) - correect one test of
  examples *(commit by [@pabllopf](https://github.com/pabllopf))*

### :art: Code Style Changes

- [`3142a9c`](https://github.com/pabllopf/Alis/commit/3142a9c4c752bf8c0f50163948b1b9385f271b64) - delete some spaces *(
  commit by [@pabllopf](https://github.com/pabllopf))*

### :flying_saucer: Other Changes

- [`87ee9d4`](https://github.com/pabllopf/Alis/commit/87ee9d4298c4715677d5442e8af198ec2c455dd6) - example of other
  label *(commit by [@pabllopf](https://github.com/pabllopf))*

## [v0.0.3] - 2022-07-13

### :sparkles: New Features

- [`e114c9e`](https://github.com/pabllopf/Alis/commit/e114c9ee38ee1f9aed93712db09b1929d0208d3c) - delete some spaces of
  class program *(commit by [@pabllopf](https://github.com/pabllopf))*


## [v0.0.2] - 2022-07-13

### :sparkles: New Features

- [`e114c9e`](https://github.com/pabllopf/Alis/commit/e114c9ee38ee1f9aed93712db09b1929d0208d3c) - delete some spaces of
  class program *(commit by [@pabllopf](https://github.com/pabllopf))*

## [v0.0.1] - 2022-07-13

### :bug: Bug Fixes

- [`027e2c3`](https://github.com/pabllopf/Alis/commit/027e2c3a828d5fa86d31db56267474a9860cc4fc) - the version flow *(
  commit by [@pabllopf](https://github.com/pabllopf))*

[v0.0.1]: https://github.com/pabllopf/Alis/compare/v0.0.0...v0.0.1
[v0.0.2]: https://github.com/pabllopf/Alis/compare/v0.0.1...v0.0.2
[v0.0.3]: https://github.com/pabllopf/Alis/compare/v0.0.2...v0.0.3
[v0.0.4]: https://github.com/pabllopf/Alis/compare/v0.0.3...v0.0.4
[v0.0.5]: https://github.com/pabllopf/Alis/compare/v0.0.4...v0.0.5
[v0.0.6]: https://github.com/pabllopf/Alis/compare/v0.0.5...v0.0.6
[v0.0.7]: https://github.com/pabllopf/Alis/compare/v0.0.6...v0.0.7
[v0.0.8]: https://github.com/pabllopf/Alis/compare/v0.0.7...v0.0.8
[v0.0.9]: https://github.com/pabllopf/Alis/compare/v0.0.8...v0.0.9
[v0.1.0]: https://github.com/pabllopf/Alis/compare/v0.0.9...v0.1.0
[v0.1.1]: https://github.com/pabllopf/Alis/compare/v0.1.0...v0.1.1
[v0.1.2]: https://github.com/pabllopf/Alis/compare/v0.1.1...v0.1.2
[v0.1.3]: https://github.com/pabllopf/Alis/compare/v0.1.2...v0.1.3
[v0.1.4]: https://github.com/pabllopf/Alis/compare/v0.1.3...v0.1.4
[v0.1.5]: https://github.com/pabllopf/Alis/compare/v0.1.4...v0.1.5
[v0.1.6]: https://github.com/pabllopf/Alis/compare/v0.1.5...v0.1.6
[v0.1.7]: https://github.com/pabllopf/Alis/compare/v0.1.6...v0.1.7

[v0.1.8]: https://github.com/pabllopf/Alis/compare/v0.1.7...v0.1.8
[v0.1.9]: https://github.com/pabllopf/Alis/compare/v0.1.8...v0.1.9