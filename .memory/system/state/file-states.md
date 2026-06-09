---
title: File States
tags:
  - system
  - state
  - documentation
  - reference

status: Draft

license: GPLv3
---

## File States

This document defines the 4 states for all files in the `.memory/` directory.

### 1. Draft

**Purpose**: State that allows AI to manipulate and complete the file.

**Characteristics**:
- AI can read, modify, and update content
- File is actively being developed
- Content may be incomplete or in progress
- Suitable for ongoing work and iterations

**When to use**:
- New files being created
- Content being actively developed
- AI-assisted writing or updates

### 2. In Review

**Purpose**: State that indicates a user is reviewing the file and it should not be touched.

**Characteristics**:
- AI should NOT modify the file
- Human review in progress
- Content is frozen for review
- Read-only for AI

**When to use**:
- Files being reviewed by humans
- Content under evaluation
- Pending approval or feedback

### 3. Done

**Purpose**: State that indicates the file is complete and should only be read by AI.

**Characteristics**:
- File is complete and finalized
- AI can only read, not modify
- Content is stable and approved
- Reference material only

**When to use**:
- Completed documentation
- Finalized content
- Reference materials
- Approved documentation

### 4. To Do

**Purpose**: State that indicates the file needs to be built better and defined entirely again by AI.

**Characteristics**:
- File requires significant reconstruction
- Current content is insufficient
- AI needs to rebuild from scratch
- Placeholder or minimal content

**When to use**:
- Files needing complete rewrite
- Insufficient content
- Placeholder documentation
- Restructuring needed

## State Transitions

```
Draft → In Review → Done
   ↓
To Do → Draft → In Review → Done
```

## Usage Guidelines

1. **Default State**: All new files start as `Draft`
2. **Review Process**: Move to `In Review` when human review is needed
3. **Completion**: Move to `Done` when content is finalized
4. **Reconstruction**: Move to `To Do` when file needs rebuilding

## Related

- [[File States]] — This document
- [[Memory System State]] — Overall system state
- [[Documentation Quality]] — Quality standards
