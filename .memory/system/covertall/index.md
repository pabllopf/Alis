# Coverage Remediation Progress

Last update:
2026-08-16T23:20:00Z

## Projects

| Project | Status | Initial | Current | Agent | Last Commit |
|---|---|---:|---:|---|---|
| Alis.Extension.Profile | COMPLETED | 100.0% | 100.0% | covertall-agent-001 | - |
| Alis.Extension.Updater | COMPLETED | 92.93% | 94.89% | covertall-agent-001 | 98d510f14 |
| Alis.Extension.Network | COMPLETED | 97.28% | 97.28% | covertall-agent-001 | - |
| Alis.Core.Ecs | COMPLETED | 98.90% | 99.02% | covertall-agent-001 | - |
| Alis.Extension.Graphic.Ui | COMPLETED | 94.54% | 94.54% | covertall-agent-001 | - |
| Alis.Extension.Media.FFmpeg | COMPLETED | 97.14% | 97.14% | covertall-agent-001 | - |
| Alis.App.Installer | COMPLETED | 12.71% | 12.71% | covertall-agent-001 | - |
| Alis.Core.Audio | IN_PROGRESS | - | - | other-agent | - |
| Categories.cs | IN_PROGRESS | - | - | other-agent | - |
| CircleShape.cs | IN_PROGRESS | - | - | other-agent | - |
| Clock.cs | IN_PROGRESS | - | - | other-agent | - |
| AudioPlayer.cs | AVAILABLE | - | - | - | - |
| AudioVideoWriter.cs | AVAILABLE | - | - | - | - |
| AudioWriter.cs | AVAILABLE | - | - | - | - |

## Notes

- 6_Ideation projects (Memory 98.5%, Logging 98.8%, Math/Data/Fluent/Time 100%)
  have only defensive/conditional-compilation gaps; not meaningfully testable.
- Glfw (33.7%), Sfml (75.7%), Sdl2 (98.7%) native coverage paths require a
  startup hook that is broken in this environment (generated AssemblyLoader
  fails to resolve Alis.Core.Aspect.Memory in the hook load context). Shared
  infra issue; not modified.
- Audio/Graphic native players and ImPlot P/Invoke bodies abort the test host
  or require live displays; documented as not safely testable.
- FFmpeg VideoReader/AudioReader stream branches are unreachable because the
  Data JSON source generator's DeserializeArray<T> supports primitives only
  (shared infra limitation).