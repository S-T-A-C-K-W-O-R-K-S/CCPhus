Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

Invoke-Item (start powershell -windowstyle minimized ($PSScriptRoot + "\CCPhus.API\CCPhus.API.PS1")) <# alternatively, "-windowstyle hidden" can be used #>
Invoke-Item (start powershell -windowstyle minimized ($PSScriptRoot + "\CCPhus.SPA\CCPhus.SPA.PS1")) <# alternatively, "-windowstyle hidden" can be used #>



<######################################################################## Job-Based Script

$ApplicationRoot = (Get-Location).Path
Write-Host "Executing Script From: $ApplicationRoot"

Start-Job -Name CCPhus.API -FilePath .\CCPhus.API\CCPhus.API.PS1 -Verbose
Start-Job -Name CCPhus.SPA -FilePath .\CCPhus.SPA\CCPhus.SPA.PS1 -Verbose

########################################################################>
