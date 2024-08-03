# build sveltekit app
echo "Building sveltekit app..."
bun run build

# Publish the application
echo "Publishing .net windows forms app..."
if (Test-Path -Path "./csharp-src/publish/win-x64") {
    Remove-Item -Path "./csharp-src/publish/win-x64" -Recurse -Force
}
dotnet publish csharp-src -p:PublishProfile=win-x64.pubxml

# copy ./build to ./csharp-src/publish/win-x64 and rename it to wwwroot
echo "Copying ./build to ./csharp-src/publish/win-x64 and renaming it to wwwroot..."
$destinationPath = "./csharp-src/publish/win-x64/wwwroot"
if (-Not (Test-Path -Path $destinationPath)) {
    New-Item -ItemType Directory -Path $destinationPath
}

Copy-Item -Path "./build/*" -Destination $destinationPath -Recurse -Force