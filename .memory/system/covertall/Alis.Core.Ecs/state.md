# Project Coverage State

Project:
./4_Operation/Ecs/src/Alis.Core.Ecs.csproj

Test project:
./4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj

Status:
COMPLETED

Agent:
covertall-agent-001

Started:
2026-08-16T21:45:00Z

Last update:
2026-08-16T22:10:00Z

Initial coverage:
98.90% (13138/13284 lines)

Current coverage:
99.02% (13154/13284 lines)

Tests before:
~2100 (full suite)

Tests after:
unchanged (investigation only; CommandBuffer 343-347 already covered by
existing AddComponent_WithOnComponentAddedEvent_Fires test - the baseline
was stale)

Files modified:
- none

Coverage work:
- Re-ran a fresh coverage measurement: 99.02% (baseline was stale).
- FastestStack enumerator version-check throws (576-577, 646-647): wrote 7
  tests, then discovered the Enumerator holds a struct COPY of the stack
  (_fastestStack field), so _version can never differ from the captured
  version - the throws are unreachable dead code. Tests removed.
- Remaining uncovered lines assessed:
  - GameObject.cs:188, CommandBuffer.cs:363: coverlet closing-brace line
    artifacts; the throw statements (187, 362) are covered by existing tests.
  - GameObjectExtensions.cs:248-251: GetComp is AggressiveInlining; all 8
    Deconstruct arities are tested and pass, coverlet attributes hits to
    call sites. Inlining artifact.
  - Scene.cs:635-637, 680-682: recursion-limit throws requiring 200+
    nested command-buffer/deferred-creation operations - impractical.
  - Gen2GcCallback.cs:105-112, 165-201: finalizer + GC-timing dependent,
    non-deterministic.
  - ComponentRegistry.cs:85, 100, 141-142, 184-185, 229: unreachable
    return-null!-after-throw and 65535-component-limit paths.
  - EnumerableHelpers.cs:142-144: arrayMaxLength (0x7FFFFFC7) overflow -
    needs 2B+ elements.
  - FastestStack.cs:465-467: Grow MaxArrayLength (0x7FEFFFFF) overflow.

Remaining opportunities:
- none within unit-test scope; all remaining lines are dead code, inlining
  artifacts, or impractical boundaries.

Last commit:
none (no test changes)

Attempts:
1