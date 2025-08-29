cd ../../../

set "version=6.0.0"
set "publishDir=.\.publish\%version%"

rem Crear carpeta de salida
if not exist "%publishDir%" mkdir "%publishDir%"

rem Recorrer todos los .csproj y empaquetar excepto los excluidos
for /r %%f in (*.csproj) do (
    set "project=%%f"
    call :ProcessProject "%%f"
)

goto :eof

:ProcessProject
set "proj=%~1"

echo %proj% | findstr /i /r "\.Template\. \.App\. \.Test\. \.Benchmark \.Sample\." >nul
if %errorlevel%==0 (
    rem Coincide con exclusiones → saltar
    goto :eof
)

echo Packing %proj%
dotnet pack "%proj%" -c Release -o "%publishDir%" /p:AssemblyVersion=%version%
goto :eof


cd ./docs/scripts/windows
