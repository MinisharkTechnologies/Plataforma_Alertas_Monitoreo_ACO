<# OpenRIN - Desinstalador. Quita la aplicación, los accesos directos y la tarea de respaldo.
   Las bases de datos y los respaldos NO se borran, salvo que se indique -QuitarBases. #>
param([switch]$QuitarBases, [switch]$Silencioso)
$ErrorActionPreference = "Stop"
$esAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $esAdmin) { Start-Process powershell -Verb RunAs -ArgumentList "-NoProfile -ExecutionPolicy Bypass -File `"$($MyInvocation.MyCommand.Path)`"" -Wait; exit }
$destino = Split-Path -Parent $MyInvocation.MyCommand.Path
Get-Process -Name "Negocio.UI" -ErrorAction SilentlyContinue | Stop-Process -Force
Unregister-ScheduledTask -TaskName "OpenRIN - Respaldo Nocturno" -Confirm:$false -ErrorAction SilentlyContinue
Remove-Item (Join-Path ([Environment]::GetFolderPath("CommonDesktopDirectory")) "OpenRIN.lnk") -Force -ErrorAction SilentlyContinue
Remove-Item (Join-Path ([Environment]::GetFolderPath("CommonPrograms")) "OpenRIN") -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\OpenRIN" -Recurse -Force -ErrorAction SilentlyContinue
if ($QuitarBases) {
    $destino = Split-Path -Parent $MyInvocation.MyCommand.Path
    $cfg = [IO.File]::ReadAllText((Join-Path $destino "Negocio.UI.dll.config"))
    if ($cfg -match "Server=([^;]+);Database=OpenRIN_Negocio") {
        $servidor = $Matches[1]
        # Copia previa obligatoria antes de borrar las bases: sin respaldo verificado, no se eliminan.
        $herr = Join-Path $destino "OpenRIN.Herramientas.exe"
        $respaldosOk = $false
        if (Test-Path $herr) {
            & $herr respaldo
            $respaldosOk = ($LASTEXITCODE -eq 0)
        } else {
            $carpeta = Join-Path $env:SystemDrive "OpenRIN\Backups"
            New-Item -ItemType Directory -Force -Path $carpeta | Out-Null
            $cm0 = New-Object System.Data.SqlClient.SqlConnection "Server=$servidor;Database=master;Integrated Security=True"; $cm0.Open()
            foreach ($bd in "OpenRIN_Negocio", "OpenRIN_Services") {
                $rb = Join-Path $carpeta ($bd + "_previa_desinstalacion_" + (Get-Date -Format "yyyyMMdd_HHmmss") + ".bak")
                $rbSafe = $rb -replace "'", "''"
                $m0 = $cm0.CreateCommand()
                $m0.CommandText = "BACKUP DATABASE [$bd] TO DISK = N'$rbSafe' WITH COPY_ONLY, CHECKSUM, INIT"
                $m0.CommandTimeout = 600
                try { [void]$m0.ExecuteNonQuery(); $respaldosOk = $true } catch { $respaldosOk = $false; Write-Warning "Falló el respaldo previo de $bd : $($_.Exception.Message)"; break }
            }
            $cm0.Close()
        }
        if (-not $respaldosOk) {
            Write-Host ""; Write-Host "No se pudo hacer el respaldo previo de las bases: se CONSERVAN (no se eliminó nada)." -ForegroundColor Red
            Write-Host "Realice una copia de seguridad manual o ejecute sin -QuitarBases y vuelva a intentarlo."
        } else {
            $c = New-Object System.Data.SqlClient.SqlConnection "Server=$servidor;Database=master;Integrated Security=True"; $c.Open()
            foreach ($bd in "OpenRIN_Negocio", "OpenRIN_Services") {
                $m = $c.CreateCommand()
                $m.CommandText = "IF DB_ID('$bd') IS NOT NULL BEGIN ALTER DATABASE [$bd] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [$bd]; END"
                [void]$m.ExecuteNonQuery()
            }
            $c.Close()
            Write-Host "Bases eliminadas. Se conservó una copia previa en $(Join-Path $env:SystemDrive 'OpenRIN\Backups')."
        }
    }
}
# El script se ejecuta desde la carpeta de instalación: se borra al finalizar.
Start-Process cmd -ArgumentList "/c timeout /t 2 >nul & rmdir /s /q `"$destino`"" -WindowStyle Hidden
$estado = if ($QuitarBases) { "fueron eliminadas" } else { "se conservan (use -QuitarBases para eliminarlas)" }
Write-Host "OpenRIN se desinstaló. Las bases de datos $estado."
if (-not $Silencioso) { [void](Read-Host "Presione Enter para cerrar") }
