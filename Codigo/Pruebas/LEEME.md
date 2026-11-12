# Pruebas funcionales de OpenRIN

Programa de consola que recorre los casos de uso contra una base real (103 comprobaciones): idiomas dinámicos en la base (semilla SQL consolidada, 364 claves por idioma), excepciones de negocio, fábrica con reflexión, seguridad (login, bloqueo, recuperación, AES, PBKDF2), pacientes, historia clínica, RIN y criticidad, alertas, eventos adversos, agenda, seguimiento, reportes, exportación, control de cambios, integridad DVH/DVV con recuperación, y respaldos (COPY_ONLY, CHECKSUM, tabla Respaldos y respaldo automático diario).

## Preparación

1. Crear las bases OpenRIN_Services y OpenRIN_Negocio en SQL Server.
2. Cargar en OpenRIN_Services los scripts de Services/DAL/Tools, con sqlcmd -f 65001: script, security, permisos, localizacion, localizacion_seed y respaldos (364 claves por idioma; los .resx equivalentes viven en el build como referencia).
3. Cargar Negocio.DAL/Tools/script.sql en OpenRIN_Negocio, con sqlcmd -I (baseline idempotente con las migraciones inicial, IntegridadDVH, ControlDeCambios y ReferenciasAUsuarios).
4. Copiar App.config.ejemplo como App.config y ajustar el servidor. El archivo trae las claves Repositorio.<Interfaz> que usa la fábrica.
5. Si se usará la autenticación Windows integrada de SQL Server, retirar User Id/Password de las cadenas; las pruebas también aceptan SQL Auth. Las cadenas con contraseña real JAMÁS se versionan (App.config está en .gitignore).

## Ejecución

    dotnet run --project Pruebas

Las pruebas crean y borran sus propios datos de prueba (pacientes, usuarios de prueba y respaldos en una carpeta temporal), y fuerzan una restauración de la base de negocio desde un respaldo creado dentro de la propia prueba. Ejecutar SOLO contra bases de desarrollo/demo, nunca contra una base en uso: cambia temporalmente un dato de un paciente de prueba y lo restaura, pero la restauración reemplaza el contenido de la base. Conviene correrlas sobre una copia desechable y, después, resembrar datos de demostración con OpenRIN.Herramientas.exe sembrar.
