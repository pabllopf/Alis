cd ..;

dotnet tool install --global dotnet-zip;

dotnet tool install --global dotnet-tarball;

dotnet tool install --global dotnet-rpm;

dotnet tool install --global dotnet-deb;


dotnet zip install;

dotnet tarball install;

dotnet rpm install;

dotnet deb install;

dotnet restore;

dotnet deb ./Editor/Editor.csproj -c Linux -r debian.10-x64 -f net5.0 --output ../_/Debian10x64



