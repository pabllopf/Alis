#!/bin/bash

cd ../../

dotnet tool install --global dotnet-document --version 0.1.4-alpha

for i in `find . -name "*.sln" -type f`; do
    echo "$i"
    dotnet document apply ./alis.sln 
done

cd ./.scripts/macos/ || exit

