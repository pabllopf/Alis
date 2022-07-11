#!/bin/bash

echo "STARTING PROCESS"

version=$(grep -Eo '[0-9]\.[0-9]+.[0-9]+' ./Directory.Build.props)

echo "CURRENT VERSION '$version'"

for i in `find . -name "*.csproj" -type f`; do
    echo "Write default value of csproj = $i"
    dotnet pack -c Release $i -o .
done


