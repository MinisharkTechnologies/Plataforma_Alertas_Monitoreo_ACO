# Manuales de OpenRIN

Tres entregables en PDF (el original los edita el Word/HTML que figura en `Fuentes/`) y dos archivos de ayuda en línea (HTML Help `.chm`).

| Archivo | Qué es | Cómo se abre |
|---|---|---|
| `Manual-de-instalacion.pdf` | **D01** — instalación completa del sistema (SQL Server, bases, demo, verificación post-instalación, desinstalación). | Apertura directo (PDF). |
| `Manual-de-usuario.pdf` | Guía de uso para el consultorio: log-in, RIN, alertas, agenda, seguimiento, reportes, portal del paciente y roles. | Apertura directo (PDF). |
| `OpenRIN-Ayuda.chm` | **D02** — ayuda en línea (la misma que abren el botón Ayuda y F1 dentro de la app). Es el archivo que el instalador copia junto al ejecutable. | Doble clic (Windows desbloquea CHMs por seguridad: elegir «Desbloquear» si SmartScreen lo advierte). |
| `Manual de Programacion (documento).pdf` | **Manual de programación** — arquitectura, módulos, patrones, base de datos, integridad (DVH/DVV), respaldos, factory por reflexión, excepciones y modelo de datos. | Apertura directo (PDF). |
| `Manual del Programador (ayuda .chm).chm` | Versión de ayuda en línea del manual de programación. | Doble clic (ver nota del CHM arriba). |

## Notas

- Fecha de generación de estos artefactos: **2026-11-06**; la revisión y las correcciones aplicadas están en [`../Revision/`](../Revision/) (`Observaciones - OpenRIN.docx` con las indicaciones del docente, `Correcciones - texto de reemplazo.docx` con el detalle de qué se cambió y dónde).
- `Fuentes/` guarda los originales editables: el documento Word de cada manual (`docx/`), las capturas que incluyen (`capturas/`) y los generadores (`_fuente/`, Node.js + Chromium/Skia para los PDF). Sirve solo a mantenimiento: el entregable para consumir son los PDF/CHM de arriba.
- Las contraseñas de demostración que mencionan los manuales son valores de ejemplo del entorno de prueba; en una instalación real la contraseña de la demo se **genera aleatoria** durante la instalación (ver `Instalador/BUILD.md`).
- Capturas conservadas de la versión anterior (hay pantallas a re-fotografiar al integrar los cambios visuales: pestaña Respaldos, pantalla de Integridad Vulnerada con recuperación).
