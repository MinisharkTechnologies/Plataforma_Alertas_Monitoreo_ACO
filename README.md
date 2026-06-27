# Plataforma Integral de Alertas y Monitoreo para Pacientes Anticoagulados

**Autor:** Carlos Santiago Muñiz Cortés
**Profesor:** Gastón Matías Weingand
**Institución:** Colegio Leonardo Da Vinci
**Materia:** Prácticas Profesionalizantes III

## Descripción del Proyecto

Este repositorio contiene el análisis, diseño, documentación e implementación de un prototipo funcional para un sistema de información que optimiza la gestión de consultorios hematológicos. El proyecto abarca desde el modelado de procesos de negocio (BPM) y la ingeniería de requerimientos, hasta la arquitectura de software multicapa y la entrega de una aplicación de escritorio Windows Forms con una estética Frutiger Aero, integrada mediante WebView2.

## Estructura del Repositorio

*   `0_Negocio/`: Modelado de Procesos del Negocio (BPM), Casos de Uso del Negocio (CUN), Infraestructura Tecnológica y Stakeholders.
*   `1_Requerimientos/`: Especificación de Requerimientos Funcionales (REQ-FUNC), No Funcionales (REQ-NF) y de Arquitectura de Base (REQ-ARQ).
*   `2_Diagrama_de_Dominio/`: Modelo conceptual de las entidades del dominio.
*   `3_Casos_De_Uso/`: Especificaciones detalladas de los 13 Casos de Uso del Sistema (UC-01 a UC-13), con diagramas de clases, secuencia y modelos relacionales asociados.
*   `4_Diagramas_De_Clases/`: Diagramas de clases globales de las capas de los proyectos `Negocio` y `Services`.
*   `5_Diagrama_ERD/`: Diagramas de Entidad-Relación (ERD) globales para los proyectos Negocio y Services (persistencia en SQL Server).
*   `6_Diagrama_De_Componentes/`: Diagrama de componentes ilustrando la arquitectura desacoplada y la comunicación entre proyectos.
*   `7_User_Interface_Model/`: Mapa de navegación por rol, prototipo web funcional (HTML/CSS/JS/SVG) con estética Frutiger Aero y guía de integración con WebView2.
*   `8_Despliegue/`: Diagrama de despliegue y guía para la generación del ejecutable autocontenido (`dotnet publish`).

## Tecnologías y Estándares Utilizados

*   **Framework de UI:** Windows Forms (.NET 8) con integración WebView2.
*   **Lenguaje de Programación:** C#.
*   **Prototipado Visual:** HTML5, CSS3 (Glassmorphism + Frutiger Aero), JavaScript y SVG.
*   **Base de Datos:** Microsoft SQL Server (modelado relacional).
*   **Arquitectura:** Multicapa desacoplada (UI/Windows Forms, BLL, DAL, DomainModel + Facade de Servicios).