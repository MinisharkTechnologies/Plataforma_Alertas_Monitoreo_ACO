// Manuales de OpenRIN con el esquema de la entrega final (Manual de instalación, Manual de usuario, Manual de programación).
// Estructura: documento = {titulo, subtitulo, secciones:[{titulo, bloques:[], sub:[{titulo, bloques:[], sub:[...]}]}]}
// Bloques: {p} {ul} {ol} {nota} {importante} {tabla:{cab,filas}} {cod} {img,cap}
import { DEMO_CLAVE } from './contenido.mjs';

const AUTOR = 'Muñiz Cortés, Carlos Santiago';
const LEGAJO = 'B00000955-VCO';
export const META = { autor: AUTOR, legajo: LEGAJO, version: '1.0', materia: 'Prácticas Profesionalizantes III', docente: 'Weingand, Gastón Matías' };

// =====================================================================================================
export const INSTALACION = {
  titulo: 'Manual de instalación', subtitulo: 'OpenRIN', detalle: 'Instalación, configuración y puesta en marcha',
  secciones: [
    { titulo: 'Introducción', sub: [
      { titulo: 'Descripción del sistema', bloques: [
        { p: 'OpenRIN es una plataforma de escritorio para consultorios de hematología que atienden pacientes con anticoagulación oral. Permite registrar pacientes y su historia clínica, recibir los valores de RIN, clasificarlos y generar alertas, gestionar la agenda de turnos, hacer el seguimiento clínico de los pacientes y emitir reportes de eficacia. Está desarrollada en C# con Windows Forms sobre .NET 8.' },
      ] },
      { titulo: 'Arquitectura técnica', bloques: [
        { ul: ['Interfaz: Windows Forms.', 'Backend: C# sobre .NET 8 (la aplicación incluye su propio runtime).', 'Base de datos: SQL Server 2019 o superior (Express, Standard o Enterprise). Se probó con SQL Server 2022 Express.', 'Arquitectura: en capas: Presentación, Lógica de negocio, Dominio, Acceso a datos y Servicios técnicos.'] },
      ] },
      { titulo: 'Componentes del sistema', bloques: [
        { ul: ['Aplicación principal: Negocio.UI.exe.', 'Herramientas de línea de comandos: OpenRIN.Herramientas.exe (cargar datos de demostración, respaldo e integridad).', 'Bases de datos: OpenRIN_Negocio (datos clínicos, 13 tablas) y OpenRIN_Services (usuarios, permisos, idiomas, textos y bitácora).', 'Archivo de configuración: Negocio.UI.dll.config (y OpenRIN.Herramientas.dll.config).', 'Ayuda en línea: OpenRIN-Ayuda.chm.', 'Scripts de base de datos: carpeta 4 - Base de Datos.', 'Tarea programada «OpenRIN - Respaldo Nocturno» (respaldo diario a las 03:00).'] },
      ] },
    ] },
    { titulo: 'Requisitos del sistema', sub: [
      { titulo: 'Requisitos de hardware', bloques: [
        { tabla: { cab: ['', 'Mínimos', 'Recomendados'], filas: [
          ['Procesador', 'x64, 1,6 GHz', 'x64, 2,0 GHz o superior'],
          ['Memoria RAM', '4 GB', '8 GB'],
          ['Espacio en disco', '1,5 GB libres (más lo que ocupe SQL Server)', '3 GB libres'],
          ['Resolución de pantalla', '1366 x 768', '1920 x 1080'],
        ] } },
      ] },
      { titulo: 'Requisitos de software', bloques: [
        { p: 'Obligatorios:' },
        { ol: ['Windows 10 (64 bits) o superior, o Windows 11.', 'SQL Server 2019 o superior (Express alcanza). Si no hay ninguna instancia, el instalador instala SQL Server 2022 Express usando winget.', 'Una cuenta con permisos de administrador del equipo, que sea también administrador (sysadmin) de la instancia de SQL Server.'] },
        { p: 'Opcionales:' },
        { ul: ['SQL Server Management Studio (SSMS), para administrar las bases de datos.', 'SDK de .NET 8 o superior y Visual Studio 2022, solo para compilar desde el código fuente.'] },
        { nota: 'No hace falta instalar .NET: la aplicación incluye el runtime de .NET 8.' },
      ] },
    ] },
    { titulo: 'Instalación de dependencias', sub: [
      { titulo: 'Verificar el sistema operativo y PowerShell', bloques: [
        { p: 'El instalador usa Windows PowerShell 5.1, que viene incluido en Windows 10 y 11. Para comprobar la versión de Windows, abra «Configuración > Sistema > Acerca de». Para comprobar winget (solo necesario si hay que instalar SQL Server), abra una consola y escriba:' },
        { cod: 'winget --version' },
        { p: 'Si el comando no existe, instale «App Installer» desde Microsoft Store o instale SQL Server Express manualmente (apartado siguiente).' },
      ] },
    ] },
    { titulo: 'Instalación de SQL Server (desde cero)', bloques: [
      { nota: 'Si el equipo ya tiene SQL Server 2019 o superior, salte esta sección: el instalador lo detecta solo.' },
    ], sub: [
      { titulo: 'Descarga de SQL Server Express', bloques: [
        { p: 'Descargue SQL Server 2022 Express desde https://aka.ms/sqlexpress (edición gratuita).' },
      ] },
      { titulo: 'Instalación', bloques: [
        { ol: ['Ejecute el instalador descargado y elija «Básica».', 'Acepte los términos de licencia y la ubicación de instalación.', 'Espere a que termine. La instancia se llama SQLEXPRESS.', 'Si usa el instalador de OpenRIN y no hay SQL Server, este paso se hace solo, con la instancia SQLEXPRESS y el grupo Administradores del equipo como administradores de SQL Server.'] },
      ] },
      { titulo: 'Verificar que SQL Server esté ejecutándose', bloques: [
        { ol: ['Abra «Servicios» (services.msc).', 'Busque «SQL Server (SQLEXPRESS)». Debe figurar como «En ejecución». Si no, haga clic derecho y elija «Iniciar».'] },
        { p: 'También puede comprobarlo desde una consola:' },
        { cod: 'sqlcmd -S .\\SQLEXPRESS -E -Q "SELECT @@VERSION"' },
      ] },
      { titulo: 'SQL Server Management Studio (SSMS)', bloques: [
        { p: 'Opcional. Se descarga desde https://aka.ms/ssmsfullsetup y permite ver las bases y ejecutar consultas.' },
      ] },
    ] },
    { titulo: 'Instalación de OpenRIN', sub: [
      { titulo: 'Preparación', bloques: [
        { ul: ['Cierre cualquier versión de OpenRIN que esté abierta.', 'Verifique que dispone de 1,5 GB libres en la unidad C:.', 'Inicie sesión en Windows con una cuenta de administrador.'] },
      ] },
      { titulo: 'Instalación con el instalador', bloques: [
        { ol: ['Copie OpenRIN-Setup.exe al equipo y haga doble clic.', 'Acepte el aviso de control de cuentas de usuario de Windows.', 'Espere a que el instalador complete los ocho pasos que muestra en la ventana.', 'Cuando aparezca «Instalación finalizada», pulse Enter para cerrar.'] },
        { tabla: { cab: ['Paso', 'Acción'], filas: [
          ['1', 'Verifica la versión de Windows y el espacio en disco.'],
          ['2', 'Busca una instancia de SQL Server 2019 o superior; si no hay, instala SQL Server 2022 Express.'],
          ['3', 'Crea las bases OpenRIN_Services y OpenRIN_Negocio y carga sus esquemas, permisos, idiomas y textos.'],
          ['4', 'Copia la aplicación a C:\\Program Files\\OpenRIN y escribe su configuración.'],
          ['5', 'Crea los usuarios y los datos de demostración y verifica la integridad de los datos.'],
          ['6', 'Crea los accesos directos en el escritorio y en el menú Inicio.'],
          ['7', 'Programa el respaldo diario a las 03:00 en el Programador de tareas.'],
          ['8', 'Registra OpenRIN en Aplicaciones instaladas.'],
        ] } },
        { importante: 'El registro de la instalación queda en %TEMP%\\OpenRIN_instalacion.log. Si algo falla, adjúntelo al pedir soporte.' },
        { h: 'Opciones avanzadas' },
        { p: 'El instalador es un script de PowerShell. Para ejecutarlo sin preguntas o indicando la instancia:' },
        { cod: 'powershell -ExecutionPolicy Bypass -File Instalar.ps1 -Servidor ".\\SQLEXPRESS" -Silencioso' },
        { tabla: { cab: ['Parámetro', 'Descripción'], filas: [
          ['-Servidor', 'Instancia de SQL Server a usar. Por defecto se detecta sola.'],
          ['-Destino', 'Carpeta de instalación. Por defecto C:\\Program Files\\OpenRIN.'],
          ['-ClaveDemo', 'Contraseña inicial de los usuarios de demostración.'],
          ['-Silencioso', 'No hace preguntas ni espera una tecla al final.'],
        ] } },
        { p: 'Para extraer los archivos del instalador sin ejecutarlo: OpenRIN-Setup.exe /Q /C /T:C:\\carpeta.' },
      ] },
      { titulo: 'Instalación manual (sin instalador)', bloques: [
        { p: 'Si no puede usar el instalador, puede instalar a mano a partir del código fuente:' },
        { ol: ['Cree las bases de datos y cargue los scripts (sección 6).', 'Compile y publique la aplicación (vea el Manual de programación, sección 7).', 'Copie la carpeta publicada a C:\\Program Files\\OpenRIN.', 'Cree los archivos de configuración (sección 7).', 'Ejecute OpenRIN.Herramientas.exe sembrar para crear los usuarios y los datos de demostración.'] },
      ] },
      { titulo: 'Verificar la instalación', bloques: [
        { ul: ['Debe existir C:\\Program Files\\OpenRIN\\Negocio.UI.exe.', 'Debe haber un acceso directo «OpenRIN» en el escritorio.', 'En SSMS deben verse las bases OpenRIN_Services y OpenRIN_Negocio.', 'En el Programador de tareas debe existir «OpenRIN - Respaldo Nocturno».'] },
      ] },
    ] },
    { titulo: 'Instalación de las bases de datos', bloques: [
      { p: 'El instalador crea las bases solo. Esta sección explica cómo hacerlo a mano o cómo restaurar un respaldo. Los scripts están en la carpeta «4 - Base de Datos» de la entrega.' },
    ], sub: [
      { titulo: 'Crear las bases', bloques: [
        { cod: 'sqlcmd -S .\\SQLEXPRESS -E -Q "CREATE DATABASE OpenRIN_Services; CREATE DATABASE OpenRIN_Negocio;"' },
      ] },
      { titulo: 'Base de negocio: OpenRIN_Negocio', bloques: [
        { p: 'El script negocio_esquema.sql crea las 13 tablas, los índices, los dígitos verificadores y los datos de referencia (obras sociales, diagnósticos y el usuario sysadmin del negocio). Es idempotente: puede ejecutarse más de una vez.' },
        { cod: 'sqlcmd -S .\\SQLEXPRESS -E -I -d OpenRIN_Negocio -f 65001 -i negocio_esquema.sql' },
        { importante: 'La opción -I (QUOTED_IDENTIFIER) es obligatoria; sin ella el script falla al crear índices.' },
      ] },
      { titulo: 'Base de servicios: OpenRIN_Services', bloques: [
        { p: 'Ejecute los cinco scripts, en este orden. La opción -f 65001 es obligatoria para que los acentos de los textos se carguen bien.' },
        { cod: 'sqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i services_01_bitacora.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i services_02_seguridad.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i services_03_permisos.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i services_04_localizacion.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i services_05_localizacion_seed.sql' },
      ] },
      { titulo: 'Restaurar un respaldo', bloques: [
        { p: 'La carpeta «4 - Base de Datos» incluye un respaldo de las dos bases con los datos de demostración. Para restaurarlo:' },
        { cod: "RESTORE DATABASE OpenRIN_Negocio  FROM DISK = 'C:\\ruta\\OpenRIN_Negocio_demo.bak'  WITH REPLACE;\nRESTORE DATABASE OpenRIN_Services FROM DISK = 'C:\\ruta\\OpenRIN_Services_demo.bak' WITH REPLACE;" },
        { nota: 'El archivo .bak debe estar en una carpeta que el servicio de SQL Server pueda leer (por ejemplo C:\\OpenRIN\\Backups).' },
      ] },
    ] },
    { titulo: 'Configuración de la conexión', sub: [
      { titulo: 'Ubicación del archivo de configuración', bloques: [
        { p: 'Está junto al ejecutable: C:\\Program Files\\OpenRIN\\Negocio.UI.dll.config. La herramienta de línea de comandos usa OpenRIN.Herramientas.dll.config con el mismo contenido.' },
      ] },
      { titulo: 'Claves de configuración', bloques: [
        { tabla: { cab: ['Clave', 'Descripción'], filas: [
          ['ServicesDB', 'Cadena de conexión a OpenRIN_Services.'],
          ['NegocioDB', 'Cadena de conexión a OpenRIN_Negocio.'],
          ['BackupString', 'Cadena de conexión a la base master, usada para ejecutar los respaldos.'],
          ['MinimalLogLevel', 'Nivel mínimo de la bitácora: Debug, Info, Warning, Error o Fatal.'],
          ['BackupFolder', 'Carpeta de respaldos (por defecto C:\\OpenRIN\\Backups).'],
        ] } },
      ] },
      { titulo: 'Ejemplos según el tipo de SQL Server', bloques: [
        { tabla: { cab: ['Tipo', 'Cadena de conexión'], filas: [
          ['SQL Server Express (instancia SQLEXPRESS)', 'Server=.\\SQLEXPRESS;Database=OpenRIN_Negocio;Integrated Security=True;TrustServerCertificate=True;'],
          ['Instancia predeterminada', 'Server=.;Database=OpenRIN_Negocio;Integrated Security=True;TrustServerCertificate=True;'],
          ['Servidor remoto con usuario de SQL', 'Server=NOMBRE;Database=OpenRIN_Negocio;User Id=usuario;Password=clave;TrustServerCertificate=True;'],
        ] } },
        { nota: 'El instalador usa autenticación integrada de Windows, por lo que no queda ninguna contraseña guardada en el archivo.' },
      ] },
      { titulo: 'Pasos para configurar', bloques: [
        { ol: ['Cierre OpenRIN.', 'Abra el archivo .dll.config con el Bloc de notas como administrador.', 'Cambie el nombre del servidor en las tres cadenas de conexión.', 'Guarde, haga lo mismo con OpenRIN.Herramientas.dll.config y abra la aplicación.'] },
      ] },
    ] },
    { titulo: 'Ejecución de la aplicación', sub: [
      { titulo: 'Ejecución desde el acceso directo', bloques: [{ p: 'Haga doble clic en «OpenRIN» en el escritorio o búsquelo en el menú Inicio.' }] },
      { titulo: 'Ejecución directa del ejecutable', bloques: [{ p: 'Ejecute C:\\Program Files\\OpenRIN\\Negocio.UI.exe.' }] },
      { titulo: 'Primera ejecución', bloques: [
        { p: 'Antes de mostrar el inicio de sesión, el programa verifica la integridad de la base de datos. Luego aparece la pantalla de acceso. Ingrese con uno de los usuarios de demostración:' },
        { img: '01_login.png', cap: 'Pantalla de inicio de sesión.' },
        { tabla: { cab: ['Usuario', 'Perfil', 'Contraseña inicial'], filas: [['sysadmin', 'Administrador del sistema', DEMO_CLAVE], ['medico', 'Médico', DEMO_CLAVE], ['recepcion', 'Administrativo', DEMO_CLAVE]] } },
        { importante: 'Cambie estas contraseñas después de la primera prueba (¿Olvidó su contraseña?, o desde Sistema y Bitácora).' },
      ] },
    ] },
    { titulo: 'Verificación de la instalación', sub: [
      { titulo: 'Verificación de las bases de datos', bloques: [
        { cod: 'sqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Negocio -Q "SELECT COUNT(*) FROM Pacientes"\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -Q "SELECT COUNT(*) FROM Textos"' },
        { p: 'Con los datos de demostración la primera consulta devuelve 5 y la segunda 933 (311 textos por cada uno de los tres idiomas).' },
      ] },
      { titulo: 'Verificación de la aplicación', bloques: [
        { ol: ['Abra OpenRIN e ingrese con sysadmin.', 'En la cabecera debe leerse «Integridad OK».', 'Abra «Panel de Monitoreo»: deben verse los cinco pacientes de demostración.'] },
        { img: '04_panel_monitoreo.png', cap: 'Panel de monitoreo con los datos de demostración.' },
      ] },
      { titulo: 'Verificación de los archivos', bloques: [
        { cod: 'OpenRIN.Herramientas.exe integridad\nOpenRIN.Herramientas.exe respaldo' },
        { p: 'Ambos comandos terminan con código 0 si todo está bien. El segundo deja los archivos .bak en C:\\OpenRIN\\Backups.' },
      ] },
    ] },
    { titulo: 'Solución de problemas comunes', sub: [
      { titulo: 'Error: «A network-related or instance-specific error occurred»', bloques: [{ p: 'El programa no encuentra SQL Server. Verifique que el servicio esté en ejecución (apartado 4.3) y que el nombre de la instancia en la cadena de conexión sea el correcto (por ejemplo .\\SQLEXPRESS).' }] },
      { titulo: 'Error: «Cannot open database»', bloques: [{ p: 'La base no existe o la cuenta no tiene acceso. Cree las bases (sección 6) o ejecute el instalador otra vez.' }] },
      { titulo: 'Error: «Login failed for user»', bloques: [{ p: 'Si usa autenticación integrada, la cuenta de Windows debe tener acceso a SQL Server. Agréguela como login con permisos sobre las dos bases.' }] },
      { titulo: 'Al abrir aparece la pantalla de base de datos vulnerada', bloques: [{ p: 'Los dígitos verificadores no coinciden o no se pudo leer la base. Si es una instalación nueva, revise la conexión. Si hubo cambios hechos fuera del sistema, ejecute OpenRIN.Herramientas.exe integridad para ver el detalle y consulte el apartado 13.' }] },
      { titulo: 'Los textos se ven como claves (por ejemplo shell.titulo)', bloques: [{ p: 'No se leyó la tabla de idiomas: revise la cadena ServicesDB y que localizacion_seed.sql se haya cargado con -f 65001.' }] },
      { titulo: 'El respaldo nocturno falla', bloques: [{ p: 'Ejecute OpenRIN.Herramientas.exe respaldo y lea el mensaje. La tarea corre como la cuenta SYSTEM, que necesita acceso a las bases; el instalador se lo da. Si instaló a mano, ejecute:' }, { cod: 'CREATE LOGIN [NT AUTHORITY\\SYSTEM] FROM WINDOWS; ALTER SERVER ROLE dbcreator ADD MEMBER [NT AUTHORITY\\SYSTEM];\n-- y en cada base OpenRIN: CREATE USER [NT AUTHORITY\\SYSTEM] FOR LOGIN [NT AUTHORITY\\SYSTEM]; ALTER ROLE db_owner ADD MEMBER [NT AUTHORITY\\SYSTEM];' }] },
      { titulo: 'Error: «No se encontró winget»', bloques: [{ p: 'Instale SQL Server Express manualmente (apartado 4) y vuelva a ejecutar el instalador.' }] },
      { titulo: 'Error: «El usuario actual no es administrador (sysadmin)»', bloques: [{ p: 'Ejecute el instalador con una cuenta que sea sysadmin de la instancia, o indique otra con -Servidor.' }] },
      { titulo: 'Olvidé la contraseña', bloques: [{ p: 'Use «¿Olvidó su contraseña?» en la pantalla de acceso y responda la pregunta de seguridad. Si tampoco recuerda la respuesta, restaure un respaldo anterior (apartado 6.4).' }] },
    ] },
    { titulo: 'Desinstalación', sub: [
      { titulo: 'Desinstalar OpenRIN', bloques: [
        { p: 'Use «Desinstalar OpenRIN» del menú Inicio o «Aplicaciones instaladas» de Windows. Se eliminan la aplicación, los accesos directos y la tarea de respaldo; las bases de datos y los respaldos se conservan. Para eliminar también las bases:' },
        { cod: 'powershell -ExecutionPolicy Bypass -File "C:\\Program Files\\OpenRIN\\Desinstalar.ps1" -QuitarBases' },
      ] },
    ] },
    { titulo: 'Actualización de la aplicación', sub: [
      { titulo: 'Actualizar OpenRIN', bloques: [
        { ol: ['Haga un respaldo: OpenRIN.Herramientas.exe respaldo.', 'Cierre OpenRIN en todos los equipos.', 'Ejecute el nuevo OpenRIN-Setup.exe sobre la instalación existente. Reemplaza la aplicación y vuelve a aplicar los scripts, que no borran datos.', 'Verifique «Integridad OK».'] },
      ] },
    ] },
    { titulo: 'Mantenimiento', sub: [
      { titulo: 'Respaldo de las bases de datos', bloques: [
        { p: 'La tarea «OpenRIN - Respaldo Nocturno» genera todos los días a las 03:00 un respaldo completo de las dos bases y verifica cada archivo. Los archivos quedan en C:\\OpenRIN\\Backups con el nombre OpenRIN_Negocio_AAAAMMDD_HHMMSS_FULL.bak.' },
        { nota: 'Copie periódicamente esa carpeta a otro disco o a la nube: un respaldo en el mismo equipo no protege ante la falla del disco.' },
        { p: 'Para hacer un respaldo en cualquier momento:' },
        { cod: 'OpenRIN.Herramientas.exe respaldo' },
      ] },
      { titulo: 'Control de la bitácora', bloques: [
        { p: 'Desde Sistema y Bitácora > Bitácora se consultan los inicios de sesión, altas, modificaciones, exportaciones, respaldos y errores. Revise periódicamente las entradas de nivel Warning, Error y Fatal. La bitácora también se guarda en el archivo log_fallback.txt de C:\\ProgramData\\OpenRIN.' },
      ] },
      { titulo: 'Integridad de los datos', bloques: [
        { p: 'Cada fila de las 11 tablas de datos lleva un dígito verificador horizontal y cada tabla uno vertical. Se verifican al abrir la aplicación y con OpenRIN.Herramientas.exe integridad. Ante una alteración externa, el ingreso se bloquea hasta que el administrador la revise: si fue un cambio legítimo se recalculan las firmas; si es desconocido, se restaura el último respaldo válido.' },
      ] },
    ] },
    { titulo: 'Resumen de pasos de instalación', bloques: [
      { ol: ['Verifique los requisitos (Windows 10 u 11, 1,5 GB libres, permisos de administrador).', 'Ejecute OpenRIN-Setup.exe y acepte el aviso de Windows.', 'Espere a «Instalación finalizada».', 'Abra OpenRIN desde el escritorio e ingrese con sysadmin.', 'Verifique «Integridad OK» y el panel de monitoreo.', 'Cambie las contraseñas de demostración.'] },
    ] },
    { titulo: 'Contacto y soporte', bloques: [
      { p: `Autor: ${AUTOR} — Legajo ${LEGAJO}. Docente: Weingand, Gastón Matías. Universidad Abierta Interamericana — Facultad de Tecnología Informática, Colegio Leonardo Da Vinci, Curso Noche, comisión VCO-21-23.` },
      { p: 'Al pedir soporte adjunte el archivo %TEMP%\\OpenRIN_instalacion.log y la salida de OpenRIN.Herramientas.exe integridad.' },
    ] },
  ],
};

