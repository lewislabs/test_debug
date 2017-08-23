Param(
    [Parameter(Mandatory = $True, ParameterSetName = "StartDebugging")]
    [switch]$StartDebugging,
    [Parameter(Mandatory = $True, ParameterSetName = "Build")]
    [switch]$Build,
    [Parameter(Position = 1)]
    [string] $debuggerPath,
    [Parameter(Position = 2)]
    [string] $otherStuff
)


$containerName = "test-debug"

function Build() {
    Write-Host "Building image"
    dotnet publish
    docker build -t test-debug:dev-image "bin\Debug\netcoreapp1.1\publish"
    Write-Host "Finished building image"
    Write-Host "Starting up container"
    $containerId = (docker ps -f "name=$containerName" -q -n=1)
    if ([System.String]::IsNullOrWhiteSpace($containerId)) {
        Write-Error "Could not find a container named $containerName"
    }
    else {
        docker rm -f $containerId
    }
    docker run -d --name $containerName test-debug:dev-image
}

function StartDebugging () {
    Write-Host "Starting debugging"

    docker exec -i $containerName /vsdbg/vsdbg --interpreter=vscode
}

if ($Build) {
    Build
}
elseif ($StartDebugging) {
    StartDebugging
}