echo off

cd C:\temp

call npm install -g yo generator-angular-basic

call yo angular-basic

rem set foo="bar"
rem echo %foo%

rem /F = loop thru files
rem /b = bare format output of dir
rem /o-d = sort output of dir, -d means sort by newest date 
rem /s = trawl sub-directories
rem /tc = sort by time created
for /F %%x IN ('dir /b/o-d/s/tc *.csproj') DO (
	 %%x 
)

rem echo hi1
rem pause
