cd ..

dotnet restore

dotnet build Tools/Tools.csproj -c Release

dotnet build Core/Core.csproj -c Release

dotnet build Core-SFML/Core-SFML.csproj -c Release

dotnet nuget push "Core/bin/Windows/Alis.Core.1.3.6.nupkg" --api-key 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 --source "https://nuget.pkg.github.com/pabllopf/index.json"

dotnet nuget push "Core-SFML/bin/Windows/Alis.Core-SFML.1.3.6.nupkg" --api-key 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 --source "https://nuget.pkg.github.com/pabllopf/index.json"

dotnet nuget push "Tools/bin/Windows/Alis.Tools.1.3.6.nupkg" --api-key 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 --source "https://nuget.pkg.github.com/pabllopf/index.json"

pause