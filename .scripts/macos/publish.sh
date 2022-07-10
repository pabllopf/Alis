#!/bin/bash
cd ..;
[[ -d ./_/MacOS-X64 ]] && rm -r ./_/MacOS-X64;
dotnet publish ./Editor/Editor.csproj -r osx-x64 -c MacOS  -p:PublishSingleFile=true  -o ./_/MacOS-X64/Contents/MacOS;
mkdir ./_/MacOS-X64/Contents/Resources;
cp ./Editor/docs/Alis.icns ./_/MacOS-X64/Contents/Resources/Alis.icns;
cp ./Editor/docs/Info.plist ./_/MacOS-X64/Contents/Info.plist;
mkdir ./_/MacOS-X64/Alis.app;
mv ./_/MacOS-X64/Contents ./_/MacOS-X64/Alis.app/;
mv ./_/MacOS-X64/Alis.app/Contents/MacOS/Editor ./_/MacOS-X64/Alis.app/Contents/MacOS/Alis;