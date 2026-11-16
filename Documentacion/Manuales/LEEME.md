# Manuales de OpenRIN

Tres entregables en PDF (el original los edita el HTML que figura en `Fuentes/`) y un archivo de ayuda en línea (HTML Help `.chm`).

| Archivo | Qué es | Cómo se abre |
|---|---|---|
| `Manual-de-instalacion.pdf` | **D01** — instalación completa del sistema (SQL Server, bases, demo, verificación post-instalación, desinstalación). | Apertura directo (PDF). |
| `Manual-de-usuario.pdf` | Guía de uso para el consultorio: log-in, RIN, alertas, agenda, seguimiento, reportes, portal del paciente y roles. | Apertura directo (PDF). |
| `OpenRIN-Ayuda.chm` | **D02** — ayuda en línea (la misma que abren el botón Ayuda y F1 dentro de la app). Es el archivo que el instalador copia junto al ejecutable. | Doble clic (Windows desbloquea CHMs por seguridad: elegir «Desbloquear» si SmartScreen lo advierte). |
| `Manual de Programacion (documento).pdf` | **Manual de programación** — arquitectura, módulos, patrones, base de datos, integridad (DVH/DVV), respaldos, factory por reflexión, excepciones y modelo de datos. | Apertura directo (PDF). |

## Notas

- Fecha de generación actual: **2026-11-12** (reconstruidos desde `Fuentes/_fuente` con los datos corregidos: clave de demostración **aleatoria por instalación** — no hay claves conocidas publicadas —, **103 comprobaciones** en la suite y capturas/tablas actualizadas). La revisión y las correcciones del docente están en [`../Revision/`](../Revision/) (`Observaciones - OpenRIN.docx`, `Correcciones - texto de reemplazo.docx`).
- `Fuentes/` guarda los originales editables: documentos Word de cada manual (`docx/`), las capturas que incluyen (`capturas/`) y los generadores (`_fuente/`, Node.js + Edge headless para los PDF). Registro de cambios de esta generación: [`Fuentes/_fuente/CAMBIOS.md`](Fuentes/_fuente/CAMBIOS.md).
- El CHM del **Manual del Programador** se retiró: la compilación 1999 de HTML Help Workshop no corre de forma confiable en instalaciones actuales (verificado en esta máquina), y su contenido estaba desactualizado; la ayuda en línea de usuario (`OpenRIN-Ayuda.chm`) sí sigue vigente y es la que usa la app.
- Las contraseñas de demostración que mencionan los manuales son valores generados en la instalación; en una nueva instalación se generan **nuevas** claves aleatorias (ver `Instalador/BUILD.md`).
- Capturas conservadas de la versión anterior (hay pantallas a re-fotografiar al integrar los cambios visuales: pestaña Respaldos, pantalla de Integridad Vulnerada con recuperación).
