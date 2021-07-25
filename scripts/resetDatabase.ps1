
function ResetDatabase {
    param (
        [Parameter(Mandatory = $true)]
        [string]$databaseName        
    )

    Import-Module -Name SqlServer
    $server = New-Object Microsoft.SqlServer.Management.Smo.Server("(local)")

    # Delete existing database
    try { 
        $applicationDatabase = New-Object Microsoft.SqlServer.Management.Smo.Database($server, $databaseName)
        $applicationDatabase.Refresh()
        $applicationDatabase.Drop()
    } catch  {}

    # Create new database
    $applicationDatabase = New-Object Microsoft.SqlServer.Management.Smo.Database($server, $databaseName)
    $applicationDatabase.Create()
}

if (!(Get-Module -ListAvailable -Name SqlServer)) {
    Write-Host "Powershell SqlServer module is not installed. You must install it by running the command:"
    Write-Host "Install-Module -Name SqlServer -AllowClobber -Repository PSGallery -Force"
}
else {
    ResetDatabase  "Forest"
}
