setlocal enabledelayedexpansion

REM Cambia el directorio de trabajo al que contiene los resultados
cd /d ..\..\..\

REM Define la carpeta donde están los archivos .html y .png
set "report_files=C:\repositorios\Alis\2_Application\Alis\test\bin\Debug\lib\net6.0\BenchmarkDotNet.Artifacts\results"
set "index_location=C:\repositorios\Alis"
set "index_file=%index_location%\index.html"

REM Eliminar el archivo index.html anterior si existe
if exist "%index_file%" del "%index_file%"

REM Crear el nuevo archivo index.html
(
echo ^<!DOCTYPE html^>
echo ^<html lang="en"^>
echo ^<head^>
echo ^    ^<meta charset="UTF-8"^>
echo ^    ^<meta name="viewport" content="width=device-width, initial-scale=1.0"^>
echo ^    ^<title^>Benchmark Results^</title^>
echo ^    ^<style^>
echo ^        body { font-family: Arial, sans-serif; max-width: 1000px; margin: auto; }
echo ^        h1, h2 { text-align: center; }
echo ^        ul { list-style-type: none; padding: 0; }
echo ^        li { margin: 10px 0; }
echo ^        a { text-decoration: none; color: #007bff; }
echo ^ table { border-collapse: collapse; display: block; width: 100%; overflow: auto; }
echo ^	td, th { padding: 6px 13px; border: 1px solid #ddd; text-align: right; }
echo ^	tr { background-color: #fff; border-top: 1px solid #ccc; }
echo ^        a:hover { text-decoration: underline; }
echo ^        .benchmark { margin-bottom: 50px; }
echo ^        .benchmark h2 { margin-bottom: 20px; }
echo ^        .benchmark ul { padding-left: 20px; }
echo ^        .benchmark li { margin: 5px 0; }
echo ^        .benchmark a { color: #007bff; }
echo ^        .benchmark a:hover { text-decoration: underline; }
echo ^    ^</style^>
echo ^</head^>
echo ^<body^>
echo ^    ^<h1^>Benchmark Results^</h1^>
) > "%index_file%"

REM Añadir el contenido del body de cada benchmark al index.html
for %%f in ("%report_files%\*.html") do (
    set "filepath=%%f"
    echo "%%f"
    echo %filepath%
    set "in_body=false"
    
    echo ^    ^<div class="benchmark"^> >> "%index_file%"
    echo ^        ^<h2^>%%~nf^</h2^> >> "%index_file%"
    
    REM Extraer y añadir el contenido del body del archivo HTML al index.html
    for /f "usebackq delims=" %%j in ("!filepath!") do (
        if "%%j"=="<body>" (
            set "in_body=true"
            continue
        )
        
        if "%%j"=="</body>" (
            set "in_body=false"
            break
        )
        
        if "!in_body!"=="true" (
            echo %%j >> "%index_file%"
        )
    )
    
    echo ^    ^</div^> >> "%index_file%"
)

REM Cerrar el archivo HTML
(
echo ^</body^>
echo ^</html^>
) >> "%index_file%"

REM Abrir el archivo index.html en el navegador predeterminado
start "" "%index_file%"

endlocal
goto :EOF
