## Alis For Debian !!

This is a simple guide for config the framework Alis to work in debian.

### Install OpenGL

sudo apt-get update
sudo apt-get install freeglut3
sudo apt-get install freeglut3-dev
sudo apt-get install binutils-gold
sudo apt-get install g++ cmake
sudo apt-get install libglew-dev
sudo apt-get install g++
sudo apt-get install mesa-common-dev
sudo apt-get install build-essential
sudo apt-get install libglew1.5-dev libglm-dev 

### Cloning project of git with this line.

git clone https://github.com/pabllopf/Alis.git

### To get a simple build

dotnet publish ./Editor/Editor.csproj  -r debian.8-x64 -c Linux -p:PublishSingleFile=true -o ./_/Editor/debian -p:PublishReadyToRun=true --self-contained true
