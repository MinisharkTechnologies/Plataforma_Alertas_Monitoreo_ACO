# Arquitectura — Criterios de clasificación de archivos

Este documento define **dónde vive cada archivo** del sistema y por qué. Sirve para que
cualquier programador nuevo (o el docente) pueda decidir sin ambigüedad si un archivo
nuevo pertenece a **Negocio** o a **Services**.

## Los dos pilares

| Pilar | Qué representa | Proyectos |
|---|---|---|
| **Negocio** | El producto clínico: pacientes anticoagulados, RIN, alertas, turnos, seguimiento. Si mañana se construye otro sistema, **no se reutiliza**. | `Negocio.UI`, `Negocio.BLL`, `Negocio.DAL`, `Negocio.DomainModel` |
| **Services** | Servicios **técnicos transversales** reutilizables: seguridad, criptografía, integridad de datos, i18n, bitácora, respaldos, acceso a datos técnico. Si mañana se construye otro sistema, **se reutiliza tal cual**. | `Services` |

Ambos pilares tienen la misma forma interna: **DomainModel · DAL · BLL · (UI | Facade)**.

## La rúbrica: 4 preguntas

Un archivo va a **Services** si responde **SÍ** a la primera pregunta; va a **Negocio** si
responde **SÍ** a la segunda.

1. **¿Es reutilizable en otro sistema sin cambiar una línea?**
   *(criptografía, DVH/DVV, logging, i18n, permisos, respaldos, helpers de base)* → **Services**

2. **¿El usuario final (médico, administrativo, paciente) reconocería el término?**
   *(paciente, turno, RIN, alerta, evento adverso, historia clínica)* → **Negocio**

3. **¿Depende de entidades clínicas?**
   Si necesita `Paciente`, `Turno`, etc. → **Negocio** (Services nunca conoce el dominio).
   Si puede expresarse en términos genéricos (una fila, una tabla, un texto) → **Services**.

4. **¿Es una herramienta de operación del sistema y no del negocio diario?**
   *(auditoría de cambios, integridad de datos, respaldos, bitácora)* → **Services**.

### Tabla de decisión rápida

| Archivo | Pilar | Motivo |
|---|---|---|
| `Paciente`, `Turno`, `MedicionRIN`, `Alerta`… | Negocio | Entidades clínicas (regla 2) |
| `PacienteLogic`, `TurnoLogic`, `ReglasNegocio` | Negocio | Reglas del dominio clínico (regla 2) |
| `NegocioDbContext` + `Migrations` | Negocio | Persisten el modelo clínico (regla 3) |
| `DigitoVerificador` (DVH/DVV) | **Services** | Mecanismo de integridad genérico (regla 1) |
| `DigitosVerificadores` (entidad DVV) | **Services** | Tabla técnica de integridad (reglas 1 y 4) |
| `CambioAuditado` + `AuditoriaDeCambios` | **Services** | Auditoría: herramienta de sysadmin (regla 4) |
| `CifradoDeterministico` (conversor EF) | **Services** | Criptografía (regla 1) |
| `SeguridadLogic`, `BackupLogic`, `LocalizationLogic` | Services | Servicios técnicos (regla 1) |
| `Exportadores` (PDF/Excel/JSON) | Negocio.UI | Coordina la salida **desde la pantalla** (regla 2: es presentación) |
| `IntegridadLogic` (audita entidades clínicas) | Negocio.BLL | Necesita conocer las entidades (regla 3); la **mecánica** vive en Services |
| `Usuario` (con hash y pregunta de seguridad) | Services | Cuenta técnica de autenticación (regla 1) |
| `Usuario` (médico con teléfono y perfil) | Negocio | Actor del negocio (regla 2) |

## Casos de borde y su justificación

- **Dos clases `Usuario`**: son conceptos distintos. La de Services es la **cuenta de acceso**
  (hash de contraseña, intentos fallidos, bloqueo); la de Negocio es el **profesional** del
  dominio (teléfono, perfil). Comparten nombre porque representan la misma persona física,
  pero viven en capas distintas porque tienen responsabilidades distintas.
- **`IntegridadLogic` en Negocio.BLL**: la **mecánica** del DVH/DVV es técnica y vive en Services,
  pero **qué tablas auditar** es una regla del negocio clínico. Separación: Services calcula,
  Negocio decide qué verificar.
- **`Negocio.DAL/Context`**: aunque Entity Framework sea tecnología, ese `DbContext` y sus
  migraciones **persisten el modelo clínico**. Va en Negocio, igual que en el proyecto de
  referencia de la cátedra.
- **DTOs de reportes** (`FilaPanelMonitoreo`, `FilaReporteDiagnostico`, `ItemHistorial`,
  `SugerenciaReasignacion`): son el **vocabulario compartido** entre BLL y UI para transportar
  resultados de consultas. Se mantienen en `Negocio.DomainModel` como modelos de lectura.

## Regla de oro

> **Services no conoce el dominio.** Si un archivo de Services necesita `using Negocio.*`,
> está mal ubicado.

La dirección de dependencia es siempre **Negocio → Services**, nunca al revés.
