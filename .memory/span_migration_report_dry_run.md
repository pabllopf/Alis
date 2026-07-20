═══ SPAN MIGRATION REPORT (DRY RUN) ═══
DATE: 2026-07-20
MODE: --dry-run

OVERALL CANDIDATES: ~360
LAYERS WITH CANDIDATES: 1_Presentation, 2_Application, 4_Operation, 6_Ideation
LAYERS WITH NO CANDIDATES: 3_Structuration (no src .cs), 5_Declaration (no src .cs)

─────────────────────────────────────────
LAYER 1: 1_Presentation (~150+ candidates)
─────────────────────────────────────────

── High priority ──

1. Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs:563  byte[][] nativeLabelIds = new byte[labelIds.Length][]
   REASON: hot path, plot rendering — ~80+ occurrences across ImPlotP*.cs files

2. Extension/Graphic/Ui/src/ImGuiIOPtr.cs:700  List<bool> KeysDown { get; } → Span<bool>
   REASON: allocates List<bool>(512) per get, called every UI frame

3. Extension/Graphic/Ui/src/ImGuiIOPtr.cs:732  List<float> NavInputs { get; } → Span<float>
   REASON: allocates List<float> per get, UI hot path

4. Extension/Graphic/Ui/src/ImGuiP5.cs:1099  Combo(..., string[] items, ...) → ReadOnlySpan<string>
   REASON: byte[][] nativeLabel allocation in UI render path

5. Extension/Media/FFmpeg/src/Audio/AudioFrame.cs:170  byte[] GetSample(int, int) → void GetSample(Span<byte>)
   REASON: allocates per sample read; Span overload already exists at line 178

6. Extension/Media/FFmpeg/src/Video/VideoFrame.cs:176  byte[] GetPixels(x, y, len) → void GetPixels(Span<byte>)
   REASON: allocates per pixel read; Span overload already exists at line 184

7. Extension/Graphic/Sfml/src/Render/Image.cs:184  public byte[] Pixels { get; } → ReadOnlySpan<byte>
   REASON: allocates new byte[W*H*4] on every get

8. Extension/Graphic/Sfml/src/Audios/SoundRecorder.cs:261  short[] samplesArray = new short[nbSamples]
   REASON: per-audio-buffer allocation

9. Extension/Network/src/Internal/WebSocketFrameCommon.cs:86  ApplyMaskKey(byte[], byte[]) → ReadOnlySpan<byte>, Span<byte>
   REASON: network hot path

── Medium priority ──

1. Extension/Graphic/Glfw/src/GlfwNative.cs:1709  float[] GetJoystickAxes(Joystick) → void GetJoystickAxes(Span<float>)
   REASON: allocates new float[count]

2. Extension/Security/src/SecureRandom.cs:47-139  7× byte[] allocations → stackalloc byte[size]
   REASON: small fixed-size buffers

3. Extension/Thread/src/Scheduling/BatchPartitioner.cs:78  BatchPartition[] CreatePartitions() → void CreatePartitions(Span<BatchPartition>)
   REASON: partition array allocation

4. Extension/Network/src/HttpHelper.cs:164  IList<string> GetSubProtocols(string) → ReadOnlySpan<string>
   REASON: List<string> allocation

5. Engine/src/Engine.cs:603  int[] viewport = new int[4] → stackalloc int[4]
   REASON: per-render-frame allocation

6. Hub/src/HubEngine.cs:451  int[] viewport = new int[4] → stackalloc int[4]
   REASON: per-render-frame allocation

7. Extension/Graphic/Ui/src/ImGuiP5.cs:1101  byte[][] itemsNative = new byte[items.Length][] → ArrayPool or pinned
   REASON: UI Combo hot path

8. Extension/Graphic/Ui/src/Extras/Node/ImNodes.cs:424  byte[] createdFromSnap = new byte[1] → stackalloc byte[1]
   REASON: small fixed alloc

9. Extension/Updater/src/UpdateManager.cs:855  byte[] buffer = new byte[4096] → ArrayPool<byte>.Shared.Rent
   REASON: stream copy buffer

── Low priority ──

