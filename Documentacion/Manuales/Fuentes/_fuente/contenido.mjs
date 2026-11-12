// Contenido de la documentación de OpenRIN. Cada documento es una lista de secciones; cada sección una lista de bloques:
//   {p:"texto"} {h:"subtítulo"} {ul:[...]} {ol:[...]} {img:"archivo.png", cap:"pie"} {nota:"texto"} {tabla:{cab:[...], filas:[[...]]}} {cod:"código"}
// La clave de demostración es ALEATORIA por instalación (la genera el instalador / sembrar).
// No publicar ninguna clave por defecto.

// ------------------------------------------------------------------ AYUDA / GUÍA DEL USUARIO
export const USUARIO = [
  { id: 'inicio', titulo: 'Bienvenido a OpenRIN', bloques: [
    { p: 'OpenRIN es una plataforma de escritorio para consultorios de hematología que atienden pacientes con anticoagulación oral. Concentra en un solo lugar el registro de pacientes, la historia clínica hematológica, los valores de RIN reportados, las alertas, la agenda de turnos, el seguimiento clínico y los reportes de eficacia.' },
    { p: 'El RIN (índice internacional normalizado) mide el tiempo de coagulación. Cada paciente tiene un rango terapéutico propio, por ejemplo de 2,0 a 3,0. Un valor fuera de ese rango implica riesgo de sangrado o de trombosis, por lo que OpenRIN clasifica cada valor y avisa al equipo cuando hace falta actuar.' },
    { img: '02_principal.png', cap: 'Pantalla principal: a la izquierda los módulos disponibles para su perfil; a la derecha el módulo activo.' },
    { h: 'Cómo está organizada esta ayuda' },
    { ul: ['Ingreso al sistema y recuperación de contraseña.', 'Un tema por cada módulo del menú lateral.', 'Glosario y preguntas frecuentes.'] },
    { nota: 'Puede abrir esta ayuda en cualquier momento con el botón «Ayuda» o con la tecla F1. Se abre en el tema del módulo en el que está trabajando.' },
  ] },
  { id: 'ingreso', titulo: 'Ingreso al sistema', bloques: [
    { img: '01_login.png', cap: 'Pantalla de acceso.' },
    { ol: ['Escriba su nombre de usuario y su contraseña.', 'Si lo desea, elija el idioma (español, inglés o chino simplificado).', 'Pulse «Ingresar».'] },
    { p: 'Antes de mostrar esta pantalla, OpenRIN verifica la integridad de la base de datos. Si detecta que los datos fueron alterados fuera del sistema, no permite el ingreso y muestra un aviso para el administrador (vea «Base de datos vulnerada» en la Guía de operación).' },
    { h: 'Si olvidó su contraseña' },
    { ol: ['Pulse «¿Olvidó su contraseña?».', 'Indique su usuario y responda la pregunta de seguridad que configuró.', 'Escriba la nueva contraseña.'] },
    { nota: 'Después de 5 intentos fallidos consecutivos, la cuenta se bloquea durante 15 minutos. El administrador puede ver los intentos y el bloqueo en Sistema y Bitácora > Usuarios.' },
    { h: 'Perfiles de usuario' },
    { tabla: { cab: ['Perfil', 'Módulos a los que accede'], filas: [
      ['Médico', 'Panel de monitoreo, eventos adversos, seguimiento clínico y reportes; consulta de historias clínicas.'],
      ['Administrativo', 'Pacientes e historias clínicas, panel de monitoreo, recepción de RIN, agenda y reportes.'],
      ['Paciente / Familiar autorizado', 'Portal del paciente: reportar su propio RIN y consultar su historial.'],
      ['Sysadmin', 'Todos los módulos, más Sistema y Bitácora.'],
    ] } },
    { p: 'Los permisos de cada perfil pueden modificarse desde Sistema y Bitácora > Perfiles y permisos.' },
  ] },
  { id: 'pacientes', titulo: 'Pacientes e Historias Clínicas', bloques: [
    { img: '03_pacientes.png', cap: 'Listado de pacientes.' },
    { p: 'Este módulo permite registrar pacientes, modificar sus datos, darlos de baja y configurar su historia clínica hematológica.' },
    { h: 'Buscar pacientes' },
    { p: 'Escriba parte del nombre o del documento en «Buscar» y pulse «Buscar». Marque «Ver inactivos» para incluir a los pacientes dados de baja.' },
    { h: 'Registrar un paciente' },
    { img: '03b_alta_paciente.png', cap: 'Formulario de alta de paciente.' },
    { ol: ['Pulse «Alta de Paciente».', 'Complete nombre, documento (DNI), teléfono, correo, obra social y número de afiliado.', 'Pulse «Guardar».', 'El sistema muestra el usuario y la contraseña temporal con los que el paciente podrá ingresar al portal. Anótelos y entréguelos al paciente.'] },
    { nota: 'El DNI es único entre los pacientes activos. Si ya existe, el sistema rechaza el alta y lo informa.' },
    { h: 'Modificar o dar de baja' },
    { p: 'Seleccione al paciente en el listado y pulse «Modificar» para editar sus datos, o «Dar de baja» para indicar el motivo. La baja es lógica: el paciente queda inactivo, se deshabilitan sus credenciales del portal y se conserva toda su historia clínica.' },
    { h: 'Historia clínica hematológica' },
    { img: '03c_historia_clinica.png', cap: 'Configuración de la historia clínica.' },
    { p: 'Seleccione al paciente y pulse «Historia clínica». Allí el médico define:' },
    { ul: ['Diagnóstico o indicación de la anticoagulación.', 'Límites inferior y superior del rango terapéutico de RIN (el inferior debe ser menor que el superior).', 'Medicamento y dosis.', 'Periodicidad de reporte, en días: cada cuánto debe controlarse el paciente.', 'Fecha del próximo control (opcional).'] },
    { nota: 'Sin historia clínica configurada no es posible registrar valores de RIN del paciente, porque el sistema necesita su rango terapéutico para clasificarlos.' },
  ] },
  { id: 'panel', titulo: 'Panel de Monitoreo', bloques: [
    { img: '04_panel_monitoreo.png', cap: 'Panel de monitoreo con los pacientes ordenados por prioridad.' },
    { p: 'El panel muestra a los pacientes activos ordenados por riesgo: arriba están los que requieren atención primero. Se actualiza solo cada 30 segundos; también puede pulsar «Actualizar».' },
    { tabla: { cab: ['Columna', 'Significado'], filas: [
      ['Último RIN / Último reporte', 'Valor y fecha de la medición más reciente.'],
      ['Días sin reportar', 'Días transcurridos desde esa medición.'],
      ['Criticidad', 'Crítico (Alta), Moderado (Media), Estable (Baja) o Sin datos.'],
      ['Alerta', 'Campana: el paciente tiene una alerta activa. El triángulo junto a «Crítico» indica tendencia peligrosa.'],
    ] } },
    { h: 'Cómo se calcula la criticidad' },
    { ul: ['Baja: el valor está dentro del rango terapéutico del paciente.', 'Media: el valor está fuera del rango por menos de 0,5.', 'Alta: el valor está fuera del rango por 0,5 o más.', 'Tendencia peligrosa: dos reportes consecutivos a ±0,1 de un límite del rango. Aunque el valor esté dentro del rango, la medición se reclasifica como Alta y genera una alerta.'] },
  ] },
  { id: 'rin', titulo: 'Recepción de RIN', bloques: [
    { img: '05b_recepcion_rin_paciente.png', cap: 'Recepción de RIN con un paciente cargado.' },
    { p: 'Se usa para registrar un valor de RIN recibido por teléfono, mensaje, correo o desde el laboratorio. Si el paciente lo reporta desde su portal, el valor llega al mismo circuito.' },
    { ol: ['Escriba el DNI del paciente y pulse «Buscar».', 'Indique el valor de RIN, la fecha de la medición y el canal de reporte (digital por portal o telefónico).', 'Pulse «Reportar RIN».', 'El sistema muestra la clasificación y, si corresponde, la alerta generada. La medición aparece en «Últimas mediciones».'] },
    { nota: 'El valor debe estar entre 0,1 y 20,0 y la fecha no puede ser futura. Si no se cumple, el sistema rechaza el registro y no guarda nada.' },
  ] },
  { id: 'agenda', titulo: 'Agenda y Turnos', bloques: [
    { img: '06b_agenda_actualizada.png', cap: 'Agenda del período y sugerencias de reasignación.' },
    { ol: ['Elija el rango «Desde / Hasta» y pulse «Actualizar agenda» para ver los turnos.', 'Pulse «Agendar turno» para asignar fecha, hora, médico y observaciones a un paciente.'] },
    { h: 'Reasignación inteligente' },
    { p: 'Cuando un turno se libera o se cancela, el sistema sugiere dárselo a un paciente crítico o con control vencido que no tiene turno próximo. Las sugerencias aparecen a la derecha:' },
    { ul: ['«Aceptar»: reasigna el turno y notifica a los involucrados.', '«Rechazar»: se registra el motivo y puede escalarse el caso al médico.'] },
    { nota: 'Un médico no puede tener dos turnos en el mismo horario, y solo se agendan turnos de pacientes activos.' },
  ] },
  { id: 'seguimiento', titulo: 'Seguimiento Clínico', bloques: [
    { img: '07b_seguimiento_plazos.png', cap: 'Seguimiento: pacientes con control vencido y registro de contactos.' },
    { p: 'Cuando un paciente supera su periodicidad sin reportar un RIN, el sistema genera una alerta de reporte ausente y lo incluye en la lista de contactos.' },
    { ol: ['Pulse «Detectar plazos vencidos» para actualizar la lista.', 'Seleccione al paciente.', 'Registre el intento de contacto: tipo (llamado, mensaje, correo u otro), resultado (exitoso o fallido) y observaciones.', 'Pulse «Registrar intento».'] },
    { ul: ['Contacto exitoso: la alerta se cierra.', 'Contacto fallido: el paciente permanece en la lista. Al tercer intento fallido, la alerta se escala al médico.'] },
    { h: 'Decisión clínica' },
    { p: 'Cuando el caso requiere una decisión médica, el médico elige una opción (contactar personalmente, visita domiciliaria, cambiar la periodicidad o declarar al paciente no contactable), escribe el detalle y pulsa «Registrar decisión». Si cambia la periodicidad, indique la nueva en días.' },
  ] },
  { id: 'eventos', titulo: 'Eventos Adversos', bloques: [
    { img: '08_eventos_adversos.png', cap: 'Registro de eventos adversos.' },
    { p: 'Permite registrar hemorragias, trombosis, reacciones y otros episodios ocurridos durante el tratamiento, con su gravedad (leve, moderada o grave) y la acción tomada.' },
    { ol: ['Seleccione al paciente.', 'Pulse «Registrar evento adverso».', 'Complete fecha, tipo, gravedad, descripción y acción tomada.', 'Pulse «Guardar».'] },
    { nota: 'Los eventos de gravedad moderada o grave se destacan con color en el historial. La fecha no puede ser futura y el paciente debe estar activo y tener historia clínica.' },
  ] },
  { id: 'reportes', titulo: 'Reportes', bloques: [
    { img: '09b_reporte_mensual.png', cap: 'Reporte mensual de eficacia.' },
    { h: 'Reporte mensual' },
    { p: 'Elija el período (mes y año) y pulse «Ver reporte del mes». Muestra el indicador global de eficacia (porcentaje de controles dentro del rango) y, por paciente, la cantidad de mediciones, el porcentaje en rango y la clasificación:' },
    { ul: ['Óptimo: 80 % o más de las mediciones dentro del rango.', 'Subóptimo: 50 % o más y menos de 80 %.', 'Deficiente: menos de 50 %.'] },
    { p: 'El reporte queda guardado en el sistema; si se vuelve a generar para el mismo mes, se actualiza.' },
    { h: 'Por diagnóstico' },
    { img: '09c_reporte_diagnostico.png', cap: 'Reporte por diagnóstico.' },
    { p: 'Agrupa los indicadores según el diagnóstico de la historia clínica. Puede elegir un diagnóstico o ver todos.' },
    { h: 'Historial del paciente y exportación' },
    { img: '09d_historial_paciente.png', cap: 'Historial unificado del paciente.' },
    { p: 'Muestra en orden cronológico las mediciones, alertas, seguimientos y eventos de un paciente. Puede exportarlo en PDF, Excel o JSON. Los archivos se guardan en la carpeta Documentos\\OpenRIN\\Exportaciones y la operación queda registrada.' },
  ] },
  { id: 'portal', titulo: 'Portal del Paciente', bloques: [
    { img: '10_portal.png', cap: 'Portal del paciente.' },
    { p: 'Es la vista que usan el paciente anticoagulado y su familiar autorizado, con las credenciales entregadas en el alta. Permite reportar el propio valor de RIN con el botón «Reportar mi RIN» y consultar el historial propio. Cada valor reportado se clasifica y, si es crítico, genera una alerta que ve el equipo médico.' },
  ] },
  { id: 'sistema', titulo: 'Sistema y Bitácora', bloques: [
    { p: 'Módulo de administración, disponible para el perfil sysadmin. Tiene cinco pestañas.' },
    { h: 'Usuarios' },
    { img: '11_sistema.png', cap: 'Administración de usuarios.' },
    { p: 'Lista los usuarios con su perfil, estado, intentos fallidos y bloqueo. Permite crear usuarios nuevos y habilitar o deshabilitar cuentas.' },
    { h: 'Bitácora' },
    { img: '11b_bitacora.png', cap: 'Bitácora de actividad.' },
    { p: 'Registra inicios de sesión, altas, modificaciones, exportaciones, respaldos y errores, con fecha, hora, usuario, nivel y capa. Puede filtrarse por nivel (depuración, información, advertencia, error y fatal).' },
    { h: 'Control de cambios' },
    { img: '11c_control_cambios.png', cap: 'Control de cambios con restauración.' },
    { p: 'Cada alta, modificación o baja de datos queda auditada con el estado anterior y el nuevo. Filtre por entidad y número de registro, seleccione un cambio para ver ambos estados y pulse «Restaurar estado anterior» para recomponer el registro. La restauración también queda auditada. En esta versión no se restauran las bajas.' },
    { h: 'Idiomas' },
    { img: '11d_idiomas.png', cap: 'Administración de idiomas y leyendas.' },
    { p: 'Permite dar de alta un idioma nuevo y editar las leyendas de cualquier idioma. Los cambios se ven al instante, sin reiniciar el programa.' },
    { h: 'Perfiles y permisos' },
    { img: '11e_perfiles_permisos.png', cap: 'Árbol de permisos por perfil.' },
    { p: 'Muestra el árbol de permisos (grupos y funciones). Seleccione un perfil, marque o desmarque funciones o grupos completos y guarde.' },
  ] },
  { id: 'glosario', titulo: 'Glosario', bloques: [
    { tabla: { cab: ['Término', 'Significado'], filas: [
      ['ACO', 'Anticoagulación oral: tratamiento con anticoagulantes por vía oral.'],
      ['RIN (INR)', 'Índice internacional normalizado. Mide el tiempo de coagulación.'],
      ['Rango terapéutico', 'Intervalo de RIN, propio de cada paciente, en el que el riesgo es mínimo.'],
      ['Criticidad', 'Clasificación de un valor de RIN: Baja, Media o Alta.'],
      ['Tendencia peligrosa', 'Dos reportes consecutivos en el borde del rango (±0,1), aunque estén dentro de él.'],
      ['Triaje', 'Priorización de pacientes según la criticidad de su último RIN y sus alertas.'],
      ['Evento adverso', 'Episodio no deseado durante el tratamiento (hemorragia, trombosis u otro).'],
      ['DVH / DVV', 'Dígitos verificadores horizontal (por fila) y vertical (por tabla), que protegen la integridad de los datos.'],
    ] } },
  ] },
  { id: 'faq', titulo: 'Preguntas frecuentes', bloques: [
    { h: 'No puedo registrar un RIN: dice que falta la historia clínica.' },
    { p: 'El médico debe configurar primero la historia clínica del paciente (rango terapéutico, medicación y periodicidad) en Pacientes e Historias Clínicas.' },
    { h: 'No veo algunos módulos.' },
    { p: 'Cada perfil accede solo a los módulos que tiene permitidos. Consulte al administrador del sistema.' },
    { h: 'La cuenta está bloqueada.' },
    { p: 'Tras 5 intentos fallidos se bloquea 15 minutos. Espere o pida al administrador que la revise.' },
    { h: 'Apareció «Base de datos vulnerada».' },
    { p: 'Se detectó una alteración de los datos fuera del sistema. Avise al administrador: debe seguir el procedimiento de la Guía de operación.' },
    { h: '¿Dónde quedan los archivos exportados?' },
    { p: 'En Documentos\\OpenRIN\\Exportaciones.' },
  ] },
];

