cd ../../

rm -rf ./.build/
echo "./.build/"

rm -rf ./.nuget/
echo "./.nuget/"

rm -rf ./**/obj/
echo "./**/obj/"

rm -rf ./**/bin/
echo "./**/bin/"

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