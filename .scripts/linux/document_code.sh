
/usr/local/share/dotnet/dotnet tool install --global dotnet-document --version 0.1.4-alpha

cd ../../

/usr/local/share/dotnet/dotnet document apply ./Alis.sln 

cd .scripts/macos/