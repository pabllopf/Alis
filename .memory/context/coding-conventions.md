---
title: Coding Conventions
tags:
  - project
  - documentation
  - reference

status: draft

license: GPLv3
---


## Source Files

- **Only `.cs` files** — never generate `.md`, `.txt`, `.json`, `.yaml`, `.xml` files in source
- **XML documentation required** (`///`) — all public/protected/internal APIs must be documented
- **No `//` or `/* */` comments** in code — only XML doc comments
- **No emojis** in code, identifiers, or string literals (unless in user-facing strings in the target language)

## API Design

- Prefer **records, pattern matching, value objects** over classes where appropriate
- Use **async/await** for I/O-bound operations
- Use **`Span<T>` / `Memory<T>`** for high-performance paths
- Avoid locks and manual synchronization — prefer Channels, async/await, or Akka.NET for concurrency
- Return `Task<T>` / `ValueTask<T>` for async methods

## Diagnostics

- Source generators emit diagnostics with **ALIS0xxx** IDs for invalid configurations
- Example: `ALIS001` for invalid generator input, `ALIS009`/`ALIS010` for warning suppressions

## File Conventions

- One type per file (preferred)
- File name matches type name
- Namespace matches folder structure

## Related
- [[conventions/coding-standards]] — Detailed coding standards
- [[conventions/naming-conventions]] — Naming rules
