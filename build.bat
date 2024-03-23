@echo off

taskkill /im Flow.Launcher.exe
pause 
set "sourceFolder=.\FandomSearch\Flow.Launcher.Plugin.FandomSearch\bin\Debug"
set "destinationFolder=%APPDATA%\FlowLauncher\Plugins\FandomSearch-DEV"

echo Copying files from %sourceFolder% to %destinationFolder%...

xcopy /E /I /Y "%sourceFolder%" "%destinationFolder%"

echo Copy completed.
pause
