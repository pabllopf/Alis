cd ..;
dotnet --version;
dotnet restore;
dotnet publish ./Editor/Editor.csproj  -r debian.10-x64 -c Linux -o ./_/Debian10x64 ;
cd ./_/Debian10x64 
./Alis;