1. Extension/Graphic/Ui/src/ImGuiNative.cs (all)  ~20× byte[] returns from PInvoke
   REASON: interop marshaling, cannot change

2. Extension/Graphic/Ui/src/ImGuiIO.cs  ~17× field arrays in struct layout
   REASON: PInvoke marshaling layout

3. Extension/Media/FFmpeg/src/BaseClasses/IMediaFrame.cs:42  byte[] RawData { get; } (interface)
   REASON: interface contract change affects all implementations

4. Extension/Graphic/Sdl2/src  ~100× PInvoke signatures
   REASON: interop marshaling

── Blocked ──

1. Extension/Media/FFmpeg/src/Audio/AudioFrame.cs:49  private byte[] frameBuffer;
   BLOCKER: backing field for RawData, exposed via property
   SUGGESTION: change field to byte[] but add ReadOnlySpan<byte> RawData accessor

2. Extension/Graphic/Sfml/src/Render/Image.cs:184  public byte[] Pixels { get; }
   BLOCKER: public API, external consumers depend on array access
   SUGGESTION: add ReadOnlySpan<byte> PixelsSpan { get; }, keep original

3. Extension/Network/src/PublicBufferMemoryStream.cs:207  byte[] GetBuffer() → stream contract requires array
   BLOCKER: overrides Stream.GetBuffer(), must match base class signature
   SUGGESTION: add Span<byte> GetBufferSpan() as extension

─────────────────────────────────────────
LAYER 2: 2_Application (56 candidates)
─────────────────────────────────────────

── High priority ──

1. Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs:196  HashSet<ConsoleKey> allocation per frame
   REASON: LINQ + HashSet alloc in OnDraw() hot path — 3× per frame
   FIX: use ISet<ConsoleKey> destination overloads (already exist at lines 292, 312, 332)

2. Alis/src/Core/Ecs/Systems/Execution/InternalRuntime.cs:49  List<T> runtimes field → T[] or ReadOnlySpan<T>
   REASON: ForEach called in 24 methods (all game-loop callbacks), every frame

3. Alis/src/Core/Ecs/Components/Render/Animator.cs:45  List<Animation> Animations { get; } → ReadOnlySpan<Animation>
   REASON: accessed every frame in OnUpdate()

4. Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs:54  float[] _rectVerticesCache → Span<float> from stackalloc
   REASON: written every RenderBoxCollider call (per frame)

── Medium priority ──

1. Alis/src/Core/Ecs/Systems/Manager/Scene/SceneManager.cs:80  IReadOnlyList<Ecs.Scene> LoadedScenes → ReadOnlySpan<Ecs.Scene>
   REASON: wraps List<T>, accessed during scene transitions

2. Alis/src/Core/Ecs/Components/Render/Animation.cs:89  List<Frame> Frames { get; set; }
   REASON: property returning List<Frame>

3. Alis/src/Core/Ecs/Systems/Manager/Scene/ScenesMap.cs:43  List<int> Scenes { get; set; }
   REASON: property returning List<int>

── Blocked ──

1. Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs:285  HashSet<ConsoleKey> ComputePressedKeys(...)
   BLOCKER: returns HashSet, used in hot path (line 198)
   SUGGESTION: use existing ISet<ConsoleKey> overload instead

─────────────────────────────────────────
LAYER 3: 3_Structuration (0 candidates)
─────────────────────────────────────────

No .cs source files in src/ — module is an MSBuild shim that links sources from 4_Operation and 6_Ideation.

─────────────────────────────────────────
LAYER 4: 4_Operation (~105+ candidates)
─────────────────────────────────────────

── High priority ──

1. Graphic/src/OpenGL/Gl.cs:101  static uint[] Uint1 = new uint[1] → static Span<uint>
   REASON: used in every GenBuffer/GenTexture call (per frame)

2. Graphic/src/OpenGL/Gl.cs:106  static int[] Int1 = new int[1] → static Span<int>
   REASON: used in every GetShaderiv/GetProgramiv call (per frame)

3. Graphic/src/OpenGL/Gl.cs:111  static float[] Matrix4Float = new float[16] → static Span<float>
   REASON: uniform uploads every draw call