// =====================================================================================================
export const USUARIO = {
  titulo: 'Manual de usuario', subtitulo: 'OpenRIN', detalle: 'Plataforma integral de alertas y monitoreo para pacientes anticoagulados',
  secciones: [
    { titulo: 'Introducción', bloques: [
      { p: 'Este manual explica cómo usar OpenRIN, la plataforma de un consultorio de hematología para el seguimiento de pacientes con anticoagulación oral. Está escrito para quien usa el programa todos los días: cada sección dice para qué sirve una pantalla, qué botones tiene, cómo se hace cada tarea y qué mensajes pueden aparecer.' },
      { p: 'Cada tarea indica entre paréntesis el caso de uso que la respalda (por ejemplo, UC-04). Los casos de uso están especificados en la Carpeta de Proyecto, sección N02.' },
    ], sub: [
      { titulo: 'Descripción del sistema', bloques: [
        { p: 'El RIN (índice internacional normalizado) mide el tiempo de coagulación. Cada paciente tiene un rango terapéutico propio, por ejemplo de 2,0 a 3,0; un valor fuera de ese rango implica riesgo de sangrado o de trombosis. OpenRIN cubre el recorrido completo: se registra al paciente y su historia clínica, se reciben y clasifican sus valores de RIN, se generan alertas, se asignan turnos, se contacta a quienes no reportaron y se emiten reportes de eficacia. Todos los pacientes y datos de la instalación de demostración son ficticios.' },
        { p: 'Está hecho en C# con Windows Forms (.NET 8), con arquitectura en capas y base de datos SQL Server.' },
      ] },
      { titulo: 'Requisitos técnicos', bloques: [
        { ul: ['Windows 10 o superior (64 bits).', 'SQL Server 2019 o superior (Express alcanza), instalado por el instalador si falta.', 'Resolución recomendada: 1366 x 768 o mayor.'] },
        { p: 'La instalación paso a paso está en el Manual de instalación.' },
      ] },
      { titulo: 'Roles y permisos', bloques: [
        { p: 'Cada persona entra con un usuario que tiene un perfil. El perfil decide qué módulos ve y qué botones puede usar. Si un módulo no aparece, el perfil no tiene ese permiso.' },
        { tabla: { cab: ['Perfil', 'Qué puede hacer'], filas: [
          ['Sysadmin', 'Todo, incluida la administración de usuarios, bitácora, control de cambios, idiomas, perfiles y permisos.'],
          ['Médico', 'Panel de monitoreo, eventos adversos, seguimiento clínico y reportes. Consulta historias clínicas.'],
          ['Administrativo', 'Pacientes e historias clínicas, panel de monitoreo, recepción de RIN, agenda y reportes.'],
          ['Paciente', 'Portal del paciente: reportar su propio RIN y consultar su historial.'],
          ['Familiar autorizado', 'Las mismas funciones del portal que el paciente, para acompañar el tratamiento.'],
        ] } },
        { nota: 'La tabla resume los permisos de fábrica. El detalle, permiso por permiso, se ve y se modifica en Sistema y Bitácora > Perfiles y permisos.' },
      ] },
    ] },
    { titulo: 'Funcionamiento', bloques: [
      { p: 'Esta sección sigue el orden en que se usa el sistema: primer inicio, pantalla principal y luego cada módulo. En cualquier momento puede abrir la ayuda en línea con el botón «Ayuda» o con la tecla F1; se abre en el tema del módulo en el que está.' },
    ], sub: [
      { titulo: 'Primer inicio del sistema', bloques: [
        { p: 'Al instalar el programa se cargan tres usuarios de demostración (sysadmin, médico y recepción) y cinco pacientes de ejemplo, para poder probar todo de inmediato. Antes de usar el sistema con datos reales, cambie las contraseñas y dé de baja a los pacientes de ejemplo.' },
        { importante: 'Antes de mostrar el inicio de sesión, el programa verifica la integridad de la base de datos. Si detecta cambios hechos fuera del sistema, muestra la pantalla «Base de datos vulnerada» y no deja ingresar hasta que el administrador la revise.' },
      ] },
      { titulo: 'Pantalla principal', sub: [
        { titulo: 'Inicio de sesión (UC de acceso)', bloques: [
          { ol: ['Escriba el usuario y la contraseña.', 'Si lo desea, elija el idioma (español, inglés o chino simplificado).', 'Pulse Ingresar.'] },
          { img: '01_login.png', cap: 'Pantalla de inicio de sesión.' },
          { p: 'Si olvidó la contraseña, pulse «¿Olvidó su contraseña?», responda su pregunta de seguridad y escriba una nueva. Después de 5 intentos fallidos la cuenta se bloquea durante 15 minutos.' },
        ] },
        { titulo: 'Menú y cabecera', bloques: [
          { img: '02_principal.png', cap: 'Pantalla principal.' },
          { p: 'A la izquierda está el menú de módulos; solo aparecen los que su perfil puede usar. Arriba a la derecha se ven:' },
          { ul: ['Integridad OK: resultado de la verificación de la base de datos.', 'Idioma: selector para cambiar el idioma al instante.', 'Ayuda: abre la ayuda en línea (también con F1).', 'Cerrar sesión: vuelve a la pantalla de acceso.'] },
        ] },
      ] },
      { titulo: 'Pacientes e Historias Clínicas (UC-01, UC-02)', bloques: [
        { img: '03_pacientes.png', cap: 'Listado de pacientes.' },
        { p: 'Escriba parte del nombre o del documento en «Buscar» y pulse Buscar. Marque «Ver inactivos» para incluir a los pacientes dados de baja.' },
      ], sub: [
        { titulo: 'Registrar un paciente (UC-01)', bloques: [
          { img: '03b_alta_paciente.png', cap: 'Formulario de alta de paciente.' },
          { ol: ['Pulse Alta de Paciente.', 'Complete nombre, documento (DNI), teléfono, correo, obra social y número de afiliado.', 'Pulse Guardar.', 'El sistema muestra el usuario y la contraseña temporal del portal del paciente. Anótelos y entréguelos al paciente.'] },
          { importante: 'El DNI es único entre los pacientes activos. Si ya existe, el sistema rechaza el alta y lo informa.' },
        ] },
        { titulo: 'Modificar o dar de baja (UC-01)', bloques: [
          { p: 'Seleccione al paciente y pulse Modificar para editar sus datos, o Dar de baja para indicar el motivo. La baja es lógica: el paciente queda inactivo, se deshabilitan sus credenciales del portal y se conserva toda su historia clínica.' },
        ] },
        { titulo: 'Historia clínica hematológica (UC-02)', bloques: [
          { img: '03c_historia_clinica.png', cap: 'Configuración de la historia clínica.' },
          { p: 'Seleccione al paciente y pulse Historia clínica. El médico define el diagnóstico, los límites inferior y superior del rango terapéutico (el inferior debe ser menor que el superior), el medicamento y la dosis, la periodicidad de reporte en días y, opcionalmente, la fecha del próximo control.' },
          { nota: 'Sin historia clínica configurada no se pueden registrar valores de RIN del paciente: el sistema necesita su rango terapéutico para clasificarlos.' },
        ] },
      ] },
      { titulo: 'Panel de Monitoreo (UC-06, UC-07, UC-08)', bloques: [
        { img: '04_panel_monitoreo.png', cap: 'Panel de monitoreo con los pacientes ordenados por prioridad.' },
        { p: 'Muestra a los pacientes activos ordenados por riesgo: arriba están los que requieren atención primero. Se actualiza solo cada 30 segundos; también puede pulsar Actualizar.' },
        { tabla: { cab: ['Columna', 'Significado'], filas: [
          ['Último RIN / Último reporte', 'Valor y fecha de la medición más reciente.'],
          ['Días sin reportar', 'Días transcurridos desde esa medición.'],
          ['Criticidad', 'Crítico (Alta), Moderado (Media), Estable (Baja) o Sin datos.'],
          ['Alerta', 'Campana: el paciente tiene una alerta activa. El triángulo junto a «Crítico» indica tendencia peligrosa.'],
        ] } },
      ], sub: [
        { titulo: 'Cómo se calcula la criticidad (UC-05)', bloques: [
          { ul: ['Baja: el valor está dentro del rango terapéutico del paciente.', 'Media: el valor está fuera del rango por menos de 0,5.', 'Alta: el valor está fuera del rango por 0,5 o más.', 'Tendencia peligrosa: dos reportes consecutivos a ±0,1 de un límite del rango. Aunque el valor esté dentro del rango, la medición se reclasifica como Alta y genera una alerta.'] },
        ] },
      ] },
      { titulo: 'Recepción de RIN (UC-04)', bloques: [
        { img: '05b_recepcion_rin_paciente.png', cap: 'Recepción de RIN con un paciente cargado.' },
        { p: 'Se usa para registrar un valor de RIN recibido por teléfono, mensaje, correo o desde el laboratorio.' },
        { ol: ['Escriba el DNI del paciente y pulse Buscar.', 'Indique el valor de RIN, la fecha de la medición y el canal de reporte (digital por portal o telefónico).', 'Pulse Reportar RIN.', 'El sistema muestra la clasificación y, si corresponde, la alerta generada. La medición aparece en «Últimas mediciones».'] },
        { nota: 'El valor debe estar entre 0,1 y 20,0 y la fecha no puede ser futura. Si no se cumple, el sistema rechaza el registro y no guarda nada.' },
      ] },
      { titulo: 'Agenda y Turnos (UC-09)', bloques: [
        { img: '06b_agenda_actualizada.png', cap: 'Agenda del período y sugerencias de reasignación.' },
        { ol: ['Elija el rango Desde / Hasta y pulse Actualizar agenda para ver los turnos.', 'Pulse Agendar turno para asignar fecha, hora, médico y observaciones a un paciente.'] },
        { p: 'Cuando un turno se libera o se cancela, el sistema sugiere dárselo a un paciente crítico o con control vencido que no tiene turno próximo. Con Aceptar se reasigna el turno y se notifica a los involucrados; con Rechazar se registra el motivo y puede escalarse el caso al médico.' },
        { nota: 'Un médico no puede tener dos turnos en el mismo horario, y solo se agendan turnos de pacientes activos.' },
      ] },
      { titulo: 'Seguimiento Clínico (UC-10)', bloques: [
        { img: '07b_seguimiento_plazos.png', cap: 'Seguimiento: pacientes con control vencido y registro de contactos.' },
        { ol: ['Pulse Detectar plazos vencidos para actualizar la lista.', 'Seleccione al paciente.', 'Registre el intento de contacto: tipo (llamado, mensaje, correo u otro), resultado (exitoso o fallido) y observaciones.', 'Pulse Registrar intento.'] },
        { ul: ['Contacto exitoso: la alerta se cierra.', 'Contacto fallido: el paciente permanece en la lista. Al tercer intento fallido, la alerta se escala al médico.'] },
        { p: 'Cuando el caso requiere una decisión médica, el médico elige una opción (contactar personalmente, visita domiciliaria, cambiar la periodicidad o declarar al paciente no contactable), escribe el detalle y pulsa Registrar decisión.' },
      ] },
      { titulo: 'Eventos Adversos (UC-03)', bloques: [
        { img: '08_eventos_adversos.png', cap: 'Registro de eventos adversos.' },
        { p: 'Permite registrar hemorragias, trombosis, reacciones y otros episodios, con su gravedad (leve, moderada o grave) y la acción tomada. Seleccione al paciente, pulse Registrar evento adverso, complete los datos y pulse Guardar.' },
        { nota: 'Los eventos de gravedad moderada o grave se destacan con color en el historial. La fecha no puede ser futura y el paciente debe estar activo y tener historia clínica.' },
      ] },
      { titulo: 'Reportes (UC-11, UC-12, UC-13)', sub: [
        { titulo: 'Reporte mensual (UC-11)', bloques: [
          { img: '09b_reporte_mensual.png', cap: 'Reporte mensual de eficacia.' },
          { p: 'Elija el período y pulse Ver reporte del mes. Muestra el indicador global de eficacia (porcentaje de controles dentro del rango) y, por paciente, la cantidad de mediciones, el porcentaje en rango y la clasificación: Óptimo (80 % o más), Subóptimo (50 % o más y menos de 80 %) o Deficiente (menos de 50 %). El reporte queda guardado y se actualiza si se vuelve a generar.' },
        ] },
        { titulo: 'Por diagnóstico (UC-12)', bloques: [
          { img: '09c_reporte_diagnostico.png', cap: 'Reporte por diagnóstico.' },
          { p: 'Agrupa los indicadores según el diagnóstico de la historia clínica. Puede elegir un diagnóstico o ver todos.' },
        ] },
        { titulo: 'Historial del paciente y exportación (UC-13)', bloques: [
          { img: '09d_historial_paciente.png', cap: 'Historial unificado del paciente.' },
          { p: 'Muestra en orden cronológico las mediciones, alertas, seguimientos y eventos de un paciente. Puede exportarlo en PDF, Excel o JSON. Los archivos se guardan en Documentos\\OpenRIN\\Exportaciones y la operación queda registrada.' },
        ] },
      ] },
      { titulo: 'Portal del Paciente', bloques: [
        { img: '10_portal.png', cap: 'Portal del paciente.' },
        { p: 'Es la vista que usan el paciente y su familiar autorizado con las credenciales entregadas en el alta. Permite reportar el propio valor de RIN con el botón «Reportar mi RIN» y consultar el historial propio. Cada valor reportado se clasifica y, si es crítico, genera una alerta que ve el equipo médico.' },
      ] },
      { titulo: 'Sistema y Bitácora (administración)', bloques: [
        { p: 'Módulo para el perfil sysadmin, con cinco pestañas.' },
      ], sub: [
        { titulo: 'Usuarios', bloques: [{ img: '11_sistema.png', cap: 'Administración de usuarios.' }, { p: 'Lista los usuarios con su perfil, estado, intentos fallidos y bloqueo. Permite crear usuarios nuevos y habilitar o deshabilitar cuentas.' }] },
        { titulo: 'Bitácora', bloques: [{ img: '11b_bitacora.png', cap: 'Bitácora de actividad.' }, { p: 'Registra inicios de sesión, altas, modificaciones, exportaciones, respaldos y errores, con fecha, usuario, nivel y capa. Puede filtrarse por nivel.' }] },
        { titulo: 'Control de cambios', bloques: [{ img: '11c_control_cambios.png', cap: 'Control de cambios con restauración.' }, { p: 'Cada alta, modificación o baja queda auditada con el estado anterior y el nuevo. Filtre por entidad y número de registro, seleccione un cambio y pulse Restaurar estado anterior para recomponer el registro. En esta versión no se restauran las bajas.' }] },
        { titulo: 'Idiomas', bloques: [{ img: '11d_idiomas.png', cap: 'Administración de idiomas y leyendas.' }, { p: 'Permite dar de alta un idioma nuevo y editar las leyendas de cualquier idioma. Los cambios se ven al instante, sin reiniciar el programa.' }] },
        { titulo: 'Perfiles y permisos', bloques: [{ img: '11e_perfiles_permisos.png', cap: 'Árbol de permisos por perfil.' }, { p: 'Muestra el árbol de permisos (grupos y funciones). Seleccione un perfil, marque o desmarque funciones o grupos completos y guarde.' }] },
      ] },
      { titulo: 'Idioma', bloques: [
        { p: 'El idioma se cambia al instante desde el selector de la cabecera o desde la pantalla de acceso. Se entregan español (Latinoamérica), inglés y chino simplificado; el administrador puede agregar otros.' },
      ] },
    ] },
    { titulo: 'Mensajes y problemas frecuentes', bloques: [
      { tabla: { cab: ['Mensaje o situación', 'Qué significa y qué hacer'], filas: [
        ['Usuario o contraseña incorrectos', 'Revise los datos. Tras 5 intentos fallidos consecutivos la cuenta se bloquea 15 minutos.'],
        ['Base de datos vulnerada', 'Se detectó una alteración de los datos fuera del sistema. Avise al administrador.'],
        ['El paciente no posee una historia clínica configurada', 'El médico debe configurar primero el rango terapéutico, la medicación y la periodicidad en Pacientes e Historias Clínicas.'],
        ['Valor de RIN fuera del rango biológico', 'El valor debe estar entre 0,1 y 20,0.'],
        ['La fecha no puede ser futura', 'Corrija la fecha de la medición o del evento.'],
        ['Ya existe un paciente activo con ese DNI', 'Busque al paciente en el listado; si estaba dado de baja, marque «Ver inactivos».'],
        ['El médico ya posee un turno en ese horario', 'Elija otro horario u otro médico.'],
        ['No veo algunos módulos', 'Cada perfil accede solo a los módulos que tiene permitidos. Consulte al administrador.'],
        ['Los textos aparecen como claves (por ejemplo shell.titulo)', 'La aplicación no pudo leer los idiomas de la base. Avise al administrador.'],
      ] } },
    ] },
  ],
};

