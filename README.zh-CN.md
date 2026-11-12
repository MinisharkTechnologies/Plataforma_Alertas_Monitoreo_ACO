# OpenRIN — 抗凝患者综合预警与监测平台

**作者：** Carlos Santiago Muñiz Cortés
**教师：** Gastón Matías Weingand
**院校：** Colegio Leonardo Da Vinci
**课程：** Prácticas Profesionalizantes III（职业实践 III） · **年份：** 2026

[Español](README.md) · [English](README.en.md) · [中文]

## 简介

OpenRIN 是一款面向血液科诊所的桌面平台，专注于抗凝患者的随访管理：统一管理患者与临床病历、接收 RIN（INR）检验值、自动进行危急程度分级并生成预警、带智能改期的预约排班、含联系与升级流程的临床随访、疗效统计报告、患者门户，以及系统管理与安全工具。

本方案基于 **C# / .NET 8（Windows Forms）** 与 **SQL Server** 构建，采用多层架构，完整覆盖诊所业务闭环：患者 → RIN 检查 → 预警 → 预约 → 随访 → 报告。

## 本版本新特性（v1.2 · 2026 年 11 月）

- **一键安装程序**：自包含的安装包（`Instalador/` → `OpenRIN-Setup.exe`），缺少 SQL Server 2022 Express 时自动安装，按模式与种子数据创建两个数据库，安装应用，并以**目标机器上随机生成的密钥**播种演示数据（仓库中不含已知凭据）。
- **固定夜间备份**：每日 03:00 任务（`respaldo-auto`，经 DVH/DVV 校验数据健康，保留最近 10 份，登记于 `Respaldos` 表），另含启动备份与系统区 **Respaldos（备份）面板**（手动备份、校验、带**强制预先副本**的恢复，由权限 **SI004 — 管理备份与恢复** 控制）。
- **完整性在线恢复**：若 DVH/DVV 检测到篡改，应用会列出被篡改的记录（表、Id、原因），并可用 SI004 权限在进入登录前**恢复健康备份**或**重算校验位**。
- **基于反射的仓储工厂**（`Repositorio.*` 键）、仓储封装为 `internal`、以及 **业务异常层级**（`ReglaNegocioException` 及其派生类），提示信息可操作。
- **「Pruebas」验收测试套件**（`Codigo/Pruebas/`）：针对真实数据库的 **103 项检查**全部通过（详见其中的 LEEME）；**Herramientas** 命令行（`sembrar`、`respaldo`、`respaldo-auto`、`integridad`）。
- **本仓库内完整的交付文档**：**项目文档册（PDF，153 页）**、安装手册、用户手册与程序员手册（PDF + `.chm` 联机帮助，应用内 F1 同样可用）、draw.io + PNG 图表，以及 **`Prueba SQL/`** 演示文件夹（DVH/DVV 与备份的引导式演示）。
- 编译 **0 错误 / 0 警告**；本地冒烟测试 40/40（Negocio），解决方案已完成全部复核。

## 主动完整性（v1.1）

- **DVH/DVV**：按行与按表的校验位，在唯一的保存点签名，并在**启动应用时、登录之前**进行校验。
- **组合模式（Composite）权限**：原子权限与组合权限构成的树，具有唯一编码，可在系统内编辑，并应用于模块访问控制。
- **动态国际化**：西班牙语（拉美）、英语与简体中文，语言与词条**存储在数据库中**（运行时无静态资源文件）；通过观察者模式实现热切换。
- **带恢复功能的变更控制**：审计历史包含变更前后状态，并提供“恢复上一状态”操作（恢复并重新签名）。
- **使用第三方库生成 PDF**（QuestPDF，社区许可）用于报告与病历，同时支持 **Excel** 与 **JSON** 导出。
- **自动备份**：每日（03:00）备份两个数据库，并对每份副本进行完整性校验。

## 仓库结构

