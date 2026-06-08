# Index

## Entities

### Projects
- [[Alis]] — C# game engine/framework with layered architecture (6 layers, 8 solution files)

### Tools & Technologies
- [[.NET]] — C# runtime and SDK
- [[Obsidian]] — Markdown knowledge base viewer (used for wiki)
- [[qmd]] — Local markdown search engine (BM25 + vector + LLM re-ranking)

## Concepts

- [[Layered Architecture]] — 6-layer organization (Presentation → Application → Structuration → Operation → Declaration → Ideation)
- [[Aspect-Oriented Design]] — Core.Aspect as foundation, 6 experimental aspects built on top
- [[Solution Composition]] — Modular .slnx files for different build targets (core, apps, extensions, tests, samples)
- [[Generator Pattern]] — Source generators for Ecs, Graphic, Memory, Data, Fluent aspects
- [[Multi-Platform Samples]] — Each sample game ships Web + Desktop variants

## Sources

- [[alis.slnx]] — Full solution (all projects: apps, samples, core, aspects, extensions)
- [[alis.core.slnx]] — Core libraries only (no tests, samples, or presentation)
- [[alis.apps.slnx]] — Applications + core dependencies (Installer, Engine, Hub)
- [[alis.extensions.slnx]] — All extensions + core dependencies
- [[alis.test.slnx]] — Test projects across all layers
- [[alis.samples.slnx]] — Sample games + core samples
- [[alis.core.aspect.slnx]] — Aspect layer only (5_Declaration + 6_Ideation)
- [[alis.benchmark.slnx]] — Benchmark project

## Overview

- [[Alis Architecture Overview]]