// ------------------------------------------------------------------ MANUAL DE INSTALACIÓN (D01)
export const INSTALACION = [
  { titulo: 'Introducción', bloques: [
    { p: 'Este manual explica cómo instalar OpenRIN 1.0 en un equipo del consultorio. El instalador (OpenRIN-Setup.exe) instala la aplicación, el motor de base de datos si no existe, las bases OpenRIN_Services y OpenRIN_Negocio con su esquema, y los datos de demostración, con una interacción mínima.' },
  ] },
  { titulo: 'Requisitos', bloques: [
    { tabla: { cab: ['Elemento', 'Requisito'], filas: [
      ['Sistema operativo', 'Windows 10 u 11 de 64 bits.'],
      ['Permisos', 'Cuenta con permisos de administrador del equipo.'],
      ['Espacio en disco', 'Al menos 1500 MB libres en la unidad del sistema.'],
      ['Motor de base de datos', 'SQL Server 2019 o superior (la edición Express alcanza). Si no hay ninguna instancia, el instalador instala SQL Server 2022 Express usando winget.'],
      ['.NET', 'No hace falta instalarlo: la aplicación incluye el runtime de .NET 8.'],
      ['Internet', 'Solo si hay que instalar SQL Server Express.'],
    ] } },
    { nota: 'El usuario que instala debe ser administrador (sysadmin) de la instancia de SQL Server. Si se instala SQL Server Express con el instalador, el grupo Administradores del equipo queda como sysadmin.' },
  ] },
  { titulo: 'Instalación paso a paso', bloques: [
    { ol: ['Copie OpenRIN-Setup.exe al equipo y haga doble clic.', 'Acepte el aviso de control de cuentas de usuario de Windows.', 'Espere a que el instalador complete los ocho pasos que muestra en la ventana.', 'Cuando aparezca «Instalación finalizada», pulse Enter para cerrar.', 'Abra OpenRIN desde el acceso directo del escritorio.'] },
    { h: 'Qué hace el instalador' },
    { tabla: { cab: ['Paso', 'Acción'], filas: [
      ['1', 'Verifica la versión de Windows y el espacio en disco.'],
      ['2', 'Busca una instancia de SQL Server 2019 o superior; si no hay, instala SQL Server 2022 Express.'],
      ['3', 'Crea las bases OpenRIN_Services y OpenRIN_Negocio y carga sus esquemas, permisos, idiomas y textos.'],
      ['4', 'Copia la aplicación a C:\\Program Files\\OpenRIN y escribe su configuración (autenticación integrada de Windows, sin contraseñas guardadas).'],
      ['5', 'Crea los usuarios y los datos de demostración (cinco pacientes de ejemplo) y verifica la integridad.'],
      ['6', 'Crea los accesos directos en el escritorio y en el menú Inicio.'],
      ['7', 'Programa el respaldo diario a las 03:00 en el Programador de tareas de Windows.'],
      ['8', 'Registra OpenRIN en Aplicaciones instaladas para poder desinstalarlo.'],
    ] } },
    { h: 'Usuarios de demostración' },
    { tabla: { cab: ['Usuario', 'Perfil', 'Contraseña inicial'], filas: [
      ['sysadmin', 'Administrador del sistema', '(aleatoria por instalación)'],
      ['medico', 'Médico', '(aleatoria por instalación)'],
      ['recepcion', 'Administrativo', '(aleatoria por instalación)'],
    ] } },
    { p: 'La clave de demostración es aleatoria y se muestra una única vez por consola al instalar (o al ejecutar «OpenRIN.Herramientas.exe sembrar»). No existe ninguna clave por defecto documentada.' },
    { nota: 'Cambie estas contraseñas después de la primera prueba (pantalla de acceso > «¿Olvidó su contraseña?», o Sistema y Bitácora). Los pacientes de demostración pueden darse de baja desde el módulo de pacientes antes de usar el sistema con datos reales.' },
  ] },
  { titulo: 'Opciones avanzadas', bloques: [
    { p: 'El instalador es un script de PowerShell (Instalar.ps1). Puede ejecutarse directamente con estos parámetros:' },
    { tabla: { cab: ['Parámetro', 'Descripción'], filas: [
      ['-Servidor', 'Instancia de SQL Server a usar, por ejemplo ".\\SQLEXPRESS". Por defecto se detecta sola.'],
      ['-Destino', 'Carpeta de instalación. Por defecto C:\\Program Files\\OpenRIN.'],
      ['-ClaveDemo', 'Contraseña inicial de los usuarios de demostración.'],
      ['-Silencioso', 'No hace preguntas ni espera una tecla al final.'],
    ] } },
    { cod: 'powershell -ExecutionPolicy Bypass -File Instalar.ps1 -Servidor ".\\SQLEXPRESS" -Silencioso' },
    { p: 'Para extraer los archivos del instalador sin ejecutarlo: OpenRIN-Setup.exe /Q /C /T:C:\\carpeta.' },
  ] },
  { titulo: 'Verificación de la instalación', bloques: [
    { ol: ['Abra OpenRIN: debe aparecer la pantalla «Iniciar Sesión».', 'Ingrese con sysadmin y la contraseña inicial.', 'En la cabecera debe leerse «Integridad OK».', 'Abra Panel de Monitoreo: deben verse los cinco pacientes de demostración.', 'Compruebe la tarea programada «OpenRIN - Respaldo Nocturno (app)» en el Programador de tareas.'] },
    { p: 'El registro de la instalación queda en %TEMP%\\OpenRIN_instalacion.log.' },
  ] },
  { titulo: 'Solución de problemas', bloques: [
    { tabla: { cab: ['Síntoma', 'Causa probable y solución'], filas: [
      ['«No se encontró winget»', 'Instale SQL Server Express manualmente (https://aka.ms/sqlexpress) y vuelva a ejecutar el instalador.'],
      ['«El usuario actual no es administrador (sysadmin)»', 'Ejecute el instalador con un usuario que sea sysadmin de la instancia, o indique otra con -Servidor.'],
      ['Al abrir aparece la pantalla de integridad', 'La base no está accesible o fue alterada. Verifique que el servicio SQL Server esté iniciado y revise Guía de operación.'],
      ['El respaldo nocturno falla', 'Revise permisos de C:\\OpenRIN\\Backups y ejecute OpenRIN.Herramientas.exe respaldo para ver el mensaje.'],
      ['Los textos se ven como claves (por ejemplo shell.titulo)', 'No se pudo leer la tabla de idiomas: revise la cadena de conexión en Negocio.UI.dll.config.'],
    ] } },
  ] },
  { titulo: 'Desinstalación', bloques: [
    { p: 'Use «Desinstalar OpenRIN» del menú Inicio o Aplicaciones instaladas de Windows. Se eliminan la aplicación, los accesos directos y la tarea de respaldo. Las bases de datos y los respaldos se conservan. Para eliminar también las bases:' },
    { cod: 'powershell -ExecutionPolicy Bypass -File "C:\\Program Files\\OpenRIN\\Desinstalar.ps1" -QuitarBases' },
  ] },
];

