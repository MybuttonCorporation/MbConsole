@echo off
colorful -s "Launching MbConsole..." -f 2 -n
if "%~1"=="" (
start %~dp0Codebutton.exe -noCmd
)
if not "%~1"=="" (
start %~dp0Codebutton.exe %*
)