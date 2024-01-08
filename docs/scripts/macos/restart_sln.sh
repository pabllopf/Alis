#!/bin/bash

echo "Do you want to continue? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 
          
          cd ../../../
          
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
          
          
          dotnet new sln -o . -n Alis --force
          
          cp ./.config/default.sln  ./Alis.sln
          
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
        
          
          for i in `find . -name "*.csproj" -type f`; do
              if [[ $i == *$skip* ]] ; then
                  echo "Skip project $i"
              else
                  echo "Add csproj = $i"
                  dotnet restore $i
              fi
          done
                    
          cd ./docs/scripts/macos/ || exit 
          
          break;;
        No ) 
          echo "Goodbye!"
          exit;;
    esac
done

