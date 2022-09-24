cd ..\\..\\

@RD /S /Q ".\\docs\\docs"

.\\.tools\\doxygen\\doxygen.exe config

xcopy /E /Y /I .\\docs\\images .\\docs\\docs\\images

cd .\\.scripts\\windows\\
