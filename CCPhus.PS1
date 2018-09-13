Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

Invoke-Item (start powershell -windowstyle minimized ($PSScriptRoot + "\CCPhus.API\CCPhus.API.PS1")) <# alternatively, "-windowstyle hidden" can be used #>
Invoke-Item (start powershell -windowstyle minimized ($PSScriptRoot + "\CCPhus.SPA\CCPhus.SPA.PS1")) <# alternatively, "-windowstyle hidden" can be used #>

# netstat -a -n -o | find "5000"
# netstat -a -n -o | find "5001"
# netstat -a -n -o | find "4200"
