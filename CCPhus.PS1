Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

# Invoke-Item (start powershell -windowstyle minimized ($PSScriptRoot + "\CCPhus.API\CCPhus.API.PS1")) <# alternatively, "-windowstyle hidden" can be used #>
# Invoke-Item (start powershell -windowstyle minimized ($PSScriptRoot + "\CCPhus.SPA\CCPhus.SPA.PS1")) <# alternatively, "-windowstyle hidden" can be used #>

$api = New-Object system.Diagnostics.ProcessStartInfo
$api.FileName = "powershell.exe"
$api.Arguments = "-noprofile -command ($PSScriptRoot\CCPhus.API\CCPhus.API.PS1)"
[system.Diagnostics.Process]::Start($api)

$spa = New-Object system.Diagnostics.ProcessStartInfo
$spa.FileName = "powershell.exe"
$spa.Arguments = "-noprofile -command ($PSScriptRoot\CCPhus.SPA\CCPhus.SPA.PS1)"
[system.Diagnostics.Process]::Start($spa)

# netstat -a -n -o | find "5000"
# netstat -a -n -o | find "5001"
# netstat -a -n -o | find "4200"
