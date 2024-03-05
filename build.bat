@echo off

taskkill /im Flow.Launcher.exe
pause 
set "sourceFolder=.\FandomSearch\Flow.Launcher.Plugin.FandomSearch\bin\Debug"
set "destinationFolder=C:\Users\jonas\AppData\Local\FlowLauncher\app-1.17.2\UserData\Plugins\FandomSearch-DEV\"

echo Copying files from %sourceFolder% to %destinationFolder%...

xcopy /E /I /Y "%sourceFolder%" "%destinationFolder%"

echo Copy completed.

echo Starting Flow Launcher...
start "" "C:\Users\jonas\AppData\Local\FlowLauncher\Flow.Launcher.exe"

pause
