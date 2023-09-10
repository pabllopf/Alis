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
                
          skip="Template"  
          for i in `find . -name "*.csproj" -type f`; do
              if [[ $i == *$skip* ]] ; then
                  echo "Skip project $i"
              else
                  echo "Restore csproj = $i"
                  dotnet restore $i
              fi
          done
          
          cd ./.scripts/macos/ || exit
          
          break;;
        No ) 
          echo "Goodbye!"
          exit;;
    esac
done

