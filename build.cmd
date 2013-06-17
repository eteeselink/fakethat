@echo off
pushd %~dp0
del /q FakeThat\bin\Release\*
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe FakeThat.sln /t:Rebuild /p:Configuration=Release
nuget spec -AssemblyPath FakeThat\bin\Release\FakeThat.dll