// ------------------------------------------------------------------ GUÍA DE OPERACIÓN (D03)
export const OPERACION = [
  { titulo: 'Objetivo y alcance', bloques: [
    { p: 'Esta guía está dirigida a la persona que opera el sistema en el consultorio (administrador): rutinas diarias, respaldos, usuarios, control de integridad y qué hacer ante incidentes.' },
  ] },
  { titulo: 'Rutina diaria', bloques: [
    { ul: ['Al abrir el sistema, confirmar que la cabecera indique «Integridad OK».', 'Revisar el Panel de Monitoreo: atender primero los pacientes en rojo.', 'Ejecutar «Detectar plazos vencidos» en Seguimiento Clínico y gestionar la lista de contactos.', 'Revisar las sugerencias de reasignación en Agenda y Turnos.'] },
  ] },
  { titulo: 'Gestión de usuarios y perfiles', bloques: [
    { ul: ['Alta de usuarios del personal: Sistema y Bitácora > Usuarios > Nuevo usuario. Elija el perfil adecuado.', 'Los pacientes reciben su usuario del portal al registrarse en el módulo de pacientes.', 'Deshabilite las cuentas del personal que deja el consultorio; no se eliminan para conservar la trazabilidad.', 'Ajuste los permisos de cada perfil en Perfiles y permisos.', 'Una cuenta bloqueada por 5 intentos fallidos se libera sola a los 15 minutos.'] },
  ] },
  { titulo: 'Respaldos', bloques: [
    { p: 'El respaldo completo de OpenRIN_Services y OpenRIN_Negocio se ejecuta todos los días a las 03:00 con la tarea «OpenRIN - Respaldo Nocturno (app)» del Programador de tareas, aunque la aplicación esté cerrada. Cada archivo .bak se verifica con RESTORE VERIFYONLY y el resultado queda en la bitácora.' },
    { tabla: { cab: ['Dato', 'Valor'], filas: [
      ['Carpeta de respaldos', 'C:\\OpenRIN\\Backups (se cambia con la clave BackupFolder del archivo de configuración)'],
      ['Nombre de archivo', 'OpenRIN_Negocio_AAAAMMDD_HHMMSS_FULL.bak'],
      ['Respaldo manual', 'OpenRIN.Herramientas.exe respaldo (en C:\\Program Files\\OpenRIN)'],
    ] } },
    { nota: 'Copie periódicamente la carpeta de respaldos a otro disco o a la nube: un respaldo en el mismo equipo no protege ante una falla del disco.' },
    { h: 'Restaurar un respaldo' },
    { ol: ['Cierre OpenRIN en todos los equipos.', 'Con SQL Server Management Studio o sqlcmd, restaure el archivo .bak sobre la base correspondiente.', 'Abra OpenRIN y verifique «Integridad OK».'] },
    { cod: "RESTORE DATABASE OpenRIN_Negocio FROM DISK = 'C:\\OpenRIN\\Backups\\OpenRIN_Negocio_AAAAMMDD_HHMMSS_FULL.bak' WITH REPLACE;" },
  ] },
  { titulo: 'Integridad de los datos (DVH / DVV)', bloques: [
    { p: 'Cada fila de las 11 tablas de datos de negocio lleva un dígito verificador horizontal (DVH) calculado con sus campos y su posición, y cada tabla tiene un dígito vertical (DVV) calculado con los DVH de todas sus filas. El sistema los verifica al arrancar, antes del inicio de sesión.' },
    { h: 'Base de datos vulnerada' },
    { p: 'Si la verificación falla se muestra una pantalla con el detalle de los problemas y el ingreso queda bloqueado. Procedimiento:' },
    { ol: ['No se intente ingresar ni modificar datos.', 'Identifique la causa con el detalle: ¿se editó la base con una herramienta externa? ¿se restauró un respaldo parcial?', 'Si la alteración es un error conocido y legítimo, recalcule las firmas con la herramienta de reparación (administrador).', 'Si la alteración es desconocida, restaure el último respaldo válido y registre el incidente.'] },
    { p: 'La auditoría puede ejecutarse en cualquier momento con OpenRIN.Herramientas.exe integridad.' },
  ] },
  { titulo: 'Bitácora y control de cambios', bloques: [
    { ul: ['La bitácora se guarda en la base y, como destino alternativo, en el archivo log_fallback.txt de C:\\ProgramData\\OpenRIN.', 'Control de cambios permite saber quién, cuándo y qué se modificó, y recomponer el estado anterior de un registro.', 'Revise periódicamente las entradas de nivel Warning, Error y Fatal.'] },
  ] },
  { titulo: 'Incidentes frecuentes', bloques: [
    { tabla: { cab: ['Incidente', 'Qué hacer'], filas: [
      ['La aplicación no abre o muestra la pantalla de integridad sin motivo', 'Verifique que el servicio de SQL Server esté iniciado y que el equipo llegue a la instancia indicada en Negocio.UI.dll.config.'],
      ['Un paciente reportó un RIN por error', 'Corrija el valor con Control de cambios (restaurar estado anterior) y registre el motivo en observaciones.'],
      ['El respaldo nocturno no se generó', 'Revise la bitácora y el historial de la tarea programada; ejecute un respaldo manual.'],
      ['Se olvidó la contraseña del administrador', 'Use «¿Olvidó su contraseña?» con la pregunta de seguridad; si no es posible, un técnico puede restablecerla con la herramienta de mantenimiento.'],
    ] } },
  ] },
];

