# Fix: AZ6OPbAksynw1OJ1vi8E

- **Rule**: csharpsquid:S2696, csharpsquid:S2325
- **File**: Installer.cs, Program.cs
- **Fix Type**: Made instance method static to match static field usage
- **Changes**:
  - `Installer.Run(string[] args)` → `public static void Run(string[] args)`
  - `new Installer().Run(args)` → `Installer.Run(args)`
- **Build**: Verified (0 errors, 0 warnings)
