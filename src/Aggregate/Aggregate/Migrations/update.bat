
ECHO Checking for 'dotnet ef' installation...
(dotnet tool list -g | findstr "dotnet-ef") > nul

IF ERRORLEVEL 1 (
    ECHO 'dotnet ef' is not installed.
    ECHO Installing 'dotnet ef'...
    dotnet tool install --global dotnet-ef
    ECHO 'dotnet ef' has been installed.
)

SET DATABASE=postgres
SET VERSION=1.0.0
dotnet ef database update --project ../Aggregate.csproj
echo %VERSION%
pause