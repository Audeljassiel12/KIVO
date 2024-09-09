# 🏥 Sistema de Gestión Médica

Este proyecto es una **aplicación web** diseñada para consultorios médicos, permitiendo la **gestión de pacientes**, **médicos**, y **citas**. También incluye herramientas avanzadas como **consultas en vivo**, **mensajes de WhatsApp**, y **recetas personalizadas**. El sistema ofrece estadísticas al **MINSA** sobre enfermedades tratadas en clínicas privadas, facilitando un acceso a datos que antes no estaban disponibles.

---

## 🚀 **Funcionalidades Principales**

- **Gestión de Consultas y Pacientes**:
  - Registro y seguimiento de citas médicas.
  - Historial médico completo:
    - **Alergias**
    - **Historia patológica**
    - **Historia no patológica**
    - **Historia familiar**
    - **Historia obstétrica y ginecológica**
    - **Historia psiquiátrica**
    - **Dieta**

- **Módulo de Signos Vitales**:
  - Estatura, peso, temperatura, presión arterial, masa corporal, y más.

- **Resultados de Pruebas de Laboratorio**:
  - Subida y visualización de resultados de laboratorio.

- **Plan de Tratamiento**:
  - Registro del diagnóstico, tratamiento y seguimiento del paciente.

- **Seguimiento Nutricional**:
  - Control del progreso en las dietas de los pacientes.

- **Exploración Física y Topográfica**:
  - Registro detallado de exploraciones físicas.

- **Gestión de Procedimientos Médicos**:
  - Registro y seguimiento de procedimientos y solicitudes de laboratorio o imágenes.

- **Recetas Personalizadas y Plantillas Médicas**:
  - Generación de recetas y plantillas reutilizables.

- **Mensajes por WhatsApp**:
  - Envío de mensajes a los pacientes a través de WhatsApp.

- **Consultas en Vivo**:
  - Realización de videollamadas entre médicos y pacientes.

- **Notificaciones Personalizadas**:
  - Notificaciones de citas, recordatorios de medicamentos, entre otros.

- **Acceso para el MINSA (Ministerio de Salud)**:
  - Acceso a estadísticas de enfermedades tratadas y motivos de consulta en clínicas privadas, siempre que estas lo permitan.

---

## 🛠️ **Configuración del Sistema**

### **Centro Médico**:
Cada **centro médico** puede personalizar:

- **Logo**
- **Horarios de atención**
- **Especialidades**
- Configuración de servicios como:
  - Signos Vitales
  - Pruebas de Laboratorio
  - Plan de Tratamiento
  - Exploración física y más.
- **Página web personalizada**
- **Consultas en vivo**, WhatsApp, y notificaciones.

---

## 🛠️ **Tecnologías Utilizadas**

- **Backend**:
  - ASP.NET Core **8.0.401**
  - **Entity Framework Core**
  - **SQL Server**
  - ASP.NET **Identity** para la gestión de usuarios y roles.
  - **AutoMapper** para mapeo de entidades.

- **Frontend**:
  - **JavaScript**
  - **jQuery** (última versión)
  - **CSS** y **HTML**

- **Herramientas de Desarrollo**:
  - **Visual Studio 2022**
  - **Git Flow** para la gestión de ramas.
  - **GitKraken** para visualización y gestión del repositorio.

---

### Motivación

El proyecto surge de la necesidad de mejorar la gestión y seguimiento de la información médica tanto para los consultorios privados como para las instituciones públicas de salud. Actualmente, los consultorios médicos suelen almacenar los datos de los pacientes de manera aislada, lo que dificulta la colaboración y el acceso a información clave por parte de entidades como el **Ministerio de Salud (MINSA)**.

La motivación principal del proyecto es crear una plataforma integrada que:

- **Permita a los doctores gestionar de manera eficiente la información médica** de sus pacientes, incluyendo signos vitales, resultados de laboratorio, diagnóstico, y plan de tratamiento, todo en un solo lugar.
- **Facilite al MINSA el acceso a estadísticas de enfermedades** que antes quedaban en las clínicas privadas, permitiendo tomar decisiones más informadas a nivel público.
- **Empodere a los pacientes** a través de una plataforma donde puedan registrar su historial médico, llevar un seguimiento de la toma de medicamentos, subir resultados de exámenes, y recibir instrucciones médicas personalizadas.
- **Optimice la comunicación entre doctores y pacientes** mediante consultas en vivo, notificaciones personalizadas, y mensajes a través de plataformas como WhatsApp.
- **Proporcione herramientas flexibles para los doctores** como la posibilidad de personalizar plantillas, generar recetas electrónicas, y gestionar configuraciones visuales para cada especialidad y clínica.

En resumen, este proyecto busca cerrar la brecha entre los servicios de salud pública y privada, brindando una plataforma moderna y escalable que mejore la calidad de atención al paciente y optimice la toma de decisiones médicas.

## 🛠️ **Configuración Inicial del Entorno**

### **1. Clonar el Repositorio**

1. Abre una terminal en tu computadora.
2. Clona el repositorio con el siguiente comando:

    ```bash
    git clone https://github.com/Audeljassiel12/KIVO
    ```

3. Accede a la carpeta del proyecto:

    ```bash
    cd KIVO
    ```

### **2. Configuración de Visual Studio**:
- Instalar la última versión de **Visual Studio**.
- Instalar el SDK de .NET **8.0.401**.
- Instalar la extensión para trabajar con **SQL Server**.

### **3. Instalación de Dependencias de NuGet**:
- Abrir la solución en Visual Studio y restaurar los paquetes **NuGet**.
- Verificar que las dependencias de **Entity Framework**, **AutoMapper**, y **ASP.NET Identity** estén correctamente instaladas.

### **4. Configuración de Base de Datos**:
- Ejecutar una instancia de **SQL Server**.
- Actualizar la cadena de conexión en el archivo `appsettings.json`.
- Ejecutar las migraciones de **Entity Framework** con el siguiente comando:

    ```bash
    dotnet ef database update
    ```

### **5. Configuración de jQuery y Librerías Front-End**:
- Asegurarse de tener la última versión de **jQuery** instalada.
- Instalar cualquier otra dependencia de **JavaScript**/**CSS** si es necesario.

### **6. Uso de Git Flow y GitKraken**:
- Git Flow será utilizado para gestionar el flujo de trabajo de ramas:
  - **main**: versión de producción.
  - **develop**: integración de nuevos cambios.
  - **feature/**: desarrollo de nuevas características.
  - **release/**: preparación para lanzamientos.
  - **hotfix/**: correcciones urgentes en producción.
  
- Utilizar **GitKraken** para la visualización y gestión de las ramas:
  - Realizar checkout de las ramas **feature**, **develop**, y **main** según sea necesario.

### **7. Compilación y Ejecución**:
- Una vez configurado todo, ejecutar el proyecto desde **Visual Studio**.

---

## 📊 **Integraciones Especiales**

- **Consultas en Vivo** y gestión de citas en tiempo real.
- Página web personalizada para cada consultorio médico.
- Envío de mensajes por **WhatsApp** y generación de notificaciones automáticas.
- **Plantillas** reutilizables para diagnósticos, procedimientos, y recetas.
- Integración con el **MINSA** para acceder a estadísticas de enfermedades.

---

