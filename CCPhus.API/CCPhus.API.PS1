Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

$ENV:ASPNETCORE_ENVIRONMENT = "Production"
Write-Host "Environment: $ENV:ASPNETCORE_ENVIRONMENT"

dotnet watch run



<#################################################### Job-Based Script

$ScriptDirectory = (Get-Location).Path
Write-Host "Executing Script From: $ScriptDirectory"

$ENV:ASPNETCORE_ENVIRONMENT = "Production"
Write-Host "Environment: $ENV:ASPNETCORE_ENVIRONMENT"

dotnet watch run

####################################################>
