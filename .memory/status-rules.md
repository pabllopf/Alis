---
title: Status Rules
tags:
  - status
  - rules
  - configuration
  - lifecycle
lastUpdated: 2026-06-09
author: Pablo Perdomo Falcón
license: GPLv3
repository: https://github.com/pabllopf/Alis
---

# ALIS Memory System - Status Rules

> **Version**: 1.0.0 | **Author**: Pablo Perdomo Falcón | **License**: GPLv3  
> **Repository**: https://github.com/pabllopf/Alis | **Website**: www.alisengine.com  
> **Status**: **ACTIVE** ✓ | **Last Updated**: 2026-06-09

## Overview

This document defines the **4 lifecycle states** for all markdown files in the `.memory/` directory. These states control how the AI interacts with each document and determine what operations are allowed.

## Status Values

### Draft

**Description**: Estado que permite que la IA pueda manipularlo y completarlo.

**Color**: Yellow 🟡

**Usage**: 
- New documents being created
- Documents being actively edited by AI
- Work in progress content
- Documents needing completion

**AI Permissions**:
- ✅ Read
- ✅ Write
- ✅ Edit
- ✅ Delete
- ✅ Move to other states

**Rules**:
- AI can freely modify content
- AI can add missing sections
- AI can restructure content
- AI can transition to other states

### In Review

**Description**: Estado que indica que lo está revisando un usuario y no se debe tocar.

**Color**: Orange 🟠

**Usage**:
- Documents under human review
- Content being validated by user
- Pending approval documents

**AI Permissions**:
- ✅ Read
- ❌ Write (NO modifications allowed)
- ❌ Edit (NO changes allowed)
- ❌ Delete (NO deletions allowed)
- ⚠️ Move to other states (only by human)

**Rules**:
- AI must NOT modify content
- AI can only read and analyze
- AI can suggest changes but not apply them
- Human must explicitly approve state changes

### Done

**Description**: Estado que indica que está completo el fichero y solo debe ser leído por la IA.

**Color**: Green 🟢

**Usage**:
- Complete and validated documents
- Finalized content
- Reference documentation
- Approved and published materials

**AI Permissions**:
- ✅ Read
- ❌ Write (NO modifications allowed)
- ❌ Edit (NO changes allowed)
- ❌ Delete (NO deletions allowed)
- ❌ Move to other states (NO state changes)

**Rules**:
- AI can ONLY read and reference
- AI must NOT modify content
- AI can use as reference for other documents
- Status is immutable without human intervention

### To Do

**Description**: Necesita construirse mejor y definir entero de nuevo por la IA.

**Color**: Red 🔴

**Usage**:
- Incomplete or poorly structured documents
- Content needing major revision
- Documents requiring complete rewrite
- Outdated or insufficient content

**AI Permissions**:
- ✅ Read
- ✅ Write (with restrictions)
- ✅ Edit (major restructuring allowed)
- ⚠️ Delete (only if replacing with new content)
- ✅ Move to other states (after improvements)

**Rules**:
- AI must plan major revisions
- AI should create improvement plan first
- AI can restructure entire document
- AI must document changes made
- AI should transition to Draft after improvements

## Status Transitions

### Allowed Transitions

| From \ To | Draft | In Review | Done | To Do |
|-----------|-------|-----------|------|-------|
| **Draft** | ✅ | ✅ | ✅ | ✅ |
| **In Review** | ✅ (human) | ✅ | ✅ (human) | ✅ (human) |
| **Done** | ✅ (human) | ✅ (human) | ✅ | ❌ |
| **To Do** | ✅ | ✅ | ✅ | ✅ |

### Transition Rules

1. **Draft → In Review**: AI can transition when document is ready for human review
2. **In Review → Draft**: Human can return for modifications
3. **In Review → Done**: Human approves and marks complete
4. **In Review → To Do**: Human identifies need for major revision
5. **Done → Draft**: Human requests changes (rare)
6. **To Do → Draft**: AI completes planned improvements
7. **To Do → In Review**: AI requests human review after improvements
8. **To Do → Done**: AI completes and validates document

## Implementation

### Frontmatter Format

```yaml
---
title: Document Title
tags:
  - tag1
  - tag2
status: Draft
statusDate: 2026-06-09
statusHistory:
  - status: Draft
    date: 2026-06-09
    changedBy: AI
  - status: In Review
    date: 2026-06-10
    changedBy: Human
lastUpdated: 2026-06-09
author: Pablo Perdomo Falcón
license: GPLv3
repository: https://github.com/pabllopf/Alis
---
```

### Status Property

- **Type**: string
- **Required**: Yes
- **Valid Values**: `Draft`, `In Review`, `Done`, `To Do`
- **Default**: `Draft`
- **Case Sensitive**: Yes

### Status Date Property

- **Type**: date
- **Format**: `YYYY-MM-DD`
- **Required**: When status changes
- **Description**: Date when current status was set

### Status History Property

- **Type**: array
- **Required**: No (recommended for audit trail)
- **Structure**: Array of status change objects

## AI Behavior Guidelines

### When Reading Documents

1. Check `status` property first
2. Respect AI permissions for that status
3. Log any permission violations
4. Do not modify if not allowed

### When Modifying Documents

1. Verify current status allows modification
2. Update `statusDate` if changing status
3. Add entry to `statusHistory`
4. Document changes in commit message

### When Creating New Documents

1. Default status: `Draft`
2. Set `statusDate` to current date
3. Add initial entry to `statusHistory`
4. Mark as AI-created in metadata

## Validation Rules

1. **Status must be one of**: `Draft`, `In Review`, `Done`, `To Do`
2. **Date format**: `YYYY-MM-DD` for all date fields
3. **History array**: Must contain at least one entry if status exists
4. **Case sensitivity**: Status values are case-sensitive
5. **Immutability**: `Done` status cannot be changed by AI

## Maintenance Schedule

- **Daily**: AI checks status permissions before operations
- **Weekly**: Review `In Review` documents pending human action
- **Monthly**: Audit status transitions and history
- **Quarterly**: Archive `Done` documents older than 1 year

## Related Documents

- [[ALIS Memory System - Global Properties]] - Property definitions
- [[ALIS Memory System - Document Template]] - Template for new documents
- [[ALIS Memory System - Global Index]] - System overview

---

**Status**: **Draft** ✓  
**Last Updated**: 2026-06-09  
**Version**: 1.0.0