4. Ecs/src/Collections/SparseSet.cs:45  T[] _dense + int[] _sparse → Span<T>, Span<int>
   REASON: ECS internal data structure, every entity lookup

5. Ecs/src/Collections/ShortSparseSet.cs:49  T[] _dense → Span<T>
   REASON: used in SceneUpdateFilter hot path

6. Ecs/src/Collections/FastLookup.cs:51  Archetype[] Archetypes = new Archetype[8]
   REASON: archetype lookup in every query

7. Ecs/src/Kernel/Archetypes/Archetype.cs:100  GameObjectIdOnly[] _entities → Span<GameObjectIdOnly>
   REASON: allocated per archetype, accessed every ECS tick

8. Ecs/src/Kernel/Archetypes/Archetype.cs:675  byte[] componentTable = new byte[...]
   REASON: per-archetype component tag table

9. Ecs/src/Collections/Chunk.cs:50  TData[] Buffer → Span<TData>
   REASON: every archetype chunk storage

10. Ecs/src/Updating/SceneUpdateFilter.cs:62  ComponentStorageBase[] _allComponents → Span<ComponentStorageBase>
    REASON: per-filter array, accessed every system run

11. Physic/src/Dynamics/Island.cs:71-131  Body[], Contact[], Joint[], int[] Locks, SolverPosition[], SolverVelocity[]
    REASON: physics solver arrays, accessed every frame in simulation

12. Physic/src/Dynamics/Contacts/ContactSolver.cs:94-124  Contact[], ContactPositionConstraint[], SolverPosition[], SolverVelocity[], int[] Locks
    REASON: solver arrays, reset per frame

13. Physic/src/Collisions/DynamicTreeBroadPhase.cs:71  int[] _moveBuffer + Pair[] _pairBuffer
    REASON: broad phase collision detection (every frame)

14. Physic/src/Dynamics/WorldPhysic.cs:126  Body[] _stack = new Body[64]
    REASON: world body stack, collision processing

15. Physic/src/Dynamics/Fixture.cs:133  FixtureProxy[] Proxies { get; }
    REASON: fixture proxy array, accessed in collision detection

16. Physic/src/Common/Vertices.cs:52  class Vertices : List<Vector2F> → could use Span<Vector2F>
    REASON: used everywhere in physics

17. Graphic/src/Platforms/Web/EmscriptenWeb.cs:530  int[] GetConnectedGamepads() → Span<int>
    REASON: per-frame input polling

18. Graphic/src/Platforms/Web/EmscriptenWeb.cs:560  float[] GetGamepadAxes(int) → Span<float>
    REASON: per-frame gamepad input

19. Graphic/src/Platforms/Web/EmscriptenWeb.cs:590  bool[] GetGamepadButtons(int) → Span<bool>
    REASON: per-frame gamepad input

20. Graphic/src/Image.cs:67  byte[] Data { get; } → ReadOnlySpan<byte>
    REASON: pixel data used every frame by renderer

21. Graphic/src/Image.cs:112  byte[] rawData = new byte[height * width * 4]
    REASON: allocates pixel buffer on every LoadFromStream

22. Physic/src/Collisions/Shapes/PolygonShape.cs:391  float[] depths = new float[SettingEnv.MaxPolygonVertices]
    REASON: per-shape collision detection

── Medium priority ──

1. Ecs/src/Collections/FastestStack.cs:50  T[] _array → Span<T>
   REASON: component stacks/recycling

2. Ecs/src/Collections/FastestStack.cs:487  T[] ToArray() → CopyTo(Span<T>)
   REASON: called in query paths

3. Ecs/src/Collections/FastestTable.cs:50  T[] _buffer → Span<T>
   REASON: ID lookups in ECS

4. Ecs/src/Collections/FrugalStack.cs:50  T[] _buffer → Span<T>
   REASON: component command stack

5. Ecs/src/Collections/IDTable.cs:49  Array Buffer → Array + Span accessor
   REASON: base class for all component ID tables

6. Ecs/src/Redifinition/MemoryHelpers.cs:67  ComponentHandle[] sharedTempComponentHandleBuffer → ThreadStatic Span or ArrayPool
   REASON: hot path component handle buffer (LazyInitializer)