// ------------------------------------------------------------------ GUÍA DE MANTENIMIENTO (D03)
export const MANTENIMIENTO = [
  { titulo: 'Objetivo y alcance', bloques: [
    { p: 'Guía para el técnico que mantiene OpenRIN: componentes instalados, configuración, actualización de versiones, cambios en la base de datos y diagnóstico de problemas.' },
  ] },
  { titulo: 'Componentes instalados', bloques: [
    { tabla: { cab: ['Componente', 'Ubicación'], filas: [
      ['Aplicación', 'C:\\Program Files\\OpenRIN (Negocio.UI.exe y bibliotecas, con el runtime de .NET 8)'],
      ['Herramientas', 'OpenRIN.Herramientas.exe: comandos sembrar, respaldo e integridad'],
      ['Configuración', 'Negocio.UI.dll.config y OpenRIN.Herramientas.dll.config, junto a los ejecutables'],
      ['Datos de trabajo', 'C:\\ProgramData\\OpenRIN (bitácora de respaldo)'],
      ['Respaldos', 'C:\\OpenRIN\\Backups'],
      ['Clave de cifrado', '%LOCALAPPDATA%\\OpenRIN\\enc.key, protegida con DPAPI para el usuario de Windows'],
      ['Bases de datos', 'OpenRIN_Services (seguridad, idiomas, permisos, bitácora) y OpenRIN_Negocio (datos clínicos)'],
      ['Tarea programada', '«OpenRIN - Respaldo Nocturno (app)», diaria a las 03:00, cuenta SYSTEM'],
    ] } },
  ] },
  { titulo: 'Configuración', bloques: [
    { p: 'La configuración está en el archivo .dll.config de cada ejecutable. No contiene contraseñas: usa autenticación integrada de Windows.' },
    { tabla: { cab: ['Clave', 'Descripción'], filas: [
      ['ServicesDB', 'Cadena de conexión a OpenRIN_Services.'],
      ['NegocioDB', 'Cadena de conexión a OpenRIN_Negocio.'],
      ['BackupString', 'Conexión a master, usada para ejecutar los respaldos.'],
      ['MinimalLogLevel', 'Nivel mínimo de bitácora: Debug, Info, Warning, Error o Fatal.'],
      ['BackupFolder', 'Carpeta de respaldos (por defecto C:\\OpenRIN\\Backups).'],
      ['BackupDatabase', 'Base a respaldar por defecto (OpenRIN_Negocio).'],
    ] } },
    { nota: 'Si el servidor de base de datos cambia de nombre, edite solo las tres cadenas de conexión; no hace falta reinstalar.' },
  ] },
  { titulo: 'Actualización de la versión', bloques: [
    { ol: ['Haga un respaldo manual: OpenRIN.Herramientas.exe respaldo.', 'Cierre la aplicación en todos los equipos.', 'Ejecute el nuevo OpenRIN-Setup.exe sobre la instalación existente: reemplaza la aplicación y vuelve a aplicar los scripts, que son idempotentes (no borran datos).', 'Verifique «Integridad OK» y la tarea de respaldo.'] },
    { nota: 'El instalador conserva las bases de datos y no vuelve a cargar los datos de demostración si ya hay pacientes.' },
  ] },
  { titulo: 'Cambios en la base de datos', bloques: [
    { p: 'La base de negocio se versiona con migraciones de Entity Framework Core. Para generar el script de esquema completo e idempotente (el que usa el instalador):' },
    { cod: 'dotnet ef migrations script --idempotent --project Negocio.DAL --startup-project Negocio.DAL -o Negocio.DAL/Tools/script.sql' },
    { p: 'Los scripts de la base de servicios (bitácora, seguridad, permisos, localización y textos) están en Services/DAL/Tools y también son idempotentes. Si agrega una tabla firmada con DVH, inclúyala en la lista de IntegridadLogic y recalcule las firmas.' },
  ] },
  { titulo: 'Diagnóstico', bloques: [
    { ul: ['Registro del instalador: %TEMP%\\OpenRIN_instalacion.log.', 'Bitácora del sistema: tabla Logs de OpenRIN_Services y archivo log_fallback.txt.', 'Prueba de integridad: OpenRIN.Herramientas.exe integridad (código de salida 0 = correcto).', 'Prueba de respaldo: OpenRIN.Herramientas.exe respaldo (código 0 = respaldos generados y verificados).', 'Pruebas funcionales: proyecto Codigo/Pruebas (62 comprobaciones contra una base real).'] },
    { tabla: { cab: ['Error', 'Causa'], filas: [
      ['Error 916 al respaldar con la tarea programada', 'La cuenta SYSTEM no tiene acceso a las bases. El instalador le da db_owner y dbcreator; verifique que el login exista.'],
      ['«Idioma no soportado»', 'La tabla Idiomas está vacía o no se leyó: revise la conexión a OpenRIN_Services y ejecute localizacion_seed.sql con sqlcmd -f 65001.'],
      ['CREATE INDEX falla con QUOTED_IDENTIFIER', 'Ejecute el script de negocio con sqlcmd -I.'],
      ['Ruta demasiado larga al compilar', 'Clone o copie el proyecto en una carpeta corta (por ejemplo C:\\OpenRIN).'],
    ] } },
  ] },
  { titulo: 'Reconstruir el instalador', bloques: [
    { p: 'Requiere el SDK de .NET 8 o superior en el equipo de desarrollo.' },
    { cod: 'powershell -ExecutionPolicy Bypass -File Instalador\\Construir_Setup.ps1' },
    { p: 'El script publica la aplicación con el runtime incluido, arma app.zip, copia los scripts SQL y genera OpenRIN-Setup.exe con IExpress (incluido en Windows).' },
  ] },
];

