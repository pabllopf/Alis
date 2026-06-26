# Coverage Remediation State

**Project**: pabllopf-official_alis
**Branch**: master
**Last Sync**: 2025-06-26T00:00:00Z
**Overall Coverage**: 59.3% (line: 58.7%, branch: 62.7%)

## Files Below 100% Coverage (14 total)

### CRITICAL (< 60%) — 3 files
| File | Coverage | Lines Uncovered | Conditions | Status |
|------|----------|-----------------|------------|--------|
| AudioVideoWriter.cs | 54.0% | 79 | 76 | PENDING |
| AudioWriter.cs | 54.0% | 50 | 54 | PENDING |
| AudioReader.cs | 56.3% | 53 | 48 | PENDING |

### MEDIUM (70-85%) — 2 files
| File | Coverage | Lines Uncovered | Conditions | Status |
|------|----------|-----------------|------------|--------|
| AudioPlayer.cs | 79.3% | TBD | TBD | PENDING |
| Body.cs | 82.0% | TBD | TBD | PENDING |

### HIGH (85-95%) — 5 files
| File | Coverage | Status |
|------|----------|--------|
| Archetype.cs | 86.4% | PENDING |
| AssetRegistry.cs | 90.3% | PENDING |
| AdsManager.cs | 91.0% | PENDING |
| Body.Factory.cs | 92.0% | PENDING |
| BayazitDecomposer.cs | 93.9% | PENDING |

### NEAR-COMPLETE (95-100%) — 4 files
| File | Coverage | Status |
|------|----------|--------|
| AudioSource.cs | 95.3% | PENDING |
| BinaryReaderWriter.cs | 96.6% | PENDING |
| Animator.cs | 97.8% | PENDING |
| BoardBuilder.cs | 99.5% | PENDING |

## Processing Rules
- Process MEDIUM priority first (AudioPlayer, Body) before CRITICAL FFmpeg files
- FFmpeg files require FFmpeg binary installed
- Focus on testable targets first (Archetype, Body, BayazitDecomposer)
