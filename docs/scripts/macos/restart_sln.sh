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
      
      # add 2_Application/Alis/src/Alis.csproj
      dotnet sln "$sln" add "$base""2_Application/Alis/src/Alis.csproj" --solution-folder "2_Application/Alis"
      sleep 1
      
      # add 4_Operation/Ecs/generator/Alis.Core.Ecs.Generator.csproj
      dotnet sln "$sln" add "$base""4_Operation/Ecs/generator/Alis.Core.Ecs.Generator.csproj" --solution-folder "4_Operation/Ecs"
      sleep 1
            
      # add 4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj
      dotnet sln "$sln" add "$base""4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj" --solution-folder "4_Operation/Graphic"
      sleep 1
      
              
      
     # Añadir todos los .csproj bajo la base, quitando carpetas src, test, generator, sample, desktop, web, android e ios del path relativo, excluyendo Alis.csproj
     find "$base" -name "*.csproj" -type f | while read -r csproj; do
       relpath="${csproj#$base}"
       folder=$(dirname "$relpath" | sed -E 's/(^|\/)(src|test|generator|sample|desktop|web|android|ios)(\/|$)/\1/g' | sed 's/^\/\+//;s/\/\+$//')
       dotnet sln "$sln" add "$csproj" --solution-folder "$folder"
       echo "Added $csproj to $sln under folder $folder"
       sleep 1
     done
      
      
      
         
       
                    
          cd ./docs/scripts/macos/ || exit 
          
          break;;
        No ) 
          echo "Goodbye!"
          exit;;
    esac
done

