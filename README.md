## 📋 Descripción del Proyecto

PersonAPI es una aplicación web desarrollada en **.NET 8** que gestiona información de personas, profesiones, teléfonos y estudios académicos. El proyecto implementa una arquitectura de **API REST** con **Swagger** para documentación interactiva, y una interfaz web **MVC** para gestión visual de los datos.

### Características Principales

- ✅ **4 Entidades** con relaciones bien definidas
- ✅ **CRUD completo** (6 operaciones por entidad: GetAll, GetById, Add, Update, Delete, Count)
- ✅ **API REST** documentada con Swagger
- ✅ **5 Pantallas MVC** para gestión visual
- ✅ **Docker Compose** para despliegue completo
- ✅ **SQL Server 2022** como base de datos

---

## 🏗️ Arquitectura y Tecnologías

### Stack Tecnológico

- **Framework**: .NET 8.0
- **ORM**: Entity Framework Core 8.0.8
- **Base de Datos**: Microsoft SQL Server 2022
- **API**: ASP.NET Core Web API
- **Frontend**: ASP.NET Core MVC con Razor Views
- **Documentación API**: Swagger/OpenAPI (Swashbuckle)
- **Contenedores**: Docker & Docker Compose

### Patrones de Diseño

- **Repository Pattern**: Separación de lógica de acceso a datos
- **Dependency Injection**: Inyección de dependencias nativa de ASP.NET Core
- **MVC Pattern**: Separación de responsabilidades en la capa de presentación

---

## 🔧 Requisitos Previos

Para ejecutar el proyecto, necesitas tener instalado:

- **Docker Desktop** (Windows/Mac/Linux)
  - Docker Engine 20.10 o superior
  - Docker Compose 2.0 o superior
- **.NET SDK 8.0** (opcional, solo si quieres ejecutar sin Docker)

### Verificar Instalación

```bash
# Verificar Docker
docker --version
docker compose version

# Verificar .NET (opcional)
dotnet --version
```

---

## ⚙️ Configuración del Ambiente

### 1. Clonar el Repositorio

```bash
git clone <url-del-repositorio>
cd personapi-dotnet
```

### 2. Configuración de la Base de Datos

La base de datos se crea automáticamente cuando se ejecuta el contenedor de SQL Server. Si deseas crear las tablas manualmente, puedes ejecutar el script `DDL.SQL` que se encuentra en la raíz del proyecto.

#### Parámetros de Conexión

| Parámetro | Valor |
|-----------|-------|
| **Servidor** | `personapi_sql,1433` (dentro de Docker) o `localhost,1433` (desde el host) |
| **Usuario** | `sa` |
| **Contraseña** | `Admin123$!` |
| **Base de Datos** | `arq_per_db` |

#### Script de Creación Manual (Opcional)

Si necesitas crear las tablas manualmente, ejecuta:

```sql
-- Conectar a SQL Server
sqlcmd -S localhost,1433 -U sa -P 'Admin123$!' -Q "CREATE DATABASE arq_per_db"

-- Ejecutar el script DDL
sqlcmd -S localhost,1433 -U sa -P 'Admin123$!' -d arq_per_db -i DDL.SQL
```

### 3. Configuración de la Aplicación

El archivo `appsettings.json` contiene la cadena de conexión por defecto. En Docker, esta se sobrescribe mediante variables de entorno en `docker-compose.yml`.

**appsettings.json**:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=personapi_sql,1433;Database=arq_per_db;User Id=sa;Password=Admin123$!;TrustServerCertificate=True;Encrypt=False;MultipleActiveResultSets=True;"
  }
}
```

---

## 🚀 Compilación y Despliegue

### Opción 1: Despliegue con Docker Compose (Recomendado)

Esta es la forma más sencilla y recomendada para ejecutar el proyecto completo.

#### Pasos:

1. **Asegúrate de estar en el directorio raíz del proyecto**

```bash
cd personapi-dotnet
```

2. **Construir y levantar los contenedores**

```bash
# Windows PowerShell
docker compose up -d --build

