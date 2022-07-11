#!/bin/bash

echo "STARTING PROCESS"

version=$(grep -Eo '[0-9]\.[0-9]+.[0-9]+' ./Directory.Build.props)

echo "CURRENT VERSION '$version'"

dotnet restore alis.sln

dotnet build --configuration Release alis.sln

for i in `find . -name "*.csproj" -type f`; do
    echo "Write default value of csproj = $i"
    dotnet pack --no-build -c Release $i -o .
done

dotnet nuget push *.nupkg -s https://api.nuget.org/v3/index.json -k ${{secrets.NUGET}} --skip-duplicate -n 1
