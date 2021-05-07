cd ..

dotnet --version

dotnet restore

dotnet publish ./Editor/Editor.csproj  -r win-x64 -c Windows -o ./_/Windows 

cd ./_/Windows

Alis.exe