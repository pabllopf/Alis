echo "Do you want to continue? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 

    cd ../../../
    
    find . -type d -name "publish" -exec rm -Rf {} \;
    find . -type d -name ".publish" -exec rm -Rf {} \;
    
    dotnet restore alis.sln;
        
        
    for i in `find . -name "*.csproj" -type f`; 
      do if [[ $i == *".Template."* || $i == *".App."* || $i == *".Test."* || $i == *".Benchmark."* || $i == *".Sample."* || $i == *".Generator."* ]] ; 
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
