---
status: Draft

license: GPLv3

---

# ALIS Memory System - Global Index

> **Version**: 1.2.0 | **Author**: Pablo Perdomo Falcón | **License**: GPLv3  
> **Repository**: https://github.com/pabllopf/Alis | **Website**: www.alisengine.com  
> **Status**: **ACTIVE** ✓ | **Last Updated**: 2026-06-09

## Overview

This directory contains the complete **ALIS Memory System** — a cross-platform C# game engine framework with **140+ projects** organized across **6 architectural layers** and **40+ directories**.

## System Statistics

| Metric                   | Value                         |
| ------------------------ | ----------------------------- |
| **Total Files**          | 425 markdown files            |
| **Total Directories**    | 40+ directories               |
| **Total Projects**       | 140+ projects                 |
| **Architectural Layers** | 6 layers                      |
| **Framework Targets**    | 15+ frameworks                |
| **Documentation Type**   | YAML frontmatter + wiki-links |

## Property System

### Core Properties (Required)

| Property | Type | Description |
|----------|------|-------------|
| `title` | string | Human-readable document title |
| `tags` | array | Categorization tags (lowercase, hyphen-separated) |
| `type` | string | Document type (index, concept, project, etc.) |

### Metadata Properties (Recommended)

| Property | Type | Description |
|----------|------|-------------|
| `status` | string | Document lifecycle status (active, archived, draft, deprecated) |
| `version` | string | Semantic versioning (X.Y.Z) |
| `lastUpdated` | date | Last modification date (YYYY-MM-DD) |
| `author` | string | Document author name |
| `license` | string | License type (GPLv3) |
| `repository` | string | Source repository URL |
| `weight` | number | Importance/priority (0-100) |
| `accessibility` | string | Access level (public, internal, private) |
| `language` | string | Document language (en, es) |

### AI-Optimized Properties

| Property | Type | Description |
|----------|------|-------------|
| `ai-summary` | string | AI-generated summary (max 500 chars) |
| `ai-keywords` | array | AI-extracted keywords (max 10) |
| `ai-confidence` | number | AI confidence score (0.0-1.0) |
| `ai-context` | array | AI context categories |
| `ai-priority` | string | AI processing priority (high, medium, low) |

### Relationship Properties

| Property | Type | Description |
|----------|------|-------------|
| `related` | array | Related document wiki-links |
| `parent` | string | Parent document wiki-link |
| `child` | array | Child document wiki-links |
| `references` | array | External reference wiki-links |
| `dependsOn` | array | Dependencies wiki-links |

## Directory Structure

### Layer 1: Presentation (76 files)

| Directory | Files | Description |
|-----------|-------|-------------|
| `projects/1_Presentation/Engine` | 76 | ALIS Engine core documentation |

### Layer 2: Application (52 files)

| Directory | Files | Description |
|-----------|-------|-------------|
| `projects/2_Application/Samples` | 14 | Sample applications |
| `applications` | 5 | Application documentation |
| `samples` | 14 | Code samples and examples |

### Layer 3: Structuration (37 files)

| Directory | Files | Description |
|-----------|-------|-------------|
| `concepts` | 37 | Theoretical concepts and theories |
| `concepts/summaries` | 3 | Concept summaries |

### Layer 4: Operation (15 files)

| Directory | Files | Description |
|-----------|-------|-------------|
| `projects/4_Operation` | 15 | Runtime and implementation documentation |

### Layer 5: Declaration (6 files)

| Directory | Files | Description |
|-----------|-------|-------------|
| `projects/5_Declaration` | 6 | Contract and interface documentation |

### Layer 6: Ideation (15 files)

| Directory | Files | Description |
|-----------|-------|-------------|
| `projects/6_Ideation` | 15 | Experimental modules documentation |

### Domain Documentation

| Directory | Files | Description |
|-----------|-------|-------------|
| `domain/data` | 3 | JSON serialization library |
| `domain/fluent` | - | Fluent API builders |
| `domain/memory` | - | Memory management |
| `domain/time` | - | Time tracking |

### System State and Tracking

| Directory | Files | Description |
|-----------|-------|-------------|
| `system/state` | 18 | System state tracking |
| `system/indexes` | 18 | System indexes |
| `system/queues` | 12 | Work queues |
| `system/tracking` | 8 | Monitoring and tracking |
| `system/sessions` | 8 | Session management |
| `system/logs` | 7 | Execution logs |
| `system/checkpoints` | 7 | Validation checkpoints |

### Glossary and Concepts

| Directory | Files | Description |
|-----------|-------|-------------|
| `glossary` | 27 | Terminology definitions |
| `concepts` | 37 | Theoretical concepts |
| `concepts/summaries` | 3 | Concept summaries |

### Architecture and Decisions

| Directory | Files | Description |
|-----------|-------|-------------|
| `decisions` | - | Architecture decisions (ADRs) |
| `diagrams` | 9 | Visual diagrams and charts |
| `architecture` | 4 | Architecture documentation |
| `context` | 6 | Context and context analysis |

### Infrastructure and Support

