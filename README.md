# Sistema de Checador con Captura de Webcam

Sistema de asistencias con captura de fotos desde webcam y visualizador de registros. Desarrollado en C# con .NET 8 y SQL Server.

## 📋 Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Proyectos Incluidos](#proyectos-incluidos)
- [Requisitos Previos](#requisitos-previos)
- [Instalación de Base de Datos](#instalación-de-base-de-datos)
- [Configuración](#configuración)
- [Uso](#uso)
- [Estructura de Archivos](#estructura-de-archivos)
- [Características](#características)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)

## 📌 Descripción General

Este sistema permite:
- **Capturar asistencias** mediante foto de webcam con fecha/hora automática
- **Visualizar y consultar** todas las asistencias registradas
- **Filtrar por equipo y rango de fechas** para búsquedas avanzadas
- **Guardar fotos** de los registros de asistencia
- **Configuración centralizada** mediante archivo `appsettings.json`

## 🗂️ Proyectos Incluidos

### 1. **ChecadorPc** 
Aplicación principal para registrar asistencias con captura de webcam.

**Funcionalidades:**
- ✅ Captura automática de foto desde webcam
- ✅ Obtiene fecha/hora de la API WorldTime (zona horaria México)
- ✅ Extrae nombre del equipo automáticamente
- ✅ Guarda registro en base de datos SQL Server
- ✅ Interfaz simple y directa

**Archivos principales:**
- `Form1.cs` - Interfaz principal de captura
- `Captura.cs` - Modelo de datos
- `CapturaRepository.cs` - Acceso a base de datos
- `ConfigurationHelper.cs` - Lectura de configuración
- `appsettings.json` - Cadena de conexión

### 2. **VisorAsistencias**
Aplicación para consultar y visualizar todas las asistencias registradas.

**Funcionalidades:**
- ✅ Filtrar por equipo específico o todos
- ✅ Filtrar por rango de fechas
- ✅ Visualizar fotos en grande
- ✅ Navegar entre registros (Anterior/Siguiente)
- ✅ Guardar fotos seleccionadas
- ✅ DataGridView con lista completa de capturas

**Archivos principales:**
- `Form1.cs` - Interfaz principal de consulta
- `CapturaRepository.cs` - Consultas a base de datos
- `Captura.cs` - Modelo de datos
- `ConfigurationHelper.cs` - Lectura de configuración
- `appsettings.json` - Cadena de conexión

## 📦 Requisitos Previos

### Software necesario:
- **.NET 8 Runtime** - [Descargar](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)
- **SQL Server Express 2019 o superior** - [Descargar](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- **Visual Studio 2022** (opcional, para desarrollo)
- **Webcam** conectada y funcional

### Paquetes NuGet (se instalan automáticamente):