#!/bin/bash

cd ../../../

# 📦 Directorio base
BASE_DIR="."

# 🎨 Colores para salida
GREEN="\033[0;32m"
RED="\033[0;31m"
NC="\033[0m" # Sin color

# 🧭 Buscar archivos de imagen (png, jpg, jpeg, bmp)
find "$BASE_DIR" -type f \( -iname "*.png" -o -iname "*.jpg" -o -iname "*.jpeg" -o -iname "*.bmp" \) | while read -r file; do
    dir=$(dirname "$file")
    name=$(basename "$file")
    base="${name%.*}"
    output="$dir/$base.bmp"

    # Tamaño original en KB
    size_orig=$(du -k "$file" | cut -f1)

    # Convertir con ImageMagick → BMP con compresión RLE y 8 bits de profundidad
    magick "$file" -colors 8 -compress RLE "$output" 2>/dev/null

    # Verificar que se creó correctamente
    if [ ! -f "$output" ]; then
        echo "⚠️ Error al convertir $file"
        continue
    fi

    # Tamaño nuevo en KB
    size_new=$(du -k "$output" | cut -f1)

    # Calcular porcentaje de reducción
    if [ "$size_orig" -gt 0 ]; then
        reduction=$((100 * (size_orig - size_new) / size_orig))
    else
        reduction=0
    fi

    # Mostrar resultados con color
    if [ "$size_new" -lt "$size_orig" ]; then
        echo -e "🖼️  $file → ${GREEN}${reduction}% reducción${NC}"
    else
        echo -e "🖼️  $file → ${RED}+${reduction#-}% incremento${NC}"
    fi

    echo "   ➜ Original: ${size_orig} KB"
    echo "   ➜ BMP nuevo: ${size_new} KB"

    # Borrar original (solo si no es el mismo archivo)
    if [ "$file" != "$output" ]; then
        rm "$file"
        echo "   ❌ Archivo original eliminado."
    else
        echo "   🔄 BMP reescrito con compresión."
    fi

    echo "----------------------------------------"
done

echo "✅ Conversión completada en todos los subdirectorios de '$BASE_DIR'."
