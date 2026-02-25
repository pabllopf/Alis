#!/bin/bash

dotnet sonarscanner begin \
  /o:"pabllopf" \
  /k:"pabllopf_Alis" \
  /d:sonar.host.url="https://sonarcloud.io" \
  /d:sonar.scanner.skipJreProvisioning=false \
  /d:sonar.language=cs \
  /d:sonar.dotnet.version=8.0 \
  /d:sonar.verbose=false \
  /d:sonar.exclusions="**/TestResults/**" \
  /d:sonar.cs.cobertura.reportsPaths="**/coverage.opencover.xml" \
  /d:sonar.token="fdba65e36940f87146fd9ba99321bff467d188f7" 
  
  dotnet build alis_design.sln -c Release -f net8.0
  dotnet test alis_design.sln --no-build -c Release -f net8.0 --collect:"XPlat Code Coverage" --results-directory ./TestResults
  
  
dotnet sonarscanner end /d:sonar.token="fdba65e36940f87146fd9ba99321bff467d188f7"

