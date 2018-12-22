@echo off

cd C:\temp

setlocal enableDelayedExpansion

call npm install -g yo generator-angular-basic

call yo angular-basic

rem set foo="bar"
rem echo %foo%

::build "array" of .csproj files in sub-folders
set folderCnt=0
rem /F = loop thru files
rem /b = bare format output of dir
rem /o-d = sort output of dir, -d means sort by newest date 
rem /s = trawl sub-directories
rem /tc = sort by time created
for /f "eol=: delims=" %%F in ('dir /b/o-d/s/tc *.csproj') do (
  set /a folderCnt+=1
  set "folder!folderCnt!=%%F"
)

:: open last .csproj in "array" which is the .csproj file we just created
rem set selection=%folderCnt%
!folder%folderCnt%!

rem pause

rem https://stackoverflow.com/questions/10544646/dir-output-into-bat-array