#!/bin/bash

# Ejecuta las pruebas y recoge los datos de cobertura para cada proyecto de prueba
#dotnet test ./alis.sln -f net6.0 /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Busca todos los archivos XML de cobertura en la solución
coverage_files=$(find . -path '*test*' -name 'coverage.net6.0.xml' | tr '\n' ';')

# Verifica si se encontraron archivos de cobertura
if [ -z "$coverage_files" ]; then
    echo "No se encontraron archivos de cobertura."
    exit 1
fi

# Combina todos los archivos de cobertura en uno solo
reportgenerator "-reports:${coverage_files}" "-targetdir:./coverage" -reporttypes:Cobertura

# Renombra el archivo de cobertura generado a coverage.xml
mv ./coverage/Cobertura.xml ./coverage/coverage.xml
