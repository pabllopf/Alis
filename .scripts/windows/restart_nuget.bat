cd ..\..\

for /r %%i in (*.Test.csproj) do dotnet test %%i

cd .\.scripts\windows\