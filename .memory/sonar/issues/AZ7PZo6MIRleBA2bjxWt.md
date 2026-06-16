---
id: AZ7PZo6MIRleBA2bjxWt
rule: external_roslyn:RS2008
file: 4_Operation/Ecs/generator/GeneratorAnalyzer.cs
line: 53
severity: MAJOR
status: PROCESSING
---

## ISSUE: RS2008

- File: 4_Operation/Ecs/generator/GeneratorAnalyzer.cs
- Line: 53
- Severity: MAJOR
- Description: Enable analyzer release tracking for the analyzer project containing rule 'FR0000'

### Analysis

The `NonPartialGenericComponent` DiagnosticDescriptor at line 53 uses rule ID "FR0000". RS2008 requires release tracking for analyzer rules. Since these are internal source generator rules, the fix is to suppress RS2008 at the file level with a justification.
