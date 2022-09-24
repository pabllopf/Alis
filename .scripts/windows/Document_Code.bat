dotnet tool install --global dotnet-document --version 0.1.4-alpha

cd ../../

dotnet document apply ./Alis.sln

cd ./.scripts/windows/
