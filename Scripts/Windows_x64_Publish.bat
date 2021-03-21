cd ..

dotnet restore

cd Scripts

dotnet msbuild ../Editor/Editor.csproj /t:CreateZip /p:TargetFramework=net5.0 /p:RuntimeIdentifier=win-x64 /p:Configuration=Windows /p:OutputPath=../_/WindowsX64/