
cd ../../

dotnet dev-certs https --trust

dotnet new sln -o . -n Alis --force

cp ./.config/default_sln  ./Alis.sln

for i in `find . -name "*.csproj" -type f`; do
    echo "$i"
    dotnet sln Alis.sln add $i
done

rm -rf ./.nuget/
rm -rf ./**/obj/
rm -rf ./**/bin/

for i in `find . -name "*.csproj" -type f`; do
    echo "$i"
    dotnet restore $i
done

cd ./.scripts/macos/