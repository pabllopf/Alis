#!/bin/bash

echo "start"

year=$(grep -Eo '[0-9]\.[0-9]+.[0-9]+' ./Directory.Build.props)

echo "year is $year"



