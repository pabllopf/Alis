#!/bin/bash

sudo workload install maccatalyst wasm-tools maui-windows maui-ios maui-android ios android

sudo dotnet tool install --global dotnet-document --version 0.1.4-alpha

./restart_permissions.sh

