cmdkey /delete:vscode-insiders-microsoft.login/account
cmdkey /delete:git:https://github.com
::shutdown -s -t 30 -c "may tinh se tat trong 30s nua"
taskkill /F /IM chrome.exe /T > nul

del /f/q/s database.sql >nul
del /f/q/s Report.docx >nul
del /f/q/s README.MD >nul

rmdir /q/s Tiki >nul

del /f/q/s %temp%\*.* >nul

