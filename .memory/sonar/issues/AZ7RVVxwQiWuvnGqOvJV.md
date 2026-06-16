# Issue: AZ7RVVxwQiWuvnGqOvJV

- **Rule**: external_roslyn:RS2007
- **File**: 4_Operation/Ecs/generator/AnalyzerReleases.Unshipped.md
- **Line**: 1
- **Severity**: MAJOR
- **Status**: FIXED
- **Commit**: 39f93e83c

## Description

Analyzer release file 'AnalyzerReleases.Unshipped.md' has a missing or invalid release header '## Unshipped'

## Fix Applied

Updated AnalyzerReleases.Unshipped.md with proper Roslyn-formatted table including all ALIS001-ALIS010 rules. Created corresponding AnalyzerReleases.Shipped.md and Unshipped.md files in 6_Ideation/Fluent/generator/ directory.

## Learnings

- RS2007 requires proper table format with all 5 columns (Rule ID, Category, Severity, Notes)
- Both Shipped and Unshipped files must exist in analyzer projects
- Projects with EnableAnalyzerReleaseTracking=true require these files
