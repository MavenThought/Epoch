@echo off
cls
if exist .\packages\FAKE\tools\Fake.exe (
	rem Fake already installed
) else (
	".nuget\NuGet.exe" "Install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion"
)

"packages\FAKE\tools\Fake.exe" "BuildTools/build.fsx" %*
