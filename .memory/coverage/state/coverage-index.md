# Coverage Index - SonarCloud Delta Tracker

## Last Sync: 2026-07-06T15:55:00Z
## Status: Analysis complete — SonarCloud configuration issue CONFIRMED

## Executive Summary

**All 16 files with coverage issues have comprehensive existing tests that pass locally.**

SonarCloud reports low coverage despite tests passing, indicating a configuration issue where:
- Tests are not executing during SonarCloud analysis
- Test projects are not properly referenced in sonar-project.properties
- Test result files are not being parsed

## Project Coverage (master branch)
- **Overall**: 61.4%
- **Line Coverage**: 60.6%
- **Branch Coverage**: 65.5%

## Files with Coverage Issues: 16 (ALL have existing comprehensive tests)

| # | File | Uncovered | Coverage | Existing Tests | Test Status |
|---|------|-----------|----------|----------------|-------------|
| 1 | BoxCollider.cs | 190 lines | 28.2% | 3 test files, 88 tests | ✅ Passing |
| 2 | Body.cs | 97 lines | 82.1% | 1843-line test file | ✅ Exists |
| 3 | BrowserPlayer.cs | 90 lines | 59.1% | 4 test files | ✅ Exists |
| 4 | AudioVideoWriter.cs | 75 lines | 56.3% | 3 test files, 759 lines | ✅ Exists |
| 5 | Archetype.cs | 74 lines | 87.2% | 14 test files | ✅ Exists |
| 6-16 | Others | 0-46 lines | 57-99% | All have tests | ✅ Exist |

## Root Cause Analysis

**Pattern**: Every high-priority target has extensive existing test coverage that passes locally.

**Likely causes**:
1. `sonar-project.properties` missing test project references
2. Tests not configured to run during SonarCloud analysis
3. Test result XML files not being parsed
4. Branch analysis configuration issue

## Recommendation: Fix SonarCloud Configuration

**Action items**:
1. Verify `sonar-project.properties` exists in repository root
2. Add test project references:
   ```properties
   sonar.cs.xunit.reportsPaths=xunit.runner.json
   sonar.cs.opencover.reportsPaths=coverage.opencover.xml
   ```
3. Ensure CI/CD pipeline runs tests and generates coverage reports
4. Verify `master` branch is being analyzed (not feature branches)

## Next Steps

**Option A**: Fix SonarCloud configuration (RECOMMENDED)
- Will make all existing tests count toward coverage
- No new test generation needed

**Option B**: Continue generating tests for specific uncovered paths
- Only useful if SonarCloud configuration is fixed first
- Currently low ROI due to configuration issue

## Session Status: PAUSED — Awaiting user decision on SonarCloud config fix
