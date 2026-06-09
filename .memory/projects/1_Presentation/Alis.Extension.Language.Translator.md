# Alis.Extension.Language.Translator

tags:
  - presentation,application,extension,documentation

## Overview
Multi-language translation system for ALIS applications. Provides text localization with caching, pluralization, and fallback language support.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~20 files across multiple directories

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Language Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Enables internationalization (i18n) for ALIS applications. Provides translation management with provider-based architecture, caching, pluralization rules, and language fallback chains.

## Key Components

### TranslationManager
Main facade class coordinating translation operations:
- Language management and selection
- Translation lookup across providers
- Multi-level fallback (e.g., "en-US" -> "en" -> default)
- Caching layer for performance
- Observer pattern for translation change notifications
- Pluralization engine integration

### Abstractions
- **ILanguage** — Language representation
- **ILanguageProvider** — Language metadata provider
- **ITranslationProvider** — Translation data provider
- **ITranslationCache** — Cache interface for translations
- **IPluralizationEngine** — Pluralization rules engine
- **ITranslationObserver** — Observer pattern for events

### Providers
- **LanguageProvider** — Language metadata implementation
- **MemoryTranslationProvider** — In-memory translation storage

### Supporting Components
- **TranslationCache** — Cache implementation
- **PluralizationEngine** — Pluralization rules
- **Lang** — Language model class

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: disabled (project-specific)

## Architecture Notes
1. Provider-based architecture for flexible translation sources
2. Fallback chain resolution for missing translations
3. Cache-first lookup strategy for performance
4. Observer pattern for reactive UI updates
5. Pluralization engine supports multiple language rules

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Language.Translator.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Extension.Language.Dialogue]] — Dialogue system
- [[Alis.Core.Aspect.Logging]] — Logging infrastructure

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
