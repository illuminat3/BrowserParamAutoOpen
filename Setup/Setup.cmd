@echo off
setlocal

set SCHEME=autoopen
set APP_PATH="C:\Users\Matthew\source\repos\BrowserParamAutoOpen\BrowserParamAutoOpen\bin\Release\net8.0-windows\BrowserParamAutoOpen.exe"

echo Registering the %SCHEME% protocol...

reg add "HKCU\Software\Classes\%SCHEME%" /ve /d "URL:%SCHEME% Protocol" /f
reg add "HKCU\Software\Classes\%SCHEME%" /v "URL Protocol" /f

reg add "HKCU\Software\Classes\%SCHEME%\shell\open\command" /ve /d "%APP_PATH% \"%%1\"" /f

echo %SCHEME% protocol has been registered successfully.
pause
