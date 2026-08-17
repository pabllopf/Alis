# Project Coverage State

Project:
./2_Application/Alis/src/Alis.csproj

Test project:
./2_Application/Alis/test/Alis.Test.csproj

Status:
COMPLETED

Agent:
covertall-agent-alis-001

Started:
2026-08-17T10:23:32Z

Last update:
2026-08-17T10:40:00Z

Initial coverage:
91.91% lines (4110/4472) measured at baseline

Current coverage:
91.91%

Tests before:
946 (3 pre-existing failures in GraphicManagerBootstrapTests)

Tests after:
946 (unchanged)

Files modified:
- none

Coverage work:
- Measured full-project coverage via coverlet. Remaining uncovered lines:
  1. BoxCollider.cs (106 lines): OnCollision/OnSeparation second branches
     (lines 325-336, 365-376) are defensive mirror branches - the physics
     engine always invokes a body's own handler with its own fixture first
     (Contact.ReportCollision), so fixtureGameObject always equals
     ThisGameObject and the first branch always wins; the second branch is
     unreachable through the public API. Render/InitializeShaders paths
     (412-536) and static Vertices (54-59) require a live OpenGL context;
     GL calls abort the test host (documented repo-wide limitation).
  2. GraphicManager.cs (74 lines): OnInit/OnDraw/BuildNewKeys/
     RenderBoxColliders (132-169, 201-254, 295-306, 434-436) all create a
     native platform window or call GL - require a live display.
  3. VideoGameBuilder.cs line 110: Run() starts the game loop - not
     unit-testable.

Remaining opportunities:
- none within unit-test scope. All GL/native paths and defensive branches
  documented above are not safely testable in this environment.

Last commit:
none (no meaningful coverage improvement possible)

Attempts:
1

## Notes

- 3 pre-existing test failures (GraphicManagerBootstrapTests) occur because
  the process startup hook is not installed in this environment
  (StartupHook.cs exists in test/, but bootstrap requires a native graphics
  hook); these fail before and after, unrelated to coverage work.
- The 31 src files absent from the coverage report are interfaces, delegates,
  or empty structs (e.g. CircleCollider, Canvas, lights) - no executable code.
