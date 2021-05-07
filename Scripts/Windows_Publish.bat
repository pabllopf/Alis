cd ..

dotnet tool install --global dotnet-zip

dotnet tool install --global dotnet-tarball

dotnet tool install --global dotnet-rpm

dotnet tool install --global dotnet-deb


dotnet zip install

dotnet tarball install

dotnet rpm install

dotnet deb install

dotnet restore

cd Scripts

dotnet msbuild ../Editor/Editor.csproj /t:CreateZip /p:TargetFramework=net5.0 /p:RuntimeIdentifier=win-x86 /p:Configuration=Windows /p:OutputPath=../_/WindowsX86/

dotnet msbuild ../Editor/Editor.csproj /t:CreateZip /p:TargetFramework=net5.0 /p:RuntimeIdentifier=win-x64 /p:Configuration=Windows /p:OutputPath=../_/WindowsX64/