7. Ecs/src/Redifinition/MemoryHelpers.cs:82  ComponentStorageBase[] sharedTempComponentStorageBuffer → same pattern
   REASON: hot path component storage buffer

8. Physic/src/Common/PolygonManipulation/SimplifyTools.cs:87  bool[] usePoint = new bool[vertices.Count] → stackalloc or ArrayPool
   REASON: simplification algorithm, medium frequency

9. Physic/src/Common/ConvexHull/GiftWrap.cs:68  int[] hull = new int[vertices.Count] → stackalloc or ArrayPool
   REASON: convex hull computation

10. Physic/src/Common/Decomposition/EarclipDecomposer.cs:105  float[] xrem + yrem = new float[vertices.Count] → ArrayPool
    REASON: polygon decomposition

11. Physic/src/Controllers/GravityController.cs:175  List<Body> Bodies { get; set; } → could use collection expression or Span
    REASON: gravity controller body list

12. Audio/src/Players/BrowserPlayer.cs:239  bool TryParseWav(byte[] wav, ...) → ReadOnlySpan<byte>
    REASON: WAV parsing during Play()

13. Graphic/src/Platforms/Linux/LinuxNativePlatform.cs:80  bool[] mouseButtons = new bool[5] → stackalloc
    REASON: mouse state

── Blocked ──

1. Ecs/src/Collections/SparseSet.cs:55  internal int[] _sparse
   BLOCKER: field exposed via internal visibility, used by external consumers
   SUGGESTION: change backing to Span<int> or add Span accessor

2. Physic/src/Dynamics/FixtureCollection.cs:53  internal readonly List<Fixture> List
   BLOCKER: implements IList<Fixture> interface
   SUGGESTION: keep list, add Span<Fixture> accessor

3. Graphic/src/Image.cs:67  public byte[] Data { get; }
   BLOCKER: public API
   SUGGESTION: add ReadOnlySpan<byte> DataSpan { get; }

─────────────────────────────────────────
LAYER 5: 5_Declaration (0 candidates)
─────────────────────────────────────────

No .cs source files in src/ — module has no source code (MSBuild shim like 3_Structuration).

─────────────────────────────────────────
LAYER 6: 6_Ideation (46 candidates)
─────────────────────────────────────────

── High priority ──

1. Math/src/Collections/FastImmutableArray.cs:58-990  T[] _elements, new T[capacity], ToArray(), AddRange(params T[])
   REASON: core data structure used throughout framework — 25 high-priority candidates
   NOTE: Span overloads already exist for CopyTo() and AsSpan()

2. Memory/src/AssetRegistry.cs:207  byte[] buffer = pool.Rent(81920)
   REASON: hot path streaming read (GetMemoryStreamByResourceName)

3. Memory/src/AssetRegistry.cs:363  byte[] buffer = pool.Rent(81920)
   REASON: hot path ExtractResourceToTemp

4. Memory/src/AssetRegistry.cs:517  byte[] bytes = mem.ToArray()
   REASON: full archive content allocation — large allocation

5. Memory/src/ZipCacheEntry.cs:46  byte[] PackBytes { get; set; } → ReadOnlyMemory<byte>
   REASON: stores full assets.pack bytes

6. Math/src/Vector/Vector2F.cs:381  void CopyTo(float[] array) → already has Span overload at line 405
   REASON: array overload redundant for Span consumers

7. Math/src/Collections/FastImmutableArray.cs:380  void AddRange(params T[] items) → AddRange(ReadOnlySpan<T>)
   REASON: params forces allocation at callsite

8. Math/src/Collections/FastImmutableArray.cs:619  T[] ToArray() → CopyTo(Span<T>) or AsSpan()
   REASON: allocates on every call

── Medium priority ──

1. Memory/src/AssetRegistry.cs:437  byte[] keyBytes = Encoding.UTF8.GetBytes(key) → GetBytes(Span<byte>)
   REASON: SHA256 hashing; Span overload available on newer TFMs

2. Memory/src/AssetRegistry.cs:463  string ToLowerHex(byte[] bytes) → ReadOnlySpan<byte>
   REASON: parameter could accept span

