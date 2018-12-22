@echo off

cd C:\temp

setlocal enableDelayedExpansion

rem call npm install -g yo generator-angular-basic

rem call yo angular-basic

:: set foo="bar"
:: echo %foo%

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

echo you picked !folder1!

::print menu
:: for /l %%N in (1 1 %folderCnt%) do echo %%N - !folder%%N!
:: echo(

:: :get selection
:: set selection=
:: set /p "selection=Enter a folder number: "
:: echo you picked %selection% - !folder%selection%!


pause