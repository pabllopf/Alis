---
title: Concepts Overview
tags:
  - concept
  - theory
  - documentation
---


This directory contains comprehensive documentation about the Alis solution architecture and development practices.

## Summary

**Total Files**: 20 concept documents  
**Total Size**: ~80KB  
**Coverage**: Architecture, platform support, build system, testing, and development workflows

## Categories

### Architecture (4 files)
- **Alis Architecture Overview** - High-level architecture overview
- **Layered Architecture** - 6-layer structure and dependencies  
- **Repository Structure** - Directory organization
- **Solution Files Strategy** - 8 modular .slnx files

### Platform Support (3 files)
- **Multi-Targeting Strategy** - 15+ framework configurations
- **Platform-Specific Build Constants** - Conditional compilation
- **Multi-Platform Samples** - 12+ sample games

### Design Patterns (3 files)
- **Aspect-Oriented Design** - Core.Aspect foundation
- **Generator Pattern** - Source code generation
- **Entity Component System** - ECS architecture

### Development (6 files)
- **Build System Configuration** - Centralized build settings
- **Testing Strategy** - xUnit testing framework
- **CI/CD Pipeline** - GitHub Actions workflows
- **Quality Assurance** - Static analysis and coverage
- **Developer Onboarding** - Getting started guide
- **Dependency Management** - No external NuGet packages

### Extensions (2 files)
- **Extension System** - 18+ modular extensions
- **Application Composition** - Main app and samples

## Key Statistics

| Metric | Value |
|--------|-------|
| Concept files | 20 |
| Total lines | ~1,400+ |
| Framework targets | 15+ |
| Solution files | 8 |
| Sample games | 12+ |
| Extensions | 18+ |

## Usage

### For Developers
1. Start with [[Developer Onboarding]]
2. Read [[Alis Architecture Overview]] for context
3. Reference specific concepts as needed

### For AI Agents
- Use concepts as context for code generation
- Reference [[Layered Architecture]] for dependency rules
- Check [[Generator Pattern]] for code generation requirements

## Maintenance

Update these files when:
- New layers or modules are added
- Build configuration changes
- New platforms are supported
- Testing strategies evolve

## See Also
- `.memory/architecture/` - Architecture documentation
- `.memory/dependencies/` - Dependency maps
- `.memory/projects/` - Project-specific documentation
