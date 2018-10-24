Push-Location $PSScriptRoot
Write-Host "Executing Script From: $PSScriptRoot"

$scripts="$PSScriptRoot\CCPhus.API\CCPhus.API.PS1","$PSScriptRoot\CCPhus.SPA\CCPhus.SPA.PS1"

foreach ($script in $scripts)
    {Invoke-Item (start powershell $script -windowstyle minimized)} <# "-windowstyle hidden" works too #>

# netstat -a -n -o | find "5000"
# netstat -a -n -o | find "5001"
# netstat -a -n -o | find "4200"
