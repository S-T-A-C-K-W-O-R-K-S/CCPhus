Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

& "$PSScriptRoot\CCPhus.API\CCPhus.API.PS1"
& "$PSScriptRoot\CCPhus.SPA\CCPhus.SPA.PS1"