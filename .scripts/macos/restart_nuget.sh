#!/bin/bash

echo "Do you want to continue? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 
          
          cd ../../
          
          rm -rf ./.build/
          echo "./.build/"
          
          rm -rf ./.nuget/
          echo "./.nuget/"
          
          rm -rf ./**/obj/
          echo "./**/obj/"
          
          rm -rf ./**/bin/
          echo "./**/bin/"
                  
          for i in `find . -name "*.csproj" -type f`; do
              echo "restoring csproj = $i"
              dotnet restore $i
          done
          
          cd ./.scripts/macos/ || exit
          
          break;;
        No ) 
          echo "Goodbye!"
          exit;;
    esac
done

