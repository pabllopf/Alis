
cd ..\..\

dotnet new sln -o . -n Alis --force

@type .\.config\default_sln > Alis.sln

for /r %%i in (*.csproj) do dotnet sln Alis.sln add %%i

cd .\.scripts\windows\