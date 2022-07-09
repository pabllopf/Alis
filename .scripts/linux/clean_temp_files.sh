
cd ../../

rm -rf ./.nuget/
rm -rf ./**/obj/
rm -rf ./**/bin/

for i in `find . -name "*.csproj" -type f`; do
    echo "Write default value of csproj = $i"
    cat ./.config/Default_csproj.props > $i
done

for i in `find . -name "*.csproj" -type f`; do
    echo "restoring csproj = $i"
    dotnet restore $i
done

cd ./.scripts/macos/