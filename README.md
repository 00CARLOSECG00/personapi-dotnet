# Grupo 6
Carlos Enrique Caicedo Guerrero
Juan Andrés Rodriguez Rubio
Harry Esteban Sanchez


---

## 🧩 Configuración de la base de datos

La base de datos se llama `arq_per_db` y se crea automáticamente dentro del contenedor SQL Server.  
El usuario predeterminado es:

| Parámetro | Valor |
|------------|--------|
| Servidor | `personapi_sql,1433` |
| Usuario | `sa` |
| Contraseña | `Admin123$!` |
| Base de datos | `arq_per_db` |

Si deseas crear las tablas manualmente, podés usar este script:
```sql
USE arq_per_db;
CREATE TABLE persona (...);
CREATE TABLE profesion (...);
CREATE TABLE telefono (...);
CREATE TABLE estudios (...);

# Ejecución con Docker COmpose
sudo docker compose up -d --build

Esto levanta dos contenedores:
-personapi_sql → SQL Server 2022
-personapi_app → API .NET 8

# Endpoints principales
http://localhost:8080/swagger
| Recurso     | Endpoint base     | Descripción               |
| ----------- | ----------------- | ------------------------- |
| Personas    | `/api/personas`   | CRUD completo de personas |
| Profesiones | `/api/profesions` | CRUD de profesiones       |
| Teléfonos   | `/api/telefonos`  | CRUD de teléfonos         |
| Estudios    | `/api/estudios`   | CRUD de estudios          |
