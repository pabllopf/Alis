# Alis.Extension.Language.Dialogue

## Overview
Dialogue system for ALIS games. Provides state-machine-based dialog management with branching conversations, events, and condition support.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~8 files across Core directory

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Language Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides a complete dialogue system for interactive narratives in ALIS games. Supports branching dialogue trees, state transitions, events, conditions, and observer pattern for UI integration.

## Key Components

### DialogManager
Main orchestrator class for dialogue systems:
- Dialog registration and lookup by key
- State machine management (Idle, Active, Completed, Cancelled)
- Event-driven dialog flow via DialogEventPublisher
- Observer pattern for UI integration
- Dialog context tracking with branching state

### Core Types
- **Dialog** — Individual dialog node/entry
- **DialogOption** — Player choice options
- **DialogContext** — Current dialog state context
- **DialogStateType** — State machine enum (Idle, Active, Completed, Cancelled)
- **DialogEventPublisher** — Event system for dialog state changes

### Core Folder
- **DialogEventObserver** — Observer interface
- **DialogCondition** — Conditional flow control
- **DialogTransition** — State transitions
- **DialogEvent** — Event definitions

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- [[Alis.Extension.Language.Translator]] — Parent language module

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: disabled (project-specific)

## Architecture Notes
1. State machine-based dialog flow
2. Observer pattern for loose coupling
3. Event-driven branching conversations
4. Condition-based dialog progression
5. Context tracking for save/load support

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Language.Dialogue.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Extension.Language.Translator]] — Translation system
- [[Alis.Core.Aspect.Logging]] — Logging infrastructure
- [[Alis.Sample.Rogue]] — Sample game using dialogue

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
