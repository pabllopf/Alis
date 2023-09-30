cd ../../../

for i in `find . -name "*.csproj" -type f`; do if [[ $i == *"Template"* ]] ; then echo "Skip project $i"; else dotnet test $i --configuration Debug ; fi;done

for i in `find . -name "*.csproj" -type f`; do if [[ $i == *"Template"* ]] ; then echo "Skip project $i"; else dotnet test $i --configuration Release ; fi;done

cd ./.scripts/macos/ || exit 