SET PATH=%PATH%;%CD%\\scripts\\graphviz\\bin

dot -V

@RD /S /Q ".\\docs\\docs"

.\\scripts\\apidoc\\Doxygen\\doxygen.exe config

xcopy /E /Y /I .\\docs\\images .\\docs\\docs\\images
