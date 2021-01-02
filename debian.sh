https://www.wikihow.com/Install-Mesa-%28OpenGL%29-on-Linux-Mint

config for debian


git clone https://github.com/pabllopf/Alis.git

cd Alis

dotnet publish ./Editor/Editor.csproj  -r debian.8-x64 -c MacOS -p:PublishSingleFile=true -o ./_/Editor/debian -p:PublishReadyToRun=true --self-contained true


last publish profile

dotnet publish ./Editor/Editor.csproj  -r debian.8-x64 -c Linux -p:PublishSingleFile=true -o ./_/Editor/debian -p:PublishReadyToRun=true --self-contained true



