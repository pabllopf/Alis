#!/bin/bash
          
cd ../../../

echo ""
echo "----------------------------------------"
echo "TAMAÑO DE MÓDULOS COMPILADOS (Release) EXCLUYENDO samples, app, test, generator"
echo "----------------------------------------"

echo ""
echo "INFO:"
find . -type d -path "*/bin/OsxArm64/Release" \
    | grep -Ev "samples|app|test|generator" \
    | while read -r dir; do
        echo "Módulo: $dir"
        du -hs "$dir"
        echo "----------------------------------------"
    done

echo ""
echo "GENERAL SIZE:"
find . -type d -path "*/bin/OsxArm64/Release"  | grep -Ev "samples|app|test|generator" | xargs du -chs | tail -1

echo ""