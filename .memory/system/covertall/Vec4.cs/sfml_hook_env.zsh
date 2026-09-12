#!/bin/zsh
# Environment setup for SFML/Ui/Glfw main-thread coverage runs (no repo changes).
export LIB_DIR="$(pwd)/1_Presentation/Extension/Graphic/Sfml/test/bin/Debug/lib"
export DOTNET_STARTUP_HOOKS="/tmp/opencode/HookLib/out/HookLib.dll:$PWD/1_Presentation/Extension/Graphic/Sfml/test/bin/Debug/lib/Alis.Extension.Graphic.Sfml.Test.dll"
export ALIS_SFML_HOOK=1
export ALIS_HOOK_PRELOAD_DIR="$PWD/1_Presentation/Extension/Graphic/Sfml/test/bin/Debug/lib"
