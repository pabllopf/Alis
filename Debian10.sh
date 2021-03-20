sudo cd ..;
sudo apt-get update;
sudo apt-get upgrade -y;
sudo apt-get dist-upgrade -y;

sudo apt-get install -y wget;


sudo wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb;
sudo dpkg -i packages-microsoft-prod.deb;

sudo apt-get update;


### Install DOTNET 5

sudo apt-get update; 
sudo apt-get install -y apt-transport-https;
sudo apt-get install -y dotnet-sdk-5.0;
sudo apt-get install -y aspnetcore-runtime-5.0;
sudo apt-get install -y dotnet-runtime-5.0;


### Install OpenGL

sudo apt-get install -y freeglut3;
sudo apt-get install -y freeglut3-dev;
sudo apt-get install -y binutils-gold;
sudo apt-get install -y g++ cmake;
sudo apt-get install -y libglew-dev;
sudo apt-get install -y g++;
sudo apt-get install -y mesa-common-dev;
sudo apt-get install -y build-essential;
sudo apt-get install -y libglew1.5-dev libglm-dev ;
sudo apt-get install -y libicu60

# Build and Run

sudo cd Alis;
sudo dotnet --version;
sudo dotnet restore;
sudo dotnet publish ./Editor/Editor.csproj  -r debian.8-x64 -c Linux -p:PublishSingleFile=true -o ./_/Editor/debian ;
sudo cd ./_/Editor/debian
sudo ./Editor