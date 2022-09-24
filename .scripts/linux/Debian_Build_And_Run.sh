cd ..;
dotnet --version;
dotnet restore;
dotnet publish ./Editor/Editor.csproj  -r debian-x64 -c Linux -o ./_/Debian ;
cd ./_/Debian 
./Alis;