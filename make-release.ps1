$version =  Read-Host "Enter version"
$version = $version.Trim()

& "c:\Program Files\7-Zip\7z.exe" a Releases\Mug-$version.7z Mug\bin\Release\*

Write-Host "Done! Don't forget to git tag -a Mug-$version"

$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")