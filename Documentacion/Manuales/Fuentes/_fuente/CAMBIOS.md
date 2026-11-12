# CAMBIOS — reconstrucción 2026-11-12

Regeneración de los manuales desde los archivos de contenido de esta carpeta (Edge headless + PDF). `hhc.exe` no disponible en esta máquina (ver nota abajo sobre el CHM del manual de programación).

## Qué cambió respecto de la entrega 2026-11-06

- **Clave de demostración aleatoria**: se eliminó toda referencia a una clave conocida (`Demo2026!` o similar) en los manuales de instalación y usuario. La tabla de usuarios iniciales de la demo ahora dice «(aleatoria por instalación)» y explica cómo obtenerla (consola del instalador, o `OpenRIN.Herramientas.exe sembrar` sin argumentos, imprime una única vez).
- **Suite de pruebas**: en «Manual de programación» la referencia «62 comprobaciones» pasó a **103 comprobaciones**, y la sección de preparación cita `localizacion_seed.sql` (364 claves por idioma, MERGE idempotente con `sqlcmd -f 65001`) y el aviso de que la suite **restaura la base de negocio dentro de la prueba** (ejecutar solo contra bases de desarrollo/demo).
- **i18n**: se verificó que los manuales ya describen la arquitectura vigente (textos e idiomas en la base, MERGE idempotente, «los textos se ven como claves → localizacion_seed.sql»), coherente con la decisión «DB-driven» del proyecto.
- **CHM del manual de programación retirado**: HTML Help Workshop 1999 no compila de forma fiable en Windows actual (verificado); el contenido actualizado queda en `Manual de Programacion (documento).pdf`. La ayuda en línea de usuario (`OpenRIN-Ayuda.chm`) se conservó (sin referencias a credenciales; verificada).

## Cómo reconstruir

```powershell
node construir_manuales.mjs <carpeta-de-capturas> <carpeta-de-salida> [hhc.exe] [msedge.exe]
```
Los PDFs se generan con Microsoft Edge headless (`--print-to-pdf`). El CHM requiere un `hhc.exe` operativo (HTML Help Workshop clásico); no es imprescindible para el entregable.

## Actualización 2026-11-12 (tarde): cifrado AES-256 determinístico documentado

- Se agregó a la sección **Seguridad** (manual de programación y de usuario) la descripción del **cifrado AES-256
  determinístico** aplicado a los 7 campos clínicos de texto libre, con IV derivado del contexto para conservar el DVH,
  prefijo `AES1$` en la columna y fallback de datos legacy.
- «103 comprobaciones» → **109 comprobaciones** (la suite ahora valida también el cifrado: determinismo, round-trip,
  aislamiento por contexto y verificación end-to-end del ciphertext en la base).
- Nota de la sección: las contraseñas/respuestas siguen con PBKDF2 (hash irreversible) y DNI/teléfono/email quedan en claro
  a propósito (igualdad/unicidad), documentado para la defensa.
