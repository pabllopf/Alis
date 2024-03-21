
:choice
set /P c=Are you sure you want to continue[Y/N]?
if /I "%c%" EQU "Y" goto :somewhere
if /I "%c%" EQU "N" goto :somewhere_else
goto :choice

:somewhere

echo "Start"

cd ..\\..\\..\\

dotnet new sln -o . -n alis --force

@type .\.config\default.sln > alis.sln

for /r %%i in (*.csproj) do @type .\.config\default_csproj.props > %%i

for /r %%i in (*.csproj) do dotnet sln alis.sln add %%i

rd /s /q .nuget
rd /s /q .build

FOR /d /r . %%d IN (bin) DO @IF EXIST "%%d" rd /s /q "%%d"

FOR /d /r . %%d IN (obj) DO @IF EXIST "%%d" rd /s /q "%%d"

for /r %%i in (*.csproj) do dotnet restore %%i

cd .\.scripts\windows\

pause
exit

:somewhere_else

echo "Cancel"
pause
exit