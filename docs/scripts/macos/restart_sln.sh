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
          find ./ -name "*.a" -exec rm -f {} \; 
          find ./ -name "*.o" -exec rm -f {} \;
          find ./ -name "*.nupkg" -exec rm -f {} \;
          find ./ -name "*.exe" -exec rm -f {} \; 
          find ./ -name "*.pdb" -exec rm -f {} \; 
          find ./ -name "*.mdb" -exec rm -f {} \; 
          
          
          dotnet new sln -o . -n Alis --force
          
          cp ./.config/default.sln  ./Alis.sln
          
         skip="Template"
         for i in $(find . -name "*.csproj" -type f); do
             if [[ $i == *$skip* ]]; then
                 echo "Skip project $i"
             else
                 echo "Check csproj = $i"
                 props="./.config/default/default_csproj.props"
                 if [[ $i == *"Alis.Benchmark"* ]]; then
                     props="./.config/default/default_benchmark_csproj.props"
                  fi
                 if [[ $i == *"Alis.App"* ]]; then
                     props="./.config/default/default_app_csproj.props"
                  fi
                 if [[ $i == *"Generator"* ]]; then
                     props="./.config/default/default_generator_csproj.props"
                  fi
                 if [[ $i == *"Sample"* ]]; then
                     props="./.config/default/default_sample_csproj.props"
                 fi
                 if [[ $i == *".Web"* ]]; then
                    props="./.config/default/default_sample_web_csproj.props"
                fi
                 if [[ $i == *"Test"* ]]; then
                     props="./.config/default/default_test_csproj.props"
                 fi
                 echo "Write default value of csproj = $i with $props"
                 cat $props > $i
             fi
         done
          
     
      
      # 1) Localizar la solución
      sln="$1"
      if [[ -z "$sln" ]]; then
        dir="$(cd "$(dirname "$0")/../../../" && pwd)"
        while [[ ! -f "$dir/Alis.sln" ]]; do
          next="$(dirname "$dir")"
          if [[ "$dir" == "$next" ]]; then
            echo "ERROR: No se encontró Alis.sln desde $(dirname "$0") hacia arriba."
            echo "Pasa la ruta como primer parámetro: ./add-all.sh /ruta/a/Alis.sln"
            exit 1
          fi
          dir="$next"
        done
        sln="$dir/Alis.sln"
      fi
      
      # 2) Base = carpeta donde está la .sln
      base="$(cd "$(dirname "$sln")" && pwd)/"
      
      echo "Usando solución: $sln"
      echo "Base: $base"
      
      # 3) Añadir todos los .csproj bajo la base
      find "$base" -name "*.csproj" -type f | while read -r csproj; do
        rel="${csproj#$base}"
        # Aplanar carpetas especiales
        for F in sample src test generator; do
          rel="${rel//$F\//}"
        done
        # Quitar / final si existe
        rel="${rel%/}"
        # Quitar nombre del archivo
        folder="$(dirname "$rel")"
        # Reemplazar / inicial y espacios
        folder="${folder#/}"
        folder="$(echo "$folder" | xargs)"
        if [[ -z "$folder" || "$folder" == "." ]]; then
          dotnet sln "$sln" add "$csproj"
        else
          dotnet sln "$sln" add "$csproj" --solution-folder "$folder"
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

