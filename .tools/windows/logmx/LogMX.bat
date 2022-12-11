@ECHO OFF
SETLOCAL
SETLOCAL ENABLEEXTENSIONS
SETLOCAL ENABLEDELAYEDEXPANSION

REM --------------------------------------------------------------------
REM  This file should be used to start LogMX if "LogMX[-64].exe" is not
REM  able to start LogMX (may be due to a bad Java installation)
REM --------------------------------------------------------------------
REM  DO NOT MODIFY THIS FILE: Use startup config file ("startup.conf") 
REM  instead to set startup settings
REM --------------------------------------------------------------------


REM *** Set default startup config
SET DEFAULT_STARTUP_CONF_FILE=startup.conf
SET SPLASH_SCREEN_PATH=pics/splash_screen.png
SET SPLASH_SCREEN=-splash:
SET MAX_MEMORY=1G
SET USER_PARAMS=
SET CONFIG_FILE=
SET SPECIFIC_JRE_PATH=
SET LOGMX_ADDITIONAL_CLASSPATH=
SET LOGGING_PARAM=
SET JVM_EXTRA_OPTIONS=

REM *** Examine parameters passed to this script
FOR %%A IN (%*) DO (
	IF "!CONF_FILE_EXPECTED!" NEQ "" (
		SET STARTUP_CONF_FILE=%%A
		SET STARTUP_CONF_FILE=!STARTUP_CONF_FILE:"=!
		SET CONF_FILE_EXPECTED=
	) ELSE (
		IF "%%A" == "--console" (
			SET CONSOLE=on
		) ELSE IF "%%A" == "--help" (
			SET CONSOLE=on
		) ELSE IF "%%A" == "--conf" (
			SET CONF_FILE_EXPECTED=true
		) 
		IF "%%A" NEQ "--conf" (
			SET USER_PARAMS=!USER_PARAMS! %%A
		) 
	)	
)

IF "%CONSOLE%" NEQ "" (
	SET SPLASH_SCREEN=
) ELSE (
	echo.
	echo Starting LogMX...  ^(you should use 'LogMX.exe' or 'LogMX-64.exe' instead^)
	echo.
)

REM *** Get LogMX Directory
REM -- If batch file started from its directory --
SET BATCHNAME=%0
IF NOT EXIST %BATCHNAME% SET BATCHNAME=%0.bat
IF NOT EXIST %BATCHNAME% GOTO SearchInPath
FOR %%i IN (%BATCHNAME%) DO SET BATCHNAME=%%~dfsi
GOTO GetLogMXDir

:SearchInPath
REM -- If batch file started using %PATH% --
FOR %%i IN (%0) DO SET BATCHNAME=%%~dfs$PATH:i
IF NOT "%BATCHNAME%"=="" GOTO GetLogMXDir
FOR %%i IN (%0.bat) DO SET BATCHNAME=%%~dfs$PATH:i
IF NOT "%BATCHNAME%"=="" GOTO GetLogMXDir
ECHO Unable to find LogMX directory
PAUSE
GOTO:EOF

:GetLogMXDir
FOR %%i IN (%BATCHNAME%) DO SET LOGMX_HOME=%%~dpsi

IF "%STARTUP_CONF_FILE%" == "" (
    SET STARTUP_CONF_FILE=%LOGMX_HOME%\%DEFAULT_STARTUP_CONF_FILE%
)

