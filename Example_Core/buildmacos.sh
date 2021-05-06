#!/bin/bash
[[ -d ./_/MacOS-X64 ]] && rm -r ./_/MacOS-X64;

dotnet publish -r osx-x64 -c MacOS  -o ./_/MacOS-X64 -p:PublishSingleFile=true --self-contained true

#dotnet publish -r osx-x64 -c MacOS  -o ./_/MacOS-X64/Contents/MacOS;
#mkdir ./_/MacOS-X64/Contents/Resources;
#cp ./docs/icon.icns ./_/MacOS-X64/Contents/Resources/icon.icns;
#cp ./docs/Info.plist ./_/MacOS-X64/Contents/Info.plist;
#mkdir ./_/MacOS-X64/PingPong.app;
#mv ./_/MacOS-X64/Contents ./_/MacOS-X64/PingPong.app/;