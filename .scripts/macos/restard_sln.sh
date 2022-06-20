
cd ../../

dotnet new sln -o . -n Alis --force

cp ./.config/default_sln  ./Alis.sln

for i in `find . -name "*.csproj" -type f`; do
    echo "$i"
    dotnet sln Alis.sln add $i
done

cd ./.scripts/macos/