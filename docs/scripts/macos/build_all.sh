echo "Do you want to continue? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 

    cd ../../../
    
    find . -type d -name "publish" -exec rm -Rf {} \;
    find . -type d -name ".publish" -exec rm -Rf {} \;
    
    for i in `find . -name "*.csproj" -type f`; 
      do if [[ $i != *".Template."* && $i != *".App."* && $i != *".Test."* && $i != *".Benchmark."* && $i != *".Sample."* && $i != *".Extension."*  ]] ; 
      then 
        echo "Build project $i" ;
        dotnet restore $i;
        dotnet build $i -c Release; 
        dotnet build $i -r win-x64 -c Release;
        dotnet build $i -r win-arm64 -c Release;
        dotnet build $i -r win-x86 -c Release;
        dotnet build $i -r osx-x64 -c Release;
        dotnet build $i -r osx-arm64 -c Release;
        dotnet build $i -r linux-x64 -c Release;
        dotnet build $i -r linux-x86 -c Release;
        dotnet build $i -r linux-arm64 -c Release;
        else 
          echo "Skip project $i";
          dotnet restore $i;
    fi;done
    
    for i in `find . -name "*.csproj" -type f`; 
          do if [[ $i != *".Template."* && $i != *".App."* && $i != *".Test."* && $i != *".Benchmark."* && $i != *".Sample."* && $i != *".Extension."* ]] ; 
          then 
            echo "Build project $i" ;
            dotnet restore $i;
            dotnet build $i -c Debug; 
            dotnet build $i -r win-x64 -c Debug;
            dotnet build $i -r win-arm64 -c Debug;
            dotnet build $i -r win-x86 -c Debug;
            dotnet build $i -r osx-x64 -c Debug;
            dotnet build $i -r osx-arm64 -c Debug;
            dotnet build $i -r linux-x64 -c Debug;
            dotnet build $i -r linux-x86 -c Debug;
            dotnet build $i -r linux-arm64 -c Debug;
            else 
              echo "Skip project $i";
              dotnet restore $i;
        fi;done
        
        
    for i in `find . -name "*.csproj" -type f`; 
      do if [[ $i == *".Template."* || $i == *".App."* || $i == *".Test."* || $i == *".Benchmark."* || $i == *".Sample."* ]] ; 
      then 
        echo "Skip project $i"; 
      else 
        dotnet pack -c Release $i -o ./.publish/test/ ; 
      fi;done
    
    
    
    cd ./docs/scripts/macos/ || exit 

break;;
No ) 
          echo "Goodbye!"
          exit;;
    esac
done
