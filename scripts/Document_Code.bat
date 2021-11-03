dotnet tool install --global dotnet-document --version 0.1.4-alpha

cd ../src

dotnet document apply ./Alis.sln

pause