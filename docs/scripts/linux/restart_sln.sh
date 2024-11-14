#!/bin/bash

echo "Do you want to continue? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 
          
          cd ../../../
          
          dotnet new sln -o . -n Alis --force
          
          cp ./.config/default_sln  ./Alis.sln
          
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
              if [[ $i == *$skip* ]] ; then
                  echo "Skip project $i"
              else
                  echo "Add csproj = $i"
                  dotnet sln Alis.sln add $i
              fi
          done
          
          rm -rf ./.nuget/
          rm -rf ./.build/
          rm -rf ./**/obj/
          rm -rf ./**/bin/
          
          
          for i in `find . -name "*.csproj" -type f`; do
              if [[ $i == *$skip* ]] ; then
                  echo "Skip project $i"
              else
                  echo "Add csproj = $i"
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

