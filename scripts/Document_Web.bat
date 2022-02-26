SET PATH=%PATH%;%CD%\\graphviz\\bin

dot -V

@RD /S /Q "..\\docs\\docs"

cd .\\apidoc

.\\Doxygen\\doxygen.exe .\\config

cd ..

cd ..

cd docs

xcopy /E /Y /I .\\images .\\docs\\images
