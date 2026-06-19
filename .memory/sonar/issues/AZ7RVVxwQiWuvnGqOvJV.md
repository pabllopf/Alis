# Issue: AZ7RVVxwQiWuvnGqOvJV

- Rule: external_roslyn:RS2007
- Severity: MAJOR
- Component: pabllopf-official_alis:4_Operation/Ecs/generator/AnalyzerReleases.Unshipped.md
- Line: 1
- Status: OPEN
- Resolution: None
- Message: Analyzer release file 'AnalyzerReleases.Unshipped.md' has a missing or invalid release header '## Unshipped'

## Code Snippet

```markdown
## Unshipped

| Rule ID | Category | Severity | Notes |
```

## Root Cause

File `AnalyzerReleases.Unshipped.md` was missing the required comment header (`;` lines) before the `## Unshipped` release header. The Roslyn SDK analyzer (RS2007) requires the file to start with comment lines documenting the expected format before the `## Unshipped` section header.

## Fix

Added standard comment header before `## Unshipped` with format documentation comments (lines starting with `;`).

## Commit

`fix: sonarAZ7RVVxwQiWuvnGqOvJV AnalyzerReleases.Unshipped.md`