- `Codigo/` —— .NET 解决方案：`Negocio.UI`（Windows Forms）、`Negocio.BLL`、`Negocio.DAL`、`Negocio.DomainModel`、`Services`（DomainModel、BLL、DAL、Facade），以及 **`Pruebas/`**（103 项检查）与 **`Herramientas/`**（CLI）。
- `Documentacion/` —— **项目文档册（PDF，153 页）** 与手册（[`Manuales/`](Documentacion/Manuales/)：安装、用户、程序员及 `.chm` 帮助）。
  - `Documentacion/Revision/` —— 教师意见与已应用更正的明细。
  - `Documentacion Antigua antes de Septiembre/` —— 历史分析与设计交付物（勿改动）。
- `Diagramas/` —— draw.io 图表（可编辑）与导出的 PNG（架构、E-R 图、流程、UC-01..UC-13、T02 及新增类图）。
- `Instalador/` —— 一键安装程序（IExpress + PowerShell）；参见 [`Instalador/BUILD.md`](Instalador/BUILD.md)。
- `Propuesta Corregida/` —— 项目提案（TP 1）。
- `Prueba SQL/` —— 完整性（DVH/DVV）与备份的引导式演示（仅限演示数据库）。
- `ops/` —— 仓库运维工具。

## 架构

- **分层**：表示层（WinForms）→ 业务逻辑层（BLL）与服务门面（Facade）→ 数据访问层（DAL）→ 数据库。
- **两条持久化路径**：业务域采用 **Entity Framework Core**（Fluent 配置与唯一保存点），服务库采用 **ADO.NET**（安全、语言、权限、日志）。
- **数据库**：`OpenRIN_Negocio`（13 张表，含完整性签名与变更审计）与 `OpenRIN_Services`（安全、语言、权限、日志与备份登记表）。
- **设计模式**：Singleton（会话）、Composite（权限）、Observer（语言）、Repository（患者）与 Facade（技术服务）。

## 运行要求

- Windows 10/11。
- .NET 8（Desktop）。
- SQL Server 2019 或更高（Express 版即可；安装程序可在缺失时自动安装）。

> 凭据与本地配置**不纳入**本仓库版本管理。

## 安装与运行

**作为交付物**：运行 `OpenRIN-Setup.exe`（从本仓库自行编译参见 [`Instalador/BUILD.md`](Instalador/BUILD.md)；预编译的可执行文件可发布在仓库的 Releases 板块）。它会在缺失时安装 SQL Server Express，创建并播种数据库，并创建快捷方式。

**用于开发**：
1. 创建 `OpenRIN_Negocio` 与 `OpenRIN_Services` 数据库；执行来自 `Codigo/Services/DAL/Tools/` 的幂等脚本（`script.sql`——日志、`security.sql`——安全、`permisos.sql`——权限、`localizacion.sql` + `localizacion_seed.sql`——语言、`respaldos.sql`——备份登记表；需 `sqlcmd -f 65001`），以及 `Codigo/Negocio.DAL/Tools/script.sql`（完整的业务库架构，含迁移及其历史）。
2. 配置本地连接字符串（配置文件不纳入版本管理；参见 `Codigo/Negocio.UI/App.config.example`）。
3. 编译并运行：`dotnet build`，然后运行 `Negocio.UI` 项目。

启动时，应用会在显示登录界面**之前**校验数据库完整性；若数据库被篡改，拦截界面会列出受影响的记录，并可使用 **SI004** 权限恢复健康备份或重算校验位。

## 完整文档

**[项目文档册](Documentacion/)** 包含完整的交付文档：产品全局说明、各层类图、数据模型、五个业务过程与**十三个用例**（含顺序图、受影响类与真实系统截图），以及技术专题（架构、会话、加密、权限配置、多语言、活动日志、变更控制、备份与完整性）。手册（安装、用户、程序员）位于 [`Documentacion/Manuales/`](Documentacion/Manuales/)。

## 许可证

Copyright (C) 2026 Carlos Santiago Muñiz Cortés。依据 **GNU General Public License v3.0** 发布（见 [`LICENSE`](LICENSE) 与 [`NOTICE.txt`](NOTICE.txt)）。可依据 GPLv3 分发 OpenRIN 及其衍生作品：衍生作品必须在同一许可证下保持开源（强 copyleft 传染性）。第三方依赖保留其自身许可证（QuestPDF Community License，面向开源项目与小型实体免费；其余为 MIT）。

## 项目状态

2026 年 11 月交付。功能范围已完成并验证；剩余事项仅属于课程收尾阶段。
