@echo off
@setlocal enableextensions
@cd /d "%~dp0"

set origin=Unity-Rabbit
set clone=_%origin%Clone
mkdir %clone%
call:makeSymlink %clone%\ProjectSettings %origin%\ProjectSettings
call:makeSymlink %clone%\Assets %origin%\Assets
call:makeSymlink %clone%\Packages %origin%\Packages

goto:eof

::--------------------------------------------------------
::-- Make correct symlink
::--------------------------------------------------------
:makeSymlink
echo I'm making symlink %~1 pointing at %~2...
if not exist %~2 (
	echo.
	echo There should already exist %~2 ! 
	echo Something is going wrong, I'm quitting :-(
	echo.
	pause
	exit
)
if exist %~1 (
  echo Removing old version of %~1
  rmdir /q %~1
)
mklink /j %~1 %~2
goto:eof

::--------------------------------------------------------
::-- Check for directory
::--------------------------------------------------------
:checkDir
if not exist %~1 (
	echo.
	echo There should already exist %~1 ! 
	echo Something is going wrong, I'm quitting :-(
	echo.
	pause
	exit
)
goto:eof