# Linux/Mac
sudo docker compose up -d --build
```

Este comando:
- Construye la imagen de la aplicación .NET
- Descarga y configura SQL Server 2022
- Crea los volúmenes necesarios
- Levanta ambos contenedores en segundo plano

3. **Verificar que los contenedores están corriendo**

```bash
docker compose ps
```

Deberías ver:
- `personapi_sql` (SQL Server 2022)
- `personapi_app` (Aplicación .NET)

4. **Ver los logs (opcional)**

```bash
# Logs de todos los servicios
docker compose logs -f

# Logs solo de la aplicación
docker compose logs -f personapi_app

# Logs solo de SQL Server
docker compose logs -f personapi_sql
```

5. **Detener los contenedores**

```bash
docker compose down
```

6. **Detener y eliminar volúmenes (limpia completamente)**

```bash
docker compose down -v
```

### Opción 2: Ejecución Local sin Docker

Si prefieres ejecutar la aplicación sin Docker:

1. **Asegúrate de tener SQL Server instalado localmente**

2. **Actualiza la cadena de conexión en `appsettings.json`**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=arq_per_db;User Id=sa;Password=Admin123$!;TrustServerCertificate=True;Encrypt=False;MultipleActiveResultSets=True;"
  }
}
```

3. **Restaurar dependencias y ejecutar**:

```bash
dotnet restore
dotnet build
dotnet run
```

La aplicación estará disponible en:
- **API/Swagger**: http://localhost:5000/swagger
- **MVC**: http://localhost:5000

---

## 📡 Endpoints de la API (Puerto 8080)

Todas las APIs están disponibles en el puerto **8080** y documentadas en Swagger.

### Base URL
```
http://localhost:8080
```

### Swagger UI
```
http://localhost:8080/swagger
```

---

### 1. API de Personas (`/api/persona`)

| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| `GET` | `/api/persona` | Obtener todas las personas | - |
| `GET` | `/api/persona/{cc}` | Obtener una persona por cédula | `cc` (int) |
| `POST` | `/api/persona` | Crear una nueva persona | Body: JSON Persona |
| `PUT` | `/api/persona/{cc}` | Actualizar una persona | `cc` (int), Body: JSON Persona |
| `DELETE` | `/api/persona/{cc}` | Eliminar una persona | `cc` (int) |
| `GET` | `/api/persona/count` | Contar total de personas | - |

**Ejemplo de Body para POST/PUT**:
```json
{
  "cc": 1234567890,
  "nombre": "Juan",
  "apellido": "Pérez",
  "genero": "M",
  "edad": 30
}
```

---

### 2. API de Profesiones (`/api/profesion`)

| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| `GET` | `/api/profesion` | Obtener todas las profesiones | - |
| `GET` | `/api/profesion/{id}` | Obtener una profesión por ID | `id` (int) |
| `POST` | `/api/profesion` | Crear una nueva profesión | Body: JSON Profesion |
| `PUT` | `/api/profesion/{id}` | Actualizar una profesión | `id` (int), Body: JSON Profesion |
| `DELETE` | `/api/profesion/{id}` | Eliminar una profesión | `id` (int) |
| `GET` | `/api/profesion/count` | Contar total de profesiones | - |

**Ejemplo de Body para POST/PUT**:
```json
{
  "id": 1,
  "nom": "Ingeniero de Sistemas",
  "des": "Profesional especializado en desarrollo de software"
}
```

---

### 3. API de Teléfonos (`/api/telefono`)

| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| `GET` | `/api/telefono` | Obtener todos los teléfonos | - |
| `GET` | `/api/telefono/{num}` | Obtener un teléfono por número | `num` (string) |
| `POST` | `/api/telefono` | Crear un nuevo teléfono | Body: JSON Telefono |
| `PUT` | `/api/telefono/{num}` | Actualizar un teléfono | `num` (string), Body: JSON Telefono |
| `DELETE` | `/api/telefono/{num}` | Eliminar un teléfono | `num` (string) |
| `GET` | `/api/telefono/count` | Contar total de teléfonos | - |

**Ejemplo de Body para POST/PUT**:
```json
{
  "num": "3001234567",
  "oper": "Claro",
  "duenio": 1234567890
}
```

---

### 4. API de Estudios (`/api/estudio`)

| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| `GET` | `/api/estudio` | Obtener todos los estudios | - |
| `GET` | `/api/estudio/{idProf}/{ccPer}` | Obtener un estudio específico | `idProf` (int), `ccPer` (int) |
| `POST` | `/api/estudio` | Crear un nuevo estudio | Body: JSON Estudio |
| `PUT` | `/api/estudio/{idProf}/{ccPer}` | Actualizar un estudio | `idProf` (int), `ccPer` (int), Body: JSON Estudio |
| `DELETE` | `/api/estudio/{idProf}/{ccPer}` | Eliminar un estudio | `idProf` (int), `ccPer` (int) |
| `GET` | `/api/estudio/count` | Contar total de estudios | - |

**Ejemplo de Body para POST/PUT**:
```json
{
  "idProf": 1,
  "ccPer": 1234567890,
  "fecha": "2020-01-15",
  "univer": "Universidad Javeriana"
}
```

---

## 🖥️ Endpoints MVC (Puerto 8080)

Las pantallas web están disponibles en el mismo puerto **8080** con rutas MVC.

### Base URL
```
http://localhost:8080
```

---

### 1. Página de Inicio
- **URL**: `http://localhost:8080/` o `http://localhost:8080/Home/Index`
- **Descripción**: Página principal del sistema

---

### 2. Gestión de Personas (`/PersonaMvc`)

| Ruta | Método | Descripción |
|------|--------|-------------|
| `/PersonaMvc` o `/PersonaMvc/Index` | GET | Listar todas las personas |
| `/PersonaMvc/Create` | GET | Mostrar formulario de creación |
| `/PersonaMvc/Create` | POST | Procesar creación de persona |
| `/PersonaMvc/Edit/{cc}` | GET | Mostrar formulario de edición |
| `/PersonaMvc/Edit` | POST | Procesar actualización de persona |
| `/PersonaMvc/Delete/{cc}` | GET | Eliminar una persona |
| `/PersonaMvc/Buscar` | GET | Buscar persona por cédula |

---

### 3. Gestión de Profesiones (`/ProfesionMvc`)

| Ruta | Método | Descripción |
|------|--------|-------------|
| `/ProfesionMvc` o `/ProfesionMvc/Index` | GET | Listar todas las profesiones |
| `/ProfesionMvc/Create` | GET | Mostrar formulario de creación |
| `/ProfesionMvc/Create` | POST | Procesar creación de profesión |
| `/ProfesionMvc/Edit/{id}` | GET | Mostrar formulario de edición |
| `/ProfesionMvc/Edit` | POST | Procesar actualización de profesión |
| `/ProfesionMvc/Delete/{id}` | GET | Eliminar una profesión |

---

### 4. Gestión de Teléfonos (`/TelefonoMvc`)

| Ruta | Método | Descripción |
|------|--------|-------------|
| `/TelefonoMvc` o `/TelefonoMvc/Index` | GET | Listar todos los teléfonos |
| `/TelefonoMvc/Create` | GET | Mostrar formulario de creación |
| `/TelefonoMvc/Create` | POST | Procesar creación de teléfono |
| `/TelefonoMvc/Edit/{num}` | GET | Mostrar formulario de edición |
| `/TelefonoMvc/Edit` | POST | Procesar actualización de teléfono |
| `/TelefonoMvc/Delete/{num}` | GET | Eliminar un teléfono |

---

### 5. Gestión de Estudios (`/EstudioMvc`)

| Ruta | Método | Descripción |
|------|--------|-------------|
| `/EstudioMvc` o `/EstudioMvc/Index` | GET | Listar todos los estudios |
| `/EstudioMvc/Create` | GET | Mostrar formulario de creación |
| `/EstudioMvc/Create` | POST | Procesar creación de estudio |
| `/EstudioMvc/Edit/{idProf}/{ccPer}` | GET | Mostrar formulario de edición |
| `/EstudioMvc/Edit` | POST | Procesar actualización de estudio |
| `/EstudioMvc/Delete/{idProf}/{ccPer}` | GET | Eliminar un estudio |

---

## 👥 Autores

**Grupo 6**
- Carlos Enrique Caicedo Guerrero
- Juan Andrés Rodriguez Rubio
- Harry Esteban Sanchez

