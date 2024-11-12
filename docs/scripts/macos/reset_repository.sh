#!/bin/bash

# Define GitHub token as a global variable
TOKEN=""

# If the TOKEN variable is empty, prompt the user for it
if [ -z "$TOKEN" ]; then
    echo "GitHub token is required. Please enter your GitHub token:"
    read TOKEN
fi

# Ensure the token is not empty after reading it
if [ -z "$TOKEN" ]; then
    echo "Error: GitHub token is required. Exiting."
    exit 1
fi

# Initial confirmation
echo "This script will perform critical operations on the repository. Are you sure you want to continue? (y/n)"
read response
if [[ "$response" != "y" && "$response" != "Y" ]]; then
  echo "Operation canceled."
  exit 1
fi

cd ../../../

# Create a temporary directory to store all downloaded and generated files
TEMP_DIR=".temp"
mkdir -p "$TEMP_DIR"

# Export commit messages
echo "Exporting commit messages..."
git log --pretty=format:"%s" > "$TEMP_DIR/commit_messages.txt"

# Export tags and their messages to a file
echo "Exporting tags..."
git tag -l > "$TEMP_DIR/tags_list.txt"

# Download all releases from GitHub and save them to separate JSON files
echo "Downloading releases from GitHub..."

# Variables de configuración
REPO="pabllopf/Alis"
PAGE=1

# Loop a través de todas las páginas de releases
while true; do
  # Realizar la solicitud para obtener la página actual de releases
  RESPONSE=$(curl -s -H "Authorization: token $TOKEN" \
    "https://api.github.com/repos/$REPO/releases?page=$PAGE&per_page=100")

  # Verificar si la respuesta está vacía, lo que significa que no hay más releases
  if [ -z "$RESPONSE" ]; then
    break
  fi

  # Procesar cada release individualmente
  echo "$RESPONSE" | jq -c '.[]' | while read -r release; do
    # Obtener información de la release
    tag_name=$(echo "$release" | jq -r '.tag_name')
    
    # Verificar que el tag_name no esté vacío antes de guardar
    if [[ -z "$tag_name" ]]; then
        echo "Error: tag_name faltante en release, saltando."
        continue
    fi

    # Crear un archivo JSON separado para cada release, manteniendo saltos de línea
    RELEASE_FILE="$TEMP_DIR/release_$tag_name.json"
    echo "$release" | jq '.' > "$RELEASE_FILE"

    echo "Saved release $tag_name to $RELEASE_FILE"
  done

  # Verificar si hemos recibido menos de `per_page`, lo que indica la última página
  NUM_RELEASES=$(echo "$RESPONSE" | jq -r 'length')
  if [ "$NUM_RELEASES" -lt 100 ]; then
    break
  fi

  # Incrementar el número de página para obtener la siguiente página
  PAGE=$((PAGE + 1))
done

echo "All releases have been downloaded to $TEMP_DIR."


echo "Releases downloaded successfully to individual files."

# Check if the releases files were created successfully
if [ ! "$(ls -A $TEMP_DIR/release_*.json)" ]; then
  echo "Error: Failed to download releases. Exiting."
  rm -rf "$TEMP_DIR"
  exit 1
fi

# Read each release file and process them
echo "Processing releases..."
for release_file in $TEMP_DIR/release_*.json; do
    # Read the release information from the JSON file
    release=$(cat "$release_file")
    tag_name=$(echo "$release" | jq -r '.tag_name')
    name=$(echo "$release" | jq -r '.name')
    body=$(echo "$release" | jq -r '.body')
    assets=$(echo "$release" | jq -r '.assets')

    # Create a directory for the tag if it doesn't exist
    mkdir -p "$TEMP_DIR/$tag_name"

    # Save the release description to a text file
    echo "$body" > "$TEMP_DIR/$tag_name/description.txt"

    # Check if there are any assets
    if [[ "$assets" == "[]" ]]; then
        echo "No assets found for release $tag_name."
        continue
    fi

    # Download the assets
    for asset in $(echo "$assets" | jq -r '.[] | @base64'); do
        _jq() {
            echo ${asset} | base64 --decode | jq -r ${1}
        }

        # Get the asset ID and download URL
        asset_id=$(_jq '.id')
        download_url=$(_jq '.browser_download_url')

        # Validate the values
        if [ -z "$asset_id" ] || [ -z "$download_url" ]; then
            echo "Error: Could not get the download URL or asset ID for release $tag_name"
            continue
        fi

        # Get the asset file name from the URL
        asset_name=$(basename $download_url)

        # Check if the asset has already been downloaded
        if [ -f "$TEMP_DIR/$tag_name/$asset_name" ]; then
            echo "Asset $asset_name already exists for release $tag_name. Skipping download."
            continue
        fi

        # Download the asset and save it in the corresponding folder
        echo "Downloading $asset_name for tag $tag_name..."
        curl -H "Authorization: token $TOKEN" \
            -L $download_url -o "$TEMP_DIR/$tag_name/$asset_name"
    done
