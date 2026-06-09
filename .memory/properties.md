---
status: draft

license: GPLv3
---

# ALIS Memory System - Global Properties

## Overview
This document defines the global properties and metadata schema for organizing the ALIS Memory System. These properties enhance accessibility for both humans and AI models.

## File Properties Schema

### Core Properties (Required for all files)

| Property | Type | Description | Example |
|----------|------|-------------|---------|
| `title` | string | Human-readable title | "ALIS Memory Index" |
| `tags` | array | Categorization tags | `[documentation, reference]` |
| `type` | string | Document type | `index`, `concept`, `project`, `decision`, `glossary` |
| `status` | string | Document status | `active`, `archived`, `draft`, `deprecated` |
| `version` | string | Document version | `1.0.0` |
| `lastUpdated` | date | Last modification date | `2026-06-09` |

### Metadata Properties (Recommended)

| Property | Type | Description | Example |
|----------|------|-------------|---------|
| `author` | string | Document author | "Pablo Perdomo Falcón" |
| `license` | string | License type | "GPLv3" |
| `repository` | string | Source repository URL | "https://github.com/pabllopf/Alis" |
| `weight` | number | Importance/priority (0-100) | `85` |
| `accessibility` | string | Access level | `public`, `internal`, `private` |
| `language` | string | Document language | `en`, `es` |

### AI-Optimized Properties

| Property | Type | Description | Example |
|----------|------|-------------|---------|
| `ai-summary` | string | AI-generated summary | "ALIS is a cross-platform C# game engine..." |
| `ai-keywords` | array | AI-extracted keywords | `["game engine", "C#", "AOT"]` |
| `ai-confidence` | number | AI confidence score (0-1) | `0.95` |
| `ai-context` | string | AI context tags | `architecture, documentation, reference` |
| `ai-priority` | string | AI processing priority | `high`, `medium`, `low` |

### Relationship Properties

| Property | Type | Description | Example |
|----------|------|-------------|---------|
| `related` | array | Related document links | `[[Alis Architecture Overview]]` |
| `parent` | string | Parent document link | `[[ALIS Memory Index]]` |
| `child` | array | Child document links | `[[Concept 1]], [[Concept 2]]` |
| `references` | array | External references | `[[Alis.Core.Aspect.Data]]` |
| `dependsOn` | array | Dependencies | `[[Core]], [[Infrastructure]]` |

## Property Categories

### Document Types

| Type | Description | Directory |
|------|-------------|-----------|
| `index` | Root index and navigation | `.memory/` |
| `concept` | Theoretical concepts | `.memory/concepts/` |
| `project` | Project documentation | `.memory/projects/` |
| `glossary` | Terminology definitions | `.memory/glossary/` |
| `decision` | Architecture decisions | `.memory/decisions/` |
| `diagram` | Visual diagrams | `.memory/diagrams/` |
| `system` | System state/tracking | `.memory/system/` |
| `sample` | Code samples | `.memory/samples/` |
| `extension` | Plugin/extension docs | `.memory/extensions/` |
| `application` | Application docs | `.memory/applications/` |

### Status Values

| Status | Description | Usage |
|--------|-------------|-------|
| `active` | Currently maintained | Most documentation |
| `archived` | No longer maintained | Old versions |
| `draft` | Work in progress | New features |
| `deprecated` | Replaced by newer version | Legacy code |

### Access Levels

| Level | Description | Use Case |
|-------|-------------|----------|
| `public` | Open to all | General documentation |
| `internal` | Team only | Internal processes |
| `private` | Restricted | Sensitive information |

## Property Usage Examples

### Example 1: Index File
```yaml
---
title: ALIS Memory Index
type: index
status: active
version: 1.1.0
lastUpdated: 2026-06-09
author: Pablo Perdomo Falcón
license: GPLv3
repository: https://github.com/pabllopf/Alis
tags:
  - documentation
  - reference
  - index
accessibility: public
weight: 100
ai-summary: "ALIS Memory Index - Complete documentation for ALIS Game Engine Framework"
ai-keywords: ["memory system", "documentation", "index"]
ai-confidence: 1.0
ai-priority: high
---
```

### Example 2: Project Documentation
```yaml
---
title: Alis.Core.Aspect.Data
type: project
status: active
version: 1.0.0
lastUpdated: 2026-06-09
author: Pablo Perdomo Falcón
license: GPLv3
tags:
  - domain
  - api
  - reference
  - documentation
accessibility: public
weight: 85
ai-summary: "JSON serialization library for AOT environments"
ai-keywords: ["JSON", "serialization", "AOT", "reflection-free"]
ai-confidence: 0.95
ai-priority: high
related: [[ALIS Memory Index]]
dependsOn: [[Alis.Core.Aspect]]
---
```

### Example 3: Concept Documentation
```yaml
---
title: ALIS Architecture Overview
type: concept
status: active
version: 1.0.0
lastUpdated: 2026-06-09
author: Pablo Perdomo Falcón
tags:
  - concept
  - theory
  - architecture
  - documentation
accessibility: public
weight: 90
ai-summary: "Overview of ALIS Game Engine Framework architecture"
ai-keywords: ["architecture", "design patterns", "layers"]
ai-confidence: 0.92
ai-context: architecture, design, theory
parent: [[ALIS Memory Index]]
---
```

## Implementation Guidelines

### For Humans
1. Use clear, descriptive titles
2. Add relevant tags for categorization
3. Maintain proper status and version tracking
4. Link related documents using wiki-links
5. Include author and date information

### For AI Models
1. Provide AI-optimized properties for better understanding
2. Use consistent keyword extraction
3. Maintain confidence scores for AI-generated content
4. Include context tags for better retrieval
5. Set priority levels for processing order

### For Automated Tools
1. Validate required properties before processing
2. Use status for lifecycle management
3. Leverage tags for filtering and grouping
4. Track versions for change management
5. Monitor dependencies for impact analysis

## Property Validation Rules

1. **Required Properties**: `title`, `tags`, `type`
2. **Date Format**: `YYYY-MM-DD` for `lastUpdated`
3. **Version Format**: `X.Y.Z` semantic versioning
4. **Tag Format**: Lowercase, hyphen-separated, no spaces
5. **Link Format**: `[[Document Title]]` wiki-link syntax
6. **Number Range**: `weight` and `confidence` must be 0-100 or 0-1

## Maintenance

- Review and update `lastUpdated` dates monthly
- Archive deprecated documents with `status: archived`
- Update `ai-confidence` scores after AI processing
- Validate all links quarterly
- Backup property schemas annually

## Future Enhancements

- Add support for multi-language properties
- Implement property inheritance from parent documents
- Create property templates for common document types
- Add automated property validation tools
- Develop property visualization dashboards
