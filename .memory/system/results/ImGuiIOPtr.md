# Result: ImGuiIOPtr.cs

File:
pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs

CoverageBefore:
0.0% (SonarCloud, stale)

CoverageAfter:
96.52% (measured locally, existing tests)

TestsAdded:
0

Commit:
none

Status:
BLOCKED_BY_PRODUCTION_CODE

Reason:
File already covered 96.52% by 924 existing passing tests. Remaining 24 uncovered lines
are the happy-path bodies of the KeysData, MouseClickedPos and MouseDragMaxDistanceAbs
getters, whose Marshal.OffsetOf<ImGuiIo>("...") calls always throw ArgumentException
because the ImGuiIo struct exposes per-index properties (KeysData0..KeysDataN) and no
fields named KeysData / MouseClickedPos / MouseDragMaxDistanceAbs. The throw path is
already asserted by existing tests. Covering the happy path requires fixing the field
names in src (production change, forbidden by policy).
