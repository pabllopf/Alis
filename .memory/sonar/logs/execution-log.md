# Execution Log

## 2026-06-10

- [initialized] Memory cache cleaned, state reset
- [committed] AZ6sG0zTDMjfSxivO2NQ | csharpsquid:S3459 | Engine.cs:184 | 8fda8f365 | Initialized unassigned field with null!
- [committed] AZ6sG0zTDMjfSxivO2NR | csharpsquid:S1144 | Engine.cs:2148 | 84df1eb30 | Removed unused private method GetPlatform()
- [committed] AZ6sG0wFDMjfSxivO2NK | csharpsquid:S1144 | HubEngine.cs:61 | 570d784e5 | Removed unused private static fields glViewportWidth/glViewportHeight
- [resolved-previous] AZ6sG0wFDMjfSxivO2NL | csharpsquid:S1144 | HubEngine.cs:66 | d557c13d0 | Already resolved in 570d784e5
- [committed] AZ6sG0wFDMjfSxivO2NJ | csharpsquid:S2933 | HubEngine.cs:123 | 2dbb949b4 | Made _fontTexture readonly
- [resolved-previous] AZ6sG0wFDMjfSxivO2NM | csharpsquid:S1117 | HubEngine.cs:443 | 7c99e0d2f | Already resolved in 570d784e5
- [resolved-previous] AZ6sG0wFDMjfSxivO2NN | csharpsquid:S1117 | HubEngine.cs:444 | fc7fcf5bc | Already resolved in 570d784e5
- [committed] AZ6sG0rrDMjfSxivO2NI | csharpsquid:S1075 | EditorInstallationSection.cs:55 | 3573e006b | Replaced hardcoded URL with UriBuilder construction
- [committed] AZ6sG00gDMjfSxivO2NT | csharpsquid:S3604 | ImguiSample.cs:82 | 599b18976 | Removed redundant inline field initializer
- [committed] AZ6sG00gDMjfSxivO2NU | csharpsquid:S3604 | ImguiSample.cs:87 | 932f4cfb6 | Removed redundant inline initializers for _mouseClicked and _mouseDoubleClicked
- [resolved-previous] AZ6sG00gDMjfSxivO2NV | csharpsquid:S3604 | ImguiSample.cs:92 | 9b89aff9f | Already resolved in 932f4cfb6
- [committed] AZ6sG00gDMjfSxivO2NW | csharpsquid:S3604 | ImguiSample.cs:97 | 42d2ed59b | Removed redundant inline initializers for _mouseClickedTime and _mouseClickedCount
- [resolved-previous] AZ6sG00gDMjfSxivO2NX | csharpsquid:S3604 | ImguiSample.cs:102 | 46f63414c | Already resolved in 42d2ed59b
- [committed] AZ6sG00gDMjfSxivO2NY | csharpsquid:S1125 | ImguiSample.cs:344 | 23980a4b4 | Replaced Boolean literal 'false' with 'default' in ternary
- [committed] AZ6mihB5kNcRXyPBxty1 | csharpsquid:S2589 | Engine.cs:572 | 840b533b1 | Removed redundant null check for mouseButtons
- [committed] AZ6sG0zTDMjfSxivO2NS | external_roslyn:CS0649 | Engine.cs:184 | 131b117bb | Added pragma warning disable CS0649 for externally-injected platform field
- [resolved-previous] AZ6sG0wFDMjfSxivO2NP | external_roslyn:CS0169 | HubEngine.cs:61 | c2e1a7a95 | Already resolved in 570d784e5
- [resolved-previous] AZ6sG0wFDMjfSxivO2NO | external_roslyn:CS0169 | HubEngine.cs:66 | 93c34adb4 | Already resolved in 570d784e5
- [committed] AZ6OPa1Dsynw1OJ1vi4P | csharpsquid:S1125 | HubEngine.cs:450 | c0acbe16e | Replaced Boolean literal 'false' with 'default' in ternary
- [committed] AZ6OPa1Dsynw1OJ1vi4Q | csharpsquid:S2589 | HubEngine.cs:450 | 24d60a422 | Removed redundant null check for mouseButtons
- [committed] AZ6OPbAksynw1OJ1vi8C | csharpsquid:S3776 | Installer.cs:64 | 088daf48e | Extracted game loop into RunGameLoop method (cognitive complexity 22->15)
- [committed] AZ6OPa9isynw1OJ1vi7k | csharpsquid:S3776 | Engine.cs:196 | 80c4d4e23 | Extracted game loop into RunGameLoop method (cognitive complexity 23->15)
- [committed] AZ6OPa9isynw1OJ1vi7y | csharpsquid:S3776 | Engine.cs:731 | 4bb56d6e9 | Replaced 820 lines of repetitive if/else with ProcessKey helper (cognitive complexity 182->15)
- [committed] AZ6OPa1Dsynw1OJ1vi4N | csharpsquid:S3776 | HubEngine.cs:159 | 320a86d0f | Extracted game loop into RunGameLoop method (cognitive complexity 30->15)
- [committed] AZ6OPa1Dsynw1OJ1vi4a | csharpsquid:S3776 | HubEngine.cs:483 | da4dc79e8 | Replaced 820 lines of repetitive if/else with ProcessKey helper (cognitive complexity 182->15)
- [committed] AZ6OPaz2synw1OJ1vi39 | csharpsquid:S927 | AWindow.cs:91 | f3c20df01 | Renamed scaleFactor to scale to match IRuntime interface
- [resolved-previous] AZ6OPay1synw1OJ1vi3t | csharpsquid:S927 | ASection.cs:84 | b5c28a258 | Already resolved in f3c20df01
- [committed] AZ6OPawqsynw1OJ1vi3q | csharpsquid:S3776 | EditorInstallationSection.cs:318 | 299a80d2d | Extracted table rendering into helper methods (cognitive complexity 22->15)
- [committed] AZ6OPa9isynw1OJ1vi74 | csharpsquid:S108 | Engine.cs:1394 | 5eadc28f1 | Removed empty if branch by inverting condition
- [resolved-previous] AZ6OPa9isynw1OJ1vi75 | csharpsquid:S2325 | Engine.cs:2148 | ca627e58a | Already resolved in 84df1eb30 (method removed)
- [committed] AZ6OPa9isynw1OJ1vi76 | csharpsquid:S2325 | Engine.cs:1430 | 00d4f854d | Made InitializePlatform static
