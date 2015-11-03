@echo off
If "%1" == "Debug" Goto Debug
If "%1" == "Release" Goto Release
If "%1" == "TestDebug" Goto TestDebug
If "%1" == "TestRelease" Goto TestRelease

echo Usage: build [Debug|Release|TestDebug|TestRelease]
Goto Done

:Debug
devenv fizzandbuzz.sln /build Debug
Goto Done;

:Release
devenv fizzandbuzz.sln /build Release
Goto Done;

:TestDebug
mstest /testcontainer:FizzBuzzTest\bin\Debug\FizzBuzzTest.dll
Goto Done;

:TestRelease
mstest /testcontainer:FizzBuzzTest\bin\Release\FizzBuzzTest.dll
Goto Done;

:Done
echo @on