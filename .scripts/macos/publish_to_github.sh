#!/bin/bash

echo "STARTING PROCESS"

filename="./Directory.Build.props"

echo "FILE VERASION NAME $filename"

version=$(grep -Eo '[0-9]\.[0-9]+.[0-9]+' $filename)

echo "CURRENT VERSION '$version'"

mayor=$(echo $version | cut -f1 -d.)
minor=$(echo $version | cut -f2 -d.)
alpha=$(echo $version | cut -f3 -d.)

((alpha=alpha+1))

if [[ "$alpha" -gt 9 ]]; then
    ((minor=minor+1))
    ((alpha=0))
fi

if [[ "$minor" -gt 9 ]]; then
    ((mayor=mayor+1))
    ((minor=0))
fi

echo "MAYOR VERSION '$mayor'"
echo "MINIR VERSION '$minor'"
echo "ALPHA VERSION '$alpha'"

versionFinal=$(echo "$mayor.$minor.$alpha")

echo "NEXT VERSION '$versionFinal'"

# Take the search string
search=$(echo "$version")
echo "$search"

# Take the replace string
replace=$(echo "$versionFinal")
echo "$replace"

if [[ $search != "" && $replace != "" ]]; then
    echo "Write new version"
    sed -i "s/$search/$replace/" $filename
fi


for i in `find . -name "*.csproj" -type f`; do
    echo "Write default value of csproj = $i"
    dotnet pack -c Release $i -o ./.publish/$versionFinal/
done
