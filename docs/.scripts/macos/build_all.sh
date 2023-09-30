echo "Do you want to continue? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 

    cd ../../../
    
    rm -rf ./.build/
    echo "remove ./.build/"
    
    rm -rf ./.nuget/
    echo "remove ./.nuget/"
    
    rm -rf ./**/obj/
    echo "remove ./**/obj/"
    
    rm -rf ./**/bin/
    echo "remove ./**/bin/"
    
    rm -rf ./**/lib/
    echo "remove ./**/lib/"
    
    for i in `find . -name "*.csproj" -type f`; 
      do if [[ $i != *".Template."* && $i != *".App."* && $i != *".Test."* && $i != *".Benchmark."* && $i != *".Sample."* ]] ; 
      then 
        echo "Build project $i" ;
        dotnet restore $i;
        dotnet build $i -c Release; 
        dotnet build $i -r win-x64 -c Release;
        dotnet build $i -r win-arm64 -c Release;
        dotnet build $i -r win-x86 -c Release;
        dotnet build $i -r win-arm -c Release;
        dotnet build $i -r osx-x64 -c Release;
        dotnet build $i -r osx-arm64 -c Release;
        dotnet build $i -r linux-x64 -c Release;
        dotnet build $i -r linux-x86 -c Release;
        dotnet build $i -r linux-arm64 -c Release;
        else 
          echo "Skip project $i";
          dotnet restore $i;
    fi;done
    
    
    cd ./.scripts/macos/ || exit 

break;;
No ) 
          echo "Goodbye!"
          exit;;
    esac
done
