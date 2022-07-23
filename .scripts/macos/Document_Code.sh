cd ../../

/usr/local/share/dotnet/dotnet tool install --global dotnet-document --version 0.1.4-alpha
/usr/local/share/dotnet/dotnet document apply ./alis.sln 

cd ./.scripts/macos/

exit