SET Environment=%1
IF "%Environment%" == "" SET Environment=Development

REM Install node packages
cd ..\src\Client
call yarn install

REM Start front
start cmd /k yarn dev

REM Start back
cd ..\Web
start "Back" dotnet run --environment %Environment%

exit