| Directory | Files | Description |
|-----------|-------|-------------|
| `extensions` | 13 | Plugin and extension documentation |
| `sources` | 12 | Source references |
| `dependencies` | - | Dependency tracking |
| `infrastructure` | - | Infrastructure documentation |

### Testing and Quality

| Directory | Files | Description |
|-----------|-------|-------------|
| `testing` | 3 | Testing and quality assurance |
| `performance` | - | Performance benchmarks |
| `reports` | - | Analysis and validation reports |

### Organization and Management

| Directory | Files | Description |
|-----------|-------|-------------|
| `indexes` | - | Catalog and indexes |
| `queues` | 12 | Work queues |
| `logs` | 7 | Execution logs |
| `checkpoints` | 7 | Validation checkpoints |
| `metadata` | - | System configuration |
| `tracking` | - | Monitoring and analysis |
| `sessions` | 8 | Session history |
| `conventions` | - | Naming and standards |

### Cross-Reference and Links

| Directory | Files | Description |
|-----------|-------|-------------|
| `cross-link` | - | Cross-references and validation |
| `memory-system` | - | Memory system overview |

### Additional Resources

| Directory | Files | Description |
|-----------|-------|-------------|
| `onboarding` | - | Getting started guides |
| `prompts` | 4 | AI prompts and references |
| `entities` | 4 | Game objects and components |
| `summaries` | 3 | Document summaries |
| `security` | 3 | Security analysis |

## Document Types

| Type | Description | Directory | Priority |
|------|-------------|-----------|----------|
| `index` | Root index and navigation | `.memory/` | 100 |
| `concept` | Theoretical concepts | `.memory/concepts/` | 90 |
| `project` | Project documentation | `.memory/projects/` | 85 |
| `glossary` | Terminology definitions | `.memory/glossary/` | 80 |
| `decision` | Architecture decisions | `.memory/decisions/` | 85 |
| `diagram` | Visual diagrams | `.memory/diagrams/` | 75 |
| `system` | System state/tracking | `.memory/system/` | 70 |
| `sample` | Code samples | `.memory/samples/` | 60 |
| `extension` | Plugin/extension docs | `.memory/extensions/` | 65 |
| `application` | Application docs | `.memory/applications/` | 60 |

## Status Values

| Status | Description | Color | Usage |
|--------|-------------|-------|-------|
| `active` | Currently maintained | Green | Most documentation |
| `archived` | No longer maintained | Gray | Old versions |
| `draft` | Work in progress | Yellow | New features |
| `deprecated` | Replaced by newer version | Red | Legacy code |

## Access Levels

| Level | Description | Visibility |
|-------|-------------|------------|
| `public` | Open to all | All users |
| `internal` | Team only | Team members |
| `private` | Restricted | Owner only |

## AI Configuration

### Summary Guidelines

- Maximum 500 characters
- Required for all documents
- AI-generated summaries
- Clear and concise

### Keyword Extraction

- Maximum 10 keywords
- Lowercase, hyphen-separated
- AI-extracted from content
- Relevant to document type

### Confidence Scores

- Range: 0.0 to 1.0
- Default: 0.85
- Updated after AI processing
- Indicates AI certainty

### Context Categories

- `architecture` - Architecture documentation
- `design` - Design patterns
- `implementation` - Implementation details
- `reference` - Reference documentation
- `theory` - Theoretical concepts

### Priority Levels

- `high` - Critical documents
- `medium` - Standard documents
- `low` - Reference documents

## Validation Rules

1. **Required Properties**: `title`, `tags`, `type`
2. **Date Format**: `YYYY-MM-DD` for `lastUpdated`
3. **Version Format**: `X.Y.Z` semantic versioning
4. **Tag Format**: Lowercase, hyphen-separated, no spaces
5. **Link Format**: `[[Document Title]]` wiki-link syntax
6. **Number Range**: `weight` (0-100), `confidence` (0-1)

## Maintenance Schedule

- **Monthly**: Review and update `lastUpdated` dates
- **Quarterly**: Archive deprecated documents
- **Annually**: Update `ai-confidence` scores
- **Annually**: Validate all links
- **Annually**: Backup property schemas

## Future Enhancements

1. Add support for multi-language properties
2. Implement property inheritance from parent documents
3. Create property templates for common document types
4. Add automated property validation tools
5. Develop property visualization dashboards

## Related Documents

- [[ALIS Memory System - Global Properties]] - Property definitions
- [[ALIS Memory System - YAML Configuration]] - YAML schema
- [[ALIS Memory System - JSON Configuration]] - JSON schema
- [[ALIS Memory System - Obsidian Configuration]] - Obsidian settings
- [[ALIS Memory System - Document Template]] - Template for new documents
- [[ALIS Memory System - Dataview Configuration]] - Query configuration

## Quick Links

- [ALIS Repository](https://github.com/pabllopf/Alis)
- [ALIS Website](www.alisengine.com)
- [ALIS Documentation](https://docs.alisengine.com)

---

**Status**: **COMPLETE** ✓  
**Last Updated**: 2026-06-09  
**Version**: 1.2.0
