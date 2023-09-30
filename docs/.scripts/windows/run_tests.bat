cd ..\..\..\\

for /r %%i in (*.Test.csproj) do dotnet test %%i --configuration Debug

for /r %%i in (*.Test.csproj) do dotnet test %%i --configuration Release

cd .scripts\\windows\\
