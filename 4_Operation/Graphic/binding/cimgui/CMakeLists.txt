cmake_minimum_required(VERSION 3.1)

project(cimgui)

#find_package(SDL2 CONFIG REQUIRED)

#general settings
file(GLOB IMGUI_SOURCES
    cimgui.cpp
    imgui/imgui.cpp
    imgui/imgui_draw.cpp
    imgui/imgui_demo.cpp
    imgui/imgui_widgets.cpp
	imgui/imgui_tables.cpp
	cimplot.cpp
	implot/implot.cpp
	implot/implot_demo.cpp
	implot/implot_items.cpp
    cimnodes.cpp
    imnodes/imnodes.cpp
    cimguizmo.cpp
    imguizmo/ImGuizmo.cpp
    imguizmo/GraphEditor.cpp
    imguizmo/ImCurveEdit.cpp
    imguizmo/ImGradient.cpp
    imguizmo/ImSequencer.cpp
)

set(IMGUI_STATIC "no" CACHE STRING "Build as a static library")
set(CMAKE_CXX_STANDARD 11)

#add library and link
if (IMGUI_STATIC)
    add_library(cimgui STATIC ${IMGUI_SOURCES})
else (IMGUI_STATIC)
    add_library(cimgui SHARED ${IMGUI_SOURCES})
endif (IMGUI_STATIC)

target_compile_definitions(cimgui PUBLIC IMGUI_DISABLE_OBSOLETE_FUNCTIONS=1)


target_include_directories(cimgui PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/imnodes)
target_include_directories(cimgui PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/implot)
target_include_directories(cimgui PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/../cimgui/imgui)
target_include_directories(cimgui PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/../cimgui)
set_target_properties(cimgui PROPERTIES PREFIX "")

#install
install(TARGETS cimgui
    RUNTIME DESTINATION  .
    LIBRARY DESTINATION  .
    ARCHIVE DESTINATION  .
)