// ------------------------------------------------------------------ MANUAL DEL PROGRAMADOR (CHM)
export const PROGRAMADOR = [
  { id: 'inicio', titulo: 'Manual del programador de OpenRIN', bloques: [
    { p: 'Este manual describe cómo está construido OpenRIN y cómo extenderlo: arquitectura en capas, proyectos de la solución, base de datos, patrones de diseño, seguridad, pruebas y publicación.' },
    { tabla: { cab: ['Dato', 'Valor'], filas: [
      ['Lenguaje y plataforma', 'C# 12 sobre .NET 8, Windows Forms'],
      ['Base de datos', 'SQL Server 2019 o superior (dos bases)'],
      ['Persistencia de negocio', 'Entity Framework Core 8'],
      ['Persistencia de servicios', 'ADO.NET (Microsoft.Data.SqlClient)'],
      ['PDF', 'QuestPDF (licencia comunitaria)'],
      ['Solución', 'Codigo/PlataformaACO.sln'],
    ] } },
  ] },
  { id: 'arquitectura', titulo: 'Arquitectura', bloques: [
    { p: 'La solución tiene cinco capas con dependencias en un solo sentido: la presentación depende de la lógica de negocio y de la fachada de servicios; la lógica accede a los datos a través del contexto o de los repositorios; nada depende de la presentación.' },
    { tabla: { cab: ['Capa', 'Proyecto', 'Responsabilidad'], filas: [
      ['Presentación', 'Negocio.UI', 'Formularios y controles de Windows Forms; no contiene reglas de negocio.'],
      ['Lógica de negocio', 'Negocio.BLL', 'Reglas: criticidad, tendencia, alertas, agenda, seguimiento, reportes, integridad.'],
      ['Dominio', 'Negocio.DomainModel', 'Entidades, enumeraciones, excepciones y objetos de valor.'],
      ['Acceso a datos de negocio', 'Negocio.DAL', 'DbContext de EF Core, repositorios, auditoría de cambios y migraciones.'],
      ['Servicios técnicos', 'Services', 'Seguridad, criptografía, localización, bitácora, respaldos, transacciones y excepciones; con su propia fachada, lógica y acceso a datos ADO.NET.'],
    ] } },
    { p: 'Hay dos bases de datos separadas: OpenRIN_Negocio (datos clínicos, mapeados con EF Core) y OpenRIN_Services (usuarios, permisos, idiomas, textos y bitácora, accedidos con ADO.NET parametrizado).' },
    { h: 'Criterios de diseño' },
    { ul: ['Alta cohesión y bajo acoplamiento entre capas; la UI no conoce la base de datos.', 'Las clases de servicios se exponen con fachadas estáticas (Services/Facade) y ocultan su lógica interna.', 'Un único punto de guardado (SaveChanges) donde se firman los dígitos verificadores y se audita.', 'Las reglas de validación lanzan ValidacionNegocioException y se registran en la bitácora.'] },
  ] },
  { id: 'estructura', titulo: 'Estructura de la solución', bloques: [
    { tabla: { cab: ['Carpeta', 'Contenido'], filas: [
      ['Codigo/Negocio.UI', 'Program, LoginForm, PrincipalForm, un control por módulo y los diálogos.'],
      ['Codigo/Negocio.BLL', 'Clases *Logic, una por área funcional.'],
      ['Codigo/Negocio.DomainModel', 'Entities, Enums, Exceptions y registros auxiliares.'],
      ['Codigo/Negocio.DAL', 'Context, Repositorios, Auditoria, Migrations y Tools/script.sql.'],
      ['Codigo/Services', 'BLL, DAL (Implementations, Interfaces, Tools con SQL), DomainModel y Facade.'],
      ['Codigo/Herramientas', 'OpenRIN.Herramientas: sembrar datos, respaldo e integridad por línea de comandos.'],
      ['Codigo/Pruebas', 'Pruebas funcionales de consola contra una base real.'],
      ['Instalador', 'Instalar.ps1, Desinstalar.ps1 y Construir_Setup.ps1.'],
      ['Diagramas', 'Diagramas draw.io (.drawio y .png) y su generador.'],
      ['Documentacion', 'Carpeta de Proyecto, manuales y fuentes de la ayuda.'],
    ] } },
  ] },
  { id: 'compilar', titulo: 'Compilar y ejecutar', bloques: [
    { ol: ['Instale el SDK de .NET 8 o superior y SQL Server (Express alcanza).', 'Copie el proyecto en una ruta corta (por ejemplo C:\\OpenRIN): las rutas largas rompen la compilación.', 'Cree las bases y cargue los scripts (vea el tema «Base de datos»).', 'Cree el archivo de configuración junto al ejecutable (vea «Configuración»).', 'Compile y ejecute:'] },
    { cod: 'cd Codigo\ndotnet build PlataformaACO.sln\ndotnet run --project Negocio.UI' },
    { h: 'Configuración' },
    { p: 'Cree Negocio.UI/App.config (no se versiona) tomando como modelo App.config.example. Con SQL Server local y autenticación de Windows:' },
    { cod: '<connectionStrings>\n  <add name="ServicesDB" connectionString="Server=.\\SQLEXPRESS;Database=OpenRIN_Services;Integrated Security=True;TrustServerCertificate=True;" />\n  <add name="NegocioDB"  connectionString="Server=.\\SQLEXPRESS;Database=OpenRIN_Negocio;Integrated Security=True;TrustServerCertificate=True;" />\n  <add name="BackupString" connectionString="Server=.\\SQLEXPRESS;Database=master;Integrated Security=True;TrustServerCertificate=True;" />\n</connectionStrings>' },
    { nota: 'En .NET 8 el archivo se copia como Negocio.UI.dll.config junto al ejecutable.' },
  ] },
  { id: 'basedatos', titulo: 'Base de datos', bloques: [
    { h: 'OpenRIN_Negocio (13 tablas)' },
    { p: 'Pacientes, ObrasSociales, Diagnosticos, HistoriasClinicas, MedicionesRIN, Alertas, Turnos, Seguimientos, EventosAdversos, Usuarios, ReportesEstadisticos, DigitosVerificadores y AuditoriaCambios. Once tablas llevan la columna DVH (todas menos DigitosVerificadores y AuditoriaCambios, que son de control). Las claves foráneas usan borrado restringido y el DNI es único entre pacientes activos.' },
    { h: 'OpenRIN_Services' },
    { p: 'Usuarios (hash PBKDF2, pregunta y respuesta de seguridad, intentos y bloqueo), Permisos (árbol composite), PerfilesPermisos, Idiomas, Textos y Logs.' },
    { h: 'Crear las bases' },
    { cod: 'sqlcmd -S .\\SQLEXPRESS -E -Q "CREATE DATABASE OpenRIN_Services; CREATE DATABASE OpenRIN_Negocio;"\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i Services\\DAL\\Tools\\script.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i Services\\DAL\\Tools\\security.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i Services\\DAL\\Tools\\permisos.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i Services\\DAL\\Tools\\localizacion.sql\nsqlcmd -S .\\SQLEXPRESS -E -d OpenRIN_Services -f 65001 -i Services\\DAL\\Tools\\localizacion_seed.sql\nsqlcmd -S .\\SQLEXPRESS -E -I -d OpenRIN_Negocio -f 65001 -i Negocio.DAL\\Tools\\script.sql' },
    { nota: '-f 65001 es obligatorio para los textos con acentos y -I para el script de negocio (índices filtrados). Luego cargue usuarios y datos de ejemplo con: OpenRIN.Herramientas.exe sembrar.' },
  ] },
  { id: 'patrones', titulo: 'Patrones de diseño', bloques: [
    { tabla: { cab: ['Patrón', 'Dónde', 'Para qué'], filas: [
      ['Singleton', 'SesionActual', 'Una única sesión de usuario, con lock para concurrencia.'],
      ['Composite', 'Permiso, PermisoAtomico, PermisoCompuesto', 'Árbol de permisos; hojas y grupos responden igual a Incluye().'],
      ['Observer', 'LocalizationLogic.IdiomaCambiado', 'Las vistas se suscriben y refrescan sus textos al cambiar el idioma.'],
      ['Repository', 'IPacienteRepositorio, RepositorioGenerico<T>', 'Encapsula el acceso a datos de pacientes y las operaciones CRUD.'],
      ['Facade', 'Services/Facade/*', 'Punto de entrada estático a los servicios técnicos.'],
    ] } },
  ] },
  { id: 'seguridad', titulo: 'Seguridad', bloques: [
    { ul: ['Contraseñas y respuestas de seguridad: PBKDF2-SHA256, 120 000 iteraciones y sal aleatoria de 16 bytes; formato «sal.iteraciones.hash»; comparación en tiempo constante.', 'Cifrado simétrico AES-256 (System.Security.Cryptography) aplicado a los campos clínicos de texto libre: EventoAdverso.Descripcion y AccionTomada, Turno.Observaciones, Seguimiento.Observaciones y DetalleDecision, Alerta.Descripcion y AccionResolucion. El IV se deriva del CONTEXTO del campo (entidad:propiedad) con HMAC-SHA256 sobre la clave, de modo que el cifrado es determinístico: el DVH —que firma el texto plano— sigue siendo estable y las lecturas devuelven el texto claro. La columna guarda «AES1$» + Base64; los valores anteriores (sin prefijo) se leen tal cual y se cifran en su próximo guardado. La clave se genera la primera vez y se protege con DPAPI en %LOCALAPPDATA%\OpenRIN\enc.key.', 'Anti fuerza bruta: 5 intentos fallidos bloquean la cuenta 15 minutos.', 'Acceso a base: autenticación integrada de Windows; no se guardan contraseñas de base en la configuración.', 'Permisos: cada módulo y acción se habilita consultando el árbol de permisos por código (PA001, PO001, SI001…).'] },
  ] },
  { id: 'integridad', titulo: 'Integridad DVH/DVV y control de cambios', bloques: [
    { p: 'NegocioDbContext.SaveChanges se sobrescribe y trabaja en tres fases:' },
    { ol: ['Se persisten los cambios para obtener los identificadores reales y se captura la auditoría.', 'Se calcula y escribe el DVH de cada fila afectada (campos y posición).', 'Se recalcula el DVV de cada tabla tocada, incluidas las que tuvieron filas eliminadas.'] },
    { p: 'Al iniciar, Program.Main llama a VerificacionArranque.Auditar() antes de mostrar el login; ante cualquier inconsistencia se muestra IntegridadVulneradaForm y se bloquea el acceso. IntegridadLogic.RecalcularTodo() recalcula todas las firmas (reparación).' },
    { p: 'La auditoría de cambios (AuditoriaDeCambios) serializa en JSON el estado anterior y el nuevo de cada entidad; AuditoriaLogic.Restaurar recompone un estado anterior y lo vuelve a firmar. La tabla AuditoriaCambios no se firma: es de solo agregado.' },
  ] },
  { id: 'localizacion', titulo: 'Localización (multiidioma)', bloques: [
    { p: 'Los idiomas y sus textos están en la base (tablas Idiomas y Textos); no se usan hojas de recursos. LocalizationService.ObtenerTexto(clave) devuelve el texto del idioma activo, o la clave si no existe. Se entregan es, en y zh-CN.' },
    { h: 'Agregar un texto' },
    { ol: ['Elija una clave jerárquica, por ejemplo agenda.nuevaColumna.', 'Agregue la fila en cada idioma a Services/DAL/Tools/localizacion_seed.sql (MERGE idempotente).', 'Use Texto("agenda.nuevaColumna") en el formulario y vuelva a aplicar los textos en AplicarTextos().'] },
    { h: 'Agregar un idioma' },
    { p: 'Desde Sistema y Bitácora > Idiomas se da de alta el idioma y se cargan sus leyendas, sin recompilar.' },
  ] },
  { id: 'extender', titulo: 'Cómo extender el sistema', bloques: [
    { h: 'Agregar un módulo' },
    { ol: ['Cree la clase de lógica en Negocio.BLL, que reciba el NegocioDbContext.', 'Cree el UserControl en Negocio.UI.', 'En PrincipalForm, en el bloque donde se arma el menú, agregue AgregarModulo("mod.nuevo", sysadmin || tiene("PA0xx")) y la rama correspondiente en MostrarModulo.', 'Agregue el permiso en Services/DAL/Tools/permisos.sql, su texto en localizacion_seed.sql y el tema de ayuda.'] },
    { h: 'Agregar una entidad' },
    { ol: ['Cree la clase en Negocio.DomainModel/Entities.', 'Agregue el DbSet y su configuración a NegocioDbContext.', 'Si debe firmarse, agréguela a IntegridadLogic y a la lista de tablas firmadas.', 'Genere la migración y regenere Negocio.DAL/Tools/script.sql.'] },
    { cod: 'dotnet ef migrations add NombreMigracion --project Negocio.DAL --startup-project Negocio.DAL\ndotnet ef migrations script --idempotent --project Negocio.DAL --startup-project Negocio.DAL -o Negocio.DAL/Tools/script.sql' },
    { h: 'Cambiar una regla de negocio' },
    { p: 'Las constantes de las reglas están en la lógica correspondiente: MedicionRINLogic (DistanciaAlta = 0,5; MargenBorde = 0,1), SeguimientoLogic (UmbralIntentosFallidos = 3) y ReporteLogic (UmbralOptimo = 80; UmbralSuboptimo = 50). Actualice también las pruebas.' },
  ] },
  { id: 'pruebas', titulo: 'Pruebas', bloques: [
    { p: 'El proyecto Codigo/Pruebas es un programa de consola que recorre los casos de uso contra una base real y verifica 109 comprobaciones: idiomas, seguridad, pacientes, historia clínica, RIN y criticidad, alertas, eventos, agenda, seguimiento, reportes, exportación, control de cambios, integridad y respaldo.' },
    { cod: 'copy Pruebas\\App.config.ejemplo Pruebas\\App.config\ndotnet run --project Pruebas' },
    { p: 'Termina con código 0 si todas pasan. Úselo después de cualquier cambio en la lógica o en la base.' },
  ] },
  { id: 'publicar', titulo: 'Publicar e instalador', bloques: [
    { p: 'Instalador/Construir_Setup.ps1 publica Negocio.UI y Herramientas como autocontenidos (win-x64), comprime la aplicación, copia los scripts SQL y genera OpenRIN-Setup.exe con IExpress. Instalar.ps1 y Desinstalar.ps1 se guardan con BOM UTF-8 para que Windows PowerShell 5.1 lea bien los acentos.' },
    { cod: 'powershell -ExecutionPolicy Bypass -File Instalador\\Construir_Setup.ps1' },
    { h: 'Ayuda en línea' },
    { p: 'Negocio.UI abre OpenRIN-Ayuda.chm con el botón Ayuda o F1, en el tema del módulo activo (PrincipalForm.MostrarAyuda). Las fuentes están en Documentacion/_fuente y se compilan con hhc.exe (HTML Help Workshop).' },
  ] },
  { id: 'convenciones', titulo: 'Convenciones de código', bloques: [
    { ul: ['Nombres en español para el dominio y las reglas; inglés solo en nombres técnicos del framework.', 'Documentación XML (<summary>) en las API públicas, con la referencia al requerimiento cuando existe.', 'Toda validación fallida se rechaza con ReglasNegocio.Rechazar, que deja el motivo y el usuario en la bitácora.', 'Los accesos a base con ADO.NET usan siempre parámetros (SqlHelper); no se concatenan valores en SQL.', 'Los textos visibles se piden con Texto(clave); no se escriben literales en los formularios.'] },
  ] },
];