3. Logging/src/Core/CoreLogger.cs:293  IReadOnlyList<object> GetCurrentScopes() → ReadOnlySpan<object>
   REASON: _scopeStack.ToArray() allocates on every scope read

4. Logging/src/MemoryLogOutput.cs:177  IReadOnlyList<ILogEntry> GetEntries() → ReadOnlySpan<ILogEntry>
   REASON: _entries.ToArray() allocates on every call

5. Math/src/HashCode.cs:99  byte[] randomBytes = new byte[sizeof(uint)] (fallback)
   REASON: net6.0+ already uses stackalloc; only older TFM fallback

6. Math/src/RandomUtils.cs:66,92  byte[] buffer = new byte[4] (fallback)
   REASON: net6.0+ already uses stackalloc; only older TFM fallback

── Blocked ──

1. Math/src/Collections/FastImmutableArray.cs:1007  internal readonly T[] Array (struct field)
   BLOCKER: public struct, breaking change
   SUGGESTION: keep field but add ReadOnlySpan<T> AsSpan() (already exists at line 965)

2. Memory/src/ZipCacheEntry.cs:46  byte[] PackBytes { get; set; }
   BLOCKER: public property
   SUGGESTION: add ReadOnlyMemory<byte> PackBytesMemory { get; }

─────────────────────────────────────────
SUMMARY BY PRIORITY
─────────────────────────────────────────

HIGH PRIORITY:      ~120 candidates
  - Per-frame allocations (ECS, physics, rendering, input)
  - Core data structures (SparseSet, FastImmutableArray, Archetype)
  - Large buffer allocations (AssetRegistry, Image loading)
  - Hot path methods with alloc per call (GetSample, GetPixels, GetGamepadAxes)

MEDIUM PRIORITY:    ~150 candidates
  - Internal properties returning List<T>/T[]
  - Small buffer allocations (int[4], byte[1], bool[5]) → stackalloc
  - Fallback paths for older TFMs
  - Buffer copies (stream reads) → ArrayPool

LOW PRIORITY:       ~90 candidates
  - PInvoke signatures (cannot change)
  - Struct layout fields (ImGuiIO)
  - Demo/benchmark code
  - One-time startup allocations

BLOCKED:            ~15 candidates
  - Public API surface (must preserve backward compat)
  - Interface contracts (IMediaFrame, ILogEntry)
  - Base class overrides (Stream.GetBuffer)

─────────────────────────────────────────
TOP 10 MOST IMPACTFUL MIGRATIONS
─────────────────────────────────────────

1. 4_Operation/Ecs/src/Collections/SparseSet.cs — T[] _dense + int[] _sparse to Span<T>/Span<int>
   IMPACT: eliminates alloc per entity lookup in entire ECS

2. 4_Operation/Physic/src/Dynamics/Island.cs — Body[], Contact[], SolverPosition[], SolverVelocity[] to ArrayPool-backed Span
   IMPACT: eliminates massive solver allocation per physics frame

3. 4_Operation/Graphic/src/OpenGL/Gl.cs — static uint[1], int[1], float[16] to static Span
   IMPACT: eliminates per-draw-call alloc in rendering

4. 6_Ideation/Math/src/Collections/FastImmutableArray.cs — AddRange(params T[]) → AddRange(ReadOnlySpan<T>)
   IMPACT: core collection, used everywhere

5. 1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs — List<bool>/List<float> properties → Span
   IMPACT: 6 allocations per UI frame eliminated

6. 4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs — componentTable byte[] → ArrayPool
   IMPACT: per-archetype allocation reduction

7. 2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs — HashSet allocations per frame → use existing ISet overloads
   IMPACT: 3 HashSet allocs per frame eliminated

8. 4_Operation/Physic/src/Collisions/DynamicTreeBroadPhase.cs — _moveBuffer + _pairBuffer → ArrayPool
   IMPACT: broad phase collision alloc reduction

9. 6_Ideation/Memory/src/AssetRegistry.cs — mem.ToArray() → ArrayPool
   IMPACT: large archive alloc eliminated

10. 1_Presentation/Extension/Graphic/Sfml/src/Render/Image.cs — byte[] Pixels get → ReadOnlySpan<byte>
    IMPACT: massive W*H*4 alloc per property access eliminated
