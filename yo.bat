@echo off

cd C:\temp

setlocal enableDelayedExpansion

call npm install -g yo generator-angular-basic

call yo angular-basic

rem set foo="bar"
rem echo %foo%

rem /F = loop thru files
rem /b = bare format output of dir
rem /o-d = sort output of dir, -d means sort by newest date 
rem /s = trawl sub-directories
rem /tc = sort by time created

rem for /F %%x IN ('dir /b/o-d/s/tc *.csproj') DO (
rem	 %%x 
rem )

::build "array" of folders
set folderCnt=0
for /f "eol=: delims=" %%F in ('dir /b/o-d/s/tc *.csproj') do (
  set /a folderCnt+=1
  set "folder!folderCnt!=%%F"
)

:: open first entry
!folder1!

rem pause