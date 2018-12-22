echo off

cd C:\temp

rem call npm install -g yo generator-angular-basic

rem call yo angular-basic

set foo="bar"
echo %foo%

dir /s/b *.csproj

rem find most recent .csproj file in all top level folders only
for /R %%x in (*.csproj) do Echo "%%x" 


rem cd a
rem a.csproj

pause

