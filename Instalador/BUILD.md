# Compilar el instalador OpenRIN (Setup.exe)

Requisitos en la máquina de empaquetado:

- Windows 10/11 con `C:\Windows\System32\iexpress.exe` (incluido en el sistema).
- SDK de .NET (8 o superior; el proyecto apunta a `net8.0-windows` y se publica `win-x64` self-contained).
- El árbol completo de este repositorio (con `Codigo/` y `Documentacion/Manuales/OpenRIN-Ayuda.chm`).

## Un solo comando

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\Construir_Setup.ps1
```

Resultado: `Instalador\Salida\OpenRIN-Setup.exe` (~80 MB, self-contained) + su SHA256 impreso por consola. La salida `Instalador\Salida\` está ignorada por git (el .exe no se versiona; publicarlo como release/artefacto aparte).

## Qué hace

1. `dotnet publish` Release `-c Release -r win-x64 --self-contained true` de `Negocio.UI` y `OpenRIN.Herramientas`.
2. Arma `app.zip` + copia los scripts SQL desde `Codigo\Services\DAL\Tools\` (bitácora, seguridad, permisos, localización y su semilla, respaldos) y `Codigo\Negocio.DAL\Tools\script.sql` (esquema de negocio + migraciones).
3. Copia `OpenRIN-Ayuda.chm` junto a la aplicación (botón Ayuda y F1).
4. Genera el `OpenRIN-Setup.exe` con IExpress (instalación con mínima interacción, sin Visual Studio).

## Qué hará en la máquina destino

El instalador (`Instalar.ps1`), con elevación de administrador:

1. Instala SQL Server 2022 Express vía winget **si no hay ninguna instancia utilizable** (requiere sysadmin en la instancia elegida; no instala nada si ya existe).
2. Crea las bases `OpenRIN_Services` y `OpenRIN_Negocio` (si no existen) aplicando los scripts SQL (esquema + semillas de seguridad, permisos e idiomas).
3. Instala la aplicación en `Archivos de programa\OpenRIN`, escribe la configuración con autenticación integrada de Windows (sin contraseñas, `TrustServerCertificate=True`, respaldos en `C:\OpenRIN\Backups`).
4. Siembra los datos de demostración (`OpenRIN.Herramientas.exe sembrar`): crea `sysadmin`, `medico`, `recepcion`. **La clave de demostración se genera aleatoria y se muestra una única vez por consola** (o se usa `-ClaveDemo` para indicarla).
5. Crea accesos directos (escritorio y menú Inicio) y la tarea programada diaria 03:00 «OpenRIN - Respaldo Nocturno (app)» (`OpenRIN.Herramientas.exe respaldo-auto`, SYSTEM).
6. Registra la desinstalación en «Agregar o quitar programas» (ícono, versión, publisher, sin modificar/reparar).

Para desinstalar: menú Inicio → «Desinstalar OpenRIN». Las bases y los respaldos se **conservan**; `-QuitarBases` hace una copia previa obligatoria (vía Herramientas o BACKUP COPY_ONLY) y solo después elimina las bases.

## Verificación recomendada

Probar siempre en una VM limpia o en una cuenta desechable: doble clic en el .exe → verificar que la app arranca, los 3 usuarios demo existen (con la clave aleatoria impresa en consola), las bases tienen datos y el respaldo del día queda registrado en la tabla Respaldos y en la bitácora. Ver `Documentacion/Manuales/Manual-de-instalacion.pdf` (tests de post-instalación) y `Prueba SQL/LEEME.txt`.

## Notas y límites conocidos

- Es **IExpress**, no un `.msi`: sin rollback/repair ni actualización in-place (ver `Documentacion/` el PDF de la guía `.msi` para el camino VS Installer Projects: Visual Studio 2022 + proyecto Setup + acción personalizada, ícono BMP y `RemovePreviousVersions=True`).
- El ejecutable no está firmado (SmartScreen advertirá; revisar SHA256 publicado).
- `NT AUTHORITY\SYSTEM` recibe login y `db_owner` **solo** en las dos bases de OpenRIN (necesario para la tarea de respaldo); no recibe rol de servidor.
