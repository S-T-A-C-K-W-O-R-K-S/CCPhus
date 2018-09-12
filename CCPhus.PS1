Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

Invoke-Item (start powershell ($PSScriptRoot + "\CCPhus.API\CCPhus.API.PS1"))
Invoke-Item (start powershell ($PSScriptRoot + "\CCPhus.SPA\CCPhus.SPA.PS1"))
