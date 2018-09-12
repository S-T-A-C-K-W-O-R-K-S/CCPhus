Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

$ENV:ASPNETCORE_ENVIRONMENT = "Production"
Write-Host "Environment: $ENV:ASPNETCORE_ENVIRONMENT"

dotnet watch run
