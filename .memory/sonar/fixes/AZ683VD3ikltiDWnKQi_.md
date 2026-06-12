# Fix: AZ683VD3ikltiDWnKQi_ (and AZ683VD3ikltiDWnKQjA, AZ683VD3ikltiDWnKQjB)

- **Rule**: csharpsquid:S1075
- **Pattern**: Externalize hardcoded URLs
- **Files**: TopMenuAction.cs, Urls.cs (new)

## What Changed

- Created new `Urls` class in `1_Presentation/Engine/src/Menus/Urls.cs`
- Moved 3 hardcoded URLs from TopMenuAction.cs to Urls class:
  - `AlisEngineUrl` → `Urls.AlisEngine`
  - `AlisApiUrl` → `Urls.AlisApiReference`
  - `AlisBugReportUrl` → `Urls.AlisBugReport`
- Updated all references in TopMenuAction.cs to use centralized class

## Why

Hardcoded URLs violate S1075. Centralizing them makes future externalization to configuration trivial.
