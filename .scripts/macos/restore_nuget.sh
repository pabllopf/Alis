
cd ../../

rm -rf ./.nuget/
rm -rf ./**/obj/
rm -rf ./**/bin/

for i in `find . -name "*.csproj" -type f`; do
    echo "$i"
    dotnet restore $i
done

cd ./.scripts/macos/