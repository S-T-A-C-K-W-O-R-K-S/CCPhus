Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

ng serve --configuration production



<################################################### Job-Based Script

$ScriptDirectory = (Get-Location).Path
Write-Host "Executing Script From: $ScriptDirectory"

ng serve --configuration production

###################################################>
