#!/bin/bash
cd ../../../

echo "-------------------------------------------------"
echo "Total size of repository (before): " && du -hs .
echo "-------------------------------------------------"

find . -type d -name "bin" -exec rm -Rf {} \;
find . -type d -name "obj" -exec rm -Rf {} \;
find . -type d -name "publish" -exec rm -Rf {} \;
find . -type d -name "build" -exec rm -Rf {} \;
find . -type d -name "lib" -exec rm -Rf {} \;
find . -type d -name ".nuget" -exec rm -Rf {} \;
find . -type d -name ".publish" -exec rm -Rf {} \;

find ./ -name ".DS_Store" -exec rm -f {} \; 
find ./ -name "*.dll" -exec rm -f {} \; 
find ./ -name "*.so" -exec rm -f {} \; 
find ./ -name "*.a" -exec rm -f {} \; 
find ./ -name "*.o" -exec rm -f {} \;
find ./ -name "*.nupkg" -exec rm -f {} \;
find ./ -name "*.dylib" -exec rm -f {} \; 
find ./ -name "*.exe" -exec rm -f {} \; 
find ./ -name "*.pdb" -exec rm -f {} \; 
find ./ -name "*.mdb" -exec rm -f {} \; 
find ./ -name "*.xml" -exec rm -f {} \; 

echo "-------------------------------------------------"
echo "Total size of repository (after): " && du -hs .
echo "-------------------------------------------------"

cd ./docs/scripts/macos/ || exit 

