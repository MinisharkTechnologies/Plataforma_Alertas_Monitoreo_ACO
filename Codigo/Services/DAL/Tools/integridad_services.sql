-- OpenRIN_Services: integridad de datos (DVH por fila + DVV por tabla), requisito del docente.
-- Idempotente: cada ALTER se aplica solo si falta la columna.
IF COL_LENGTH('dbo.Logs', 'DVH') IS NULL
    ALTER TABLE dbo.Logs ADD DVH nvarchar(128) NULL;
GO
IF COL_LENGTH('dbo.Usuarios', 'DVH') IS NULL
    ALTER TABLE dbo.Usuarios ADD DVH nvarchar(128) NULL;
GO
IF COL_LENGTH('dbo.Idiomas', 'DVH') IS NULL
    ALTER TABLE dbo.Idiomas ADD DVH nvarchar(128) NULL;
GO
IF COL_LENGTH('dbo.Textos', 'DVH') IS NULL
    ALTER TABLE dbo.Textos ADD DVH nvarchar(128) NULL;
GO
IF COL_LENGTH('dbo.Permisos', 'DVH') IS NULL
    ALTER TABLE dbo.Permisos ADD DVH nvarchar(128) NULL;
GO
IF COL_LENGTH('dbo.PerfilesPermisos', 'DVH') IS NULL
    ALTER TABLE dbo.PerfilesPermisos ADD DVH nvarchar(128) NULL;
GO
IF COL_LENGTH('dbo.Respaldos', 'DVH') IS NULL
    ALTER TABLE dbo.Respaldos ADD DVH nvarchar(128) NULL;
GO

IF OBJECT_ID('dbo.DigitosVerificadores', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.DigitosVerificadores
    (
        NombreTabla  VARCHAR(100)  NOT NULL CONSTRAINT PK_DigitosVerificadores PRIMARY KEY,
        DVV          NVARCHAR(128) NOT NULL,
        FechaCalculo DATETIME2(0)  NOT NULL CONSTRAINT DF_DigitosVerificadores_Fecha DEFAULT SYSDATETIME()
    );
END;
GO
