#!/bin/bash

cd ../../../

find . -type d -name "bin" -exec rm -Rf {} \;
find . -type d -name "obj" -exec rm -Rf {} \;
find . -type d -name "publish" -exec rm -Rf {} \;
find . -type d -name "build" -exec rm -Rf {} \;
find . -type d -name "lib" -exec rm -Rf {} \;
find . -type d -name ".nuget" -exec rm -Rf {} \;
find . -type d -name ".publish" -exec rm -Rf {} \;

find ./ -name ".DS_Store" -exec rm -f {} \; 
find ./ -name "*.so" -exec rm -f {} \; 
find ./ -name "*.a" -exec rm -f {} \; 
find ./ -name "*.o" -exec rm -f {} \;
find ./ -name "*.nupkg" -exec rm -f {} \;
find ./ -name "*.dylib" -exec rm -f {} \; 
find ./ -name "*.exe" -exec rm -f {} \; 
find ./ -name "*.pdb" -exec rm -f {} \; 
find ./ -name "*.mdb" -exec rm -f {} \; 

echo ""
echo "----------------------------------------"
echo "Total size of repository: " && du -hs .
echo "----------------------------------------"
echo "Size of repository:"
# shellcheck disable=SC2035
du -hs .[^.]* * 
echo "----------------------------------------"
echo ""


echo "Do you want to see detail of repository? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 
          
          echo ""
          echo "----------------------------------------"
          echo "DETAIL size of repository: " && du -hs .
          echo "----------------------------------------"
          echo "DETAIL of repository:"
          # shellcheck disable=SC2035
          du -ha .[^.]* * 
          echo "----------------------------------------"
          echo ""
          
          break;;
        No ) 
          echo ""
          exit;;
    esac
done

cd ./docs/scripts/macos/ || exit 


