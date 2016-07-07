@echo off
setlocal enabledelayedexpansion
set "a=0"
:loop
start "" "F:\Endless\Server\Client\bin\Debug\Client.exe"
set /a "a=!a!+1"
echo ´ÎÊý!a!
if %a%==500 goto end
goto loop