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
          find ./ -name "*.nupkg" -exec rm -f {} \;
          find ./ -name "*.exe" -exec rm -f {} \; 
          find ./ -name "*.pdb" -exec rm -f {} \; 
          find ./ -name "*.mdb" -exec rm -f {} \; 
          
          
          dotnet new sln -o . -n Alis_design --force
          
          cp ./.config/default.sln  ./alis_design.sln
          
          skip="App"
          skip3="Sample"
          skip2="Test"
          skip4="Benchmark"
          for i in `find . -name "*.csproj" -type f`; do
              if [[ $i == *$skip* ]] || [[ $i == *$skip2* ]] || [[ $i == *$skip3* ]] || [[ $i == *$skip4* ]] ; then
                  echo "Skip project $i"
              elif [[ $i == *"Test"* ]] ; then
                  echo "Write default value of csproj = $i"
                  cat ./.config/default/default_test_csproj.props > $i
              elif [[ $i == *"Generator"* ]] ; then
                  echo "Write default value of csproj = $i"
                  cat ./.config/default/default_generator_csproj.props > $i
              else
                  echo "Write default value of csproj = $i"
                  cat ./.config/default/default_csproj.props > $i
              fi
          done
          
          for i in `find . -name "*.csproj" -type f`; do
              if [[ $i == *$skip* ]] || [[ $i == *$skip3* ]] || [[ $i == *$skip4* ]] ; then
                  echo "Skip project $i"
              else
                  echo "Add csproj = $i"
                  dotnet sln alis_design.sln add $i
              fi
          done
        
          
          for i in `find . -name "*.csproj" -type f`; do
              if [[ $i == *$skip* ]] || [[ $i == *$skip3* ]] || [[ $i == *$skip4* ]] ; then
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

