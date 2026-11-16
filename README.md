# OpenRIN — Plataforma Integral de Alertas y Monitoreo para Pacientes Anticoagulados

**Autor:** Carlos Santiago Muñiz Cortés
**Profesor:** Gastón Matías Weingand
**Institución:** Colegio Leonardo Da Vinci
**Materia:** Prácticas Profesionalizantes III · **Año:** 2026

[Español] · [English](README.en.md) · [中文](README.zh-CN.md)

## Descripción

OpenRIN es una plataforma de escritorio para consultorios hematológicos, orientada al seguimiento de pacientes anticoagulados: centraliza la gestión de pacientes e historias clínicas, la recepción de mediciones de RIN, la clasificación automática de criticidad con generación de alertas, la agenda de turnos con reasignación inteligente, el seguimiento clínico con protocolo de contacto y escalada, los reportes estadísticos de eficacia, el portal del paciente y las herramientas de administración y seguridad del sistema.

La solución está construida en **C# / .NET 8 (Windows Forms)** sobre **SQL Server**, con arquitectura multicapa, y cubre de punta a punta el circuito del consultorio: paciente → control de RIN → alerta → turno → seguimiento → reporte.

## Novedades de esta versión (v1.2, Noviembre 2026)

- **Instalador de un clic**: paquete autocontenido (`Instalador/` → `OpenRIN-Setup.exe`) que instala SQL Server 2022 Express si falta, crea las bases con esquema + semillas, instala la aplicación y **siembra datos de demostración** con clave aleatoria generada en la máquina destino (sin claves conocidas en este repositorio).
- **Respaldo nocturno recurrente**: tarea diaria 03:00 (`respaldo-auto`, salud verificada por DVH/DVV, retención de 10, registro en tabla `Respaldos`), además del respaldo al arranque de la aplicación y del panel **Respaldos** en el Sistema (respaldo manual, verificación y restauración con **copia previa obligatoria**, habilitados con el permiso **SI004 — Administrar respaldos y restauración**).
- **Recuperación de integridad en vivo**: si DVH/DVV detecta alteraciones, la app muestra la lista de registros alterados (tabla, Id, motivo) y permite — con permiso SI004 — **restaurar un respaldo sano** o **recalcular los dígitos** antes de llegar al log-in.
- **Cifrado simétrico AES-256 en campos clínicos**: los textos libres de eventos adversos, turnos, seguimientos y alertas se guardan cifrados en la base (`System.Security.Cryptography`), con IV derivado del contexto para que el DVH siga estable; las lecturas siguen devolviendo texto claro y los datos anteriores se cifran en su próximo guardado.
- **Fábrica de repositorios por reflexión** (claves `Repositorio.*`), encapsulación de repositorios (`internal`) y jerarquía de **excepciones de negocio** (`ReglaNegocioException` y derivadas) con mensajes accionables.
- **Suite «Pruebas»** (`Codigo/Pruebas/`): **103 comprobaciones** de aceptación contra una base real, todas en verde (ver LEEME allí); **Herramientas** CLI (`sembrar`, `respaldo`, `respaldo-auto`, `integridad`).
- **Entregable documental completo** en este repositorio: **Carpeta de Proyecto (PDF, 153 páginas)**, manual de instalación, de usuario y de programación (PDF + ayuda `.chm`, incluida F1 desde la app), diagramas en draw.io + PNG y la carpeta **`Prueba SQL/`** con la demostración guiada de DVH/DVV y de los respaldos.
- Build **0 errores / 0 advertencias**; smokes locales 40/40 (Negocio) y revisión completa de la solución.

## Integridad proactiva (v1.1)

- **DVH/DVV**: dígitos verificadores por fila y por tabla, firmados en el punto único de guardado y **verificados al iniciar la aplicación, antes del log-in**.
- **Permisos con patrón Composite**: árbol de permisos atómicos y compuestos con códigos únicos (editable desde el Sistema; el gating de módulos migrado a códigos).
- **Internacionalización dinámica**: español (Latinoamérica), inglés y chino simplificado, con los idiomas y sus leyendas **en la base de datos** (sin hojas de recursos en tiempo de ejecución); cambio de idioma en caliente mediante patrón observer.
- **Control de cambios con restauración**: historial de auditoría con estado anterior/nuevo y la acción *Restaurar estado anterior* (recompone y vuelve a firmar).
- **PDF con librería de terceros** (QuestPDF, licencia comunitaria) para reportes e historiales, junto con exportación a **Excel** y **JSON**.
- **Respaldos automáticos**: respaldo diario de ambas bases (03:00) con verificación de integridad de cada copia.

## Estructura del repositorio

