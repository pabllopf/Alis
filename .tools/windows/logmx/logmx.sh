#!/bin/sh

# === LogMX start script for UNIX/Linux/Mac ===
#
# DO NOT MODIFY THIS FILE: Use startup config file ("startup.conf") instead to set startup settings
#
# Expected arguments for this script are:
#
# file1 file2 ... fileN
#    -> Open log files "file1", "file2", ... and "fileN" in LogMX
#
# --conf="StartupConfFile"
#    -> Ignore default startup config file (startup.conf) and use file path "StartupConfFile" instead
#       DOUBLE QUOTES AROUND FILE PATH IS MANDATORY if file path contains space(s) character(s)
#       This 'startup config file' allows you to tune the maximum amount of memory that LogMX can use,
#       the specific Java path to use, the specific preferences file to use, ...
#
# --console
#    -> Use console mode (see possible options using --help)
#
# Here are some examples:
# ./logmx.sh logs/my_log.txt
#    -> Will open file "logs/my_log.txt" in LogMX
# ./logmx.sh logs/my_log.txt logs/my_log2.txt
#    -> Will open files "logs/my_log.txt" and "logs/my_log2.txt" in LogMX
# ./logmx.sh --conf=/mypath/my_startup.conf logs/my_log.txt
#    -> Will open file "logs/my_log.txt" with LogMX started with startup config file "/mypath/my_startup.conf"
#


# Get LogMX directory
LOGMX_PATH=`dirname "$0"`

# Set default startup config
STARTUP_CONF_FILE="$LOGMX_PATH/startup.conf"
SPLASH_SCREEN="$LOGMX_PATH/pics/splash_screen.png"
MAX_MEMORY=1G
CONFIG_FILE="-Dnop"  # Workaround for Shell limitation (variable containing quotes)
LOGGING_PARAM=""
JVM_EXTRA_OPTIONS=""

# Examine parameters passed to this script
for param in "$@"
do
	if [ "$param" = "--console" ]; then
		# Disable splash screen for Console Mode
		SPLASH_SCREEN=
	else
		SUB_PARAM=`echo $param | sed 's/^.*--conf=\(.*\)$/\1/'`
		if  [ "$param" != "$SUB_PARAM" ]; then 
			# Use the specified startup config file
			STARTUP_CONF_FILE="$SUB_PARAM"
		fi
		
	fi
done

# Read Startup config file
while read Line
do
	Line=`echo $Line | sed 's/^\([ ]*#.*\)$//' | tr -d '\r'`
	if [ -n "$Line" ]; then
		Key=`echo $Line | sed 's/^\([^=]*\)=.*$/\1/' | sed 's/ //'`
		Value=`echo $Line | sed 's/^[^=]*=\(.*\)$/\1/' | sed 's/^[ ]*\(.*\)$/\1/'`
		if [ "$Key" = "JAVA_PATH" ]; then
			SPECIFIC_JRE_PATH="$Value"
		elif [ "$Key" = "MAX_MEMORY" ]; then
			if [ -n "$Value" ]; then
				MAX_MEMORY="$Value"
			fi
		elif [ "$Key" = "CONFIG_FILE" ]; then
			if [ -n "$Value" ]; then
				CONFIG_FILE="-Dconfig.file=$Value"
			fi
		elif [ "$Key" = "SPLASH_SCREEN" ]; then
			if [ "$Value" = "0" ]; then
				SPLASH_SCREEN=""
			fi
		elif [ "$Key" = "ADDITIONAL_CLASSPATH" ]; then
			ADDITIONAL_CLASSPATH="$Value"
		elif [ "$Key" = "INTERNAL_LOGGING" ]; then
			if [ "$Value" = "1" ]; then
				LOGGING_PARAM="-Djava.util.logging.config.file=config/logging.properties"
			fi
		elif [ "$Key" = "JVM_EXTRA_OPTIONS" ]; then
			JVM_EXTRA_OPTIONS="$Value"
		fi
	fi
done < $STARTUP_CONF_FILE

# Set Java command line options
LOGMX_CLASSPATH=$LOGMX_PATH/classes:$LOGMX_PATH/parsers/classes:$LOGMX_PATH/managers/classes:$LOGMX_PATH/jar/logmx.jar:$LOGMX_PATH/lib/*
LOGMX_CLASSPATH=$LOGMX_CLASSPATH:$ADDITIONAL_CLASSPATH
LOGMX_MAIN=com.lightysoft.logmx.LogMX
PATH=$SPECIFIC_JRE_PATH:$SPECIFIC_JRE_PATH/bin:$PATH

# Start LogMX
java -Xmx$MAX_MEMORY $JVM_EXTRA_OPTIONS -splash:"$SPLASH_SCREEN" $LOGGING_PARAM "$CONFIG_FILE" -cp "$LOGMX_CLASSPATH" $LOGMX_MAIN "$@"

