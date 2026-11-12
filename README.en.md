# OpenRIN — Comprehensive Alert and Monitoring Platform for Anticoagulated Patients

**Author:** Carlos Santiago Muñiz Cortés
**Professor:** Gastón Matías Weingand
**Institution:** Colegio Leonardo Da Vinci
**Course:** Prácticas Profesionalizantes III · **Year:** 2026

[Español](README.md) · [English] · [中文](README.zh-CN.md)

## Overview

OpenRIN is a desktop platform for hematology practices focused on the follow-up of anticoagulated patients: it centralizes patient and clinical record management, INR (RIN) measurement intake, automatic criticality classification with alert generation, appointment scheduling with smart reassignment, clinical follow-up with a contact-and-escalation protocol, effectiveness statistics reports, the patient portal, and the system administration and security tools.

The solution is built in **C# / .NET 8 (Windows Forms)** on **SQL Server**, with a layered architecture, and covers the practice's full circuit end to end: patient → INR control → alert → appointment → follow-up → report.

## What's new in this version (v1.2, November 2026)

- **One-click installer**: a self-contained package (`Instalador/` → `OpenRIN-Setup.exe`) that installs SQL Server 2022 Express if missing, creates both databases with schema and seeds, installs the application and **seeds the demo data** with a random password generated on the target machine (no known credentials in this repository).
- **Recurring nightly backups**: daily task at 03:00 (`respaldo-auto`, integrity verified via DVH/DVV, retention of 10, logged in the `Respaldos` table), plus the startup backup and the **Backups** panel in the System area (manual backup, verification and restore with a **mandatory pre-copy**, gated by permission **SI004 — Manage backups and restore**).
- **Live integrity recovery**: if DVH/DVV detects tampering, the app shows the altered records (table, Id, reason) and — with SI004 — can **restore a healthy backup** or **recalculate the check digits** before reaching login.
- **Reflection-based repository factory** (`Repositorio.*` keys), `internal` repository encapsulation, and a hierarchy of **business exceptions** (`ReglaNegocioException` and derivatives) with actionable messages.
- **«Pruebas» acceptance suite** (`Codigo/Pruebas/`): **103 checks** against a real database, all green (see LEEME there); **Herramientas** CLI (`sembrar`, `respaldo`, `respaldo-auto`, `integridad`).
- **Complete deliverable documentation** in this repository: **Project Folder (PDF, 153 pages)**, installation, user and programming manuals (PDF + `.chm` online help, also bound to F1 in the app), draw.io + PNG diagrams, and the **`Prueba SQL/`** folder with the guided DVH/DVV and backup demo.
- Build **0 errors / 0 warnings**; local smokes 40/40 (Negocio) and full solution review.

## Proactive integrity (v1.1)

- **DVH/DVV**: per-row and per-table check digits, signed at the single save point and **verified at application startup, before login**.
- **Composite-pattern permissions**: a tree of atomic and composite permissions with unique codes, editable from within the system and applied to module gating.
- **Dynamic internationalization**: Spanish (Latin America), English and Simplified Chinese, with languages and captions **stored in the database** (no runtime resource sheets); hot language switching via the observer pattern.
- **Change control with restore**: audit history with before/after states and the *Restore previous state* action (recomposes and re-signs).
- **PDF via a third-party library** (QuestPDF, community license) for reports and histories, alongside **Excel** and **JSON** export.
- **Automatic backups**: daily backup of both databases (03:00) with integrity verification of every copy.

## Repository structure

- `Codigo/` — .NET solution: `Negocio.UI` (Windows Forms), `Negocio.BLL`, `Negocio.DAL`, `Negocio.DomainModel`, `Services` (DomainModel, BLL, DAL, Facade), **`Pruebas/`** (103 checks) and **`Herramientas/`** (CLI).
- `Documentacion/` — **Project Folder (PDF, 153 pages)** and manuals ([`Manuales/`](Documentacion/Manuales/): installation, user, programming and `.chm` help).
  - `Documentacion/Revision/` — teacher's observations and the detail of applied corrections.
  - `Documentacion Antigua antes de Septiembre/` — historical analysis and design deliverables (do not modify).
- `Diagramas/` — draw.io diagrams (editable) and exported PNGs (architecture, ERD, processes, UC-01..UC-13, T02 and new class diagrams).
- `Instalador/` — one-click installer (IExpress + PowerShell); see [`Instalador/BUILD.md`](Instalador/BUILD.md).
- `Propuesta Corregida/` — project proposal (TP 1).
- `Prueba SQL/` — guided demonstration of integrity (DVH/DVV) and backups (demo database only).
- `ops/` — repository operation utilities.

## Architecture

- **Layers**: Presentation (WinForms) → Business Logic (BLL) and Services Facade → Data Access (DAL) → Databases.
- **Two persistence paths**: **Entity Framework Core** for the business domain (context with Fluent configuration and a single save point) and **ADO.NET** for the services database (security, languages, permissions, logs).
- **Databases**: `OpenRIN_Negocio` (13 tables with integrity signatures and change auditing) and `OpenRIN_Services` (security, languages, permissions, logs and backup registry).
- **Patterns**: Singleton (session), Composite (permissions), Observer (languages), Repository (patients) and Facade (technical services).

## Requirements

- Windows 10/11.
- .NET 8 (Desktop).
- SQL Server 2019 or later (Express edition is enough; the installer sets it up if missing).

> Credentials and local configurations are **not** versioned in this repository.

## Installation and running

**As a deliverable**: run `OpenRIN-Setup.exe` (see [`Instalador/BUILD.md`](Instalador/BUILD.md) to build it from this repository; a prebuilt executable can be published in the repository's Releases section). It installs SQL Server Express if missing, creates and seeds the databases and creates shortcuts.

**For development**:
1. Create the `OpenRIN_Negocio` and `OpenRIN_Services` databases; apply the idempotent scripts from `Codigo/Services/DAL/Tools/` (`script.sql` — logs, `security.sql` — security, `permisos.sql` — permissions, `localizacion.sql` + `localizacion_seed.sql` — languages, `respaldos.sql` — backup registry; with `sqlcmd -f 65001`) and `Codigo/Negocio.DAL/Tools/script.sql` (full business schema including migrations and their history).
2. Configure the local connection string (configuration file not versioned; see `Codigo/Negocio.UI/App.config.example`).
3. Build and run: `dotnet build`, then the `Negocio.UI` project.

On startup, the application verifies database integrity **before** showing the login screen; if the database is tampered with, the lock screen lists the affected records and allows — with permission **SI004** — restoring a healthy backup or recalculating the check digits.

## Full documentation

The **[Project Folder](Documentacion/)** contains the complete deliverable document: global product description, per-layer class diagrams, data model, the five business processes and the **thirteen use cases** (with sequences, affected classes and real system screenshots), and the technical aspects (architecture, session, encryption, profiles, multi-language, activity log, change control, backups and integrity). Manuals (installation, user, programming) are under [`Documentacion/Manuales/`](Documentacion/Manuales/).

## Project status

Deliverable for November 2026. Functional scope is complete and verified; remaining items are specific to the final course stage.