- `Codigo/` — solución .NET: `Negocio.UI` (Windows Forms), `Negocio.BLL`, `Negocio.DAL`, `Negocio.DomainModel`, `Services` (DomainModel, BLL, DAL, Facade), **`Pruebas/`** (103 comprobaciones) y **`Herramientas/`** (CLI).
- `Documentacion/` — **Carpeta de Proyecto (PDF, 153 páginas)** y manuales ([`Manuales/`](Documentacion/Manuales/): instalación, usuario, programación y ayuda `.chm`).
  - `Documentacion/Revision/` — observaciones del docente y detalle de correcciones aplicadas.
  - `Documentacion Antigua antes de Septiembre/` — entregables históricos de análisis y diseño (no modificar).
- `Diagramas/` — diagramas en draw.io (editables) y PNG exportados (arquitectura, DER, procesos, UC-01..UC-13, T02 y diagramas de clases nuevos).
- `Instalador/` — instalador de un clic (IExpress + PowerShell); ver [`Instalador/BUILD.md`](Instalador/BUILD.md).
- `Propuesta Corregida/` — propuesta de proyecto (TP 1).
- `Prueba SQL/` — demostración guiada de integridad (DVH/DVV) y respaldos (solo base demo).
- `ops/` — utilitarios de operación del repositorio.

## Arquitectura

- **Capas**: Presentación (WinForms) → Lógica de Negocio (BLL) y Fachada de Servicios → Acceso a Datos (DAL) → Bases de datos.
- **Dos vías de persistencia**: **Entity Framework Core** para el dominio del negocio (contexto con configuración Fluent y punto único de guardado) y **ADO.NET** para la base de servicios (seguridad, idiomas, permisos, bitácora).
- **Bases**: `OpenRIN_Negocio` (13 tablas con firmas de integridad y auditoría de cambios) y `OpenRIN_Services` (seguridad, idiomas, permisos, bitácora y registro de respaldos).
- **Patrones**: Singleton (sesión), Composite (permisos), Observer (idiomas), Repository (pacientes) y Facade (servicios técnicos).

## Requisitos

- Windows 10/11.
- .NET 8 (Desktop).
- SQL Server 2019 o superior (la edición Express es suficiente; el instalador la instala si falta).

> Las credenciales y configuraciones locales **no se versionan** en este repositorio.

## Instalación y ejecución

**Como entregable**: ejecutar `OpenRIN-Setup.exe` (ver [`Instalador/BUILD.md`](Instalador/BUILD.md) para compilarlo desde este repositorio; un ejecutable precompilado puede publicarse en la sección Releases del repositorio). Instala SQL Server Express si falta, crea y siembra las bases y deja accesos directos.

**Para desarrollo**:
1. Crear las bases `OpenRIN_Negocio` y `OpenRIN_Services`; aplicar los scripts idempotentes desde `Codigo/Services/DAL/Tools/` (`script.sql` — bitácora, `security.sql` — seguridad, `permisos.sql` — permisos, `localizacion.sql` + `localizacion_seed.sql` — idiomas, `respaldos.sql` — registro de respaldos; con `sqlcmd -f 65001`) y `Codigo/Negocio.DAL/Tools/script.sql` (esquema completo de negocio, incluido el bloque de migraciones y su historial).
2. Configurar la cadena de conexión local (archivo de configuración no versionado; ver `Codigo/Negocio.UI/App.config.example`).
3. Compilar y ejecutar: `dotnet build` y luego el proyecto `Negocio.UI`.

Al iniciar, la aplicación verifica la integridad de la base **antes** de mostrar el inicio de sesión; si la base está alterada, la pantalla de bloqueo lista los registros afectados y permite, con permiso **SI004**, restaurar un respaldo sano o recalcular los dígitos.

## Documentación completa

La **[Carpeta de Proyecto](Documentacion/)** contiene el documento entregable completo: descripción global del producto, diagramas de clases por capa, modelo de datos, especificación de los cinco procesos de negocio y de los **trece casos de uso** (con secuencias, clases afectadas y pantallas reales del sistema), y los aspectos técnicos (arquitectura, sesión, encriptación, perfiles, multiidioma, bitácora, control de cambios, respaldos e integridad). Los manuales (instalación, usuario, programación) están en [`Documentacion/Manuales/`](Documentacion/Manuales/).

## Licencia

Copyright (C) 2026 Carlos Santiago Muñiz Cortés. Publicado bajo la **GNU General Public License v3.0** (ver [`LICENSE`](LICENSE) y [`NOTICE.txt`](NOTICE.txt)). Puede redistribuir OpenRIN y sus derivados bajo los términos de la GPLv3: los derivados deben mantenerse abiertos bajo la misma licencia (copyleft fuerte). Las dependencias de terceros conservan sus licencias propias (QuestPDF Community License, gratuita para proyectos open source y entidades pequeñas; el resto, MIT).

## Estado del proyecto

Entregable de Noviembre 2026. El alcance funcional está completo y verificado; los pendientes son propios de la fase final de cátedra.
