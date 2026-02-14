#!/bin/bash

cd ../../../

BASE_DIR="."

GREEN="\033[0;32m"
RED="\033[0;31m"
NC="\033[0m"

find "$BASE_DIR" -type f -iname "*.wav" | while read -r file; do
    dir=$(dirname "$file")
    name=$(basename "$file")
    base="${name%.*}"
    temp="$dir/$base.tmp.wav"

    # Tamaño original en KB
    size_orig=$(du -k "$file" | cut -f1)

    # Detectar duración
    duration=$(ffprobe -v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 "$file")
    duration=${duration%.*}

    ffmpeg -y -i "$file" -ac 1 -ar 16000 -acodec pcm_s16le "$temp" -hide_banner -loglevel error

    # Verificar creación
    if [ ! -f "$temp" ]; then
        echo "⚠️ Error al comprimir $file"
        continue
    fi

    # Tamaño nuevo
    size_new=$(du -k "$temp" | cut -f1)
    mv "$temp" "$file"

    reduction=$((100 * (size_orig - size_new) / size_orig))

    if [ "$size_new" -lt "$size_orig" ]; then
        echo -e "🎵 $file → ${GREEN}${reduction}% reducción${NC}"
    else
        echo -e "🎵 $file → ${RED}+${reduction#-}% incremento${NC}"
    fi

    echo "   ➜ Original: ${size_orig} KB"
    echo "   ➜ Comprimido: ${size_new} KB"
    echo "----------------------------------------"
done

echo "✅ Compresión completada en todos los WAV de '$BASE_DIR'."