done

# Initial confirmation for repository reset
echo "Are you sure you want to continue? This will delete the .git directory and reinitialize the repository (y/n)"
read response2
if [[ "$response2" != "y" && "$response2" != "Y" ]]; then
  echo "Operation canceled."
  exit 1
fi

# Delete history and reinitialize the repository
echo "Reinitializing the repository..."
rm -rf .git
git init

# Initial confirmation for the first commit
echo "Are you sure you want to create the first commit after reset (y/n)?"
read response3
if [[ "$response3" != "y" && "$response3" != "Y" ]]; then
  echo "Operation canceled."
  exit 1
fi

# Add all files and make the first signed commit
git add .
git commit --gpg-sign -m "Initial commit after reset"

# Creating empty signed commits
echo "Creating empty signed commits..."
while IFS= read -r msg; do
    if [[ "$msg" =~ ^(fix|feature|style|test|release|docs): ]]; then
        git commit --allow-empty --gpg-sign -m "$msg"
    else
        echo "Skipping commit: $msg (doesn't match the allowed prefixes)"
    fi
done < "$TEMP_DIR/commit_messages.txt"

# Clean up the git history
echo "Cleaning up git history..."
git reflog expire --expire=now --all
git gc --aggressive --prune=now

# Add remote repository
git remote add origin https://github.com/pabllopf/Alis

echo "Force pushing to the remote repository (overwriting the history)..."
git push --force --set-upstream origin master

# Step 7: Delete all tags from the local repository
echo "Deleting all tags locally..."
git tag -l | xargs git tag -d

# Step 8: Remove all tags remotely
echo "Removing all tags from the remote repository..."
git push --force --tags

# Step 9: Clean up by running garbage collection
echo "Running garbage collection to clean up the repository..."
git gc --aggressive --prune=now

echo "Repository reset complete. All history and tags have been removed, and the repository is now clean."

brew install gh

echo "Are you sure you want to delete all releases (y/n)?"
read response3
if [[ "$response3" != "y" && "$response3" != "Y" ]]; then
  echo "Operation canceled."
  exit 1
fi

gh release list \
  | awk -F '\t' '{print $3}' \
  | while read -r line; do \
    gh release delete -y --cleanup-tag "$line"; \
  done

echo "Are you sure you want to upload all releases (y/n)?"
read response3
if [[ "$response3" != "y" && "$response3" != "Y" ]]; then
  echo "Operation canceled."
  exit 1
fi

# Definir el rango de versiones desde v0.0.0 hasta v0.4.5
echo "Starting to iterate over versions from v0.0.0 to v0.4.5..."

for i in {0..4}; do
  for j in {0..4}; do
    for k in {0..9}; do
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

      # Construir la lista de archivos a subir
      files_to_upload=""
      temp_dir=".temp/$release_tag"
      for file in "$temp_dir"/*; do
        if [[ -f "$file" && ( "$file" =~ \.zip$ || "$file" =~ \.dmg$ || "$file" =~ \.nupkg$ || "$file" =~ \.md$ ) ]]; then
          files_to_upload="$files_to_upload $file"
        fi
      done

      if [[ -n "$files_to_upload" ]]; then
        # Crear la release y adjuntar los archivos
        gh release create "$release_tag" \
          --title "$release_tag has arrived !!!" \
          --notes "$release_notes" \
          --draft=false \
          --prerelease=false \
          $files_to_upload
        echo "Release $release_tag created successfully with attached files."
      else
        echo "No valid files found to attach for release $release_tag. Skipping..."
      fi
      
    done
  done
done


echo "All operations completed successfully!"