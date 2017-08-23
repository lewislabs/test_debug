# test_debug
Trying to debug .NET Core on docker from vscode

## Pre-requisites
- .NET Core sdk - https://www.microsoft.com/net/download/core
- Docker for Windows - https://store.docker.com/editions/community/docker-ce-desktop-windows
- VS Code - https://code.visualstudio.com/download
- C# extension for VS Code - https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp
- Powershell

## Running 
- Open the repo in VS Code. 
- Set a breakpoint somewhere in [`Program.cs`](Program.cs)
- Hit F5 - this should run the `preLaunchTask=build`, which will run the build function of [`dockerTask.ps1`](dockerTask.ps1). This builds a docker image for running the app in, it then starts up a container from this image. After that the launch task should run and your breakpoint should get hit!


**NOTE: I can't get this working right now with the following environment:**