// =====================================================================================================
export const PROGRAMACION = {
  titulo: 'Manual de programación', subtitulo: 'OpenRIN', detalle: 'Documentación técnica para el programador',
  secciones: [
    { titulo: 'Introducción', bloques: [
      { p: 'Este manual está dirigido a quien tenga que mantener o ampliar OpenRIN. Explica cómo está organizado el código, qué patrones usa, cómo se manejan los hilos, la seguridad y los idiomas, cómo compilar y probar, y cómo agregar una función. Al final tiene la referencia de clases, generada a partir de los comentarios de documentación XML del propio código.' },
      { p: 'Para el uso del programa ver el Manual de usuario; para instalarlo, el Manual de instalación.' },
    ], sub: [
      { titulo: 'Tecnologías', bloques: [
        { tabla: { cab: ['Componente', 'Tecnología'], filas: [
          ['Lenguaje y plataforma', 'C# 12 sobre .NET 8 (net8.0-windows)'],
          ['Interfaz', 'Windows Forms, con controles propios por módulo'],
          ['Acceso a datos del negocio', 'Entity Framework Core 8 con repositorios y un único punto de guardado'],
          ['Acceso a datos de servicios', 'ADO.NET (Microsoft.Data.SqlClient) con comandos parametrizados'],
          ['Base de datos', 'SQL Server 2019 o superior (probado con SQL Server 2022 Express)'],
          ['PDF', 'QuestPDF (licencia comunitaria)'],
          ['Criptografía', 'System.Security.Cryptography (AES, PBKDF2) y DPAPI (ProtectedData)'],
          ['Instalador', 'PowerShell + IExpress, con el runtime de .NET incluido'],
        ] } },
      ] },
    ] },
    { titulo: 'Arquitectura', bloques: [
      { p: 'El sistema está dividido en capas. Cada capa solo conoce a las que están debajo; la interfaz nunca toca la base de datos.' },
    ], sub: [
      { titulo: 'Estructura de la solución', bloques: [
        { tabla: { cab: ['Proyecto', 'Capa', 'Qué contiene'], filas: [
          ['Negocio.DomainModel', 'Dominio', 'Entidades (Paciente, HistoriaClinica, MedicionRIN, Alerta, Turno...), enumeraciones, excepciones y registros auxiliares.'],
          ['Negocio.DAL', 'Acceso a datos', 'NegocioDbContext de EF Core, repositorios, auditoría de cambios y migraciones.'],
          ['Negocio.BLL', 'Lógica de negocio', 'Clases *Logic con las reglas de cada módulo: criticidad, tendencia, agenda, seguimiento, reportes e integridad.'],
          ['Services', 'Transversal', 'Seguridad, criptografía, localización, bitácora, respaldos, transacciones y manejo de excepciones, con su fachada.'],
          ['Negocio.UI', 'Interfaz', 'Formularios y un UserControl por módulo.'],
          ['Herramientas', 'Utilitario', 'Comandos sembrar, respaldo e integridad.'],
          ['Pruebas', 'Pruebas', 'Programa de consola con 62 comprobaciones contra una base real.'],
        ] } },
        { p: 'Las dependencias van así: Negocio.UI → Negocio.BLL → Negocio.DAL → Negocio.DomainModel, y Services lo usan todas las capas a través de sus fachadas.' },
        { img: '../../Diagramas/Arquitectura/G06 - Logica de negocio (clases).png', cap: 'Diagrama de clases de la capa de lógica de negocio (draw.io).' },
      ] },
      { titulo: 'Bases de datos', bloques: [
        { ul: ['OpenRIN_Negocio: 13 tablas (Pacientes, ObrasSociales, Diagnosticos, HistoriasClinicas, MedicionesRIN, Alertas, Turnos, Seguimientos, EventosAdversos, Usuarios, ReportesEstadisticos, DigitosVerificadores y AuditoriaCambios). El esquema lo administra Entity Framework mediante migraciones.', 'OpenRIN_Services: Usuarios, Permisos, PerfilesPermisos, Idiomas, Textos y Logs, accedidas con ADO.NET.'] },
        { p: 'Los scripts equivalentes están en la carpeta «4 - Base de Datos». El de negocio se regenera con:' },
        { cod: 'dotnet ef migrations script --idempotent --project Negocio.DAL --startup-project Negocio.DAL -o Negocio.DAL/Tools/script.sql' },
        { p: 'Once tablas llevan la columna DVH (todas menos DigitosVerificadores y AuditoriaCambios). Las relaciones se declaran con 16 claves foráneas en OpenRIN_Negocio (todas las columnas que referencian pacientes, historias, mediciones o usuarios, con borrado restringido) y 2 en OpenRIN_Services (Permisos hacia su grupo padre y Textos hacia Idiomas). PerfilesPermisos y la preferencia de idioma del usuario son referencias lógicas, sin clave foránea. Los diagramas entidad-relación (hojas A, B y C) se generan leyendo el esquema real con Diagramas/_fuente/der.mjs y están en la carpeta «3 - Modelo de diagramas» y en la Carpeta de Proyecto.' },
      ] },
      { titulo: 'Configuración y arranque', bloques: [
        { p: 'Program.Main registra los manejadores globales de excepciones, establece el idioma base, verifica la integridad de la base (VerificacionArranque.Auditar) y, si está todo bien, muestra LoginForm y luego PrincipalForm. Si la verificación falla se muestra IntegridadVulneradaForm y no se permite el acceso.' },
        { p: 'Las cadenas de conexión se leen del archivo .dll.config mediante ConfigurationManager (claves ServicesDB, NegocioDB y BackupString).' },
      ] },
    ] },
    { titulo: 'Patrones de diseño', bloques: [
      { tabla: { cab: ['Patrón', 'Dónde', 'Para qué'], filas: [
        ['Singleton', 'SesionActual', 'Una única sesión de usuario, creada de forma perezosa y protegida con lock.'],
        ['Composite', 'Permiso, PermisoAtomico, PermisoCompuesto', 'Árbol de permisos: las hojas y los grupos responden igual a Incluye().'],
        ['Observer', 'LocalizationLogic.IdiomaCambiado', 'Las vistas se suscriben y refrescan sus textos al cambiar el idioma.'],
        ['Repository', 'IRepositorioGenerico<T>, IPacienteRepositorio', 'Aislar el acceso a datos de la lógica de negocio.'],
        ['Facade', 'Services/Facade/*', 'Punto de entrada estático a los servicios técnicos.'],
        ['Unit of Work (punto único de guardado)', 'NegocioDbContext.SaveChanges', 'Firmar DVH/DVV y auditar en una sola operación.'],
      ] } },
    ] },
    { titulo: 'Hilos y concurrencia', bloques: [
      { p: 'OpenRIN es una aplicación de un solo puesto y casi todo corre en el hilo de la interfaz. Hay tres puntos con concurrencia que conviene conocer.' },
    ], sub: [
      { titulo: 'Refresco del panel de monitoreo', bloques: [
        { p: 'PanelTriajeControl usa un System.Windows.Forms.Timer de 30 segundos. Ese temporizador dispara en el hilo de la interfaz, por lo que no hace falta sincronizar el acceso a los controles. Se pausa al cambiar de módulo (Pausar) y se reanuda al volver (Reanudar).' },
      ] },
      { titulo: 'Respaldo programado', bloques: [
        { p: 'BackupLogic.ProgramarRespaldoDiario crea un System.Threading.Timer que dispara en un hilo del grupo de subprocesos. El acceso al temporizador está protegido con lock (Candado). En producción el respaldo no depende de la aplicación abierta: lo ejecuta la tarea programada de Windows con OpenRIN.Herramientas.exe respaldo.' },
      ] },
      { titulo: 'Estado compartido protegido con lock', bloques: [
        { ul: ['SesionActual: instancia única con doble verificación y lock.', 'LocalizationLogic: diccionario del idioma activo, lista de idiomas y suscriptores, protegidos con lock (Candado).', 'BitacoraLogic y TransaccionDAL: escritura de la bitácora y transacción activa, protegidas con lock.'] },
        { nota: 'Si agrega trabajo en segundo plano, no toque controles desde otro hilo: use Control.Invoke para volver al hilo de la interfaz.' },
      ] },
    ] },
    { titulo: 'Seguridad', bloques: [
      { ul: ['Contraseñas y respuestas de seguridad: PBKDF2-SHA256, 120 000 iteraciones y sal aleatoria de 16 bytes; formato «sal.iteraciones.hash»; comparación en tiempo constante.', 'Cifrado simétrico: AES-CBC de 256 bits (CryptographyService). La clave se genera la primera vez y se guarda con DPAPI en %LOCALAPPDATA%\\OpenRIN\\enc.key.', 'Anti fuerza bruta: 5 intentos fallidos bloquean la cuenta 15 minutos.', 'Acceso a base: autenticación integrada de Windows; las consultas ADO.NET son siempre parametrizadas.', 'Permisos: cada módulo y acción se habilita consultando el árbol de permisos por código (PA001, PO001, SI001...).', 'Integridad: dígitos verificadores horizontales (por fila) y verticales (por tabla). SaveChanges trabaja en tres fases: persistir, firmar el DVH de cada fila y recalcular el DVV de cada tabla tocada.', 'Control de cambios: AuditoriaDeCambios serializa en JSON el estado anterior y el nuevo; AuditoriaLogic.Restaurar recompone un estado anterior y lo vuelve a firmar.'] },
      { nota: 'La clave AES existe como servicio, pero hoy no se aplica a campos de la base: las contraseñas y respuestas de seguridad se almacenan con hash PBKDF2.' },
    ] },
    { titulo: 'Idiomas', bloques: [
      { p: 'Los idiomas y sus textos están en la base (tablas Idiomas y Textos); no se usan hojas de recursos. LocalizationService.ObtenerTexto(clave) devuelve el texto del idioma activo, o la clave si no existe. Se entregan es, en y zh-CN. EstablecerIdioma(codigo) cambia el idioma en caliente y notifica a los suscriptores.' },
    ], sub: [
      { titulo: 'Agregar un texto', bloques: [
        { ol: ['Elija una clave jerárquica, por ejemplo agenda.nuevaColumna.', 'Agregue la fila en cada idioma a Services/DAL/Tools/localizacion_seed.sql (MERGE idempotente).', 'Use Texto("agenda.nuevaColumna") en el formulario y vuelva a aplicar los textos en AplicarTextos().'] },
      ] },
      { titulo: 'Agregar un idioma', bloques: [{ p: 'Desde Sistema y Bitácora > Idiomas, sin recompilar.' }] },
    ] },
    { titulo: 'Compilar, ejecutar y probar', sub: [
      { titulo: 'Compilar', bloques: [
        { ol: ['Instale el SDK de .NET 8 o superior y SQL Server (Express alcanza).', 'Copie el proyecto en una ruta corta (por ejemplo C:\\OpenRIN): las rutas largas rompen la compilación.', 'Cree las bases y cargue los scripts (Manual de instalación, sección 6).', 'Cree la configuración junto al ejecutable (apartado 7.4).'] },
        { cod: 'cd Codigo\ndotnet build PlataformaACO.sln\ndotnet run --project Negocio.UI' },
      ] },
      { titulo: 'Pruebas automáticas', bloques: [
        { p: 'El proyecto Pruebas recorre los casos de uso contra una base real y verifica 62 comprobaciones: idiomas, seguridad, pacientes, historia clínica, RIN y criticidad, alertas, eventos, agenda, seguimiento, reportes, exportación, control de cambios, integridad y respaldo. Termina con código 0 si todas pasan.' },
        { cod: 'copy Pruebas\\App.config.ejemplo Pruebas\\App.config\ndotnet run --project Pruebas' },
      ] },
      { titulo: 'Generar el instalador', bloques: [
        { p: 'Instalador/Construir_Setup.ps1 publica Negocio.UI y Herramientas como autocontenidos (win-x64), comprime la aplicación, copia los scripts SQL y la ayuda en línea y genera OpenRIN-Setup.exe con IExpress.' },
        { cod: 'powershell -ExecutionPolicy Bypass -File Instalador\\Construir_Setup.ps1' },
      ] },
      { titulo: 'Configuración', bloques: [
        { p: 'Cree Negocio.UI/App.config tomando como modelo App.config.example. En .NET 8 se copia como Negocio.UI.dll.config. Ejemplo con SQL Server local y autenticación de Windows:' },
        { cod: '<connectionStrings>\n  <add name="ServicesDB" connectionString="Server=.\\SQLEXPRESS;Database=OpenRIN_Services;Integrated Security=True;TrustServerCertificate=True;" />\n  <add name="NegocioDB"  connectionString="Server=.\\SQLEXPRESS;Database=OpenRIN_Negocio;Integrated Security=True;TrustServerCertificate=True;" />\n  <add name="BackupString" connectionString="Server=.\\SQLEXPRESS;Database=master;Integrated Security=True;TrustServerCertificate=True;" />\n</connectionStrings>' },
      ] },
    ] },
    { titulo: 'Cómo agregar una función', sub: [
      { titulo: 'Agregar un módulo', bloques: [
        { ol: ['Cree la clase de lógica en Negocio.BLL, que reciba el NegocioDbContext.', 'Cree el UserControl en Negocio.UI.', 'En PrincipalForm.ConstruirMenu agregue AgregarModulo("mod.nuevo", sysadmin || tiene("PA0xx")) y la rama correspondiente en MostrarModulo.', 'Agregue el permiso en permisos.sql, su texto en localizacion_seed.sql y el tema de ayuda en Documentacion/_fuente.'] },
      ] },
      { titulo: 'Agregar una entidad', bloques: [
        { ol: ['Cree la clase en Negocio.DomainModel/Entities.', 'Agregue el DbSet y su configuración a NegocioDbContext.', 'Si debe firmarse, agréguela a IntegridadLogic.', 'Genere la migración y regenere el script de esquema.'] },
        { cod: 'dotnet ef migrations add NombreMigracion --project Negocio.DAL --startup-project Negocio.DAL' },
      ] },
      { titulo: 'Cambiar una regla de negocio', bloques: [
        { p: 'Las constantes están en la lógica correspondiente: MedicionRINLogic (DistanciaAlta = 0,5; MargenBorde = 0,1), SeguimientoLogic (UmbralIntentosFallidos = 3) y ReporteLogic (UmbralOptimo = 80; UmbralSuboptimo = 50). Actualice también las pruebas y los diagramas.' },
      ] },
    ] },
    { titulo: 'Referencia de clases', api: true, bloques: [
      { p: 'Generada a partir de los comentarios de documentación XML del código, agrupada por espacio de nombres.' },
    ] },
  ],
};