REM *** Read Startup config file
FOR /F "usebackq delims=" %%a IN (`type "%STARTUP_CONF_FILE%" ^| find "="`) DO (
	SET Line=%%a
	FOR /F "tokens=1 delims==" %%b IN ("!Line!") DO (
		SET Key=%%b
		SET TrimmedKey=!Key: =!
		
		IF "!TrimmedKey!" NEQ "" (
			SET KeyStr=!Key!
			SET KeyLen=0
			CALL:GetKeyLength
			SET FirstChar=!TrimmedKey:~0,1!
			IF "!FirstChar!" NEQ "#" (
				CALL:GetKeyValue
				IF "!TrimmedKey!" == "JAVA_PATH" (
					SET SPECIFIC_JRE_PATH=!KeyValue!
                ) ELSE IF "!TrimmedKey!" == "MAX_MEMORY" (
                	IF "!KeyValue!" NEQ "" SET MAX_MEMORY=!KeyValue!
				) ELSE IF "!TrimmedKey!" == "CONFIG_FILE" (
					SET F=!KeyValue:"=!
					IF "!KeyValue!" NEQ "" SET CONFIG_FILE=-Dconfig.file="!F!"
				) ELSE IF "!TrimmedKey!" == "SPLASH_SCREEN" (
					IF "!KeyValue!" == "0" SET SPLASH_SCREEN=
                ) ELSE IF "!TrimmedKey!" == "CONSOLE" (
                    IF "!CONSOLE!" == "" IF "!KeyValue!" == "1" SET CONSOLE=on
				) ELSE IF "!TrimmedKey!" == "ADDITIONAL_CLASSPATH" (
					SET ADDITIONAL_CLASSPATH=!KeyValue!
                ) ELSE IF "!TrimmedKey!" == "INTERNAL_LOGGING" (
                    IF "!KeyValue!" == "1" SET LOGGING_PARAM=-Djava.util.logging.config.file=config/logging.properties 
                ) ELSE IF "!TrimmedKey!" == "JVM_EXTRA_OPTIONS" (
                    SET JVM_EXTRA_OPTIONS=!KeyValue!
				) 
			)
		)
	)
)

IF "%SPLASH_SCREEN%" NEQ "" (
    SET SPLASH_SCREEN=%SPLASH_SCREEN%%LOGMX_HOME%\%SPLASH_SCREEN_PATH%
)

goto:StartLogMX

:GetKeyValue
SET str=%Line%
SET idx=%KeyLen%
SET /a idx+=1
REM SubString file line after end of key ("=")
CALL SET KeyValue=%%str:~%idx%%%
FOR /f "tokens=* delims= " %%a IN ("%KeyValue%") DO SET KeyValue=%%a
goto:eof

:GetKeyLength
IF DEFINED KeyStr (
	SET KeyStr=!KeyStr:~1!
	SET /a KeyLen+=1
	goto:GetKeyLength
)
goto:eof


REM *** Start LogMX
:StartLogMX
SET LOGMX_CLASSPATH=%LOGMX_HOME%\classes;%LOGMX_HOME%\parsers\classes;%LOGMX_HOME%\managers\classes;%LOGMX_HOME%\jar\logmx.jar;%LOGMX_HOME%\lib\*
SET LOGMX_CLASSPATH=%LOGMX_CLASSPATH%;%ADDITIONAL_CLASSPATH%
SET LIB_PATH=-Djava.library.path=%LOGMX_HOME%\lib
SET LOGMX_MAIN=com.lightysoft.logmx.LogMX
SET JVM_OPTIONS=-Xmx%MAX_MEMORY% %LIB_PATH% %SPLASH_SCREEN% %CONFIG_FILE% %LOGGING_PARAM% %JVM_EXTRA_OPTIONS%
SET PATH=%SPECIFIC_JRE_PATH%;%SPECIFIC_JRE_PATH%\bin;%LOGMX_HOME%\jre\bin;%PATH%
SET CMD_LINE=%JVM_OPTIONS% -cp "%LOGMX_CLASSPATH%" %LOGMX_MAIN% %USER_PARAMS%

IF "%CONSOLE%" == "" (
	START javaw %CMD_LINE%
) ELSE (
	java %CMD_LINE%
	GOTO:EOF
)

IF %ERRORLEVEL% EQU 0 GOTO:EOF

echo.
echo ** Error while starting LogMX. Typical issues:
echo **   - Unsupported Java version: LogMX needs Java 8 or higher
echo **   - LogMX JAR file not found
echo **   - License file not found (Professional version only)
echo **   - Ctrl+C was used to kill LogMX
echo.

PAUSE

ENDLOCAL
