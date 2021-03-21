cd ..;
dotnet --version;
dotnet restore;
dotnet publish ./Editor/Editor.csproj  -r debian.10-x64 -c Linux -o ./_/Editor/Debian10x64 ;
cd ./_/Editor/Debian10x64 
./Editor;