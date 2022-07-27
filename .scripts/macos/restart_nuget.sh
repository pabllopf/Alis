#!/bin/bash

cd ../../

rm -rf ./.nuget/
echo "./.nuget/"

rm -rf ./**/obj/
echo "./**/obj/"

rm -rf ./**/bin/
echo "./**/bin/"

skip="Template"
for i in `find . -name "*.csproj" -type f`; do
    if [[ $i == *$skip* ]] ; then
        echo "Skip project $i"
    else
        echo "Write default value of csproj = $i"
        cat ./.config/Default_csproj.props > $i
    fi
done

for i in `find . -name "*.csproj" -type f`; do
    echo "restoring csproj = $i"
    dotnet restore $i
done

cd ./.scripts/macos/ || exit