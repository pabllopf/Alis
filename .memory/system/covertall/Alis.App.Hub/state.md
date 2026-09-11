# Project Coverage State

Project:
./1_Presentation/Hub/src/Alis.App.Hub.csproj

Test project:
./1_Presentation/Hub/test/Alis.App.Hub.Test.csproj

Status:
BLOCKED

Agent:
covertall-agent-hub

Started:
2026-09-10

Last update:
2026-09-10

Problem:
Alis.App.Hub module is never reported by coverlet XPlat Code Coverage
(silently absent from coverage.cobertura.xml). Reproduced with: default
collector run, explicit Include filter [Alis.App.Hub]*, coverlet.console
global tool, and dotnet-coverage (profiler not initialized). Rebuild and
rerun did not change anything. Tests themselves PASS (98/98). This is the
same shared-infra failure family documented for Graphic.Glfw in index.md
(generated Memory.Generator AssemblyLoader custom load context prevents
coverlet from instrumenting/reporting this module).

NOT caused by any change of this agent; pre-existing environment limitation.
Fixing shared coverage tooling (.config/coverlet.runsettings, MSBuild infra)
is out of scope for a project-level agent.

Commands executed:
- dotnet test 1_Presentation/Hub/test/Alis.App.Hub.Test.csproj -f net8.0 -c Debug --no-build --collect:"XPlat Code Coverage" (several)
- build -f net8.0 -c Debug + rerun
- coverlet console tool + dotnet-coverage

Attempts:
5
