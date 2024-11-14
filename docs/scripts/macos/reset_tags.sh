#!/bin/bash

# Confirmación inicial para asegurar que el usuario está de acuerdo con la operación
echo "This script will perform critical operations on the repository. Are you sure you want to continue? (y/n)"
read response
if [[ "$response" != "y" && "$response" != "Y" ]]; then
  echo "Operation canceled."
  exit 1
fi

# Cambiar al directorio raíz del proyecto
cd ../../../

# Crear un directorio temporal para almacenar los archivos descargados y generados
TEMP_DIR=".temp"
mkdir -p "$TEMP_DIR"
echo "Created temporary directory: $TEMP_DIR"

# Definir el rango de versiones desde v0.0.0 hasta v0.4.5
echo "Starting to iterate over versions from v0.0.0 to v0.4.5..."

for i in {0..4}; do
  for j in {0..4}; do
    for k in {0..5}; do
      release_tag="v0.$j.$k"

      # Obtener los detalles del changelog para esta versión (tag)
      echo "Fetching release notes for $release_tag from changelog.md..."
      release_notes=$(sed -n "/## \[$release_tag\]/, /## \[/p" changelog.md | sed '$d')  # Ajusta según el formato del changelog
      if [[ -z "$release_notes" ]]; then
        echo "No release notes found for $release_tag. Skipping..."
        continue
      fi

      # Crear la release en GitHub
      echo "Creating GitHub release for $release_tag..."
      
      gh release create "$release_tag" \
        --title "$release_tag has arrived !!!" \
        --notes "$release_notes" \
        --draft=false \
        --prerelease=false

      echo "Release $release_tag created successfully."
      
    done
  done
done

# Finalización del script
echo "Script completed."
