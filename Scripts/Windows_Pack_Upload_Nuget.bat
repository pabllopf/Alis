cd ..

dotnet restore

dotnet build Tools/Tools.csproj -c Windows

dotnet build Core/Core.csproj -c Windows

dotnet build Core-SFML/Core-SFML.csproj -c Windows

dotnet nuget push "Core/bin/Windows/Alis.Core.1.2.8.nupkg" --source "github"

dotnet nuget push "Core-SFML/bin/Windows/Alis.Core-SFML.1.2.8.nupkg" --source "github"

dotnet nuget push "Tools/bin/Windows/Alis.Tools.1.2.8.nupkg" --source "github"

pause