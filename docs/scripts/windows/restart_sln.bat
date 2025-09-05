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

for /r %%i in (*.csproj) do (
    echo %%i | findstr /i "sample" >nul
    if not errorlevel 1 (
        @type .\.config\default_sample_csproj.props > %%i
    ) else (
        echo %%i | findstr /i "Test" >nul
        if not errorlevel 1 (
            @type .\.config\default_test_csproj.props > %%i
        ) else (
            @type .\.config\default_csproj.props > %%i
        )
    )
)


setlocal EnableExtensions EnableDelayedExpansion

rem --- 1) Localizar la solucion ---
set "sln=%~1"
if not defined sln (
  set "dir=%~dp0../../../"        rem carpeta del script (con \ final)
  :find_sln
  if exist "%dir%alis.sln" set "sln=%dir%alis.sln" & goto sln_found
  for %%d in ("%dir%\..") do set "next=%%~dpd"
  if /I "%dir%"=="%next%" goto no_sln
  set "dir=%next%"
  goto find_sln
)
:sln_found

rem --- 2) Base = carpeta donde está la .sln (con \ final) ---
for %%z in ("%sln%") do set "base=%%~dpz"
if not "%base:~-1%"=="\" set "base=%base%\"

echo Usando solucion: %sln%
echo Base: %base%

rem --- 3) Añadir todos los .csproj bajo la base ---
for /r "%base%" %%i in (*.csproj) do (
  set "rel=%%~dpi"
  set "rel=!rel:%base%=!"

  rem aplanar carpetas especiales
  for %%F in (sample src test generator) do set "rel=!rel:%%F\=!"

  if "!rel:~-1!"=="\" set "rel=!rel:~0,-1!"
  set "rel=!rel:\=/!"

  if "!rel!"=="" (
    dotnet sln "%sln%" add "%%i"
  ) else (
    dotnet sln "%sln%" add "%%i" --solution-folder "!rel!"
  )
)
goto :eof

:no_sln
echo ERROR: No se encontro "alis.sln" desde "%~dp0" hacia arriba. Pasa la ruta como primer parametro:
echo     add-all.bat "C:\repositorios\Alis\alis.sln"
exit /b 1






rd /s /q .nuget
rd /s /q .build

FOR /d /r . %%d IN (bin) DO @IF EXIST "%%d" rd /s /q "%%d"

FOR /d /r . %%d IN (obj) DO @IF EXIST "%%d" rd /s /q "%%d"

dotnet restore alis.sln

pause
exit

:somewhere_else

echo "Cancel"
pause
exit