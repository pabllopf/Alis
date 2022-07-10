@RD /S /Q ".\\docs\\docs"

.\\tools\\doxygen\\bin\\doxygen.exe config

xcopy /E /Y /I .\\docs\\images .\\docs\\docs\\images
